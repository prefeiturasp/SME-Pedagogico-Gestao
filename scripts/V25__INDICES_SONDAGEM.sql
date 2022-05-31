-- Sondagem
CREATE INDEX sondagem_codigodre_idx ON public."Sondagem" ("CodigoDre");
CREATE INDEX sondagem_codigoue_idx ON public."Sondagem" ("CodigoUe");
CREATE INDEX sondagem_componentecurricularid_idx ON public."Sondagem" ("ComponenteCurricularId");
CREATE INDEX sondagem_anoturma_idx ON public."Sondagem" ("AnoTurma");
CREATE INDEX sondagem_anoletivo_idx ON public."Sondagem" ("AnoLetivo");
CREATE INDEX sondagem_anoturma_idx ON public."Sondagem" ("AnoTurma");

-- Sondaem Aluno
CREATE INDEX sondagemaluno_sondagemid_idx ON public."SondagemAluno" ("SondagemId");
CREATE INDEX sondagemaluno_codigoaluno_idx ON public."SondagemAluno" ("CodigoAluno");

-- Sondagem Aluno Resposta
CREATE INDEX sondagemalunorespostas_sondagemalunoid_idx ON public."SondagemAlunoRespostas" ("SondagemAlunoId");
CREATE INDEX sondagemalunorespostas_perguntaid_idx ON public."SondagemAlunoRespostas" ("PerguntaId");
CREATE INDEX sondagemalunorespostas_respostaid_idx ON public."SondagemAlunoRespostas" ("RespostaId");
