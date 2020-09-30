using SME.Pedagogico.Gestao.Infra.Dtos.Relatorios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Aplicacao.Interfaces.CasosDeUso.ExemploGames
{
    public interface IGamesUseCase
    {
        Task<bool> Executar(FiltroRelatorioGamesDto filtroRelatorioGamesDto);
    }
}
