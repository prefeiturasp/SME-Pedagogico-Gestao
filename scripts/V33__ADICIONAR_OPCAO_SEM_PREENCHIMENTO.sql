-- Inserir Resposta sem preenchimento
INSERT INTO public."Resposta" ("Id", "Descricao", "Excluido", "Verdadeiro")
VALUES ('6e4d70c6-d509-4474-aa02-039ebe3f9294', 'Sem preenchimento', false, false)
ON CONFLICT DO NOTHING;



-- inserir perguntas com a resposta sem preenchimento
INSERT INTO public."PerguntaResposta" ("Id" ,"PerguntaId", "RespostaId","Ordenacao","Excluido")
SELECT uuid_generate_v4(),"Id" ,'6e4d70c6-d509-4474-aa02-039ebe3f9294' ,1,false 
from "Pergunta"
ON CONFLICT DO NOTHING;