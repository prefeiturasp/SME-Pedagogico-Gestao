using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterTokenUsuarioLogadoQueryHandler : IRequestHandler<ObterTokenUsuarioLogadoQuery, string>
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public ObterTokenUsuarioLogadoQueryHandler(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException("");
        }
        public async Task<string> Handle(ObterTokenUsuarioLogadoQuery request, CancellationToken cancellationToken)
        {
            httpContextAccessor.HttpContext?.Request?.Headers?.TryGetValue("token", out var strToken);
            return strToken;
        }
    }
}
