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
    public class ObterPerfilUsuarioLogadoQueryHandler : IRequestHandler<ObterPerfilUsuarioLogadoQuery, string>
    {
        private readonly IMediator mediator;
        public ObterPerfilUsuarioLogadoQueryHandler(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<string> Handle(ObterPerfilUsuarioLogadoQuery request, CancellationToken cancellationToken)
        {
           
           var token = await mediator.Send(new ObterObterTokenUsuarioLogadoQuery());

            return ObterPerfilDoToken(token).ToString();
        }
        private Guid ObterPerfilDoToken(string token)
    => Guid.Parse(ObterClaims(token)
        .FirstOrDefault(claim => claim.Type == "perfil")?.Value
        ?? string.Empty);

        private IEnumerable<Claim> ObterClaims(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadToken(token) as JwtSecurityToken;

            return tokenS.Claims;
        }
    }
}
