
select t.nomedre
	, t.nomeue 
	, t.sigladre 
	, t.ano
	, t.nometurma 
	, count(pp."Id") > 1 as PossuiSondagem
  from turmas t 
  left join "PortuguesePolls" pp on pp."classroomCodeEol" = t.turmacodigo::varchar(15)
 where t.ano in (1,2,3,4,5,6,7,8)
   --and t.turmacodigo = '2371296'
  group by t.nomedre
	, t.nomeue 
	, t.sigladre 
	, t.ano
	, t.nometurma 
