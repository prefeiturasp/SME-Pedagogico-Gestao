ALTER TABLE public."Resposta" ADD "Verdadeiro" bool NOT NULL DEFAULT false;
UPDATE public."Resposta"
	SET "Verdadeiro"=true
	WHERE "Id"='68cdf94d-8087-4b80-b2f6-c4545b1cdd19';
