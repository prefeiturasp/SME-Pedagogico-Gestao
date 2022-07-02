using MediatR;
using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.Business;
using SME.Pedagogico.Gestao.Infra;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ExcluirSondagemMatematica2022ComDivergenciasCommandHandler : AsyncRequestHandler<ExcluirSondagemMatematica2022ComDivergenciasCommand>
    {
        private SondagemAutoralBusiness sondagemAutoralBusiness;

        public ExcluirSondagemMatematica2022ComDivergenciasCommandHandler(IServicoTelemetria servicoTelemetria)
        {
            sondagemAutoralBusiness = new SondagemAutoralBusiness(servicoTelemetria);
        }

        protected override async Task Handle(ExcluirSondagemMatematica2022ComDivergenciasCommand request, CancellationToken cancellationToken)
        {
            var divergencias = await sondagemAutoralBusiness.ObterRespostasDivergentesPorDre(request.DreCodigo);

            foreach(var divergencia in divergencias)
            {
                var respostas = await sondagemAutoralBusiness.ObterRespostasDivergentesPorPergunta(divergencia.CodigoTurma, divergencia.CodigoAluno, divergencia.PerguntaId);

                var ultimaResposta = respostas
                    .OrderByDescending(x => x.HoraGuid)
                    .FirstOrDefault();

                await sondagemAutoralBusiness.ExcluirRespostasDivergentes(divergencia.SondagemAlunoId, ultimaResposta.RespostaId);
            };
        }
    }
}
