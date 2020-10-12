using SME.Pedagogico.Gestao.Infra;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public interface IGamesUseCase
    {
        Task<bool> Executar(FiltroRelatorioGamesDto filtroRelatorioGamesDto);
    }
}
