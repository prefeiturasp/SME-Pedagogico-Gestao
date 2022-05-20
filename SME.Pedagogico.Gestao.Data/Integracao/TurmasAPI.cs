using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;

namespace SME.Pedagogico.Gestao.Data.Integracao
{
    public class TurmasAPI
    {
        private readonly EndpointsAPI endpointsAPI;

        public TurmasAPI(EndpointsAPI endpointsAPI)
        {
            this.endpointsAPI = endpointsAPI;
        }

        public async Task<List<AlunosNaTurmaDTO>> GetAlunosNaTurma(int codigoTurma, string token)
        {
            var url = HttpHelper
                .ConstroiURL(endpointsAPI.BaseEndpoint, endpointsAPI.BuscaAlunosNaTurma);

            return await HttpHelper
                .GetAsync<List<AlunosNaTurmaDTO>>
                      (token, string.Format(url, codigoTurma, false));
        }

        public async Task<List<AlunosNaTurmaDTO>> GetAlunosConsideraInativosNaTurma(int codigoTurma, string token)
        {
            var url = HttpHelper
                .ConstroiURL(endpointsAPI.BaseEndpoint, endpointsAPI.BuscaAlunosNaTurma);

            return await HttpHelper
                .GetAsync<List<AlunosNaTurmaDTO>>
                      (token, string.Format(url, codigoTurma, true));
        }
    }
}
