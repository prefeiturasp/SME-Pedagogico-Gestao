using Dapper;
using Microsoft.EntityFrameworkCore;
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
using SME.Pedagogico.Gestao.Models.Autoral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Data.Business
{
    public class RelatorioMatematicaAutoral
    {
        private const int TERCEIRO_ANO = 3;

        public async Task<RelatorioConsolidadoDTO> ObterRelatorioMatematicaAutoral(filtrosRelatorioDTO filtro)
        {
            IncluiIdDoComponenteCurricularEhDoPeriodoNoFiltro(filtro);
            int totalDeAlunos = await ConsultaTotalDeAlunos.BuscaTotalDeAlunosEOl(filtro);
            var query = ObtenhaQueryRelatorioMatematica(filtro);
            var relatorio = new RelatorioConsolidadoDTO();

            using (var conexao = new NpgsqlConnection(Environment.GetEnvironmentVariable("sondagemConnection")))
            {
                relatorio.Perguntas = await RetornaRelatorioMatematica(filtro, conexao, query, totalDeAlunos);
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

            return await new RelatorioMatematicaPorTurmaProficiencia(filtro, ObtenhaProficiencia(filtro.Proficiencia)).ObtenhaDTO();
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
                    ComponenteCurricularId = filtro.ComponenteCurricularId,
                    Bimestre = filtro.Bimestre
                });

            var relatorioAgrupado = ListaPerguntaEhRespostasRelatorio.GroupBy(p => p.PerguntaId).ToList();

            var lista = new List<PerguntaDTO>();

            relatorioAgrupado.ForEach(x =>
            {
                var pergunta = new PerguntaDTO();
                CalculaPercentualTotalPergunta(totalDeAlunos, x.Where(y => y.PerguntaId == x.Key).First().PerguntaDescricao, pergunta);

                var listaPr = x.Where(y => y.PerguntaId == x.Key).ToList();

                var totalRespostas = x.Where(y => y.PerguntaId == x.Key).Sum(q => q.QtdRespostas);
                CalculaPercentualRespostas(totalDeAlunos, pergunta, listaPr, totalRespostas);
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
                var componenteCurricular = contexto.ComponenteCurricular.Where(x => x.Descricao == filtro.DescricaoDisciplina).FirstOrDefault();

                filtro.ComponenteCurricularId = componenteCurricular.Id;
                var periodo = contexto.Periodo.Where(x => x.Descricao == filtro.DescricaoPeriodo).FirstOrDefault();
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

            if (periodos.Count() == 0)
                throw new Exception("Periodo fixo anual nao encontrado");

            var endpoits = new EndpointsAPI();
            var alunoApi = new AlunosAPI(endpoits);
            var alunosEol = (await alunoApi.ObterAlunosAtivosPorTurmaEPeriodo(filtro.CodigoTurmaEol,periodos.First().DataInicio))
                                                            .OrderBy(aluno => aluno.NomeAluno)
                                                            .ToList();
            var QueryAlunosRespostas = ObtenhaQueryRelatorioPorTurmaMatematica(filtro);
            var listaAlunoRespostas = await RetornaListaRespostasAlunoPorTurma(filtro, QueryAlunosRespostas);
            var AlunosAgrupados = listaAlunoRespostas.GroupBy(x => x.CodigoAluno);
            var relatorio = new RelatorioMatematicaPorTurmaDTO();
            await RetornaPerguntasDoRelatorio(filtro, relatorio);

            var ListaAlunos = new List<AlunoPorTurmaRelatorioDTO>();
            alunosEol.ForEach(alunoRetorno =>
            {
                var aluno = new AlunoPorTurmaRelatorioDTO();
                aluno.CodigoAluno = alunoRetorno.CodigoAluno;
                aluno.NomeAluno = string.IsNullOrEmpty(alunoRetorno.NomeSocialAluno) ? alunoRetorno.NomeAlunoRelatorio : alunoRetorno.NomeSocialAluno;
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
                IQueryable<PerguntaAnoEscolar> queryPerguntaAnoEscolar = contexto.PerguntaAnoEscolar.Include(x => x.Pergunta)
                    .Where(perguntaAnoEscolar => perguntaAnoEscolar.AnoEscolar == filtro.AnoEscolar &&
                          ((perguntaAnoEscolar.FimVigencia == null && perguntaAnoEscolar.InicioVigencia.GetValueOrDefault().Year <= filtro.AnoLetivo) ||
                          (perguntaAnoEscolar.FimVigencia.GetValueOrDefault().Year >= filtro.AnoLetivo && perguntaAnoEscolar.InicioVigencia.GetValueOrDefault().Year <= filtro.AnoLetivo)));

                if (filtro.ConsiderarBimestre && filtro.AnoEscolar <= TERCEIRO_ANO)
                {
                    queryPerguntaAnoEscolar = queryPerguntaAnoEscolar.Where(perguntaAnoEscolar => perguntaAnoEscolar.Grupo == (int)ProficienciaEnum.Numeros);
                }

                var perguntasBanco = await queryPerguntaAnoEscolar.OrderBy(x => x.Ordenacao).Select(x => MapearPergunta(x)).ToListAsync();
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

        private int ObtenhaProficiencia(string proficiencia)
        {
            ProficienciaEnum valorEnum;

            if (Enum.TryParse(proficiencia.Replace(" ", String.Empty), out valorEnum))
            {
                return (int)valorEnum;
            }

            return (int)ProficienciaEnum.Numeros;
        }

        private async Task<List<PerguntaProficienciaDTO>> ObtenhaListaDeDtoPerguntaProficiencia(filtrosRelatorioDTO filtro)
        {
            int totalDeAlunos = await ConsultaTotalDeAlunos.BuscaTotalDeAlunosEOl(filtro);
            var listaPerguntaResposta = await ObtenhaListaDtoPerguntasRespostasProficiencia(filtro);
            var listaAgrupada = listaPerguntaResposta.GroupBy(p => p.PerguntaId).ToList();
            var listaRetorno = new List<PerguntaProficienciaDTO>();

            totalDeAlunos = listaPerguntaResposta.Count() > totalDeAlunos ? listaPerguntaResposta.Count() : totalDeAlunos;

            listaAgrupada.ForEach(agrupador =>
            {
                listaRetorno.Add(ObtenhaDtoPerguntaProficiencia(agrupador, totalDeAlunos));
            });

            return listaRetorno;
        }

        private PerguntaProficienciaDTO ObtenhaDtoPerguntaProficiencia(IGrouping<string, PerguntasRespostasProficienciaDTO> grupoPerguntaResposta, int totalDeAlunos)
        {
            var perguntaAgrupador = grupoPerguntaResposta.FirstOrDefault(pergunta => pergunta.PerguntaId == grupoPerguntaResposta.Key);

            return new PerguntaProficienciaDTO()
            {
                Nome = perguntaAgrupador.PerguntaDescricao,
                Ordenacao = perguntaAgrupador.OrdemPergunta,
                SubPerguntas = ObtenhaListaDtoPerguntaProficiencia(grupoPerguntaResposta, totalDeAlunos)
            };
        }

        private List<PerguntaDTO> ObtenhaListaDtoPerguntaProficiencia(IGrouping<string, PerguntasRespostasProficienciaDTO> grupoPerguntaResposta, int totalDeAlunos)
        {
            var listaPergunta = new List<PerguntaDTO>();
            var listaSubPerguntaAgrupador = grupoPerguntaResposta.Where(pergunta => pergunta.PerguntaId == grupoPerguntaResposta.Key)
                                                                .GroupBy(pergunta => pergunta.SubPerguntaId)
                                                                .ToList();

            listaSubPerguntaAgrupador.ForEach(subAgrupador =>
            {
                var pergunta = new PerguntaDTO();
                var descricao = subAgrupador.Where(sub => sub.SubPerguntaId == subAgrupador.Key).First().SubPerguntaDescricao;

                CalculaPercentualTotalPergunta(totalDeAlunos, descricao, pergunta);

                var listaPr = subAgrupador.Where(y => y.SubPerguntaId == subAgrupador.Key).ToList();
                var totalRespostas = subAgrupador.Where(y => y.SubPerguntaId == subAgrupador.Key).Sum(q => q.QtdRespostas);
                CalculaPercentualRespostas(totalDeAlunos, pergunta, listaPr.Cast<PerguntasRespostasDTO>().ToList(), totalRespostas);
                listaPergunta.Add(pergunta);
            });

            return listaPergunta;
        }

        private async Task<List<PerguntasRespostasProficienciaDTO>> ObtenhaListaDtoPerguntasRespostasProficiencia(filtrosRelatorioDTO filtro)
        {
            string query = ConsultasRelatorios.QueryRelatorioMatematicaProficiencia(!string.IsNullOrEmpty(filtro.CodigoDre), !string.IsNullOrEmpty(filtro.CodigoUe));

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

        private string ObtenhaQueryRelatorioMatematica(filtrosRelatorioDTO filtro)
        {
            if (filtro.ConsiderarBimestre)
            {
                return ConsultasRelatorios.QueryRelatorioMatematicaAutoralBimestre(
                                                !string.IsNullOrEmpty(filtro.CodigoDre), 
                                                !string.IsNullOrEmpty(filtro.CodigoUe),
                                                filtro.AnoEscolar <= TERCEIRO_ANO,filtro.Bimestre);
            }

            return ConsultasRelatorios.QueryRelatorioMatematicaAutoral(filtro);
        }

        private string ObtenhaQueryRelatorioPorTurmaMatematica(filtrosRelatorioDTO filtro)
        {
            if (filtro.ConsiderarBimestre)
            {
                return ConsultasRelatorios.QueryRelatorioPorTurmaMatematicaBimestre(filtro.AnoEscolar);
            }

            return ConsultasRelatorios.QueryRelatorioPorTurmaMatematica();
        }
    }
}