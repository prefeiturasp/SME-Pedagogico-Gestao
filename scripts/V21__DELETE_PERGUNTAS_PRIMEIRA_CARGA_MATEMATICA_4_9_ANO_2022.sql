delete from "Resposta" r where r."Id" 
in (select pr."RespostaId" from "PerguntaResposta" pr where pr."PerguntaId" 
in (select pae."PerguntaId" from "PerguntaAnoEscolar" pae where extract(year from pae."InicioVigencia") = 2022 and "AnoEscolar" > 3));

delete from "PerguntaResposta" pr where pr."PerguntaId" 
in (select pae."PerguntaId" from "PerguntaAnoEscolar" pae where extract(year from pae."InicioVigencia") = 2022 and "AnoEscolar" > 3);

delete from "Pergunta" p where p."Id" 
in (select pae."PerguntaId" from "PerguntaAnoEscolar" pae where extract(year from pae."InicioVigencia") = 2022 and "AnoEscolar" > 3 );

delete from "PerguntaAnoEscolar" pae where extract(year from pae."InicioVigencia") = 2022 and "AnoEscolar" > 3;
