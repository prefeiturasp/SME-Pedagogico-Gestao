using MediatR;
using SME.Pedagogico.Gestao.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterCodigoCorrelacaoQueryHandler : IRequestHandler<ObterCodigoCorrelacaoQuery, Guid>
    {
        private readonly IMediator mediator;

        public ObterCodigoCorrelacaoQueryHandler(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<Guid> Handle(ObterCodigoCorrelacaoQuery request, CancellationToken cancellationToken)
        {
            var guidRelatorio = Guid.NewGuid();
            var mensagem = new MensagemInserirCodigoCorrelacaoDto(request.TipoRelatorio);

            await mediator.Send(new InserirFilaRabbitCommand(new PublicaFilaRelatoriosDto(RotasRabbit.FilaSgp, RotasRabbit.ExchangeSgp, mensagem, RotasRabbit.RotaRelatorioCorrelacaoInserir, guidRelatorio, request.UsuarioRf)));

            return guidRelatorio;
        }
    }
}
