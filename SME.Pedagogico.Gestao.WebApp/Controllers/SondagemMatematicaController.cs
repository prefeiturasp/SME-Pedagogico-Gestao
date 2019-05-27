using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SME.Pedagogico.Gestao.Data.Contexts;
using SME.Pedagogico.Gestao.Data.DTO;
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

        #endregion

        #region ==================== CONSTRUCTORS ====================

        /// <summary>
        /// Construtor padrão para o SondagemMatematicaController, faz injeção de dependências SMEManagementContext.
        /// </summary>
        /// <param name="db">Depêndencia de dataContext (SMEManagementContext)</param>
        public SondagemMatematicaController(SMEManagementContext db)
        {
            _db = db;
        }

        #endregion

        #region ==================== METHODS ====================

        #region -------------------- PRIVATE --------------------
        #endregion

        #region -------------------- PUBLIC --------------------

        /// <summary>
        /// Método para fazer a sondagem de matemática por ordem.
        /// </summary>
        /// <param name="dadosSondagem">Objeto que contém informações da sondagem de matemática</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> SondagemMatematicaOrdem([FromBody]SondagemMatematicaOrdemDTO dadosSondagem)
        {
            return default;
        }

        #endregion

        #endregion
    }
}