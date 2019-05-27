using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Data.Integracao.Endpoints
{
    public class EscolasAPI
    {

        private readonly EndpointsAPI endpointsAPI;

        public EscolasAPI(EndpointsAPI endpointsAPI)
        {
            this.endpointsAPI = endpointsAPI;
        }

        public async Task<EscolaDTO> GetEscolasPor(string codigoEol, string token)
        {
            var url = HttpHelper.ConstroiURL(endpointsAPI.BaseEndpoint, endpointsAPI.BuscaEscolasPor);

            return await HttpHelper
                .GetAsync<EscolaDTO>
                      (token, string.Format(url, codigoEol));
        }

        public async Task<List<BuscaProfessorDTO>> GetProfessores(string codigoEolEscola, int anoLetivo, string token)
        {
            var url = HttpHelper.ConstroiURL(endpointsAPI.BaseEndpoint, endpointsAPI.BuscaProfessores);

            return await HttpHelper
                .GetAsync<List<BuscaProfessorDTO>>
                      (token, string.Format(url, codigoEolEscola, anoLetivo));
        }

        public async Task<List<string>> GetModalidadesEnsino(string token)
        {
            var url = HttpHelper.ConstroiURL(endpointsAPI.BaseEndpoint, endpointsAPI.BuscaModalidadesEnsino);

            return await HttpHelper
                .GetAsync<List<string>>
                      (token, string.Format(url));
        }

        public async Task<List<string>> GetTiposUE(string token)
        {
            var url = HttpHelper.ConstroiURL(endpointsAPI.BaseEndpoint, endpointsAPI.BuscaTiposUE);

            return await HttpHelper
                .GetAsync<List<string>>
                      (token, string.Format(url));
        }

        public async Task<List<SalasPorUEDTO>> GetTurmasDoTipoSala(int codigoUE, string tipoSala, string anoLetivo, string token)
        {
            var url = HttpHelper.ConstroiURL(endpointsAPI.BaseEndpoint, endpointsAPI.BuscaTurmasDoTipoSala);

            return await HttpHelper
                .GetAsync<List<SalasPorUEDTO>>
                      (token, string.Format(url, codigoUE, tipoSala, anoLetivo));
        }

        public async Task<List<FuncionariosDTO>> GetFuncionarios(string codigoUE, string token)
        {
            var url = HttpHelper.ConstroiURL(endpointsAPI.BaseEndpoint, endpointsAPI.BuscaFuncionariosdaEscola);

            return await HttpHelper
                .GetAsync<List<FuncionariosDTO>>
                      (token, string.Format(url, codigoUE));
        }

        public async Task<List<FuncionariosDTO>> GetFuncionariosPorCargo(string codigoCargo, string codigoUE, string token)
        {
            var url = HttpHelper.ConstroiURL(endpointsAPI.BaseEndpoint, endpointsAPI.BuscaFuncionariosdaEscolaPorCargo);

            return await HttpHelper
                .GetAsync<List<FuncionariosDTO>>
                      (token, string.Format(url, codigoCargo, codigoUE));
        }


        public async Task<List<SubprefeituraDTO>> GetSubprefeiturasPor(string codigoEscolaEol, string token)
        {
            var url = HttpHelper.ConstroiURL(endpointsAPI.BaseEndpoint, endpointsAPI.BuscaSubprefeiturasPor);

            return await HttpHelper
                .GetAsync<List<SubprefeituraDTO>>
                      (token, string.Format(url, codigoEscolaEol));
        }

        public async Task<List<SalasPorUEDTO>> GetTurmasPorEscola(int codigoUE, string anoLetivo, string token)
        {
            var url = HttpHelper.ConstroiURL(endpointsAPI.BaseEndpoint, endpointsAPI.BuscaTurmasPorEscola);

            return await HttpHelper
                .GetAsync<List<SalasPorUEDTO>>
                      (token, string.Format(url, codigoUE, anoLetivo));
        }
    }
}
