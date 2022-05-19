UPDATE
	"PerguntaResposta"
SET
	"Ordenacao" = 4
WHERE
	"PerguntaId" IN (
	SELECT
		"Id"
	FROM
		"Pergunta" p
	WHERE
		lower(p."Descricao") = lower('Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Perímetro'))
	AND "RespostaId" IN (
	SELECT
		"Id"
	FROM
		"Resposta" r
	WHERE
		lower(r."Descricao") = lower('Não compreendeu a ideia'))
	AND "Ordenacao" = 2