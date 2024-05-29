using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoreLinq;
using Npgsql;
using SME.Pedagogico.Gestao.Data.Contexts;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Data.DTO.Matematica;
using SME.Pedagogico.Gestao.Data.DTO.Matematica.Relatorio;
using SME.Pedagogico.Gestao.Data.DTO.RelatorioPorTurma;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using SME.Pedagogico.Gestao.Data.Relatorios;
using SME.Pedagogico.Gestao.Data.Relatorios.Querys;
using SME.Pedagogico.Gestao.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Data.Business
{
    public class RelatorioMatematicaAutoral
    {
        private const int TERCEIRO_ANO = 3;
        private readonly IConfiguration _config;

        public RelatorioMatematicaAutoral(IConfiguration config)
        {
            this._config = config;
        }

        public async Task<RelatorioConsolidadoDTO> ObterRelatorioMatematicaAutoral(filtrosRelatorioDTO filtro)
        {
            var consideraNovaOpcaoResposta_SemPreenchimento = NovaOpcaoRespostaSemPreenchimento.ConsideraOpcaoRespostaSemPreenchimento(filtro.AnoLetivo,filtro.DescricaoPeriodo);
            IncluiIdDoComponenteCurricularEhDoPeriodoNoFiltro(filtro);
            var totalDeAlunos = await ConsultaTotalDeAlunos.BuscaTotalDeAlunosEOl(filtro);
            var query = ObtenhaQueryRelatorioMatematica(filtro);
            var relatorio = new RelatorioConsolidadoDTO();

            using (var conexao = new NpgsqlConnection(Environment.GetEnvironmentVariable("sondagemConnection")))
            {
                relatorio.Perguntas = await RetornaRelatorioMatematica(filtro, conexao, query, totalDeAlunos, consideraNovaOpcaoResposta_SemPreenchimento);
            }

            relatorio.Graficos = ObtenhaListaDeGrafico(relatorio.Perguntas);

            return relatorio;
        }

        public async Task<RelatorioConsolidadoProficienciaDTO> ObtenhaRelatorioMatematicaProficiencia(filtrosRelatorioDTO filtro)
        {
            var relatorio = new RelatorioConsolidadoProficienciaDTO();

            IncluiIdDoComponenteCurricularEhDoPeriodoNoFiltro(filtro);

            relatorio.Perguntas = await ObtenhaListaDeDtoPerguntaProficiencia(filtro);
            relatorio.Graficos = ObtenhaListaDeGraficoProficiencia(relatorio.Perguntas);

            return relatorio;
        }

        public async Task<RelatorioMatematicaPorTurmaProficienciaDTO> ObterRelatorioPorTurmaProficiencia(filtrosRelatorioDTO filtro)
        {
            IncluiIdDoComponenteCurricularEhDoPeriodoNoFiltro(filtro);

            return await new RelatorioMatematicaPorTurmaProficiencia(filtro, ObtenhaProficiencia(filtro.Proficiencia), this._config).ObtenhaDTO(filtro.Bimestre);
        }

        private static async Task<List<PerguntaDTO>> RetornaRelatorioMatematica(filtrosRelatorioDTO filtro, NpgsqlConnection conexao, string query, int totalDeAlunos, bool consideraNovaOpcaoResposta_SemPreenchimento)
        {
            var ListaPerguntaEhRespostasRelatorio = await conexao.QueryAsync<PerguntasRespostasDTO>(query.ToString(),
                new
                {
                    AnoDaTurma = filtro.AnoEscolar,
                    CodigoEscola = filtro.CodigoUe,
                    CodigoDRE = filtro.CodigoDre,
                    AnoLetivo = filtro.AnoLetivo,
                    PeriodoId = filtro.PeriodoId,
                    ComponenteCurricularId = filtro.ComponenteCurricularId,
                    Bimestre = filtro.Bimestre
                });

            var relatorioAgrupado = ListaPerguntaEhRespostasRelatorio.GroupBy(p => p.PerguntaId).ToList();

            var lista = new List<PerguntaDTO>();

            relatorioAgrupado.ForEach(x =>
            {
                var pergunta = new PerguntaDTO();
                var totalRespostas = x.Where(y => y.PerguntaId == x.Key).Sum(q => q.QtdRespostas);
                totalDeAlunos = totalRespostas > totalDeAlunos ? totalRespostas : totalDeAlunos;

                CalculaPercentualTotalPergunta(totalDeAlunos, x.First(y => y.PerguntaId == x.Key).PerguntaDescricao, pergunta);

                var listaPr = x.Where(y => y.PerguntaId == x.Key).ToList();
                CalculaPercentualRespostas(totalDeAlunos, pergunta, listaPr, totalRespostas, consideraNovaOpcaoResposta_SemPreenchimento);

                lista.Add(pergunta);
            });

            return lista;
        }

        private static void CalculaPercentualTotalPergunta(int totalDeAlunos, string descricaoPergunta, PerguntaDTO pergunta)
        {
            pergunta.Nome = descricaoPergunta;
            pergunta.Total = new TotalDTO()
            {
                Quantidade = totalDeAlunos
            };

            pergunta.Total.Porcentagem = (pergunta.Total.Quantidade > 0 ? (pergunta.Total.Quantidade * 100) / (Double)totalDeAlunos : 0).ToString("0.00");
            pergunta.Respostas = new List<RespostaDTO>();
        }

        private static void CalculaPercentualRespostas(int totalDeAlunos, PerguntaDTO pergunta, List<PerguntasRespostasDTO> listaPr, int totalRespostas, bool consideraNovaOpcaoResposta_SemPreenchimento)
        {
            foreach (var item in listaPr)
            {
                var resposta = new RespostaDTO();
                resposta.Nome = item.RespostaDescricao;
                resposta.quantidade = item.QtdRespostas;
                resposta.porcentagem = (item.QtdRespostas > 0 ? (item.QtdRespostas * 100) / (double)totalDeAlunos : 0).ToString("0.00");
                pergunta.Respostas.Add(resposta);
            }

            if (consideraNovaOpcaoResposta_SemPreenchimento) return;
            var respostaSempreenchimento = CriaRespostaSemPreenchimento(totalDeAlunos, totalRespostas);
            pergunta.Respostas.Add(respostaSempreenchimento);
        }

        private static RespostaDTO CriaRespostaSemPreenchimento(int totalDeAlunos, int quantidadeTotalRespostasPergunta)
        {
            var respostaSemPreenchimento = new RespostaDTO();
            var quantidade = totalDeAlunos - quantidadeTotalRespostasPergunta;
            respostaSemPreenchimento.Nome = "Sem preenchimento";
            respostaSemPreenchimento.quantidade = quantidade >= 0 ? quantidade : 0;
            respostaSemPreenchimento.porcentagem = (respostaSemPreenchimento.quantidade > 0 ? (respostaSemPreenchimento.quantidade * 100) / (Double)totalDeAlunos : 0).ToString("0.00");
            respostaSemPreenchimento.porcentagem = respostaSemPreenchimento.porcentagem;
            return respostaSemPreenchimento;
        }

        private static void IncluiIdDoComponenteCurricularEhDoPeriodoNoFiltro(filtrosRelatorioDTO filtro)
        {
            using (var contexto = new SMEManagementContextData())
            {
                var componenteCurricular = contexto.ComponenteCurricular.FirstOrDefault(x => x.Descricao == filtro.DescricaoDisciplina);

                filtro.ComponenteCurricularId = componenteCurricular.Id;
                var periodo = contexto.Periodo.FirstOrDefault(x => x.Descricao == filtro.DescricaoPeriodo);
                filtro.PeriodoId = periodo.Id;

                if (filtro.ConsiderarBimestre)
                {
                    filtro.Bimestre = int.Parse(filtro.DescricaoPeriodo.Substring(0, 1));
                }
            }
        }

        public async Task<RelatorioMatematicaPorTurmaDTO> ObterRelatorioPorTurma(filtrosRelatorioDTO filtro)
        {
                IncluiIdDoComponenteCurricularEhDoPeriodoNoFiltro(filtro);

                var periodos = await ConsultaTotalDeAlunos.BuscaDatasPeriodoFixoAnual(filtro);
                

            if (!periodos.Any())
                    throw new Exception("Periodo fixo anual nao encontrado");

                var endpoits = new EndpointsAPI();
                var alunoApi = new AlunosAPI(endpoits);
                var alunosEol = (await alunoApi.ObterAlunosAtivosPorTurmaEPeriodo(filtro.CodigoTurmaEol,periodos.First().DataFim))
                    .OrderBy(aluno => aluno.NomeAluno)
                    .ToList();
                var QueryAlunosRespostas = ObtenhaQueryRelatorioPorTurmaMatematica(filtro);
                var listaAlunoRespostas = await RetornaListaRespostasAlunoPorTurma(filtro, QueryAlunosRespostas);
                var relatorio = new RelatorioMatematicaPorTurmaDTO();
                await RetornaPerguntasDoRelatorio(filtro, relatorio);

                var ListaAlunos = new List<AlunoPorTurmaRelatorioDTO>();

                foreach (var alunoRetorno in alunosEol)
                {
                    var aluno = new AlunoPorTurmaRelatorioDTO();
                    aluno.CodigoAluno = alunoRetorno.CodigoAluno;
                    aluno.NomeAluno = string.IsNullOrEmpty(alunoRetorno.NomeSocialAluno) ? alunoRetorno.NomeAlunoRelatorio : alunoRetorno.NomeSocialAluno;
                    aluno.Perguntas = new List<PerguntaRespostaPorAluno>();

                    foreach (var perguntaBanco in relatorio.Perguntas)
                    {
                        var pergunta = new PerguntaRespostaPorAluno()
                        {
                            Id = perguntaBanco.Id,
                            Valor = string.Empty
                        };

                        var respostaAluno = listaAlunoRespostas.FirstOrDefault(x => x.PerguntaId == perguntaBanco.Id && x.CodigoAluno == aluno.CodigoAluno.ToString());
                        if (respostaAluno != null)
                            pergunta.Valor = respostaAluno.RespostaDescricao;
                        aluno.Perguntas.Add(pergunta);
                    }
                    ListaAlunos.Add(aluno);
                }
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
                    
                    relatorio.Graficos.Add(grafico);
                }
                }
                return relatorio;
        }
        private static bool ExibirNumeroDaQuestao(int anoEscolar, int bimestre)
        {
            return (anoEscolar >= Constantes.QUARTO_ANO && anoEscolar <= Constantes.NONO_ANO) && bimestre == Constantes.QUARTO_BIMESTRE;
        }

        private async Task RetornaPerguntasDoRelatorio(filtrosRelatorioDTO filtro, RelatorioMatematicaPorTurmaDTO relatorio)
        {
            var numeracaoNaDescricaoDaQuestao = ExibirNumeroDaQuestao(filtro.AnoEscolar, filtro.Bimestre) ? $@" 'Questão '|| pae.""Ordenacao""|| ': ' || p.""Descricao"" as ""Nome""  " : $@" p.""Descricao"" as ""Nome"" ";
            var sql = $@"select p.""Id"" as ""Id"",
							    {numeracaoNaDescricaoDaQuestao}
					from ""PerguntaAnoEscolar"" pae
                    inner join ""Pergunta"" p on p.""Id"" = pae.""PerguntaId""
                    left join  ""PerguntaAnoEscolarBimestre"" paeb ON paeb.""PerguntaAnoEscolarId"" = pae.""Id"" 
					where pae.""AnoEscolar"" = @anoEscolar ";

            if (filtro.AnoLetivo >= 2022)
                sql += $@" and((pae.""FimVigencia"" is null or extract(year from pae.""FimVigencia"") = @anoLetivo)
                           and extract(year from pae.""InicioVigencia"") <= @anoLetivo)";
            else
                sql += $@" and extract(year from pae.""InicioVigencia"") <= @anoLetivo";

            sql += $@" and (paeb.""Id"" is null
                       and not exists(select 1 from ""PerguntaAnoEscolar"" pae 
                                      inner join  ""PerguntaAnoEscolarBimestre"" paeb ON paeb.""PerguntaAnoEscolarId"" = pae.""Id""
                                      where pae.""AnoEscolar"" = @anoEscolar 
                                      and (pae.""FimVigencia"" is null 
                                      and extract(year from pae.""InicioVigencia"") <= @anoLetivo) 
                                      and paeb.""Bimestre"" = @bimestre)
                        or paeb.""Bimestre"" = @bimestre) ";

            if(!string.IsNullOrEmpty(filtro.Proficiencia))
                sql += $@"  and pae.""Grupo"" = @grupo";

            sql += " order by pae.\"Ordenacao\"";

            using (var conexao = new NpgsqlConnection(Environment.GetEnvironmentVariable("sondagemConnection")))
            {
                relatorio.Perguntas = (await conexao.QueryAsync<PerguntasRelatorioDTO>(sql.ToString(),
                    new
                    {
                        anoLetivo = filtro.AnoLetivo,
                        bimestre = filtro.Bimestre,
                        anoEscolar = filtro.AnoEscolar,
                        grupo = ObtenhaProficiencia(filtro.Proficiencia)
                    })).ToList();
            }  
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
                    ComponenteCurricularId = filtro.ComponenteCurricularId,
                    Bimestre = filtro.Bimestre

                });

                return listaAlunoRespostas;
            }
        }

        private List<GraficosRelatorioProficienciaDTO> ObtenhaListaDeGraficoProficiencia(List<PerguntaProficienciaDTO> lista)
        {
            var listaRetorno = new List<GraficosRelatorioProficienciaDTO>();

            lista.ForEach(pergunta =>
            {
                var grafico = new GraficosRelatorioProficienciaDTO()
                {
                    Nome = pergunta.Nome,
                    Ordenacao = pergunta.Ordenacao,
                    ListaDeGrafico = ObtenhaListaDeGrafico(pergunta.SubPerguntas)
                };

                listaRetorno.Add(grafico);
            });

            return listaRetorno;
        }

        private List<GraficosRelatorioDTO> ObtenhaListaDeGrafico(List<PerguntaDTO> listaPergunta)
        {
            var listaGrafico = new List<GraficosRelatorioDTO>();

            listaPergunta.ForEach(pergunta =>
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

                listaGrafico.Add(grafico);
            });

            return listaGrafico;
        }

        private static int ObtenhaProficiencia(string proficiencia)
        {
            if (string.IsNullOrEmpty(proficiencia)) return default;
            ProficienciaEnum valorEnum;

            if (Enum.TryParse(proficiencia.Replace(" ", String.Empty), out valorEnum))
            {
                return (int)valorEnum;
            }

            return (int)ProficienciaEnum.Numeros;

        }

        private async Task<List<PerguntaProficienciaDTO>> ObtenhaListaDeDtoPerguntaProficiencia(filtrosRelatorioDTO filtro)
        {
            var totalDeAlunos = await ConsultaTotalDeAlunos.BuscaTotalDeAlunosEOl(filtro);
            var consideraNovaOpcaoResposta_SemPreenchimento = NovaOpcaoRespostaSemPreenchimento.ConsideraOpcaoRespostaSemPreenchimento(filtro.AnoLetivo,filtro.DescricaoPeriodo);
            var listaPerguntaResposta = await ObtenhaListaDtoPerguntasRespostasProficiencia(filtro);
            var listaAgrupada = listaPerguntaResposta.GroupBy(p => p.PerguntaId).ToList();
            var listaRetorno = new List<PerguntaProficienciaDTO>();

            listaAgrupada.ForEach(agrupador =>
            {
                listaRetorno.Add(ObtenhaDtoPerguntaProficiencia(agrupador, totalDeAlunos,consideraNovaOpcaoResposta_SemPreenchimento));
            });

            return listaRetorno;
        }

        private PerguntaProficienciaDTO ObtenhaDtoPerguntaProficiencia(
            IGrouping<string, PerguntasRespostasProficienciaDTO> grupoPerguntaResposta, int totalDeAlunos,
            bool consideraNovaOpcaoRespostaSemPreenchimento)
        {
            var perguntaAgrupador = grupoPerguntaResposta.FirstOrDefault(pergunta => pergunta.PerguntaId == grupoPerguntaResposta.Key);

            return new PerguntaProficienciaDTO()
            {
                Nome = perguntaAgrupador.PerguntaDescricao,
                Ordenacao = perguntaAgrupador.OrdemPergunta,
                SubPerguntas = ObtenhaListaDtoPerguntaProficiencia(grupoPerguntaResposta, totalDeAlunos,consideraNovaOpcaoRespostaSemPreenchimento)
            };
        }

        private List<PerguntaDTO> ObtenhaListaDtoPerguntaProficiencia(
            IGrouping<string, PerguntasRespostasProficienciaDTO> grupoPerguntaResposta, int totalDeAlunos,
            bool consideraNovaOpcaoRespostaSemPreenchimento)
        {
            var listaPergunta = new List<PerguntaDTO>();
            var listaSubPerguntaAgrupador = grupoPerguntaResposta.Where(pergunta => pergunta.PerguntaId == grupoPerguntaResposta.Key)
                                                                .GroupBy(pergunta => pergunta.SubPerguntaId)
                                                                .ToList();

            var totalRespostasGeralPorSubPergunta = listaSubPerguntaAgrupador.Select(subPergunta => subPergunta.Sum(s => s.QtdRespostas)).Max();
            if (totalRespostasGeralPorSubPergunta > totalDeAlunos) totalDeAlunos = totalRespostasGeralPorSubPergunta;

            listaSubPerguntaAgrupador.ForEach(subAgrupador =>
            {
                var pergunta = new PerguntaDTO();
                var descricao = subAgrupador.Where(sub => sub.SubPerguntaId == subAgrupador.Key).First().SubPerguntaDescricao;

                CalculaPercentualTotalPergunta(totalDeAlunos, descricao, pergunta);

                var listaPr = subAgrupador.Where(y => y.SubPerguntaId == subAgrupador.Key).ToList().OrderBy(x => x.RespostaDescricao);
                var totalRespostas = subAgrupador.Where(y => y.SubPerguntaId == subAgrupador.Key).Sum(q => q.QtdRespostas);
                
                CalculaPercentualRespostas(totalDeAlunos, pergunta, listaPr.Cast<PerguntasRespostasDTO>().ToList(), totalRespostas,consideraNovaOpcaoRespostaSemPreenchimento);
                listaPergunta.Add(pergunta);
            });

            return listaPergunta;
        }

        private async Task<List<PerguntasRespostasProficienciaDTO>> ObtenhaListaDtoPerguntasRespostasProficiencia(filtrosRelatorioDTO filtro)
        {
            string query = ConsultasRelatorios.QueryRelatorioMatematicaProficiencia(!string.IsNullOrEmpty(filtro.CodigoDre), !string.IsNullOrEmpty(filtro.CodigoUe), filtro.Bimestre,filtro.AnoEscolar);

            using (var conexao = new NpgsqlConnection(Environment.GetEnvironmentVariable("sondagemConnection")))
            {
                return (await conexao.QueryAsync<PerguntasRespostasProficienciaDTO>(query.ToString(),
                                new
                                {
                                    AnoDaTurma = filtro.AnoEscolar,
                                    CodigoEscola = filtro.CodigoUe,
                                    CodigoDRE = filtro.CodigoDre,
                                    AnoLetivo = filtro.AnoLetivo,
                                    PeriodoId = filtro.PeriodoId,
                                    ComponenteCurricularId = filtro.ComponenteCurricularId,
                                    Grupo = ObtenhaProficiencia(filtro.Proficiencia),
                                    Bimestre = filtro.Bimestre
                                })
                        ).ToList();
            }
        }

        private static  string ObtenhaQueryRelatorioMatematica(filtrosRelatorioDTO filtro)
        {
            if (filtro.ConsiderarBimestre)
            {
                return ConsultasRelatorios.QueryRelatorioMatematicaAutoralBimestre(
                                                !string.IsNullOrEmpty(filtro.CodigoDre), 
                                                !string.IsNullOrEmpty(filtro.CodigoUe),
                                                filtro.AnoEscolar <= TERCEIRO_ANO,filtro.Bimestre,filtro.AnoEscolar);
            }

            return ConsultasRelatorios.QueryRelatorioMatematicaAutoral(filtro);
        }

        private static string ObtenhaQueryRelatorioPorTurmaMatematica(filtrosRelatorioDTO filtro)
        {
            return filtro.ConsiderarBimestre ? ConsultasRelatorios.QueryRelatorioPorTurmaMatematicaBimestre(filtro.AnoEscolar,filtro.Bimestre) : ConsultasRelatorios.QueryRelatorioPorTurmaMatematica();
        }
    }
}