using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace SME.Pedagogico.Gestao.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class VariaveisController : ControllerBase
    {
        [HttpGet]
        [Route("Url-Front-Sgp")]
        public string ObterUrlFrontSGP([FromServices]IConfiguration configuration)
        {
            return configuration.GetValue<string>("urlFrontSgp");
        }
    }
}
