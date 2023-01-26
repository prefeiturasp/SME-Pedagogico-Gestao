--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Finalizando perguntas e respostas do ano de 2022, dos anos escolares do 4º ao 9º

update "PerguntaAnoEscolar" pae 
	set "FimVigencia" = '2022-12-31' 
where "InicioVigencia" = '2022-01-01' 
	and "AnoEscolar" > 3;