using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.Functionalities;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.DTO;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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


        public async Task<List<SalasPorUEDTO>> GetClassRoomSchool(string schoolCodeEol, string schooYear)
        {
            try
            {
                var endPoint = new EndpointsAPI();
                var schoolApi = new EscolasAPI(endPoint);
                var listClassRoom = await schoolApi.GetTurmasPorEscola(int.Parse(schoolCodeEol), schooYear, _token);
                if (listClassRoom != null)
                {
                    return listClassRoom;
                }

                else
                {
                    return null;
                }
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }

    }
}
