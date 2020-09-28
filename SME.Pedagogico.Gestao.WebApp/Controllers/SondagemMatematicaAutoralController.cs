using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.Business;
using SME.Pedagogico.Gestao.Data.DTO.Matematica;

namespace SME.Pedagogico.Gestao.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/SondagemAutoral")]
    [ApiController]
    public class SondagemMatematicaAutoralController : ControllerBase
    {
        private SondagemAutoralBusiness sondagemAutoralBusiness;

        public SondagemMatematicaAutoralController(IConfiguration configuration)
        {
            sondagemAutoralBusiness = new SondagemAutoralBusiness(configuration);
        }

        [HttpGet("Matematica/Periodos")]
        public async Task<IActionResult> ObterPeriodos()
        {
            return Ok(await sondagemAutoralBusiness.ObterPeriodoMatematica());
        }

        [HttpGet("Matematica/Perguntas")]
        public async Task<IActionResult> ObterPerguntas([FromQuery]int anoEscolar)
        {
            return Ok(await sondagemAutoralBusiness.ObterPerguntas(anoEscolar));
        }

        [HttpGet("Matematica")]
        public async Task<IActionResult> ObterSondagemAutoral([FromQuery]FiltrarListagemMatematicaDTO filtrarListagemDto)
        {
            filtrarListagemDto.PerguntaId = "d53ba946-fb3d-4b20-8883-0f7dbab3bddb";
            return Ok(await sondagemAutoralBusiness.ObterListagemAutoral(filtrarListagemDto));
        }

        [HttpPost("Matematica")]
        public async Task<IActionResult> SalvarSondagem([FromBody]IEnumerable<AlunoSondagemMatematicaDto> alunoSondagemMatematicaDtos)
        {
            await sondagemAutoralBusiness.SalvarSondagem(alunoSondagemMatematicaDtos);

            return Ok();
        }
    }
}