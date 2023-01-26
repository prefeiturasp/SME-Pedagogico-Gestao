-- Sondagem
CREATE INDEX IF NOT EXISTS sondagem_codigodre_idx ON public."Sondagem" ("CodigoDre");
CREATE INDEX IF NOT EXISTS sondagem_codigoue_idx ON public."Sondagem" ("CodigoUe");
CREATE INDEX IF NOT EXISTS sondagem_componentecurricularid_idx ON public."Sondagem" ("ComponenteCurricularId");
CREATE INDEX IF NOT EXISTS sondagem_anoturma_idx ON public."Sondagem" ("AnoTurma");
CREATE INDEX IF NOT EXISTS sondagem_anoletivo_idx ON public."Sondagem" ("AnoLetivo");
CREATE INDEX IF NOT EXISTS sondagem_codigoturma_idx ON public."Sondagem" ("CodigoTurma");

-- Sondaem Aluno
CREATE INDEX IF NOT EXISTS sondagemaluno_sondagemid_idx ON public."SondagemAluno" ("SondagemId");
CREATE INDEX IF NOT EXISTS sondagemaluno_codigoaluno_idx ON public."SondagemAluno" ("CodigoAluno");

-- Sondagem Aluno Resposta
CREATE INDEX IF NOT EXISTS sondagemalunorespostas_sondagemalunoid_idx ON public."SondagemAlunoRespostas" ("SondagemAlunoId");
CREATE INDEX IF NOT EXISTS sondagemalunorespostas_perguntaid_idx ON public."SondagemAlunoRespostas" ("PerguntaId");
CREATE INDEX IF NOT EXISTS sondagemalunorespostas_respostaid_idx ON public."SondagemAlunoRespostas" ("RespostaId");
