using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.DataTransfer;
using SME.Pedagogico.Gestao.Data.Functionalities;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.DTO;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Data.Business
{
    public class Profile
    {
        private string _token;
        public Profile(IConfiguration config)
        {
            var createToken = new CreateToken(config);
            _token = createToken.CreateTokenProvisorio();
        }

   
        public async Task<RetornoCargosServidorDTO> GetOccupationsRF(string rf)
        {
            try
            {
                // Pensar num fluxo para que os perfis da cotic enxerguem com duas visualizações 
                // já que quem esta na tabela de privilegios atualmente nao passa aqui.
                var endPoint = new EndpointsAPI();
                var profileApi = new PerfilSgpAPI(endPoint);
                var occupations = await profileApi.GetCargosDeServidor(rf, _token);
                if (occupations != null)
                {
                   
                 // var result = await GetProfileEmployeeInformation(rf, occupations.cargos[0].codigoCargo, "2019");
                
                
                    return occupations;
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



        public async Task<List<SalasPorUEDTO>> GetListClassRoomSchool(string schoolCodeEol, string schooYear)
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


        public async Task<List<EscolasPorDREDTO>> GetListSchoolDre(string dreCodeEol, string schooYear)
        {
            try
            {
                var endPoint = new EndpointsAPI();
                var schoolApi = new DREAPI(endPoint);
                var listSchools = await schoolApi.GetEscolasPorDRE(dreCodeEol, _token);
                if (listSchools != null)
                {
                    return listSchools;
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

        public async Task<RetornoInfoPerfilDTO> GetProfileEmployeeInformation(string codeRF, string codeOccupations, string schoolYear)
        {
            try
            {
                var endPoint = new EndpointsAPI();
                var profileApi = new PerfilSgpAPI(endPoint);
                var profileInformation = await profileApi.getInformacoesPerfil(codeRF, int.Parse(codeOccupations), int.Parse(schoolYear), _token);
                if (profileInformation != null)
                {
                    return profileInformation;
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
