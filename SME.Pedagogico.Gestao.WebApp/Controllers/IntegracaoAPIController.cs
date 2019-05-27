using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using SME.Pedagogico.Gestao.WebApp.Models.Auth;
using System.Security.Claims;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SME.Pedagogico.Gestao.Models.Authentication;
using SME.Pedagogico.Gestao.WebApp.Contexts;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;

namespace SME.Pedagogico.Gestao.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntegracaoAPIController : ControllerBase
    {
        private IConfiguration _config;
        public IntegracaoAPIController(IConfiguration config)
        {

            _config = config;
        }


        [HttpGet("turmas/{codigoTurma}/alunos/anosLetivos/{anoLetivo}")]
        public async Task<IActionResult> TesteTurmas(int codigoTurma,
                                                int anoLetivo, [FromBody]CredentialModel credential)
        {
            ClientUserModel user = await Authenticate(credential);

            if (user != null)
            {
                user.SMEToken = new SMETokenModel();
                user.SMEToken.Token = CreateToken(user); // Cria o token de acesso
            }
            string token = user.SMEToken.Token.ToString();

            var endpoint = new EndpointsAPI();
            TurmasAPI turmas = new TurmasAPI(endpoint);

            return Ok(await turmas.GetAlunosNaTurma(codigoTurma, anoLetivo, token));
        }



        [HttpGet("professores/{codigoRF}/escolas/{codigoUE}/turmas/anos_letivos/{anoLetivo}")]
        public async Task<IActionResult> TesteProfessores(string codigoRF, int codigoUE, string anoLetivo, [FromBody]CredentialModel credential)
        {
            ClientUserModel user = await Authenticate(credential);

            if (user != null)
            {
                user.SMEToken = new SMETokenModel();
                user.SMEToken.Token = CreateToken(user); // Cria o token de acesso
            }
            string token = user.SMEToken.Token.ToString();

            var endpoint = new EndpointsAPI();
            ProfessoresAPI professores = new ProfessoresAPI(endpoint);

            return Ok(await professores.GetTurmasDoProfessor(codigoRF, codigoUE, anoLetivo, token));
        }


        [HttpGet("cargos")]
        public async Task<IActionResult> TesteCargos([FromBody]CredentialModel credential)
        {
            ClientUserModel user = await Authenticate(credential);

            if (user != null)
            {
                user.SMEToken = new SMETokenModel();
                user.SMEToken.Token = CreateToken(user); // Cria o token de acesso
            }

            string token = user.SMEToken.Token.ToString();

            var endpoint = new EndpointsAPI();
            CargosAPI cargos = new CargosAPI(endpoint);
            var cargosretorno = cargos.GetCargos(token);

            return Ok(await cargos.GetCargos(token));
        }

        [HttpGet("servidores/{codigoRF}/cargos")]
        public async Task<IActionResult> TesteCargosDeServidor(string codigoRF, [FromBody]CredentialModel credential)
        {
            ClientUserModel user = await Authenticate(credential);

            if (user != null)
            {
                user.SMEToken = new SMETokenModel();
                user.SMEToken.Token = CreateToken(user); // Cria o token de acesso
            }

            string token = user.SMEToken.Token.ToString();

            var endpoint = new EndpointsAPI();
            PerfilSgpAPI perfilSGP = new PerfilSgpAPI(endpoint);

            return Ok(await perfilSGP.GetCargosDeServidor(codigoRF, token));
        }





        [HttpGet("servidores/{codigoRF}/{codigoCargo}/{anoLetivo}/informacoes_perfil")]
        public async Task<IActionResult> TestInformacoesPerfil(string codigoRF,
                                                     int codigoCargo,
                                                     int anoLetivo, [FromBody]CredentialModel credential)
        {
            ClientUserModel user = await Authenticate(credential);

            if (user != null)
            {
                user.SMEToken = new SMETokenModel();
                user.SMEToken.Token = CreateToken(user); // Cria o token de acesso
            }

            string token = user.SMEToken.Token.ToString();

            var endpoint = new EndpointsAPI();
            PerfilSgpAPI perfilSGP = new PerfilSgpAPI(endpoint);

            return Ok(await perfilSGP.getInformacoesPerfil(codigoRF, codigoCargo, anoLetivo, token));
        }


        [HttpGet("funcionario/{codigoCargo}")]
        public async Task<IActionResult> TesteFuncionario(string codigoCargo, [FromBody]CredentialModel credential)
        {
            ClientUserModel user = await Authenticate(credential);

            if (user != null)
            {
                user.SMEToken = new SMETokenModel();
                user.SMEToken.Token = CreateToken(user); // Cria o token de acesso
            }

            string token = user.SMEToken.Token.ToString();

            var endpoint = new EndpointsAPI();

            var funcionario = new FuncionariosAPI(endpoint);

            return Ok(await funcionario.GetFuncionarios(codigoCargo, token));
        }



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

        public string CreateToken(ClientUserModel user)
        {
            return (CreateToken(user.Username));
        }

        public string CreateToken(string username)
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

    }
}