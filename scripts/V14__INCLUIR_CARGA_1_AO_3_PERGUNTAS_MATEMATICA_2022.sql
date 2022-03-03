CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

--> Insere Respostas

--> Escreve convencionalmente = S
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Escreve convencionalmente' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Escreve convencionalmente');

--> Não escreve convencionalmente = N
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não escreve convencionalmente' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não escreve convencionalmente');

--> Acertou = A
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Acertou' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Acertou');

--> Errou = E
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Errou' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Errou');

--> Não resolveu = NR
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não resolveu' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não resolveu');


--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 1º ano - numeros - Ordem 1

do $$
declare 
	respostaId text;
	perguntaPaiId text;
	perguntaId text;
begin


insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Familiares ou Frequentes','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia","Grupo")
select uuid_generate_v4()::text, perguntaId, 1,1,'2022-01-01',1
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 1 and "Grupo" = 1 and "Ordenacao" = 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);


--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 1º ano - numeros - Ordem 2
	
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Opacos','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia","Grupo")
select uuid_generate_v4()::text, perguntaId, 1,2,'2022-01-01',1
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 1 and "Grupo" = 1 and "Ordenacao" = 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 1º ano - numeros - Ordem 3

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Transparentes','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia","Grupo")
select uuid_generate_v4()::text, perguntaId, 1,3,'2022-01-01',1
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 1 and "Grupo" = 1 and "Ordenacao" = 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 1º ano - numeros - Ordem 4
	
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Terminam em Zero','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia","Grupo")
select uuid_generate_v4()::text, perguntaId, 1,4,'2022-01-01',1
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 1 and "Grupo" = 1 and "Ordenacao" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 1º ano - numeros - Ordem 5

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Algarismos Iguais','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia","Grupo")
select uuid_generate_v4()::text, perguntaId, 1,5,'2022-01-01',1
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 1 and "Grupo" = 1 and "Ordenacao" = 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 1º ano - numeros - Ordem 6
	
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Processo de Generalização','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia","Grupo")
select uuid_generate_v4()::text, perguntaId, 1,6,'2022-01-01',1
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 1 and "Grupo" = 1 and "Ordenacao" = 6);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 1º ano - numeros - Ordem 7

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Zero Intercalado','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia","Grupo")
select uuid_generate_v4()::text, perguntaId, 1,7,'2022-01-01',1
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 1 and "Grupo" = 1 and "Ordenacao" = 7);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 2º ano - numeros - Ordem 1
	
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Familiares ou Frequentes','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia","Grupo")
select uuid_generate_v4()::text, perguntaId, 2,1,'2022-01-01',1
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 2 and "Grupo" = 1 and "Ordenacao" = 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 2º ano - numeros - Ordem 2
	
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Opacos','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia","Grupo")
select uuid_generate_v4()::text, perguntaId, 2,2,'2022-01-01',1
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 2 and "Grupo" = 1 and "Ordenacao" = 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 2º ano - numeros - Ordem 3
	
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Transparentes','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia","Grupo")
select uuid_generate_v4()::text, perguntaId, 2,3,'2022-01-01',1
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 2 and "Grupo" = 1 and "Ordenacao" = 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 2º ano - numeros - Ordem 4
	
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Terminam em Zero','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia","Grupo")
select uuid_generate_v4()::text, perguntaId, 2,4,'2022-01-01',1
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 2 and "Grupo" = 1 and "Ordenacao" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 2º ano - numeros - Ordem 5
	
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Algarismos Iguais','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia","Grupo")
select uuid_generate_v4()::text, perguntaId, 2,5,'2022-01-01',1
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 2 and "Grupo" = 1 and "Ordenacao" = 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 2º ano - numeros - Ordem 6
	
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Processo de Generalização','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia","Grupo")
select uuid_generate_v4()::text, perguntaId, 2,6,'2022-01-01',1
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 2 and "Grupo" = 1 and "Ordenacao" = 6);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 2º ano - numeros - Ordem 7
	
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Zero Intercalado','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia","Grupo")
select uuid_generate_v4()::text, perguntaId, 2,7,'2022-01-01',1
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 2 and "Grupo" = 1 and "Ordenacao" = 7);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 3º ano - numeros - Ordem 1
	
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Familiares ou Frequentes','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia","Grupo")
select uuid_generate_v4()::text, perguntaId, 3,1,'2022-01-01',1
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 3 and "Grupo" = 1 and "Ordenacao" = 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 3º ano - numeros - Ordem 2
	
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Opacos','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia","Grupo")
select uuid_generate_v4()::text, perguntaId, 3,2,'2022-01-01',1
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 3 and "Grupo" = 1 and "Ordenacao" = 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 3º ano - numeros - Ordem 3
	
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Transparentes','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia","Grupo")
select uuid_generate_v4()::text, perguntaId, 3,3,'2022-01-01',1
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 3 and "Grupo" = 1 and "Ordenacao" = 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 3º ano - numeros - Ordem 4
	
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Terminam em Zero','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia","Grupo")
select uuid_generate_v4()::text, perguntaId, 3,4,'2022-01-01',1
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 3 and "Grupo" = 1 and "Ordenacao" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 3º ano - numeros - Ordem 5
	
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Algarismos Iguais','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia","Grupo")
select uuid_generate_v4()::text, perguntaId, 3,5,'2022-01-01',1
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 3 and "Grupo" = 1 and "Ordenacao" = 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 3º ano - numeros - Ordem 6
	
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Processo de Generalização','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia","Grupo")
select uuid_generate_v4()::text, perguntaId, 3,6,'2022-01-01',1
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 3 and "Grupo" = 1 and "Ordenacao" = 6);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 3º ano - numeros - Ordem 7
	
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Zero Intercalado','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia","Grupo")
select uuid_generate_v4()::text, perguntaId, 3,7,'2022-01-01',1
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 3 and "Grupo" = 1 and "Ordenacao" = 7);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não escreve convencionalmente';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);


--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 1º Ano - CA - Ordem 1

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Composição','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaPaiId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia", "Grupo")
select uuid_generate_v4()::text, perguntaPaiId, 1,1,'2022-01-01',2
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaPaiId and "AnoEscolar" = 1 and "Ordenacao" = 1 and "Grupo" = 2);

--> Ideia
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Ideia','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', perguntaPaiId)
returning "Id" into perguntaId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--> Resultado
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Resultado','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', perguntaPaiId)
returning "Id" into perguntaId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 1º Ano - CA - Ordem 2

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Composição','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaPaiId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia", "Grupo")
select uuid_generate_v4()::text, perguntaPaiId, 1,2,'2022-01-01',2
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaPaiId and "AnoEscolar" = 1 and "Ordenacao" = 2 and "Grupo" = 2);

--> Ideia
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Ideia','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', perguntaPaiId)
returning "Id" into perguntaId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--> Resultado
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Resultado','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', perguntaPaiId)
returning "Id" into perguntaId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 1º Ano - CA - Ordem 3

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Composição','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaPaiId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia", "Grupo")
select uuid_generate_v4()::text, perguntaPaiId, 1,3,'2022-01-01',2
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaPaiId and "AnoEscolar" = 1 and "Ordenacao" = 3 and "Grupo" = 2);

--> Ideia
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Ideia','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', perguntaPaiId)
returning "Id" into perguntaId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--> Resultado
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Resultado','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', perguntaPaiId)
returning "Id" into perguntaId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);



--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 2º Ano - CA - Ordem 1

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Composição','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaPaiId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia", "Grupo")
select uuid_generate_v4()::text, perguntaPaiId, 2,1,'2022-01-01',2
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaPaiId and "AnoEscolar" = 2 and "Ordenacao" = 1 and "Grupo" = 2);

--> Ideia
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Ideia','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', perguntaPaiId)
returning "Id" into perguntaId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--> Resultado
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Resultado','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', perguntaPaiId)
returning "Id" into perguntaId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 2º Ano - CA - Ordem 2

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Transformação','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaPaiId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia", "Grupo")
select uuid_generate_v4()::text, perguntaPaiId, 2,2,'2022-01-01',2
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaPaiId and "AnoEscolar" = 2 and "Ordenacao" = 2 and "Grupo" = 2);

--> Ideia
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Ideia','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', perguntaPaiId)
returning "Id" into perguntaId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--> Resultado
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Resultado','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', perguntaPaiId)
returning "Id" into perguntaId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 2º Ano - CM - Ordem 3

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Proporcionalidade','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaPaiId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia", "Grupo")
select uuid_generate_v4()::text, perguntaPaiId, 2,3,'2022-01-01',3
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaPaiId and "AnoEscolar" = 2 and "Ordenacao" = 3 and "Grupo" = 3);

--> Ideia
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Ideia','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', perguntaPaiId)
returning "Id" into perguntaId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--> Resultado
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Resultado','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', perguntaPaiId)
returning "Id" into perguntaId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 3º Ano - CA - Ordem 1

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Composição','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaPaiId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia", "Grupo")
select uuid_generate_v4()::text, perguntaPaiId, 3,1,'2022-01-01',2
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaPaiId and "AnoEscolar" = 3 and "Ordenacao" = 1 and "Grupo" = 2);

--> Ideia
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Ideia','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', perguntaPaiId)
returning "Id" into perguntaId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--> Resultado
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Resultado','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', perguntaPaiId)
returning "Id" into perguntaId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 3º Ano - CA - Ordem 2

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Transformação','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaPaiId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia", "Grupo")
select uuid_generate_v4()::text, perguntaPaiId, 3,2,'2022-01-01',2
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaPaiId and "AnoEscolar" = 3 and "Ordenacao" = 2 and "Grupo" = 2);

--> Ideia
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Ideia','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', perguntaPaiId)
returning "Id" into perguntaId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--> Resultado
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Resultado','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', perguntaPaiId)
returning "Id" into perguntaId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 3º Ano - CA - Ordem 3

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Comparação','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaPaiId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia", "Grupo")
select uuid_generate_v4()::text, perguntaPaiId, 3,3,'2022-01-01',2
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaPaiId and "AnoEscolar" = 3 and "Ordenacao" = 3 and "Grupo" = 2);

--> Ideia
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Ideia','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', perguntaPaiId)
returning "Id" into perguntaId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--> Resultado
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Resultado','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', perguntaPaiId)
returning "Id" into perguntaId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 3º Ano - CM - Ordem 4

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Configuração Retangular','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaPaiId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia", "Grupo")
select uuid_generate_v4()::text, perguntaPaiId, 3,4,'2022-01-01',3
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaPaiId and "AnoEscolar" = 3 and "Ordenacao" = 4 and "Grupo" = 3);

--> Ideia
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Ideia','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', perguntaPaiId)
returning "Id" into perguntaId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--> Resultado
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Resultado','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', perguntaPaiId)
returning "Id" into perguntaId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> 3º Ano - CM - Ordem 5

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Proporcionalidade','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', null)
returning "Id" into perguntaPaiId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia", "Grupo")
select uuid_generate_v4()::text, perguntaPaiId, 3,5,'2022-01-01',3
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaPaiId and "AnoEscolar" = 3 and "Ordenacao" = 5 and "Grupo" = 3);

--> Ideia
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Ideia','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', perguntaPaiId)
returning "Id" into perguntaId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--> Resultado
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId", "PerguntaId") 
values (uuid_generate_v4()::text,'Resultado','9f3d8467-2f6e-4bcb-a8e9-12e840426aba', perguntaPaiId)
returning "Id" into perguntaId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou';	

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

end $$;
