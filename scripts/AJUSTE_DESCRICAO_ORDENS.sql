-- Auto-generated SQL script #202010071736
UPDATE public."Ordem"
	SET "Descricao"='Ordem do argumentar'
	WHERE "Id"='ad53a26a-e9d5-4732-a086-212dc20f3af7';
UPDATE public."Ordem"
	SET "Descricao"='Ordem do narrar'
	WHERE "Id"='f4213141-94b9-4b91-a65f-56348a3f8399';
UPDATE public."Ordem"
	SET "Descricao"='Ordem do relatar'
	WHERE "Id"='9467c76f-4b87-43be-93d6-d243e6a856ec';


INSERT INTO public."PeriodoFixoAnual" ("Ano","Descricao","DataInicio","DataFim","TipoPeriodo","PeriodoId") VALUES 
(2020,'1° Semestre','2020-02-01 00:00:00.000','2020-06-05 00:00:00.000',1,'c93c1c4a-abb9-43a4-a8cd-283e4df365d8')
,(2020,'2° Semestre','2020-06-05 00:00:00.000','2020-12-30 00:00:00.000',1,'8de86d08-b7a1-45df-b775-07550714756b')
,(2020,'1° Bimestre','2020-02-01 00:00:00.000','2020-03-30 00:00:00.000',2,'fbd8b833-d7dc-4d04-9af6-50c1aaa2f8c0')
,(2020,'2° Bimestre','2020-03-30 00:00:00.000','2020-06-04 00:00:00.000',2,'05ce183c-cb37-44fb-9c30-dac5ae5b8d37')
,(2020,'3° Bimestre','2020-06-05 00:00:00.000','2020-09-30 00:00:00.000',2,'a8d3311a-b71e-45ce-8667-cef062334949')
,(2020,'4° Bimestre','2020-10-01 00:00:00.000','2020-12-30 00:00:00.000',2,'aa7f39fc-3b50-4aea-bd05-4bbe7cba687c')
;


-- Auto-generated SQL script #202010071812
UPDATE public."OrdemPergunta"
	SET "PerguntaId"='0bf845cc-29dc-45ec-8bf2-8981cef616df'
	WHERE "Id"='73c1a6fd-3c3d-4787-bce1-24765b89a709';
