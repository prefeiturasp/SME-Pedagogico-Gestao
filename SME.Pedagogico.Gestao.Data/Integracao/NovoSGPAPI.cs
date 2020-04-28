using Newtonsoft.Json;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoNovoSGP;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public async Task<MeusDadosDto> MeusDados(string authenticationToken)
        {
            ResetarCabecalhoAutenticado(authenticationToken);

            var resposta = await httpClient.GetAsync(EndpointsNovoSGP.MeusDadosEndpoint());

            return await TrataRetorno<MeusDadosDto>(resposta);
        }

        public async Task<IEnumerable<PrioridadePerfilDto>> ListarPefis(string authenticationToken, string login)
        {
            ResetarCabecalhoAutenticado(authenticationToken);

            var resposta = await httpClient.GetAsync(EndpointsNovoSGP.ListarPerfisEndpoint(login));

            return await TrataRetorno<IEnumerable<PrioridadePerfilDto>>(resposta);
        }

        public async Task<TrocaPerfilDto> TrocaPerfil(string authenticationToken, Guid perfil)
        {
            ResetarCabecalhoAutenticado(authenticationToken);

            var resposta = await httpClient.GetAsync(EndpointsNovoSGP.TrocarPerfilEndpoint(perfil.ToString()));

            return await TrataRetorno<TrocaPerfilDto>(resposta);
        }

        public async Task<UsuarioAutenticacaoRetornoDto> Autenticar(string login, string senha)
        {
            ResetarCabecalho();

            var valoresParaEnvio = new Dictionary<string, string>
            {
                {"Login", login },
                {"Senha", senha }
            };

            var resposta = await httpClient.PostAsync(EndpointsNovoSGP.AutenticacaoEndpoint(), new StringContent(JsonConvert.SerializeObject(valoresParaEnvio), Encoding.UTF8, "application/json-patch+json"));

            return await TrataRetorno<UsuarioAutenticacaoRetornoDto>(resposta);
        }

        private async Task<T> TrataRetorno<T>(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                return default(T);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(json);
        }

        private void ResetarCabecalho()
        {
            httpClient.DefaultRequestHeaders.Clear();

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        private void ResetarCabecalhoAutenticado(string authenticationToken)
        {
            ResetarCabecalho();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationToken);
        }
    }
}
