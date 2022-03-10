using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.Business;
using SME.Pedagogico.Gestao.Data.DTO.Matematica;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpGet("Matematica/Periodo/Aberto")]
        public async Task<IActionResult> ConsultarSePeriodoEstaAberto([FromQuery] int bimestre, [FromQuery] string anoLetivo)
        {
            return Ok(await sondagemAutoralBusiness.ConsultarSePeriodoEstaAberto(bimestre, anoLetivo));
        }

        [HttpGet("Matematica/Perguntas")]
        public async Task<IActionResult> ObterPerguntas([FromQuery]int anoEscolar, [FromQuery]int anoLetivo)
        {
            return Ok(await sondagemAutoralBusiness.ObterPerguntas(anoEscolar, anoLetivo));
        }

        [HttpGet("Matematica")]
        public async Task<IActionResult> ObterSondagemAutoral([FromQuery]FiltrarListagemMatematicaDTO filtrarListagemDto)
        {
            var retorno = await sondagemAutoralBusiness.ObterListagemAutoral(filtrarListagemDto);
            return Ok(retorno);
        }

        [HttpPost("Matematica")]
        public async Task<IActionResult> SalvarSondagem([FromBody]IEnumerable<AlunoSondagemMatematicaDto> alunoSondagemMatematicaDtos)
        {
            await sondagemAutoralBusiness.SalvarSondagemMatematica(alunoSondagemMatematicaDtos);

            return Ok();
        }
    }
}