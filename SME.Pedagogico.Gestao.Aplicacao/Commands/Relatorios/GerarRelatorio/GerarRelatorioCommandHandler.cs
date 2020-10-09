using MediatR;
using SME.Pedagogico.Gestao.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Aplicacao.Commands.Relatorios.GerarRelatorio
{
    public class GerarRelatorioCommandHandler : IRequestHandler<GerarRelatorioCommand, bool>
    {
        private readonly IMediator mediator;

        public GerarRelatorioCommandHandler(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(GerarRelatorioCommand request, CancellationToken cancellationToken)
        {
            var codigoCorrelacao = await mediator.Send(new ObterCodigoCorrelacaoQuery(request.TipoRelatorio, request.UsuarioLogadoRf));

            return await mediator.Send(new InserirFilaRabbitCommand(new PublicaFilaRelatoriosDto(RotasRabbit.WorkerRelatoriosSgp, RotasRabbit.ExchangeServidorRelatorios, request.Filtros,  request.TipoRelatorio.Name(), codigoCorrelacao, request.UsuarioLogadoRf)));
        }
    }
}
