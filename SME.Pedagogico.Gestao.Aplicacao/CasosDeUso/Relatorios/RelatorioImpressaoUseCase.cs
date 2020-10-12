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

            if (filtros.ComponenteCurricularId == ComponenteCurricularEnum.Matematica)
            {
                if (filtros.ProficienciaId == ProficienciaEnum.CampoAditivo || filtros.ProficienciaId == ProficienciaEnum.CampoMultiplicativo)
                {
                    await mediator.Send(new GerarRelatorioCommand(TipoRelatorio.RelatorioMatetimaticaPorTurma, filtros, filtros.UsuarioRF));
                }
            }


        }
    }
}
