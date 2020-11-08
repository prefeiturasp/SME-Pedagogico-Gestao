using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterLoginUsuarioLogadoQueryHandler : IRequestHandler<ObterLoginUsuarioLogado, string>
    {
        private readonly IMediator mediator;
        public ObterLoginUsuarioLogadoQueryHandler(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<string> Handle(ObterLoginUsuarioLogado request, CancellationToken cancellationToken)
        {
           
           var token = await mediator.Send(new ObterTokenUsuarioLogadoQuery());

            return ObterLoginDoToken(token).ToString();
        }
        private string ObterLoginDoToken(string token)
            =>  ObterClaims(token).FirstOrDefault(claim => claim.Type == "login")?.Value ?? string.Empty;

        private IEnumerable<Claim> ObterClaims(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadToken(token) as JwtSecurityToken;

            return tokenS.Claims;
        }
    }
}
