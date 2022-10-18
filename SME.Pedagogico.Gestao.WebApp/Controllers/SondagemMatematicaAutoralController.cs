using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Aplicacao;
using SME.Pedagogico.Gestao.Data.Business;
using SME.Pedagogico.Gestao.Data.DTO.Matematica;
using SME.Pedagogico.Gestao.Infra;
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

        public SondagemMatematicaAutoralController(IServicoTelemetria servicoTelemetria)
        {
            sondagemAutoralBusiness = new SondagemAutoralBusiness(servicoTelemetria);
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
        public async Task<IActionResult> ObterPerguntas([FromQuery] int anoEscolar, [FromQuery] int anoLetivo,[FromQuery] int bimestre)
        {
            var perguntas = await sondagemAutoralBusiness.ObterPerguntas(anoEscolar, anoLetivo,bimestre);
            return Ok(perguntas);
        }

        [HttpGet("Matematica")]
        public async Task<IActionResult> ObterSondagemAutoral([FromQuery] FiltrarListagemMatematicaDTO filtrarListagemDto, [FromServices]IMediator mediator)
        {
            var retorno = await mediator.Send(new ObterListagemAutoralQuery(filtrarListagemDto));
            return Ok(retorno);
        }

        [HttpPost("Matematica")]
        public async Task<IActionResult> SalvarSondagem([FromBody] IEnumerable<AlunoSondagemMatematicaDto> alunoSondagemMatematicaDtos)
        {  
            await sondagemAutoralBusiness.SalvarSondagemMatematica(alunoSondagemMatematicaDtos);

            return Ok();
        }


        [HttpPost("Matematica/ExcluirDivergencias")]
        public async Task<IActionResult> ExcluirDivergencias([FromQuery] string dreCodigo, [FromServices] IMediator mediator)
        {
            await mediator.Send(new ExcluirSondagemMatematica2022ComDivergenciasCommand(dreCodigo));

            return Ok();
        }

    }
}
