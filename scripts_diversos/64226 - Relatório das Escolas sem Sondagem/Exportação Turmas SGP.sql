select t.nome as NomeTurma, t.ano, t.turma_id as TurmaCodigo
	, ue.nome as NomeUe
	, dre.abreviacao as SiglaDre, dre.nome as NomeDre
  from turma t 
 inner join ue on ue.id = t.ue_id
 inner join dre on dre.id = ue.dre_id 
 where t.ano_letivo = 2022
   and t.tipo_turma = 1
   and t.modalidade_codigo = 5
   and ue.tipo_escola in (1,3,4,16)
