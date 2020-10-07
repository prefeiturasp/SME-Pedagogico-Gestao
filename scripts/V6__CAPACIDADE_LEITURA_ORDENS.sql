
delete from "OrdemPergunta" op where "PerguntaId" = 'c2a181e7-ab8a-4b80-bbdd-53557fcd9583';

delete from "Pergunta" p where "Id" = 'c2a181e7-ab8a-4b80-bbdd-53557fcd9583';

delete from "OrdemPergunta" op where "PerguntaId" = '24527cb2-960f-4988-a71a-0447be46a1c1';

delete from "Pergunta" p where "Id" = '24527cb2-960f-4988-a71a-0447be46a1c1';

UPDATE public."Pergunta"
	SET "Descricao"='Inferência'
	WHERE "Id"='644c6c1e-81b8-4efc-985a-249b9869a230';


DELETE FROM public."OrdemPergunta"
	WHERE "Id"='5b2c2243-f4ce-4780-b0f2-c9735b216fd4';
DELETE FROM public."OrdemPergunta"
	WHERE "Id"='dddd37bf-b6a4-42e7-94f6-d02c9ce96fd4';
DELETE FROM public."OrdemPergunta"
	WHERE "Id"='af51f6ef-99fe-4b9a-93eb-a80b877e6849';
DELETE FROM public."OrdemPergunta"
	WHERE "Id"='edf2d1dc-aadd-4142-aaae-535049f8fe7a';