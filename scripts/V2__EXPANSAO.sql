--
-- PostgreSQL database dump
--

-- Dumped from database version 11.9
-- Dumped by pg_dump version 12.2

-- Started on 2020-10-08 17:45:32

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

--
-- TOC entry 217 (class 1259 OID 68258)
-- Name: ComponenteCurricular; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."ComponenteCurricular" (
    "Id" text NOT NULL,
    "Descricao" character varying(100) NOT NULL,
    "Excluido" boolean DEFAULT false NOT NULL
);


ALTER TABLE public."ComponenteCurricular" OWNER TO usr_pedagogicogestao;

--
-- TOC entry 222 (class 1259 OID 68303)
-- Name: Grupo; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Grupo" (
    "Id" text NOT NULL,
    "Descricao" character varying(200) NOT NULL,
    "Excluido" boolean DEFAULT false NOT NULL,
    "OrdemVisivel" boolean DEFAULT false
);


ALTER TABLE public."Grupo" OWNER TO usr_pedagogicogestao;

--
-- TOC entry 227 (class 1259 OID 68347)
-- Name: GrupoOrdem; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."GrupoOrdem" (
    "Id" text NOT NULL,
    "GrupoId" text NOT NULL,
    "OrdemId" text NOT NULL,
    "Ordenacao" integer NOT NULL,
    "Excluido" boolean DEFAULT false NOT NULL
);


ALTER TABLE public."GrupoOrdem" OWNER TO usr_pedagogicogestao;

--
-- TOC entry 223 (class 1259 OID 68312)
-- Name: Ordem; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Ordem" (
    "Id" text NOT NULL,
    "Descricao" character varying(200) NOT NULL,
    "GrupoId" text NOT NULL,
    "Excluido" boolean DEFAULT false NOT NULL,
    "Ordenacao" integer
);


ALTER TABLE public."Ordem" OWNER TO usr_pedagogicogestao;

--
-- TOC entry 224 (class 1259 OID 68321)
-- Name: OrdemPergunta; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."OrdemPergunta" (
    "Id" text NOT NULL,
    "SequenciaOrdem" integer NOT NULL,
    "PerguntaId" text NOT NULL,
    "Excluido" boolean DEFAULT false NOT NULL,
    "OrdenacaoNaTela" integer,
    "GrupoId" text
);


ALTER TABLE public."OrdemPergunta" OWNER TO usr_pedagogicogestao;

--
-- TOC entry 218 (class 1259 OID 68267)
-- Name: Pergunta; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Pergunta" (
    "Id" text NOT NULL,
    "Descricao" character varying(200) NOT NULL,
    "ComponenteCurricularId" character varying NOT NULL,
    "Excluido" boolean DEFAULT false NOT NULL
);


ALTER TABLE public."Pergunta" OWNER TO usr_pedagogicogestao;

--
-- TOC entry 221 (class 1259 OID 68294)
-- Name: PerguntaAnoEscolar; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."PerguntaAnoEscolar" (
    "Id" text NOT NULL,
    "PerguntaId" text NOT NULL,
    "AnoEscolar" integer NOT NULL,
    "Ordenacao" integer NOT NULL,
    "Excluido" boolean DEFAULT false NOT NULL
);


ALTER TABLE public."PerguntaAnoEscolar" OWNER TO usr_pedagogicogestao;

--
-- TOC entry 220 (class 1259 OID 68285)
-- Name: PerguntaResposta; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."PerguntaResposta" (
    "Id" text NOT NULL,
    "PerguntaId" text NOT NULL,
    "RespostaId" text NOT NULL,
    "Ordenacao" integer NOT NULL,
    "Excluido" boolean DEFAULT false NOT NULL
);


ALTER TABLE public."PerguntaResposta" OWNER TO usr_pedagogicogestao;

--
-- TOC entry 234 (class 1259 OID 112556)
-- Name: PeriodoFixoAnual; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."PeriodoFixoAnual" (
    "Id" integer NOT NULL,
    "Ano" integer,
    "Descricao" character varying(50),
    "DataInicio" timestamp without time zone,
    "DataFim" timestamp without time zone,
    "TipoPeriodo" integer,
    "PeriodoId" text
);


ALTER TABLE public."PeriodoFixoAnual" OWNER TO usr_pedagogicogestao;

--
-- TOC entry 233 (class 1259 OID 112554)
-- Name: PeridodoFixoAnual_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."PeriodoFixoAnual" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."PeridodoFixoAnual_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 225 (class 1259 OID 68330)
-- Name: Periodo; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Periodo" (
    "Id" text NOT NULL,
    "Descricao" character varying(200) NOT NULL,
    "TipoPeriodo" integer NOT NULL,
    "Excluido" boolean DEFAULT false NOT NULL
);


ALTER TABLE public."Periodo" OWNER TO usr_pedagogicogestao;

--
-- TOC entry 229 (class 1259 OID 71004)
-- Name: PeriodoDeAberturas; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."PeriodoDeAberturas" (
    "Id" bigint NOT NULL,
    "Ano" character varying(5),
    "Bimestre" integer,
    "DataInicio" timestamp without time zone,
    "DataFim" timestamp without time zone
);


ALTER TABLE public."PeriodoDeAberturas" OWNER TO usr_pedagogicogestao;

--
-- TOC entry 228 (class 1259 OID 71002)
-- Name: PeriodoDeAberturas_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."PeriodoDeAberturas" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."PeriodoDeAberturas_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 219 (class 1259 OID 68276)
-- Name: Resposta; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Resposta" (
    "Id" text NOT NULL,
    "Descricao" character varying(200) NOT NULL,
    "Excluido" boolean DEFAULT false NOT NULL,
    "Verdadeiro" boolean DEFAULT false NOT NULL
);


ALTER TABLE public."Resposta" OWNER TO usr_pedagogicogestao;

--
-- TOC entry 3094 (class 0 OID 68258)
-- Dependencies: 217
-- Data for Name: ComponenteCurricular; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."ComponenteCurricular" VALUES ('9f3d8467-2f6e-4bcb-a8e9-12e840426aba', 'Matemática', false);
INSERT INTO public."ComponenteCurricular" VALUES ('c65b2c0a-7a58-4d40-b474-23f0982f14b1', 'Língua Portuguesa', false);


--
-- TOC entry 3099 (class 0 OID 68303)
-- Dependencies: 222
-- Data for Name: Grupo; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Grupo" VALUES ('6a3d323a-2c44-4052-ba68-13a8dead299a', 'Leitura em voz alta', false, false);
INSERT INTO public."Grupo" VALUES ('263b55b8-efa2-480c-80ad-f4e8f0935e12', 'Produção de texto', false, false);
INSERT INTO public."Grupo" VALUES ('e27b99a3-789d-43fb-a962-7df8793622b1', 'Capacidade de leitura', false, true);


--
-- TOC entry 3103 (class 0 OID 68347)
-- Dependencies: 227
-- Data for Name: GrupoOrdem; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."GrupoOrdem" VALUES ('54b8dd49-4845-4d52-a014-022b7a370011', 'e27b99a3-789d-43fb-a962-7df8793622b1', 'f4213141-94b9-4b91-a65f-56348a3f8399', 4, false);
INSERT INTO public."GrupoOrdem" VALUES ('b19d1d50-21f0-4888-8e63-2ffaaf60e28d', 'e27b99a3-789d-43fb-a962-7df8793622b1', '9467c76f-4b87-43be-93d6-d243e6a856ec', 5, false);
INSERT INTO public."GrupoOrdem" VALUES ('33a755e5-03a5-48f6-a6b3-774760dfc1c7', 'e27b99a3-789d-43fb-a962-7df8793622b1', 'ad53a26a-e9d5-4732-a086-212dc20f3af7', 6, false);
INSERT INTO public."GrupoOrdem" VALUES ('a5cba7c6-c345-4ffc-a2db-31e6f6a81093', '263b55b8-efa2-480c-80ad-f4e8f0935e12', 'dd4092b6-3716-43c9-9bf4-3f7a6a283320', 1, false);
INSERT INTO public."GrupoOrdem" VALUES ('9fc4f6b1-aba5-4bbf-872d-ed9e5d750cbf', '6a3d323a-2c44-4052-ba68-13a8dead299a', 'fcadf49b-1aae-433d-a34e-66281b5de6a6', 1, false);


--
-- TOC entry 3100 (class 0 OID 68312)
-- Dependencies: 223
-- Data for Name: Ordem; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Ordem" VALUES ('dd4092b6-3716-43c9-9bf4-3f7a6a283320', 'Ordem Produção de texto', '263b55b8-efa2-480c-80ad-f4e8f0935e12', false, 1);
INSERT INTO public."Ordem" VALUES ('fcadf49b-1aae-433d-a34e-66281b5de6a6', 'Leitura em voz alta', '6a3d323a-2c44-4052-ba68-13a8dead299a', false, 1);
INSERT INTO public."Ordem" VALUES ('ad53a26a-e9d5-4732-a086-212dc20f3af7', 'Ordem do argumentar', 'e27b99a3-789d-43fb-a962-7df8793622b1', false, 3);
INSERT INTO public."Ordem" VALUES ('f4213141-94b9-4b91-a65f-56348a3f8399', 'Ordem do narrar', 'e27b99a3-789d-43fb-a962-7df8793622b1', false, 1);
INSERT INTO public."Ordem" VALUES ('9467c76f-4b87-43be-93d6-d243e6a856ec', 'Ordem do relatar', 'e27b99a3-789d-43fb-a962-7df8793622b1', false, 2);


--
-- TOC entry 3101 (class 0 OID 68321)
-- Dependencies: 224
-- Data for Name: OrdemPergunta; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."OrdemPergunta" VALUES ('5c283e6a-380e-43dc-a63e-3bdf0da266d9', 1, '18d148be-d83c-4f24-9d03-dc003a05b9e4', false, 4, '6a3d323a-2c44-4052-ba68-13a8dead299a');
INSERT INTO public."OrdemPergunta" VALUES ('2b0bee5d-09e8-47ae-b067-622ae36e3f49', 1, '98940cdb-d229-4282-a2e1-60e4a17dab64', false, 2, '263b55b8-efa2-480c-80ad-f4e8f0935e12');
INSERT INTO public."OrdemPergunta" VALUES ('838a12de-8e39-4df2-80f6-0a22c3cd1d54', 1, '3173bff2-a148-4634-b029-b50c949ae2d6', false, 1, '263b55b8-efa2-480c-80ad-f4e8f0935e12');
INSERT INTO public."OrdemPergunta" VALUES ('cb512711-007d-49e8-8ede-49a5fad841cb', 1, 'cfec69be-16fb-453d-8c47-fd5ebc4161ef', false, 3, '263b55b8-efa2-480c-80ad-f4e8f0935e12');
INSERT INTO public."OrdemPergunta" VALUES ('b7b6eb1f-f583-4580-8388-0a3e492dfa9e', 1, 'ef0e79cd-dc31-4272-ad04-68f79a3a135d', false, 4, '263b55b8-efa2-480c-80ad-f4e8f0935e12');
INSERT INTO public."OrdemPergunta" VALUES ('7ee3a73a-4325-4f86-bd33-a9215288f7e1', 1, 'f4aae748-bfd8-482e-aee0-07a1cdad71ff', false, 5, '263b55b8-efa2-480c-80ad-f4e8f0935e12');
INSERT INTO public."OrdemPergunta" VALUES ('02d1c996-062a-4981-b0c9-ae65afe75637', 1, '67a791d2-089d-40ee-8ddf-c64454ee5c54', false, 6, '263b55b8-efa2-480c-80ad-f4e8f0935e12');
INSERT INTO public."OrdemPergunta" VALUES ('6e48d99e-cd0c-452a-a6a4-cee5842b4909', 1, '84e946ca-a139-4adb-b0f1-6930b1f775b4', false, 3, 'e27b99a3-789d-43fb-a962-7df8793622b1');
INSERT INTO public."OrdemPergunta" VALUES ('fb4412f8-a56c-4440-ad91-ce762bc6eb2a', 1, '9693f717-503c-4a71-bfa7-ad7a9b6ae85a', false, 1, 'e27b99a3-789d-43fb-a962-7df8793622b1');
INSERT INTO public."OrdemPergunta" VALUES ('891d3995-910c-4392-a7d4-36e7261d74de', 1, '644c6c1e-81b8-4efc-985a-249b9869a230', false, 2, 'e27b99a3-789d-43fb-a962-7df8793622b1');
INSERT INTO public."OrdemPergunta" VALUES ('73c1a6fd-3c3d-4787-bce1-24765b89a709', 1, '0bf845cc-29dc-45ec-8bf2-8981cef616df', false, 1, '6a3d323a-2c44-4052-ba68-13a8dead299a');
INSERT INTO public."OrdemPergunta" VALUES ('c83f7155-b036-4904-85a0-42bd08eb746e', 1, '49c26883-e717-44aa-9aab-1bd8aa870916', false, 2, '6a3d323a-2c44-4052-ba68-13a8dead299a');
INSERT INTO public."OrdemPergunta" VALUES ('26d231df-121d-4c0e-92be-7415916e0c53', 1, '0b38221a-9d50-4cdf-abbd-a9ac092dbe70', false, 3, '6a3d323a-2c44-4052-ba68-13a8dead299a');


--
-- TOC entry 3095 (class 0 OID 68267)
-- Dependencies: 218
-- Data for Name: Pergunta; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Pergunta" VALUES ('d53ba946-fb3d-4b20-8883-0f7dbab3bddb', 'Problema de lógica', '9f3d8467-2f6e-4bcb-a8e9-12e840426aba', false);
INSERT INTO public."Pergunta" VALUES ('9d60c205-9a55-4f17-9254-b1d760d172fd', 'Área e perímetro ', '9f3d8467-2f6e-4bcb-a8e9-12e840426aba', false);
INSERT INTO public."Pergunta" VALUES ('13eb098b-c9a6-46c5-b5cb-f4549cef94f0', 'Sólidos geométricos', '9f3d8467-2f6e-4bcb-a8e9-12e840426aba', false);
INSERT INTO public."Pergunta" VALUES ('21d6ae6b-f41e-4712-b71f-02cfc709e973', 'Relações entre grandezas e porcentagem', '9f3d8467-2f6e-4bcb-a8e9-12e840426aba', false);
INSERT INTO public."Pergunta" VALUES ('ef810828-770d-4fa4-bde2-31f31fb48337', 'Média, moda e mediana', '9f3d8467-2f6e-4bcb-a8e9-12e840426aba', false);
INSERT INTO public."Pergunta" VALUES ('0f3609b2-309c-475a-a097-a38f3cf7498d', 'Triângulos e quadriláteros', '9f3d8467-2f6e-4bcb-a8e9-12e840426aba', false);
INSERT INTO public."Pergunta" VALUES ('67d7fd9f-4717-4a5f-9c8a-9f95338d005a', 'Probabilidade', '9f3d8467-2f6e-4bcb-a8e9-12e840426aba', false);
INSERT INTO public."Pergunta" VALUES ('1ed6a3a8-e85e-4103-9187-1f8ee3f460ab', 'Regularidade e generalização', '9f3d8467-2f6e-4bcb-a8e9-12e840426aba', false);
INSERT INTO public."Pergunta" VALUES ('9693f717-503c-4a71-bfa7-ad7a9b6ae85a', 'Localização', 'c65b2c0a-7a58-4d40-b474-23f0982f14b1', false);
INSERT INTO public."Pergunta" VALUES ('84e946ca-a139-4adb-b0f1-6930b1f775b4', 'Reflexão', 'c65b2c0a-7a58-4d40-b474-23f0982f14b1', false);
INSERT INTO public."Pergunta" VALUES ('0bf845cc-29dc-45ec-8bf2-8981cef616df', 'Não conseguiu ou não quis ler', 'c65b2c0a-7a58-4d40-b474-23f0982f14b1', false);
INSERT INTO public."Pergunta" VALUES ('49c26883-e717-44aa-9aab-1bd8aa870916', 'Leu com muita dificuldade', 'c65b2c0a-7a58-4d40-b474-23f0982f14b1', false);
INSERT INTO public."Pergunta" VALUES ('0b38221a-9d50-4cdf-abbd-a9ac092dbe70', 'Leu com alguma fluência', 'c65b2c0a-7a58-4d40-b474-23f0982f14b1', false);
INSERT INTO public."Pergunta" VALUES ('cfec69be-16fb-453d-8c47-fd5ebc4161ef', 'Escrita não alfabética', 'c65b2c0a-7a58-4d40-b474-23f0982f14b1', false);
INSERT INTO public."Pergunta" VALUES ('ef0e79cd-dc31-4272-ad04-68f79a3a135d', 'Dificuldades com aspectos semânticos', 'c65b2c0a-7a58-4d40-b474-23f0982f14b1', false);
INSERT INTO public."Pergunta" VALUES ('f4aae748-bfd8-482e-aee0-07a1cdad71ff', 'Dificuldades com aspectos textuais', 'c65b2c0a-7a58-4d40-b474-23f0982f14b1', false);
INSERT INTO public."Pergunta" VALUES ('67a791d2-089d-40ee-8ddf-c64454ee5c54', 'Dificuldades com aspectos ortográficos e notacionais', 'c65b2c0a-7a58-4d40-b474-23f0982f14b1', false);
INSERT INTO public."Pergunta" VALUES ('18d148be-d83c-4f24-9d03-dc003a05b9e4', 'Leu com fluência', 'c65b2c0a-7a58-4d40-b474-23f0982f14b1', false);
INSERT INTO public."Pergunta" VALUES ('0ef5e05f-a366-4da1-b6c0-594ae45f57e5', 'Não resolveu', 'c65b2c0a-7a58-4d40-b474-23f0982f14b1', true);
INSERT INTO public."Pergunta" VALUES ('3173bff2-a148-4634-b029-b50c949ae2d6', 'Não produziu/entregou em branco', 'c65b2c0a-7a58-4d40-b474-23f0982f14b1', false);
INSERT INTO public."Pergunta" VALUES ('98940cdb-d229-4282-a2e1-60e4a17dab64', 'Não apresentou dificuldades', 'c65b2c0a-7a58-4d40-b474-23f0982f14b1', false);
INSERT INTO public."Pergunta" VALUES ('644c6c1e-81b8-4efc-985a-249b9869a230', 'Inferência', 'c65b2c0a-7a58-4d40-b474-23f0982f14b1', false);


--
-- TOC entry 3098 (class 0 OID 68294)
-- Dependencies: 221
-- Data for Name: PerguntaAnoEscolar; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."PerguntaAnoEscolar" VALUES ('1361d4d5-09c0-45c5-b6a8-a586e7b45a33', 'd53ba946-fb3d-4b20-8883-0f7dbab3bddb', 7, 1, false);
INSERT INTO public."PerguntaAnoEscolar" VALUES ('f2d4de2f-e66b-43de-be42-af63ada710ef', '9d60c205-9a55-4f17-9254-b1d760d172fd', 7, 2, false);
INSERT INTO public."PerguntaAnoEscolar" VALUES ('50f4cf10-ef5e-45d9-b936-7ea8d73b06a4', '13eb098b-c9a6-46c5-b5cb-f4549cef94f0', 7, 3, false);
INSERT INTO public."PerguntaAnoEscolar" VALUES ('f0543c73-8f1c-4b5f-9319-5a5712460910', '21d6ae6b-f41e-4712-b71f-02cfc709e973', 7, 4, false);
INSERT INTO public."PerguntaAnoEscolar" VALUES ('419935cc-8268-4128-8f25-fb0c23acf5d8', 'ef810828-770d-4fa4-bde2-31f31fb48337', 7, 5, false);
INSERT INTO public."PerguntaAnoEscolar" VALUES ('56f883ea-e337-4c80-9cda-1e494781f1c9', 'd53ba946-fb3d-4b20-8883-0f7dbab3bddb', 8, 1, false);
INSERT INTO public."PerguntaAnoEscolar" VALUES ('6ddcd8f6-967e-46c9-889e-48c762682e35', '9d60c205-9a55-4f17-9254-b1d760d172fd', 8, 2, false);
INSERT INTO public."PerguntaAnoEscolar" VALUES ('8f3715ab-83fd-4a1c-a664-e936f2757e5c', '0f3609b2-309c-475a-a097-a38f3cf7498d', 8, 3, false);
INSERT INTO public."PerguntaAnoEscolar" VALUES ('362050c1-6e4e-47bf-9dbf-cc30df38b383', '21d6ae6b-f41e-4712-b71f-02cfc709e973', 8, 4, false);
INSERT INTO public."PerguntaAnoEscolar" VALUES ('9d3bbe25-d0d2-4ce0-b180-a38982f91390', '67d7fd9f-4717-4a5f-9c8a-9f95338d005a', 8, 5, false);
INSERT INTO public."PerguntaAnoEscolar" VALUES ('f0d0d99d-2f6e-486f-afd1-5c719e4db459', 'd53ba946-fb3d-4b20-8883-0f7dbab3bddb', 9, 1, false);
INSERT INTO public."PerguntaAnoEscolar" VALUES ('28e17b2b-6b7e-4a47-821c-61951643c5ba', '9d60c205-9a55-4f17-9254-b1d760d172fd', 9, 2, false);
INSERT INTO public."PerguntaAnoEscolar" VALUES ('8bf9f3a6-1bdf-4c88-bd05-3598a6c61684', '13eb098b-c9a6-46c5-b5cb-f4549cef94f0', 9, 3, false);
INSERT INTO public."PerguntaAnoEscolar" VALUES ('40284417-9c79-4f97-8ff5-a449662ddadb', '1ed6a3a8-e85e-4103-9187-1f8ee3f460ab', 9, 4, false);
INSERT INTO public."PerguntaAnoEscolar" VALUES ('b25275f5-bef0-4d64-bddc-e498049c1c9a', '67d7fd9f-4717-4a5f-9c8a-9f95338d005a', 9, 5, false);


--
-- TOC entry 3097 (class 0 OID 68285)
-- Dependencies: 220
-- Data for Name: PerguntaResposta; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."PerguntaResposta" VALUES ('7d071fc3-accc-4133-8cbf-1f20332ff5c1', 'd53ba946-fb3d-4b20-8883-0f7dbab3bddb', 'bc66297b-3f3a-4d8d-b6c4-ceea1696bc11', 1, false);
INSERT INTO public."PerguntaResposta" VALUES ('a11ad326-34f1-4bb9-9dbe-5fb8ef049514', 'd53ba946-fb3d-4b20-8883-0f7dbab3bddb', '04695943-0abf-4dd7-b8b8-9e850f5d8d2e', 2, false);
INSERT INTO public."PerguntaResposta" VALUES ('cb133766-a446-4c95-a65d-2d26b1a4068a', 'd53ba946-fb3d-4b20-8883-0f7dbab3bddb', '53911083-6799-4553-8e5e-3eaadec17a55', 3, false);
INSERT INTO public."PerguntaResposta" VALUES ('8320dc58-bef3-4f3c-b077-7ce54e6a5d09', 'd53ba946-fb3d-4b20-8883-0f7dbab3bddb', 'a04c7a11-52d7-4fbc-9115-2df00eda1ad2', 4, false);
INSERT INTO public."PerguntaResposta" VALUES ('aff9e7c3-3a5d-45c3-8f54-aab5315761b6', '9d60c205-9a55-4f17-9254-b1d760d172fd', 'bc66297b-3f3a-4d8d-b6c4-ceea1696bc11', 1, false);
INSERT INTO public."PerguntaResposta" VALUES ('fc4eeadb-0d13-4e2b-8b56-4a90e10c9709', '9d60c205-9a55-4f17-9254-b1d760d172fd', 'aae9c109-bdb5-4391-b513-e5fd68d39d5a', 2, false);
INSERT INTO public."PerguntaResposta" VALUES ('bbc15078-22bf-4262-8b08-cc7b3634fcb6', '9d60c205-9a55-4f17-9254-b1d760d172fd', 'ffa53f05-b71e-4ef8-9b10-7c932ca681db', 3, false);
INSERT INTO public."PerguntaResposta" VALUES ('238b0422-8337-408d-a4a2-d9e15b20e999', '9d60c205-9a55-4f17-9254-b1d760d172fd', 'a04c7a11-52d7-4fbc-9115-2df00eda1ad2', 4, false);
INSERT INTO public."PerguntaResposta" VALUES ('73f07fca-500f-40ef-be9f-986552ec116d', '13eb098b-c9a6-46c5-b5cb-f4549cef94f0', 'bc66297b-3f3a-4d8d-b6c4-ceea1696bc11', 1, false);
INSERT INTO public."PerguntaResposta" VALUES ('ce762d7b-87f7-43e8-a3b9-473c2d9dd3b6', '13eb098b-c9a6-46c5-b5cb-f4549cef94f0', '7abb0305-441f-4d40-baea-4cc3f13a1a50', 2, false);
INSERT INTO public."PerguntaResposta" VALUES ('bfe55343-993f-4d5a-aa45-3cdc33e774a0', '13eb098b-c9a6-46c5-b5cb-f4549cef94f0', '0218ff47-5565-426c-8d12-07090a1b4ec9', 3, false);
INSERT INTO public."PerguntaResposta" VALUES ('b555f060-93f8-4dcb-bb91-e10f68145c14', '13eb098b-c9a6-46c5-b5cb-f4549cef94f0', 'a04c7a11-52d7-4fbc-9115-2df00eda1ad2', 4, false);
INSERT INTO public."PerguntaResposta" VALUES ('5e35f5c0-b38a-4acb-9904-2ffbb5aa804c', '21d6ae6b-f41e-4712-b71f-02cfc709e973', 'bc66297b-3f3a-4d8d-b6c4-ceea1696bc11', 1, false);
INSERT INTO public."PerguntaResposta" VALUES ('bf6910f2-0006-4311-8da4-7ed753f5a80d', '21d6ae6b-f41e-4712-b71f-02cfc709e973', '80d96e10-6be4-4ba4-8a84-4a7135e09b59', 2, false);
INSERT INTO public."PerguntaResposta" VALUES ('0a00bafd-797f-4621-9b9e-be6c1ab656e0', '21d6ae6b-f41e-4712-b71f-02cfc709e973', '91c73b09-4ae9-4305-92bd-efa68ed9a4db', 3, false);
INSERT INTO public."PerguntaResposta" VALUES ('1f33668e-42bc-4ac7-b061-769f109f463c', '21d6ae6b-f41e-4712-b71f-02cfc709e973', 'a04c7a11-52d7-4fbc-9115-2df00eda1ad2', 4, false);
INSERT INTO public."PerguntaResposta" VALUES ('4872b248-bbcd-4ea6-b536-e8a83bfe3382', 'ef810828-770d-4fa4-bde2-31f31fb48337', 'bc66297b-3f3a-4d8d-b6c4-ceea1696bc11', 1, false);
INSERT INTO public."PerguntaResposta" VALUES ('7178cf08-6d84-4473-9e66-16f15a15dcab', 'ef810828-770d-4fa4-bde2-31f31fb48337', '22cbd4e4-582f-46c4-a2ee-ff4f387453bc', 2, false);
INSERT INTO public."PerguntaResposta" VALUES ('7793d007-07c0-4f04-9d74-53907e7d9b53', 'ef810828-770d-4fa4-bde2-31f31fb48337', '56da5097-d043-475e-a083-edcec0a94fdc', 3, false);
INSERT INTO public."PerguntaResposta" VALUES ('d6c80a80-a70d-4625-a85d-06a30ace186a', 'ef810828-770d-4fa4-bde2-31f31fb48337', 'a04c7a11-52d7-4fbc-9115-2df00eda1ad2', 4, false);
INSERT INTO public."PerguntaResposta" VALUES ('03ce3846-22bf-4807-83b0-e59d40bfe07b', '0f3609b2-309c-475a-a097-a38f3cf7498d', 'bc66297b-3f3a-4d8d-b6c4-ceea1696bc11', 1, false);
INSERT INTO public."PerguntaResposta" VALUES ('a177b235-41b6-4b36-aa7c-b42c4b5faaec', '0f3609b2-309c-475a-a097-a38f3cf7498d', 'c48be0b2-df68-4314-b680-27c1bd190e51', 2, false);
INSERT INTO public."PerguntaResposta" VALUES ('32de178b-0a5d-4215-bb2c-813d1b520080', '0f3609b2-309c-475a-a097-a38f3cf7498d', '8fe12714-a68f-4135-be5f-2e448d8e4cf1', 3, false);
INSERT INTO public."PerguntaResposta" VALUES ('4ee882cd-9d46-48d3-bfee-91d7eeade4e7', '0f3609b2-309c-475a-a097-a38f3cf7498d', 'a04c7a11-52d7-4fbc-9115-2df00eda1ad2', 4, false);
INSERT INTO public."PerguntaResposta" VALUES ('6af27793-9d30-4584-984f-36bd1adf9de7', '67d7fd9f-4717-4a5f-9c8a-9f95338d005a', 'bc66297b-3f3a-4d8d-b6c4-ceea1696bc11', 1, false);
INSERT INTO public."PerguntaResposta" VALUES ('be86b03d-8cad-4a8d-90d7-ae73c4063e3e', '67d7fd9f-4717-4a5f-9c8a-9f95338d005a', '02483544-6b27-4807-a124-2a1bbd1b24de', 2, false);
INSERT INTO public."PerguntaResposta" VALUES ('e4b8fde0-1dce-4817-b53f-26324bf47a88', '67d7fd9f-4717-4a5f-9c8a-9f95338d005a', '05df369b-14ff-4eee-9c45-d87c54e2a995', 3, false);
INSERT INTO public."PerguntaResposta" VALUES ('01fc5cb8-c994-439d-92d0-2b4fc6295832', '67d7fd9f-4717-4a5f-9c8a-9f95338d005a', 'a04c7a11-52d7-4fbc-9115-2df00eda1ad2', 4, false);
INSERT INTO public."PerguntaResposta" VALUES ('ef055079-babf-42e9-8ef0-03b27a670936', '1ed6a3a8-e85e-4103-9187-1f8ee3f460ab', 'bc66297b-3f3a-4d8d-b6c4-ceea1696bc11', 1, false);
INSERT INTO public."PerguntaResposta" VALUES ('e6cbf116-8802-4a97-9795-97964f94db57', '1ed6a3a8-e85e-4103-9187-1f8ee3f460ab', '4b9718e1-62e6-413c-ba46-b3dbc4989cb7', 2, false);
INSERT INTO public."PerguntaResposta" VALUES ('baa94672-2e2a-4e82-b63f-ede37e9f874c', '1ed6a3a8-e85e-4103-9187-1f8ee3f460ab', '0dd19700-303b-46d8-bbc6-48b0c32ac090', 3, false);
INSERT INTO public."PerguntaResposta" VALUES ('6b6b965c-df45-495f-b904-f6b54aa25c2b', '1ed6a3a8-e85e-4103-9187-1f8ee3f460ab', 'a04c7a11-52d7-4fbc-9115-2df00eda1ad2', 4, false);
INSERT INTO public."PerguntaResposta" VALUES ('fbfd1028-d89e-4a5c-94d0-76296471d8b0', '9693f717-503c-4a71-bfa7-ad7a9b6ae85a', 'ca6efe5b-d00b-436c-873f-fd31f913c644', 1, false);
INSERT INTO public."PerguntaResposta" VALUES ('3d9c4a43-5c33-4479-84bb-e93efc6f01c7', '644c6c1e-81b8-4efc-985a-249b9869a230', 'ca6efe5b-d00b-436c-873f-fd31f913c644', 1, false);
INSERT INTO public."PerguntaResposta" VALUES ('2b553268-6690-498a-a3dd-530612192e8f', '644c6c1e-81b8-4efc-985a-249b9869a230', '3b877537-a423-4e4d-89d7-ed46f4cc25c7', 2, false);
INSERT INTO public."PerguntaResposta" VALUES ('2be83916-3530-4e6b-b2ce-f675bb1a37a9', '644c6c1e-81b8-4efc-985a-249b9869a230', '9dfd9097-1d0a-4859-9852-c9b491a42c81', 3, false);
INSERT INTO public."PerguntaResposta" VALUES ('5a1497ca-9a46-41c7-af07-ce4239965682', '84e946ca-a139-4adb-b0f1-6930b1f775b4', 'ca6efe5b-d00b-436c-873f-fd31f913c644', 1, false);
INSERT INTO public."PerguntaResposta" VALUES ('46145256-d0b3-4379-a33a-ea932ec68860', '84e946ca-a139-4adb-b0f1-6930b1f775b4', '3b877537-a423-4e4d-89d7-ed46f4cc25c7', 2, false);
INSERT INTO public."PerguntaResposta" VALUES ('79efd70c-a8c8-41d2-afde-a93f9121485d', '84e946ca-a139-4adb-b0f1-6930b1f775b4', '9dfd9097-1d0a-4859-9852-c9b491a42c81', 3, false);
INSERT INTO public."PerguntaResposta" VALUES ('b5fd7d71-d43c-4905-84d4-ced19404305c', '0bf845cc-29dc-45ec-8bf2-8981cef616df', '68cdf94d-8087-4b80-b2f6-c4545b1cdd19', 1, false);
INSERT INTO public."PerguntaResposta" VALUES ('1ac20dbb-2f19-4a33-a15d-0d83e62c7740', '49c26883-e717-44aa-9aab-1bd8aa870916', '68cdf94d-8087-4b80-b2f6-c4545b1cdd19', 1, false);
INSERT INTO public."PerguntaResposta" VALUES ('e67a0618-6b74-4d51-8aef-90d93d9149c2', '0b38221a-9d50-4cdf-abbd-a9ac092dbe70', '68cdf94d-8087-4b80-b2f6-c4545b1cdd19', 1, false);
INSERT INTO public."PerguntaResposta" VALUES ('6f7f2765-d2c8-4f2d-ab6a-42ae81839f01', 'cfec69be-16fb-453d-8c47-fd5ebc4161ef', '68cdf94d-8087-4b80-b2f6-c4545b1cdd19', 1, false);
INSERT INTO public."PerguntaResposta" VALUES ('87c4ea90-4fe3-44d8-a340-5c551ec2644d', 'ef0e79cd-dc31-4272-ad04-68f79a3a135d', '68cdf94d-8087-4b80-b2f6-c4545b1cdd19', 1, false);
INSERT INTO public."PerguntaResposta" VALUES ('6d54e18a-fc7d-44d7-aefc-ed23531d1324', 'f4aae748-bfd8-482e-aee0-07a1cdad71ff', '68cdf94d-8087-4b80-b2f6-c4545b1cdd19', 1, false);
INSERT INTO public."PerguntaResposta" VALUES ('8bbd9c17-bb86-47b6-8d28-cafd55bb6adb', '67a791d2-089d-40ee-8ddf-c64454ee5c54', '68cdf94d-8087-4b80-b2f6-c4545b1cdd19', 1, false);
INSERT INTO public."PerguntaResposta" VALUES ('b963f904-c466-45f7-8aae-a4ac0d8aa416', '0bf845cc-29dc-45ec-8bf2-8981cef616df', 'ffc9d8ca-e534-42af-97a9-411543832c7b', 2, false);
INSERT INTO public."PerguntaResposta" VALUES ('512b9356-ee7f-411b-abf3-bac3375d813e', '49c26883-e717-44aa-9aab-1bd8aa870916', 'ffc9d8ca-e534-42af-97a9-411543832c7b', 2, false);
INSERT INTO public."PerguntaResposta" VALUES ('ac26c542-4188-44e2-b29d-5d5a1345e91b', '0b38221a-9d50-4cdf-abbd-a9ac092dbe70', 'ffc9d8ca-e534-42af-97a9-411543832c7b', 2, false);
INSERT INTO public."PerguntaResposta" VALUES ('1f2fe62f-84cf-4ab7-99cb-ea41daeff0b1', 'cfec69be-16fb-453d-8c47-fd5ebc4161ef', 'ffc9d8ca-e534-42af-97a9-411543832c7b', 2, false);
INSERT INTO public."PerguntaResposta" VALUES ('a4ca1b9a-ade0-4fb8-9622-3890a8d90c46', 'ef0e79cd-dc31-4272-ad04-68f79a3a135d', 'ffc9d8ca-e534-42af-97a9-411543832c7b', 2, false);
INSERT INTO public."PerguntaResposta" VALUES ('f055c585-d41d-43af-b887-8ec3a0e55f21', 'f4aae748-bfd8-482e-aee0-07a1cdad71ff', 'ffc9d8ca-e534-42af-97a9-411543832c7b', 2, false);
INSERT INTO public."PerguntaResposta" VALUES ('f42fbdfb-d6ab-4f12-b534-0f25c0f83c94', '67a791d2-089d-40ee-8ddf-c64454ee5c54', 'ffc9d8ca-e534-42af-97a9-411543832c7b', 2, false);
INSERT INTO public."PerguntaResposta" VALUES ('d09eca97-8212-466e-91ba-7884b5ecedbd', '18d148be-d83c-4f24-9d03-dc003a05b9e4', '68cdf94d-8087-4b80-b2f6-c4545b1cdd19', 1, false);
INSERT INTO public."PerguntaResposta" VALUES ('9298156a-be71-44aa-a909-3f25551b8f44', '18d148be-d83c-4f24-9d03-dc003a05b9e4', 'ffc9d8ca-e534-42af-97a9-411543832c7b', 2, false);
INSERT INTO public."PerguntaResposta" VALUES ('222a8f56-0146-4c60-a9ba-6edc7dc4ec25', '3173bff2-a148-4634-b029-b50c949ae2d6', '68cdf94d-8087-4b80-b2f6-c4545b1cdd19', 1, false);
INSERT INTO public."PerguntaResposta" VALUES ('42bbabcd-90a8-4a3d-9af4-f4927e257d25', '3173bff2-a148-4634-b029-b50c949ae2d6', 'ffc9d8ca-e534-42af-97a9-411543832c7b', 2, false);
INSERT INTO public."PerguntaResposta" VALUES ('c1e44e54-33e3-4aa5-8757-f272d34066ea', '98940cdb-d229-4282-a2e1-60e4a17dab64', '68cdf94d-8087-4b80-b2f6-c4545b1cdd19', 1, false);
INSERT INTO public."PerguntaResposta" VALUES ('7ddc12f0-3bdc-499c-8371-050d0c19bca7', '98940cdb-d229-4282-a2e1-60e4a17dab64', 'ffc9d8ca-e534-42af-97a9-411543832c7b', 2, false);
INSERT INTO public."PerguntaResposta" VALUES ('52fd59c8-596c-45ff-a38a-fac00eef7597', '9693f717-503c-4a71-bfa7-ad7a9b6ae85a', '3b877537-a423-4e4d-89d7-ed46f4cc25c7', 2, false);
INSERT INTO public."PerguntaResposta" VALUES ('f6a48bf6-acd3-4f9b-abf2-9e2237b0e690', '9693f717-503c-4a71-bfa7-ad7a9b6ae85a', '9dfd9097-1d0a-4859-9852-c9b491a42c81', 3, false);


--
-- TOC entry 3102 (class 0 OID 68330)
-- Dependencies: 225
-- Data for Name: Periodo; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Periodo" VALUES ('c93c1c4a-abb9-43a4-a8cd-283e4df365d8', '1° Semestre', 1, false);
INSERT INTO public."Periodo" VALUES ('8de86d08-b7a1-45df-b775-07550714756b', '2° Semestre', 1, false);
INSERT INTO public."Periodo" VALUES ('fbd8b833-d7dc-4d04-9af6-50c1aaa2f8c0', '1° Bimestre', 2, false);
INSERT INTO public."Periodo" VALUES ('05ce183c-cb37-44fb-9c30-dac5ae5b8d37', '2° Bimestre', 2, false);
INSERT INTO public."Periodo" VALUES ('a8d3311a-b71e-45ce-8667-cef062334949', '3° Bimestre', 2, false);
INSERT INTO public."Periodo" VALUES ('aa7f39fc-3b50-4aea-bd05-4bbe7cba687c', '4° Bimestre', 2, false);


--
-- TOC entry 3105 (class 0 OID 71004)
-- Dependencies: 229
-- Data for Name: PeriodoDeAberturas; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."PeriodoDeAberturas" OVERRIDING SYSTEM VALUE VALUES (1, '2019', 1, '2019-02-02 00:00:00', '2019-04-02 00:00:00');
INSERT INTO public."PeriodoDeAberturas" OVERRIDING SYSTEM VALUE VALUES (2, '2019', 2, '2019-04-02 00:00:00', '2019-05-02 00:00:00');
INSERT INTO public."PeriodoDeAberturas" OVERRIDING SYSTEM VALUE VALUES (3, '2019', 3, '2019-06-02 00:00:00', '2019-08-02 00:00:00');
INSERT INTO public."PeriodoDeAberturas" OVERRIDING SYSTEM VALUE VALUES (4, '2019', 4, '2019-08-02 00:00:00', '2019-10-02 00:00:00');
INSERT INTO public."PeriodoDeAberturas" OVERRIDING SYSTEM VALUE VALUES (5, '2020', 2, '2021-01-12 00:00:00', '2020-02-05 00:00:00');
INSERT INTO public."PeriodoDeAberturas" OVERRIDING SYSTEM VALUE VALUES (6, '2020', 3, '2020-03-05 00:00:00', '2020-08-02 00:00:00');
INSERT INTO public."PeriodoDeAberturas" OVERRIDING SYSTEM VALUE VALUES (7, '2020', 4, '2020-09-03 00:00:00', '2021-12-02 00:00:00');
INSERT INTO public."PeriodoDeAberturas" OVERRIDING SYSTEM VALUE VALUES (8, '2020', 1, '2020-02-01 00:00:00', '2020-03-31 00:00:00');


--
-- TOC entry 3107 (class 0 OID 112556)
-- Dependencies: 234
-- Data for Name: PeriodoFixoAnual; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."PeriodoFixoAnual" OVERRIDING SYSTEM VALUE VALUES (1, 2020, '1° Semestre', '2020-02-01 00:00:00', '2020-06-05 00:00:00', 1, 'c93c1c4a-abb9-43a4-a8cd-283e4df365d8');
INSERT INTO public."PeriodoFixoAnual" OVERRIDING SYSTEM VALUE VALUES (2, 2020, '2° Semestre', '2020-06-05 00:00:00', '2020-12-30 00:00:00', 1, '8de86d08-b7a1-45df-b775-07550714756b');
INSERT INTO public."PeriodoFixoAnual" OVERRIDING SYSTEM VALUE VALUES (3, 2020, '1° Bimestre', '2020-02-01 00:00:00', '2020-03-30 00:00:00', 2, 'fbd8b833-d7dc-4d04-9af6-50c1aaa2f8c0');
INSERT INTO public."PeriodoFixoAnual" OVERRIDING SYSTEM VALUE VALUES (4, 2020, '2° Bimestre', '2020-03-30 00:00:00', '2020-06-04 00:00:00', 2, '05ce183c-cb37-44fb-9c30-dac5ae5b8d37');
INSERT INTO public."PeriodoFixoAnual" OVERRIDING SYSTEM VALUE VALUES (5, 2020, '3° Bimestre', '2020-06-05 00:00:00', '2020-09-30 00:00:00', 2, 'a8d3311a-b71e-45ce-8667-cef062334949');
INSERT INTO public."PeriodoFixoAnual" OVERRIDING SYSTEM VALUE VALUES (6, 2020, '4° Bimestre', '2020-10-01 00:00:00', '2020-12-30 00:00:00', 2, 'aa7f39fc-3b50-4aea-bd05-4bbe7cba687c');


--
-- TOC entry 3096 (class 0 OID 68276)
-- Dependencies: 219
-- Data for Name: Resposta; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Resposta" VALUES ('c48be0b2-df68-4314-b680-27c1bd190e51', 'Classificou corretamente o triângulo e parcialmente o quadrilátero', false, false);
INSERT INTO public."Resposta" VALUES ('8fe12714-a68f-4135-be5f-2e448d8e4cf1', 'Classificou parcialmente o triângulo e o quadrilátero', false, false);
INSERT INTO public."Resposta" VALUES ('ffa53f05-b71e-4ef8-9b10-7c932ca681db', 'Compreende o que é perímetro, mas não compreende o que é área', false, false);
INSERT INTO public."Resposta" VALUES ('84880d69-abbc-460c-a68b-44897f9d93ea', 'Compreende o que é perímetro, mas não compreende o que é área.', false, false);
INSERT INTO public."Resposta" VALUES ('aae9c109-bdb5-4391-b513-e5fd68d39d5a', 'Compreende o que é área, mas não compreende o que é perímetro', false, false);
INSERT INTO public."Resposta" VALUES ('80d96e10-6be4-4ba4-8a84-4a7135e09b59', 'Identificou corretamente a proporcionalidade e indicou a porcentagem corretamente, mas errou os cálculos', false, false);
INSERT INTO public."Resposta" VALUES ('22cbd4e4-582f-46c4-a2ee-ff4f387453bc', 'Identificou corretamente as três medidas de tendência central, mas erros os cálculos', false, false);
INSERT INTO public."Resposta" VALUES ('7abb0305-441f-4d40-baea-4cc3f13a1a50', 'Identificou os nomes das figuras e não determinou elementos de poliedros corretamente', false, false);
INSERT INTO public."Resposta" VALUES ('05df369b-14ff-4eee-9c45-d87c54e2a995', 'Não identificou a probabilidade', false, false);
INSERT INTO public."Resposta" VALUES ('91c73b09-4ae9-4305-92bd-efa68ed9a4db', 'Não identificou corretamente a proporcionalidade e indicou incorretamente a porcentagem', false, false);
INSERT INTO public."Resposta" VALUES ('0218ff47-5565-426c-8d12-07090a1b4ec9', 'Não identificou nomes de figuras e não determinou elementos de poliedros corretamente', false, false);
INSERT INTO public."Resposta" VALUES ('56da5097-d043-475e-a083-edcec0a94fdc', 'Não identificou uma ou mais medidas de tendência central', false, false);
INSERT INTO public."Resposta" VALUES ('0dd19700-303b-46d8-bbc6-48b0c32ac090', 'Não percebeu a regularidade e nem expressou a generalização por meio de uma expressão algébrica', false, false);
INSERT INTO public."Resposta" VALUES ('a04c7a11-52d7-4fbc-9115-2df00eda1ad2', 'Não registrou', false, false);
INSERT INTO public."Resposta" VALUES ('4b9718e1-62e6-413c-ba46-b3dbc4989cb7', 'Percebeu a regularidade, mas não expressou a generalização por meio de uma expressão algébrica', false, false);
INSERT INTO public."Resposta" VALUES ('02483544-6b27-4807-a124-2a1bbd1b24de', 'Representou corretamente a probabilidade na forma fracionária, mas errou as formas decimal e/ou percentual', false, false);
INSERT INTO public."Resposta" VALUES ('bc66297b-3f3a-4d8d-b6c4-ceea1696bc11', 'Resolveu corretamente', false, false);
INSERT INTO public."Resposta" VALUES ('66f5ce70-bd0a-4591-bfa2-ab36d8b62284', 'Resolveu corretamente.', false, false);
INSERT INTO public."Resposta" VALUES ('53911083-6799-4553-8e5e-3eaadec17a55', 'Resolveu o problema incorretamente', false, false);
INSERT INTO public."Resposta" VALUES ('04695943-0abf-4dd7-b8b8-9e850f5d8d2e', 'Resolveu uma parte do problema corretamente', false, false);
INSERT INTO public."Resposta" VALUES ('ca6efe5b-d00b-436c-873f-fd31f913c644', 'Adequada', false, false);
INSERT INTO public."Resposta" VALUES ('3b877537-a423-4e4d-89d7-ed46f4cc25c7', 'Inadequada', false, false);
INSERT INTO public."Resposta" VALUES ('9dfd9097-1d0a-4859-9852-c9b491a42c81', 'Não resolveu', false, false);
INSERT INTO public."Resposta" VALUES ('ffc9d8ca-e534-42af-97a9-411543832c7b', 'false', false, false);
INSERT INTO public."Resposta" VALUES ('68cdf94d-8087-4b80-b2f6-c4545b1cdd19', 'true', false, true);


--
-- TOC entry 3125 (class 0 OID 0)
-- Dependencies: 233
-- Name: PeridodoFixoAnual_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."PeridodoFixoAnual_Id_seq"', 6, true);


--
-- TOC entry 3126 (class 0 OID 0)
-- Dependencies: 228
-- Name: PeriodoDeAberturas_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."PeriodoDeAberturas_Id_seq"', 8, true);


--
-- TOC entry 2953 (class 2606 OID 68266)
-- Name: ComponenteCurricular ComponenteCurricular_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ComponenteCurricular"
    ADD CONSTRAINT "ComponenteCurricular_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2971 (class 2606 OID 68355)
-- Name: GrupoOrdem GrupoOrdem_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."GrupoOrdem"
    ADD CONSTRAINT "GrupoOrdem_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2963 (class 2606 OID 68311)
-- Name: Grupo Grupo_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Grupo"
    ADD CONSTRAINT "Grupo_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2967 (class 2606 OID 68329)
-- Name: OrdemPergunta OrdemPergunta_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."OrdemPergunta"
    ADD CONSTRAINT "OrdemPergunta_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2965 (class 2606 OID 68320)
-- Name: Ordem Ordem_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Ordem"
    ADD CONSTRAINT "Ordem_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2961 (class 2606 OID 68302)
-- Name: PerguntaAnoEscolar PerguntaAnoEscolar_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PerguntaAnoEscolar"
    ADD CONSTRAINT "PerguntaAnoEscolar_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2959 (class 2606 OID 68293)
-- Name: PerguntaResposta PerguntaResposta_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PerguntaResposta"
    ADD CONSTRAINT "PerguntaResposta_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2955 (class 2606 OID 68275)
-- Name: Pergunta Pergunta_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Pergunta"
    ADD CONSTRAINT "Pergunta_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2969 (class 2606 OID 68338)
-- Name: Periodo Periodo_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Periodo"
    ADD CONSTRAINT "Periodo_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2957 (class 2606 OID 68284)
-- Name: Resposta Resposta_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Resposta"
    ADD CONSTRAINT "Resposta_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2972 (class 2606 OID 113721)
-- Name: PeriodoFixoAnual fk_periodo; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PeriodoFixoAnual"
    ADD CONSTRAINT fk_periodo FOREIGN KEY ("PeriodoId") REFERENCES public."Periodo"("Id");