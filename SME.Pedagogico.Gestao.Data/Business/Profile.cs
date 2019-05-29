using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.DataTransfer;
using SME.Pedagogico.Gestao.Data.Functionalities;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.DTO;
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

        private void DeParaProfile()
        {
            
        }

        public async Task<RetornoCargosServidorDTO> GetOccupationsRF(string rf)
        {
            try
            {
                var endPoint = new EndpointsAPI();
                var profileApi = new PerfilSgpAPI(endPoint);
                var occupations = await profileApi.GetCargosDeServidor(rf, _token);
                if (occupations != null)
                {

                    var result = await GetProfileEmployeeInformation(rf, occupations.cargos[0].codigoCargo, "2019");
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
