CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

create or replace FUNCTION insereSondagemResposta(anoEscolar int4, recordValores RECORD, sondagemAlunoId uuid)
RETURNS void AS $$
declare
	valorResposta text;
	rec_perguntaResposta RECORD;
	sondagemAlunoRespostaId uuid;
begin
	
	if recordValores.valorResultado = 'A' then 
		valorResposta = 'Acertou';
	elseif recordValores.valorResultado = 'E' then 	
		valorResposta = 'Errou';
	elseif recordValores.valorResultado = 'NR' then 	
		valorResposta = 'Não resolveu';
	end if;

	for rec_perguntaResposta in select ps."Id" as perguntaId, r."Id" as respostaId   
                from public."PerguntaAnoEscolar" pae
                join public."Pergunta" p on p."Id" = pae."PerguntaId"
                join public."Pergunta" ps on ps."PerguntaId" = pae."PerguntaId"
                join public."PerguntaAnoEscolar" pae2 on pae2."PerguntaId" = ps."Id"
                join public."PerguntaResposta" prs on prs."PerguntaId" = ps."Id"
                join public."Resposta" r on r."Id" = prs."RespostaId"
                where pae."AnoEscolar" = anoEscolar 
                    and pae."Grupo" = 2 
                	and pae."Ordenacao" = recordValores.ordem
                    and ps."Descricao" = recordValores.descricaoPergunta
                    and r."Descricao" = valorResposta 
                   
		loop
			raise notice 'SondagemAlunoRespostas inserida - perguntaId: %, respostaId: %', rec_perguntaResposta.perguntaId,  rec_perguntaResposta.respostaId;
		
			insert into public."SondagemAlunoRespostas"("Id", "SondagemAlunoId", "PerguntaId", "RespostaId")
			values (public.uuid_generate_v4(), sondagemAlunoId, rec_perguntaResposta.perguntaId, rec_perguntaResposta.respostaId)
			returning "Id" into sondagemAlunoRespostaId;
			
			raise notice 'SondagemAlunoRespostas inserida: %', sondagemAlunoRespostaId;
		end loop;
end;
$$  LANGUAGE plpgsql
SET search_path = admin, pg_temp;


do $$
declare 
	REC_SONDAGEM RECORD;
	REC_SONDAGEM_ALUNO RECORD;
	REC_SONDAGEM_RESULTADO RECORD; 
	componenteCurricularId text;
	sondagemId uuid;
	sondagemAlunoId uuid;
begin
	
	raise notice '*INICIANDO MIGRAÇÃO SONDAGEM CM 2022*';
	
	select "Id" into componenteCurricularId from "ComponenteCurricular" c where c."Descricao" = 'Matemática'; 
	
	for REC_SONDAGEM in select "DreEolCode" , "EscolaEolCode" , "TurmaEolCode", "AnoLetivo" , "AnoTurma"  
		from "MathPoolCMs" mpc 
		where "AnoLetivo" = 2022 and 
		"AnoTurma" <= 3 and
		("Ordem3Ideia" <> '' or "Ordem3Resultado" <> ''
		or "Ordem4Ideia" <> '' or "Ordem4Resultado" <> ''
		or "Ordem5Ideia" <> '' or "Ordem5Resultado" <> '') and
		not exists (select "Id" from "Sondagem" 
					where "AnoTurma" = mpc."AnoTurma" 
						  and "CodigoTurma" = mpc."TurmaEolCode"
						  and "CodigoUe" = mpc."EscolaEolCode" 
						  and "CodigoDre" = mpc."DreEolCode" 
						  and "AnoLetivo" = mpc."AnoLetivo")
		group by "DreEolCode" , "EscolaEolCode" , "TurmaEolCode", "AnoLetivo" , "AnoTurma"
		
		loop
			raise notice 'Sondagem: %', REC_SONDAGEM;
			
			insert into public."Sondagem" ("Id", "ComponenteCurricularId" , "AnoTurma" , "CodigoTurma" , "CodigoUe" , "CodigoDre" , "AnoLetivo", "PeriodoId", "Bimestre")
			values (uuid_generate_v4(), componenteCurricularId, REC_SONDAGEM."AnoTurma",  REC_SONDAGEM."TurmaEolCode", REC_SONDAGEM."EscolaEolCode", REC_SONDAGEM."DreEolCode", REC_SONDAGEM."AnoLetivo", '', '1')
			returning "Id" into sondagemId;
		
			raise notice 'Sondagem inserida: %', sondagemId;
		
			for REC_SONDAGEM_ALUNO in select "AlunoEolCode", "AlunoNome", "Ordem3Ideia", "Ordem3Resultado" , "Ordem4Ideia" , "Ordem4Resultado" , "Ordem5Ideia" , "Ordem5Resultado"  
										from "MathPoolCMs" mpc 
										where "AnoLetivo" = 2022 and 
										"AnoTurma" <= 3 and
										"DreEolCode" = REC_SONDAGEM."DreEolCode" and 
										"EscolaEolCode" = REC_SONDAGEM."EscolaEolCode" and 
										"TurmaEolCode" = REC_SONDAGEM."TurmaEolCode" and 
										"AnoTurma"  = REC_SONDAGEM."AnoTurma" and
										("Ordem3Ideia" <> '' or "Ordem3Resultado" <> ''
										or "Ordem4Ideia" <> '' or "Ordem4Resultado" <> ''
										or "Ordem5Ideia" <> '' or "Ordem5Resultado" <> '')
			loop
				raise notice 'Sondagem Aluno: %', REC_SONDAGEM_ALUNO;
				
				insert into public."SondagemAluno"("Id" , "SondagemId" , "CodigoAluno" , "NomeAluno" , "Bimestre")
				values (uuid_generate_v4(), sondagemId, REC_SONDAGEM_ALUNO."AlunoEolCode", REC_SONDAGEM_ALUNO."AlunoNome", '1')
				returning "Id" into sondagemAlunoId;
			
				raise notice 'SondagemAluno inserida: %', sondagemAlunoId;
			
				for REC_SONDAGEM_RESULTADO in SELECT * FROM (VALUES (3, 'Ideia', REC_SONDAGEM_ALUNO."Ordem3Ideia"), 
																	(3, 'Resultado', REC_SONDAGEM_ALUNO."Ordem3Resultado"), 
																	(4, 'Ideia', REC_SONDAGEM_ALUNO."Ordem4Ideia"),
																	(4, 'Resultado', REC_SONDAGEM_ALUNO."Ordem4Resultado"),
																	(5, 'Ideia', REC_SONDAGEM_ALUNO."Ordem5Ideia"), 
																	(5, 'Resultado', REC_SONDAGEM_ALUNO."Ordem5Resultado")) AS t (ordem, descricaoPergunta, valorResultado)
						  											where valorResultado <> ''
					loop
						perform insereSondagemResposta(REC_SONDAGEM."AnoTurma", REC_SONDAGEM_RESULTADO, sondagemAlunoId);
					end loop;
			end loop;
		end loop;
	

	drop function insereSondagemResposta(int4, RECORD, uuid);

end $$;