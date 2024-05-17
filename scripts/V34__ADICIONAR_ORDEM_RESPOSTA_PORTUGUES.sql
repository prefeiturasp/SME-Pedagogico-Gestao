
INSERT INTO public."Pergunta"
("Id", "Descricao", "ComponenteCurricularId", "Excluido", "PerguntaId")
VALUES('0882766a-9375-4e0a-bd39-8d96d75f7a22', 'Sem preenchimento', 'c65b2c0a-7a58-4d40-b474-23f0982f14b1', false, NULL)
ON CONFLICT ("Id") DO NOTHING;


INSERT INTO public."PerguntaResposta"
("Id", "PerguntaId", "RespostaId", "Ordenacao", "Excluido")
VALUES('5a62cace-e356-43db-a5a1-04930d2669a2', '0882766a-9375-4e0a-bd39-8d96d75f7a22', '68cdf94d-8087-4b80-b2f6-c4545b1cdd19', 3, false)
ON CONFLICT ("Id") DO NOTHING;


INSERT INTO public."PerguntaResposta"
("Id", "PerguntaId", "RespostaId", "Ordenacao", "Excluido")
VALUES('302b7379-530a-47b6-9d87-8a12a2f1293e', '0882766a-9375-4e0a-bd39-8d96d75f7a22', 'ffc9d8ca-e534-42af-97a9-411543832c7b', 4, false)
ON CONFLICT ("Id") DO NOTHING;

-- Leitura em voz alta
INSERT INTO public."OrdemPergunta"
("Id", "SequenciaOrdem", "PerguntaId", "Excluido", "OrdenacaoNaTela", "GrupoId")
VALUES('f74431b3-e96d-4e8a-8ba9-eac250025298', 1, '0882766a-9375-4e0a-bd39-8d96d75f7a22', false, 5, '6a3d323a-2c44-4052-ba68-13a8dead299a')
ON CONFLICT ("Id") DO NOTHING;


-- Produção de Texto
INSERT INTO public."OrdemPergunta"
("Id", "SequenciaOrdem", "PerguntaId", "Excluido", "OrdenacaoNaTela", "GrupoId")
VALUES('b1390aa6-7272-4387-b4c5-b21b866d7543', 1, '0882766a-9375-4e0a-bd39-8d96d75f7a22', false, 6, '263b55b8-efa2-480c-80ad-f4e8f0935e12')
ON CONFLICT ("Id") DO NOTHING;