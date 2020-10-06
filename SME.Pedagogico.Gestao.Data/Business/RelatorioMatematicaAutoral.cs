﻿using System;
using Dapper;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using SME.Pedagogico.Gestao.WebApp.Models;
using SME.Pedagogico.Gestao.Data.DTO.Matematica.Relatorio;
using System.Text;
using SME.Pedagogico.Gestao.Data.Contexts;
using SME.Pedagogico.Gestao.Models.Autoral;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Data.Business
{
    public class RelatorioMatematicaAutoral
    {
        public async Task<List<PerguntaDTO>>  ObterPeriodoMatematica(filtrosRelatorioDTO filtro)
        {
	

			using (var contexto = new SMEManagementContextData()) 
			{ 

				var componenteCurricular = contexto.ComponenteCurricular.Where(x => x.Descricao == filtro.DescricaoDisciplina).FirstOrDefault();

				filtro.ComponenteCurricularId = componenteCurricular.Id;
				var periodo = contexto.Periodo.Where(x => x.Descricao == filtro.DescricaoPeriodo).FirstOrDefault();
				filtro.PeriodoId = periodo.Id;
			}

				var queryTeste = @"SELECT
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
            query.Append(queryTeste);
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

            try
            {

                var conexao = new NpgsqlConnection(Environment.GetEnvironmentVariable("sondagemConnection"));
                var obj = await conexao.QueryAsync<PerguntasRespostasDTO>(query.ToString(),
                    new
                    {
                        AnoDaTurma = filtro.AnoDaTurma,
                        CodigoEscola = filtro.CodigoEscola,
                        CodigoDRE = filtro.CodigoDRE,
                        AnoLetivo = filtro.AnoLetivo,
						PeriodoId = filtro.PeriodoId,
						ComponenteCurricularId = filtro.ComponenteCurricularId

					});

                var obj2 = obj.GroupBy(p => p.PerguntaId).ToList();

                var lista = new List<PerguntaDTO>();

                obj2.ForEach(x =>
                {
                    var pergunta = new PerguntaDTO();
                    pergunta.Nome = x.Where(y => y.PerguntaId == x.Key).First().PerguntaDescricao;
                    pergunta.Total = new TotalDTO()
                    {
                        Quantidade = x.Where(y => y.PerguntaId == x.Key).Sum(q => q.QtdRespostas)
                    };
                    pergunta.Respostas = new List<RespostaDTO>();

                    var listaPr = x.Where(y => y.PerguntaId == x.Key).ToList();

                    foreach (var item in listaPr)
                    {
                        var resposta = new RespostaDTO();

                        resposta.Nome = item.RespostaDescricao;
                        resposta.quantidade = item.QtdRespostas;
                        resposta.porcentagem = pergunta.Total.Quantidade > 0 ? (item.QtdRespostas * 100) / pergunta.Total.Quantidade : 0;

                        pergunta.Respostas.Add(resposta);
                    }

                    lista.Add(pergunta);
                });

			





				return lista;
            }


            catch (Exception ex)
            {

                throw ex;
            }




        }
    }
}
