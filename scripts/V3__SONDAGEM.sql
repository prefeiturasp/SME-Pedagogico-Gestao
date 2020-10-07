update public."Grupo" set "OrdemVisivel" = true
where "Id" = 'e27b99a3-789d-43fb-a962-7df8793622b1';

alter table public."SondagemAutoral"
add column "SequenciaDeOrdemSalva" int4;

alter table public."Ordem"
add column "Ordenacao" int4;

update public."Ordem" set "Ordenacao" = 1 
where "Id" = 'ad53a26a-e9d5-4732-a086-212dc20f3af7';

update public."Ordem" set "Ordenacao" = 2
where "Id" = '2382e530-c426-46fe-83b6-84461257aabc';

update public."Ordem" set "Ordenacao" = 3
where "Id" = '9913da2a-dc3d-45e6-a1e5-34b386cc1202';

update public."Ordem" set "Ordenacao" = 4
where "Id" = 'd0fcd18f-d626-4ca1-900d-6f85b1ad690f';

update public."Ordem" set "Ordenacao" = 5
where "Id" = 'f4213141-94b9-4b91-a65f-56348a3f8399';

update public."Ordem" set "Ordenacao" = 6
where "Id" = '9467c76f-4b87-43be-93d6-d243e6a856ec';

alter table public."OrdemPergunta"
add column "OrdenacaoNaTela" int4;

UPDATE public."OrdemPergunta"
SET   "OrdenacaoNaTela"= 1
WHERE "Id"='fb4412f8-a56c-4440-ad91-ce762bc6eb2a';

  
UPDATE public."OrdemPergunta"
SET   "OrdenacaoNaTela"= 2
WHERE "Id"='891d3995-910c-4392-a7d4-36e7261d74de';

UPDATE public."OrdemPergunta"
SET   "OrdenacaoNaTela"= 3
WHERE "Id"='6e48d99e-cd0c-452a-a6a4-cee5842b4909';

UPDATE public."OrdemPergunta"
SET   "OrdenacaoNaTela"= 1
WHERE "Id"='dddd37bf-b6a4-42e7-94f6-d02c9ce96fd4';

UPDATE public."OrdemPergunta"
SET   "OrdenacaoNaTela"= 2
WHERE "Id"= '616654b0-04cf-426c-984f-910606da8af5';

UPDATE public."OrdemPergunta"
SET   "OrdenacaoNaTela"= 3
WHERE "Id"= '5b2c2243-f4ce-4780-b0f2-c9735b216fd4';

UPDATE public."OrdemPergunta"
SET   "OrdenacaoNaTela"= 1
WHERE "Id"= 'edf2d1dc-aadd-4142-aaae-535049f8fe7a';

UPDATE public."OrdemPergunta"
SET   "OrdenacaoNaTela"= 2
WHERE "Id"= '97d31bca-c1e5-4d6d-a486-3803d12c55f2';

UPDATE public."OrdemPergunta"
SET   "OrdenacaoNaTela"= 3
WHERE "Id"= 'af51f6ef-99fe-4b9a-93eb-a80b877e6849';

-----------------------------------




--Novas Ordens

INSERT INTO public."Ordem"
("Id", "Descricao", "GrupoId", "Excluido", "Ordenacao")
VALUES('dd4092b6-3716-43c9-9bf4-3f7a6a283320', 'Ordem Produção de texto', '263b55b8-efa2-480c-80ad-f4e8f0935e12', false, 1);

INSERT INTO public."Ordem"
("Id", "Descricao", "GrupoId", "Excluido", "Ordenacao")
VALUES('fcadf49b-1aae-433d-a34e-66281b5de6a6', 'Leitura em voz alta', '6a3d323a-2c44-4052-ba68-13a8dead299a', false, 1);

-- Relacao Grupo Ordem Producao de Texto
INSERT INTO public."GrupoOrdem"
("Id", "GrupoId", "OrdemId", "Ordenacao", "Excluido")
VALUES('a5cba7c6-c345-4ffc-a2db-31e6f6a81093', '263b55b8-efa2-480c-80ad-f4e8f0935e12', 'dd4092b6-3716-43c9-9bf4-3f7a6a283320', 1, false);

-- Relacao Grupo Ordem Leitura em voz alta
INSERT INTO public."GrupoOrdem"
("Id", "GrupoId", "OrdemId", "Ordenacao", "Excluido")
VALUES('9fc4f6b1-aba5-4bbf-872d-ed9e5d750cbf', '6a3d323a-2c44-4052-ba68-13a8dead299a', 'fcadf49b-1aae-433d-a34e-66281b5de6a6', 1, false);


--Perguntas
--Leitura em voz alta
INSERT INTO public."Pergunta"
("Id", "Descricao", "ComponenteCurricularId", "Excluido")
VALUES('0bf845cc-29dc-45ec-8bf2-8981cef616df', 'Não conseguiu ou não quis ler', 'c65b2c0a-7a58-4d40-b474-23f0982f14b1', false);

INSERT INTO public."Pergunta"
("Id", "Descricao", "ComponenteCurricularId", "Excluido")
VALUES('49c26883-e717-44aa-9aab-1bd8aa870916', 'Leu com muita dificuldade', 'c65b2c0a-7a58-4d40-b474-23f0982f14b1', false);

INSERT INTO public."Pergunta"
("Id", "Descricao", "ComponenteCurricularId", "Excluido")
VALUES('0b38221a-9d50-4cdf-abbd-a9ac092dbe70', 'Leu com alguma fluência', 'c65b2c0a-7a58-4d40-b474-23f0982f14b1', false);

INSERT INTO public."Pergunta"
("Id", "Descricao", "ComponenteCurricularId", "Excluido")
VALUES('18d148be-d83c-4f24-9d03-dc003a05b9e4', 'Leu com fluência', 'c65b2c0a-7a58-4d40-b474-23f0982f14b1', false);

INSERT INTO public."Pergunta"
("Id", "Descricao", "ComponenteCurricularId", "Excluido")
VALUES('0ef5e05f-a366-4da1-b6c0-594ae45f57e5', 'Não resolveu', 'c65b2c0a-7a58-4d40-b474-23f0982f14b1', false);

--Produção de texto escrito

INSERT INTO public."Pergunta"
("Id", "Descricao", "ComponenteCurricularId", "Excluido")
VALUES('cfec69be-16fb-453d-8c47-fd5ebc4161ef', 'Escrita não alfabética', 'c65b2c0a-7a58-4d40-b474-23f0982f14b1', false);

INSERT INTO public."Pergunta"
("Id", "Descricao", "ComponenteCurricularId", "Excluido")
VALUES('ef0e79cd-dc31-4272-ad04-68f79a3a135d', 'Dificuldades com aspectos semânticos', 'c65b2c0a-7a58-4d40-b474-23f0982f14b1', false);

INSERT INTO public."Pergunta"
("Id", "Descricao", "ComponenteCurricularId", "Excluido")
VALUES('f4aae748-bfd8-482e-aee0-07a1cdad71ff', 'Dificuldades com aspectos textuais', 'c65b2c0a-7a58-4d40-b474-23f0982f14b1', false);

INSERT INTO public."Pergunta"
("Id", "Descricao", "ComponenteCurricularId", "Excluido")
VALUES('67a791d2-089d-40ee-8ddf-c64454ee5c54', 'Dificuldades com aspectos ortográficos e notacionais', 'c65b2c0a-7a58-4d40-b474-23f0982f14b1', false);

-- Respostas 

INSERT INTO public."Resposta"
("Id", "Descricao", "Excluido")
VALUES('68cdf94d-8087-4b80-b2f6-c4545b1cdd19', 'true', false);

INSERT INTO public."Resposta"
("Id", "Descricao", "Excluido")
VALUES('ffc9d8ca-e534-42af-97a9-411543832c7b', 'false', false);

-- PerguntaResposta
-- Resposta true

INSERT INTO public."PerguntaResposta"
("Id", "PerguntaId", "RespostaId", "Ordenacao", "Excluido")
VALUES('d09eca97-8212-466e-91ba-7884b5ecedbd', '18d148be-d83c-4f24-9d03-dc003a05b9e4', '68cdf94d-8087-4b80-b2f6-c4545b1cdd19', 1, false);

INSERT INTO public."PerguntaResposta"
("Id", "PerguntaId", "RespostaId", "Ordenacao", "Excluido")
VALUES('b5fd7d71-d43c-4905-84d4-ced19404305c', '0bf845cc-29dc-45ec-8bf2-8981cef616df', '68cdf94d-8087-4b80-b2f6-c4545b1cdd19', 1, false);

INSERT INTO public."PerguntaResposta"
("Id", "PerguntaId", "RespostaId", "Ordenacao", "Excluido")
VALUES('1ac20dbb-2f19-4a33-a15d-0d83e62c7740', '49c26883-e717-44aa-9aab-1bd8aa870916', '68cdf94d-8087-4b80-b2f6-c4545b1cdd19', 1, false);

INSERT INTO public."PerguntaResposta"
("Id", "PerguntaId", "RespostaId", "Ordenacao", "Excluido")
VALUES('e67a0618-6b74-4d51-8aef-90d93d9149c2', '0b38221a-9d50-4cdf-abbd-a9ac092dbe70', '68cdf94d-8087-4b80-b2f6-c4545b1cdd19', 1, false);

INSERT INTO public."PerguntaResposta"
("Id", "PerguntaId", "RespostaId", "Ordenacao", "Excluido")
VALUES('302a0663-fd24-4875-9494-cb2db671fe5a', '0ef5e05f-a366-4da1-b6c0-594ae45f57e5', '68cdf94d-8087-4b80-b2f6-c4545b1cdd19', 1, false);

INSERT INTO public."PerguntaResposta"
("Id", "PerguntaId", "RespostaId", "Ordenacao", "Excluido")
VALUES('6f7f2765-d2c8-4f2d-ab6a-42ae81839f01', 'cfec69be-16fb-453d-8c47-fd5ebc4161ef', '68cdf94d-8087-4b80-b2f6-c4545b1cdd19', 1, false);

INSERT INTO public."PerguntaResposta"
("Id", "PerguntaId", "RespostaId", "Ordenacao", "Excluido")
VALUES('87c4ea90-4fe3-44d8-a340-5c551ec2644d', 'ef0e79cd-dc31-4272-ad04-68f79a3a135d', '68cdf94d-8087-4b80-b2f6-c4545b1cdd19', 1, false);

INSERT INTO public."PerguntaResposta"
("Id", "PerguntaId", "RespostaId", "Ordenacao", "Excluido")
VALUES('6d54e18a-fc7d-44d7-aefc-ed23531d1324', 'f4aae748-bfd8-482e-aee0-07a1cdad71ff', '68cdf94d-8087-4b80-b2f6-c4545b1cdd19', 1, false);

INSERT INTO public."PerguntaResposta"
("Id", "PerguntaId", "RespostaId", "Ordenacao", "Excluido")
VALUES('8bbd9c17-bb86-47b6-8d28-cafd55bb6adb', '67a791d2-089d-40ee-8ddf-c64454ee5c54', '68cdf94d-8087-4b80-b2f6-c4545b1cdd19', 1, false);
-- PerguntaResposta
-- Resposta false

INSERT INTO public."PerguntaResposta"
("Id", "PerguntaId", "RespostaId", "Ordenacao", "Excluido")
VALUES('9298156a-be71-44aa-a909-3f25551b8f44', '18d148be-d83c-4f24-9d03-dc003a05b9e4', 'ffc9d8ca-e534-42af-97a9-411543832c7b', 2, false);

INSERT INTO public."PerguntaResposta"
("Id", "PerguntaId", "RespostaId", "Ordenacao", "Excluido")
VALUES('b963f904-c466-45f7-8aae-a4ac0d8aa416', '0bf845cc-29dc-45ec-8bf2-8981cef616df', 'ffc9d8ca-e534-42af-97a9-411543832c7b', 2, false);

INSERT INTO public."PerguntaResposta"
("Id", "PerguntaId", "RespostaId", "Ordenacao", "Excluido")
VALUES('512b9356-ee7f-411b-abf3-bac3375d813e', '49c26883-e717-44aa-9aab-1bd8aa870916', 'ffc9d8ca-e534-42af-97a9-411543832c7b', 2, false);

INSERT INTO public."PerguntaResposta"
("Id", "PerguntaId", "RespostaId", "Ordenacao", "Excluido")
VALUES('ac26c542-4188-44e2-b29d-5d5a1345e91b', '0b38221a-9d50-4cdf-abbd-a9ac092dbe70', 'ffc9d8ca-e534-42af-97a9-411543832c7b', 2, false);

INSERT INTO public."PerguntaResposta"
("Id", "PerguntaId", "RespostaId", "Ordenacao", "Excluido")
VALUES('847b2b71-d6c8-495f-a7cf-1d8298aa3730', '0ef5e05f-a366-4da1-b6c0-594ae45f57e5', 'ffc9d8ca-e534-42af-97a9-411543832c7b', 2, false);

INSERT INTO public."PerguntaResposta"
("Id", "PerguntaId", "RespostaId", "Ordenacao", "Excluido")
VALUES('1f2fe62f-84cf-4ab7-99cb-ea41daeff0b1', 'cfec69be-16fb-453d-8c47-fd5ebc4161ef', 'ffc9d8ca-e534-42af-97a9-411543832c7b', 2, false);

INSERT INTO public."PerguntaResposta"
("Id", "PerguntaId", "RespostaId", "Ordenacao", "Excluido")
VALUES('a4ca1b9a-ade0-4fb8-9622-3890a8d90c46', 'ef0e79cd-dc31-4272-ad04-68f79a3a135d', 'ffc9d8ca-e534-42af-97a9-411543832c7b', 2, false);

INSERT INTO public."PerguntaResposta"
("Id", "PerguntaId", "RespostaId", "Ordenacao", "Excluido")
VALUES('f055c585-d41d-43af-b887-8ec3a0e55f21', 'f4aae748-bfd8-482e-aee0-07a1cdad71ff', 'ffc9d8ca-e534-42af-97a9-411543832c7b', 2, false);

INSERT INTO public."PerguntaResposta"
("Id", "PerguntaId", "RespostaId", "Ordenacao", "Excluido")
VALUES('f42fbdfb-d6ab-4f12-b534-0f25c0f83c94', '67a791d2-089d-40ee-8ddf-c64454ee5c54', 'ffc9d8ca-e534-42af-97a9-411543832c7b', 2, false);

--OrdemPergunta

INSERT INTO public."OrdemPergunta"
("Id", "SequenciaOrdem", "PerguntaId", "Excluido", "OrdenacaoNaTela")
VALUES('73c1a6fd-3c3d-4787-bce1-24765b89a709', 1, '0bf845cc-29dc-45ec-8bf2-8981cef616d', false, 1);

INSERT INTO public."OrdemPergunta"
("Id", "SequenciaOrdem", "PerguntaId", "Excluido", "OrdenacaoNaTela")
VALUES('c83f7155-b036-4904-85a0-42bd08eb746e', 1, '49c26883-e717-44aa-9aab-1bd8aa870916', false, 2);

INSERT INTO public."OrdemPergunta"
("Id", "SequenciaOrdem", "PerguntaId", "Excluido", "OrdenacaoNaTela")
VALUES('26d231df-121d-4c0e-92be-7415916e0c53', 1, '0b38221a-9d50-4cdf-abbd-a9ac092dbe70', false, 3);

INSERT INTO public."OrdemPergunta"
("Id", "SequenciaOrdem", "PerguntaId", "Excluido", "OrdenacaoNaTela")
VALUES('5c283e6a-380e-43dc-a63e-3bdf0da266d9', 1, '18d148be-d83c-4f24-9d03-dc003a05b9e4', false, 4);


INSERT INTO public."OrdemPergunta"
("Id", "SequenciaOrdem", "PerguntaId", "Excluido", "OrdenacaoNaTela")
VALUES('9bd3885a-5979-4b07-95f8-4755c9ea3362', 1, '0ef5e05f-a366-4da1-b6c0-594ae45f57e5', false, 5);

-- Relacionamento entre OrdemPergunta e Grupo

INSERT INTO public."OrdemPergunta"
("Id", "SequenciaOrdem", "PerguntaId", "Excluido", "OrdenacaoNaTela")
VALUES('cb512711-007d-49e8-8ede-49a5fad841cb', 1, 'cfec69be-16fb-453d-8c47-fd5ebc4161ef', false, 1);

INSERT INTO public."OrdemPergunta"
("Id", "SequenciaOrdem", "PerguntaId", "Excluido", "OrdenacaoNaTela")
VALUES('b7b6eb1f-f583-4580-8388-0a3e492dfa9e', 1, 'ef0e79cd-dc31-4272-ad04-68f79a3a135d', false, 2);

INSERT INTO public."OrdemPergunta"
("Id", "SequenciaOrdem", "PerguntaId", "Excluido", "OrdenacaoNaTela")
VALUES('7ee3a73a-4325-4f86-bd33-a9215288f7e1', 1, 'f4aae748-bfd8-482e-aee0-07a1cdad71ff', false, 3);

INSERT INTO public."OrdemPergunta"
("Id", "SequenciaOrdem", "PerguntaId", "Excluido", "OrdenacaoNaTela")
VALUES('02d1c996-062a-4981-b0c9-ae65afe75637', 1, '67a791d2-089d-40ee-8ddf-c64454ee5c54', false, 4);

alter table public."OrdemPergunta" 
add column "GrupoId" text;

--- Leitura em voz alta
UPDATE public."OrdemPergunta"
SET "GrupoId"='6a3d323a-2c44-4052-ba68-13a8dead299a'
WHERE "PerguntaId" ='6a3d323a-2c44-4052-ba68-13a8dead299a';

UPDATE public."OrdemPergunta"
SET "GrupoId"='26a3d323a-2c44-4052-ba68-13a8dead299a'
WHERE "PerguntaId" ='0bf845cc-29dc-45ec-8bf2-8981cef616df';

UPDATE public."OrdemPergunta"
SET  "GrupoId"='26a3d323a-2c44-4052-ba68-13a8dead299a'
WHERE "PerguntaId" ='0ef5e05f-a366-4da1-b6c0-594ae45f57e5';

UPDATE public."OrdemPergunta"
SET "GrupoId"='26a3d323a-2c44-4052-ba68-13a8dead299a'
WHERE "PerguntaId" ='18d148be-d83c-4f24-9d03-dc003a05b9e4';

UPDATE public."OrdemPergunta"
SET "GrupoId"='26a3d323a-2c44-4052-ba68-13a8dead299a'
WHERE "PerguntaId" ='49c26883-e717-44aa-9aab-1bd8aa870916';


------ Capacidade de leitura

UPDATE public."OrdemPergunta"
SET "GrupoId"='e27b99a3-789d-43fb-a962-7df8793622b1'
WHERE "PerguntaId" ='84e946ca-a139-4adb-b0f1-6930b1f775b4';
                     
UPDATE public."OrdemPergunta"
SET "GrupoId"='e27b99a3-789d-43fb-a962-7df8793622b1'
WHERE "PerguntaId" ='9693f717-503c-4a71-bfa7-ad7a9b6ae85a';
                     
UPDATE public."OrdemPergunta"
SET "GrupoId"='e27b99a3-789d-43fb-a962-7df8793622b1'
WHERE "PerguntaId" ='24527cb2-960f-4988-a71a-0447be46a1c1';

UPDATE public."OrdemPergunta"
SET "GrupoId"='e27b99a3-789d-43fb-a962-7df8793622b1'
WHERE "PerguntaId" ='644c6c1e-81b8-4efc-985a-249b9869a230';

UPDATE public."OrdemPergunta"
SET "GrupoId"='e27b99a3-789d-43fb-a962-7df8793622b1'
WHERE "PerguntaId" ='c2a181e7-ab8a-4b80-bbdd-53557fcd9583';

--producao de Texto

UPDATE public."OrdemPergunta"
SET "GrupoId"='263b55b8-efa2-480c-80ad-f4e8f0935e12'
WHERE "PerguntaId" ='cfec69be-16fb-453d-8c47-fd5ebc4161ef';

UPDATE public."OrdemPergunta"
SET "GrupoId"='263b55b8-efa2-480c-80ad-f4e8f0935e12'
WHERE "PerguntaId" ='ef0e79cd-dc31-4272-ad04-68f79a3a135d';

UPDATE public."OrdemPergunta"
SET "GrupoId"='263b55b8-efa2-480c-80ad-f4e8f0935e12'
WHERE "PerguntaId" ='f4aae748-bfd8-482e-aee0-07a1cdad71ff';

UPDATE public."OrdemPergunta"
SET "GrupoId"='263b55b8-efa2-480c-80ad-f4e8f0935e12'
WHERE "PerguntaId" ='67a791d2-089d-40ee-8ddf-c64454ee5c54';

-------------------------------------------------------------------------------------------------------------------

CREATE TABLE public."PeridodoFixoAnual" (
	"Id" int NOT NULL GENERATED ALWAYS AS IDENTITY,
	"Ano" int4 NULL,
	"Descricao" varchar(50) NULL,
	"DataInicio" timestamp NULL,
	"DataFim" timestamp null,
	"TipoPeriodo" int4 NULL
);



INSERT INTO public."PeridodoFixoAnual"
("Ano", "Descricao", "DataInicio", "DataFim", "TipoPeriodo")
VALUES(2020, '1° Semestre', '2020-02-01 00:00:00', '2020-06-05 00:00:00', 1);

INSERT INTO public."PeridodoFixoAnual"
("Ano", "Descricao", "DataInicio", "DataFim", "TipoPeriodo")
VALUES(2020, '2° Semestre', '2020-06-05 00:00:00', '2020-12-30 00:00:00', 1);

INSERT INTO public."PeridodoFixoAnual"
("Ano", "Descricao", "DataInicio", "DataFim", "TipoPeriodo")
VALUES(2020, '1° Bimestre', '2020-02-01 00:00:00', '2020-03-30 00:00:00', 2);

INSERT INTO public."PeridodoFixoAnual"
("Ano", "Descricao", "DataInicio", "DataFim", "TipoPeriodo")
VALUES(2020, '2° Bimestre', '2020-03-30 00:00:00', '2020-06-04 00:00:00', 2);

INSERT INTO public."PeridodoFixoAnual"
("Ano", "Descricao", "DataInicio", "DataFim", "TipoPeriodo")
VALUES(2020, '3° Bimestre', '2020-06-05 00:00:00', '2020-09-30 00:00:00', 2);

INSERT INTO public."PeridodoFixoAnual"
("Ano", "Descricao", "DataInicio", "DataFim", "TipoPeriodo")
VALUES(2020, '4° Bimestre', '2020-10-01 00:00:00', '2020-12-30 00:00:00', 2);


CREATE TABLE  IF NOT EXISTS public."Sondagem" (
	"Id" uuid NOT NULL,
	"ComponenteCurricularId" text NOT NULL,
	"PeriodoId" text NOT NULL,
	"AnoTurma" int4 NOT NULL,
	"CodigoTurma" varchar(50) NOT NULL,
	"CodigoUe" varchar(50) NOT NULL,
	"CodigoDre" varchar(50) NOT NULL,
	"AnoLetivo" int4 NOT NULL,
	"OrdemId" text NULL,
	"GrupoId" text NULL,
	"SequenciaDeOrdemSalva" int4 NULL,
	CONSTRAINT "Sondagem_pkey" PRIMARY KEY ("Id")
);



-- Drop table

-- DROP TABLE public."SondagemAluno";

CREATE TABLE IF NOT EXISTS public."SondagemAluno" (
	"Id" uuid NOT NULL,
	"SondagemId" uuid NOT NULL,
	"CodigoAluno" varchar(50) NOT NULL,
	"NomeAluno" varchar(200) NOT NULL,
	CONSTRAINT "SondagemAluno_pkey" PRIMARY KEY ("Id")
);

ALTER TABLE public."SondagemAluno" ADD CONSTRAINT "fk_SondagemId" FOREIGN KEY ("SondagemId") REFERENCES "Sondagem"("Id");


CREATE TABLE  IF NOT EXISTS public."SondagemAlunoRespostas" (
	"Id" uuid NOT NULL,
	"SondagemAlunoId" uuid NOT NULL,
	"PerguntaId" text NOT NULL,
	"RespostaId" text NOT NULL,
	CONSTRAINT "SondagemAlunoRespostas_pkey" PRIMARY KEY ("Id")
);

ALTER TABLE public."SondagemAlunoRespostas" ADD CONSTRAINT "fk_SondagemAlunoId" FOREIGN KEY ("SondagemAlunoId") REFERENCES "SondagemAluno"("Id");


CREATE TABLE public."PeriodoFixoAnual" (
	"Id" int4 NOT NULL GENERATED ALWAYS AS IDENTITY,
	"Ano" int4 NULL,
	"Descricao" varchar(50) NULL,
	"DataInicio" timestamp NULL,
	"DataFim" timestamp NULL,
	"TipoPeriodo" int4 NULL,
	"PeriodoId" text NULL
);

	alter table "PeriodoFixoAnual"
	add CONSTRAINT "fk_periodo"
      FOREIGN KEY("PeriodoId") 
	  REFERENCES "Periodo"("Id");
	
	  update "PeriodoFixoAnual" set "PeriodoId" = 'c93c1c4a-abb9-43a4-a8cd-283e4df365d8'  where "Id" = 1;
	  update "PeriodoFixoAnual" set "PeriodoId" = '8de86d08-b7a1-45df-b775-07550714756b'  where "Id" = 2;
	  update "PeriodoFixoAnual" set "PeriodoId" = 'fbd8b833-d7dc-4d04-9af6-50c1aaa2f8c0'  where "Id" = 3;
	  update "PeriodoFixoAnual" set "PeriodoId" = '05ce183c-cb37-44fb-9c30-dac5ae5b8d37'  where "Id" = 4;
	  update "PeriodoFixoAnual" set "PeriodoId" = 'a8d3311a-b71e-45ce-8667-cef062334949'  where "Id" = 5;
	  update "PeriodoFixoAnual" set "PeriodoId" = 'aa7f39fc-3b50-4aea-bd05-4bbe7cba687c'  where "Id" = 6;








