using Microsoft.EntityFrameworkCore;
using MoreLinq;
using Npgsql;
using SME.Pedagogico.Gestao.Data.Contexts;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Data.DTO.Portugues.Graficos.Portugues;
using SME.Pedagogico.Gestao.Data.DTO.Portugues.Relatorio;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.DTO;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using SME.Pedagogico.Gestao.Infra;
using SME.Pedagogico.Gestao.Models.Autoral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Data.Business
{
    public class RelatorioPortugues
    {
        private AlunosAPI alunoAPI;

        public RelatorioPortugues()
        {
            alunoAPI = new AlunosAPI(new EndpointsAPI());
        }

        public async Task<RelatorioPortuguesTurmaDto> ObterRelatorioPorTurmasPortugues(RelatorioPortuguesFiltroDto relatorioPortuguesFiltroDto)
        {
            IEnumerable<SondagemAluno> dados = null;
            PeriodoFixoAnual periodo = null;
            IEnumerable<Pergunta> perguntas = null;
            Grupo grupo = null;
            var relatorio = new RelatorioPortuguesTurmaDto();

            using (var contexto = new SMEManagementContextData())
            {
                grupo = await ObterGrupo(relatorioPortuguesFiltroDto, grupo, contexto);

                periodo = await ObterPeriodo(relatorioPortuguesFiltroDto, contexto);

                perguntas = await ObterPerguntas(relatorioPortuguesFiltroDto, perguntas, contexto);

                dados = await ObterDadosRelatorioPorTurma(relatorioPortuguesFiltroDto, dados, contexto);

            }

            var alunos = await ObterAlunosTurma(relatorioPortuguesFiltroDto, periodo);

            if (dados == null)
            {
                PreencherAlunosSemRespostas(relatorio, alunos);
                PreencherGraficoSemRespostas(perguntas, grupo, relatorio, alunos);
            }
            else
            {
                MapearRelatorioPorTurma(dados, perguntas, relatorio, alunos);
                MapearGraficoPorTurma(dados, perguntas, grupo, alunos, relatorio);
            }

            relatorio.Alunos = relatorio.Alunos.OrderBy(x => x.NomeAluno).ToList();

            return relatorio;
        }

        private static void MapearGraficoPorTurma(IEnumerable<SondagemAluno> dados, IEnumerable<Pergunta> perguntas, Grupo grupo, IEnumerable<AlunosNaTurmaDTO> alunos, RelatorioPortuguesTurmaDto relatorio)
        {
            var perguntasRespondidas = dados.SelectMany(x => x.ListaRespostas);

            var grafico = new Grafico
            {
                NomeGrafico = grupo.Descricao
            };

            perguntas.ForEach(pergunta =>
            {
                var barra = new GraficoBarra
                {
                    Label = pergunta.Descricao,
                    Value = perguntasRespondidas.Count(x => x.PerguntaId.Equals(pergunta.Id))
                };

                grafico.Barras.Add(barra);

            });

            grafico.Barras.Add(new GraficoBarra
            {
                Label = "Sem Preenchimento",
                Value = ObterTotalSemPreenchimento(dados, alunos)
            });

            relatorio.Graficos.Add(grafico);
        }

        private static int ObterTotalSemPreenchimento(IEnumerable<SondagemAluno> dados, IEnumerable<AlunosNaTurmaDTO> alunos)
        {
            var resultado = alunos.Where(aluno => !dados.Any(relatorio => relatorio.CodigoAluno.Equals(aluno.CodigoAluno.ToString())));

            return resultado.Count();
        }

        private static void PreencherGraficoSemRespostas(IEnumerable<Pergunta> perguntas, Grupo grupo, RelatorioPortuguesTurmaDto relatorio, IEnumerable<AlunosNaTurmaDTO> alunos)
        {
            var grafico = new Grafico
            {
                NomeGrafico = grupo.Descricao,
                Barras = perguntas.Select(pergunta => new GraficoBarra
                {
                    Label = pergunta.Descricao,
                    Value = 0,
                }).ToList()
            };

            grafico.Barras.Add(new GraficoBarra
            {
                Label = "Sem preenchimento",
                Value = alunos.Count()
            });

            relatorio.Graficos.Add(grafico);
        }

        private async Task<IEnumerable<AlunosNaTurmaDTO>> ObterAlunosTurma(RelatorioPortuguesFiltroDto relatorioPortuguesFiltroDto, PeriodoFixoAnual periodo)
        {
            var alunos = await alunoAPI.ObterAlunosAtivosPorTurmaEPeriodo(relatorioPortuguesFiltroDto.CodigoTurma, periodo.DataFim);

            if (alunos == null || !alunos.Any())
                throw new Exception("Não encontrado alunos para a turma informda");

            return alunos;
        }

        private static async Task<Grupo> ObterGrupo(RelatorioPortuguesFiltroDto relatorioPortuguesFiltroDto, Grupo grupo, SMEManagementContextData contexto)
        {
            grupo = await contexto.Grupo.FirstOrDefaultAsync(x => x.Id.Equals(relatorioPortuguesFiltroDto.GrupoId));

            if (grupo == null)
                throw new Exception("Não encontrado grupo informado");

            return grupo;
        }

        private static async Task<IEnumerable<SondagemAluno>> ObterDadosRelatorioPorTurma(RelatorioPortuguesFiltroDto relatorioPortuguesFiltroDto, IEnumerable<SondagemAluno> dados, SMEManagementContextData contexto)
        {
            dados = await contexto.SondagemAluno
                                .Include(banco => banco.ListaRespostas)
                                .Where(sondagemAluno => sondagemAluno.Sondagem.CodigoDre == relatorioPortuguesFiltroDto.CodigoDre &&
                                                        sondagemAluno.Sondagem.AnoLetivo == relatorioPortuguesFiltroDto.AnoLetivo &&
                                                        sondagemAluno.Sondagem.AnoTurma == relatorioPortuguesFiltroDto.AnoEscolar &&
                                                        sondagemAluno.Sondagem.CodigoUe == relatorioPortuguesFiltroDto.CodigoUe &&
                                                        sondagemAluno.Sondagem.CodigoTurma == relatorioPortuguesFiltroDto.CodigoTurma &&
                                                        sondagemAluno.Sondagem.ComponenteCurricularId == relatorioPortuguesFiltroDto.ComponenteCurricularId &&
                                                        sondagemAluno.Sondagem.GrupoId == relatorioPortuguesFiltroDto.GrupoId &&
                                                        sondagemAluno.Sondagem.PeriodoId == relatorioPortuguesFiltroDto.PeriodoId)
                                .ToListAsync();
            return dados;
        }

        private static async Task<PeriodoFixoAnual> ObterPeriodo(RelatorioPortuguesFiltroDto relatorioPortuguesFiltroDto, SMEManagementContextData contexto)
        {
            var periodo = await contexto.PeriodoFixoAnual
                                .FirstOrDefaultAsync(x => x.PeriodoId == relatorioPortuguesFiltroDto.PeriodoId && x.Ano == relatorioPortuguesFiltroDto.AnoLetivo);

            if (periodo == null)
                throw new Exception("Não encontrado periodo Informado");

            return periodo;
        }

        private static async Task<IEnumerable<Pergunta>> ObterPerguntas(RelatorioPortuguesFiltroDto relatorioPortuguesFiltroDto, IEnumerable<Pergunta> perguntas, SMEManagementContextData contexto)
        {
            perguntas = await contexto.OrdemPergunta
                                .Include(x => x.Pergunta)
                                .Where(x => x.GrupoId.Equals(relatorioPortuguesFiltroDto.GrupoId) && x.Excluido == false)
                                .OrderBy(x => x.OrdenacaoNaTela)
                                .Select(x => x.Pergunta)
                                .ToListAsync();

            if (perguntas == null || !perguntas.Any())
                throw new Exception("Não encontrada perguntas para o grupo informado");

            return perguntas;
        }

        private static void PreencherAlunosSemRespostas(RelatorioPortuguesTurmaDto relatorio, IEnumerable<AlunosNaTurmaDTO> alunos)
        {
            alunos.ForEach(aluno =>
            {
                if (relatorio.Alunos?.Any(r => r.CodigoAluno.Equals(aluno.CodigoAluno.ToString())) ?? false)
                {
                    AtualizarAlunosRelatorioTurma(relatorio, aluno);
                    return;
                }

                relatorio.Alunos.Add(new RelatorioPortuguesTurmaAluno
                {
                    CodigoAluno = aluno.CodigoAluno.ToString(),
                    NomeAluno = aluno.NomeAlunoRelatorio,
                    NumeroChamada = aluno.NumeroAlunoChamada,
                });
            });
        }

        private static void AtualizarAlunosRelatorioTurma(RelatorioPortuguesTurmaDto relatorio, AlunosNaTurmaDTO aluno)
        {
            var relatorioAluno = relatorio.Alunos.FirstOrDefault(ra => ra.CodigoAluno.Equals(aluno.CodigoAluno.ToString()));

            relatorioAluno.CodigoAluno = aluno.CodigoAluno.ToString();
            relatorioAluno.NomeAluno = aluno.NomeAlunoRelatorio;
            relatorioAluno.NumeroChamada = aluno.NumeroAlunoChamada;

            return;
        }

        private static void MapearRelatorioPorTurma(IEnumerable<SondagemAluno> dados, IEnumerable<Pergunta> perguntas, RelatorioPortuguesTurmaDto relatorio, IEnumerable<AlunosNaTurmaDTO> alunos)
        {
            relatorio.Perguntas = perguntas.Select(pergunta => (PerguntaSimplificadaDto)pergunta);

            relatorio.Alunos = dados.Select(dado => new RelatorioPortuguesTurmaAluno
            {
                CodigoAluno = dado.CodigoAluno,
                NomeAluno = dado.NomeAluno,
                Perguntas = dado.ListaRespostas.Select(x => x.PerguntaId)
            }).ToList();

            PreencherAlunosSemRespostas(relatorio, alunos);
        }

        public async Task<RelatorioAutoralLeituraProducaoDto> ObterRelatorioConsolidadoPortugues(RelatorioPortuguesFiltroDto filtroRelatorioSondagem)
        {
            var dados = new List<SondagemAlunoRespostas>();
            PeriodoFixoAnual periodo = null;
            Grupo grupo = null;
            IEnumerable<Pergunta> perguntas = null;
            var relatorio = new RelatorioAutoralLeituraProducaoDto();

            using (var contexto = new SMEManagementContextData())
            {
                dados = await contexto.SondagemAlunoRespostas.Include(x => x.SondagemAluno).Include(x => x.Pergunta).Include(x => x.Resposta)
                                                              .FromSql(ObterConsultaCompleta(filtroRelatorioSondagem),
                                                                        ObterParametros(filtroRelatorioSondagem)).ToListAsync();

                periodo = await contexto.PeriodoFixoAnual.FirstOrDefaultAsync(x => x.PeriodoId == filtroRelatorioSondagem.PeriodoId && x.Ano == filtroRelatorioSondagem.AnoLetivo);

                grupo = await contexto.Grupo.FirstOrDefaultAsync(x => x.Id == filtroRelatorioSondagem.GrupoId);

                perguntas = await contexto.OrdemPergunta.Include(x => x.Pergunta).Where(x => x.GrupoId.Equals(filtroRelatorioSondagem.GrupoId)).OrderBy(p => p.OrdenacaoNaTela).Select(x => x.Pergunta).ToListAsync();
            }

            if (grupo == null)
                throw new Exception($"Não encontrado grupo com o id '{filtroRelatorioSondagem.GrupoId}'");

            relatorio.GrupoDescricao = grupo.Descricao;

            int quantidade = await ObterQuantidadeAlunosAtivos(filtroRelatorioSondagem, periodo);

            if (quantidade == 0)
                throw new Exception("Não foi possivel obter os alunos ativos para o filtro especificado");

            relatorio.Totais = new RelatorioPortuguesTotalizadores { Quantidade = quantidade };
            if (filtroRelatorioSondagem.GrupoId != GrupoEnum.ProducaoTexto.Name())
                relatorio.Totais.Porcentagem = 100;

            var listaRetorno = new List<RelatorioPortuguesPerguntasDto>();

            if (dados == null || !dados.Any())
            {
                PreencherPerguntasForaLista(listaRetorno, perguntas);

                ObterSemPreenchimento(dados, quantidade, listaRetorno);

                relatorio.Perguntas = listaRetorno;

                MapearGrafico(grupo, relatorio);

                return relatorio;
            }

            PopularListaRetorno(dados, quantidade, perguntas, listaRetorno);

            relatorio.Perguntas = listaRetorno;

            MapearGrafico(grupo, relatorio);

            return relatorio;
        }

        private static void MapearGrafico(Grupo grupo, RelatorioAutoralLeituraProducaoDto relatorio)
        {
            var grafico = new Grafico
            {
                NomeGrafico = grupo.Descricao,
                Barras = relatorio.Perguntas.Select(pergunta => new GraficoBarra
                {
                    Label = pergunta.Nome,
                    Value = pergunta.Total.Quantidade
                }).ToList()
            };

            relatorio.Graficos.Add(grafico);
        }

        private async Task<int> ObterQuantidadeAlunosAtivos(RelatorioPortuguesFiltroDto filtroRelatorioSondagem, PeriodoFixoAnual periodo)
        {
            var filtro = new FiltroTotalAlunosAtivos
            {
                AnoLetivo = filtroRelatorioSondagem.AnoLetivo,
                AnoTurma = filtroRelatorioSondagem.AnoEscolar,
                DreId = filtroRelatorioSondagem.CodigoDre,
                UeId = filtroRelatorioSondagem.CodigoUe,
                DataInicio = periodo.DataInicio,
                DataFim = periodo.DataFim,
            };

            return await alunoAPI.ObterTotalAlunosAtivosPorPeriodo(filtro);
        }

        private void PopularListaRetorno(List<SondagemAlunoRespostas> dados, int alunosAtivos, IEnumerable<Pergunta> perguntas, List<RelatorioPortuguesPerguntasDto> listaRetorno)
        {
            foreach (var pergunta in perguntas)
            {
                AdicionarPerguntaSeNaoExistir(listaRetorno, pergunta, dados, alunosAtivos);
            }

            ObterSemPreenchimento(dados, alunosAtivos, listaRetorno);
            PreencherPerguntasForaLista(listaRetorno, perguntas);
        }

        private static void PreencherPerguntasForaLista(List<RelatorioPortuguesPerguntasDto> listaRetorno, IEnumerable<Pergunta> perguntas)
        {
            perguntas.ForEach(pergunta =>
            {
                if (listaRetorno.Any(x => x.Id?.Equals(pergunta.Id) ?? false))
                    return;

                listaRetorno.Add(new RelatorioPortuguesPerguntasDto
                {
                    Id = pergunta.Id,
                    Nome = pergunta.Descricao,
                    Total = new RelatorioPortuguesTotalizadores
                    {
                        Quantidade = 0,
                        Porcentagem = 0,
                    }
                });
            });
        }

        private static void ObterSemPreenchimento(List<SondagemAlunoRespostas> dados, int alunosAtivos, List<RelatorioPortuguesPerguntasDto> listaRetorno)
        {
            var alunosUnicos = dados.GroupBy(X => X.SondagemAluno.CodigoAluno);

            var quantidadeAlunosUnicos = alunosUnicos.Select(x => x.Key).Count();

            var diferenca = alunosAtivos - quantidadeAlunosUnicos;

            if (diferenca <= 0) return;

            listaRetorno.Add(new RelatorioPortuguesPerguntasDto
            {
                Nome = "Sem preenchimento",
                Total = new RelatorioPortuguesTotalizadores
                {
                    Quantidade = diferenca,
                    Porcentagem = Math.Round(((double)diferenca / (double)alunosAtivos) * 100, 2)
                }
            });
        }

        private void AdicionarPerguntaSeNaoExistir(List<RelatorioPortuguesPerguntasDto> retorno, Pergunta pergunta, List<SondagemAlunoRespostas> dados, int alunosAtivos)
        {
            if (retorno.Any(x => x.Id.Equals(pergunta.Id)))
                return;

            var AlunosPergunta = dados.Where(x => x.PerguntaId == pergunta.Id)
                                                .Select(x => x.SondagemAluno.CodigoAluno)
                                                .GroupBy(x => x).OrderBy(x => x.Key);

            var quantidadeAlunosPergunta = AlunosPergunta.Select(x => x.Key).Count();

            retorno.Add(new RelatorioPortuguesPerguntasDto
            {
                Id = pergunta.Id,
                Nome = pergunta.Descricao,
                Total = new RelatorioPortuguesTotalizadores
                {
                    Quantidade = quantidadeAlunosPergunta,
                    Porcentagem = Math.Round(((double)quantidadeAlunosPergunta / (double)alunosAtivos) * 100, 2)
                }
            });
        }

        private NpgsqlParameter[] ObterParametros(RelatorioPortuguesFiltroDto filtroRelatorioSondagem)
        {
            var parametros = new List<NpgsqlParameter>();

            parametros.Add(new NpgsqlParameter("anoLetivo", filtroRelatorioSondagem.AnoLetivo));
            parametros.Add(new NpgsqlParameter("periodoId", filtroRelatorioSondagem.PeriodoId));
            parametros.Add(new NpgsqlParameter("grupoId", filtroRelatorioSondagem.GrupoId));
            parametros.Add(new NpgsqlParameter("anoTurma", filtroRelatorioSondagem.AnoEscolar));
            parametros.Add(new NpgsqlParameter("componenteCurricularId", filtroRelatorioSondagem.ComponenteCurricularId));

            if (!string.IsNullOrWhiteSpace(filtroRelatorioSondagem.CodigoTurma))
                parametros.Add(new NpgsqlParameter("codigoTurma", filtroRelatorioSondagem.CodigoTurma));

            if (!string.IsNullOrWhiteSpace(filtroRelatorioSondagem.CodigoUe))
                parametros.Add(new NpgsqlParameter("codigoUe", filtroRelatorioSondagem.CodigoUe));

            if (!string.IsNullOrWhiteSpace(filtroRelatorioSondagem.CodigoDre))
                parametros.Add(new NpgsqlParameter("codigoDre", filtroRelatorioSondagem.CodigoDre));

            return parametros.ToArray();
        }

        private string ObterConsultaCompleta(RelatorioPortuguesFiltroDto filtroRelatorioSondagem)
        {
            var sql = new StringBuilder();

            sql.AppendLine("select sar.* from \"Sondagem\" s");
            sql.AppendLine("inner join \"SondagemAluno\" sa on sa.\"SondagemId\" = s.\"Id\"");
            sql.AppendLine("inner join \"SondagemAlunoRespostas\" sar on sar.\"SondagemAlunoId\" = sa.\"Id\"");
            sql.AppendLine(ObterWhere(filtroRelatorioSondagem));

            var retorno = sql.ToString();

            return sql.ToString();
        }

        private string ObterWhere(RelatorioPortuguesFiltroDto filtroRelatorioSondagem)
        {
            var builder = new StringBuilder();

            builder.AppendLine("where s.\"AnoLetivo\" = @anoLetivo");

            builder.AppendLine("and s.\"ComponenteCurricularId\" = @componenteCurricularId");

            builder.AppendLine("and s.\"PeriodoId\" = @periodoId");

            builder.AppendLine("and s.\"GrupoId\" = @grupoId");

            if (filtroRelatorioSondagem.AnoEscolar > 0)
                builder.AppendLine("and s.\"AnoTurma\" = @anoTurma");

            if (!string.IsNullOrWhiteSpace(filtroRelatorioSondagem.CodigoTurma))
                builder.AppendLine("and s.\"CodigoTurma\" = @codigoTurma");

            if (!string.IsNullOrWhiteSpace(filtroRelatorioSondagem.CodigoUe))
                builder.AppendLine("and s.\"CodigoUe\" = @codigoUe");

            if (!string.IsNullOrWhiteSpace(filtroRelatorioSondagem.CodigoDre))
                builder.AppendLine("and s.\"CodigoDre\" = @codigoDre");

            return builder.ToString();
        }
    }
}
