using Microsoft.AspNetCore.Mvc;
using SME.Pedagogico.Gestao.Aplicacao.Interfaces.CasosDeUso.ExemploGames;
using SME.Pedagogico.Gestao.Infra.Dtos.Relatorios;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExemploRelatorioController : ControllerBase
    {
        [HttpPost("games")]
        public async Task<IActionResult> ExemploGames([FromBody] FiltroRelatorioGamesDto filtroRelatorioGamesDto, [FromServices] IGamesUseCase gamesUseCase)
        {
            return Ok(await gamesUseCase.Executar(filtroRelatorioGamesDto));
        }
    }
}
