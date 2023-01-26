
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo respostas

insert into public."Resposta" ("Id", "Descricao")
select uuid_generate_v4()::text,'Acertou a questão'
    where not exists (select 1 from public."Resposta" where "Descricao" = 'Acertou a questão');   

insert into public."Resposta" ("Id", "Descricao")
select uuid_generate_v4()::text,'Acertou parcialmente a questão'
    where not exists (select 1 from public."Resposta" where "Descricao" = 'Acertou parcialmente a questão');

insert into public."Resposta" ("Id", "Descricao")
select uuid_generate_v4()::text,'Errou a questão'
    where not exists (select 1 from public."Resposta" where "Descricao" = 'Errou a questão');   

insert into public."Resposta" ("Id", "Descricao")
select uuid_generate_v4()::text,'Sim'
    where not exists (select 1 from public."Resposta" where "Descricao" = 'Sim');   
   
insert into public."Resposta" ("Id", "Descricao")
select uuid_generate_v4()::text,'Não'
    where not exists (select 1 from public."Resposta" where "Descricao" = 'Não');      
   
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 4º Ano

do $$
declare
respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
--> Questão 1
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 1:Resolver problemas do Eixo Números','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4, 1, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 1)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 2
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 2:Resolver problemas do  Eixo Álgebra','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4, 2, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 2)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 3
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 3:Resolver problemas do Eixo Probabilidade e Estatística','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4, 3, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 3)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 4
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 4:Resolver problemas do Eixo Geometria','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4, 4, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 4)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 5
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 5:Resolver problemas do Eixo Grandezas e Medidas','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4, 5, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 5)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 6
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 6:O estudante participa dos projetos de recuperação paralela?','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4, 6, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 6)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Sim';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 5º Ano

do $$
declare
respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
--> Questão 1
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 1:Resolver problemas do Eixo Números','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5, 1, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 1)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 2
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 2:Resolver problemas do  Eixo Álgebra','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5, 2, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 2)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 3
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 3:Resolver problemas do Eixo Probabilidade e Estatística','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5, 3, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 3)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 4
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 4:Resolver problemas do Eixo Geometria','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5, 4, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 4)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 5
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 5:Resolver problemas do Eixo Grandezas e Medidas','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5, 5, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 5)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 6
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 6:O estudante participa dos projetos de recuperação paralela?','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5, 6, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 6)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Sim';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 6º Ano

do $$
declare
respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
--> Questão 1
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 1:Resolver problemas do Eixo Números','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 6, 1, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 6 and "Ordenacao" = 1)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 2
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 2:Resolver problemas do  Eixo Álgebra','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 6, 2, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 6 and "Ordenacao" = 2)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 3
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 3:Resolver problemas do Eixo Probabilidade e Estatística','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 6, 3, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 6 and "Ordenacao" = 3)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 4
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 4:Resolver problemas do Eixo Geometria','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 6, 4, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 6 and "Ordenacao" = 4)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 5
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 5:Resolver problemas do Eixo Grandezas e Medidas','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 6, 5, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 6 and "Ordenacao" = 5)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 6
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 6:O estudante participa dos projetos de recuperação paralela?','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 6, 6, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 6 and "Ordenacao" = 6)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Sim';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 7º Ano

do $$
declare
respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
--> Questão 1
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 1:Resolver problemas do Eixo Números','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 7, 1, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 7 and "Ordenacao" = 1)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 2
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 2:Resolver problemas do  Eixo Álgebra','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 7, 2, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 7 and "Ordenacao" = 2)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 3
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 3:Resolver problemas do Eixo Probabilidade e Estatística','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 7, 3, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 7 and "Ordenacao" = 3)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 4
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 4:Resolver problemas do Eixo Geometria','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 7, 4, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 7 and "Ordenacao" = 4)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 5
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 5:Resolver problemas do Eixo Grandezas e Medidas','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 7, 5, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 7 and "Ordenacao" = 5)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 6
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 6:O estudante participa dos projetos de recuperação paralela?','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 7, 6, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 7 and "Ordenacao" = 6)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Sim';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 8º Ano

do $$
declare
respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
--> Questão 1
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 1:Resolver problemas do Eixo Números','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 8, 1, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 8 and "Ordenacao" = 1)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 2
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 2:Resolver problemas do  Eixo Álgebra','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 8, 2, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 8 and "Ordenacao" = 2)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 3
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 3:Resolver problemas do Eixo Probabilidade e Estatística','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 8, 3, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 8 and "Ordenacao" = 3)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 4
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 4:Resolver problemas do Eixo Geometria','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 8, 4, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 8 and "Ordenacao" = 4)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 5
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 5:Resolver problemas do Eixo Grandezas e Medidas','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 8, 5, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 8 and "Ordenacao" = 5)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 6
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 6:O estudante participa dos projetos de recuperação paralela?','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 8, 6, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 8 and "Ordenacao" = 6)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Sim';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 9º Ano

do $$
declare
respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
--> Questão 1
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 1:Resolver problemas do Eixo Números','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 9, 1, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 9 and "Ordenacao" = 1)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 2
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 2:Resolver problemas do  Eixo Álgebra','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 9, 2, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 9 and "Ordenacao" = 2)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 3
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 3:Resolver problemas do Eixo Probabilidade e Estatística','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 9, 3, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 9 and "Ordenacao" = 3)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 4
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 4:Resolver problemas do Eixo Geometria','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 9, 4, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 9 and "Ordenacao" = 4)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 5
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 5:Resolver problemas do Eixo Grandezas e Medidas','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 9, 5, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 9 and "Ordenacao" = 5)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou parcialmente a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Errou a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);


--> Questão 6
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Questão 6:O estudante participa dos projetos de recuperação paralela?','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
    returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 9, 6, '2023-01-01'
    where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 9 and "Ordenacao" = 6)
returning "Id" into perguntaAnoEscolarId;

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Sim';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

end $$; 