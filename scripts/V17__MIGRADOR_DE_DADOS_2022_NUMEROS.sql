CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

create or replace FUNCTION insereSondagemResposta(anoEscolar int4, recordValores RECORD, sondagemAlunoId uuid)
RETURNS void AS $$
declare
	valorResposta text;
	rec_perguntaResposta RECORD;
	sondagemAlunoRespostaId uuid;
begin
	
	if recordValores.valorResultado = 'S' then 
		valorResposta = 'Escreve convencionalmente';
	elseif recordValores.valorResultado = 'N' then 	
		valorResposta = 'Não escreve convencionalmente';
	end if;

	for rec_perguntaResposta in select p."Id" as perguntaId, r."Id" as respostaId   
                from public."PerguntaAnoEscolar" pae
                join public."Pergunta" p on p."Id" = pae."PerguntaId"
                join public."PerguntaResposta" prs on prs."PerguntaId" = p."Id"
                join public."Resposta" r on r."Id" = prs."RespostaId"
                where pae."AnoEscolar" = anoEscolar 
                    and pae."Grupo" = 3 
                    and p."Descricao" = recordValores.descricaoPergunta
                    and r."Descricao" = valorResposta 
		loop
			raise notice 'perguntaId: %, respostaId: %', rec_perguntaResposta.perguntaId,  rec_perguntaResposta.respostaId;
			
			select "Id" into sondagemAlunoRespostaId 
			from public."SondagemAlunoRespostas"
			where "SondagemAlunoId" = sondagemAlunoId
			  and "PerguntaId" = rec_perguntaResposta.perguntaId;
			
			if sondagemAlunoRespostaId is null then    
				insert into public."SondagemAlunoRespostas"("Id", "SondagemAlunoId", "PerguntaId", "RespostaId", "Bimestre")
				values (public.uuid_generate_v4(), sondagemAlunoId, rec_perguntaResposta.perguntaId, rec_perguntaResposta.respostaId, 1)
				returning "Id" into sondagemAlunoRespostaId;
				
				raise notice 'SondagemAlunoRespostas inserida: %', sondagemAlunoRespostaId;
			else
				raise notice 'SondagemAlunoRespostas já cadastrado: %', sondagemAlunoRespostaId;
			end if;
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
	
	raise notice '*INICIANDO MIGRAÇÃO SONDAGEM NÚMEROS 2022*';
	
	select "Id" into componenteCurricularId from "ComponenteCurricular" where "Descricao" = 'Matemática'; 
	create index "idx_MathPoolNumbers_migracao" on "MathPoolNumbers" ("AnoLetivo", "DreEolCode", "EscolaEolCode", "TurmaEolCode", "AnoTurma");
	
	for REC_SONDAGEM in select "DreEolCode" , "EscolaEolCode" , "TurmaEolCode", "AnoLetivo" , "AnoTurma" 
						from "MathPoolNumbers"	
						where "AnoLetivo" = 2022 and
						"AnoTurma" <= 3 and
						("Familiares" <> '' or "Opacos" <> '' or "Transparentes" <> '' or "TerminamZero" <> '' or
						"Algarismos" <> '' or "Processo" <> '' or "ZeroIntercalados" <> '')
						group by "DreEolCode" , "EscolaEolCode" , "TurmaEolCode", "AnoLetivo" , "AnoTurma"
		
		loop
			raise notice 'Sondagem: %', REC_SONDAGEM;
		
			select "Id" into sondagemId 
			from "Sondagem" 
			where "AnoTurma" = REC_SONDAGEM."AnoTurma" 
				  and "CodigoTurma" = REC_SONDAGEM."TurmaEolCode"
				  and "CodigoUe" = REC_SONDAGEM."EscolaEolCode" 
				  and "CodigoDre" = REC_SONDAGEM."DreEolCode" 
				  and "AnoLetivo" = REC_SONDAGEM."AnoLetivo"
				  and "Bimestre" = 1;
		
			if sondagemId is null then		 
				insert into public."Sondagem" ("Id", "ComponenteCurricularId" , "AnoTurma" , "CodigoTurma" , "CodigoUe" , "CodigoDre" , "AnoLetivo", "PeriodoId", "Bimestre")
				values (uuid_generate_v4(), componenteCurricularId, REC_SONDAGEM."AnoTurma",  REC_SONDAGEM."TurmaEolCode", REC_SONDAGEM."EscolaEolCode", REC_SONDAGEM."DreEolCode", REC_SONDAGEM."AnoLetivo", '', 1)
				returning "Id" into sondagemId;
			
				raise notice 'Sondagem inserida: %', sondagemId;
			else
				raise notice 'Sondagem encontrada: %', sondagemId;
			end if;
		
			for REC_SONDAGEM_ALUNO in select "AlunoEolCode" , "AlunoNome", "Familiares", "Opacos", "Transparentes", "TerminamZero", "Algarismos", "Processo", "ZeroIntercalados"  
										from "MathPoolNumbers"	
										where "AnoLetivo" = 2022 and
										"DreEolCode" = REC_SONDAGEM."DreEolCode" and
										"EscolaEolCode" = REC_SONDAGEM."EscolaEolCode" and
										"TurmaEolCode" = REC_SONDAGEM."TurmaEolCode" and
										"AnoTurma" = REC_SONDAGEM."AnoTurma" and
										("Familiares" <> '' or "Opacos" <> '' or "Transparentes" <> '' or "TerminamZero" <> '' or
										"Algarismos" <> '' or "Processo" <> '' or "ZeroIntercalados" <> '')
			loop
				raise notice 'Sondagem Aluno: %', REC_SONDAGEM_ALUNO;
			
				select "Id" into sondagemAlunoId 
				from "SondagemAluno" 
				where "SondagemId" = sondagemId 
				  and "CodigoAluno" = REC_SONDAGEM_ALUNO."AlunoEolCode";
				
				if sondagemAlunoId is null then	 
					insert into public."SondagemAluno"("Id" , "SondagemId" , "CodigoAluno" , "NomeAluno" , "Bimestre")
					values (uuid_generate_v4(), sondagemId, REC_SONDAGEM_ALUNO."AlunoEolCode", REC_SONDAGEM_ALUNO."AlunoNome", 1)
					returning "Id" into sondagemAlunoId;
				
					raise notice 'SondagemAluno inserida: %', sondagemAlunoId;
				else
					raise notice 'SondagemAluno encontrada: %', sondagemAlunoId;
				end if;
			
				for REC_SONDAGEM_RESULTADO in SELECT * FROM (VALUES ('Familiares ou Frequentes', REC_SONDAGEM_ALUNO."Familiares"), 
																	('Opacos', REC_SONDAGEM_ALUNO."Opacos"), 
																	('Transparentes', REC_SONDAGEM_ALUNO."Transparentes"),
																	('Terminam em Zero', REC_SONDAGEM_ALUNO."TerminamZero"),
																	('Algarismos Iguais', REC_SONDAGEM_ALUNO."Algarismos"), 
																	('Processo de Generalização', REC_SONDAGEM_ALUNO."Processo"),
																	('Zero Intercalado', REC_SONDAGEM_ALUNO."ZeroIntercalados")) AS t (descricaoPergunta, valorResultado)
						  											where valorResultado <> ''
					loop
						perform insereSondagemResposta(REC_SONDAGEM."AnoTurma", REC_SONDAGEM_RESULTADO, sondagemAlunoId);
					end loop;
			end loop;
		end loop;
	
	drop index "idx_MathPoolNumbers_migracao";
	drop function insereSondagemResposta(int4, RECORD, uuid);
	
	raise notice '*FINAL MIGRAÇÃO SONDAGEM NÚMEROS 2022*';
end $$;