using MediatR;
using SME.Pedagogico.Gestao.Dominio;
using SME.Pedagogico.Gestao.Infra;
using System;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class GamesUseCase : IGamesUseCase
    {
        private readonly IMediator mediator;

        public GamesUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<bool> Executar(FiltroRelatorioGamesDto filtroRelatorioGamesDto)
        {
            var retorno = await mediator.Send(new GerarRelatorioCommand(TipoRelatorio.RelatorioExemplo, filtroRelatorioGamesDto, filtroRelatorioGamesDto.UsuarioRf));
            return retorno;
        }
    }
}
