using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Aplicacao;
using SME.Pedagogico.Gestao.Data.Business;
using SME.Pedagogico.Gestao.Data.DTO;
using System.Threading.Tasks;
using EnumModel = SME.Pedagogico.Gestao.Models.Enums;

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
        public async Task<ActionResult<string>> ListarPeriodoDeAberturas(string schoolYear, [FromQuery] EnumModel.TipoPeriodoEnum? tipoPeriodicidade)
        {
            var periodoAbertura = new PeriodoAbertura(_config);
            var lista = await periodoAbertura.GetPeriodoDeAberturas(schoolYear, tipoPeriodicidade);
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
            var listClassRoom = await mediator.Send(new ObterTurmasPorUeCodigoQuery(classrooms.schoolYear, classrooms.schoolCodeEol, true));

            if (listClassRoom != null)
                return Ok(listClassRoom);

            return (NoContent());
        }

        /// <summary>
        /// Listar escolas por dre
        /// </summary>
        /// <param name="schoolFilters"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> ListarEscolasPorDre(BuscarEscolasPorDreDTO schoolFilters, [FromServices]IMediator mediator)
        {
            if (string.IsNullOrEmpty(schoolFilters.dreCodeEol))
                return (NoContent());

            var listSchool = await mediator.Send(new ObterUesPorDreQuery(long.Parse(schoolFilters.dreCodeEol), long.Parse(schoolFilters.schoolYear)));


            if (listSchool != null)
            {
                return (Ok(listSchool));
            }
            else
            {
                return (NoContent());
            }
        }

        /// <summary>
        /// Listar todas as dres
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<string>> ListarDres([FromQuery]long anoLetivo, [FromServices]IMediator mediator)
        {
            var listDres = await mediator.Send(new ObterDresQuery(anoLetivo));

            if (listDres != null)
            {
                return (Ok(listDres));
            }
            else
            {
                return (NoContent());
            }
        }

        /// <summary>
        /// Busca as disciplinas pelo RF e código da turma selecionada.
        /// </summary>
        /// <param name="buscarDisciplinasPorRfTurmaDto">Parâmetro com o RF e código da turma.</param>
        /// <returns>Lista disciplinas com nome e código.</returns>
        [HttpPost]
        public async Task<ActionResult<string>> ListarDisciplinasPorRfTurma(BuscarDisciplinasPorRfTurmaDto buscarDisciplinasPorRfTurmaDto, [FromServices]IMediator mediator)
        {
            var listDiscplines = await mediator.Send(new ObterCCPorTurmaUsuarioQuery(buscarDisciplinasPorRfTurmaDto.CodigoTurmaEol));

            if (listDiscplines != null)
                return (Ok(listDiscplines));

            return (NoContent());
        }
    }
}

