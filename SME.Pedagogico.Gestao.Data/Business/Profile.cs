using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using SME.Pedagogico.Gestao.Data.Functionalities;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.DTO;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
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

        EndpointsAPI endPoint = new EndpointsAPI();

        public async Task<RetornoCargosServidorDTO> GetOccupationsRF(string rf)
        {
            if (string.IsNullOrWhiteSpace(rf))
                return null;

            try
            {
                var profileApi = new PerfilSgpAPI(endPoint);
                var occupations = await profileApi.GetCargosDeServidor(rf, _token);
                string codigoCargoAtivo;
                bool occupationAccess = false;

                if (occupations == null)
                    return null;

                foreach (var occupation in occupations.cargos)
                {
                    codigoCargoAtivo = RetornaCargoAtivo(occupation);

                    if (codigoCargoAtivo == "3239" ||
                        codigoCargoAtivo == "3301" ||
                        // codigoCargoAtivo == "3336" ||
                        codigoCargoAtivo == "3310" ||
                        codigoCargoAtivo == "3379" ||
                        codigoCargoAtivo == "3360")
                    {
                        occupationAccess = true;
                        break;
                    }
                }

                if (!occupationAccess)
                    return null;

                return occupations;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public string RetornaCargoAtivo(RetornoCargoDTO occupation)
        {
            string codigoCargoAtivo;
            if (occupation.codigoCargoSobreposto != null)
                codigoCargoAtivo = occupation.codigoCargoSobreposto;
            else
            {
                codigoCargoAtivo = occupation.codigoCargo;
            }

            return codigoCargoAtivo;
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
                var parseado = int.TryParse(codeOccupations, out int result);
                var profileInformation = await profileApi.getInformacoesPerfil(codeRF, parseado ? result : 0, int.Parse(schoolYear), _token);
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
                return null;
            }

        }

        public async Task<List<DREsDTO>> GetCodeDreAdm(string userName)
        {
            try
            {
                using (Contexts.SMEManagementContextData db = new Contexts.SMEManagementContextData())
                {
                    var user = db.PrivilegedAccess.Where(x => x.Login == userName).FirstOrDefault();

                    if (user != null && !string.IsNullOrEmpty(user.DreCodeEol))
                    {
                        var dreApi = new DREAPI(endPoint);
                        return await dreApi.GetDresPorCodigo(user.DreCodeEol, _token);
                    }

                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
