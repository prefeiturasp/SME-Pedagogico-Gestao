update "Periodo" set "Descricao" = '1° Semestre' where "Id" = 'c93c1c4a-abb9-43a4-a8cd-283e4df365d8';

update "Periodo" set "Descricao" = '2° Semestre' where "Id" = '8de86d08-b7a1-45df-b775-07550714756b' ;

update "Periodo" set "Descricao" = '1° Bimestre' where "Id" = 'fbd8b833-d7dc-4d04-9af6-50c1aaa2f8c0' ;

update "Periodo" set "Descricao" = '2° Bimestre' where "Id" = '05ce183c-cb37-44fb-9c30-dac5ae5b8d37' ;

update "Periodo" set "Descricao" = '3° Bimestre' where "Id" = 'a8d3311a-b71e-45ce-8667-cef062334949' ;

update "Periodo" set "Descricao" = '4° Bimestre' where "Id" = 'aa7f39fc-3b50-4aea-bd05-4bbe7cba687c' ;

update "ComponenteCurricular" set "Descricao" = 'Língua Portuguesa' where "Id" = 'c65b2c0a-7a58-4d40-b474-23f0982f14b1';

delete from public."PerguntaResposta" where "PerguntaId" = '0ef5e05f-a366-4da1-b6c0-594ae45f57e5';
delete from "OrdemPergunta" op where "Id" = '9e15751d-fe28-424e-8caa-d33b6ccc9c2f';
delete from "OrdemPergunta" op where "Id" = '9bd3885a-5979-4b07-95f8-4755c9ea3362';


insert
	into
	public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId", "Excluido")
values ('3173bff2-a148-4634-b029-b50c949ae2d6', 'Não produziu/entregou em branco', 'c65b2c0a-7a58-4d40-b474-23f0982f14b1', false);

insert
	into
	public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId", "Excluido")
values ('98940cdb-d229-4282-a2e1-60e4a17dab64', 'Não apresentou dificuldades', 'c65b2c0a-7a58-4d40-b474-23f0982f14b1', false);

insert
	into
	"OrdemPergunta" ("Id", "SequenciaOrdem", "PerguntaId", "Excluido", "OrdenacaoNaTela", "GrupoId")
values ('838a12de-8e39-4df2-80f6-0a22c3cd1d54', 1, '3173bff2-a148-4634-b029-b50c949ae2d6', false, 1, '263b55b8-efa2-480c-80ad-f4e8f0935e12');

insert
	into
	"OrdemPergunta" ("Id", "SequenciaOrdem", "PerguntaId", "Excluido", "OrdenacaoNaTela", "GrupoId")
values ('2b0bee5d-09e8-47ae-b067-622ae36e3f49', 1, '98940cdb-d229-4282-a2e1-60e4a17dab64', false, 2, '263b55b8-efa2-480c-80ad-f4e8f0935e12');


UPDATE public."OrdemPergunta"
	SET "OrdenacaoNaTela"=3
	WHERE "Id"='cb512711-007d-49e8-8ede-49a5fad841cb';
UPDATE public."OrdemPergunta"
	SET "OrdenacaoNaTela"=4
	WHERE "Id"='b7b6eb1f-f583-4580-8388-0a3e492dfa9e';
UPDATE public."OrdemPergunta"
	SET "OrdenacaoNaTela"=5
	WHERE "Id"='7ee3a73a-4325-4f86-bd33-a9215288f7e1';
UPDATE public."OrdemPergunta"
	SET "OrdenacaoNaTela"=6
	WHERE "Id"='02d1c996-062a-4981-b0c9-ae65afe75637';


insert
	into
	public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao", "Excluido")
values 
('222a8f56-0146-4c60-a9ba-6edc7dc4ec25', '3173bff2-a148-4634-b029-b50c949ae2d6', '68cdf94d-8087-4b80-b2f6-c4545b1cdd19', 1, false) ,
('42bbabcd-90a8-4a3d-9af4-f4927e257d25', '3173bff2-a148-4634-b029-b50c949ae2d6', 'ffc9d8ca-e534-42af-97a9-411543832c7b', 2, false) ;

insert
	into
	public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao", "Excluido")
values 
('c1e44e54-33e3-4aa5-8757-f272d34066ea', '98940cdb-d229-4282-a2e1-60e4a17dab64', '68cdf94d-8087-4b80-b2f6-c4545b1cdd19', 1, false) ,
('7ddc12f0-3bdc-499c-8371-050d0c19bca7', '98940cdb-d229-4282-a2e1-60e4a17dab64', 'ffc9d8ca-e534-42af-97a9-411543832c7b', 2, false) ;