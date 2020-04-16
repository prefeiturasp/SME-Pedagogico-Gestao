using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.Functionalities;
using SME.Pedagogico.Gestao.Data.Integracao;
using System.Collections.Generic;
using System.Linq;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
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


        public async Task<List<SalasPorUEDTO>> GetListClassRoomSchool(string schoolCodeEol, string schooYear)
        {
            try
            {
                var endPoint = new EndpointsAPI();
                var schoolApi = new EscolasAPI(endPoint);
                var eolCodeParseado = int.TryParse(schoolCodeEol, out int result);
                var listClassRoom = await schoolApi.GetTurmasPorEscola(eolCodeParseado ? result : 0 , schooYear, _token);
              
                if (listClassRoom != null)
                {
                    return listClassRoom.OrderBy(x=> x.NomeTurma).ToList();
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

        public async Task<List<EscolasPorDREDTO>> GetListSchoolDre(string dreCodeEol, string schooYear)
        {
            try
            {
                var endPoint = new EndpointsAPI();
                var schoolApi = new DREAPI(endPoint);
                var listSchools = await schoolApi.GetEscolasPorDREPorTipoEscola(dreCodeEol, "1", _token);
                if (listSchools != null)
                {
                    return listSchools.OrderBy(x => x.NomeEscola).ToList();
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

        public async Task<List<DREsDTO>> GetListDre()
        {
            try
            { 
                var endPoint = new EndpointsAPI();
                var dreApi = new DREAPI(endPoint);
                var listDres = await dreApi.GetDres(_token);
                if (listDres != null)
                {
                    return listDres;
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
