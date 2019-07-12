//CargoController
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using SME.Pedagogico.Gestao.Data.Business;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Data.Functionalities;

namespace SME.Pedagogico.Gestao.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        //Necessário para gerar o Token temporariamente
        public IConfiguration _config;
        public CargoController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public string CriaToken()
        {
            var criaToken = new CreateToken(_config);

            return criaToken.CreateTokenProvisorio();
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
            try
            {
                string codigoRF = occupationsProfile.codigoRF;
                string codigoCargo = occupationsProfile.codigoCargo;
                string anoLetivo = occupationsProfile.anoLetivo;

                //Necessário para gerar o Token temporariamente
                var profileBusiness = new Profile(_config);

                var profileInformation = await profileBusiness.GetProfileEmployeeInformation(codigoRF, codigoCargo, anoLetivo);

                if (profileInformation != null)
                {
                    return (Ok(profileInformation));
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
