using System;
using Dapper;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using SME.Pedagogico.Gestao.Data.DTO.Matematica.Relatorio;
using System.Text;
using SME.Pedagogico.Gestao.Data.Contexts;
using SME.Pedagogico.Gestao.Data.Integracao.DTO;
using System.Threading.Tasks;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;

namespace SME.Pedagogico.Gestao.Data.Business
{
    public class RelatorioMatematicaAutoral
    {
        private const string QueryPeriodoFixoAnual = @"select
										     ""DataInicio"",
											 ""DataFim""
										      from
										     ""PeriodoFixoAnual""
											  where
											""PeriodoId"" = @PeriodoId
											and ""Ano"" = @AnoLetivo";

        public async Task<List<PerguntaDTO>> ObterPeriodoMatematica(filtrosRelatorioDTO filtro)
        {
            IncluiIdDoComponenteCurricularEhDoPeriodoNoFiltro(filtro);
            using (var conexao = new NpgsqlConnection(Environment.GetEnvironmentVariable("sondagemConnection")))
            {
                var query = QueryRelatorioMatematicaAutoral(filtro);
                var DatasPeriodo = await BuscaDatasPeriodoFixoAnual(filtro, conexao);
                int totalDeAlunos = await BuscaTotalDeAlunosEOl(filtro, DatasPeriodo);
                return await RetornaRelatorioMatematica(filtro, conexao, query, totalDeAlunos);
            }

        }

        private async Task<List<PerguntaDTO>> RetornaRelatorioMatematica(filtrosRelatorioDTO filtro, NpgsqlConnection conexao, string query, int totalDeAlunos)
        {
            var ListaPerguntaEhRespostasRelatorio = await conexao.QueryAsync<PerguntasRespostasDTO>(query.ToString(),
                new
                {
                    AnoDaTurma = filtro.AnoDaTurma,
                    CodigoEscola = filtro.CodigoEscola,
                    CodigoDRE = filtro.CodigoDRE,
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

                CalculaPercentualRespostas(totalDeAlunos, pergunta, listaPr);
                lista.Add(pergunta);
            });


            return lista;
        }

        private static void CalculaPercentualTotalPergunta(int totalDeAlunos, IGrouping<string, PerguntasRespostasDTO> x, PerguntaDTO pergunta)
        {
            pergunta.Nome = x.Where(y => y.PerguntaId == x.Key).First().PerguntaDescricao;
            pergunta.Total = new TotalDTO()
            {
                Quantidade = x.Where(y => y.PerguntaId == x.Key).Sum(q => q.QtdRespostas)
            };

            pergunta.Total.Porcentagem = (pergunta.Total.Quantidade > 0 ? (pergunta.Total.Quantidade * 100) / (Double)totalDeAlunos : 0).ToString("0.00");
            pergunta.Respostas = new List<RespostaDTO>();
        }

        private void CalculaPercentualRespostas(int totalDeAlunos, PerguntaDTO pergunta, List<PerguntasRespostasDTO> listaPr)
        {
            foreach (var item in listaPr)
            {
                var resposta = new RespostaDTO();
                resposta.Nome = item.RespostaDescricao;
                resposta.quantidade = item.QtdRespostas;
                resposta.porcentagem = (item.QtdRespostas > 0 ? (item.QtdRespostas * 100) / (Double)totalDeAlunos : 0).ToString("0.00");
                pergunta.Respostas.Add(resposta);
            }

            var respostaSempreenchimento = CriaRespostaSemPreenchimento(totalDeAlunos, pergunta.Total.Quantidade);
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

        private static async Task<int> BuscaTotalDeAlunosEOl(filtrosRelatorioDTO filtro, IEnumerable<DatasPeriodoFixoAnualDTO> DatasPeriodo)
        {
            var endpointsApi = new EndpointsAPI();
            var alunoApi = new AlunosAPI(endpointsApi);

            var filtroAlunos = new FiltroTotalAlunosAtivos()
            {
                AnoLetivo = filtro.AnoLetivo,
                AnoTurma = filtro.AnoDaTurma,
                DreId = filtro.CodigoDRE,
                UeId = filtro.CodigoEscola,
                DataInicio = DatasPeriodo.First().DataInicio,
                DataFim = DatasPeriodo.First().DataFim
            };


            var totalDeAlunos = await alunoApi.ObterTotalAlunosAtivosPorPeriodo(filtroAlunos);
            return totalDeAlunos;
        }

        private static async Task<IEnumerable<DatasPeriodoFixoAnualDTO>> BuscaDatasPeriodoFixoAnual(filtrosRelatorioDTO filtro, NpgsqlConnection conexao)
        {
            var queryPeriodoFixoAnual = QueryPeriodoFixoAnual;

            var DatasPeriodo = await conexao.QueryAsync<DatasPeriodoFixoAnualDTO>(queryPeriodoFixoAnual.ToString(),
              new
              {
                  PeriodoId = filtro.PeriodoId,
                  AnoLetivo = filtro.AnoLetivo,

              });
            return DatasPeriodo;
        }

        private static string QueryRelatorioMatematicaAutoral(filtrosRelatorioDTO filtro)
        {
            var queryRelatorio = @"SELECT
								p.""Id"" as ""PerguntaId"",
							    p.""Descricao"" as ""PerguntaDescricao"",
								r.""Id"" as ""RespostaId"",
								r.""Descricao"" as ""RespostaDescricao"",
								count(tabela.""RespostaId"") as ""QtdRespostas""
							    from
								""Pergunta"" p
								inner join ""PerguntaAnoEscolar"" pa on
							    pa.""PerguntaId"" = p.""Id""

								and pa.""AnoEscolar"" = @AnoDaTurma
								inner join ""PerguntaResposta"" pr on
								pr.""PerguntaId"" = p.""Id""
								inner join ""Resposta"" r on
								r.""Id"" = pr.""RespostaId""
								left join (
									select
									s.""AnoLetivo"",
									s.""AnoTurma"",
									per.""Descricao"",
									c.""Descricao"",
									sa.""NomeAluno"",
									p.""Id"" as""PerguntaId"",
									p.""Descricao"" as ""PerguntaDescricao"",
									r.""Id"" as ""RespostaId"",
									r.""Descricao"" as ""RespostaDescricao""
								from
									""SondagemAlunoRespostas"" sar
								inner join ""SondagemAluno"" sa on
									sa.""Id"" = ""SondagemAlunoId""
								inner join ""Sondagem"" s on
									s.""Id"" = sa.""SondagemId""
								inner join ""Pergunta"" p on
									p.""Id"" = sar.""PerguntaId""
								inner join ""Resposta"" r on
									r.""Id"" = sar.""RespostaId""
								inner join ""Periodo"" per on
									per.""Id"" = s.""PeriodoId""
								inner join ""ComponenteCurricular"" c on
									c.""Id"" = s.""ComponenteCurricularId""
								where
									s.""Id"" in (
									select
										""Id""
									from
										""Sondagem""
									where
									   ""ComponenteCurricularId"" = @ComponenteCurricularId
										";


            var query = new StringBuilder();
            query.Append(queryRelatorio);
            if (!string.IsNullOrEmpty(filtro.CodigoDRE))
                query.AppendLine(@" and ""CodigoDre"" =  @CodigoDRE");
            if (!string.IsNullOrEmpty(filtro.CodigoEscola))
                query.AppendLine(@"and ""CodigoUe"" =  @CodigoEscola");

            query.Append(@" and ""AnoLetivo"" = @AnoLetivo
			                and ""AnoTurma"" =  @AnoDaTurma
                            and ""PeriodoId"" = @PeriodoId
				         -- and ""CodigoTurma"" = '2135826'
                                                    ) ) as tabela on
								p.""Id"" = tabela.""PerguntaId"" and
								r.""Id""= tabela.""RespostaId""
							group by
								r.""Id"",
								r.""Descricao"",
								p.""Id"",
								p.""Descricao""
							order by
								p.""Descricao"",
								r.""Descricao"" ");
            return query.ToString();
        }

        private static async Task<IEnumerable<AlunosNaTurmaDTO>> ObterAlunosPorTurmaEPeriodoEOl(string codigoTurma, DateTime dataReferencia)
        {
            var endpointsApi = new EndpointsAPI();
            var alunoApi = new AlunosAPI(endpointsApi);
            return await alunoApi.ObterAlunosAtivosPorTurmaEPeriodo(codigoTurma, dataReferencia);
        }
    }
}
