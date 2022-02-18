alter table "SondagemAlunoRespostas" add column if not exists "Bimestre" int4;
alter table "SondagemAluno" add column if not exists "Bimestre" int4;