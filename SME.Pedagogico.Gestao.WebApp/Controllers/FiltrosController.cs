using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.Business;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FiltrosController : ControllerBase
    {
        //Necessário para gerar o Token temporariamente
        public IConfiguration _config;
        public FiltrosController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public async Task<ActionResult<string>> ListarTurmasPorEscola(string schoolCodeEol, string schoolYear)
        {
            try
            {
                //Necessário para gerar o Token temporariamente
                var filterBusiness = new Filters(_config);
                var funcionarioDTO = filterBusiness.GetClassRoomSchool(schoolCodeEol, schoolYear);

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

        public async Task<ActionResult<string>> ListarEscolasPorDre(string schoolCodeEol, string schoolYear)
        {
            try
            {
                //Necessário para gerar o Token temporariamente
                var filterBusiness = new Filters(_config);
                var funcionarioDTO = filterBusiness.GetClassRoomSchool(schoolCodeEol, schoolYear);

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


    }

}

