using Microsoft.AspNetCore.Mvc;
using SME.Pedagogico.Gestao.Aplicacao;
using SME.Pedagogico.Gestao.Infra;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.WebApp.Controllers
{
    [ApiController]
    [Route("api/v1/relatorios")]
    public class RelatorioController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Gerar([FromBody]RelatorioImpressaoFiltroDto filtros,
            [FromServices]IRelatorioImpressaoUseCase relatorioImpressaoUseCase)
        {
            await relatorioImpressaoUseCase.Executar(filtros);
            return Ok();
        }
        [HttpPost]
        [Route("sync")]
        public async Task<IActionResult> GerarSync([FromBody]RelatorioImpressaoFiltroDto filtros,
            [FromServices]IRelatorioImpressaoUseCase relatorioImpressaoUseCase)
        {
            return Ok(await relatorioImpressaoUseCase.ExecutarSync(filtros));
        }
    }
}
