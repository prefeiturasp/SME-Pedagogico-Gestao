alter table public."PerguntaAnoEscolar" add column if not exists "InicioVigencia" timestamp;
alter table public."PerguntaAnoEscolar" add column if not exists "FimVigencia" timestamp;

