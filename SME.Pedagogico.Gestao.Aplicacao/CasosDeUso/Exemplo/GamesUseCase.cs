using MediatR;
using SME.Pedagogico.Gestao.Aplicacao.Commands.Relatorios.NewFolder;
using SME.Pedagogico.Gestao.Aplicacao.Interfaces.CasosDeUso.ExemploGames;
using SME.Pedagogico.Gestao.Aplicacao.Queries.Usuario.ObterUsuarioLogado;
using SME.Pedagogico.Gestao.Dominio.Enumerados;
using SME.Pedagogico.Gestao.Infra.Dtos.Relatorios;
using SME.Pedagogico.Gestao.Models.Enums;
using System;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Aplicacao.CasosDeUso.Exemplo
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
            var usuarioLogado = await mediator.Send(new ObterUsuarioLogadoQuery());
            var retorno = await mediator.Send(new GerarRelatorioCommand(TipoRelatorio.RelatorioExemplo, filtroRelatorioGamesDto, usuarioLogado));
            return retorno;
        }
    }
}
