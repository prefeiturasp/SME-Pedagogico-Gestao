using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.Contexts;
using SME.Pedagogico.Gestao.Data.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.WebApp.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SondagemMatematicaController : Controller
    {
        #region ==================== ATTRIBUTES ====================

        private readonly SMEManagementContext _db;
        public readonly IConfiguration _config;

        #endregion

        #region ==================== CONSTRUCTORS ====================

        /// <summary>
        /// Construtor padrão para o SondagemMatematicaController, faz injeção de dependências SMEManagementContext.
        /// </summary>
        /// <param name="db">Depêndencia de dataContext (SMEManagementContext)</param>
        public SondagemMatematicaController(SMEManagementContext db, 
                                            IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        #endregion

        #region ==================== METHODS ====================

        #region -------------------- PRIVATE --------------------
        #endregion

        #region -------------------- PUBLIC --------------------

        /// <summary>
        /// Método para fazer a sondagem de matemática de CM.
        /// </summary>
        /// <param name="dadosSondagem">Objeto que contém informações da sondagem de matemática</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> GravaSondagemCM([FromBody]List<SondagemMatematicaOrdemDTO> dadosSondagem)
        {
            try
            {
                var businessSondagemMatematica = new Data.Business.SondagemMatematica(_config);
                await businessSondagemMatematica.InsertPoolCM(dadosSondagem);

                return (Ok());
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        /// <summary>
        /// Método para fazer a sondagem de matemática de CA.
        /// </summary>
        /// <param name="dadosSondagem">Objeto que contém informações da sondagem de matemática</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> GravaSondagemCA([FromBody]List<SondagemMatematicaOrdemDTO> dadosSondagem)
        {
            try
            {
                var businessSondagemMatematica = new Data.Business.SondagemMatematica(_config);
                await businessSondagemMatematica.InsertPoolCA(dadosSondagem);

                return (Ok());
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        /// <summary>
        /// Método para fazer a sondagem de matemática de Números.
        /// </summary>
        /// <param name="dadosSondagem">Objeto que contém informações da sondagem de matemática</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> GravaSondagemNumeros([FromBody]List<SondagemMatematicaNumerosDTO> dadosSondagem)
        {
            try
            {
                var businessSondagemMatematica = new Data.Business.SondagemMatematica(_config);
                await businessSondagemMatematica.InsertPoolNumeros(dadosSondagem);

                return (Ok());
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        #endregion

        #endregion
    }
}