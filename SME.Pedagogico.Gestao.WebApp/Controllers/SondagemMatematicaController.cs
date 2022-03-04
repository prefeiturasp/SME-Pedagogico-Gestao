using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.Business;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Data.DTO.Matematica;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.WebApp.Controllers
{
    [Produces("application/json")]
    //[Route("api/SondagemAlfabetizacao/")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SondagemMatematicaController : Controller
    {
        private SondagemMatematica sondagemAlfabetizacaoBusiness;

        /// <summary>
        /// Construtor padrão para o SondagemMatematicaController, faz injeção de dependências SMEManagementContext.
        /// </summary>
        public SondagemMatematicaController(IConfiguration configuration)
        {
            sondagemAlfabetizacaoBusiness = new SondagemMatematica(configuration);
        }

        /// <summary>
        /// Método para fazer a sondagem de matemática de CM.
        /// </summary>
        /// <param name="dadosSondagem">Objeto que contém informações da sondagem de matemática</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GravaSondagemCM([FromBody]List<SondagemMatematicaOrdemDTO> dadosSondagem)
        {
            await sondagemAlfabetizacaoBusiness.InsertPoolCMAsync(dadosSondagem);

            return Ok();
        }

        /// <summary>
        /// Método para fazer a sondagem de matemática de CM.
        /// </summary>
        /// <param name="filtroSondagem">Objeto que contém filtro para retorno de sondagem de CM</param>
        /// <returns>Dados da sondagem</returns>
        [HttpPost]
        public async Task<IActionResult> ListaSondagemCM([FromBody]FiltroSondagemMatematicaDTO filtroSondagem)
        {
            return Ok(await sondagemAlfabetizacaoBusiness.ListPoolCMAsync(filtroSondagem));
        }

        /// <summary>
        /// Método para fazer a sondagem de matemática de CA.
        /// </summary>
        /// <param name="filtroSondagem">Objeto que contém filtro para retorno de sondagem de CA</param>
        /// <returns>Dados da sondagem</returns>
        [HttpPost]
        public async Task<ActionResult> ListaSondagemCA([FromBody]FiltroSondagemMatematicaDTO filtroSondagem)
        {
            return Ok(await sondagemAlfabetizacaoBusiness.ListPoolCAAsync(filtroSondagem));
        }

        /// <summary>
        /// Método para fazer a sondagem de matemática de Numeros.
        /// </summary>
        /// <param name="filtroSondagem">Objeto que contém filtro para retorno de sondagem de Numeros</param>
        /// <returns>Dados da sondagem</returns>
        [HttpPost]
        public async Task<IActionResult> ListaSondagemNumeros([FromBody]FiltroSondagemMatematicaDTO filtroSondagem)
        {
            return Ok(await sondagemAlfabetizacaoBusiness.ListPoolNumerosAsync(filtroSondagem));
        }

        /// <summary>
        /// Método para fazer a sondagem de matemática de CA.
        /// </summary>
        /// <param name="dadosSondagem">Objeto que contém informações da sondagem de matemática</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GravaSondagemCA([FromBody]List<SondagemMatematicaOrdemDTO> dadosSondagem)
        {
            await sondagemAlfabetizacaoBusiness.InsertPoolCAAsync(dadosSondagem);
            return Ok();
        }

        /// <summary>
        /// Método para fazer a sondagem de matemática de Números.
        /// </summary>
        /// <param name="dadosSondagem">Objeto que contém informações da sondagem de matemática</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GravaSondagemNumeros([FromBody]List<SondagemMatematicaNumerosDTO> dadosSondagem)
        {
            
            await sondagemAlfabetizacaoBusiness.InsertPoolNumerosAsync(dadosSondagem);
            return Ok();
        }

        [HttpGet("Matematica/Perguntas")]
        public async Task<IActionResult> ObterPerguntas([FromQuery] int anoEscolar, [FromQuery] int anoLetivo, [FromQuery] int grupo)
        {
            return Ok(await sondagemAlfabetizacaoBusiness.ObterPerguntas(anoEscolar, anoLetivo, grupo));
        }

        [HttpGet("Matematica/Alunos")]
        public async Task<IActionResult> ObterAlunos([FromQuery] FiltrarListagemMatematicaDTO filtrarListagemDto)
        {
            var retorno = await sondagemAlfabetizacaoBusiness.ObterAlunos(filtrarListagemDto);
            return Ok(retorno);
        }
    }
}