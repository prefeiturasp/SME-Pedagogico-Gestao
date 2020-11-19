using MediatR;
using SME.Pedagogico.Gestao.Infra;
using System;
using System.Linq;
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

            var listaPerfis = await mediator.Send(new ObterVerificarPerfisDoUsuarioLoginQuery(loginRF, request.Perfis));

            if (listaPerfis.Perfis.Any())
            {
                var retornoTokenPerfilUnico = await mediator.Send(new AtualizarPerfilCommand(listaPerfis.Perfis.FirstOrDefault().CodigoPerfil.ToString()));
                listaPerfis.Token = retornoTokenPerfilUnico.Token;
            }

            return listaPerfis;

        }
    }
}
