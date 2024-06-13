using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.Business;
using SME.Pedagogico.Gestao.WebApp.Middlewares;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.WebApp.Controllers
{
    [ApiController]
    [Route("api/integracoes/portugues")]
    [ChaveIntegracaoSondagemApi]
    public class SondagemPortuguesIntegracaoController : ControllerBase
    {
        private readonly IConfiguration config;

        public SondagemPortuguesIntegracaoController(IConfiguration config)
        {
            this.config = config ?? throw new System.ArgumentNullException(nameof(config));
        }

        [HttpGet("turmas/{turmaCodigo}/alunos/{alunoCodigo}")]
        public async Task<IActionResult> ObterSondagemAlunoTurma(string turmaCodigo, string alunoCodigo)
        {
            var sondagemAutoralBll = new PollPortuguese(config);
            return Ok(await sondagemAutoralBll.ObterResultadosAluno(turmaCodigo, alunoCodigo));
        }
    }
}
