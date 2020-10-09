using MediatR;
using Microsoft.AspNetCore.Mvc;
using SME.Pedagogico.Gestao.Aplicacao;
using SME.Pedagogico.Gestao.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.WebApp.Controllers
{
    [ApiController]
    [Route("api/v1/relatorios")]
    public class RelatorioController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Gerar([FromServices]IMediator mediator,[FromBody]RelatorioImpressaoFiltroDto filtros,
            [FromServices]IRelatorioImpressaoUseCase relatorioMatematicaNumerosAutoralConsolidadoUseCase)
        {
            await relatorioMatematicaNumerosAutoralConsolidadoUseCase.Executar(filtros);
            return Ok();
        }
    }
}
