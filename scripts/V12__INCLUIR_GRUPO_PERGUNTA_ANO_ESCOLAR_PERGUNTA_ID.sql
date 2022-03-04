
alter table public."PerguntaAnoEscolar" drop column if exists "Grupo";
alter table public."PerguntaAnoEscolar" add column "Grupo" int;

alter table public."Pergunta" drop column if exists "PerguntaId";
alter table public."Pergunta" add column "PerguntaId" text null;