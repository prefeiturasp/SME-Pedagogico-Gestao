using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using SME.Pedagogico.Gestao.WebApp.Models.ClassRoom;
using SME.Pedagogico.Gestao.Data.DataTransfer;
using SME.Pedagogico.Gestao.Data.Business;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Data.DTO.Portugues;
using SME.Pedagogico.Gestao.Data.DTO.Portugues.Relatorio;
using System;

namespace SME.Pedagogico.Gestao.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SondagemPortuguesController : ControllerBase
    {
        public IConfiguration _config;

        public SondagemPortuguesController(IConfiguration config)
        {

            _config = config;
        }



        [HttpPost]
        public async Task<ActionResult> IncluirSondagemPortugues(List<StudentPollPortuguese> ListStudentPollPortuguese)
        {
            try
            {
                var BusinessPollPortuguese = new Data.Business.PollPortuguese(_config);
                BusinessPollPortuguese.InsertPollPortuguese(ListStudentPollPortuguese);

                return (Ok());
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpGet]
        public async Task<ActionResult> ObterRelatorioPortugues([FromQuery]RelatorioPortuguesFiltroDto relatorioPortuguesFiltroDto)
        {
            try
            {
                var relatorio = new RelatorioPortugues();

                return Ok(await relatorio.ObterRelatorioPortugues(relatorioPortuguesFiltroDto));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> ListarSondagemPortugues(ClassRoomModel classRoomModel)
        {
            try
            {
                var classRoomDataTransfer = new ClassRoomFilter()
                {
                    classroomCodeEol = classRoomModel.classroomCodeEol,
                    dreCodeEol = classRoomModel.dreCodeEol,
                    schoolCodeEol = classRoomModel.schoolCodeEol,
                    schoolYear = classRoomModel.schoolYear,
                    yearClassroom = classRoomModel.yearClassroom
                };

                var BusinessPoll = new PollPortuguese(_config);
                var ListStudentPollPortuguese = await BusinessPoll.ListStudentPollPortuguese(classRoomDataTransfer);

                if (ListStudentPollPortuguese != null)
                {
                    return (Ok(ListStudentPollPortuguese));
                }

                else
                {
                    return NoContent();
                }

            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Grupos()
        {
            var sondagemAutoralBll = new PollPortuguese(_config);
            return Ok(sondagemAutoralBll.ListarGrupos());
        }

        [HttpGet]
        public async Task<ActionResult> ListarOrdens()
        {
            var sondagemAutoralBll = new PollPortuguese(_config);
            return Ok(sondagemAutoralBll.ListarOrdens());
        }

        [HttpGet]
        public async Task<ActionResult> ComponenteCurricular()
        {
            var sondagemAutoralBll = new PollPortuguese(_config);
            return Ok(sondagemAutoralBll.RetornaComponenteCurricularPortugues());
        }
        [HttpGet]
        public async Task<ActionResult> Bimestres()
        {
            var sondagemAutoralBll = new PollPortuguese(_config);
            return Ok(sondagemAutoralBll.RetornaPeriodosBimestres());
        }

        [HttpPost]
        public async Task<IActionResult> SondagemPortuguesAutoral([FromBody]IEnumerable<AlunoSondagemPortuguesDTO2> ListaAlunosSondagemDto)
        {
            var sondagemAutoralBll = new PollPortuguese(_config);
            sondagemAutoralBll.SalvarSondagemAutoralPortugues(ListaAlunosSondagemDto);

            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> ExcluirSondagemPortugues([FromQuery] FiltrarListagemDto filtrarListagemDto)
        {
            var sondagemAutoralBll = new PollPortuguese(_config);
            var sondagem = await sondagemAutoralBll.ObterSondagemPortugues(filtrarListagemDto);
            if (sondagem != null)
            {
                sondagemAutoralBll.ExcluirSondagem(sondagem);
                return Ok();
            }
            return BadRequest("Sondagem não encontrada");

        }

        [HttpGet]
        public async Task<IActionResult> ListarSondagemPortuguesAutoral([FromQuery] FiltrarListagemDto filtrarListagemDto)
        {
            var sondagemAutoralBll = new PollPortuguese(_config);

            // return Ok(await sondagemAutoralBll.ListarAlunosPortuguesAutoral(filtrarListagemDto));
            return Ok(await sondagemAutoralBll.ListarAlunosPortugues(filtrarListagemDto));
        }

        [HttpGet]
        public async Task<ActionResult> Perguntas([FromQuery] int sequenciaOrdem, string grupoId)
        {
            if (sequenciaOrdem < 1 || sequenciaOrdem > 3)
                return BadRequest("O valor do parametro sequenciaOrdem deve estar entre 1 e 3");

            if (string.IsNullOrEmpty(grupoId))
                return BadRequest("O valor do parametro grupId é obrigatorio");

            var sondagemAutoralBll = new PollPortuguese(_config);

            return Ok(await sondagemAutoralBll.ListarPerguntas(sequenciaOrdem, grupoId));
        }

        [HttpGet]
        public async Task<ActionResult> SequenciaDeOrdens([FromQuery] FiltrarListagemDto filtrarListagemDto)
        {
            var sondagemAutoralBll = new PollPortuguese(_config);

            return Ok(await sondagemAutoralBll.ListaSequenciaOrdensSalva(filtrarListagemDto));
        }
    }
}
