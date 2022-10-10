CREATE TABLE "PerguntaAnoEscolarBimestre" (
	"Id" int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	"PerguntaAnoEscolarId" text NOT NULL,
	"Bimestre" int4 NOT NULL,
	CONSTRAINT perguntaAnoEscolarbimestre_pk PRIMARY KEY ("Id")
);

CREATE INDEX perguntaAnoEscolarbimestre_perguntaanoescolar_idx ON public."PerguntaAnoEscolarBimestre" 
USING btree ("PerguntaAnoEscolarId");

ALTER TABLE public."PerguntaAnoEscolarBimestre" ADD CONSTRAINT perguntaAnoEscolarbimestre_perguntaanoescolar_fk 
FOREIGN KEY ("PerguntaAnoEscolarId") REFERENCES "PerguntaAnoEscolar"("Id");