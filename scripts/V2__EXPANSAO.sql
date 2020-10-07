CREATE TABLE if not exists public."ComponenteCurricular" (
	"Id" text NOT NULL  primary key,
	"Descricao" varchar(100) NOT NULL,
	"Excluido" boolean NOT NULL DEFAULT false
);

CREATE TABLE if not exists public."Pergunta" (
	"Id" text NOT NULL  primary key,
	"Descricao" varchar(200) NOT NULL,
	"ComponenteCurricularId" varchar NOT NULL,
	"Excluido" boolean NOT NULL DEFAULT false
);

CREATE TABLE if not exists public."Resposta" (
	"Id" text NOT NULL  primary key,
	"Descricao" varchar(200) NOT NULL,
	"Excluido" boolean NOT NULL DEFAULT false
);

CREATE TABLE public."PerguntaResposta" (
	"Id" text NOT NULL  primary key,
	"PerguntaId" text NOT NULL,
	"RespostaId" text NOT NULL,
	"Ordenacao" int4 NOT NULL,
	"Excluido" boolean NOT NULL DEFAULT false
);


CREATE TABLE if not exists public."PerguntaAnoEscolar" (
	"Id" text NOT NULL  primary key,
	"PerguntaId" text NOT NULL,
	"AnoEscolar" int4 NOT NULL,
	"Ordenacao" int4 NOT NULL,
	"Excluido" boolean NOT NULL DEFAULT false
);

CREATE TABLE public."Grupo" (
	"Id" text NOT NULL  primary key,
	"Descricao" varchar(200) NOT NULL,
	"Excluido" boolean NOT NULL DEFAULT false,
	"OrdemVisivel" bool default false
);

CREATE TABLE if not exists public."Ordem" (
	"Id" text NOT NULL  primary key,
	"Descricao" varchar(200) NOT NULL,
	"GrupoId" text NOT NULL,
	"Excluido" boolean NOT NULL DEFAULT false
);

CREATE TABLE if not exists public."OrdemPergunta" (
	"Id" text NOT NULL  primary key,
	"SequenciaOrdem" int4 NOT NULL,
	"PerguntaId" text NOT NULL,
	"Excluido" boolean NOT NULL DEFAULT false
);

CREATE TABLE if not exists public."Periodo" (
	"Id" text NOT NULL  primary key,
	"Descricao" varchar(200) NOT NULL,
	"TipoPeriodo" int4 NOT NULL,
	"Excluido" boolean NOT NULL DEFAULT false
);

CREATE TABLE if not exists public."SondagemAutoral" (
	"Id" text NOT NULL  primary key,
	"ComponenteCurricularId" text NOT NULL,
	"PerguntaId" text NOT NULL,
	"RespostaId" text DEFAULT NULL,
	"CodigoAluno" varchar(50) NOT NULL,
	"NomeAluno" varchar(200) NOT NULL,
	"CodigoDre" varchar(50) NOT NULL,
	"CodigoUe" varchar(50) NOT NULL,
	"CodigoTurma" varchar(50) NOT NULL,
	"GrupoId" text NULL,
	"OrdemId" text NULL,
	"AnoTurma" int4 NOT NULL,
	"AnoLetivo" int4 NOT NULL,
	"PeriodoId" text NOT NULL
);

CREATE TABLE public."GrupoOrdem" (
	"Id" text NOT NULL  primary key,
	"GrupoId" text NOT NULL,
	"OrdemId" text NOT NULL,
	"Ordenacao" int4 NOT NULL,
	"Excluido" boolean NOT NULL DEFAULT false
);

create extension if not exists "uuid-ossp";

INSERT INTO public."ComponenteCurricular" ("Id","Descricao")
	VALUES ('c65b2c0a-7a58-4d40-b474-23f0982f14b1','Língua portuguesa');
INSERT INTO public."ComponenteCurricular" ("Id","Descricao")
	VALUES ('9f3d8467-2f6e-4bcb-a8e9-12e840426aba','Matemática');
	
-- Auto-generated SQL script #202008201858
INSERT INTO public."Pergunta" ("Id","Descricao","ComponenteCurricularId")
	VALUES ('d53ba946-fb3d-4b20-8883-0f7dbab3bddb','Problema de lógica','9f3d8467-2f6e-4bcb-a8e9-12e840426aba');
INSERT INTO public."Pergunta" ("Id","Descricao","ComponenteCurricularId")
	VALUES ('9d60c205-9a55-4f17-9254-b1d760d172fd','Área e perímetro ','9f3d8467-2f6e-4bcb-a8e9-12e840426aba');
INSERT INTO public."Pergunta" ("Id","Descricao","ComponenteCurricularId")
	VALUES ('13eb098b-c9a6-46c5-b5cb-f4549cef94f0','Sólidos geométricos','9f3d8467-2f6e-4bcb-a8e9-12e840426aba');
INSERT INTO public."Pergunta" ("Id","Descricao","ComponenteCurricularId")
	VALUES ('21d6ae6b-f41e-4712-b71f-02cfc709e973','Relações entre grandezas e porcentagem','9f3d8467-2f6e-4bcb-a8e9-12e840426aba');
INSERT INTO public."Pergunta" ("Id","Descricao","ComponenteCurricularId")
	VALUES ('ef810828-770d-4fa4-bde2-31f31fb48337','Média, moda e mediana','9f3d8467-2f6e-4bcb-a8e9-12e840426aba');
INSERT INTO public."Pergunta" ("Id","Descricao","ComponenteCurricularId")
	VALUES ('0f3609b2-309c-475a-a097-a38f3cf7498d','Triângulos e quadriláteros','9f3d8467-2f6e-4bcb-a8e9-12e840426aba');
INSERT INTO public."Pergunta" ("Id","Descricao","ComponenteCurricularId")
	VALUES ('67d7fd9f-4717-4a5f-9c8a-9f95338d005a','Probabilidade','9f3d8467-2f6e-4bcb-a8e9-12e840426aba');
INSERT INTO public."Pergunta" ("Id","Descricao","ComponenteCurricularId")
	VALUES ('1ed6a3a8-e85e-4103-9187-1f8ee3f460ab','Regularidade e generalização','9f3d8467-2f6e-4bcb-a8e9-12e840426aba');
	
INSERT INTO public."Pergunta" ("Id","Descricao","ComponenteCurricularId")
	VALUES ('9693f717-503c-4a71-bfa7-ad7a9b6ae85a','Localização','c65b2c0a-7a58-4d40-b474-23f0982f14b1');
INSERT INTO public."Pergunta" ("Id","Descricao","ComponenteCurricularId")
	VALUES ('644c6c1e-81b8-4efc-985a-249b9869a230','Inferência Local','c65b2c0a-7a58-4d40-b474-23f0982f14b1');
INSERT INTO public."Pergunta" ("Id","Descricao","ComponenteCurricularId")
	VALUES ('84e946ca-a139-4adb-b0f1-6930b1f775b4','Reflexão','c65b2c0a-7a58-4d40-b474-23f0982f14b1');
INSERT INTO public."Pergunta" ("Id","Descricao","ComponenteCurricularId")
	VALUES ('c2a181e7-ab8a-4b80-bbdd-53557fcd9583','Inferência Global','c65b2c0a-7a58-4d40-b474-23f0982f14b1');
INSERT INTO public."Pergunta" ("Id","Descricao","ComponenteCurricularId")
	VALUES ('24527cb2-960f-4988-a71a-0447be46a1c1','Generalização ','c65b2c0a-7a58-4d40-b474-23f0982f14b1');

INSERT INTO public."Resposta" ("Id","Descricao") 
	VALUES('c48be0b2-df68-4314-b680-27c1bd190e51','Classificou corretamente o triângulo e parcialmente o quadrilátero');
INSERT INTO public."Resposta" ("Id","Descricao") 
	VALUES('8fe12714-a68f-4135-be5f-2e448d8e4cf1','Classificou parcialmente o triângulo e o quadrilátero');
INSERT INTO public."Resposta" ("Id","Descricao") 
	VALUES('ffa53f05-b71e-4ef8-9b10-7c932ca681db','Compreende o que é perímetro, mas não compreende o que é área');
INSERT INTO public."Resposta" ("Id","Descricao") 
	VALUES('84880d69-abbc-460c-a68b-44897f9d93ea','Compreende o que é perímetro, mas não compreende o que é área.');
INSERT INTO public."Resposta" ("Id","Descricao") 
	VALUES('aae9c109-bdb5-4391-b513-e5fd68d39d5a','Compreende o que é área, mas não compreende o que é perímetro');
INSERT INTO public."Resposta" ("Id","Descricao") 
	VALUES('80d96e10-6be4-4ba4-8a84-4a7135e09b59','Identificou corretamente a proporcionalidade e indicou a porcentagem corretamente, mas errou os cálculos');
INSERT INTO public."Resposta" ("Id","Descricao") 
	VALUES('22cbd4e4-582f-46c4-a2ee-ff4f387453bc','Identificou corretamente as três medidas de tendência central, mas erros os cálculos');
INSERT INTO public."Resposta" ("Id","Descricao") 
	VALUES('7abb0305-441f-4d40-baea-4cc3f13a1a50','Identificou os nomes das figuras e não determinou elementos de poliedros corretamente');
INSERT INTO public."Resposta" ("Id","Descricao") 
	VALUES('05df369b-14ff-4eee-9c45-d87c54e2a995','Não identificou a probabilidade');
INSERT INTO public."Resposta" ("Id","Descricao") 
	VALUES('91c73b09-4ae9-4305-92bd-efa68ed9a4db','Não identificou corretamente a proporcionalidade e indicou incorretamente a porcentagem');
INSERT INTO public."Resposta" ("Id","Descricao") 
	VALUES('0218ff47-5565-426c-8d12-07090a1b4ec9','Não identificou nomes de figuras e não determinou elementos de poliedros corretamente');
INSERT INTO public."Resposta" ("Id","Descricao") 
	VALUES('56da5097-d043-475e-a083-edcec0a94fdc','Não identificou uma ou mais medidas de tendência central');
INSERT INTO public."Resposta" ("Id","Descricao") 
	VALUES('0dd19700-303b-46d8-bbc6-48b0c32ac090','Não percebeu a regularidade e nem expressou a generalização por meio de uma expressão algébrica');
INSERT INTO public."Resposta" ("Id","Descricao") 
	VALUES('a04c7a11-52d7-4fbc-9115-2df00eda1ad2','Não registrou');
INSERT INTO public."Resposta" ("Id","Descricao") 
	VALUES('4b9718e1-62e6-413c-ba46-b3dbc4989cb7','Percebeu a regularidade, mas não expressou a generalização por meio de uma expressão algébrica');
INSERT INTO public."Resposta" ("Id","Descricao") 
	VALUES('02483544-6b27-4807-a124-2a1bbd1b24de','Representou corretamente a probabilidade na forma fracionária, mas errou as formas decimal e/ou percentual');
INSERT INTO public."Resposta" ("Id","Descricao") 
	VALUES('bc66297b-3f3a-4d8d-b6c4-ceea1696bc11','Resolveu corretamente');
INSERT INTO public."Resposta" ("Id","Descricao") 
	VALUES('66f5ce70-bd0a-4591-bfa2-ab36d8b62284','Resolveu corretamente.');
INSERT INTO public."Resposta" ("Id","Descricao") 
	VALUES('53911083-6799-4553-8e5e-3eaadec17a55','Resolveu o problema incorretamente');
INSERT INTO public."Resposta" ("Id","Descricao") 
	VALUES('04695943-0abf-4dd7-b8b8-9e850f5d8d2e','Resolveu uma parte do problema corretamente');
INSERT INTO public."Resposta" ("Id","Descricao")
	VALUES ('ca6efe5b-d00b-436c-873f-fd31f913c644','Adequada');
INSERT INTO public."Resposta" ("Id","Descricao")
	VALUES ('3b877537-a423-4e4d-89d7-ed46f4cc25c7','Inadequada');
INSERT INTO public."Resposta" ("Id","Descricao")
	VALUES ('9dfd9097-1d0a-4859-9852-c9b491a42c81','Não resolveu');


INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('7d071fc3-accc-4133-8cbf-1f20332ff5c1','d53ba946-fb3d-4b20-8883-0f7dbab3bddb','bc66297b-3f3a-4d8d-b6c4-ceea1696bc11',1);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('a11ad326-34f1-4bb9-9dbe-5fb8ef049514','d53ba946-fb3d-4b20-8883-0f7dbab3bddb','04695943-0abf-4dd7-b8b8-9e850f5d8d2e',2);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('cb133766-a446-4c95-a65d-2d26b1a4068a','d53ba946-fb3d-4b20-8883-0f7dbab3bddb','53911083-6799-4553-8e5e-3eaadec17a55',3);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('8320dc58-bef3-4f3c-b077-7ce54e6a5d09','d53ba946-fb3d-4b20-8883-0f7dbab3bddb','a04c7a11-52d7-4fbc-9115-2df00eda1ad2',4);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('aff9e7c3-3a5d-45c3-8f54-aab5315761b6','9d60c205-9a55-4f17-9254-b1d760d172fd','bc66297b-3f3a-4d8d-b6c4-ceea1696bc11',1);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('fc4eeadb-0d13-4e2b-8b56-4a90e10c9709','9d60c205-9a55-4f17-9254-b1d760d172fd','aae9c109-bdb5-4391-b513-e5fd68d39d5a',2);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('bbc15078-22bf-4262-8b08-cc7b3634fcb6','9d60c205-9a55-4f17-9254-b1d760d172fd','ffa53f05-b71e-4ef8-9b10-7c932ca681db',3);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('238b0422-8337-408d-a4a2-d9e15b20e999','9d60c205-9a55-4f17-9254-b1d760d172fd','a04c7a11-52d7-4fbc-9115-2df00eda1ad2',4);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('73f07fca-500f-40ef-be9f-986552ec116d','13eb098b-c9a6-46c5-b5cb-f4549cef94f0','bc66297b-3f3a-4d8d-b6c4-ceea1696bc11',1);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('ce762d7b-87f7-43e8-a3b9-473c2d9dd3b6','13eb098b-c9a6-46c5-b5cb-f4549cef94f0','7abb0305-441f-4d40-baea-4cc3f13a1a50',2);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('bfe55343-993f-4d5a-aa45-3cdc33e774a0','13eb098b-c9a6-46c5-b5cb-f4549cef94f0','0218ff47-5565-426c-8d12-07090a1b4ec9',3);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('b555f060-93f8-4dcb-bb91-e10f68145c14','13eb098b-c9a6-46c5-b5cb-f4549cef94f0','a04c7a11-52d7-4fbc-9115-2df00eda1ad2',4);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('5e35f5c0-b38a-4acb-9904-2ffbb5aa804c','21d6ae6b-f41e-4712-b71f-02cfc709e973','bc66297b-3f3a-4d8d-b6c4-ceea1696bc11',1);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('bf6910f2-0006-4311-8da4-7ed753f5a80d','21d6ae6b-f41e-4712-b71f-02cfc709e973','80d96e10-6be4-4ba4-8a84-4a7135e09b59',2);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('0a00bafd-797f-4621-9b9e-be6c1ab656e0','21d6ae6b-f41e-4712-b71f-02cfc709e973','91c73b09-4ae9-4305-92bd-efa68ed9a4db',3);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('1f33668e-42bc-4ac7-b061-769f109f463c','21d6ae6b-f41e-4712-b71f-02cfc709e973','a04c7a11-52d7-4fbc-9115-2df00eda1ad2',4);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('4872b248-bbcd-4ea6-b536-e8a83bfe3382','ef810828-770d-4fa4-bde2-31f31fb48337','bc66297b-3f3a-4d8d-b6c4-ceea1696bc11',1);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('7178cf08-6d84-4473-9e66-16f15a15dcab','ef810828-770d-4fa4-bde2-31f31fb48337','22cbd4e4-582f-46c4-a2ee-ff4f387453bc',2);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('7793d007-07c0-4f04-9d74-53907e7d9b53','ef810828-770d-4fa4-bde2-31f31fb48337','56da5097-d043-475e-a083-edcec0a94fdc',3);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('d6c80a80-a70d-4625-a85d-06a30ace186a','ef810828-770d-4fa4-bde2-31f31fb48337','a04c7a11-52d7-4fbc-9115-2df00eda1ad2',4);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('03ce3846-22bf-4807-83b0-e59d40bfe07b','0f3609b2-309c-475a-a097-a38f3cf7498d','bc66297b-3f3a-4d8d-b6c4-ceea1696bc11',1);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('a177b235-41b6-4b36-aa7c-b42c4b5faaec','0f3609b2-309c-475a-a097-a38f3cf7498d','c48be0b2-df68-4314-b680-27c1bd190e51',2);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('32de178b-0a5d-4215-bb2c-813d1b520080','0f3609b2-309c-475a-a097-a38f3cf7498d','8fe12714-a68f-4135-be5f-2e448d8e4cf1',3);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('4ee882cd-9d46-48d3-bfee-91d7eeade4e7','0f3609b2-309c-475a-a097-a38f3cf7498d','a04c7a11-52d7-4fbc-9115-2df00eda1ad2',4);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('6af27793-9d30-4584-984f-36bd1adf9de7','67d7fd9f-4717-4a5f-9c8a-9f95338d005a','bc66297b-3f3a-4d8d-b6c4-ceea1696bc11',1);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('be86b03d-8cad-4a8d-90d7-ae73c4063e3e','67d7fd9f-4717-4a5f-9c8a-9f95338d005a','02483544-6b27-4807-a124-2a1bbd1b24de',2);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('e4b8fde0-1dce-4817-b53f-26324bf47a88','67d7fd9f-4717-4a5f-9c8a-9f95338d005a','05df369b-14ff-4eee-9c45-d87c54e2a995',3);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('01fc5cb8-c994-439d-92d0-2b4fc6295832','67d7fd9f-4717-4a5f-9c8a-9f95338d005a','a04c7a11-52d7-4fbc-9115-2df00eda1ad2',4);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('ef055079-babf-42e9-8ef0-03b27a670936','1ed6a3a8-e85e-4103-9187-1f8ee3f460ab','bc66297b-3f3a-4d8d-b6c4-ceea1696bc11',1);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('e6cbf116-8802-4a97-9795-97964f94db57','1ed6a3a8-e85e-4103-9187-1f8ee3f460ab','4b9718e1-62e6-413c-ba46-b3dbc4989cb7',2);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('baa94672-2e2a-4e82-b63f-ede37e9f874c','1ed6a3a8-e85e-4103-9187-1f8ee3f460ab','0dd19700-303b-46d8-bbc6-48b0c32ac090',3);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('6b6b965c-df45-495f-b904-f6b54aa25c2b','1ed6a3a8-e85e-4103-9187-1f8ee3f460ab','a04c7a11-52d7-4fbc-9115-2df00eda1ad2',4);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('fbfd1028-d89e-4a5c-94d0-76296471d8b0','9693f717-503c-4a71-bfa7-ad7a9b6ae85a','ca6efe5b-d00b-436c-873f-fd31f913c644',1);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('52fd59c8-596c-45ff-a38a-fac00eef7597','9693f717-503c-4a71-bfa7-ad7a9b6ae85a','3b877537-a423-4e4d-89d7-ed46f4cc25c7',2);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('f6a48bf6-acd3-4f9b-abf2-9e2237b0e690','9693f717-503c-4a71-bfa7-ad7a9b6ae85a','9dfd9097-1d0a-4859-9852-c9b491a42c81',3);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('3d9c4a43-5c33-4479-84bb-e93efc6f01c7','644c6c1e-81b8-4efc-985a-249b9869a230','ca6efe5b-d00b-436c-873f-fd31f913c644',1);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('2b553268-6690-498a-a3dd-530612192e8f','644c6c1e-81b8-4efc-985a-249b9869a230','3b877537-a423-4e4d-89d7-ed46f4cc25c7',2);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('2be83916-3530-4e6b-b2ce-f675bb1a37a9','644c6c1e-81b8-4efc-985a-249b9869a230','9dfd9097-1d0a-4859-9852-c9b491a42c81',3);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('5a1497ca-9a46-41c7-af07-ce4239965682','84e946ca-a139-4adb-b0f1-6930b1f775b4','ca6efe5b-d00b-436c-873f-fd31f913c644',1);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('46145256-d0b3-4379-a33a-ea932ec68860','84e946ca-a139-4adb-b0f1-6930b1f775b4','3b877537-a423-4e4d-89d7-ed46f4cc25c7',2);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('79efd70c-a8c8-41d2-afde-a93f9121485d','84e946ca-a139-4adb-b0f1-6930b1f775b4','9dfd9097-1d0a-4859-9852-c9b491a42c81',3);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('31cbb4e3-f640-4884-952c-b936a493a2f8','c2a181e7-ab8a-4b80-bbdd-53557fcd9583','ca6efe5b-d00b-436c-873f-fd31f913c644',1);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('b6624a33-7199-4a54-bc01-ee7a0ef2cb30','c2a181e7-ab8a-4b80-bbdd-53557fcd9583','3b877537-a423-4e4d-89d7-ed46f4cc25c7',2);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('6b7d7495-fa50-42d1-b7ce-5e4de905a67d','c2a181e7-ab8a-4b80-bbdd-53557fcd9583','9dfd9097-1d0a-4859-9852-c9b491a42c81',3);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('0eb78c3d-fe5c-4c68-80b5-72796ee02d5f','24527cb2-960f-4988-a71a-0447be46a1c1','ca6efe5b-d00b-436c-873f-fd31f913c644',1);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('386f7951-f84c-4836-8ea6-c99243c64232','24527cb2-960f-4988-a71a-0447be46a1c1','3b877537-a423-4e4d-89d7-ed46f4cc25c7',2);
INSERT INTO public."PerguntaResposta" ("Id","PerguntaId", "RespostaId", "Ordenacao") 
	VALUES ('d3e9e062-399d-41c2-8305-14e66203115f','24527cb2-960f-4988-a71a-0447be46a1c1','9dfd9097-1d0a-4859-9852-c9b491a42c81',3);

INSERT INTO public."PerguntaAnoEscolar" ("Id","PerguntaId", "AnoEscolar", "Ordenacao") 
	VALUES ('1361d4d5-09c0-45c5-b6a8-a586e7b45a33','d53ba946-fb3d-4b20-8883-0f7dbab3bddb',7,1);
INSERT INTO public."PerguntaAnoEscolar" ("Id","PerguntaId", "AnoEscolar", "Ordenacao") 
	VALUES ('f2d4de2f-e66b-43de-be42-af63ada710ef','9d60c205-9a55-4f17-9254-b1d760d172fd',7,2);
INSERT INTO public."PerguntaAnoEscolar" ("Id","PerguntaId", "AnoEscolar", "Ordenacao") 
	VALUES ('50f4cf10-ef5e-45d9-b936-7ea8d73b06a4','13eb098b-c9a6-46c5-b5cb-f4549cef94f0',7,3);
INSERT INTO public."PerguntaAnoEscolar" ("Id","PerguntaId", "AnoEscolar", "Ordenacao") 
	VALUES ('f0543c73-8f1c-4b5f-9319-5a5712460910','21d6ae6b-f41e-4712-b71f-02cfc709e973',7,4);
INSERT INTO public."PerguntaAnoEscolar" ("Id","PerguntaId", "AnoEscolar", "Ordenacao") 
	VALUES ('419935cc-8268-4128-8f25-fb0c23acf5d8','ef810828-770d-4fa4-bde2-31f31fb48337',7,5);
INSERT INTO public."PerguntaAnoEscolar" ("Id","PerguntaId", "AnoEscolar", "Ordenacao") 
	VALUES ('56f883ea-e337-4c80-9cda-1e494781f1c9','d53ba946-fb3d-4b20-8883-0f7dbab3bddb',8,1);
INSERT INTO public."PerguntaAnoEscolar" ("Id","PerguntaId", "AnoEscolar", "Ordenacao") 
	VALUES ('6ddcd8f6-967e-46c9-889e-48c762682e35','9d60c205-9a55-4f17-9254-b1d760d172fd',8,2);
INSERT INTO public."PerguntaAnoEscolar" ("Id","PerguntaId", "AnoEscolar", "Ordenacao") 
	VALUES ('8f3715ab-83fd-4a1c-a664-e936f2757e5c','0f3609b2-309c-475a-a097-a38f3cf7498d',8,3);
INSERT INTO public."PerguntaAnoEscolar" ("Id","PerguntaId", "AnoEscolar", "Ordenacao") 
	VALUES ('362050c1-6e4e-47bf-9dbf-cc30df38b383','21d6ae6b-f41e-4712-b71f-02cfc709e973',8,4);
INSERT INTO public."PerguntaAnoEscolar" ("Id","PerguntaId", "AnoEscolar", "Ordenacao") 
	VALUES ('9d3bbe25-d0d2-4ce0-b180-a38982f91390','67d7fd9f-4717-4a5f-9c8a-9f95338d005a',8,5);
INSERT INTO public."PerguntaAnoEscolar" ("Id","PerguntaId", "AnoEscolar", "Ordenacao") 
	VALUES ('f0d0d99d-2f6e-486f-afd1-5c719e4db459','d53ba946-fb3d-4b20-8883-0f7dbab3bddb',9,1);
INSERT INTO public."PerguntaAnoEscolar" ("Id","PerguntaId", "AnoEscolar", "Ordenacao") 
	VALUES ('28e17b2b-6b7e-4a47-821c-61951643c5ba','9d60c205-9a55-4f17-9254-b1d760d172fd',9,2);
INSERT INTO public."PerguntaAnoEscolar" ("Id","PerguntaId", "AnoEscolar", "Ordenacao") 
	VALUES ('8bf9f3a6-1bdf-4c88-bd05-3598a6c61684','13eb098b-c9a6-46c5-b5cb-f4549cef94f0',9,3);
INSERT INTO public."PerguntaAnoEscolar" ("Id","PerguntaId", "AnoEscolar", "Ordenacao") 
	VALUES ('40284417-9c79-4f97-8ff5-a449662ddadb','1ed6a3a8-e85e-4103-9187-1f8ee3f460ab',9,4);
INSERT INTO public."PerguntaAnoEscolar" ("Id","PerguntaId", "AnoEscolar", "Ordenacao") 
	VALUES ('b25275f5-bef0-4d64-bddc-e498049c1c9a','67d7fd9f-4717-4a5f-9c8a-9f95338d005a',9,5);
	
INSERT INTO public."Grupo" ("Id", "Descricao") 
	VALUES ('e27b99a3-789d-43fb-a962-7df8793622b1','Capacidade de leitura');
INSERT INTO public."Grupo" ("Id", "Descricao") 
	VALUES ('6a3d323a-2c44-4052-ba68-13a8dead299a','Leitura em voz alta');
INSERT INTO public."Grupo" ("Id", "Descricao") 
	VALUES ('263b55b8-efa2-480c-80ad-f4e8f0935e12','Produção de texto');
	
-- Auto-generated SQL script #202008211549
INSERT INTO  public."Ordem" ("Id","Descricao","GrupoId")
	VALUES ('2382e530-c426-46fe-83b6-84461257aabc','"Ordem" da descrição de ações','e27b99a3-789d-43fb-a962-7df8793622b1');
INSERT INTO  public."Ordem" ("Id","Descricao","GrupoId")
	VALUES ('9913da2a-dc3d-45e6-a1e5-34b386cc1202','"Ordem" do discurso em versos','e27b99a3-789d-43fb-a962-7df8793622b1');
INSERT INTO  public."Ordem" ("Id","Descricao","GrupoId")
	VALUES ('d0fcd18f-d626-4ca1-900d-6f85b1ad690f','"Ordem" do expor','e27b99a3-789d-43fb-a962-7df8793622b1');
INSERT INTO  public."Ordem" ("Id","Descricao","GrupoId")
	VALUES ('f4213141-94b9-4b91-a65f-56348a3f8399','"Ordem" do narrar','e27b99a3-789d-43fb-a962-7df8793622b1');
INSERT INTO  public."Ordem" ("Id","Descricao","GrupoId")
	VALUES ('9467c76f-4b87-43be-93d6-d243e6a856ec','"Ordem" do relatar','e27b99a3-789d-43fb-a962-7df8793622b1');
INSERT INTO  public."Ordem" ("Id","Descricao","GrupoId")
	VALUES ('ad53a26a-e9d5-4732-a086-212dc20f3af7','"Ordem" do argumentar','e27b99a3-789d-43fb-a962-7df8793622b1');

-- Auto-generated SQL script #202008211604
INSERT INTO  public."Periodo" ("Id","Descricao","TipoPeriodo")
	VALUES ('c93c1c4a-abb9-43a4-a8cd-283e4df365d8','1º Semestre',1);
INSERT INTO  public."Periodo" ("Id","Descricao","TipoPeriodo")
	VALUES ('8de86d08-b7a1-45df-b775-07550714756b','2º Semestre',1);
INSERT INTO  public."Periodo" ("Id","Descricao","TipoPeriodo")
	VALUES ('fbd8b833-d7dc-4d04-9af6-50c1aaa2f8c0','1º Bimestre',2);
INSERT INTO  public."Periodo" ("Id","Descricao","TipoPeriodo")
	VALUES ('05ce183c-cb37-44fb-9c30-dac5ae5b8d37','2º Bimestre',2);
INSERT INTO  public."Periodo" ("Id","Descricao","TipoPeriodo")
	VALUES ('a8d3311a-b71e-45ce-8667-cef062334949','3º Bimestre',2);
INSERT INTO  public."Periodo" ("Id","Descricao","TipoPeriodo")
	VALUES ('aa7f39fc-3b50-4aea-bd05-4bbe7cba687c','4º Bimestre',2);
	
-- Auto-generated SQL script #202008211708
INSERT INTO public."OrdemPergunta" ("Id","SequenciaOrdem","PerguntaId")
	VALUES ('fb4412f8-a56c-4440-ad91-ce762bc6eb2a',1,'9693f717-503c-4a71-bfa7-ad7a9b6ae85a');
INSERT INTO public."OrdemPergunta" ("Id","SequenciaOrdem","PerguntaId")
	VALUES ('891d3995-910c-4392-a7d4-36e7261d74de',1,'644c6c1e-81b8-4efc-985a-249b9869a230');
INSERT INTO public."OrdemPergunta" ("Id","SequenciaOrdem","PerguntaId")
	VALUES ('6e48d99e-cd0c-452a-a6a4-cee5842b4909',1,'84e946ca-a139-4adb-b0f1-6930b1f775b4');
INSERT INTO public."OrdemPergunta" ("Id","SequenciaOrdem","PerguntaId")
	VALUES ('dddd37bf-b6a4-42e7-94f6-d02c9ce96fd4',2,'9693f717-503c-4a71-bfa7-ad7a9b6ae85a');
INSERT INTO public."OrdemPergunta" ("Id","SequenciaOrdem","PerguntaId")
	VALUES ('616654b0-04cf-426c-984f-910606da8af5',2,'c2a181e7-ab8a-4b80-bbdd-53557fcd9583');
INSERT INTO public."OrdemPergunta" ("Id","SequenciaOrdem","PerguntaId")
	VALUES ('5b2c2243-f4ce-4780-b0f2-c9735b216fd4',2,'84e946ca-a139-4adb-b0f1-6930b1f775b4');
INSERT INTO public."OrdemPergunta" ("Id","SequenciaOrdem","PerguntaId")
	VALUES ('edf2d1dc-aadd-4142-aaae-535049f8fe7a',3,'9693f717-503c-4a71-bfa7-ad7a9b6ae85a');
INSERT INTO public."OrdemPergunta" ("Id","SequenciaOrdem","PerguntaId")
	VALUES ('97d31bca-c1e5-4d6d-a486-3803d12c55f2',3,'24527cb2-960f-4988-a71a-0447be46a1c1');
INSERT INTO public."OrdemPergunta" ("Id","SequenciaOrdem","PerguntaId")
	VALUES ('af51f6ef-99fe-4b9a-93eb-a80b877e6849',3,'84e946ca-a139-4adb-b0f1-6930b1f775b4');

-- Auto-generated SQL script #202008211801
INSERT INTO public."GrupoOrdem" ("Id","GrupoId","OrdemId","Ordenacao")
	VALUES ('791f092a-3d81-429b-9885-e6cb8a30b67d','e27b99a3-789d-43fb-a962-7df8793622b1','2382e530-c426-46fe-83b6-84461257aabc',1);
INSERT INTO public."GrupoOrdem" ("Id","GrupoId","OrdemId","Ordenacao")
	VALUES ('57a379d0-8351-4323-8743-129092066477','e27b99a3-789d-43fb-a962-7df8793622b1','9913da2a-dc3d-45e6-a1e5-34b386cc1202',2);
INSERT INTO public."GrupoOrdem" ("Id","GrupoId","OrdemId","Ordenacao")
	VALUES ('ccaa768a-9019-489f-bb63-d2961aec8979','e27b99a3-789d-43fb-a962-7df8793622b1','d0fcd18f-d626-4ca1-900d-6f85b1ad690f',3);
INSERT INTO public."GrupoOrdem" ("Id","GrupoId","OrdemId","Ordenacao")
	VALUES ('54b8dd49-4845-4d52-a014-022b7a370011','e27b99a3-789d-43fb-a962-7df8793622b1','f4213141-94b9-4b91-a65f-56348a3f8399',4);
INSERT INTO public."GrupoOrdem" ("Id","GrupoId","OrdemId","Ordenacao")
	VALUES ('b19d1d50-21f0-4888-8e63-2ffaaf60e28d','e27b99a3-789d-43fb-a962-7df8793622b1','9467c76f-4b87-43be-93d6-d243e6a856ec',5);
INSERT INTO public."GrupoOrdem" ("Id","GrupoId","OrdemId","Ordenacao")
	VALUES ('33a755e5-03a5-48f6-a6b3-774760dfc1c7','e27b99a3-789d-43fb-a962-7df8793622b1','ad53a26a-e9d5-4732-a086-212dc20f3af7',6);
	