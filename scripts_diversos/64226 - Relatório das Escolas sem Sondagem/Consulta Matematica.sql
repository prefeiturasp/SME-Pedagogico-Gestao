
select t.nomedre
	, t.nomeue 
	, t.sigladre 
	, t.ano
	, t.nometurma 
	, count(pae."Id") > 1 as PossuiSondagem
  from "turmas" t
	left join "Sondagem" s on s."CodigoTurma" = t.turmacodigo::varchar(15)
	left join "SondagemAluno" sa on sa."SondagemId" = s."Id" 
	left join "SondagemAlunoRespostas" sar on sar."SondagemAlunoId" = sa."Id" 
	left join "PerguntaAnoEscolar" pae on pae."PerguntaId" = sar."PerguntaId"
			and pae."FimVigencia" is null
			and pae."AnoEscolar" = 1
			and pae."Grupo" = 2
 where t.ano in (2,3)
  group by t.nomedre
	, t.nomeue 
	, t.sigladre 
	, t.ano
	, t.nometurma 
 