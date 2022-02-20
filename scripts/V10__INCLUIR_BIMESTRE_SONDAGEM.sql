alter table "SondagemAlunoRespostas" add column if not exists "Bimestre" int4;
alter table "SondagemAluno" add column if not exists "Bimestre" int4;
alter table "Sondagem" add column if not exists "Bimestre" int4;

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Incluindo o campo 'PerguntaAnoEscolarId' na tabela 'PerguntaResposta'
alter table "PerguntaResposta" add "PerguntaAnoEscolarId" text NULL;

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Incluindo o campo 'PerguntaAnoEscolarId' na tabela 'SondagemAlunoRespostas'
alter table "SondagemAlunoRespostas" add "PerguntaAnoEscolarId" text NULL;

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Referenciando campo criado
update "PerguntaResposta" set "PerguntaAnoEscolarId" = '1361d4d5-09c0-45c5-b6a8-a586e7b45a33' where "Id" in ('7d071fc3-accc-4133-8cbf-1f20332ff5c1','a11ad326-34f1-4bb9-9dbe-5fb8ef049514','cb133766-a446-4c95-a65d-2d26b1a4068a','8320dc58-bef3-4f3c-b077-7ce54e6a5d09');
update "PerguntaResposta" set "PerguntaAnoEscolarId" = 'f2d4de2f-e66b-43de-be42-af63ada710ef' where "Id" in ('aff9e7c3-3a5d-45c3-8f54-aab5315761b6','fc4eeadb-0d13-4e2b-8b56-4a90e10c9709','bbc15078-22bf-4262-8b08-cc7b3634fcb6','238b0422-8337-408d-a4a2-d9e15b20e999');
update "PerguntaResposta" set "PerguntaAnoEscolarId" = '50f4cf10-ef5e-45d9-b936-7ea8d73b06a4' where "Id" in ('73f07fca-500f-40ef-be9f-986552ec116d','ce762d7b-87f7-43e8-a3b9-473c2d9dd3b6','bfe55343-993f-4d5a-aa45-3cdc33e774a0','b555f060-93f8-4dcb-bb91-e10f68145c14');
update "PerguntaResposta" set "PerguntaAnoEscolarId" = 'f0543c73-8f1c-4b5f-9319-5a5712460910' where "Id" in ('5e35f5c0-b38a-4acb-9904-2ffbb5aa804c','bf6910f2-0006-4311-8da4-7ed753f5a80d','0a00bafd-797f-4621-9b9e-be6c1ab656e0','1f33668e-42bc-4ac7-b061-769f109f463c');
update "PerguntaResposta" set "PerguntaAnoEscolarId" = '419935cc-8268-4128-8f25-fb0c23acf5d8' where "Id" in ('4872b248-bbcd-4ea6-b536-e8a83bfe3382','7178cf08-6d84-4473-9e66-16f15a15dcab','7793d007-07c0-4f04-9d74-53907e7d9b53','d6c80a80-a70d-4625-a85d-06a30ace186a');
update "PerguntaResposta" set "PerguntaAnoEscolarId" = '56f883ea-e337-4c80-9cda-1e494781f1c9' where "Id" in ('7d071fc3-accc-4133-8cbf-1f20332ff5c1','a11ad326-34f1-4bb9-9dbe-5fb8ef049514','cb133766-a446-4c95-a65d-2d26b1a4068a','8320dc58-bef3-4f3c-b077-7ce54e6a5d09');
update "PerguntaResposta" set "PerguntaAnoEscolarId" = '6ddcd8f6-967e-46c9-889e-48c762682e35' where "Id" in ('aff9e7c3-3a5d-45c3-8f54-aab5315761b6','fc4eeadb-0d13-4e2b-8b56-4a90e10c9709','bbc15078-22bf-4262-8b08-cc7b3634fcb6','238b0422-8337-408d-a4a2-d9e15b20e999');
update "PerguntaResposta" set "PerguntaAnoEscolarId" = '8f3715ab-83fd-4a1c-a664-e936f2757e5c' where "Id" in ('03ce3846-22bf-4807-83b0-e59d40bfe07b','a177b235-41b6-4b36-aa7c-b42c4b5faaec','32de178b-0a5d-4215-bb2c-813d1b520080','4ee882cd-9d46-48d3-bfee-91d7eeade4e7');
update "PerguntaResposta" set "PerguntaAnoEscolarId" = '362050c1-6e4e-47bf-9dbf-cc30df38b383' where "Id" in ('5e35f5c0-b38a-4acb-9904-2ffbb5aa804c','bf6910f2-0006-4311-8da4-7ed753f5a80d','0a00bafd-797f-4621-9b9e-be6c1ab656e0','1f33668e-42bc-4ac7-b061-769f109f463c');
update "PerguntaResposta" set "PerguntaAnoEscolarId" = '9d3bbe25-d0d2-4ce0-b180-a38982f91390' where "Id" in ('6af27793-9d30-4584-984f-36bd1adf9de7','be86b03d-8cad-4a8d-90d7-ae73c4063e3e','e4b8fde0-1dce-4817-b53f-26324bf47a88','01fc5cb8-c994-439d-92d0-2b4fc6295832');
update "PerguntaResposta" set "PerguntaAnoEscolarId" = 'f0d0d99d-2f6e-486f-afd1-5c719e4db459' where "Id" in ('7d071fc3-accc-4133-8cbf-1f20332ff5c1','a11ad326-34f1-4bb9-9dbe-5fb8ef049514','cb133766-a446-4c95-a65d-2d26b1a4068a','8320dc58-bef3-4f3c-b077-7ce54e6a5d09');
update "PerguntaResposta" set "PerguntaAnoEscolarId" = '28e17b2b-6b7e-4a47-821c-61951643c5ba' where "Id" in ('aff9e7c3-3a5d-45c3-8f54-aab5315761b6','fc4eeadb-0d13-4e2b-8b56-4a90e10c9709','bbc15078-22bf-4262-8b08-cc7b3634fcb6','238b0422-8337-408d-a4a2-d9e15b20e999');
update "PerguntaResposta" set "PerguntaAnoEscolarId" = '8bf9f3a6-1bdf-4c88-bd05-3598a6c61684' where "Id" in ('73f07fca-500f-40ef-be9f-986552ec116d','ce762d7b-87f7-43e8-a3b9-473c2d9dd3b6','bfe55343-993f-4d5a-aa45-3cdc33e774a0','b555f060-93f8-4dcb-bb91-e10f68145c14');
update "PerguntaResposta" set "PerguntaAnoEscolarId" = '40284417-9c79-4f97-8ff5-a449662ddadb' where "Id" in ('ef055079-babf-42e9-8ef0-03b27a670936','e6cbf116-8802-4a97-9795-97964f94db57','baa94672-2e2a-4e82-b63f-ede37e9f874c','6b6b965c-df45-495f-b904-f6b54aa25c2b');
update "PerguntaResposta" set "PerguntaAnoEscolarId" = 'b25275f5-bef0-4d64-bddc-e498049c1c9a' where "Id" in ('6af27793-9d30-4584-984f-36bd1adf9de7','be86b03d-8cad-4a8d-90d7-ae73c4063e3e','e4b8fde0-1dce-4817-b53f-26324bf47a88','01fc5cb8-c994-439d-92d0-2b4fc6295832');

