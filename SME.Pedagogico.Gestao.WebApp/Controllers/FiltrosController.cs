using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Aplicacao;
using SME.Pedagogico.Gestao.Data.Business;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Data.Integracao;
using System;
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
        public async Task<ActionResult<string>> ListarTurmasPorEscola(BuscarTurmasPorEscola classrooms, [FromServices]IMediator mediator)
        {
            try
            {
                //Necessário para gerar o Token temporariamente
                //var filterBusiness = new Filters(_config);
                //var listClassRoom = await filterBusiness.GetListClassRoomSchool(classrooms.schoolCodeEol, classrooms.schoolYear);

                var listClassRoom =  await mediator.Send(new ObterTurmasPorUeCodigoQuery(classrooms.schoolYear, classrooms.schoolCodeEol));

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
        public async Task<ActionResult<string>> ListarEscolasPorDre(BuscarEscolasPorDreDTO schoolFilters, [FromServices]IMediator mediator)
        {
            try
            {

                 var listSchool = await  mediator.Send(new ObterUesPorDreQuery(long.Parse(schoolFilters.dreCodeEol), long.Parse(schoolFilters.schoolYear)));

                //Necessário para gerar o Token temporariamente
                //var filterBusiness = new Filters(_config);
                //var listSchool = await filterBusiness.GetListSchoolDre(schoolFilters.dreCodeEol, schoolFilters.schoolYear);

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
        public async Task<ActionResult<string>> ListarDres([FromQuery]long anoLetivo, [FromServices]IMediator mediator)
        {
            try
            {
                //Necessário para gerar o Token temporariamente
                //var filterBusiness = new Filters(_config);
                //var listDres = await filterBusiness.GetListDre();

                //TODO: Obter o Ano Letivo
                
                var listDres = await  mediator.Send(new ObterDresQuery(anoLetivo));

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

        /// <summary>
        /// Busca as disciplinas pelo RF e código da turma selecionada.
        /// </summary>
        /// <param name="buscarDisciplinasPorRfTurmaDto">Parâmetro com o RF e código da turma.</param>
        /// <returns>Lista disciplinas com nome e código.</returns>
        [HttpPost]
        public async Task<ActionResult<string>> ListarDisciplinasPorRfTurma(BuscarDisciplinasPorRfTurmaDto buscarDisciplinasPorRfTurmaDto)
        {
            var novoSgpApi = new NovoSGPAPI();
            var listDiscplines = await novoSgpApi.DisciplinasPorTurma(buscarDisciplinasPorRfTurmaDto);

            if (listDiscplines != null)
                return (Ok(listDiscplines));

            return (NoContent());
        }
    }
}

