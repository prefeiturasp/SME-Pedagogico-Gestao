using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SME.Pedagogico.Gestao.Aplicacao;
using SME.Pedagogico.Gestao.Data.Business;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.DTO;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoNovoSGP;
using SME.Pedagogico.Gestao.Infra;
using SME.Pedagogico.Gestao.WebApp.Contexts;
using SME.Pedagogico.Gestao.WebApp.Models;
using SME.Pedagogico.Gestao.WebApp.Models.Auth;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.WebApp.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region ==================== ATTRIBUTES ====================

        private IConfiguration _config; // Objeto para recuperar informações de configuração do arquivo appsettings.json
        private readonly SMEManagementContext _db; // Objeto context referente ao banco smeCoreDB
        private readonly NovoSGPAPI _apiNovoSgp; //Objeto para comunicação com a API do Novo SGP
        private readonly Profile _profile;
        private readonly AbrangenciaAPI _abrangenciaAPI;

        #endregion ==================== ATTRIBUTES ====================

        #region ==================== CONSTRUCTORS ====================

        /// <summary>
        /// Construtor padrão para o AuthController, faz injeção de dependências de IConfiguration e SMEManagementContext.
        /// </summary>
        /// <param name="config">Depêndencia de configurações</param>
        /// <param name="db">Depêndencia de dataContext (SMEManagementContext)</param>
        public AuthController(IConfiguration config, SMEManagementContext db)
        {
            _config = config;
            _db = db;
            _apiNovoSgp = new NovoSGPAPI();
            _profile = new Profile(config);
            _abrangenciaAPI = new AbrangenciaAPI();
        }

        #endregion ==================== CONSTRUCTORS ====================

        #region ==================== METHODS ====================

        #region -------------------- PRIVATE --------------------

        /// <summary>
        /// Método para validar as credenciais de login do usuário.
        /// </summary>
        /// <param name="credential">Objeto que contém informações da credencial do usuário</param>
        /// <returns>Objeto contendo informações do usuário encontrado, caso não seja encontrado nenhum usuário com correspondente a credencial enviada o método retorna nulo.</returns>
        private async Task<ClientUserModel> Authenticate(CredentialModel credential)
        {
            // Configurações iniciais
            string url = "http://identity.sme.prefeitura.sp.gov.br/Account/Login";
            CookieContainer cookies = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;

            // Inicialização do cliente para requisições (GET e POST)
            using (HttpClient client = new HttpClient(handler))
            using (HttpResponseMessage getResponse = await client.GetAsync(url))
            using (HttpContent content = getResponse.Content)
            {
                // Extrai o anti forgery token da pagina da requisição GET
                string result = await content.ReadAsStringAsync();
                string forgeryToken = ExtractDataByName(result, "__RequestVerificationToken");

                // Faz o POST dos dados (login) caso o usuário não esteja logado
                if (forgeryToken != string.Empty)
                {
                    // Cria os dados necessários que compõe o corpo da requisição
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add("__RequestVerificationToken", forgeryToken); // Adiciona o Anti Forgery Token
                    data.Add("Username", credential.Username); // Adiciona o nome de usuário
                    data.Add("Password", credential.Password); // Adiciona a senha
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url) { Content = new FormUrlEncodedContent(data) }; // Encoda os dados no formato correto dentro da requisição
                    HttpResponseMessage postResponse = await client.SendAsync(request); // Executa a requisição

                    // Caso a requisição não ocorra corretamente, retorna 'null'
                    if (!postResponse.IsSuccessStatusCode)
                        return (null);

                    result = await postResponse.Content.ReadAsStringAsync();

                    // Caso o usuário não seja autenticado, retorna 'null'
                    if (result.StartsWith("<form method='post' action='http://coresso.sme.prefeitura.sp.gov.br/Login.ashx'>") == false)
                        return (null);
                }

                // Cria e pega informações do usuário
                ClientUserModel user = await GetUser(credential.Username);

                if (user == null)
                    user = new ClientUserModel() { Username = credential.Username };

                // Pega os cookies da pagina
                user.Cookies = cookies.GetCookies(new Uri(url)).Cast<Cookie>();

                // Preenche as informações do identity
                user.Identity = new IdentityModel();
                user.Identity.code = ExtractDataByName(result, "code");
                user.Identity.id_token = ExtractDataByName(result, "id_token");
                user.Identity.access_token = ExtractDataByName(result, "access_token");
                user.Identity.token_type = ExtractDataByName(result, "token_type");
                user.Identity.expires_in = ExtractDataByName(result, "expires_in");
                user.Identity.scope = ExtractDataByName(result, "scope");
                user.Identity.state = ExtractDataByName(result, "state");
                user.Identity.sesion_state = ExtractDataByName(result, "session_state");

                return (user);
            }
        }

        /// <summary>
        /// Método para gerar o token de acesso.
        /// </summary>
        /// <param name="user">Objeto contendo informações do usuário</param>
        /// <returns>Token gerado à partir das informações do usuário.</returns>
        private string CreateToken(ClientUserModel user)
        {
            return (CreateToken(user.Username));
        }

        /// <summary>
        /// Método para gerar o token de acesso.
        /// </summary>
        /// <param name="username">Nome do usuário</param>
        /// <returns>Token gerado à partir das informações do usuário.</returns>
        private string CreateToken(string username)
        {
            // Adicionar Claims para restringir o acesso dos usuários a determinados conteudos
            Claim[] claims = new Claim[]
            {
                //new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim("username", username),
                //new Claim(JwtRegisteredClaimNames.Email, user.email),
                //new Claim(JwtRegisteredClaimNames.Birthdate, user.birthdate.ToString("yyyy-MM-dd")),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(
                _config["JwtSettings:Issuer"],
                _config["JwtSettings:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(10), // Define o tempo de validade de cada token
                signingCredentials: creds);

            return (new JwtSecurityTokenHandler().WriteToken(token));
        }

        /// <summary>
        /// Método para encontrar um usuário pelo username. Não está implementado corretamente ainda.
        /// </summary>
        /// <param name="username">Nome de usuário a ser retornado</param>
        /// <returns>Usuário com o username especificado.</returns>
        private async Task<ClientUserModel> GetUser(string username)
        {
            string connectionString = @"Server=10.49.16.23\SME_PRD;Database=GestaoPedagogica;User Id=Caique.Santos;Password=Antares2014;";
            ClientUserModel clientUser = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("API_SMECORE_GET_USER_INFO", con);
                    cmd.Parameters.Add(new SqlParameter("@usu_login", username));
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader;

                    con.Open();
                    reader = cmd.ExecuteReader();
                    reader.Read();

                    clientUser = new ClientUserModel() { Username = username };
                    clientUser.Name = reader["nome"].ToString();
                    clientUser.Email = reader["email"].ToString();
                }
                catch (Exception ex)
                {
                    return (null);
                }
            }

            return (clientUser);
        }

        /// <summary>
        /// Método para extrair atributos de uma página html (raw) pela propriedade 'name'. Só funciona se a propriedade 'name' estiver antes do 'value'.
        /// </summary>
        /// <param name="source">Fonte do html (raw)</param>
        /// <param name="name">Nome do atributo desejado</param>
        /// <returns>Valor (value) do atributo desejado</returns>
        private static string ExtractDataByName(string source, string name)
        {
            int startIndex = source.IndexOf(string.Format("name=\"{0}\"", name));
            string delimiter = "\"";

            if (startIndex < 0)
            {
                startIndex = source.IndexOf(string.Format("name='{0}'", name));
                delimiter = "'";

                if (startIndex < 0)
                    return (string.Empty);
            }

            int firstIndex = source.IndexOf("value=" + delimiter, startIndex) + 7;
            int lastIndex = source.IndexOf(">", startIndex);
            string data = source.Substring(firstIndex, lastIndex - firstIndex - 3);

            return (data);
        }

        /// <summary>
        /// Método para retornar as funções/cargos/perfis do usuário pelo 'username'
        /// </summary>
        /// <param name="username">Nome de usuário a ser pesquisado</param>
        /// <returns>Retorna uma lista de UserRoleModel</returns>
        private async Task<List<UserRoleModel>> GetUserRoles(string username)
        {
            List<UserRoleModel> userRoles =
                (from current in await Data.Business.Authentication.GetUserRoles(username)
                 select new UserRoleModel()
                 {
                     RoleId = current.RoleId,
                     RoleName = current.Role.Name,
                     AccessLevelId = current.AccessLevelId,
                     AccessLevel = current.AccessLevel.Value,
                     Description = current.AccessLevel.Description,
                     PerfilId = current.PerfilId
                 }).ToList();

            return (userRoles);
        }

        private async Task<Dictionary<string, string>> SetOccupationsRF(string rf, RetornoCargosServidorDTO occupations)
        {
            var ProfileBusiness = new Profile(_config);

            string roleName = "";
            string accessLevel = "";
            bool haveOccupationAccess;
            bool isTeacher = false;
            int qtdIsTeacher = 0;
            var ListcodeOcupations = new Dictionary<string, string>();

            if (occupations != null)
            {
                //Implementar regra de cargo sobrePosto 
                foreach (var occupation in occupations.cargos)
                {
                    string codigoCargoAtivo = ProfileBusiness.RetornaCargoAtivo(occupation);
                    haveOccupationAccess = false;

                    switch (codigoCargoAtivo)
                    {
                        case "3239":
                        case "3301":
                            roleName = "Professor";
                            accessLevel = "32";
                            haveOccupationAccess = true;
                            isTeacher = true;
                            qtdIsTeacher += 1;
                            break;
                        case "3310":
                            roleName = "Professor";
                            accessLevel = "32";
                            haveOccupationAccess = true;
                            qtdIsTeacher += 1;
                            break;
                        case "3379":
                            roleName = "CP";
                            accessLevel = "27";
                            haveOccupationAccess = true;
                            break;
                        case "3360":
                            roleName = "Diretor";
                            accessLevel = "27";
                            haveOccupationAccess = true;
                            break;
                        case "3085":
                            roleName = "AD";
                            accessLevel = "26";
                            haveOccupationAccess = true;
                            break;
                        default:
                            haveOccupationAccess = false;
                            break;
                    }

                    if (haveOccupationAccess)
                    {
                        try
                        {
                            if (isTeacher)
                            {

                                if (qtdIsTeacher == 1)
                                {
                                    var profileBusiness = new Profile(_config);

                                    var profileInformation = await profileBusiness.GetProfileEmployeeInformation(rf, codigoCargoAtivo, DateTime.Now.Year.ToString(), default);
                                    if (profileInformation != null)
                                    {
                                        await Authentication.SetRole(rf, roleName, accessLevel, Perfil.ObterPerfis().FirstOrDefault(x => x.RoleName.Equals(roleName)).PerfilGuid);
                                        ListcodeOcupations.Add(roleName, codigoCargoAtivo);
                                    }
                                }
                            }
                            else
                            {
                                await Authentication.SetRole(rf, roleName, accessLevel, Perfil.ObterPerfis().FirstOrDefault(x => x.RoleName.Equals(roleName)).PerfilGuid);
                                ListcodeOcupations.Add(roleName, codigoCargoAtivo);
                            }

                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        //verifica se tem turma atribuida
                    }
                }
            }
            return ListcodeOcupations;
        }

        //private async Task<Dictionary<string,string>> SetOccupationsRF(string rf, RetornoCargosServidorDTO occupations)
        //{
        //    var ProfileBusiness = new Profile(_config);

        //    string roleName = "";
        //    string accessLevel = "";
        //    bool haveOccupationAccess;
        //    var ListcodeOcupations = new Dictionary<string, string>();

        //    if (occupations != null)
        //    {
        //        //Implementar regra de cargo sobrePosto 

        //        foreach (var occupation in occupations.cargos)
        //        {

        //           string codigoCargoAtivo = ProfileBusiness.RetornaCargoAtivo(occupation);
        //            haveOccupationAccess = false;
        //            switch (codigoCargoAtivo)
        //            {
        //                case "3239":
        //                    roleName = "Professor";
        //                    accessLevel = "32";
        //                    haveOccupationAccess = true;
        //                    break;
        //                case "3301":
        //                    roleName = "Professor";
        //                    accessLevel = "32";
        //                    haveOccupationAccess = true;
        //                    break;
        //                case "3336":
        //                    roleName = "Professor";
        //                    accessLevel = "32";
        //                    haveOccupationAccess = true;
        //                    break;
        //                case "3310":
        //                    roleName = "Professor";
        //                    accessLevel = "32";
        //                    haveOccupationAccess = true;
        //                    break;
        //                case "3379":
        //                    roleName = "CP";
        //                    accessLevel = "27";
        //                    haveOccupationAccess = true;
        //                    break;
        //                case "3360":
        //                    roleName = "Diretor";
        //                    accessLevel = "27";
        //                    haveOccupationAccess = true;
        //                    break;
        //                default:
        //                    haveOccupationAccess = false;
        //                    break;
        //            }

        //            if (haveOccupationAccess)
        //            {
        //                await Authentication.SetRole(rf, roleName, accessLevel);
        //                ListcodeOcupations.Add(roleName, codigoCargoAtivo);
        //            }

        //        }
        //    }
        //    return ListcodeOcupations;
        //}

        #endregion -------------------- PRIVATE --------------------

        #region -------------------- PUBLIC --------------------



        /// <summary>
        /// Método para deslogar o usuário.
        /// </summary>
        /// <param name="credential">Objeto que contém informações da credencial do usuário, neste caso específico é necessário o atributo username e session</param>
        /// <returns>Retorna verdadeiro caso o usuário estiver logado com as credenciais especificadas, caso contrário retorna falso.</returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<string>> Logout([FromBody] CredentialModel credential)
        {
            return (Ok(await Data.Business.Authentication.LogoutUser(credential.Username, credential.Session)));
        }

        /// <summary>
        /// Método para fazer login do usuário utilizando o sistema http://identity.sme.prefeitura.sp.gov.br.
        /// </summary>
        /// <param name="credential">Objeto que contém informações da credencial do usuário, neste caso específico é necessário o atributo username e password</param>
        /// <returns>Informações sobre o usuário que está tentando logar (tokens de acesso e cookies), caso não seja encontrado nenhum usuário correspondente à credencial, o método retorna usuário não autorizado.</returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<string>> LoginIdentity([FromBody] CredentialModel credential, [FromServices]IMediator mediator)
        {
            var retornoAutenticacao = await _apiNovoSgp.Autenticar(credential.Username, credential.Password);

            if (retornoAutenticacao == null || !retornoAutenticacao.Autenticado)
                return Unauthorized("Usuário e/ou senha invalida");


            if (retornoAutenticacao.ModificarSenha)
                return Unauthorized("Você deve alterar a sua senha diretamente no Novo SGP");


            var perfisTratados = await mediator.Send(new ObterVerificarPerfisDoUsuarioLoginQuery(credential.Username, retornoAutenticacao.PerfisUsuario.Perfis));
            

            var menus = await _apiNovoSgp.ObterMenus(retornoAutenticacao.Token);

            var menussSondagem = menus.SelectMany(c => c.Menus).Where(c => c.Codigo < 9).ToDictionary(c => c.Url, k => k);

            //Tratar os Perfis que podem visualizar
            retornoAutenticacao.PerfisUsuario.Perfis = perfisTratados; 

            retornoAutenticacao.Permissoes = new List<MenuPermissaoDto>
            {
                menussSondagem["/sondagem"],
                new MenuPermissaoDto
                {
                    PodeAlterar = false,
                    PodeConsultar = true,
                    PodeExcluir = false,
                    PodeIncluir = false,
                },
            };

            return Ok(retornoAutenticacao);
          
        }


        [AllowAnonymous]
        [HttpPut]
        public async Task<IActionResult> ModificarPerfil([FromQuery] string perfil, [FromServices]IMediator mediator)
        {
            var token = await mediator.Send(new AtualizarPerfilCommand(perfil));

            return Ok(token);

        }


        [AllowAnonymous]
        [HttpPut]
        public async Task<IActionResult> ValidarPerfisToken([FromBody] List<PerfilDto> perfis, [FromServices]IMediator mediator)
        {
            var perfisRetorno = await mediator.Send(new ObterVerificarPerfisTokenQuery(perfis));
            return Ok(perfisRetorno);
        }
        #endregion -------------------- PUBLIC --------------------

        #endregion ==================== METHODS ====================
    }
}