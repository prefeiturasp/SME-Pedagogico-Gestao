using Microsoft.EntityFrameworkCore;
using Npgsql;
using SME.Pedagogico.Gestao.Data.Contexts;
using SME.Pedagogico.Gestao.Data.DTO.Portugues.Relatorio;
using SME.Pedagogico.Gestao.Models.Autoral;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Data.Business
{
    public class RelatorioPortugues
    {
        public async Task<IEnumerable<RelatorioPortuguesPerguntasDto>> ObterRelatorioPortugues(RelatorioPortuguesFiltroDto filtroRelatorioSondagem)
        {
            var dados = new List<SondagemAlunoRespostas>();

            using (var contexto = new SMEManagementContextData())
            {
                dados = await contexto.SondagemAlunoRespostas.Include(x => x.Pergunta).Include(x => x.Resposta)
                                                              .FromSql(ObterConsultaCompleta(filtroRelatorioSondagem),
                                                                        ObterParametros(filtroRelatorioSondagem)).ToListAsync();
            }

            if (dados == null || !dados.Any())
                return null;

            var perguntas = dados.GroupBy(x => x.Pergunta).Select(x => x.Key);

            var listaRetorno = new List<RelatorioPortuguesPerguntasDto>();

            foreach (var pergunta in perguntas)
            {
                AdicionarPerguntaSeNaoExistir(listaRetorno, pergunta);

                var respostas = dados.Where(x => x.PerguntaId == pergunta.Id).Select(x => x.Resposta).GroupBy(x => x.Id);

                var perguntaRetorno = listaRetorno.FirstOrDefault(x => x.Id.Equals(pergunta.Id));

                perguntaRetorno.Respostas.AddRange(respostas.Select(resp => new RelatorioPortuguesRespostasDto
                {
                    Id = resp.Key,
                    Nome = resp.FirstOrDefault().Descricao,
                    Quantidade = resp.Count(),
                }));
            }

            return listaRetorno;
        }

        private void AdicionarPerguntaSeNaoExistir(List<RelatorioPortuguesPerguntasDto> retorno, Pergunta pergunta)
        {
            if (retorno.Any(x => x.Id.Equals(pergunta.Id)))
                return;

            retorno.Add(new RelatorioPortuguesPerguntasDto
            {
                Id = pergunta.Id,
                Nome = pergunta.Descricao,
            });
        }

        private NpgsqlParameter[] ObterParametros(RelatorioPortuguesFiltroDto filtroRelatorioSondagem)
        {
            var parametros = new List<NpgsqlParameter>();

            parametros.Add(new NpgsqlParameter("anoLetivo", filtroRelatorioSondagem.AnoLetivo));
            parametros.Add(new NpgsqlParameter("periodoId", filtroRelatorioSondagem.PeriodoId));
            parametros.Add(new NpgsqlParameter("grupoId", filtroRelatorioSondagem.GrupoId));
            parametros.Add(new NpgsqlParameter("anoTurma", filtroRelatorioSondagem.AnoEscolar));
            parametros.Add(new NpgsqlParameter("codigoTurma", filtroRelatorioSondagem.CodigoTurma));
            parametros.Add(new NpgsqlParameter("codigoUe", filtroRelatorioSondagem.CodigoUe));
            parametros.Add(new NpgsqlParameter("codigoDre", filtroRelatorioSondagem.CodigoDre));
            parametros.Add(new NpgsqlParameter("componenteCurricularId", filtroRelatorioSondagem.ComponenteCurricularId));

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
