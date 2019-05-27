using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SME.Pedagogico.Gestao.Data.Business;
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
        public CargoController(IConfiguration config)
        {
            _config = config;
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

        public async Task<ActionResult> PerfilServidor(string codigoRF, string codigoCargo, string anoLetivo)
        {
            try
            {
                //Necessário para gerar o Token temporariamente
                var profileBusiness = new Profile(_config);
                var profileInformation = profileBusiness.GetProfileEmployeeInformation(codigoRF, codigoCargo, anoLetivo);

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
    }
}
