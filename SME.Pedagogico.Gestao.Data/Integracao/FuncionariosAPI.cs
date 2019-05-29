using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;

namespace SME.Pedagogico.Gestao.Data.Integracao
{
    public class FuncionariosAPI
    {
        private readonly EndpointsAPI endpointsAPI;

        public FuncionariosAPI(EndpointsAPI endpointsAPI)
        {
            this.endpointsAPI = endpointsAPI;
        }

        public async Task<List<FuncionariosDTO>> GetFuncionarios(string codigoCargo, string token)
        {
            var url = HttpHelper.ConstroiURL(endpointsAPI.BaseEndpoint, endpointsAPI.BuscaFuncionario);

            return await HttpHelper
                .GetAsync<List<FuncionariosDTO>>
                      (token, string.Format(url, codigoCargo));
        }

    }
}
