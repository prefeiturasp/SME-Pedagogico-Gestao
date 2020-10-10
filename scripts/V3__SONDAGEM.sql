
CREATE TABLE public."Sondagem" (
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

CREATE TABLE public."SondagemAluno" (
	"Id" uuid NOT NULL,
	"SondagemId" uuid NOT NULL,
	"CodigoAluno" varchar(50) NOT NULL,
	"NomeAluno" varchar(200) NOT NULL,
	CONSTRAINT "SondagemAluno_pkey" PRIMARY KEY ("Id")
);


-- public."SondagemAluno" foreign keys

ALTER TABLE public."SondagemAluno" ADD CONSTRAINT "fk_SondagemId" FOREIGN KEY ("SondagemId") REFERENCES "Sondagem"("Id");


-- public."SondagemAlunoRespostas" definition

-- Drop table

-- DROP TABLE public."SondagemAlunoRespostas";

CREATE TABLE public."SondagemAlunoRespostas" (
	"Id" uuid NOT NULL,
	"SondagemAlunoId" uuid NOT NULL,
	"PerguntaId" text NOT NULL,
	"RespostaId" text NOT NULL,
	CONSTRAINT "SondagemAlunoRespostas_pkey" PRIMARY KEY ("Id")
);


-- public."SondagemAlunoRespostas" foreign keys

ALTER TABLE public."SondagemAlunoRespostas" ADD CONSTRAINT "fk_SondagemAlunoId" FOREIGN KEY ("SondagemAlunoId") REFERENCES "SondagemAluno"("Id");


-- public."SondagemAutoral" definition

-- Drop table

-- DROP TABLE public."SondagemAutoral";

CREATE TABLE public."SondagemAutoral" (
	"Id" text NOT NULL,
	"ComponenteCurricularId" text NOT NULL,
	"PerguntaId" text NOT NULL,
	"RespostaId" text NULL,
	"CodigoAluno" varchar(50) NOT NULL,
	"NomeAluno" varchar(200) NOT NULL,
	"CodigoDre" varchar(50) NOT NULL,
	"CodigoUe" varchar(50) NOT NULL,
	"CodigoTurma" varchar(50) NOT NULL,
	"GrupoId" text NULL,
	"OrdemId" text NULL,
	"AnoTurma" int4 NOT NULL,
	"AnoLetivo" int4 NOT NULL,
	"PeriodoId" text NOT NULL,
	"SequenciaDeOrdemSalva" int4 NULL,
	CONSTRAINT "SondagemAutoral_pkey" PRIMARY KEY ("Id")
);