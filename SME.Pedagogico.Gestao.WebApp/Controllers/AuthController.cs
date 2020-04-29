using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SME.Pedagogico.Gestao.Data.Business;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.DTO;
using SME.Pedagogico.Gestao.Models.Authentication;
using SME.Pedagogico.Gestao.WebApp.Contexts;
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
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoNovoSGP;
using SME.Pedagogico.Gestao.Data.DataTransfer;
using SME.Pedagogico.Gestao.WebApp.Models;

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
                            roleName = "Professor";
                            accessLevel = "32";
                            haveOccupationAccess = true;
                            isTeacher = true;
                            qtdIsTeacher += 1;
                            break;
                        case "3301":
                            roleName = "Professor";
                            accessLevel = "32";
                            haveOccupationAccess = true;
                            isTeacher = true;
                            qtdIsTeacher += 1;
                            break;
                        //case "3336":
                        //    roleName = "Professor";
                        //    accessLevel = "32";
                        //    haveOccupationAccess = true;
                        //    isTeacher = true;
                        //    break;
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
        /// Método para efetuar o login do usuário utilizando o sistema do Novo SGP para validar o usuário e receber credencial de acesso.
        /// </summary>
        /// <param name="credential">Objeto que contém informações da credencial do usuário, neste caso específico é necessário o atributo username e password</param>
        /// <returns>Token, Sessão e RefreshToken gerado à partir das informações do usuário encontrado, caso não seja encontrado nenhum usuário correspondente à credencial, o método retorna usuário não autorizado.</returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<string>> Login([FromBody]CredentialModel credential)
        {
            if (Data.Business.Authentication.ValidateUser(credential.Username, credential.Password))
            {
                string session = Data.Functionalities.Cryptography.CreateHashKey(); // Cria a sessão
                string refreshToken = Data.Functionalities.Cryptography.CreateHashKey(); // Cria o refresh token

                await Data.Business.Authentication.LoginUser(credential.Username, session, refreshToken); // Loga o usuário no sistema

                return (Ok(new
                {
                    Token = CreateToken(credential.Username),
                    Session = session,
                    RefreshToken = refreshToken,
                    Roles = await GetUserRoles(credential.Username)
                }));
            }

            return (Unauthorized());
        }

        /// <summary>
        /// Método para renovar o token através do refresh token e nome de usuário.
        /// </summary>
        /// <param name="credential">Objeto que contém informações da credencial do usuário, neste caso específico é necessário o atributo username e refreshToken</param>
        /// <returns>Token e RefreshToken gerado à partir do RefreshToken utilizado, caso o RefreshToken não seja válido, o método retorna usuário não autorizado.</returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<string>> RefreshLoginJWT([FromBody]CredentialModel credential)
        {
            // Faz a pesquisa no banco de dados (smeManagementDB/LoggedUsers) se o usuário está listado como logado possuindo a mesma sessão e o mesmo refresh token
            LoggedUser loggedUser = await Data.Business.Authentication.GetLoggedUser(credential.Username, credential.Session, credential.RefreshToken);

            // Caso seja encontrado algum usuário com a combinação de username, sessão e refreshToken, verifica se o refresh token ainda é valido
            if (loggedUser != null)
                if ((loggedUser.ExpiresAt - DateTime.Now).Minutes > 0)
                {
                    string newSession = Data.Functionalities.Cryptography.CreateHashKey(); // Cria a sessão
                    string newRefreshToken = Data.Functionalities.Cryptography.CreateHashKey(); // Cria o refresh token

                    await Data.Business.Authentication.LoginUser(credential.Username, newSession, newRefreshToken); // Salva as informações na tabela correspondente (LoggedUsers)

                    return (Ok(new
                    {
                        Token = CreateToken(credential.Username),
                        Session = newSession,
                        RefreshToken = newRefreshToken
                    }));
                }
                else // Caso não seja válido, remove o usuário da lista de usuários logados
                {
                    await Data.Business.Authentication.LogoutUser(credential.Username, credential.Session); // Desloga o usuário
                }

            return (Unauthorized());
        }

        /// <summary>
        /// Método para deslogar o usuário.
        /// </summary>
        /// <param name="credential">Objeto que contém informações da credencial do usuário, neste caso específico é necessário o atributo username e session</param>
        /// <returns>Retorna verdadeiro caso o usuário estiver logado com as credenciais especificadas, caso contrário retorna falso.</returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<string>> Logout([FromBody]CredentialModel credential)
        {
            return (Ok(await Data.Business.Authentication.LogoutUser(credential.Username, credential.Session)));
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<string>> LoginIdentityNovo([FromBody]CredentialModel credential)
        {
            var api = new NovoSGPAPI();

            var ret = await api.Autenticar(credential.Username, credential.Password);

            if (ret == null)
                return Unauthorized();


            var listProfile = new Dictionary<string, string>();
            //Escola 
            listProfile.Add("Professor", "40E1E074-37D6-E911-ABD6-F81654FE895D");
            listProfile.Add("CP", "44E1E074-37D6-E911-ABD6-F81654FE895D");
            listProfile.Add("AD", "45E1E074-37D6-E911-ABD6-F81654FE895D");
            listProfile.Add("Diretor", "46E1E074-37D6-E911-ABD6-F81654FE895D");
            //DRE
            listProfile.Add("ADM", "48E1E074-37D6-E911-ABD6-F81654FE895D");
            listProfile.Add("DIPED", "49E1E074-37D6-E911-ABD6-F81654FE895D");
            //SME
            listProfile.Add("DIEFM", "58E1E074-37D6-E911-ABD6-F81654FE895D");
            listProfile.Add("COPED", "59E1E074-37D6-E911-ABD6-F81654FE895D");
            listProfile.Add("ADM-Sme", "5AE1E074-37D6-E911-ABD6-F81654FE895D");
            listProfile.Add("ADM-Cotic", "5BE1E074-37D6-E911-ABD6-F81654FE895D");

            var list = new List<PerfilDto>();

            foreach (var item in listProfile)
            {
                var perfil = new PerfilDto();
                perfil.NomePerfil = item.Key;
                perfil.CodigoPerfil = Guid.Parse(item.Value);
                list.Add(perfil);
            }

            foreach (var item in ret.PerfisUsuario.Perfis)
            {
                var podeAcessar = ret.PerfisUsuario.Perfis.ToList().Exists(a => a.CodigoPerfil == item.CodigoPerfil);
                if (!podeAcessar)
                {
                    return Forbid();
                }
            }
            // Regra professor se for apenas professor é necessário verificar o cargo, pois nem
            // todos os professores podem acessar o cargo.
            var ProfileBusiness = new Profile(_config);
            //  var occupationRF = await ProfileBusiness.GetOccupationsRF(credential.Username);



            // pode acessar 



            //se for apenas professor par aqui 


            // Verifica se o usuario é cadastrado se nao for cadastra



            await CadastraUsuario(credential);
            /////////////////////////////////////////////////////////


            // perfil automatico 
            // var ProfileBusiness = new Profile(_config);

            var listOccupations = new Dictionary<string, string>();
            var userPrivileged = Authentication.ValidatePrivilegedUser(credential.Username);

            var occupationRF = await ProfileBusiness.GetOccupationsRF(credential.Username);
            if (occupationRF != null)
            {
                listOccupations = await SetOccupationsRF(credential.Username, occupationRF);
            }


            // Fluxo 2 
            if (userPrivileged != null)
            {
                await Authentication.SetRolePrivilegied(credential, userPrivileged);
            }
            if (occupationRF != null)
            {
                listOccupations = await SetOccupationsRF(credential.Username, occupationRF);
            }
            var Roles = await GetUserRoles(credential.Username);
            if (Roles != null)
            {
                string session = Data.Functionalities.Cryptography.CreateHashKey(); // Cria a sessão
                string refreshToken = Data.Functionalities.Cryptography.CreateHashKey(); // Cria o refresh token
                await Data.Business.Authentication.LoginUser(credential.Username, session, refreshToken); // Loga o usuário no sistema

                return (Ok(new
                {
                    Token = CreateToken(credential.Username),
                    Session = session,
                    RefreshToken = refreshToken,
                    Roles = await GetUserRoles(credential.Username),
                    ListOccupations = listOccupations,
                }));
            }
            else
            {
                return (Unauthorized());
            }
        }

        private static async Task CadastraUsuario(CredentialModel credential)
        {
            if (!Authentication.ValidateUser(credential.Username))
            {
                // se nao for cadastra
                await Authentication.RegisterUser(credential.Username, credential.Password);
            }
        }


        /// <summary>
        /// Método para fazer login do usuário utilizando o sistema http://identity.sme.prefeitura.sp.gov.br.
        /// </summary>
        /// <param name="credential">Objeto que contém informações da credencial do usuário, neste caso específico é necessário o atributo username e password</param>
        /// <returns>Informações sobre o usuário que está tentando logar (tokens de acesso e cookies), caso não seja encontrado nenhum usuário correspondente à credencial, o método retorna usuário não autorizado.</returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<string>> LoginIdentity([FromBody]CredentialModel credential)
        {
            var retornoAutenticacao = await _apiNovoSgp.Autenticar(credential.Username, credential.Password);

            if (retornoAutenticacao == null || !retornoAutenticacao.Autenticado)
                return Unauthorized("Usuário e/ou senha invalida");

            var perfisElegiveis = Perfil.ObterPerfis().Where(x => retornoAutenticacao.PerfisUsuario.Perfis.Any(y => y.CodigoPerfil.Equals(x.PerfilGuid)));

            var perfilSelecionado = perfisElegiveis.FirstOrDefault(x => x.PerfilGuid.Equals(retornoAutenticacao.PerfisUsuario.PerfilSelecionado)) ?? perfisElegiveis.FirstOrDefault();

            if (perfilSelecionado == null)
                return Unauthorized("Perfil não permitido para acesso");

            if (retornoAutenticacao.ModificarSenha)
                return Unauthorized("Você deve alterar a sua senha diretamente no Novo SGP");

            //cadastra usuario se não existir
            await CadastraUsuario(credential);

            var meusDados = await _apiNovoSgp.MeusDados(retornoAutenticacao.Token);

            if (meusDados == null)
                return Unauthorized("Não foi possivel obter os dados do usuário. Contate a SME");

            var ProfileBusiness = new Profile(_config);

            List<UserRoleModel> Roles = await GetRolesAuthentication(credential, retornoAutenticacao);

            var privileged = new List<PrivilegedAccess>();

            if (retornoAutenticacao.PerfisUsuario.PossuiPerfilDre)
            {
                var perfisDre = Perfil.ObterPerfis().Where(x => x.IsDre);

                var perfilAbrangencia = perfisDre.FirstOrDefault(x => retornoAutenticacao.PerfisUsuario.Perfis.Any(z => z.CodigoPerfil.ToString().ToUpper().Equals(x.PerfilGuid.ToString().ToUpper())));

                var abrangencia = await _abrangenciaAPI.ObterAbrangenciaCompactaDreDetalhes(retornoAutenticacao.Token, meusDados.CodigoRf, perfilAbrangencia.PerfilGuid);

                if (abrangencia != null && abrangencia.Dres != null && abrangencia.Dres.Any())
                    privileged = abrangencia.Dres.Select(x => new PrivilegedAccess
                    {
                        DreCodeEol = x.CodigoDRE,
                        Login = credential.Username,
                        Name = meusDados.Nome,
                        OccupationPlace = x.NomeDRE,
                        OccupationPlaceCode = 3
                    }).ToList();

                await Authentication.SetPrivilegedAccess(credential.Username, privileged);

            }

            if (retornoAutenticacao.PerfisUsuario.PossuiPerfilSme)
            {
                privileged.Add(new PrivilegedAccess
                {
                    Login = credential.Username,
                    Name = meusDados.Nome,
                    OccupationPlace = "SME",
                    OccupationPlaceCode = 2
                });

                await Authentication.SetPrivilegedAccess(credential.Username, privileged);
            }

            var listOccupations = new Dictionary<string, string>();
            var occupationRF = await ProfileBusiness.GetOccupationsRF(meusDados.CodigoRf);

            if (occupationRF != null)
                listOccupations = await SetOccupationsRF(credential.Username, occupationRF);

            Roles = await GetUserRoles(credential.Username);

            if (!Roles.Any())
                return Unauthorized("Usuario não autorizado");

            string session = Data.Functionalities.Cryptography.CreateHashKey(); // Cria a sessão
            string refreshToken = retornoAutenticacao.Token; // Usa token criado no novo SGP
            await Data.Business.Authentication.LoginUser(credential.Username, session, refreshToken); // Loga o usuário no sistema

            return Ok(new
            {
                Token = CreateToken(credential.Username),
                Session = session,
                RefreshToken = refreshToken,
                Roles,
                ListOccupations = listOccupations,
            });
        }

        private async Task<List<UserRoleModel>> GetRolesAuthentication(CredentialModel credential, UsuarioAutenticacaoRetornoDto retornoAutenticacao)
        {
            var perfis = new List<Perfil>();

            var perfisPermitidos = Perfil.ObterPerfis().Where(x => !x.haveOccupationAccess);

            foreach (var perfil in retornoAutenticacao.PerfisUsuario.Perfis)
            {
                var perfilString = perfil.CodigoPerfil.ToString().ToUpper();

                foreach (var perfilPermitido in perfisPermitidos)
                {
                    var perfilPermitidoString = perfilPermitido.PerfilGuid.ToString().ToUpper();

                    var iguais = perfilPermitidoString.Equals(perfilString);

                    if (iguais)
                        perfis.Add(perfilPermitido);
                }
            }

            //var perfis = Perfil.ObterPerfis().Where(x => retornoAutenticacao.PerfisUsuario.Perfis.Any(y => x.PerfilGuid.ToString().ToUpper().Equals(y.ToString().ToUpper())));

            var rolesAuthentication = perfis.Select(x => new RoleAuthenticationDto
            {
                AccessLevelValue = x.AccessLevel,
                RoleName = x.RoleName,
                UserName = credential.Username,
                Perfil = x.PerfilGuid
            });

            await Authentication.setRoleAuthentication(credential.Username, rolesAuthentication);

            return await GetUserRoles(credential.Username);
        }

        /// <summary>
        /// Método para fazer o logout utilizando o sistema http://identity.sme.prefeitura.sp.gov.br.
        /// </summary>
        /// <param name="credential">Objeto que contém informações da credencial do usuário, neste caso específico é necessário o atributo username</param>
        /// <returns>Sucesso (status code 200) caso seja possível deslogar o usuário desejado.</returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<string>> LogoutIdentity([FromBody] CredentialModel credential)
        {
            // Configurações iniciais
            string url = "http://identity.sme.prefeitura.sp.gov.br/Account/Logout";

            // Cria os dados necessários que compõe o corpo da requisição
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("logoutId", credential.Username); // Adiciona o nome de usuário

            // Inicialização do cliente para requisições (GET)
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url) { Content = new FormUrlEncodedContent(data) }) // Encoda os dados no formato correto dentro da requisição
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.SendAsync(request))
            {
                // Caso a requisição não ocorra corretamente, retorna 'Unauthorized'
                if (!response.IsSuccessStatusCode)
                    return (Unauthorized());
                else
                    return (Ok());
            }
        }

        /// <summary>
        /// Método para resetar a senha do usuário desejado
        /// </summary>
        /// <param name="credential">Objeto contendo nome de usuário, nova senha e "key" para conseguir acessar a funcionalidade</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<string>> ResetPassword([FromBody] ResetPassword credential)
        {
            if (credential.Key == "sgp123456789")
            {
                if (await Data.Business.Authentication.ResetSenha(credential.Username, credential.NewPassword))
                    return (Ok());
            }

            return (Forbid());
        }

        /// <summary>
        /// Método para resetar a senha padrão do usuário desejado
        /// </summary>
        /// <param name="credential">Objeto contendo nome de usuário, nova senha e "key" para conseguir acessar a funcionalidade</param>
        /// <returns>Caso erro na validação da senha, retorna array de strings com msgs de erro</returns>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<string> ResetDefaultPassword([FromBody] ResetPasswordDTO credential)
        {
            if (credential.Key == "sgp123456789")
            {
                if (Authentication.ResetSenhaPadrão(credential, out IEnumerable<string> validationErrors))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(validationErrors);
                }
            }

            return Forbid();
        }

        #endregion -------------------- PUBLIC --------------------

        #endregion ==================== METHODS ====================
    }
}