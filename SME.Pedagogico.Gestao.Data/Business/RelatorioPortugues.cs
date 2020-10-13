using Microsoft.EntityFrameworkCore;
using MoreLinq;
using Npgsql;
using SME.Pedagogico.Gestao.Data.Contexts;
using SME.Pedagogico.Gestao.Data.DTO.Portugues.Relatorio;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.DTO;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using SME.Pedagogico.Gestao.Models.Autoral;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<RelatorioAutoralLeituraProducaoDto> ObterRelatorioPortugues(RelatorioPortuguesFiltroDto filtroRelatorioSondagem)
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

                periodo = await contexto.PeriodoFixoAnual.FirstOrDefaultAsync(x => x.PeriodoId == filtroRelatorioSondagem.PeriodoId);

                grupo = await contexto.Grupo.FirstOrDefaultAsync(x => x.Id == filtroRelatorioSondagem.GrupoId);

                perguntas = await contexto.OrdemPergunta.Include(x => x.Pergunta).Where(x => x.GrupoId.Equals(filtroRelatorioSondagem.GrupoId)).Select(x => x.Pergunta).ToListAsync();
            }

            if (grupo == null)
                throw new Exception($"Não encontrado grupo com o id '{filtroRelatorioSondagem.GrupoId}'");

            relatorio.GrupoDescricao = grupo.Descricao;

            int quantidade = await ObterQuantidadeAlunosAtivos(filtroRelatorioSondagem, periodo);

            if (quantidade == 0)
                throw new Exception("Não foi possivel obter os alunos ativos para o filtro especificado");

            relatorio.Totais = new RelatorioPortuguesTotalizadores { Quantidade = quantidade };

            var listaRetorno = new List<RelatorioPortuguesPerguntasDto>();

            if (dados == null || !dados.Any())
            {
                PreencherPerguntasForaLista(listaRetorno, perguntas);

                ObterSemPreenchimento(dados, quantidade, listaRetorno);
                
                relatorio.Perguntas = listaRetorno;

                return relatorio;
            }

            if (filtroRelatorioSondagem.GrupoId.Equals("6a3d323a-2c44-4052-ba68-13a8dead299a"))
                relatorio.Totais.Porcentagem = 100;

            PopularListaRetorno(dados, quantidade, perguntas, listaRetorno);

            relatorio.Perguntas = listaRetorno;

            return relatorio;
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
