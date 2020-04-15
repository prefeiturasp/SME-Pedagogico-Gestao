using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Data.Integracao
{
    public class AbrangenciaAPI
    {
        private readonly EndpointsAPI endpointsAPI;

        public AbrangenciaAPI()
        {
            endpointsAPI = new EndpointsAPI();
        }

        public async Task<AbrangenciaCompactaDTO> ObterAbrangenciaCompactaDreDetalhes(string token,string rf, Guid perfil)
        {
            var abranciaUrl = string.Format(endpointsAPI.AbrangenciaCompacta, rf, perfil.ToString());

            var url = HttpHelper.ConstroiURL(endpointsAPI.BaseEndpoint, abranciaUrl);

            return await HttpHelper.GetAsync<AbrangenciaCompactaDTO>(token, url);
        }
    }
}
