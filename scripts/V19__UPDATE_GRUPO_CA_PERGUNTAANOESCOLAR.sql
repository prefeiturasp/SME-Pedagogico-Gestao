do $$
declare 
	PerguntaId text;
begin
	select "PerguntaId" into PerguntaId from "PerguntaAnoEscolar" where "PerguntaId" in (select "Id"  from "Pergunta" p where "Descricao" = 'Composição') and "Grupo" = 2;
	
	if not PerguntaId is null then    
		update "PerguntaAnoEscolar" set "Grupo" = 1 where "PerguntaId" = PerguntaId;
		update "PerguntaAnoEscolar" set "Grupo" = 1 where "PerguntaId" in (select "Id" from "Pergunta" p where "PerguntaId" = PerguntaId);
		raise notice 'PerguntaAnoEscolar alterada!';
	end if;
end $$;