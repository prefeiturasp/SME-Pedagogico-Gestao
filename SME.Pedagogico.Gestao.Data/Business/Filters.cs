using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.Functionalities;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.Business
{
 public class Filters
    {
        private string _token;
        public Filters(IConfiguration config)
        {
            var createToken = new CreateToken(config);
            _token = createToken.CreateTokenProvisorio();
        }

        //public List<EscolaDTO> GetSchools(string CodeDRE)
        //{


        //    var url = HttpHelper.ConstroiURL(endpointsAPI.BaseEndpoint, endpointsAPI.BuscaTurmasDeProfessores);
        //}
    }
}
