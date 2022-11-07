using Newtonsoft.Json;
using SME.Pedagogico.Gestao.Data.Business;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using SME.Pedagogico.Gestao.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<AutenticacaoRevalidarRetornoDto> RevalidarAutenticacao(string token)
        {
            ResetarCabecalhoAutenticado(token);

            var resposta = await httpClient.PostAsync(EndpointsNovoSGP.RevalidarAutenticacao(), null);

            return await TrataRetorno<AutenticacaoRevalidarRetornoDto>(resposta);
        }        

        public async Task<IList<AbrangenciaDreRetornoDto>> AbrangenciaDres(string userName, int? anoLetivo)
        {
            var loggedUser = await Authentication.GetLoggedUser(userName);
            
            ResetarCabecalhoAutenticado(loggedUser.RefreshToken);

            var consideraHistorico = anoLetivo.HasValue && !DateTime.Now.Year.Equals(anoLetivo.Value);

            var resposta = await httpClient.GetAsync(EndpointsNovoSGP.AbrangenciaDres(consideraHistorico, anoLetivo));

            return await TrataRetorno<IList<AbrangenciaDreRetornoDto>>(resposta);
        }

        public async Task<IList<AbrangenciaUeRetornoDto>> AbrangenciaUes(string userName, int? anoLetivo, string codigoDre)
        {
            var loggedUser = await Authentication.GetLoggedUser(userName);

            ResetarCabecalhoAutenticado(loggedUser.RefreshToken);

            var consideraHistorico = anoLetivo.HasValue && !DateTime.Now.Year.Equals(anoLetivo);

            var resposta = await httpClient.GetAsync(EndpointsNovoSGP.AbrangenciaUes(consideraHistorico, anoLetivo, codigoDre));

            return await TrataRetorno<IList<AbrangenciaUeRetornoDto>>(resposta);
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

        public async Task<IEnumerable<MenuRetornoDto>> ObterMenus(string token)
        {
            ResetarCabecalhoAutenticado(token);

            var resposta = await httpClient.GetAsync(EndpointsNovoSGP.Menus());

            return await TrataRetorno<IEnumerable<MenuRetornoDto>>(resposta);
        }
    }
}
