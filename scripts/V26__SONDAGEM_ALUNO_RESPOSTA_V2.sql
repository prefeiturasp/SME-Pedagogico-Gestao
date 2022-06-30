if (select exists (select from information_schema.tables where table_schema = 'public' and table_name = 'SondagemAlunoRespostaV2'))
begin 
	ALTER TABLE public."SondagemAlunoRespostas" RENAME TO "SondagemAlunoRespostasOld";
	ALTER TABLE public."SondagemAlunoRespostaV2" RENAME TO "SondagemAlunoRespostas";
end