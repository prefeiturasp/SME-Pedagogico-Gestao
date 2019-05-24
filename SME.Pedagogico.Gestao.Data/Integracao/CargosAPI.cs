using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SME.Pedagogico.Gestao.Data.Integracao.DTO;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;

namespace SME.Pedagogico.Gestao.Data.Integracao
{
    public class CargosAPI
    {
        private readonly EndpointsAPI endpointsAPI;

        public CargosAPI(EndpointsAPI endpointsAPI)
        {
            this.endpointsAPI = endpointsAPI;
        }

        public async Task<List<CargosDTO>> GetCargos(string token)
        {
            var url = HttpHelper.ConstroiURL(endpointsAPI.BaseEndpoint, endpointsAPI.BuscaCargos);

            return await HttpHelper.GetAsync<List<CargosDTO>>(token, string.Format(url));
        }

    }
}
