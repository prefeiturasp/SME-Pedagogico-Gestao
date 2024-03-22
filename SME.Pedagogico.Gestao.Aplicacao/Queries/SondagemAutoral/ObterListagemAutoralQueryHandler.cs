using MediatR;
using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Aplicacao.Queries.Periodos;
using SME.Pedagogico.Gestao.Data.Business;
using SME.Pedagogico.Gestao.Data.DTO.Matematica;
using SME.Pedagogico.Gestao.Data.Functionalities;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using SME.Pedagogico.Gestao.Infra;
using SME.Pedagogico.Gestao.Models.Autoral;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterListagemAutoralQueryHandler : IRequestHandler<ObterListagemAutoralQuery, IEnumerable<AlunoSondagemMatematicaDto>>
    {
        private string _token;
        private TurmasAPI TurmaApi;
        private readonly IMediator mediator;
        private readonly IServicoTelemetria servicoTelemetria;
        private SondagemAutoralBusiness sondagemAutoralBusiness;

        public ObterListagemAutoralQueryHandler(IConfiguration configuration, IMediator mediator, IServicoTelemetria servicoTelemetria)
        {
            var createToken = new CreateToken(configuration);
            _token = createToken.CreateTokenProvisorio();

            sondagemAutoralBusiness = new SondagemAutoralBusiness(servicoTelemetria);
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.servicoTelemetria = servicoTelemetria ?? throw new ArgumentNullException(nameof(servicoTelemetria));
            TurmaApi = new TurmasAPI(new EndpointsAPI());
        }

        public async Task<IEnumerable<AlunoSondagemMatematicaDto>> Handle(ObterListagemAutoralQuery request, CancellationToken cancellationToken)
        {
            var filtrarListagemDto = request.FiltrarListagemDto;

            var listaSondagem = Enumerable.Empty<Sondagem>();
            listaSondagem = filtrarListagemDto.AnoLetivo >= 2022 ?
                await ObterSondagemAutoralMatematicaBimestre(filtrarListagemDto) :
                await ObterSondagemAutoralMatematica(filtrarListagemDto);

            var periodoSondagemSelecionado = await mediator.Send(new ObterPeriodoFixoAnualPorTipoAnoLetivoEBimestreQuery(filtrarListagemDto.AnoLetivo, filtrarListagemDto.Bimestre.Value, filtrarListagemDto.AnoLetivo >= 2022 ? TipoPeriodoEnum.Semestre : TipoPeriodoEnum.Bimestre));

            var listaAlunos = await TurmaApi.GetAlunosNaTurma(Convert.ToInt32(filtrarListagemDto.CodigoTurma), _token);

            var alunos = listaAlunos.Where(x => !x.AlunoInativo && (x.CodigoSituacaoMatricula == 10 || x.CodigoSituacaoMatricula == 1 || x.CodigoSituacaoMatricula == 6 || x.CodigoSituacaoMatricula == 13 || x.CodigoSituacaoMatricula == 5) ||
                x.AlunoInativo && periodoSondagemSelecionado != null && ((x.DataSituacao > periodoSondagemSelecionado?.DataInicio.Date && x.DataSituacao <= periodoSondagemSelecionado?.DataFim.Date) || x.DataSituacao > periodoSondagemSelecionado?.DataFim.Date)).ToList();

            if (alunos == null || !alunos.Any())
                throw new Exception($"Não encontrado alunos para a turma {filtrarListagemDto.CodigoTurma} do ano letivo {filtrarListagemDto.AnoLetivo}");

            var listagem = new List<AlunoSondagemMatematicaDto>();

            if (listaSondagem.Count() > 0)
                MapearAlunosListagemMatematica(listagem, listaSondagem, filtrarListagemDto.Bimestre);

            AdicionarAlunosEOL(filtrarListagemDto, alunos, listagem);

            return listagem.OrderBy(x => x.NumeroChamada).ThenBy(x => x.NomeAluno);
        }

        private Task RegistrarTempos(TimeSpan tempoQuery, TimeSpan tempoEOL, TimeSpan tempoFiltro, TimeSpan tempoMapeamento, TimeSpan tempoTotal)
        {
            var mensagem = $"Tempos Carga Sondagem Matematica : Query [{FormataTempo(tempoQuery)}] EOL [{FormataTempo(tempoEOL.Subtract(tempoQuery))}] Filtro [{FormataTempo(tempoFiltro.Subtract(tempoEOL))}] Mapeamento [{FormataTempo(tempoMapeamento.Subtract(tempoFiltro))}] - Total [{FormataTempo(tempoTotal)}]";

            return mediator.Send(new SalvarLogViaRabbitCommand(mensagem, Dominio.LogNivel.Informacao, Dominio.LogContexto.Geral, ""));
        }

        private string FormataTempo(TimeSpan tempo)
            => tempo.ToString(@"ss\:fff");

        private async Task<IEnumerable<Sondagem>> ObterSondagemAutoralMatematica(FiltrarListagemMatematicaDTO filtrarListagemDto)
            => await servicoTelemetria.RegistrarComRetornoAsync<List<Sondagem>>(async () =>
            await SondagemAutoralBusiness.ObterSondagemAutoralMatematica(filtrarListagemDto), "consulta", "Consulta Sondagem Semestral", "");

        private async Task<IEnumerable<Sondagem>> ObterSondagemAutoralMatematicaBimestre(FiltrarListagemMatematicaDTO filtrarListagemDto)
            => await servicoTelemetria.RegistrarComRetornoAsync<List<Sondagem>>(async () =>
            await sondagemAutoralBusiness.ObterSondagemAutoralMatematicaBimestre(filtrarListagemDto), "consulta", "Consulta Sondagem Bimestral", "");

        private void MapearAlunosListagemMatematica(List<AlunoSondagemMatematicaDto> listagem, IEnumerable<Sondagem> listaSondagem, int? bimestre)
        {
            var listaAlunosDto = new List<AlunoSondagemMatematicaDto>();
            var listCodigoAlunoEol = new List<string>();
            foreach(var sondagem in listaSondagem)
            {
                sondagem.AlunosSondagem.ForEach(a =>
                {
                    var alunoDto = new AlunoSondagemMatematicaDto();

                    alunoDto.Id = a.Id != null ? a.Id.ToString() : null;
                    alunoDto.AnoLetivo = sondagem.AnoLetivo;
                    alunoDto.AnoTurma = sondagem.AnoTurma;
                    alunoDto.CodigoAluno = a.CodigoAluno;
                    alunoDto.NomeAluno = a.NomeAluno;
                    alunoDto.ComponenteCurricular = sondagem.ComponenteCurricularId.ToString();
                    alunoDto.CodigoUe = sondagem.CodigoUe;
                    alunoDto.CodigoDre = sondagem.CodigoDre;
                    alunoDto.Bimestre = bimestre;
                    alunoDto.CodigoTurma = sondagem.CodigoTurma;
                    alunoDto.Respostas = new List<AlunoRespostaDto>();
                    a.ListaRespostas.Where(x => x.Bimestre == bimestre).ToList().ForEach(r =>
                    {
                        var Resposta = new AlunoRespostaDto()
                        {
                            Resposta = r.RespostaId,
                            Pergunta = r.PerguntaId,
                            PeriodoId = sondagem.PeriodoId,
                            Bimestre = r.Bimestre
                        };

                        alunoDto.Respostas.Add(Resposta);
                    });

                    if (alunoDto.Respostas.Count() > 0)
                    {
                        listaAlunosDto.Add(alunoDto);
                        listCodigoAlunoEol.Add(a.CodigoAluno);
                    }
                });
            };

            foreach (var codigoAluno in listCodigoAlunoEol.Distinct())
            {
                var listaResposta = new List<AlunoRespostaDto>();
                var alunoDto = listaAlunosDto.Where(a => a.CodigoAluno == codigoAluno).FirstOrDefault();
                //var listaAlunoResposta = listaAlunosDto.Where(a => a.CodigoAluno == codigoAluno && (a.Bimestre.HasValue ? a.Bimestre.Value : 0) == bimestre).ToList();
                var listaAlunoResposta = listaAlunosDto.Where(a => a.CodigoAluno == codigoAluno && a.Bimestre == bimestre).ToList();
                listaAlunoResposta.ForEach(lr =>
                {
                    lr.Respostas.ForEach(r =>
                    {
                        listaResposta.Add(r);
                    });
                });
                alunoDto.Respostas = listaResposta;

                if (alunoDto != null)
                    listagem.Add(alunoDto);
            }
        }

        private void AdicionarAlunosEOL(FiltrarListagemMatematicaDTO filtrarListagemDto, List<AlunosNaTurmaDTO> alunos, List<AlunoSondagemMatematicaDto> listagem)
        {
            alunos.ForEach(aluno =>
            {
                var alunoBanco = listagem.FirstOrDefault(x => x.CodigoAluno.Equals(aluno.CodigoAluno.ToString()));
                if (alunoBanco != null)
                {
                    alunoBanco.NumeroChamada = aluno.NumeroAlunoChamada;
                    return;
                }

                listagem.Add(new AlunoSondagemMatematicaDto
                {
                    CodigoAluno = aluno.CodigoAluno.ToString(),
                    AnoLetivo = filtrarListagemDto.AnoLetivo,
                    AnoTurma = filtrarListagemDto.AnoEscolar,
                    CodigoDre = filtrarListagemDto.CodigoDre,
                    CodigoTurma = filtrarListagemDto.CodigoTurma,
                    CodigoUe = filtrarListagemDto.CodigoUe,
                    NumeroChamada = aluno.NumeroAlunoChamada,
                    ComponenteCurricular = filtrarListagemDto.ComponenteCurricular.ToString(),
                    NomeAluno = string.IsNullOrEmpty(aluno.NomeSocialAluno) ? aluno.NomeAluno : aluno.NomeSocialAluno,
                    Bimestre = filtrarListagemDto.Bimestre
                });

                listagem.OrderBy(x => x.NumeroChamada);
            });
        }

    }
}
