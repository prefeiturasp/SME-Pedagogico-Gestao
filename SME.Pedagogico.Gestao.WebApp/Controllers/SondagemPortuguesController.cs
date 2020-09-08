using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using SME.Pedagogico.Gestao.WebApp.Models.ClassRoom;
using SME.Pedagogico.Gestao.Data.DataTransfer;
using SME.Pedagogico.Gestao.Data.Business;
using AutoMapper;

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
    }
}
