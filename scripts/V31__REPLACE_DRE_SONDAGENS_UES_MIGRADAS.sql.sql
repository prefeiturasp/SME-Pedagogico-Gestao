
--script ajustes para migração de registros Dre Butantã
do $$
declare
	ues record;
begin				  	
	for ues in 
		SELECT * FROM (
		    VALUES 
		    ('400228'),
		    ('309445'),
		    ('309558'),
		    ('019466'),
		    ('700009'),
		    ('400689'),
		    ('019275'),
		    ('307398'),
		    ('019375'),
		    ('019340'),
		    ('019222'),
		    ('400685'),
		    ('400881'),
		    ('018830'),
		    ('019384'),
		    ('400831'),
		    ('400257'),
		    ('019653'),
		    ('019532'),
		    ('019239'),
		    ('308682'),
		    ('019515')
		) AS codigos(ue)
  	loop		
		update "Sondagem" set "CodigoDre" = '108100' 
			where "AnoLetivo" = 2023 
					and "CodigoUe" = ues.ue
					and "CodigoDre" <> '108100';
				
		update "SondagemAutoral" set "CodigoDre" = '108100' 
			where "AnoLetivo" = 2023 
					and "CodigoUe" = ues.ue
					and "CodigoDre" <> '108100';		
		
		update "SondagemAlunoRespostas" set "CodigoDre"	= '108100'
			where "Id" in (select sar."Id" from "SondagemAlunoRespostas" sar 
							inner join "SondagemAluno" sa on sa."Id" = sar."SondagemAlunoId" 
							inner join "Sondagem" s on s."Id" = sa."SondagemId" 
							where  s."AnoLetivo" = 2023
							and sar."CodigoUe" = ues.ue
							and sar."CodigoDre" <> '108100');

		update "PortuguesePolls" set "dreCodeEol"  = '108100' 
			where "schoolYear" = '2023'
					and "schoolCodeEol" = ues.ue
					and "dreCodeEol" <> '108100';			
  	end loop;
end $$


