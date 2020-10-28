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
            TipoRelatorio? tipoRelatorio = GetTipoRelatorio(filtros);

            await mediator.Send(new GerarRelatorioCommand(tipoRelatorio.Value, filtros, filtros.UsuarioRF));
        }
        public async Task<string> ExecutarSync(RelatorioImpressaoFiltroDto filtros)
        {
            TipoRelatorio? tipoRelatorio = GetTipoRelatorio(filtros);

            return (await mediator.Send(new ObterRelatorioSincronoQuery(tipoRelatorio.Value, filtros, filtros.UsuarioRF)));
        }

        private TipoRelatorio? GetTipoRelatorio(RelatorioImpressaoFiltroDto filtros)
        {
            TipoRelatorio? tipoRelatorio = null;

            if (filtros.ComponenteCurricularId == ComponenteCurricularEnum.Matematica)
            {
                if (filtros.TurmaCodigo > 0 && (filtros.ProficienciaId == ProficienciaEnum.CampoAditivo || filtros.ProficienciaId == ProficienciaEnum.CampoMultiplicativo || filtros.ProficienciaId == ProficienciaEnum.Numeros))
                {
                    tipoRelatorio = TipoRelatorio.RelatorioMatematicaPorTurma;
                }
                else if (filtros.TurmaCodigo <= 0)
                {
                    if (filtros.ProficienciaId == ProficienciaEnum.CampoAditivo || filtros.ProficienciaId == ProficienciaEnum.CampoMultiplicativo)
                    {
                        tipoRelatorio = TipoRelatorio.RelatorioMatematicaConsolidadoAdtMult;
                    }
                    else tipoRelatorio = TipoRelatorio.RelatorioMatematicaConsolidado;
                }
            }

            if (filtros.ComponenteCurricularId == ComponenteCurricularEnum.Portugues)
            {
                if (filtros.TurmaCodigo > 0)
                {
                    if (!string.IsNullOrEmpty(filtros.Ano) && int.Parse(filtros.Ano) > 4 && filtros.GrupoId.Equals("e27b99a3-789d-43fb-a962-7df8793622b1"))
                        tipoRelatorio = TipoRelatorio.RelatorioPortuguesCapLeituraPorTurma;
                    else
                        tipoRelatorio = TipoRelatorio.RelatorioPortuguesPorTurma;
                }
                else if (filtros.TurmaCodigo <= 0 && filtros.ProficienciaId == ProficienciaEnum.Autoral)
                {
                    tipoRelatorio = TipoRelatorio.RelatorioPortuguesConsolidado;
                }
            }

            return tipoRelatorio;
        }
    }
}
