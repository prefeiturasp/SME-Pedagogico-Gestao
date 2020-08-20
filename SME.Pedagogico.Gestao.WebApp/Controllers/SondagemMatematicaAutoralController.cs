using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SME.Pedagogico.Gestao.Data.Business;

namespace SME.Pedagogico.Gestao.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SondagemMatematicaAutoralController : ControllerBase
    {
        public IActionResult Teste()
        {
            return Ok(SondagemAutoralBusiness.ObterPerguntas(7));
        }
    }
}