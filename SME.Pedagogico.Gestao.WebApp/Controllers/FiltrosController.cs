using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.Business;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
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

        [HttpGet("{schoolYear}")]
        //[Route("api/[controller]/[action]/[id]")]
        public async Task<ActionResult<string>> ListarPeriodoDeAberturas(string schoolYear)
        {
            var periodoAbertura = new PeriodoAbertura(_config);
            var lista = await periodoAbertura.GetPeriodoDeAberturas(schoolYear);
            return (Ok(lista));
        }

        /// <summary>
        /// Lista turma por escola
        /// </summary>
        /// <param name="classrooms"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> ListarTurmasPorEscola(BuscarTurmasPorEscola classrooms)
        {
            try
            {
                //Necessário para gerar o Token temporariamente
                var filterBusiness = new Filters(_config);

                var listClassRoom = await filterBusiness.GetListClassRoomSchool(classrooms.schoolCodeEol, classrooms.schoolYear);

                if (listClassRoom != null)
                {
                    return (Ok(listClassRoom));
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

        /// <summary>
        /// Listar escolas por dre
        /// </summary>
        /// <param name="schoolFilters"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> ListarEscolasPorDre(BuscarEscolasPorDreDTO schoolFilters)
        {
            try
            {
                //Necessário para gerar o Token temporariamente
                var filterBusiness = new Filters(_config);
                var listSchool = await filterBusiness.GetListSchoolDre(schoolFilters.dreCodeEol, schoolFilters.schoolYear);
                
                if (listSchool != null)
                {
                    return (Ok(listSchool));
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

        /// <summary>
        /// Listar todas as dres
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<string>> ListarDres()
        {
            try
            {
                //Necessário para gerar o Token temporariamente
                var filterBusiness = new Filters(_config);
                var listDres = await filterBusiness.GetListDre();

                if (listDres != null)
                {
                    return (Ok(listDres));
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

