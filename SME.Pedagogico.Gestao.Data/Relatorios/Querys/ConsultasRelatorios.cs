using SME.Pedagogico.Gestao.Data.DTO.Matematica.Relatorio;
using SME.Pedagogico.Gestao.Data.DTO.Portugues.Relatorio;
using SME.Pedagogico.Gestao.Infra;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.Relatorios.Querys
{
    public static class ConsultasRelatorios
    {

        private const int TERCEIRO_ANO = 3;

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

        public static string QueryRelatorioMatematicaAutoralBimestre(filtrosRelatorioDTO filtro)
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
									p.""Id"" as""PerguntaId"",
									r.""Id"" as ""RespostaId""
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
                                  and ""Bimestre"" = @Bimestre
                                                          ) ) as tabela on
	         						p.""Id"" = tabela.""PerguntaId"" and
	         						r.""Id""= tabela.""RespostaId""");

            if (filtro.AnoEscolar <= TERCEIRO_ANO)
                query.AppendLine(" WHERE pa.\"Grupo\" = " + (int)ProficienciaEnum.Numeros);

            query.AppendLine(@"group by
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

        public static string QueryRelatorioMatematicaProficiencia(bool filtroPorDre, bool filtroPorUe)
        {
            var query = new StringBuilder();

            query.AppendLine("SELECT pae.\"AnoEscolar\",");
            query.AppendLine("pae.\"Ordenacao\" AS \"OrdemPergunta\",");
            query.AppendLine("ppai.\"Id\" AS \"PerguntaId\",");
            query.AppendLine("ppai.\"Descricao\" AS \"PerguntaDescricao\",");
            query.AppendLine("pfilho.\"Id\" AS \"SubPerguntaId\",");
            query.AppendLine("pfilho.\"Descricao\" AS \"SubPerguntaDescricao\",");
            query.AppendLine("pr.\"Ordenacao\" AS \"OrdemResposta\",");
            query.AppendLine("r.\"Id\" AS \"RespostaId\",");
            query.AppendLine("r.\"Descricao\" AS \"RespostaDescricao\",");
            query.AppendLine("COUNT(tabela.\"RespostaId\") AS \"QtdRespostas\"");
            query.AppendLine(" FROM \"PerguntaAnoEscolar\" pae");
            query.AppendLine(" INNER JOIN \"Pergunta\" ppai ON ppai.\"Id\" = pae.\"PerguntaId\" AND pae.\"AnoEscolar\" = @AnoDaTurma");
            query.AppendLine(" INNER JOIN \"Pergunta\" pfilho ON pfilho.\"PerguntaId\" = pae.\"PerguntaId\"");
            query.AppendLine(" INNER JOIN \"PerguntaResposta\" pr ON pr.\"PerguntaId\" = pfilho.\"Id\"");
            query.AppendLine(" LEFT JOIN \"Resposta\" r ON r.\"Id\" = pr.\"RespostaId\"");
            query.AppendLine(" LEFT JOIN ( SELECT sar.\"PerguntaId\", sar.\"RespostaId\"");
            query.AppendLine(" FROM \"SondagemAlunoRespostas\" sar");
            query.AppendLine(" INNER JOIN \"SondagemAluno\" sa ON sa.\"Id\" = \"SondagemAlunoId\"");
            query.AppendLine(" INNER JOIN \"Sondagem\" s ON s.\"Id\" = sa.\"SondagemId\"");
            query.AppendLine(" INNER JOIN  \"ComponenteCurricular\" c ON c.\"Id\" = s.\"ComponenteCurricularId\"");
            query.AppendLine(" WHERE s.\"Id\" IN ( SELECT \"Id\"");
            query.AppendLine(" FROM \"Sondagem\"");
            query.AppendLine(" WHERE \"ComponenteCurricularId\" = @ComponenteCurricularId");

            if (filtroPorDre)
                query.AppendLine(" AND \"CodigoDre\" =  @CodigoDRE");
            if (filtroPorUe)
                query.AppendLine(" AND \"CodigoUe\" =  @CodigoEscola");

            query.AppendLine(" AND \"AnoLetivo\" = @AnoLetivo");
            query.AppendLine(" AND \"AnoTurma\"  = @AnoDaTurma");
            query.AppendLine(" AND \"Bimestre\" = @Bimestre");
            query.AppendLine(") ) AS tabela ON pfilho.\"Id\" = tabela.\"PerguntaId\"");
            query.AppendLine(" AND r.\"Id\" = tabela.\"RespostaId\"");
            query.AppendLine(" WHERE pae.\"Grupo\" = @Grupo");
            query.AppendLine(" GROUP BY pae.\"AnoEscolar\", pae.\"Ordenacao\", ppai.\"Descricao\",");
            query.AppendLine("          pfilho.\"Descricao\", pr.\"Ordenacao\", r.\"Descricao\",  ppai.\"Id\", pfilho.\"Id\", r.\"Id\"");
            query.AppendLine(" ORDER BY pae.\"Ordenacao\", pr.\"Ordenacao\", pfilho.\"Descricao\"");

            return query.ToString();
        }
    }
}
