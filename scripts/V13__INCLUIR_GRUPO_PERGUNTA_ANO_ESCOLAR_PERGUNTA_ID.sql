alter table public."PerguntaAnoEscolar" add column if not exists "Grupo" int;

alter table public."Pergunta" add column if not exists "PerguntaId" text null;