CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

--DIVIDIDO POR ALTERNATIVA, 1 ALTERNATIVA PARA VÁRIAS PERGUNTAS
do $$
declare 
	respostaId text;
	perguntaId text;
begin
	
insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Acertou o resultado utilizando estratégias convencionais/ cálculo mental.') returning "Id" into respostaId;

--Ordem 1 / 4ano
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Problema do campo multiplicativo envolvendo o significado de configuração retangular','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
values(uuid_generate_v4()::text, perguntaId, 4,1,'2022-01-01');

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

--Ordem 2 / 4ano
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Problema do campo multiplicativo envolvendo o significado de proporcionalidade','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
values(uuid_generate_v4()::text, perguntaId, 4,2,'2022-01-01');

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

--Ordem 1 / 5ano
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Problema do campo multiplicativo envolvendo o significado de configuração retangular','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
values(uuid_generate_v4()::text, perguntaId, 5,1,'2022-01-01');

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

--Ordem 2 / 5 ano
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Problema do campo multiplicativo envolvendo o significado de proporcionalidade','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
values(uuid_generate_v4()::text, perguntaId, 5,2,'2022-01-01');

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

--Ordem 2 / 6 ano
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Números racionais: leitura, escrita, comparação, ordenação e representação na reta numerada; equivalência','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
values(uuid_generate_v4()::text, perguntaId, 6,2,'2022-01-01');

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

--Ordem 3 / 9 ano
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Medidas de comprimento, massa, tempo, temperatura e área/volume','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
values(uuid_generate_v4()::text, perguntaId, 9,3,'2022-01-01');

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

--Ordem 5 / 9 ano
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Relações entre grandezas: diretamente, inversamente ou não proporcionais','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
values(uuid_generate_v4()::text, perguntaId, 9,5,'2022-01-01');

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

--Ordem 6 / 9 ano --MESMA PERGUNTA E RESPOSTA QUE A DO 5 ANO
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Relações entre grandezas: diretamente, inversamente ou não proporcionais';
	
insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
values(uuid_generate_v4()::text, perguntaId, 9,6,'2022-01-01');	

--Ordem 9 / 9 ano 
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Problemas com números reais, porcentagens sucessivas, taxas percentuais e juros simples','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
values(uuid_generate_v4()::text, perguntaId, 9,9,'2022-01-01');

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

--Ordem 10 / 9 ano -- MESMA PERGUNTA E RESPOSTA QUE A DO 9 ANO
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Problemas com números reais, porcentagens sucessivas, taxas percentuais e juros simples';

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
values(uuid_generate_v4()::text, perguntaId, 9,10,'2022-01-01');

end $$;


-------------------------------//------------------------------------------- //-------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Compreendeu a ideia e acertou o resultado utilizando estratégias não convencionais e/ou outras estratégias.') 
returning "Id" into respostaId;

--Ordem 1 / 4ano
	select p."Id" into perguntaId from public."Pergunta" p 
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."AnoEscolar" = 4 and p."Descricao" = 'Problema do campo multiplicativo envolvendo o significado de configuração retangular';
--obs: perguntaano já inserida
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

--Ordem 2 / 4ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."AnoEscolar" = 4 and p."Descricao" = 'Problema do campo multiplicativo envolvendo o significado de proporcionalidade';
--obs: perguntaAno já inserida
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

--Ordem 1 / 5ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."AnoEscolar" = 5 and p."Descricao" = 'Problema do campo multiplicativo envolvendo o significado de configuração retangular';
--obs: perguntaAno já inserida
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

--Ordem 2 / 5ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."AnoEscolar" = 5 and p."Descricao" = 'Problema do campo multiplicativo envolvendo o significado de proporcionalidade';
--obs: perguntaAno já inserida
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

--Ordem 2 / 6ano
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Números racionais: leitura, escrita, comparação, ordenação e representação na reta numerada; equivalência';
--obs: perguntaAno já inserida
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

--Ordem 3 / 9 ano
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Medidas de comprimento, massa, tempo, temperatura e área/volume';
--obs: perguntaAno já inserida
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--Ordem 5 / 9 ano
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Relações entre grandezas: diretamente, inversamente ou não proporcionais';
--obs: perguntaAno já inserida
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--Ordem 6 / 9 ano
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Relações entre grandezas: diretamente, inversamente ou não proporcionais';
--obs: perguntaAno já inserida
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

-- Ordem 9 / 9 ano
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Problemas com números reais, porcentagens sucessivas, taxas percentuais e juros simples';
--obs: perguntaAno já inserida
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--Ordem 10 / 9 ano
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Problemas com números reais, porcentagens sucessivas, taxas percentuais e juros simples';
--obs: perguntaAno já inserida
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

end $$;

-------------------------------------------//-----------------------------------------//------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Compreendeu a ideia e errou o resultado.') 
returning "Id" into respostaId;

--Ordem 1 / 4ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."AnoEscolar" = 4 and p."Descricao" = 'Problema do campo multiplicativo envolvendo o significado de configuração retangular';
--obs: perguntaano já inserida
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--Ordem 2 / 4ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."AnoEscolar" = 4 and p."Descricao" = 'Problema do campo multiplicativo envolvendo o significado de proporcionalidade';
--obs: perguntaAno já inserida
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--Ordem 1 / 5ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."AnoEscolar" = 5 and p."Descricao" = 'Problema do campo multiplicativo envolvendo o significado de configuração retangular';
--obs: perguntaAno já inserida
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--Ordem 2 / 5ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."AnoEscolar" = 5 and p."Descricao" = 'Problema do campo multiplicativo envolvendo o significado de proporcionalidade';
--obs: perguntaAno já inserida
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

-- Ordem 3 / 6 ano
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Álgebra - propriedades da igualdade','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;
	
	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 6,3,'2022-01-01');
	
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

-- Ordem 4 / 6 ano -- PERGUNTA IGUAL A 3 ORDEM, MAS RESPOSTAS DIFERENTES
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Álgebra - propriedades da igualdade','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;
	
	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 6,4,'2022-01-01');
	
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--Ordem 3 / 9 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 9 and p."Descricao" = 'Medidas de comprimento, massa, tempo, temperatura e área/volume';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,2);

--Ordem 5 / 9 ano  -- serve para a 6 ordem
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 9 and p."Descricao" = 'Relações entre grandezas: diretamente, inversamente ou não proporcionais';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,2);

--Ordem 9 / 9 ano  -- serve para a 10 ordem
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 9 and p."Descricao" = 'Problemas com números reais, porcentagens sucessivas, taxas percentuais e juros simples';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,2);
end $$;


-------------------------------------------//-----------------------------------------//------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não resolveu a questão.') 
returning "Id" into respostaId;

--- 4 ano

--Ordem 1 / 4ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."AnoEscolar" = 4 and p."Descricao" = 'Problema do campo multiplicativo envolvendo o significado de configuração retangular';
--obs: perguntaano já inserida
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 2 / 4ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."AnoEscolar" = 4 and p."Descricao" = 'Problema do campo multiplicativo envolvendo o significado de proporcionalidade';
--obs: perguntaAno já inserida
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 3 / 4ano
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Padrões em sequências figurais','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;
	
	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 4,3,'2022-01-01');
	
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 4 / 4ano -- MESMA PERGUNTA E RESPOSTA DA ORDEM 3
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Padrões em sequências figurais';
	
	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 4,4,'2022-01-01');

--Ordem 5 / 4ano
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Localização e movimentação espacial','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;
	
	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 4,5,'2022-01-01');
	
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 6 / 4ano -- MESMA PERGUNTA E RESPOSTA DA ORDEM 5
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Localização e movimentação espacial';
	
	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 4,6,'2022-01-01');

--Ordem 7 / 4ano
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Perímetro','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;
	
	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 4,7,'2022-01-01');
	
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 8 / 4ano -- MESMA PERGUNTA E RESPOSTA DA ORDEM 7
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Perímetro';
	
	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 4,8,'2022-01-01');

--Ordem 9 / 4ano
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Probabilidade e Estatística – leitura e interpretação de gráficos','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;
	
	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 4,9,'2022-01-01');
	
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 10 / 4ano -- MESMA PERGUNTA E RESPOSTA DA ORDEM 9
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';
	
	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 4,10,'2022-01-01');

-- 5 ano

--Ordem 1 / 5ano
	select p."Id" into perguntaId from public."Pergunta" p 
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."AnoEscolar" = 5 and p."Descricao" = 'Problema do campo multiplicativo envolvendo o significado de configuração retangular';
--obs: perguntaAno já inserida
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 2 / 5ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."AnoEscolar" = 5 and p."Descricao" = 'Problema do campo multiplicativo envolvendo o significado de proporcionalidade';
--obs: perguntaAno já inserida
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 3 / 5ano -- PERGUNTA JÁ EXISTE, SÓ NÃO ESTÁ CADASTRADA PARA O ANO DA TURMA
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Álgebra - propriedades da igualdade';

	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 5,3,'2022-01-01');

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 4 / 5ano -- PERGUNTA JÁ EXISTE, SÓ NÃO ESTÁ CADASTRADA PARA O ANO DA TURMA
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Álgebra - propriedades da igualdade';

	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 5,4,'2022-01-01');

--Ordem 5 / 5ano -- PERGUNTA JÁ EXISTE, SÓ NÃO ESTÁ CADASTRADA PARA O ANO DA TURMA
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Localização e movimentação espacial';

	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 5,5,'2022-01-01');

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 5 / 5ano -- PERGUNTA JÁ EXISTE, SÓ NÃO ESTÁ CADASTRADA PARA O ANO DA TURMA
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Localização e movimentação espacial';

	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 5,6,'2022-01-01');

--Ordem 7 / 5ano -- PERGUNTA JÁ EXISTE, SÓ NÃO ESTÁ CADASTRADA PARA O ANO DA TURMA
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Perímetro';

	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 5,7,'2022-01-01');

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 8 / 5ano -- PERGUNTA JÁ EXISTE, SÓ NÃO ESTÁ CADASTRADA PARA O ANO DA TURMA
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Perímetro';

	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 5,8,'2022-01-01');

--Ordem 9 / 5ano -- PERGUNTA JÁ EXISTE, SÓ NÃO ESTÁ CADASTRADA PARA O ANO DA TURMA
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 5,9,'2022-01-01');

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 10 / 5ano -- PERGUNTA JÁ EXISTE, SÓ NÃO ESTÁ CADASTRADA PARA O ANO DA TURMA
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 5,10,'2022-01-01');

-----------------------------//--------------------------------------------
--6 ano
--Ordem 1 / 6ano
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Números racionais: leitura, escrita, comparação, ordenação e representação na reta numerada; equivalência','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;
	
	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 6,1,'2022-01-01');
	
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 2 / 6ano
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Números racionais: leitura, escrita, comparação, ordenação e representação na reta numerada; equivalência';
--obs: perguntaAno já inserida
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 3 / 6ano -- PERGUNTA JÁ EXISTE, SÓ NÃO ESTÁ CADASTRADA PARA O ANO DA TURMA
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."Ordenacao" = 3 and p."Descricao" = 'Álgebra - propriedades da igualdade';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 4 / 6ano -- PERGUNTA JÁ EXISTE, SÓ NÃO ESTÁ CADASTRADA PARA O ANO DA TURMA
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."Ordenacao" = 4 and p."Descricao" = 'Álgebra - propriedades da igualdade';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 5 / 6ano
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Localização e movimentação: representação, descrição e interpretação da localização e/ou movimentação de pontos no 1º quadrante do plano cartesiano','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;
	
	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 6,5,'2022-01-01');
	
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 6 / 6ano -- PERGUNTA JÁ EXISTE, SÓ NÃO ESTÁ CADASTRADA PARA O ANO DA TURMA
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Localização e movimentação: representação, descrição e interpretação da localização e/ou movimentação de pontos no 1º quadrante do plano cartesiano';

	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 6,6,'2022-01-01');

--Ordem 7 / 6ano
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas – Área','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;
	
	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 6,7,'2022-01-01');
	
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 8 / 6ano -- PERGUNTA JÁ EXISTE, SÓ NÃO ESTÁ CADASTRADA PARA O ANO DA TURMA
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas – Área';

	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 6,8,'2022-01-01');

--Ordem 9 / 6ano -- PERGUNTA JÁ EXISTE, SÓ NÃO ESTÁ CADASTRADA PARA O ANO DA TURMA
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 6,9,'2022-01-01');

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 10 / 6ano -- PERGUNTA JÁ EXISTE, SÓ NÃO ESTÁ CADASTRADA PARA O ANO DA TURMA
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 6,10,'2022-01-01');

-----------

-- 7 ano

--Ordem 1 / 7ano
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Planejamento e realização de pesquisas','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;
	
	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 7,1,'2022-01-01');
	
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 2 / 7ano 
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Planejamento e realização de pesquisas','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;

	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 7,2,'2022-01-01');

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 3 / 7ano
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Poliedros: diferenças e similaridades; planificação; exploração e classificação; relações entre os elementos de um poliedro','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;
	
	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 7,3,'2022-01-01');
	
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 4 / 7ano
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Ângulos em polígonos','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;
	
	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 7,4,'2022-01-01');
	
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 5 / 7ano
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Medidas de comprimento, massa, tempo, temperatura e área','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;
	
	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 7,5,'2022-01-01');
	
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 6 / 7ano
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Objeto de conhecimento: Medidas de comprimento, massa, tempo, temperatura e área','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;
	
	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 7,6,'2022-01-01');
	
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 7 / 7ano
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Propriedade da igualdade','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;
	
	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 7,7,'2022-01-01');
	
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 8 / 7ano 
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Propriedade da igualdade','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;

	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 7,8,'2022-01-01');

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 9 / 7ano 
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Números naturais e inteiros: significados, reta numerada e significado das operações','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;
	
	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 7,9,'2022-01-01');
	
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 10 / 7ano -- PERGUNTA JÁ EXISTE, SÓ NÃO ESTÁ CADASTRADA PARA O ANO DA TURMA
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Números naturais e inteiros: significados, reta numerada e significado das operações','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;

	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 7,10,'2022-01-01');

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

-------
-- 8 ano

-- Ordem 1 / 8ano
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Planejamento, execução e relatório de pesquisa','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;
	
	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 8,1,'2022-01-01');
	
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 2 / 8ano 
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Planejamento, execução e relatório de pesquisa','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;

	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 8,2,'2022-01-01');

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

-- Ordem 3 / 8ano
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Poliedros e Medidas de comprimento, massa, tempo, temperatura e área/volume','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;
	
	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 8,3,'2022-01-01');
	
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

-- Ordem 4 / 8ano
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Ângulos em polígonos','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;

	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 8,4,'2022-01-01');

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

-- Ordem 5 / 8ano
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Variação de grandezas: diretamente e inversamente proporcionais ou não proporcionais','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;
	
	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 8,5,'2022-01-01');
	
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 6 / 8ano 
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Variação de grandezas: diretamente e inversamente proporcionais ou não proporcionais','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;

	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 8,6,'2022-01-01');

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 7 / 8ano
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Procedimentos de cálculos, Problemas envolvendo o significado das operações','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;
	
	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 8,7,'2022-01-01');
	
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 8 / 8ano
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Procedimentos de cálculos, Problemas envolvendo o significado das operações','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;

	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 8,8,'2022-01-01');

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 9 / 8ano
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Cálculo de área','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;

	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 8,9,'2022-01-01');

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 10 / 8ano
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Cálculo de volume','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;

	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 8,10,'2022-01-01');

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

-------

-- 9ano
--Ordem 1 / 9ano -- PERGUNTA JÁ EXISTE, SÓ NÃO ESTÁ CADASTRADA PARA O ANO DA TURMA
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Planejamento, execução e relatório de pesquisa';

	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 9,1,'2022-01-01');

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 2 / 9ano -- PERGUNTA JÁ EXISTE, SÓ NÃO ESTÁ CADASTRADA PARA O ANO DA TURMA
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Planejamento, execução e relatório de pesquisa';

	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 9,2,'2022-01-01');

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 3 / 9ano -- PERGUNTA JÁ EXISTE
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Medidas de comprimento, massa, tempo, temperatura e área/volume';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 4 / 9 ano 
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Ângulos em polígonos','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;

	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 9,4,'2022-01-01');

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 5 / 9ano -- PERGUNTA JÁ EXISTE
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Relações entre grandezas: diretamente, inversamente ou não proporcionais';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 6 / 9ano -- PERGUNTA JÁ EXISTE
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Relações entre grandezas: diretamente, inversamente ou não proporcionais';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 7 / 9ano 
	insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
	values (uuid_generate_v4()::text,'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Área','9f3d8467-2f6e-4bcb-a8e9-12e840426aba') 
	returning "Id" into perguntaId;

	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 9,7,'2022-01-01');

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 8 / 9ano -- PERGUNTA JÁ EXISTE
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Área';

	insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
	values(uuid_generate_v4()::text, perguntaId, 9,8,'2022-01-01');

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 9 / 9ano -- PERGUNTA JÁ EXISTE
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Problemas com números reais, porcentagens sucessivas, taxas percentuais e juros simples';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--Ordem 10 / 9ano -- PERGUNTA JÁ EXISTE
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Problemas com números reais, porcentagens sucessivas, taxas percentuais e juros simples';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

end $$;

-------------------------------------------//-----------------------------------------//------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não compreendeu a ideia do problema.') 
returning "Id" into respostaId;

--Ordem 1 / 4ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."AnoEscolar" = 4 and p."Descricao" = 'Problema do campo multiplicativo envolvendo o significado de configuração retangular';
--obs: perguntaAno já inserida
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

--Ordem 2 / 4ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."AnoEscolar" = 4 and p."Descricao" = 'Problema do campo multiplicativo envolvendo o significado de proporcionalidade';
--obs: perguntaAno já inserida
	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

--Ordem 10 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7 and pae."Ordenacao" = 10 and p."Descricao" = 'Números naturais e inteiros: significados, reta numerada e significado das operações';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,4);

end $$;


------------------------/-------------------------/------------------/-------------------

--PELA ORDEM, TODAS AS PERGUNTAS JÁ FORAM INSERIDAS, AGORA SOMENTE AS RESPOSTAS E O RELACIONAMENTO PERGUNTA-RESPOSTA

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Estudante ausente.') 
returning "Id" into respostaId;

--- 4 ano

--Ordem 1 / 4ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."AnoEscolar" = 4 and p."Descricao" = 'Problema do campo multiplicativo envolvendo o significado de configuração retangular';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 2 / 4ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."AnoEscolar" = 4 and p."Descricao" = 'Problema do campo multiplicativo envolvendo o significado de proporcionalidade';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 3 / 4ano -- serve para a ordem 4 
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Padrões em sequências figurais';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 5 / 4ano - serve para a ordem 6 
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Localização e movimentação espacial';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 7 / 4ano 
	select p."Id" into perguntaId from public."Pergunta" p 
	inner join "PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id"
	where pae."Ordenacao" = 7 and p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Perímetro';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 8 / 4ano 
	select p."Id" into perguntaId from public."Pergunta" p 
	inner join "PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id"
	where pae."Ordenacao" = 8 and p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Perímetro';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 9 / 4ano 
	select p."Id" into perguntaId from public."Pergunta" p 
	inner join "PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id"
	where pae."Ordenacao" = 9 and p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 10 / 4ano 
	select p."Id" into perguntaId from public."Pergunta" p 
	inner join "PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id"
	where pae."Ordenacao" = 10 and p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

------

-- 5 ano

--Ordem 1 / 5ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."AnoEscolar" = 5 and p."Descricao" = 'Problema do campo multiplicativo envolvendo o significado de configuração retangular';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 2 / 5ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."AnoEscolar" = 5 and p."Descricao" = 'Problema do campo multiplicativo envolvendo o significado de configuração retangular';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 3 / 5ano -- serve para a ordem 4 
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Álgebra - propriedades da igualdade';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 5 / 5ano  
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Localização e movimentação espacial';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 7 / 5ano  -- serve para a 8 ordem
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Localização e movimentação espacial';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 9 / 5ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."Ordenacao" = 10 and p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 10 / 5ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."Ordenacao" = 10 and p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

---- 
-- 6 ano

--Ordem 1 / 6ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."Ordenacao" = 1 and p."Descricao" = 'Números racionais: leitura, escrita, comparação, ordenação e representação na reta numerada; equivalência';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 2 / 6ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."Ordenacao" = 2 and p."Descricao" = 'Números racionais: leitura, escrita, comparação, ordenação e representação na reta numerada; equivalência';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 3 / 6ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."Ordenacao" = 3 and p."Descricao" = 'Álgebra - propriedades da igualdade';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 4 / 6ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."Ordenacao" = 4 and p."Descricao" = 'Álgebra - propriedades da igualdade';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

-- Ordem 5 / 6 ano -- serve para o 6 ordem 
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Localização e movimentação: representação, descrição e interpretação da localização e/ou movimentação de pontos no 1º quadrante do plano cartesiano';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

-- Ordem 7 / 6 ano -- serve para o 8 ordem 
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas – Área';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

-- Ordem 9 / 6 ano -- serve para o 10 ordem 
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

------

-- 7 ano

--Ordem 1 / 7ano

	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."Ordenacao" = 1 and p."Descricao" = 'Planejamento e realização de pesquisas';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 2 / 7ano

	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."Ordenacao" = 2 and p."Descricao" = 'Planejamento e realização de pesquisas';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 3 / 7ano
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Poliedros: diferenças e similaridades; planificação; exploração e classificação; relações entre os elementos de um poliedro';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 4 / 7ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."AnoEscolar" = 7 and p."Descricao" = 'Ângulos em polígonos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 5 / 7ano
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Medidas de comprimento, massa, tempo, temperatura e área';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 6 / 7ano
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Objeto de conhecimento: Medidas de comprimento, massa, tempo, temperatura e área';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 6 / 7ano
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Objeto de conhecimento: Medidas de comprimento, massa, tempo, temperatura e área';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 7 / 7ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."Ordenacao" = 7 and p."Descricao" = 'Propriedade da igualdade';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 8 / 7ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."Ordenacao" = 8 and p."Descricao" = 'Propriedade da igualdade';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 9 / 7ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."Ordenacao" = 9 and p."Descricao" = 'Números naturais e inteiros: significados, reta numerada e significado das operações';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 10 / 7ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."Ordenacao" = 10 and p."Descricao" = 'Números naturais e inteiros: significados, reta numerada e significado das operações';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

-----

-- 8 ano

--Ordem 1 / 8ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."Ordenacao" = 1 and p."Descricao" = 'Planejamento, execução e relatório de pesquisa';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 2 / 8ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."Ordenacao" = 2 and p."Descricao" = 'Planejamento, execução e relatório de pesquisa';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 3 / 8ano
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Poliedros e Medidas de comprimento, massa, tempo, temperatura e área/volume';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 4 / 8ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."AnoEscolar" = 8 and p."Descricao" = 'Ângulos em polígonos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 5 / 8ano
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Variação de grandezas: diretamente e inversamente proporcionais ou não proporcionais';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 5 / 8ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."Ordenacao" = 5 and p."Descricao" = 'Variação de grandezas: diretamente e inversamente proporcionais ou não proporcionais';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 6 / 8ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."Ordenacao" = 6 and p."Descricao" = 'Variação de grandezas: diretamente e inversamente proporcionais ou não proporcionais';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 7 / 8ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."Ordenacao" = 7 and p."Descricao" = 'Procedimentos de cálculos, Problemas envolvendo o significado das operações';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 8 / 8ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."Ordenacao" = 8 and p."Descricao" = 'Procedimentos de cálculos, Problemas envolvendo o significado das operações';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 9/8ano
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Cálculo de área';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 10/8ano
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Cálculo de volume';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

----- 
--9 ano

--Ordem 1 / 9ano
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Planejamento, execução e relatório de pesquisa';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 2 / 9ano
	select p."Id" into perguntaId from public."Pergunta" p 
    inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."Ordenacao" = 2 and p."Descricao" = 'Planejamento, execução e relatório de pesquisa';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 3 / 9ano
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Medidas de comprimento, massa, tempo, temperatura e área/volume';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 4 / 9ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
    where pae."AnoEscolar" = 9 and p."Descricao" = 'Ângulos em polígonos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 5 / 9ano -- serve para a 6 ordem
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Relações entre grandezas: diretamente, inversamente ou não proporcionais';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 7 / 9ano -- serve para a 8 ordem
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Área';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--Ordem 9 / 9ano -- serve para a 10 ordem
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Problemas com números reais, porcentagens sucessivas, taxas percentuais e juros simples';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

end $$;


---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Compreendeu a ideia de regularidade e acertou a sequência.') 
returning "Id" into respostaId;

--Ordem 3 / 4ano -- serve para a 4 ordem
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Padrões em sequências figurais';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Compreendeu a ideia de regularidade, mas não acertou a sequência.') 
returning "Id" into respostaId;

--Ordem 3 / 4ano -- serve para a 4 ordem
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Padrões em sequências figurais';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Copiou segmento(s) da sequência existente na situação-problema.') 
returning "Id" into respostaId;

--Ordem 3 / 4ano -- serve para a 4 ordem
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Padrões em sequências figurais';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Compreendeu a ideia de localização e movimentação.') 
returning "Id" into respostaId;

--Ordem 4 / 4ano -- serve para a 6 ordem
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId"  = p."Id" 
	where pae."AnoEscolar" = 4 and p."Descricao" = 'Localização e movimentação espacial';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

--Ordem 5 / 5ano -- serve para a 6 ordem
	select p."Id" into perguntaId from public."Pergunta" p 	
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId"  = p."Id" 
	where pae."AnoEscolar" = 5 and p."Descricao" = 'Localização e movimentação espacial';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não compreende a ideia de regularidade.') 
returning "Id" into respostaId;

--Ordem 3 / 4ano -- serve para a 4 ordem
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId"  = p."Id" 
	where pae."AnoEscolar" = 4 and p."Descricao" = 'Padrões em sequências figurais';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

--Ordem 5 / 5ano -- serve para a 6 ordem
	select p."Id" into perguntaId from public."Pergunta" p 	
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId"  = p."Id" 
	where pae."AnoEscolar" = 5 and p."Descricao" = 'Localização e movimentação espacial';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Compreendeu a ideia de localização, mas errou os comandos, confundindo direita com esquerda, e vice-versa.') 
returning "Id" into respostaId;

--Ordem 4 / 4ano -- serve para a 6 ordem
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId"  = p."Id" 
	where pae."AnoEscolar" = 4 and p."Descricao" = 'Localização e movimentação espacial';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

--Ordem 5 / 5ano -- serve para a 6 ordem
	select p."Id" into perguntaId from public."Pergunta" p 	
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId"  = p."Id" 
	where pae."AnoEscolar" = 5 and p."Descricao" = 'Localização e movimentação espacial';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

end $$;

---------------------------//------------------------------//--------------------------
do $$
declare 
	respostaId text;
	perguntaId text;
begin
	
insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Compreendeu a ideia de movimentação, mas não utilizou a linguagem matemática convencional.') 
returning "Id" into respostaId;

--Ordem 5 / 4ano -- serve para a 6 ordem
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId"  = p."Id" 
	where pae."AnoEscolar" = 4 and p."Descricao" = 'Localização e movimentação espacial';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);
end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não compreendeu a ideia de localização e movimentação.') 
returning "Id" into respostaId;

--Ordem 5 / 4ano -- serve para a 6 ordem
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId"  = p."Id" 
	where pae."AnoEscolar" = 4 and p."Descricao" = 'Localização e movimentação espacial';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Compreendeu a ideia de perímetro e acertou o resultado.') 
returning "Id" into respostaId;

--Ordem 7 / 4 ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where pae."Ordenacao" = 7 and p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Perímetro';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Compreendeu a ideia de perímetro, mas errou o resultado.') 
returning "Id" into respostaId;

--Ordem 7 / 4 ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where pae."Ordenacao" = 7 and p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Perímetro';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Indicou apenas a soma entre a medida da largura e do comprimento.') 
returning "Id" into respostaId;

--Ordem 7 / 4 ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where pae."Ordenacao" = 7 and p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Perímetro';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não compreendeu a ideia.') 
returning "Id" into respostaId;

--Ordem 7 / 4 ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where pae."Ordenacao" = 7 and pae."AnoEscolar" = 4 and p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Perímetro';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

--Ordem 8 / 4 ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where pae."Ordenacao" = 8 and pae."AnoEscolar" = 4 and p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Perímetro';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

--Ordem 7 / 5 ano - serve para o 8 ordem
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where pae."AnoEscolar" = 5 and p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Perímetro';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

--Ordem 3 / 6 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where pae."AnoEscolar" = 6 and pae."Ordenacao" = 3 and p."Descricao" = 'Álgebra - propriedades da igualdade';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

--Ordem 4 / 6 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where pae."AnoEscolar" = 6 and pae."Ordenacao" = 4 and p."Descricao" = 'Álgebra - propriedades da igualdade';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

--Ordem 5 / 6 ano -- serve para a 6 ordem
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Localização e movimentação: representação, descrição e interpretação da localização e/ou movimentação de pontos no 1º quadrante do plano cartesiano';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

--Ordem 7 / 6 ano -- serve para a 8 ordem
	select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Área';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Compreendeu a ideia de perímetro.') 
returning "Id" into respostaId;

--Ordem 8 / 4 ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where pae."Ordenacao" = 8 and pae."AnoEscolar" = 4 and p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Perímetro';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

--Ordem 7 / 5 ano -- serve para a 8 ordem
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where pae."AnoEscolar" = 5 and p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Perímetro';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Compreendeu a ideia, mas errou o cálculo.') 
returning "Id" into respostaId;

--Ordem 8 / 4 ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where pae."Ordenacao" = 8 and pae."AnoEscolar" = 4 and p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Perímetro';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

--Ordem 7 / 5 ano -- serve para a 8 ordem
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where pae."AnoEscolar" = 5 and p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Perímetro';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Calculou apenas com os valores dispostos.') 
returning "Id" into respostaId;

--Ordem 8 / 4 ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where pae."Ordenacao" = 8 and pae."AnoEscolar" = 4 and p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Perímetro';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Realizou a leitura de dados explícitos e implícitos.') 
returning "Id" into respostaId;

--Ordem 9 / 4 ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where pae."Ordenacao" = 9 and pae."AnoEscolar" = 4 and p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

--Ordem 9 / 6 ano - serve para a 10 ordem
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where pae."AnoEscolar" = 6 and p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Realizou somente a leitura de dados explícitos no gráfico.') 
returning "Id" into respostaId;

--Ordem 8 / 4 ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where pae."Ordenacao" = 9 and pae."AnoEscolar" = 4 and p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

--Ordem 9 / 6 ano - serve para a 10 ordem
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where pae."AnoEscolar" = 6 and p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Realizou a leitura de dados explícitos e compreendeu a ideia de dado implícito, mas não o identificou corretamente.') 
returning "Id" into respostaId;

--Ordem 8 / 4 ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where pae."Ordenacao" = 9 and pae."AnoEscolar" = 4 and p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não realizou a leitura de dados explícitos em gráficos.') 
returning "Id" into respostaId;

--Ordem 8 / 4 ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where pae."Ordenacao" = 9 and pae."AnoEscolar" = 4 and p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

--Ordem 9 / 6 ano - serve para a 10 ordem
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where pae."AnoEscolar" = 6 and p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Compreendeu a ideia, explicitando adequadamente na tabela os dados do gráfico.') 
returning "Id" into respostaId;

--Ordem 10 / 4 ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where pae."Ordenacao" = 10 and pae."AnoEscolar" = 4 and p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

--Ordem 10 / 5 ano - serve para a 10 ordem
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where pae."AnoEscolar" = 5 and pae."Ordenacao" = 10 and p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Compreendeu a ideia, mas inverteu a correlação dos dados linha/coluna.') 
returning "Id" into respostaId;

--Ordem 10 / 4 ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where pae."Ordenacao" = 10 and pae."AnoEscolar" = 4 and p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

--Ordem 10 / 5 ano - serve para a 10 ordem
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where pae."AnoEscolar" = 5 and pae."Ordenacao" = 10 and p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não correlacionou corretamente os dados de linha e coluna.') 
returning "Id" into respostaId;

--Ordem 10 / 4 ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where pae."Ordenacao" = 10 and pae."AnoEscolar" = 4 and p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--Ordem 10/ 5 ano - serve para a 10 ordem
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where pae."AnoEscolar" = 5 and pae."Ordenacao" = 10 and p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não realizou a leitura de dados explícitos no gráfico.') 
returning "Id" into respostaId;

--Ordem 10 / 4 ano
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where pae."Ordenacao" = 10 and pae."AnoEscolar" = 4 and p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);
end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não compreendeu a ideia da situação-problema.') 
returning "Id" into respostaId;

--Ordem 1 / 5 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 5 and p."Descricao" = 'Problema do campo multiplicativo envolvendo o significado de configuração retangular';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

--Ordem 2 / 5 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 5 and p."Descricao" = 'Problema do campo multiplicativo envolvendo o significado de proporcionalidade';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

--Ordem 5 / 9 ano - serve para a 6 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 9 and p."Descricao" = 'Relações entre grandezas: diretamente, inversamente ou não proporcionais';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

--Ordem 9 / 9 ano - serve para a 10 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 9 and p."Descricao" = 'Problemas com números reais, porcentagens sucessivas, taxas percentuais e juros simples';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 1);
end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Compreendeu a ideia de igualdade e acertou o resultado.') 
returning "Id" into respostaId;

--Ordem 4 / 5 ano - serve para a 2 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 5 and p."Descricao" = 'Álgebra - propriedades da igualdade';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Compreendeu a ideia de igualdade, mas não acertou o resultado.') 
returning "Id" into respostaId;

--Ordem 4 / 5 ano - serve para a 2 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 5 and p."Descricao" = 'Álgebra - propriedades da igualdade';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Copiou dado(s) existente na situação-problema.') 
returning "Id" into respostaId;

--Ordem 4 / 5 ano - serve para a 2 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 5 and p."Descricao" = 'Álgebra - propriedades da igualdade';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Realizou uma operação aleatória com os dados apresentados pelo problema que não conduziu a resposta correta.') 
returning "Id" into respostaId;

--Ordem 4 / 5 ano - serve para a 2 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 5 and p."Descricao" = 'Álgebra - propriedades da igualdade';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Compreende a ideia de movimentação, mas não utiliza linguagem convencional.') 
returning "Id" into respostaId;

--Ordem 5 / 5 ano - serve para a 2 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 5 and p."Descricao" = 'Localização e movimentação espacial';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não compreende a ideia de localização e movimentação.') 
returning "Id" into respostaId;

--Ordem 5 / 5 ano - serve para a 2 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 5 and p."Descricao" = 'Localização e movimentação espacial';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Compreendeu a ideia, mas errou o cálculo.') 
returning "Id" into respostaId;

--Ordem 7 / 5 ano - serve para a 8 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 5 and p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Perímetro';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

--Ordem 7 /6 ano - serve para a 8 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 6 and p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas – Área';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

end $$;


---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Calculou apenas com os valores apresentados na questão.') 
returning "Id" into respostaId;

--Ordem 7 / 5 ano - serve para a 8 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 5 and p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Perímetro';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Realiza a leitura de dados explícitos e implícitos.') 
returning "Id" into respostaId;

--Ordem 7 / 5 ano - serve para a 8 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 5 and pae."Ordenacao" = 9 and p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Realiza a leitura de dados explícitos e compreende a ideia de dado implícito, mas não o identifica corretamente.') 
returning "Id" into respostaId;

--Ordem 7 / 5 ano - serve para a 8 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 5 and pae."Ordenacao" = 9 and p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Realiza somente a leitura de dados explícitos no gráfico.') 
returning "Id" into respostaId;

--Ordem 7 / 5 ano - serve para a 8 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 5 and pae."Ordenacao" = 9 and p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não realiza a leitura de dados explícitos em gráficos.') 
returning "Id" into respostaId;

--Ordem 7 / 5 ano - serve para a 8 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 5 and pae."Ordenacao" = 9 and p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não realiza a leitura de dados explícitos no gráfico.') 
returning "Id" into respostaId;

--Ordem 7 / 5 ano - serve para a 8 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 5 and pae."Ordenacao" = 10 and p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não realiza a leitura de dados explícitos no gráfico.') 
returning "Id" into respostaId;

--Ordem 7 / 5 ano - serve para a 8 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 5 and pae."Ordenacao" = 10 and p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Comparou e/ou ordenou números racionais na representação decimal.') 
returning "Id" into respostaId;

--Ordem 1 / 6 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 6 and pae."Ordenacao" = 1 and p."Descricao" = 'Números racionais: leitura, escrita, comparação, ordenação e representação na reta numerada; equivalência';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Comparou e/ou ordenou números racionais na representação decimal.') 
returning "Id" into respostaId;

--Ordem 1 / 6 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 6 and pae."Ordenacao" = 1 and p."Descricao" = 'Números racionais: leitura, escrita, comparação, ordenação e representação na reta numerada; equivalência';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Fez a leitura de números racionais como se fossem números naturais, colocando em ordem decrescente.') 
returning "Id" into respostaId;

--Ordem 1 / 6 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 6 and pae."Ordenacao" = 1 and p."Descricao" = 'Números racionais: leitura, escrita, comparação, ordenação e representação na reta numerada; equivalência';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Fez a leitura de números racionais como se fossem números naturais, colocando em ordem crescente.') 
returning "Id" into respostaId;

--Ordem 1 / 6 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 6 and pae."Ordenacao" = 1 and p."Descricao" = 'Números racionais: leitura, escrita, comparação, ordenação e representação na reta numerada; equivalência';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não comparou e/ou ordenou números racionais na representação decimal.') 
returning "Id" into respostaId;

--Ordem 1 / 6 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 6 and pae."Ordenacao" = 1 and p."Descricao" = 'Números racionais: leitura, escrita, comparação, ordenação e representação na reta numerada; equivalência';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Compreendeu que o número racional apresentado representa uma parte de um inteiro, mas não encontrou o valor exato.') 
returning "Id" into respostaId;

--Ordem 1 / 6 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 6 and pae."Ordenacao" = 1 and p."Descricao" = 'Números racionais: leitura, escrita, comparação, ordenação e representação na reta numerada; equivalência';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Compreendeu que o número racional apresentado representa uma parte de um inteiro, mas não encontrou o valor exato.') 
returning "Id" into respostaId;

--Ordem 2 / 6 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 6 and pae."Ordenacao" = 1 and p."Descricao" = 'Números racionais: leitura, escrita, comparação, ordenação e representação na reta numerada; equivalência';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Compreendeu a ideia e acertou o resultado.') 
returning "Id" into respostaId;

--Ordem 3 / 6 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 6 and pae."Ordenacao" = 3 and p."Descricao" = 'Álgebra - propriedades da igualdade';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

--Ordem 4 / 6 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 6 and pae."Ordenacao" = 4 and p."Descricao" = 'Álgebra - propriedades da igualdade';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Copiou dado(s) existente(s) no problema.') 
returning "Id" into respostaId;

--Ordem 3 / 6 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 6 and pae."Ordenacao" = 3 and p."Descricao" = 'Álgebra - propriedades da igualdade';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Compreendeu parcialmente a ideia, acertando parte do(s) resultado(s).') 
returning "Id" into respostaId;

--Ordem 4 / 6 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 6 and pae."Ordenacao" = 4 and p."Descricao" = 'Álgebra - propriedades da igualdade';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Compreendeu a ideia de plano cartesiano e acertou as coordenadas.') 
returning "Id" into respostaId;

--Ordem 5 / 6 ano - serve para a 6 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 6 and p."Descricao" = 'Localização e movimentação: representação, descrição e interpretação da localização e/ou movimentação de pontos no 1º quadrante do plano cartesiano';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Compreendeu a ideia, acertando parte da(s) da(s) coordenada(s).') 
returning "Id" into respostaId;

--Ordem 5 / 6 ano - serve para a 6 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 6 and p."Descricao" = 'Localização e movimentação: representação, descrição e interpretação da localização e/ou movimentação de pontos no 1º quadrante do plano cartesiano';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Compreendeu a ideia, mas inverteu a localização nos eixos.') 
returning "Id" into respostaId;

--Ordem 5 / 6 ano - serve para a 6 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 6 and p."Descricao" = 'Localização e movimentação: representação, descrição e interpretação da localização e/ou movimentação de pontos no 1º quadrante do plano cartesiano';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Compreendeu a ideia de área.') 
returning "Id" into respostaId;

--Ordem 7 / 6 ano - serve para a 8 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 6 and p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas – Área';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

--Ordem 7/ 9 ano - serve para a 8 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 9 and p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Área';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Calculou apenas com os valores dispostos na situação-problema.') 
returning "Id" into respostaId;

--Ordem 7 / 6 ano - serve para a 8 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 6 and p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas – Área';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--Ordem 7 / 9 ano - serve para a 8 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 9 and p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Área';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

end $$;


---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Realizou a leitura de dados explícitos e compreendeu a ideia de dado implícito, mas não o identificou corretamente.') 
returning "Id" into respostaId;

--Ordem 9 / 6 ano - serve para a 10 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 6 and p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

--Ordem 7 / 9 ano - serve para a 8 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 9 and p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Área';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

end $$;


---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não realizou a leitura de dados explícitos em gráficos.') 
returning "Id" into respostaId;

--Ordem 9 / 6 ano - serve para a 10 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 6 and p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

--Ordem 7 / 9 ano - serve para a 8 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 9 and p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Área';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não conheceu as terminologias envolvendo uma pesquisa que apareceram na questão.') 
returning "Id" into respostaId;

--Ordem 1 / 7 ano  
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7  and pae."Ordenacao" = 1 and p."Descricao" = 'Planejamento e realização de pesquisas';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Conheceu um pouco as terminologias que apareceram na questão e que fazem parte de uma pesquisa.') 
returning "Id" into respostaId;

--Ordem 1 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7  and pae."Ordenacao" = 1 and p."Descricao" = 'Planejamento e realização de pesquisas';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Conheceu a maioria das terminologias que apareceram na questão e que fazem parte de uma pesquisa.') 
returning "Id" into respostaId;

--Ordem 1 / 7 ano  
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7  and pae."Ordenacao" = 1 and p."Descricao" = 'Planejamento e realização de pesquisas';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Calculou o valor da renda familiar per capita (em reais) e o número de pessoas na família.') 
returning "Id" into respostaId;

--Ordem 2 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7  and pae."Ordenacao" = 2 and p."Descricao" = 'Planejamento e realização de pesquisas';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

--Ordem 2 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8 and pae."Ordenacao" = 2 and p."Descricao" = 'Planejamento, execução e relatório de pesquisa';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

--Ordem 2 / 9 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 9 and pae."Ordenacao" = 2 and p."Descricao" = 'Planejamento, execução e relatório de pesquisa';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não calculou o valor da renda familiar per capita (em reais) e o número de pessoas na família.') 
returning "Id" into respostaId;

--Ordem 2 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7  and pae."Ordenacao" = 2 and p."Descricao" = 'Planejamento e realização de pesquisas';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

--Ordem 2 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8 and pae."Ordenacao" = 2 and p."Descricao" = 'Planejamento, execução e relatório de pesquisa';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

--Ordem 2 / 9 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 9 and pae."Ordenacao" = 2 and p."Descricao" = 'Planejamento, execução e relatório de pesquisa';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);
end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Identificou o tema e a importância do título e da fonte.') 
returning "Id" into respostaId;

--Ordem 2 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7  and pae."Ordenacao" = 2 and p."Descricao" = 'Planejamento e realização de pesquisas';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--Ordem 2 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8 and pae."Ordenacao" = 2 and p."Descricao" = 'Planejamento, execução e relatório de pesquisa';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

--Ordem 2 / 9 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 9 and pae."Ordenacao" = 2 and p."Descricao" = 'Planejamento, execução e relatório de pesquisa';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não identificou o tema e nem a importância do título e da fonte.') 
returning "Id" into respostaId;

--Ordem 2 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7  and pae."Ordenacao" = 2 and p."Descricao" = 'Planejamento e realização de pesquisas';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

--Ordem 2 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8 and pae."Ordenacao" = 2 and p."Descricao" = 'Planejamento, execução e relatório de pesquisa';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

--Ordem 2 / 9 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 9 and pae."Ordenacao" = 2 and p."Descricao" = 'Planejamento, execução e relatório de pesquisa';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);
end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não reconheceu os sólidos geométricos.') 
returning "Id" into respostaId;

--Ordem 3 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7  and pae."Ordenacao" = 3 and p."Descricao" = 'Poliedros: diferenças e similaridades; planificação; exploração e classificação; relações entre os elementos de um poliedro';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Reconheceu três sólidos geométricos.') 
returning "Id" into respostaId;

--Ordem 3 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7  and pae."Ordenacao" = 3 and p."Descricao" = 'Poliedros: diferenças e similaridades; planificação; exploração e classificação; relações entre os elementos de um poliedro';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

end $$;


---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Reconheceu alguns sólidos geométricos.') 
returning "Id" into respostaId;

--Ordem 3 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7  and pae."Ordenacao" = 3 and p."Descricao" = 'Poliedros: diferenças e similaridades; planificação; exploração e classificação; relações entre os elementos de um poliedro';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

end $$;


---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Reconheceu os quatro sólidos geométricos.') 
returning "Id" into respostaId;

--Ordem 3 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7  and pae."Ordenacao" = 3 and p."Descricao" = 'Poliedros: diferenças e similaridades; planificação; exploração e classificação; relações entre os elementos de um poliedro';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não identificou medidas de ângulos.') 
returning "Id" into respostaId;

--Ordem 4 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7 and p."Descricao" = 'Ângulos em polígonos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Reconheceu um ou dois tipos de ângulos.') 
returning "Id" into respostaId;

--Ordem 4 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7 and p."Descricao" = 'Ângulos em polígonos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Reconheceu várias medidas de ângulos.') 
returning "Id" into respostaId;

--Ordem 4 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7 and p."Descricao" = 'Ângulos em polígonos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Reconheceu todas as medidas de ângulos solicitadas.') 
returning "Id" into respostaId;

--Ordem 4 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7 and p."Descricao" = 'Ângulos em polígonos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não identificou medidas de tempo.') 
returning "Id" into respostaId;

--Ordem 5 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7 and p."Descricao" = 'Medidas de comprimento, massa, tempo, temperatura e área';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Identificou medidas de tempo, mas não diferenciou a hora de minuto.') 
returning "Id" into respostaId;

--Ordem 5 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7 and p."Descricao" = 'Medidas de comprimento, massa, tempo, temperatura e área';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Identificou medidas de tempo, diferenciou a hora de minuto, mas teve dificuldade em conversões.') 
returning "Id" into respostaId;

--Ordem 5 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7 and p."Descricao" = 'Medidas de comprimento, massa, tempo, temperatura e área';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Identificou medidas de tempo e realizou conversões.') 
returning "Id" into respostaId;

--Ordem 5 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7 and p."Descricao" = 'Medidas de comprimento, massa, tempo, temperatura e área';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não reconheceu o significado de perímetro e área.') 
returning "Id" into respostaId;

--Ordem 6 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7 and p."Descricao" = 'Objeto de conhecimento: Medidas de comprimento, massa, tempo, temperatura e área';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Calculou somente perímetros.') 
returning "Id" into respostaId;

--Ordem 6 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7 and p."Descricao" = 'Objeto de conhecimento: Medidas de comprimento, massa, tempo, temperatura e área';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Calculou somente áreas.') 
returning "Id" into respostaId;

--Ordem 6 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7 and p."Descricao" = 'Objeto de conhecimento: Medidas de comprimento, massa, tempo, temperatura e área';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Calculou perímetros e áreas.') 
returning "Id" into respostaId;

--Ordem 6 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7 and p."Descricao" = 'Objeto de conhecimento: Medidas de comprimento, massa, tempo, temperatura e área';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Calculou o valor da massa de cada bola de tênis para manter o equilíbrio da balança utilizando a propriedade da igualdade.') 
returning "Id" into respostaId;

--Ordem 7 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7 and pae."Ordenacao" = 7 and p."Descricao" = 'Propriedade da igualdade';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não calculou o valor da massa de cada bola de tênis para manter o equilíbrio da balança utilizando a propriedade da igualdade.') 
returning "Id" into respostaId;

--Ordem 7 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7 and pae."Ordenacao" = 7 and p."Descricao" = 'Propriedade da igualdade';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,2);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Escreveu corretamente como encontrou a resposta.') 
returning "Id" into respostaId;

--Ordem 7 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7  and pae."Ordenacao" = 7 and p."Descricao" = 'Propriedade da igualdade';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não escreveu como encontrou a resposta.') 
returning "Id" into respostaId;

--Ordem 7 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7 and pae."Ordenacao" = 7 and p."Descricao" = 'Propriedade da igualdade';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,4);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Calculou a idade de Osmir.') 
returning "Id" into respostaId;

--Ordem 8 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7 and pae."Ordenacao" = 8 and p."Descricao" = 'Propriedade da igualdade';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não calculou a idade de Osmir.') 
returning "Id" into respostaId;

--Ordem 8 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7 and pae."Ordenacao" = 8 and p."Descricao" = 'Propriedade da igualdade';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,2);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Utilizou a escrita algébrica para encontrar a idade de Osmir.') 
returning "Id" into respostaId;

--Ordem 8 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7 and pae."Ordenacao" = 8 and p."Descricao" = 'Propriedade da igualdade';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não utilizou a escrita algébrica para encontrar a idade de Osmir.') 
returning "Id" into respostaId;

--Ordem 8 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7 and pae."Ordenacao" = 8 and p."Descricao" = 'Propriedade da igualdade';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,4);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Resolveu o problema envolvendo um dos significados dos números inteiros.') 
returning "Id" into respostaId;

--Ordem 9 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7 and pae."Ordenacao" = 9 and p."Descricao" = 'Números naturais e inteiros: significados, reta numerada e significado das operações';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Identificou a temperatura correta no termômetro.') 
returning "Id" into respostaId;

--Ordem 9 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7 and pae."Ordenacao" = 9 and p."Descricao" = 'Números naturais e inteiros: significados, reta numerada e significado das operações';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não identificar a temperatura no termômetro.') 
returning "Id" into respostaId;

--Ordem 9 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7 and pae."Ordenacao" = 9 and p."Descricao" = 'Números naturais e inteiros: significados, reta numerada e significado das operações';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,4);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Resolveu o problema corretamente utilizando alguma operação numérica.') 
returning "Id" into respostaId;

--Ordem 10 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7 and pae."Ordenacao" = 10 and p."Descricao" = 'Números naturais e inteiros: significados, reta numerada e significado das operações';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Resolveu o problema corretamente utilizando outro tipo representação.') 
returning "Id" into respostaId;

--Ordem 10 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7 and pae."Ordenacao" = 10 and p."Descricao" = 'Números naturais e inteiros: significados, reta numerada e significado das operações';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,2);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Resolveu incorretamente, pois utiliza apenas uma das informações.') 
returning "Id" into respostaId;

--Ordem 10 / 7 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 7 and pae."Ordenacao" = 10 and p."Descricao" = 'Números naturais e inteiros: significados, reta numerada e significado das operações';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não reconheceu as terminologias envolvendo uma pesquisa que apareceram na questão.') 
returning "Id" into respostaId;

--Ordem 1 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8 and pae."Ordenacao" = 1 and p."Descricao" = 'Planejamento, execução e relatório de pesquisa';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,1);

--Ordem 1 / 9 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 9 and pae."Ordenacao" = 1 and p."Descricao" = 'Planejamento, execução e relatório de pesquisa';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Reconheceu um pouco das terminologias que apareceram na questão e que fazem parte de uma pesquisa.') 
returning "Id" into respostaId;

--Ordem 1 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8 and pae."Ordenacao" = 1 and p."Descricao" = 'Planejamento, execução e relatório de pesquisa';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,2);

--Ordem 1 / 9 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 9 and pae."Ordenacao" = 1 and p."Descricao" = 'Planejamento, execução e relatório de pesquisa';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,2);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Reconheceu a maioria das terminologias que apareceram na questão e que fazem parte de uma pesquisa.') 
returning "Id" into respostaId;

--Ordem 1 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8 and pae."Ordenacao" = 1 and p."Descricao" = 'Planejamento, execução e relatório de pesquisa';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,3);

--Ordem 1 / 9 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 9 and pae."Ordenacao" = 1 and p."Descricao" = 'Planejamento, execução e relatório de pesquisa';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Reconheceu a maioria das terminologias que apareceram na questão e que fazem parte de uma pesquisa.') 
returning "Id" into respostaId;

--Ordem 1 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8 and pae."Ordenacao" = 1 and p."Descricao" = 'Planejamento, execução e relatório de pesquisa';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,3);

--Ordem 1 / 9 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 9 and pae."Ordenacao" = 1 and p."Descricao" = 'Planejamento, execução e relatório de pesquisa';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Reconheceu todas as terminologias que apareceram na questão e que fazem parte de uma pesquisa.') 
returning "Id" into respostaId;

--Ordem 1 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8 and pae."Ordenacao" = 1 and p."Descricao" = 'Planejamento, execução e relatório de pesquisa';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,4);

--Ordem 1 / 9 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 9 and pae."Ordenacao" = 1 and p."Descricao" = 'Planejamento, execução e relatório de pesquisa';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,4);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não identificou elementos geométricos presentes nos sólidos geométricos como altura, largura e profundidade.') 
returning "Id" into respostaId;

--Ordem 3 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8  and p."Descricao" = 'Poliedros e Medidas de comprimento, massa, tempo, temperatura e área/volume';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Identificou altura, largura e profundidade, mas não sabe realizar cálculo de volumes.') 
returning "Id" into respostaId;

--Ordem 3 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8  and p."Descricao" = 'Poliedros e Medidas de comprimento, massa, tempo, temperatura e área/volume';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,2);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Identificou altura, largura e profundidade e consegue realizar cálculo de volumes.') 
returning "Id" into respostaId;

--Ordem 3 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8  and p."Descricao" = 'Poliedros e Medidas de comprimento, massa, tempo, temperatura e área/volume';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,3);

end $$;
---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não reconheceu os tipos de ângulos no triângulo.') 
returning "Id" into respostaId;

--Ordem 4 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8  and p."Descricao" = 'Ângulos em polígonos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Reconheceu somente um dos tipos de ângulo (reto, agudo ou obtuso).') 
returning "Id" into respostaId;

--Ordem 4 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8 and p."Descricao" = 'Ângulos em polígonos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,2);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Reconheceu dois ou três tipos de ângulo (reto, agudo ou obtuso).') 
returning "Id" into respostaId;

--Ordem 4 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8 and p."Descricao" = 'Ângulos em polígonos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Reconheceu os tipos de ângulo (reto, agudo ou obtuso) e sabe pelo nome identificar os triângulos pela classificação quanto aos ângulos.') 
returning "Id" into respostaId;

--Ordem 4 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8 and p."Descricao" = 'Ângulos em polígonos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,4);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Calculou a variação de duas grandezas inversamente proporcionais expressando a relação por meio de uma sentença algébrica.') 
returning "Id" into respostaId;

--Ordem 5 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8  and pae."Ordenacao" = 5 and p."Descricao" = 'Variação de grandezas: diretamente e inversamente proporcionais ou não proporcionais';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Calculou a variação de duas grandezas inversamente proporcionais expressando a relação por meio de registro próprio.') 
returning "Id" into respostaId;

--Ordem 5 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8  and pae."Ordenacao" = 5 and p."Descricao" = 'Variação de grandezas: diretamente e inversamente proporcionais ou não proporcionais';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,2);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não construiu e nem calculou a variação de duas grandezas inversamente proporcionais expressando a relação por meio de uma sentença algébrica.') 
returning "Id" into respostaId;

--Ordem 5 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8  and pae."Ordenacao" = 5 and p."Descricao" = 'Variação de grandezas: diretamente e inversamente proporcionais ou não proporcionais';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não construiu e nem calculou a variação de duas grandezas inversamente proporcionais expressando a relação por meio de registro próprio.') 
returning "Id" into respostaId;

--Ordem 5 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8  and pae."Ordenacao" = 5 and p."Descricao" = 'Variação de grandezas: diretamente e inversamente proporcionais ou não proporcionais';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,4);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Calculou o valor do Capital Inicial, registrando como pensou.') 
returning "Id" into respostaId;

--Ordem 6 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8  and pae."Ordenacao" = 6 and p."Descricao" = 'Variação de grandezas: diretamente e inversamente proporcionais ou não proporcionais';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Adicionou o valor dos juros e do montante para calcular o Capital Inicial.') 
returning "Id" into respostaId;

--Ordem 6 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8  and pae."Ordenacao" = 6 and p."Descricao" = 'Variação de grandezas: diretamente e inversamente proporcionais ou não proporcionais';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,2);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Interpretou as informações, mas não calculou corretamente o Capital Inicial.') 
returning "Id" into respostaId;

--Ordem 6 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8  and pae."Ordenacao" = 6 and p."Descricao" = 'Variação de grandezas: diretamente e inversamente proporcionais ou não proporcionais';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Informou o valor numérico corretamente, mas não registrou como pensou.') 
returning "Id" into respostaId;

--Ordem 6 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8  and pae."Ordenacao" = 6 and p."Descricao" = 'Variação de grandezas: diretamente e inversamente proporcionais ou não proporcionais';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,4);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não determinou a fração de um número dado.') 
returning "Id" into respostaId;

--Ordem 7 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8  and pae."Ordenacao" = 7 and p."Descricao" = 'Procedimentos de cálculos, Problemas envolvendo o significado das operações';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Determinou a fração de um número dado.') 
returning "Id" into respostaId;

--Ordem 7 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8  and pae."Ordenacao" = 7 and p."Descricao" = 'Procedimentos de cálculos, Problemas envolvendo o significado das operações';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,2);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Identificou a fração de uma fração.') 
returning "Id" into respostaId;

--Ordem 7 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8  and pae."Ordenacao" = 7 and p."Descricao" = 'Procedimentos de cálculos, Problemas envolvendo o significado das operações';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Identificou o intervalo numérico entre duas frações.') 
returning "Id" into respostaId;

--Ordem 7 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8  and pae."Ordenacao" = 7 and p."Descricao" = 'Procedimentos de cálculos, Problemas envolvendo o significado das operações';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,4);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não interpretou problemas que compara dois fluxos de cálculo.') 
returning "Id" into respostaId;

--Ordem 8 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8  and pae."Ordenacao" = 8 and p."Descricao" = 'Procedimentos de cálculos, Problemas envolvendo o significado das operações';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Interpretou operou dados numéricos, mas não comparou as informações entre duas situações distintas.') 
returning "Id" into respostaId;

--Ordem 8 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8  and pae."Ordenacao" = 8 and p."Descricao" = 'Procedimentos de cálculos, Problemas envolvendo o significado das operações';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,2);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Interpretou operou dados numéricos, comparou as informações entre duas situações distintas, mas teve dificuldades de produzir registros conclusivos.') 
returning "Id" into respostaId;

--Ordem 8 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8  and pae."Ordenacao" = 8 and p."Descricao" = 'Procedimentos de cálculos, Problemas envolvendo o significado das operações';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Interpretou e operou dados numéricos, comparou as informações entre duas situações distintas e produziu registros conclusivos respondendo a todas as perguntas.') 
returning "Id" into respostaId;

--Ordem 8 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8  and pae."Ordenacao" = 8 and p."Descricao" = 'Procedimentos de cálculos, Problemas envolvendo o significado das operações';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,4);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não estabeleceu relação entre os dados numéricos fornecidos com as características da forma tridimensional apresentada.') 
returning "Id" into respostaId;

--Ordem 9 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8  and p."Descricao" = 'Cálculo de área';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,1);

--Ordem 10 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8 and p."Descricao" = 'Cálculo de volume';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Relacionou os dados numéricos fornecidos com as características da forma geométrica apresentada, mas não determinou a área de uma das faces.') 
returning "Id" into respostaId;

--Ordem 9 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8  and p."Descricao" = 'Cálculo de área';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,2);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Relacionou os dados numéricos fornecidos com as características da forma geométrica apresentada, determinou a área de uma das faces, mas não utilizou a unidade de medida adequada.') 
returning "Id" into respostaId;

--Ordem 9 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8 and p."Descricao" = 'Cálculo de área';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Relacionou os dados numéricos fornecidos com as características da forma geométrica apresentada, determinou a área de uma das faces e registrou a unidade de medida corretamente.') 
returning "Id" into respostaId;

--Ordem 9 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8 and p."Descricao" = 'Cálculo de área';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,4);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Relacionou os dados numéricos fornecidos com as características da forma geométrica apresentada e não determinou o volume.') 
returning "Id" into respostaId;

--Ordem 10 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8 and p."Descricao" = 'Cálculo de volume';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,2);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Relacionou os dados numéricos fornecidos com as características da forma geométrica apresentada e determinou o volume da figura.') 
returning "Id" into respostaId;

--Ordem 10 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8 and p."Descricao" = 'Cálculo de volume';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Relacionou os dados numéricos fornecidos com as características da forma geométrica apresentada, determinou a área de uma face e o volume da figura.') 
returning "Id" into respostaId;

--Ordem 10 / 8 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 8 and p."Descricao" = 'Cálculo de volume';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,4);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não compreendeu a ideia, realizando registros aleatórios.') 
returning "Id" into respostaId;

--Ordem 3 / 9 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 9 and p."Descricao" = 'Medidas de comprimento, massa, tempo, temperatura e área/volume';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,1);

--Ordem 4 / 9 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 9 and p."Descricao" = 'Ângulos em polígonos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,1);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Reconheceu parte da terminologia de ângulos que apareceram na questão, mas ainda não consolidou o conhecimento.') 
returning "Id" into respostaId;

--Ordem 4 / 9 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 9 and p."Descricao" = 'Ângulos em polígonos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,2);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Reconheceu parte das terminologias sobre polígonos que apareceram na questão, mas ainda não consolidou o conhecimento.') 
returning "Id" into respostaId;

--Ordem 4 / 9 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 9 and p."Descricao" = 'Ângulos em polígonos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,3);

end $$;

---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Reconheceu todas as terminologias que apareceram na questão e acertou os resultados utilizando estratégias convencionais/ cálculo mental.') 
returning "Id" into respostaId;

--Ordem 4 / 9 ano 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 9 and p."Descricao" = 'Ângulos em polígonos';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,4);

end $$;


---------------------------//------------------------------//--------------------------

do $$
declare 
	respostaId text;
	perguntaId text;
begin

insert into public."Resposta" ("Id", "Descricao") values (uuid_generate_v4()::text, 'Não compreendeu a ideia de área.') 
returning "Id" into respostaId;

--Ordem 7 / 9 ano - serve para o 8 ordem 
	select p."Id" into perguntaId from public."Pergunta" p
	inner join public."PerguntaAnoEscolar" pae on pae."PerguntaId" = p."Id" 
	where  pae."AnoEscolar" = 9 and p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Área';

	insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
	values (uuid_generate_v4()::text, perguntaId, respostaId,1);

end $$;