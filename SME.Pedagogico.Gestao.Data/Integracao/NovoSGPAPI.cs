using Newtonsoft.Json;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoNovoSGP;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Data.Integracao
{
    public class NovoSGPAPI
    {
        private readonly HttpClient httpClient;

        public NovoSGPAPI()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(EndpointsNovoSGP.BaseSGPEndpoint("v1"))
            };

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<UsuarioAutenticacaoRetornoDto> Autenticar(string login, string senha)
        {
            httpClient.DefaultRequestHeaders.Clear();

            var valoresParaEnvio = new Dictionary<string, string>
            {
                {"Login", login },
                {"Senha", senha }
            };

            var resposta = await httpClient.PostAsync("autenticacao", new StringContent(JsonConvert.SerializeObject(valoresParaEnvio), Encoding.UTF8, "application/json-patch+json"));

            if (!resposta.IsSuccessStatusCode)
                return null;

            var json = await resposta.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UsuarioAutenticacaoRetornoDto>(json);
        }
    }
}
