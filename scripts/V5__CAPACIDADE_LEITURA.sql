delete from "Ordem" o where "Id" in ('2382e530-c426-46fe-83b6-84461257aabc',
	'9913da2a-dc3d-45e6-a1e5-34b386cc1202',
	'd0fcd18f-d626-4ca1-900d-6f85b1ad690f');

delete
from
	"GrupoOrdem" go2
where
	"OrdemId" in ('2382e530-c426-46fe-83b6-84461257aabc',
	'9913da2a-dc3d-45e6-a1e5-34b386cc1202',
	'd0fcd18f-d626-4ca1-900d-6f85b1ad690f');


UPDATE public."Ordem"
	SET "Ordenacao"=3
	WHERE "Id"='ad53a26a-e9d5-4732-a086-212dc20f3af7';
UPDATE public."Ordem"
	SET "Ordenacao"=1
	WHERE "Id"='f4213141-94b9-4b91-a65f-56348a3f8399';
UPDATE public."Ordem"
	SET "Ordenacao"=2
	WHERE "Id"='9467c76f-4b87-43be-93d6-d243e6a856ec';
