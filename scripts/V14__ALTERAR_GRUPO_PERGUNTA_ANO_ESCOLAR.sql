--> Alteração do grupo proficiência para manter o padrão do enumerador ProficienciaEnum
-->1 Numero -> 3
-->2 Campo Aditivo -> 1 
-->3 Campo Multiplicativo -> 2 

update "PerguntaAnoEscolar" set "Grupo" = 0 where "Grupo" = 1 and 21 = (select COUNT(1) from "PerguntaAnoEscolar" where "Grupo" = 1);

update "PerguntaAnoEscolar" set "Grupo" = 1 where "Grupo" = 2 and 22 = (select COUNT(1) from "PerguntaAnoEscolar" where "Grupo" = 2);

update "PerguntaAnoEscolar" set "Grupo" = 2 where "Grupo" = 3 and 11 = (select COUNT(1) from "PerguntaAnoEscolar" where "Grupo" = 3);

update "PerguntaAnoEscolar" set "Grupo" = 3 where "Grupo" = 0;