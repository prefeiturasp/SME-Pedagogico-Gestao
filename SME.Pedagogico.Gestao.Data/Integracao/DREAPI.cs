using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Data.Integracao
{
    public class DREAPI
    { 
        private readonly EndpointsAPI endpointsAPI;

        public DREAPI(EndpointsAPI endpointsAPI)
        {
            this.endpointsAPI = endpointsAPI;
        } 

        public async Task<List<DREsDTO>> GetDres( string token)
        {
            var url = HttpHelper.ConstroiURL(endpointsAPI.BaseEndpoint, endpointsAPI.BuscaDres);

            return await HttpHelper
                .GetAsync<List<DREsDTO>>
                      (token, string.Format(url));
        }
         
        public async Task<List<DREsDTO>> GetDresPorCodigo(string codigoDRE, string token)
        {
            var url = HttpHelper.ConstroiURL(endpointsAPI.BaseEndpoint, endpointsAPI.BuscaDresPorCodigo);

            return await HttpHelper
                .GetAsync<List<DREsDTO>>
                      (token, string.Format(url, codigoDRE));
        }

        public async Task<List<EscolasPorDREDTO>> GetEscolasPorDREPorTipoEscola(string codigoDRE, string tipoEscola, string token)
        {
            var url = HttpHelper.ConstroiURL(endpointsAPI.BaseEndpoint, endpointsAPI.BuscaEscolasPorDREPorTipoEscola);

            return await HttpHelper
                .GetAsync<List<EscolasPorDREDTO>>
                      (token, string.Format(url, codigoDRE, tipoEscola));
        }
         
        public async Task<List<EscolasPorDREDTO>> GetEscolasPorDRE(string codigoDRE, string token)
        {
            var url = HttpHelper.ConstroiURL(endpointsAPI.BaseEndpoint, endpointsAPI.BuscaEscolasPorDre);

            return await HttpHelper
                .GetAsync<List<EscolasPorDREDTO>>
                      (token, string.Format(url, codigoDRE));

        }

        public async Task<List<EscolasPorDREDTO>> GetEscolasPorTipoEscola(string tipoEscola, string token)
        {
            var url = HttpHelper.ConstroiURL(endpointsAPI.BaseEndpoint, endpointsAPI.BuscaEscolasPorTipoEscola);

            return await HttpHelper
                .GetAsync<List<EscolasPorDREDTO>>
                      (token, string.Format(url, tipoEscola));
        }

        public async Task<List<SubprefeituraDTO>> GetSubprefeituraPor(string codigoDRE, string token)
        {
            var url = HttpHelper.ConstroiURL(endpointsAPI.BaseEndpoint, endpointsAPI.BuscaSubprefeituraPor);

            return await HttpHelper
                .GetAsync<List<SubprefeituraDTO>>
                      (token, string.Format(url, codigoDRE));
        }
    }
}
