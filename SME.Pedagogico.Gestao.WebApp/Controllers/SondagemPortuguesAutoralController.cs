using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.Business;
using SME.Pedagogico.Gestao.Data.DataTransfer;
using SME.Pedagogico.Gestao.Data.DataTransfer.Portugues;
using SME.Pedagogico.Gestao.WebApp.Models.ClassRoom;

namespace SME.Pedagogico.Gestao.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SondagemPortuguesAutoralController : ControllerBase
    {

        public readonly IConfiguration _config;


        public SondagemPortuguesAutoralController(IConfiguration config)
        {
            _config = config;
        }


        [HttpGet]
        public async Task<ActionResult> ListarGrupos()
        {
            var sondagemAutoralBll = new PollPortuguese(_config);
            return Ok(sondagemAutoralBll.ListarGrupos());
        }

        public async Task<ActionResult> ListarOrdens()
        {
            var sondagemAutoralBll = new PollPortuguese(_config);
            return Ok(sondagemAutoralBll.ListarOrdens());
        }

        // IncluirSondagemPortugues
        [HttpPost]
        public async Task<ActionResult> ListarSondagemPortugues(FiltrosPortuguesAutoralDTO classRoomModel)
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

                var BusinessPoll = new Data.Business.PollPortuguese(_config);
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
    }
}

      