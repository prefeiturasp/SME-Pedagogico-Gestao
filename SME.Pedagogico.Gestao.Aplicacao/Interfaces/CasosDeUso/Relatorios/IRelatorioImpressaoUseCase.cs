using SME.Pedagogico.Gestao.Infra;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public interface IRelatorioImpressaoUseCase
    {
        Task Executar(RelatorioImpressaoFiltroDto filtros);
    }
}
