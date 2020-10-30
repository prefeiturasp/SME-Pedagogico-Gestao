using System;
using Dapper;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using SME.Pedagogico.Gestao.Data.DTO.Matematica.Relatorio;
using SME.Pedagogico.Gestao.Data.Contexts;
using System.Threading.Tasks;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using SME.Pedagogico.Gestao.Data.Relatorios;
using SME.Pedagogico.Gestao.Data.Relatorios.Querys;
using SME.Pedagogico.Gestao.Data.DTO.Matematica;
using Microsoft.EntityFrameworkCore;
using SME.Pedagogico.Gestao.Models.Autoral;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Data.DTO.RelatorioPorTurma;

namespace SME.Pedagogico.Gestao.Data.Business
{
    public class RelatorioMatematicaAutoral
    {
        public async Task<RelatorioConsolidadoDTO> ObterRelatorioMatematicaAutoral(filtrosRelatorioDTO filtro)
        {
            IncluiIdDoComponenteCurricularEhDoPeriodoNoFiltro(filtro);
            int totalDeAlunos = await ConsultaTotalDeAlunos.BuscaTotalDeAlunosEOl(filtro);
            var query = ConsultasRelatorios.QueryRelatorioMatematicaAutoral(filtro);
            var relatorio = new RelatorioConsolidadoDTO();

            using (var conexao = new NpgsqlConnection(Environment.GetEnvironmentVariable("sondagemConnection")))
            {
                relatorio.Perguntas = await RetornaRelatorioMatematica(filtro, conexao, query, totalDeAlunos);
            }

            relatorio.Graficos = new List<GraficosRelatorioDTO>();


            foreach (var pergunta in relatorio.Perguntas)
            {
                var grafico = new GraficosRelatorioDTO();
                grafico.nomeGrafico = pergunta.Nome;
                grafico.Barras = new List<BarrasGraficoDTO>();
                pergunta.Respostas.ForEach(resposta =>
                {
                    var barra = new BarrasGraficoDTO();
                    barra.label = resposta.Nome;
                    barra.value = resposta.quantidade;
                    grafico.Barras.Add(barra);
                });

                relatorio.Graficos.Add(grafico);
            }
            return relatorio;
        }

        private async Task<List<PerguntaDTO>> RetornaRelatorioMatematica(filtrosRelatorioDTO filtro, NpgsqlConnection conexao, string query, int totalDeAlunos)
        {
            var ListaPerguntaEhRespostasRelatorio = await conexao.QueryAsync<PerguntasRespostasDTO>(query.ToString(),
                new
                {
                    AnoDaTurma = filtro.AnoEscolar,
                    CodigoEscola = filtro.CodigoUe,
                    CodigoDRE = filtro.CodigoDre,
                    AnoLetivo = filtro.AnoLetivo,
                    PeriodoId = filtro.PeriodoId,
                    ComponenteCurricularId = filtro.ComponenteCurricularId

                });

            var relatorioAgrupado = ListaPerguntaEhRespostasRelatorio.GroupBy(p => p.PerguntaId).ToList();

            var lista = new List<PerguntaDTO>();

            relatorioAgrupado.ForEach(x =>
            {
                var pergunta = new PerguntaDTO();
                CalculaPercentualTotalPergunta(totalDeAlunos, x, pergunta);

                var listaPr = x.Where(y => y.PerguntaId == x.Key).ToList();
                var totalRespostas = x.Where(y => y.PerguntaId == x.Key).Sum(q => q.QtdRespostas);
                CalculaPercentualRespostas(totalDeAlunos, pergunta, listaPr, totalRespostas);
                lista.Add(pergunta);
            });


            return lista;
        }

        private static void CalculaPercentualTotalPergunta(int totalDeAlunos, IGrouping<string, PerguntasRespostasDTO> x, PerguntaDTO pergunta)
        {
            pergunta.Nome = x.Where(y => y.PerguntaId == x.Key).First().PerguntaDescricao;
            pergunta.Total = new TotalDTO()
            {
                Quantidade = totalDeAlunos
            };

            pergunta.Total.Porcentagem = (pergunta.Total.Quantidade > 0 ? (pergunta.Total.Quantidade * 100) / (Double)totalDeAlunos : 0).ToString("0.00");
            pergunta.Respostas = new List<RespostaDTO>();
        }

        private void CalculaPercentualRespostas(int totalDeAlunos, PerguntaDTO pergunta, List<PerguntasRespostasDTO> listaPr, int totalRespostas)
        {
            foreach (var item in listaPr)
            {
                var resposta = new RespostaDTO();
                resposta.Nome = item.RespostaDescricao;
                resposta.quantidade = item.QtdRespostas;
                resposta.porcentagem = (item.QtdRespostas > 0 ? (item.QtdRespostas * 100) / (Double)totalDeAlunos : 0).ToString("0.00");
                pergunta.Respostas.Add(resposta);
            }

            var respostaSempreenchimento = CriaRespostaSemPreenchimento(totalDeAlunos, totalRespostas);
            pergunta.Respostas.Add(respostaSempreenchimento);

        }

        private RespostaDTO CriaRespostaSemPreenchimento(int totalDeAlunos, int quantidadeTotalRespostasPergunta)
        {
            var respostaSemPreenchimento = new RespostaDTO();
            respostaSemPreenchimento.Nome = "Sem preenchimento";
            respostaSemPreenchimento.quantidade = totalDeAlunos - quantidadeTotalRespostasPergunta;
            respostaSemPreenchimento.porcentagem = (respostaSemPreenchimento.quantidade > 0 ? (respostaSemPreenchimento.quantidade * 100) / (Double)totalDeAlunos : 0).ToString("0.00");
            respostaSemPreenchimento.porcentagem = respostaSemPreenchimento.porcentagem;
            return respostaSemPreenchimento;
        }

        private static void IncluiIdDoComponenteCurricularEhDoPeriodoNoFiltro(filtrosRelatorioDTO filtro)
        {
            using (var contexto = new SMEManagementContextData())
            {

                var componenteCurricular = contexto.ComponenteCurricular.Where(x => x.Descricao == filtro.DescricaoDisciplina).FirstOrDefault();

                filtro.ComponenteCurricularId = componenteCurricular.Id;
                var periodo = contexto.Periodo.Where(x => x.Descricao == filtro.DescricaoPeriodo).FirstOrDefault();
                filtro.PeriodoId = periodo.Id;
            }
        }

        public async Task<RelatorioMatematicaPorTurmaDTO> ObterRelatorioPorTurma(filtrosRelatorioDTO filtro)
        {
            IncluiIdDoComponenteCurricularEhDoPeriodoNoFiltro(filtro);
            var periodos = await ConsultaTotalDeAlunos.BuscaDatasPeriodoFixoAnual(filtro);

            if (periodos.Count() == 0)
                throw new Exception("Periodo fixo anual nao encontrado");

            var endpoits = new EndpointsAPI();
            var alunoApi = new AlunosAPI(endpoits);
            var alunosEol = await alunoApi.ObterAlunosAtivosPorTurmaEPeriodo(filtro.CodigoTurmaEol, periodos.First().DataFim);
            var QueryAlunosRespostas = ConsultasRelatorios.QueryRelatorioPorTurmaMatematica();
            var listaAlunoRespostas = await RetornaListaRespostasAlunoPorTurma(filtro, QueryAlunosRespostas);
            var AlunosAgrupados = listaAlunoRespostas.GroupBy(x => x.CodigoAluno);
            var relatorio = new RelatorioMatematicaPorTurmaDTO();
            await RetornaPerguntasDoRelatorio(filtro, relatorio);

            var ListaAlunos = new List<AlunoPorTurmaRelatorioDTO>();
            alunosEol.ForEach(alunoRetorno =>
            {
                var aluno = new AlunoPorTurmaRelatorioDTO();
                aluno.CodigoAluno = alunoRetorno.CodigoAluno;
                aluno.NomeAluno = alunoRetorno.NomeAlunoRelatorio;
                aluno.Perguntas = new List<PerguntaRespostaPorAluno>();

                var alunoRespostas = AlunosAgrupados.Where(x => x.Key == aluno.CodigoAluno.ToString()).ToList();

                foreach (var perguntaBanco in relatorio.Perguntas)
                {
                    var pergunta = new PerguntaRespostaPorAluno()
                    {
                        Id = perguntaBanco.Id,
                        Valor = string.Empty
                    };

                    var respostaAluno = listaAlunoRespostas.Where(x => x.PerguntaId == perguntaBanco.Id && x.CodigoAluno == aluno.CodigoAluno.ToString()).FirstOrDefault();
                    if (respostaAluno != null)
                        pergunta.Valor = respostaAluno.RespostaDescricao;
                    aluno.Perguntas.Add(pergunta);
                }
                ListaAlunos.Add(aluno);
            });
            relatorio.Alunos = ListaAlunos.OrderBy(aluno => aluno.NomeAluno);
            relatorio.Graficos = new List<GraficosRelatorioDTO>();


            using (var contexto = new SMEManagementContextData())
            {
                var perguntasBanco = await contexto.PerguntaResposta.Include(x => x.Pergunta).Include(y => y.Resposta).Where(pr => relatorio.Perguntas.Any(p => p.Id == pr.Pergunta.Id)).ToListAsync();


                foreach (var pergunta in relatorio.Perguntas)
                {
                    var grafico = new GraficosRelatorioDTO();
                    grafico.nomeGrafico = pergunta.Nome;
                    grafico.Barras = new List<BarrasGraficoDTO>();
                    var listaRespostas = perguntasBanco.Where(x => x.Pergunta.Id == pergunta.Id).ToList();

                    listaRespostas.ForEach(resposta =>
                    {
                        var barra = new BarrasGraficoDTO();
                        barra.label = resposta.Resposta.Descricao;
                        barra.value = relatorio.Alunos.Count(x => x.Perguntas.Any(r => r.Id == pergunta.Id && r.Valor == resposta.Resposta.Descricao));
                        grafico.Barras.Add(barra);

                    });

                    var barraAlunosSemPreenchimento = new BarrasGraficoDTO();
                    barraAlunosSemPreenchimento.label = "Sem Preenchimento";
                    barraAlunosSemPreenchimento.value = relatorio.Alunos.Count() - grafico.Barras.Sum(x => x.value);
                    grafico.Barras.Add(barraAlunosSemPreenchimento);
                    relatorio.Graficos.Add(grafico);
                }
            }
            return relatorio;
        }

        private async Task RetornaPerguntasDoRelatorio(filtrosRelatorioDTO filtro, RelatorioMatematicaPorTurmaDTO relatorio)
        {
            relatorio.Perguntas = new List<PerguntasRelatorioDTO>();
            using (var contexto = new SMEManagementContextData())
            {
                var perguntasBanco = await contexto.PerguntaAnoEscolar.Include(x => x.Pergunta).Where(perguntaAnoEscolar => perguntaAnoEscolar.AnoEscolar == filtro.AnoEscolar).OrderBy(x => x.Ordenacao).Select(x => MapearPergunta(x)).ToListAsync();
                relatorio.Perguntas = perguntasBanco.Select(x => new PerguntasRelatorioDTO
                {
                    Id = x.Id,
                    Nome = x.Descricao

                }).ToList();
            }
        }

        private PerguntaDto MapearPergunta(PerguntaAnoEscolar perguntaAnoEscolar)
        {
            var retorno = (PerguntaDto)perguntaAnoEscolar.Pergunta;

            if (retorno == null)
                return default;

            retorno.Ordenacao = perguntaAnoEscolar.Ordenacao;

            return retorno;
        }

        private static async Task<IEnumerable<AlunoPerguntaRespostaDTO>> RetornaListaRespostasAlunoPorTurma(filtrosRelatorioDTO filtro, string QueryAlunosRespostas)
        {
            using (var conexao = new NpgsqlConnection(Environment.GetEnvironmentVariable("sondagemConnection")))
            {
                var listaAlunoRespostas = await conexao.QueryAsync<AlunoPerguntaRespostaDTO>(QueryAlunosRespostas.ToString(),
                new
                {
                    CodigoTurmaEol = filtro.CodigoTurmaEol,
                    AnoLetivo = filtro.AnoLetivo,
                    PeriodoId = filtro.PeriodoId,
                    ComponenteCurricularId = filtro.ComponenteCurricularId

                });

                return listaAlunoRespostas;

            }
        }


    }
}
