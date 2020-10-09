using MediatR;
using SME.Pedagogico.Gestao.Infra;
using System;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class RelatorioImpressaoUseCase : IRelatorioImpressaoUseCase
    {
        private readonly IMediator mediator;

        public RelatorioImpressaoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task Executar(RelatorioImpressaoFiltroDto filtros)
        {
            TipoRelatorio? tipoRelatorio = null;

            if (filtros.ComponenteCurricularId == ComponenteCurricularEnum.Matematica)
            {
                if (filtros.ProficienciaId == ProficienciaEnum.CampoAditivo || filtros.ProficienciaId == ProficienciaEnum.CampoMultiplicativo)
                {
                    tipoRelatorio = TipoRelatorio.RelatorioMatetimaticaPorTurma;
                }
                else  if (filtros.TurmaCodigo <= 0 && filtros.ProficienciaId == ProficienciaEnum.Numeros)
                {
                    tipoRelatorio = TipoRelatorio.RelatorioMatetimaticaConsolidado;
                }
            }

            await mediator.Send(new GerarRelatorioCommand(tipoRelatorio.Value, filtros, filtros.UsuarioRF));
        }
    }
}
