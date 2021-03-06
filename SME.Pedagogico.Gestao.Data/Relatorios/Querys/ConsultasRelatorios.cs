﻿using SME.Pedagogico.Gestao.Data.DTO.Matematica.Relatorio;
using SME.Pedagogico.Gestao.Data.DTO.Portugues.Relatorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.Relatorios.Querys
{
    public static class ConsultasRelatorios
    {

        public static string QueryPeriodoFixoAnual = @"select
										     ""DataInicio"",
											 ""DataFim""
										      from
										     ""PeriodoFixoAnual""
											  where
											""PeriodoId"" = @PeriodoId
											and ""Ano"" = @AnoLetivo";

        public static string MontaQueryConsolidadoCapacidadeLeitura(RelatorioPortuguesFiltroDto filtro)
        {
            var queryRelatorio = @"
                                   select
                                   o.""Id"" as ""OrdermId"",
                                   o.""Descricao"" as ""Ordem"",
                                   p.""Id"" as ""PerguntaId"",
                                   p.""Descricao"" as ""PerguntaDescricao"",
                                   r.""Id"" as ""RespostaId"", 
                                   r.""Descricao"" as ""RespostaDescricao"" ,
                                   gp.""Ordenacao"",
                                   op.""OrdenacaoNaTela"",
                                   count(tabela.""RespostaId"") as ""QtdRespostas""
                                   from
                                       ""Ordem""  as o 
                                      inner join ""GrupoOrdem"" gp on 
                                      gp.""OrdemId"" = o.""Id"" and 
                                      gp.""GrupoId"" = @GrupoId
                                      inner join ""OrdemPergunta"" op on
                                       op.""GrupoId"" = @GrupoId
                                      inner join ""Pergunta"" p on
                                   	 p.""Id"" = op.""PerguntaId"" 
                                   inner join ""PerguntaResposta"" pr on
                                   	pr.""PerguntaId"" = p.""Id""
                                   inner join ""Resposta"" r on
                                   	r.""Id"" = pr.""RespostaId""
                                   left join (
                                   	select
                                   	    s.""OrdemId"",
                                   		s.""AnoLetivo"",
                                   		s.""AnoTurma"",
                                   		per.""Descricao"",
                                   		c.""Descricao"",
                                   		sa.""NomeAluno"",
                                   		p.""Id"" as ""PerguntaId"",
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
                                   			s.""Id""
                                   		from
                                   			""Sondagem"" s
                                   		where
                                   		        s.""GrupoId"" = @GrupoId
                                   		    and s.""ComponenteCurricularId"" = @ComponenteCurricularId";
                                           var query = new StringBuilder();
                                           query.Append(queryRelatorio);
                                           if (!string.IsNullOrEmpty(filtro.CodigoDre))
                                               query.AppendLine(@" and ""CodigoDre"" =  @CodigoDRE");
                                           if (!string.IsNullOrEmpty(filtro.CodigoUe))
                                               query.AppendLine(@"and ""CodigoUe"" =  @CodigoEscola");
                                        
                                           query.Append(@"
                                            and s.""PeriodoId"" = @PeriodoId
                                   			and s.""AnoLetivo"" = @AnoLetivo
                                   			and s.""AnoTurma"" = @AnoTurma
                                   		        ) ) as tabela on
                                          	p.""Id"" = tabela.""PerguntaId"" and
                                          	r.""Id""= tabela.""RespostaId"" and
                                              o.""Id"" = tabela.""OrdemId""
                                          group by
                                          	o.""Id"",
                                              o.""Descricao"",
                                              r.""Id"",
                                          	r.""Descricao"",
                                          	p.""Id"",
                                          	p.""Descricao"",
                                          	gp.""Ordenacao"",
                                            op.""OrdenacaoNaTela""
                                          order by
                                             gp.""Ordenacao"",
                                             o.""Descricao"",
                                             op.""OrdenacaoNaTela"",
                                              r.""Descricao""");
            return query.ToString();
        }



        public static string QueryRelatorioMatematicaAutoral(filtrosRelatorioDTO filtro)
        {
            var queryRelatorio = @"SELECT
								p.""Id"" as ""PerguntaId"",
							    p.""Descricao"" as ""PerguntaDescricao"",
								r.""Id"" as ""RespostaId"",
								r.""Descricao"" as ""RespostaDescricao"",
	                            pa.""Ordenacao"",
                                pr.""Ordenacao"",
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
                  if (!string.IsNullOrEmpty(filtro.CodigoDre))
                      query.AppendLine(@" and ""CodigoDre"" =  @CodigoDRE");
                  if (!string.IsNullOrEmpty(filtro.CodigoUe))
                      query.AppendLine(@"and ""CodigoUe"" =  @CodigoEscola");
             
                  query.Append(@" and ""AnoLetivo"" = @AnoLetivo
	         	                and ""AnoTurma"" =  @AnoDaTurma
                                  and ""PeriodoId"" = @PeriodoId
                                                          ) ) as tabela on
	         						p.""Id"" = tabela.""PerguntaId"" and
	         						r.""Id""= tabela.""RespostaId""
	         					group by
	         						r.""Id"",
	         						r.""Descricao"",
	         						p.""Id"",
	         						p.""Descricao"",
                                    pa.""Ordenacao"",
                                    pr.""Ordenacao""
	         					order by
                                    pa.""Ordenacao"",
                                    pr.""Ordenacao"",
	         						p.""Descricao"",
	         						r.""Descricao"" ");
                  return query.ToString();
        }

        public static string QueryRelatorioPorTurmaMatematica()
        {
          return  @"select
                        s.""AnoLetivo"",
           	            s.""AnoTurma"",
                        sa.""CodigoAluno"",
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
                        where s.""CodigoTurma"" = @CodigoTurmaEol
                          and s.""AnoLetivo"" = @AnoLetivo
                          and s.""ComponenteCurricularId"" = @ComponenteCurricularId
                          and s.""PeriodoId"" = @PeriodoId";
        }

        public static string QueryRelatorioPorTurmaPortuguesCapacidadeDeLeitura()
        {
            return @"
                    select
                       s.""OrdemId"",
                       o.""Descricao"" as ""OrdemDescricao"",
                       sa.""CodigoAluno"",
                       sa.""NomeAluno"",
                       p.""Id"" as ""PerguntaId"",
                       p.""Descricao"" as ""PerguntaDescricao"",
                       sar.""RespostaId"",
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
                	inner join ""Ordem"" o on
                    o.""Id"" = s.""OrdemId""

                where
            		s.""Id"" in (
            		select
            			s.""Id""
            		from
            			""Sondagem"" s
            		where
            		        s.""GrupoId"" = @GrupoId
            		    and s.""ComponenteCurricularId"" = @ComponenteCurricularId
                     and s.""PeriodoId"" = @PeriodoId
            			and s.""AnoLetivo"" = @AnoLetivo
            			and s.""CodigoTurma"" = @CodigoTurmaEol
            		        )";
        }

    }
}
