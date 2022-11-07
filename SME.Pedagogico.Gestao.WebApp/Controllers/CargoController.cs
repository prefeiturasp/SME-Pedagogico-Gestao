//CargoController
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.Business;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Data.Functionalities;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.DTO;
using SME.Pedagogico.Gestao.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SME.Pedagogico.Gestao.Aplicacao;

namespace SME.Pedagogico.Gestao.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        public IConfiguration _config;
        private readonly IMediator mediator;

        public CargoController(IConfiguration config, IMediator mediator)
        {
            _config = config;
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<ActionResult> CargosPorRF(string login)
        {
            try
            {
                var profileBusiness = new Profile(_config);
                var funcionarioDTO = profileBusiness.GetOccupationsRF(login);

                if (funcionarioDTO != null)
                    return (Ok(funcionarioDTO));
                    
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
       }


        [HttpPost]
        public async Task<ActionResult> PerfilServidor(BuscaPerfilServidor occupationsProfile)
        {
            try
            {
                string codigoRF = occupationsProfile.codigoRF;
                string codigoCargo = occupationsProfile.codigoCargo;
                string anoLetivo = occupationsProfile.anoLetivo;

                var profileBusiness = new Profile(_config);

                var perfisPermissoesTokenDataExpiracao = await mediator.Send(new ObterPerfisPermissoesTokenDataExpiracaoUsuariosSondagemPorLoginQuery(codigoRF));
                
                var roleName = perfisPermissoesTokenDataExpiracao.PerfisUsuario.Perfis.SingleOrDefault(p => p.CodigoPerfil.Equals(occupationsProfile.activeRole?.PerfilId))?.NomePerfil;

                var profileInformation = await profileBusiness
                    .GetProfileEmployeeInformation(codigoRF, codigoCargo, anoLetivo, occupationsProfile.activeRole?.PerfilId, roleName);

                if (profileInformation != null)
                    return (Ok(profileInformation));
                
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> RetornaCodigoDREAdm([FromBody]string userName)
        {
            try
            {
                var profileBusiness = new Profile(_config);
                var dre = await profileBusiness.GetCodeDreAdm(userName);
                if (dre != null)
                    return (Ok(dre));
             
                return (NoContent());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
