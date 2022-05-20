do $$
declare
perguntaId text;
respostaId text;

begin 
	select pae."PerguntaId" into perguntaId from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 7 and pae."Ordenacao" = 2 and pae."InicioVigencia" = '2022-01-01'; 
	select pr."RespostaId" into respostaId from "PerguntaResposta" pr where pr."PerguntaId" = perguntaId and pr."Ordenacao" = 3;
	
    update public."Resposta" 
	set "Descricao" = 'Identifica o tema e a importância do título e da fonte, mas calcula incorretamente o valor da renda familiar per capita (em reais) ou o número de pessoas na família.'
	where "Id" = respostaId;
end $$;