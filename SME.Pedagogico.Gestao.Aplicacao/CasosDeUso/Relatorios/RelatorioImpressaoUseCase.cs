using MediatR;
using SME.Pedagogico.Gestao.Dominio;
using SME.Pedagogico.Gestao.Infra;
using System;
using System.Threading;
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
                if (filtros.TurmaCodigo > 0 && (filtros.ProficienciaId == ProficienciaEnum.CampoAditivo || filtros.ProficienciaId == ProficienciaEnum.CampoMultiplicativo || filtros.ProficienciaId == ProficienciaEnum.Numeros))
                {
                    tipoRelatorio = TipoRelatorio.RelatorioMatetimaticaPorTurma;
                }
                else  if (filtros.TurmaCodigo <= 0)
                {
                    if (filtros.ProficienciaId == ProficienciaEnum.CampoAditivo || filtros.ProficienciaId == ProficienciaEnum.CampoMultiplicativo)
                        tipoRelatorio = TipoRelatorio.RelatorioMatetimaticaConsolidadoAditMult;
                    else
                        tipoRelatorio = TipoRelatorio.RelatorioMatetimaticaConsolidado;
                }
            }

            await mediator.Send(new GerarRelatorioCommand(tipoRelatorio.Value, filtros, filtros.UsuarioRF));
        }
        public async Task<string> ExecutarSync(RelatorioImpressaoFiltroDto filtros)
        {
            TipoRelatorio? tipoRelatorio = null;

            if (filtros.ComponenteCurricularId == ComponenteCurricularEnum.Matematica)
            {
                if (filtros.TurmaCodigo > 0)
                {
                    tipoRelatorio = TipoRelatorio.RelatorioMatetimaticaPorTurma;
                }
                else if (filtros.TurmaCodigo <= 0)
                {
                    if (filtros.ProficienciaId == ProficienciaEnum.CampoAditivo || filtros.ProficienciaId == ProficienciaEnum.CampoMultiplicativo)
                        tipoRelatorio = TipoRelatorio.RelatorioMatetimaticaConsolidadoAditMult;
                    else
                        tipoRelatorio = TipoRelatorio.RelatorioMatetimaticaConsolidado;
                }
            }

            return (await mediator.Send(new ObterRelatorioSincronoQuery(tipoRelatorio.Value, filtros, filtros.UsuarioRF)));
        }
    }
}
