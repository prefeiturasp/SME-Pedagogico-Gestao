﻿using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Data.Integracao
{
    public class ProfessoresAPI
    {
        private readonly EndpointsAPI endpointsAPI;

        public ProfessoresAPI(EndpointsAPI endpointsAPI)
        {
            this.endpointsAPI = endpointsAPI;
        }

        public async Task<List<BuscaTurmasAtribuidasDTO>> GetTurmasDoProfessor(string codigoRF, int codigoUE, string anoLetivo, string token)
        { 
            var url = HttpHelper.ConstroiURL(endpointsAPI.BaseEndpoint, endpointsAPI.BuscaTurmasDeProfessores);
              
            return await HttpHelper
                .GetAsync<List<BuscaTurmasAtribuidasDTO>>
                      (token, string.Format(url, codigoRF, codigoUE, anoLetivo));
        }




    }
}
