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
                if (filtros.ProficienciaId == ProficienciaEnum.CampoAditivo || filtros.ProficienciaId == ProficienciaEnum.CampoMultiplicativo || filtros.ProficienciaId == ProficienciaEnum.Numeros)
                {
                    tipoRelatorio = TipoRelatorio.RelatorioMatetimaticaPorTurma;
                }
                else  if (filtros.TurmaCodigo <= 0)
                {
                    tipoRelatorio = TipoRelatorio.RelatorioMatetimaticaConsolidado;
                }
            }

            await mediator.Send(new GerarRelatorioCommand(tipoRelatorio.Value, filtros, filtros.UsuarioRF));
        }
        public async Task<string> ExecutarSync(RelatorioImpressaoFiltroDto filtros)
        {
            Thread.Sleep(5000);

            if (filtros.AnoLetivo == 6969)
                throw new Exception("Algum erro interno aconteceu. ");

            if (filtros.AnoLetivo == 69)
                throw new NegocioException("Algum erro de negócio aconteceu. ");

            return await Task.FromResult("https://dev-sr-relatorios.sme.prefeitura.sp.gov.br/api/v1/downloads/sgp/pdf/relatorio-teste-123.pdf/091ac4cd-38ff-46f0-8320-8c037a3a3d97");
        }
    }
}
