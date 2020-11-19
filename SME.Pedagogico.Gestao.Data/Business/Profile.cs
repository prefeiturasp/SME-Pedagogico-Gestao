using Microsoft.Extensions.Configuration;
using MoreLinq;
using SME.Pedagogico.Gestao.Data.Functionalities;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.DTO;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SME.Pedagogico.Gestao.Data.Constantes;

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

        public async Task<bool> VerificaSeProfessorTemAcesso(string rf)
        {
            var profileApi = new PerfilSgpAPI(endPoint);
            return await profileApi.VerificaSeProfessorTemAcesso(rf, _token);
        }

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

                var temAcesso = await profileApi.VerificaSeProfessorTemAcesso(rf, _token);
                if (occupations != null && temAcesso)
                {
                    var cargoProfessor = new RetornoCargoDTO();
                    cargoProfessor.codigoCargo = CODIGO_CARGO_PROFESSOR;
                    cargoProfessor.nomeCargo = "Professor";
                    occupations.cargos.Add(cargoProfessor);
                }

                foreach (var occupation in occupations.cargos)
                {
                    codigoCargoAtivo = RetornaCargoAtivo(occupation);

                    if (codigoCargoAtivo == CODIGO_CARGO_CP || codigoCargoAtivo == CODIGO_CARGO_DIRETOR || codigoCargoAtivo == CODIGO_CARGO_AD)
                    {
                        occupationAccess = true;
                        break;
                    }
                }
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

        public async Task<RetornoInfoPerfilDTO> GetProfileEmployeeInformation(string codeRF, string codeOccupations, string schoolYear, Guid? Perfil, string roleName = null)
        {
            try
            {
                var endPoint = new EndpointsAPI();
                var profileApi = new PerfilSgpAPI(endPoint);
                var parseado = int.TryParse(codeOccupations, out int result);

                var profileInformation = new RetornoInfoPerfilDTO();

                // Para coordenador pedagógico, assitente de diretor, diretor busca a abrangência no SGP
                if (!string.IsNullOrWhiteSpace(roleName) && (roleName.Equals("CP") || roleName.Equals("AD") || roleName.Equals("Diretor")))
                    profileInformation = await ObterAbrangencia(codeRF, null, profileInformation);
                else
                    profileInformation = await profileApi
                        .getInformacoesPerfil(codeRF, parseado ? result : 0, int.Parse(schoolYear), _token, Perfil);

                if (profileInformation != null)
                    return profileInformation;
                else
                    return null;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        private async Task<RetornoInfoPerfilDTO> ObterAbrangencia(string codeRF, int? schoolYear, RetornoInfoPerfilDTO profileInformation)
        {
            var novoSgpApi = new NovoSGPAPI();
            var dres = await novoSgpApi.AbrangenciaDres(codeRF, schoolYear);

            dres.ForEach(dre =>
               {
                   profileInformation.DREs.Add(new RetornoDREDTO()
                   {
                       Codigo = dre.Codigo,
                       Nome = dre.Nome,
                       Sigla = dre.Abreviacao
                   });
                   var ues = novoSgpApi.AbrangenciaUes(codeRF, schoolYear, dre.Codigo).Result;
                   ues.ForEach(ue => profileInformation.Escolas.Add(new RetornoEscolaDTO()
                   {
                       Codigo = ue.Codigo,
                       CodigoDRE = dre.Codigo,
                       Nome = ue.Nome,
                       Sigla = ue.NomeSimples
                   }));
               });

            return profileInformation;
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
