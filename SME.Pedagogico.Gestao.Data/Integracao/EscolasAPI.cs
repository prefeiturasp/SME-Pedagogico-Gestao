using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.Integracao.Endpoints
{
  public  class EscolasAPI
    { 
        
        private readonly EndpointsAPI endpointsAPI;

        public EscolasAPI(EndpointsAPI endpointsAPI)
        {
            this.endpointsAPI = endpointsAPI;
        }

        //public async Task<List<EscolaDTO>> GetTurmasDoProfessor(string codigoRF, int codigoUE, string anoLetivo, string token)
        //{ 

        //    var url = HttpHelper.ConstroiURL(endpointsAPI.BaseEndpoint, endpointsAPI.BuscaTurmasDeProfessores);

        //    var teste = await HttpHelper
        //        .GetAsync<List<BuscaTurmasAtribuidasDTO>>
        //              (token, string.Format(url, codigoRF, codigoUE, anoLetivo));

        //    return await HttpHelper
        //        .GetAsync<List<BuscaTurmasAtribuidasDTO>>
        //              (token, string.Format(url, codigoRF, codigoUE, anoLetivo));
        //}
    }
}
