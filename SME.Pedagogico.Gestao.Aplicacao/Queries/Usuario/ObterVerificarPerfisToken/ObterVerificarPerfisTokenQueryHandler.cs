using MediatR;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoNovoSGP;
using SME.Pedagogico.Gestao.Infra;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterVerificarPerfisTokenQueryHandler : IRequestHandler<ObterVerificarPerfisTokenQuery, PerfisMenusAutenticacaoDto>
    {
        private readonly IMediator mediator;
        public ObterVerificarPerfisTokenQueryHandler(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<PerfisMenusAutenticacaoDto> Handle(ObterVerificarPerfisTokenQuery request, CancellationToken cancellationToken)
        {
            var loginRF = await mediator.Send(new ObterLoginUsuarioLogado());

            return (await mediator.Send(new ObterVerificarPerfisDoUsuarioLoginQuery(loginRF, request.Perfis)));

        }
    }
}
