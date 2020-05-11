//CargoController
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using SME.Pedagogico.Gestao.Data.Business;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Data.Functionalities;
using System.Linq;
using SME.Pedagogico.Gestao.WebApp.Models;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.DTO;

namespace SME.Pedagogico.Gestao.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        //Necessário para gerar o Token temporariamente
        public IConfiguration _config;
        public AbrangenciaAPI _AbrangenciaAPI;

        public CargoController(IConfiguration config)
        {
            _config = config;
            _AbrangenciaAPI = new AbrangenciaAPI();
        }

        [HttpGet]
        public async Task<ActionResult> CargosPorRF(string login)
        {
            try
            {
                //Necessário para gerar o Token temporariamente
                var profileBusiness = new Profile(_config);
                var funcionarioDTO = profileBusiness.GetOccupationsRF(login);

                if (funcionarioDTO != null)
                {
                    return (Ok(funcionarioDTO));
                }
                else
                {
                    return (NoContent());
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpPost]
        public async Task<ActionResult> PerfilServidor(BuscaPerfilServidor occupationsProfile)
        {
            string codigoRF = occupationsProfile.codigoRF;
            string codigoCargo = occupationsProfile.codigoCargo;
            string anoLetivo = occupationsProfile.anoLetivo;

            //Necessário para gerar o Token temporariamente
            var profileBusiness = new Profile(_config);

            var profileInformation = await profileBusiness.GetProfileEmployeeInformation(codigoRF, codigoCargo, anoLetivo, occupationsProfile.activeRole?.PerfilId);

            if (profileInformation == null)
                return NoContent();

            if (occupationsProfile.activeRole?.PerfilId != null)
            {
                var perfil = Perfil.ObterPerfis().FirstOrDefault(x => x.PerfilGuid == occupationsProfile.activeRole.PerfilId);

                if (perfil == null || perfil.IsTeacher)
                    return Ok(profileInformation);

                if (perfil.IsSme && profileInformation.DREs.Count > 1)
                    AdicionarTodasDres(occupationsProfile, ref profileInformation);

                if (profileInformation.Escolas.Count > 1)
                    AdicionarTodasUes(occupationsProfile, ref profileInformation);
            }

            return Ok(profileInformation);
        }

        private static void AdicionarTodasDres(BuscaPerfilServidor occupationsProfile, ref RetornoInfoPerfilDTO profileInformation)
        {
            profileInformation.DREs.ToList().Insert(0, new RetornoDREDTO
            {
                Codigo = "todas",
                Nome = "todas",
                Sigla = "todas"
            });
        }

        private static void AdicionarTodasUes(BuscaPerfilServidor occupationsProfile, ref RetornoInfoPerfilDTO profileInformation)
        {
            var escolas = profileInformation.Escolas.ToList();
            var dres = profileInformation.DREs.ToList();

            escolas.InsertRange(0, dres.Select(x => new RetornoEscolaDTO
            {
                Codigo = "todas",
                CodigoDRE = x.Codigo,
                Nome = "todas",
                Sigla = "todas"
            }));

            profileInformation.Escolas = escolas.ToHashSet();
        }

        private async Task<ActionResult> ObterProfileEmployeeInformationSME(BuscaPerfilServidor occupationsProfile, Perfil perfilSelecionado)
        {
            var createToken = new CreateToken(_config);
            var _token = createToken.CreateTokenProvisorio();

            var abrangencia = await _AbrangenciaAPI.AbrangenciaCompactaSondagem(_token, occupationsProfile.codigoRF, perfilSelecionado.PerfilGuid);

            var retorno = new RetornoInfoPerfilDTO
            {
                DREs = abrangencia.Dres.Where(x => abrangencia.Ues.Any(z => z.CodigoDRE.Equals(x.CodigoDRE)))
                .Select(x => new RetornoDREDTO
                {
                    Codigo = x.CodigoDRE,
                    Nome = x.NomeDRE,
                    Sigla = x.SiglaDRE
                }).ToHashSet(),
                CodigoServidor = occupationsProfile.codigoRF,
                Escolas = abrangencia.Ues.Where(x => abrangencia.Turmas.Any(z => z.CodigoEscola.Equals(x.Codigo)))
                .Select(x => new RetornoEscolaDTO
                {
                    Sigla = x.Sigla,
                    Codigo = x.Codigo,
                    CodigoDRE = x.CodigoDRE,
                    Nome = x.Nome
                }).ToHashSet()
            };

            return Ok(retorno);
        }

        [HttpPost]
        public async Task<ActionResult> RetornaCodigoDREAdm([FromBody]string userName)
        {
            try
            {
                var profileBusiness = new Profile(_config);
                var dre = await profileBusiness.GetCodeDreAdm(userName);
                if (dre != null)
                {
                    return (Ok(dre));
                }
                else
                {
                    return (NoContent());
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
