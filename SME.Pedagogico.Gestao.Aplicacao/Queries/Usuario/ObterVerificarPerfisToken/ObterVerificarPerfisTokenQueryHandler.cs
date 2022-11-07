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
            var loginRF = await mediator.Send(new ObterLoginUsuarioLogadoQuery());

            var perfisPermissoesTokenDataExpiracao = await mediator.Send(new ObterPerfisPermissoesTokenDataExpiracaoUsuariosSondagemPorLoginQuery(loginRF));

            var listaPerfis = new PerfisMenusAutenticacaoDto(perfisPermissoesTokenDataExpiracao.PerfisUsuario.Perfis.ToList(),perfisPermissoesTokenDataExpiracao.Permissoes.ToList());

            if (perfisPermissoesTokenDataExpiracao.PerfisUsuario.Perfis.Any())
            {
                var retornoTokenPerfilUnico = await mediator.Send(new AtualizarPerfilCommand(perfisPermissoesTokenDataExpiracao.PerfisUsuario.Perfis.FirstOrDefault().CodigoPerfil.ToString()));
                listaPerfis.Token = retornoTokenPerfilUnico.Token;
            }
            
            return listaPerfis;
        }
    }
}
