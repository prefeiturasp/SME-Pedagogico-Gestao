CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo as perguntas
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
select uuid_generate_v4()::text,'Álgebra - propriedades da igualdade','9f3d8467-2f6e-4bcb-a8e9-12e840426aba' 
where not exists (select 1 from public."Pergunta" where "Descricao" = 'Álgebra - propriedades da igualdade');

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
select uuid_generate_v4()::text,'Ângulos em polígonos','9f3d8467-2f6e-4bcb-a8e9-12e840426aba' 
where not exists (select 1 from public."Pergunta" where "Descricao" = 'Ângulos em polígonos');

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
select uuid_generate_v4()::text,'Cálculo de área','9f3d8467-2f6e-4bcb-a8e9-12e840426aba' 
where not exists (select 1 from public."Pergunta" where "Descricao" = 'Cálculo de área');

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
select uuid_generate_v4()::text,'Cálculo de volume','9f3d8467-2f6e-4bcb-a8e9-12e840426aba' 
where not exists (select 1 from public."Pergunta" where "Descricao" = 'Cálculo de volume');

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
select uuid_generate_v4()::text,'Localização e movimentação espacial','9f3d8467-2f6e-4bcb-a8e9-12e840426aba' 
where not exists (select 1 from public."Pergunta" where "Descricao" = 'Localização e movimentação espacial');

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
select uuid_generate_v4()::text,'Localização e movimentação: representação, descrição e interpretação da localização e/ou movimentação de pontos no 1º quadrante do plano cartesiano','9f3d8467-2f6e-4bcb-a8e9-12e840426aba' 
where not exists (select 1 from public."Pergunta" where "Descricao" = 'Localização e movimentação: representação, descrição e interpretação da localização e/ou movimentação de pontos no 1º quadrante do plano cartesiano');

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
select uuid_generate_v4()::text,'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Área','9f3d8467-2f6e-4bcb-a8e9-12e840426aba' 
where not exists (select 1 from public."Pergunta" where "Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Área');

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
select uuid_generate_v4()::text,'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Perímetro','9f3d8467-2f6e-4bcb-a8e9-12e840426aba' 
where not exists (select 1 from public."Pergunta" where "Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Perímetro');

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
select uuid_generate_v4()::text,'Medidas de comprimento, massa, tempo, temperatura e área','9f3d8467-2f6e-4bcb-a8e9-12e840426aba' 
where not exists (select 1 from public."Pergunta" where "Descricao" = 'Medidas de comprimento, massa, tempo, temperatura e área');

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
select uuid_generate_v4()::text,'Medidas de comprimento, massa, tempo, temperatura e área/volume','9f3d8467-2f6e-4bcb-a8e9-12e840426aba' 
where not exists (select 1 from public."Pergunta" where "Descricao" = 'Medidas de comprimento, massa, tempo, temperatura e área/volume');

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
select uuid_generate_v4()::text,'Números naturais e inteiros: significados, reta numerada e significado das operações','9f3d8467-2f6e-4bcb-a8e9-12e840426aba' 
where not exists (select 1 from public."Pergunta" where "Descricao" = 'Números naturais e inteiros: significados, reta numerada e significado das operações');

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
select uuid_generate_v4()::text,'Números racionais: leitura, escrita, comparação, ordenação e representação na reta numerada; equivalência','9f3d8467-2f6e-4bcb-a8e9-12e840426aba' 
where not exists (select 1 from public."Pergunta" where "Descricao" = 'Números racionais: leitura, escrita, comparação, ordenação e representação na reta numerada; equivalência');

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
select uuid_generate_v4()::text,'Objeto de conhecimento: Medidas de comprimento, massa, tempo, temperatura e área','9f3d8467-2f6e-4bcb-a8e9-12e840426aba' 
where not exists (select 1 from public."Pergunta" where "Descricao" = 'Objeto de conhecimento: Medidas de comprimento, massa, tempo, temperatura e área');

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
select uuid_generate_v4()::text,'Padrões em sequências figurais','9f3d8467-2f6e-4bcb-a8e9-12e840426aba' 
where not exists (select 1 from public."Pergunta" where "Descricao" = 'Padrões em sequências figurais');

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
select uuid_generate_v4()::text,'Planejamento e realização de pesquisas','9f3d8467-2f6e-4bcb-a8e9-12e840426aba' 
where not exists (select 1 from public."Pergunta" where "Descricao" = 'Planejamento e realização de pesquisas');

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
select uuid_generate_v4()::text,'Planejamento, execução e relatório de pesquisa','9f3d8467-2f6e-4bcb-a8e9-12e840426aba' 
where not exists (select 1 from public."Pergunta" where "Descricao" = 'Planejamento, execução e relatório de pesquisa');

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
select uuid_generate_v4()::text,'Poliedros e Medidas de comprimento, massa, tempo, temperatura e área/volume','9f3d8467-2f6e-4bcb-a8e9-12e840426aba' 
where not exists (select 1 from public."Pergunta" where "Descricao" = 'Poliedros e Medidas de comprimento, massa, tempo, temperatura e área/volume');

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
select uuid_generate_v4()::text,'Poliedros: diferenças e similaridades; planificação; exploração e classificação; relações entre os elementos de um poliedro','9f3d8467-2f6e-4bcb-a8e9-12e840426aba' 
where not exists (select 1 from public."Pergunta" where "Descricao" = 'Poliedros: diferenças e similaridades; planificação; exploração e classificação; relações entre os elementos de um poliedro');

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
select uuid_generate_v4()::text,'Probabilidade e Estatística – leitura e interpretação de gráficos','9f3d8467-2f6e-4bcb-a8e9-12e840426aba' 
where not exists (select 1 from public."Pergunta" where "Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos');

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
select uuid_generate_v4()::text,'Problema do campo multiplicativo envolvendo o significado de configuração retangular','9f3d8467-2f6e-4bcb-a8e9-12e840426aba' 
where not exists (select 1 from public."Pergunta" where "Descricao" = 'Problema do campo multiplicativo envolvendo o significado de configuração retangular');

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
select uuid_generate_v4()::text,'Problema do campo multiplicativo envolvendo o significado de proporcionalidade','9f3d8467-2f6e-4bcb-a8e9-12e840426aba' 
where not exists (select 1 from public."Pergunta" where "Descricao" = 'Problema do campo multiplicativo envolvendo o significado de proporcionalidade');

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
select uuid_generate_v4()::text,'Problemas com números reais, porcentagens sucessivas, taxas percentuais e juros simples','9f3d8467-2f6e-4bcb-a8e9-12e840426aba' 
where not exists (select 1 from public."Pergunta" where "Descricao" = 'Problemas com números reais, porcentagens sucessivas, taxas percentuais e juros simples');

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
select uuid_generate_v4()::text,'Procedimentos de cálculos, Problemas envolvendo o significado das operações','9f3d8467-2f6e-4bcb-a8e9-12e840426aba' 
where not exists (select 1 from public."Pergunta" where "Descricao" = 'Procedimentos de cálculos, Problemas envolvendo o significado das operações');

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
select uuid_generate_v4()::text,'Propriedade da igualdade','9f3d8467-2f6e-4bcb-a8e9-12e840426aba' 
where not exists (select 1 from public."Pergunta" where "Descricao" = 'Propriedade da igualdades');

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
select uuid_generate_v4()::text,'Relações entre grandezas: diretamente, inversamente ou não proporcionais','9f3d8467-2f6e-4bcb-a8e9-12e840426aba' 
where not exists (select 1 from public."Pergunta" where "Descricao" = 'Relações entre grandezas: diretamente, inversamente ou não proporcionais');

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
select uuid_generate_v4()::text,'Variação de grandezas: diretamente e inversamente proporcionais ou não proporcionais','9f3d8467-2f6e-4bcb-a8e9-12e840426aba'  
where not exists (select 1 from public."Pergunta" where "Descricao" = 'Variação de grandezas: diretamente e inversamente proporcionais ou não proporcionais');

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo respostas
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Acertou o resultado utilizando estratégias convencionais/ cálculo mental' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Acertou o resultado utilizando estratégias convencionais/ cálculo mental');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Adicionou o valor dos juros e do montante para calcular o Capital Inicial' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Adicionou o valor dos juros e do montante para calcular o Capital Inicial');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não compreendeu a ideia de área' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não compreendeu a ideia de área');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Calculou a idade de Osmir' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Calculou a idade de Osmir');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Calculou a variação de duas grandezas inversamente proporcionais expressando a relação por meio de registro próprio' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Calculou a variação de duas grandezas inversamente proporcionais expressando a relação por meio de registro próprio');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Calculou a variação de duas grandezas inversamente proporcionais expressando a relação por meio de uma sentença algébrica' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Calculou a variação de duas grandezas inversamente proporcionais expressando a relação por meio de uma sentença algébrica');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Calculou apenas com os valores apresentados na questão' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Calculou apenas com os valores apresentados na questão');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Calculou apenas com os valores dispostos' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Calculou apenas com os valores dispostos');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Calculou apenas com os valores dispostos na situação-problema' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Calculou apenas com os valores dispostos na situação-problema');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Calculou o valor da massa de cada bola de tênis para manter o equilíbrio da balança utilizando a propriedade da igualdade' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Calculou o valor da massa de cada bola de tênis para manter o equilíbrio da balança utilizando a propriedade da igualdade');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Calculou o valor da renda familiar per capita (em reais) e o número de pessoas na família' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Calculou o valor da renda familiar per capita (em reais) e o número de pessoas na família');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Calculou o valor do Capital Inicial, registrando como pensou' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Calculou o valor do Capital Inicial, registrando como pensou');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Calculou perímetros e áreas' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Calculou perímetros e áreas');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Calculou somente áreas' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Calculou somente áreas');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Calculou somente perímetros' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Calculou somente perímetros');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Comparou e/ou ordenou números racionais na representação decimal' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Comparou e/ou ordenou números racionais na representação decimal');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende a ideia de movimentação, mas não utiliza linguagem convencional' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende a ideia de movimentação, mas não utiliza linguagem convencional');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreendeu a ideia de movimentação, mas não utiliza linguagem matemática convencional' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreendeu a ideia de movimentação, mas não utiliza linguagem matemática convencional');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreendeu a ideia de área' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreendeu a ideia de área');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreendeu a ideia de igualdade e acertou o resultado' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreendeu a ideia de igualdade e acertou o resultado');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreendeu a ideia de igualdade, mas não acertou o resultado' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreendeu a ideia de igualdade, mas não acertou o resultado');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreendeu a ideia de localização e movimentação' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreendeu a ideia de localização e movimentação');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreendeu a ideia de localização, mas errou os comandos, confundindo direita com esquerda, e vice-versa' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreendeu a ideia de localização, mas errou os comandos, confundindo direita com esquerda, e vice-versa');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreendeu a ideia de movimentação, mas não utilizou a linguagem matemática convencional' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreendeu a ideia de movimentação, mas não utilizou a linguagem matemática convencional');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreendeu a ideia de perímetro' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreendeu a ideia de perímetro');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreendeu a ideia de perímetro e acertou o resultado' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreendeu a ideia de perímetro e acertou o resultado');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreendeu a ideia de perímetro, mas errou o resultado' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreendeu a ideia de perímetro, mas errou o resultado');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreendeu a ideia de plano cartesiano e acertou as coordenadas' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreendeu a ideia de plano cartesiano e acertou as coordenadas');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreendeu a ideia de regularidade e acertou a sequência' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreendeu a ideia de regularidade e acertou a sequência');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreendeu a ideia de regularidade, mas não acertou a sequência' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreendeu a ideia de regularidade, mas não acertou a sequência');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreendeu a ideia de regularidade, não acertou a sequência' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreendeu a ideia de regularidade, não acertou a sequência');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreendeu a ideia e acertou o resultado' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreendeu a ideia e acertou o resultado');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreendeu a ideia e acertou o resultado utilizando estratégias não convencionais e/ou outras estratégias' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreendeu a ideia e acertou o resultado utilizando estratégias não convencionais e/ou outras estratégias');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreendeu a ideia e errou o resultado' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreendeu a ideia e errou o resultado');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreendeu a ideia, acertando parte da(s) da(s) coordenada(s)' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreendeu a ideia, acertando parte da(s) da(s) coordenada(s)');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreendeu a ideia, explicitando adequadamente na tabela os dados do gráfico' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreendeu a ideia, explicitando adequadamente na tabela os dados do gráfico');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreendeu a ideia, mas errou o cálculo' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreendeu a ideia, mas errou o cálculo');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreendeu a ideia, mas inverteu a correlação dos dados linha/coluna' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreendeu a ideia, mas inverteu a correlação dos dados linha/coluna');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreendeu a ideia, mas inverteu a localização nos eixos' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreendeu a ideia, mas inverteu a localização nos eixos');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreendeu parcialmente a ideia, acertando parte do(s) resultado(s)' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreendeu parcialmente a ideia, acertando parte do(s) resultado(s)');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreendeu que o número racional apresentado representa uma parte de um inteiro, mas não encontrou o valor exato' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreendeu que o número racional apresentado representa uma parte de um inteiro, mas não encontrou o valor exato');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Conheceu a maioria das terminologias que apareceram na questão e que fazem parte de uma pesquisa' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Conheceu a maioria das terminologias que apareceram na questão e que fazem parte de uma pesquisa');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Conheceu todas as terminologias que apareceram na questão e que fazem parte de uma pesquisa' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Conheceu todas as terminologias que apareceram na questão e que fazem parte de uma pesquisa');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Conheceu um pouco as terminologias que apareceram na questão e que fazem parte de uma pesquisa' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Conheceu um pouco as terminologias que apareceram na questão e que fazem parte de uma pesquisa');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Copiou dado(s) existente na situação-problema' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Copiou dado(s) existente na situação-problema');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Copiou dado(s) existente(s) no problema' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Copiou dado(s) existente(s) no problema');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Copiou segmento(s) da sequência existente na situação-problema' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Copiou segmento(s) da sequência existente na situação-problema');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Determinou a fração de um número dado' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Determinou a fração de um número dado');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Escreveu corretamente como encontrou a resposta' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Escreveu corretamente como encontrou a resposta');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Estudante ausente' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Estudante ausente');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Fez a leitura de números racionais como se fossem números naturais, colocando em ordem crescente' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Fez a leitura de números racionais como se fossem números naturais, colocando em ordem crescente');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Fez a leitura de números racionais como se fossem números naturais, colocando em ordem decrescente' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Fez a leitura de números racionais como se fossem números naturais, colocando em ordem decrescente');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Identificou a fração de uma fração' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Identificou a fração de uma fração');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Identificou a temperatura correta no termômetro' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Identificou a temperatura correta no termômetro');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Identificou altura, largura e profundidade e consegue realizar cálculo de volumes' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Identificou altura, largura e profundidade e consegue realizar cálculo de volumes');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Identificou altura, largura e profundidade e consegue realizar cálculo de volumes, fazendo generalizações para outras situações' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Identificou altura, largura e profundidade e consegue realizar cálculo de volumes, fazendo generalizações para outras situações');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Identificou altura, largura e profundidade, mas não sabe realizar cálculo de volumes' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Identificou altura, largura e profundidade, mas não sabe realizar cálculo de volumes');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Identificou medidas de tempo e realizou conversões' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Identificou medidas de tempo e realizou conversões');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Identificou medidas de tempo, diferenciou a hora de minuto, mas teve dificuldade em conversões' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Identificou medidas de tempo, diferenciou a hora de minuto, mas teve dificuldade em conversões');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Identificou medidas de tempo, mas não diferenciou a hora de minuto' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Identificou medidas de tempo, mas não diferenciou a hora de minuto');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Identificou o intervalo numérico entre duas frações' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Identificou o intervalo numérico entre duas frações');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Identificou o tema e a importância do título e da fonte' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Identificou o tema e a importância do título e da fonte');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Indicou apenas a soma entre a medida da largura e do comprimento' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Indicou apenas a soma entre a medida da largura e do comprimento');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Informou o valor numérico corretamente, mas não registrou como pensou' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Informou o valor numérico corretamente, mas não registrou como pensou');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Interpretou as informações, mas não calculou corretamente o Capital Inicial' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Interpretou as informações, mas não calculou corretamente o Capital Inicial');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Interpretou e operou dados numéricos, comparou as informações entre duas situações distintas e produziu registros conclusivos respondendo a todas as perguntas' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Interpretou e operou dados numéricos, comparou as informações entre duas situações distintas e produziu registros conclusivos respondendo a todas as perguntas');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Interpretou operou dados numéricos, comparou as informações entre duas situações distintas, mas teve dificuldades de produzir registros conclusivos' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Interpretou operou dados numéricos, comparou as informações entre duas situações distintas, mas teve dificuldades de produzir registros conclusivos');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Interpretou operou dados numéricos, mas não comparou as informações entre duas situações distintas' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Interpretou operou dados numéricos, mas não comparou as informações entre duas situações distintas');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não calculou a idade de Osmir' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não calculou a idade de Osmir');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não calculou o valor da massa de cada bola de tênis para manter o equilíbrio da balança utilizando a propriedade da igualdade' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não calculou o valor da massa de cada bola de tênis para manter o equilíbrio da balança utilizando a propriedade da igualdade');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não calculou o valor da renda familiar per capita (em reais) e o número de pessoas na família' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não calculou o valor da renda familiar per capita (em reais) e o número de pessoas na família');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não calculou o valor da renda familiar per capita, mas calculou o número de pessoas da família' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não calculou o valor da renda familiar per capita, mas calculou o número de pessoas da família');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não comparou e/ou ordenou números racionais na representação decimal' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não comparou e/ou ordenou números racionais na representação decimal');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não compreende a ideia de localização e movimentação' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não compreende a ideia de localização e movimentação');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não compreende a ideia de regularidade' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não compreende a ideia de regularidade');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não compreendeu a ideia de localização e movimentação' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não compreendeu a ideia de localização e movimentação');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não compreendeu a ideia' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não compreendeu a ideia');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não compreendeu a ideia da situação-problema' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não compreendeu a ideia da situação-problema');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não compreendeu a ideia de regularidade' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não compreendeu a ideia de regularidade');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não compreendeu a ideia do problema' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não compreendeu a ideia do problema');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não compreendeu a ideia, realizando registros aleatórios' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não compreendeu a ideia, realizando registros aleatórios');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não compreendeu que o número racional apresentado representa uma parte de um inteiro' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não compreendeu que o número racional apresentado representa uma parte de um inteiro');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não conheceu as terminologias envolvendo uma pesquisa que apareceram na questão' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não conheceu as terminologias envolvendo uma pesquisa que apareceram na questão');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não construiu e nem calculou a variação de duas grandezas inversamente proporcionais expressando a relação por meio de registro próprio' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não construiu e nem calculou a variação de duas grandezas inversamente proporcionais expressando a relação por meio de registro próprio');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não construiu e nem calculou a variação de duas grandezas inversamente proporcionais expressando a relação por meio de uma sentença algébrica' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não construiu e nem calculou a variação de duas grandezas inversamente proporcionais expressando a relação por meio de uma sentença algébrica');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não correlacionou corretamente os dados de linha e coluna' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não correlacionou corretamente os dados de linha e coluna');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não determinou a fração de um número dado' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não determinou a fração de um número dado');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não escreveu como encontrou a resposta' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não escreveu como encontrou a resposta');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não estabeleceu relação entre os dados numéricos fornecidos com as características da forma tridimensional apresentada' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não estabeleceu relação entre os dados numéricos fornecidos com as características da forma tridimensional apresentada');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não identificar a temperatura no termômetro' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não identificar a temperatura no termômetro');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não identificou elementos geométricos presentes nos sólidos geométricos como altura, largura e profundidade' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não identificou elementos geométricos presentes nos sólidos geométricos como altura, largura e profundidade');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não identificou medidas de ângulos' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não identificou medidas de ângulos');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não identificou medidas de tempo' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não identificou medidas de tempo');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não identificou o tema e nem a importância do título e da fonte' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não identificou o tema e nem a importância do título e da fonte');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não interpretou problemas que compara dois fluxos de cálculo' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não interpretou problemas que compara dois fluxos de cálculo');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não realiza a leitura de dados explícitos em gráficos' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não realiza a leitura de dados explícitos em gráficos');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não realiza a leitura de dados explícitos no gráfico' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não realiza a leitura de dados explícitos no gráfico');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não realizou a leitura de dados explícitos em gráficos' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não realizou a leitura de dados explícitos em gráficos');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não realizou a leitura de dados explícitos no gráfico' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não realizou a leitura de dados explícitos no gráfico');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não reconheceu as terminologias envolvendo uma pesquisa que apareceram na questão' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não reconheceu as terminologias envolvendo uma pesquisa que apareceram na questão');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não reconheceu o significado de perímetro e área' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não reconheceu o significado de perímetro e área');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não reconheceu os sólidos geométricos' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não reconheceu os sólidos geométricos');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não reconheceu os tipos de ângulos no triângulo' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não reconheceu os tipos de ângulos no triângulo');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não resolveu a questão' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não resolveu a questão');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não resolveu o problema envolvendo um dos significados dos números inteiros' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não resolveu o problema envolvendo um dos significados dos números inteiros');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não utilizou a escrita algébrica para encontrar a idade de Osmir' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não utilizou a escrita algébrica para encontrar a idade de Osmir');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Planilha de Acompanhamento' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Planilha de Acompanhamento');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Realiza a leitura de dados explícitos e compreende a ideia de dado implícito, mas não o identifica corretamente' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Realiza a leitura de dados explícitos e compreende a ideia de dado implícito, mas não o identifica corretamente');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Realiza a leitura de dados explícitos e implícitos' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Realiza a leitura de dados explícitos e implícitos');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Realiza somente a leitura de dados explícitos no gráfico' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Realiza somente a leitura de dados explícitos no gráfico');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Realizou a leitura de dados explícitos e compreendeu a ideia de dado implícito, mas não o identificou corretamente' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Realizou a leitura de dados explícitos e compreendeu a ideia de dado implícito, mas não o identificou corretamente');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Realizou a leitura de dados explícitos e implícitos' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Realizou a leitura de dados explícitos e implícitos');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Realizou somente a leitura de dados explícitos no gráfico' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Realizou somente a leitura de dados explícitos no gráfico');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Realizou uma operação aleatória com os dados apresentados pelo problema que não conduziu a resposta correta' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Realizou uma operação aleatória com os dados apresentados pelo problema que não conduziu a resposta correta');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Reconheceu a maioria das terminologias que apareceram na questão e que fazem parte de uma pesquisa' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Reconheceu a maioria das terminologias que apareceram na questão e que fazem parte de uma pesquisa');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Reconheceu alguns sólidos geométricos' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Reconheceu alguns sólidos geométricos');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Reconheceu dois ou três tipos de ângulo (reto, agudo ou obtuso)' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Reconheceu dois ou três tipos de ângulo (reto, agudo ou obtuso)');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Reconheceu os quatro sólidos geométricos' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Reconheceu os quatro sólidos geométricos');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Reconheceu os tipos de ângulo (reto, agudo ou obtuso) e sabe pelo nome identificar os triângulos pela classificação quanto aos ângulos' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Reconheceu os tipos de ângulo (reto, agudo ou obtuso) e sabe pelo nome identificar os triângulos pela classificação quanto aos ângulos');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Reconheceu parte da terminologia de ângulos que apareceram na questão, mas ainda não consolidou o conhecimento' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Reconheceu parte da terminologia de ângulos que apareceram na questão, mas ainda não consolidou o conhecimento');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Reconheceu parte das terminologias sobre polígonos que apareceram na questão, mas ainda não consolidou o conhecimento' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Reconheceu parte das terminologias sobre polígonos que apareceram na questão, mas ainda não consolidou o conhecimento');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Reconheceu somente um dos tipos de ângulo (reto, agudo ou obtuso)' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Reconheceu somente um dos tipos de ângulo (reto, agudo ou obtuso)');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Reconheceu todas as medidas de ângulos solicitadas' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Reconheceu todas as medidas de ângulos solicitadas');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Reconheceu todas as terminologias que apareceram na questão e acertou os resultados utilizando estratégias convencionais/ cálculo mental' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Reconheceu todas as terminologias que apareceram na questão e acertou os resultados utilizando estratégias convencionais/ cálculo mental');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Reconheceu todas as terminologias que apareceram na questão e que fazem parte de uma pesquisa' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Reconheceu todas as terminologias que apareceram na questão e que fazem parte de uma pesquisa');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Reconheceu três sólidos geométricos' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Reconheceu três sólidos geométricos');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Reconheceu um ou dois tipos de ângulos' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Reconheceu um ou dois tipos de ângulos');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Reconheceu um pouco das terminologias que apareceram na questão e que fazem parte de uma pesquisa' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Reconheceu um pouco das terminologias que apareceram na questão e que fazem parte de uma pesquisa');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Reconheceu várias medidas de ângulos' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Reconheceu várias medidas de ângulos');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Relacionou os dados numéricos fornecidos com as características da forma geométrica apresentada e determinou o volume da figura' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Relacionou os dados numéricos fornecidos com as características da forma geométrica apresentada e determinou o volume da figura');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Relacionou os dados numéricos fornecidos com as características da forma geométrica apresentada e não determinou o volume' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Relacionou os dados numéricos fornecidos com as características da forma geométrica apresentada e não determinou o volume');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Relacionou os dados numéricos fornecidos com as características da forma geométrica apresentada, determinou a área de uma das faces e registrou a unidade de medida corretamente' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Relacionou os dados numéricos fornecidos com as características da forma geométrica apresentada, determinou a área de uma das faces e registrou a unidade de medida corretamente');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Relacionou os dados numéricos fornecidos com as características da forma geométrica apresentada, determinou a área de uma das faces, mas não utilizou a unidade de medida adequada' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Relacionou os dados numéricos fornecidos com as características da forma geométrica apresentada, determinou a área de uma das faces, mas não utilizou a unidade de medida adequada');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Relacionou os dados numéricos fornecidos com as características da forma geométrica apresentada, mas não determinou a área de uma das faces' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Relacionou os dados numéricos fornecidos com as características da forma geométrica apresentada, mas não determinou a área de uma das faces');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Resolveu incorretamente, pois utiliza apenas uma das informações' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Resolveu incorretamente, pois utiliza apenas uma das informações');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Resolveu o problema corretamente utilizando alguma operação numérica' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Resolveu o problema corretamente utilizando alguma operação numérica');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Resolveu o problema corretamente utilizando outro tipo representação' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Resolveu o problema corretamente utilizando outro tipo representação');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Resolveu o problema envolvendo um dos significados dos números inteiros' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Resolveu o problema envolvendo um dos significados dos números inteiros');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Texto da opção 4 – Relacionou os dados numéricos fornecidos com as características da forma geométrica apresentada, determinou a área de uma face e o volume da figura' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Texto da opção 4 – Relacionou os dados numéricos fornecidos com as características da forma geométrica apresentada, determinou a área de uma face e o volume da figura');
 
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Utilizou a escrita algébrica para encontrar a idade de Osmir' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Utilizou a escrita algébrica para encontrar a idade de Osmir');
 
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 4º Ano - Ordem 1

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Problema do campo multiplicativo envolvendo o significado de configuração retangular';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou o resultado utilizando estratégias convencionais/ cálculo mental';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4,1,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 1)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia e acertou o resultado utilizando estratégias não convencionais e/ou outras estratégias';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia e errou o resultado';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreendeu a ideia do problema';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 4º Ano - Ordem 2

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Problema do campo multiplicativo envolvendo o significado de proporcionalidade';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou o resultado utilizando estratégias convencionais/ cálculo mental';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4,2,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 2)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia e acertou o resultado utilizando estratégias não convencionais e/ou outras estratégias';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia e errou o resultado';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreendeu a ideia do problema';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 4º Ano - Ordem 3

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Padrões em sequências figurais';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de regularidade e acertou a sequência';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4,3,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 3)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de regularidade, mas não acertou a sequência';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Copiou segmento(s) da sequência existente na situação-problema';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreende a ideia de regularidade';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 4º Ano - Ordem 4

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Padrões em sequências figurais';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de regularidade e acertou a sequência';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4,4,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 4)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de regularidade, não acertou a sequência';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Copiou segmento(s) da sequência existente na situação-problema';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreendeu a ideia de regularidade';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 4º Ano - Ordem 5

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Localização e movimentação espacial';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de localização e movimentação';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4,5,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 5)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de localização, mas errou os comandos, confundindo direita com esquerda, e vice-versa';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de movimentação, mas não utilizou a linguagem matemática convencional';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreendeu a ideia de localização e movimentação';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;


--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 4º Ano - Ordem 6

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Localização e movimentação espacial';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de localização e movimentação';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4,6,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 6)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de localização, mas errou os comandos, confundindo direita com esquerda, e vice-versa';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de movimentação, mas não utiliza linguagem matemática convencional';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreendeu a ideia de localização e movimentação';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 4º Ano - Ordem 7

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Perímetro';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de perímetro e acertou o resultado';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4,7,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 7)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de perímetro, mas errou o resultado';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Indicou apenas a soma entre a medida da largura e do comprimento';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreendeu a ideia';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 4º Ano - Ordem 8

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Perímetro';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de perímetro';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4,8,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 8)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia, mas errou o cálculo';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Calculou apenas com os valores dispostos';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreendeu a ideia';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 4º Ano - Ordem 9

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Realizou a leitura de dados explícitos e implícitos';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4,9,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 9)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Realizou somente a leitura de dados explícitos no gráfico';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Realizou a leitura de dados explícitos e compreendeu a ideia de dado implícito, mas não o identificou corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não realizou a leitura de dados explícitos em gráficos';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;


--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 4º Ano - Ordem 10

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia, explicitando adequadamente na tabela os dados do gráfico';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4,10,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 10)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia, mas inverteu a correlação dos dados linha/coluna';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não realizou a leitura de dados explícitos no gráfico';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não realizou a leitura de dados explícitos em gráficos';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 5º Ano - Ordem 1

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Problema do campo multiplicativo envolvendo o significado de configuração retangular';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou o resultado utilizando estratégias convencionais/ cálculo mental';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5,1,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 1)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia e acertou o resultado utilizando estratégias não convencionais e/ou outras estratégias';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia e errou o resultado';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreendeu a ideia da situação-problema';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 5º Ano - Ordem 2

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Problema do campo multiplicativo envolvendo o significado de proporcionalidade';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou o resultado utilizando estratégias convencionais/ cálculo mental';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5,2,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 2)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia e acertou o resultado utilizando estratégias não convencionais e/ou outras estratégias';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia e errou o resultado';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreendeu a ideia da situação-problema';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 5º Ano - Ordem 3

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Álgebra - propriedades da igualdade';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de igualdade e acertou o resultado';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5,3,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 3)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de igualdade, mas não acertou o resultado';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Copiou dado(s) existente na situação-problema';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Realizou uma operação aleatória com os dados apresentados pelo problema que não conduziu a resposta correta';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 5º Ano - Ordem 4

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Álgebra - propriedades da igualdade';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de igualdade e acertou o resultado';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5,4,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 4)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de igualdade, mas não acertou o resultado';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Copiou dado(s) existente na situação-problema';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Realizou uma operação aleatória com os dados apresentados pelo problema que não conduziu a resposta correta';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 5º Ano - Ordem 5

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Localização e movimentação espacial';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de localização e movimentação';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5,5,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 5)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de localização, mas errou os comandos, confundindo direita com esquerda, e vice-versa';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia de movimentação, mas não utiliza linguagem convencional';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreende a ideia de localização e movimentação';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 5º Ano - Ordem 6

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Localização e movimentação espacial';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de localização e movimentação';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5,6,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 6)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de localização, mas errou os comandos, confundindo direita com esquerda, e vice-versa';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia de movimentação, mas não utiliza linguagem convencional';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreende a ideia de localização e movimentação';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 5º Ano - Ordem 7

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Perímetro';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de perímetro';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5,7,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 7)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia, mas errou o cálculo';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Calculou apenas com os valores apresentados na questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreendeu a ideia';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 5º Ano - Ordem 8

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Perímetro';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de perímetro';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5,8,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 8)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de perímetro';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia, mas errou o cálculo';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Calculou apenas com os valores apresentados na questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 5º Ano - Ordem 9

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Realiza a leitura de dados explícitos e implícitos';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5,9,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 9)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Realiza a leitura de dados explícitos e compreende a ideia de dado implícito, mas não o identifica corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Realiza somente a leitura de dados explícitos no gráfico';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não realiza a leitura de dados explícitos em gráficos';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 5º Ano - Ordem 10

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia, explicitando adequadamente na tabela os dados do gráfico';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5,10,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 10)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia, mas inverteu a correlação dos dados linha/coluna';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não correlacionou corretamente os dados de linha e coluna';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não realiza a leitura de dados explícitos no gráfico';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 6º Ano - Ordem 1

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Números racionais: leitura, escrita, comparação, ordenação e representação na reta numerada; equivalência';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Comparou e/ou ordenou números racionais na representação decimal';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 6,1,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 6 and "Ordenacao" = 1)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Fez a leitura de números racionais como se fossem números naturais, colocando em ordem decrescente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Fez a leitura de números racionais como se fossem números naturais, colocando em ordem crescente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não comparou e/ou ordenou números racionais na representação decimal';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 6º Ano - Ordem 2

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Números racionais: leitura, escrita, comparação, ordenação e representação na reta numerada; equivalência';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou o resultado utilizando estratégias convencionais/ cálculo mental';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 6,2,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 6 and "Ordenacao" = 2)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia e acertou o resultado utilizando estratégias não convencionais e/ou outras estratégias';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu que o número racional apresentado representa uma parte de um inteiro, mas não encontrou o valor exato';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreendeu que o número racional apresentado representa uma parte de um inteiro';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 6º Ano - Ordem 3

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Álgebra - propriedades da igualdade';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia e acertou o resultado';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 6,3,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 6 and "Ordenacao" = 3)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia e errou o resultado';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Copiou dado(s) existente(s) no problema';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreendeu a ideia';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 6º Ano - Ordem 4

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Álgebra - propriedades da igualdade';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia e acertou o resultado';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 6,4,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 6 and "Ordenacao" = 4)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu parcialmente a ideia, acertando parte do(s) resultado(s)';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia e errou o resultado';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreendeu a ideia';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 6º Ano - Ordem 5

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Localização e movimentação: representação, descrição e interpretação da localização e/ou movimentação de pontos no 1º quadrante do plano cartesiano';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de plano cartesiano e acertou as coordenadas';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 6,5,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 6 and "Ordenacao" = 5)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia, acertando parte da(s) da(s) coordenada(s)';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia, mas inverteu a localização nos eixos';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreendeu a ideia';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 6º Ano - Ordem 6

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Localização e movimentação: representação, descrição e interpretação da localização e/ou movimentação de pontos no 1º quadrante do plano cartesiano';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de plano cartesiano e acertou as coordenadas';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 6,6,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 6 and "Ordenacao" = 6)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia, acertando parte da(s) da(s) coordenada(s)';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia, mas inverteu a localização nos eixos';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreendeu a ideia';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 6º Ano - Ordem 7

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Área';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de área';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 6,7,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 6 and "Ordenacao" = 7)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia, mas errou o cálculo';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Calculou apenas com os valores dispostos na situação-problema';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreendeu a ideia';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 6º Ano - Ordem 8

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Área';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de área';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 6,8,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 6 and "Ordenacao" = 8)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia, mas errou o cálculo';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Calculou apenas com os valores dispostos na situação-problema';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreendeu a ideia';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 6º Ano - Ordem 9

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Realizou a leitura de dados explícitos e implícitos';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 6,9,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 6 and "Ordenacao" = 9)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Realizou a leitura de dados explícitos e compreendeu a ideia de dado implícito, mas não o identificou corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Realizou somente a leitura de dados explícitos no gráfico';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não realizou a leitura de dados explícitos em gráficos';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 6º Ano - Ordem 10

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Probabilidade e Estatística – leitura e interpretação de gráficos';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Realizou a leitura de dados explícitos e implícitos';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 6,10,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 6 and "Ordenacao" = 10)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Realizou a leitura de dados explícitos e compreendeu a ideia de dado implícito, mas não o identificou corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Realizou somente a leitura de dados explícitos no gráfico';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não realizou a leitura de dados explícitos em gráficos';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 7º Ano - Ordem 1

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Planejamento e realização de pesquisas';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não conheceu as terminologias envolvendo uma pesquisa que apareceram na questão';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 7,1,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 7 and "Ordenacao" = 1)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Conheceu um pouco as terminologias que apareceram na questão e que fazem parte de uma pesquisa';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Conheceu a maioria das terminologias que apareceram na questão e que fazem parte de uma pesquisa';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Conheceu todas as terminologias que apareceram na questão e que fazem parte de uma pesquisa';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 7º Ano - Ordem 2

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Planejamento e realização de pesquisas';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Calculou o valor da renda familiar per capita (em reais) e o número de pessoas na família';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 7,2,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 7 and "Ordenacao" = 2)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não calculou o valor da renda familiar per capita (em reais) e o número de pessoas na família';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Identificou o tema e a importância do título e da fonte';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não identificou o tema e nem a importância do título e da fonte';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 7º Ano - Ordem 3

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Poliedros: diferenças e similaridades; planificação; exploração e classificação; relações entre os elementos de um poliedro';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não reconheceu os sólidos geométricos';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 7,3,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 7 and "Ordenacao" = 3)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Reconheceu três sólidos geométricos';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Reconheceu alguns sólidos geométricos';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Reconheceu os quatro sólidos geométricos';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 7º Ano - Ordem 4

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Ângulos em polígonos';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não identificou medidas de ângulos';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 7,4,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 7 and "Ordenacao" = 4)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Reconheceu um ou dois tipos de ângulos';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Reconheceu várias medidas de ângulos';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Reconheceu todas as medidas de ângulos solicitadas';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 7º Ano - Ordem 5

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Medidas de comprimento, massa, tempo, temperatura e área';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não identificou medidas de tempo';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 7,5,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 7 and "Ordenacao" = 5)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Identificou medidas de tempo, mas não diferenciou a hora de minuto';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Identificou medidas de tempo, diferenciou a hora de minuto, mas teve dificuldade em conversões';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Identificou medidas de tempo e realizou conversões';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 7º Ano - Ordem 6

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Objeto de conhecimento: Medidas de comprimento, massa, tempo, temperatura e área';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não reconheceu o significado de perímetro e área';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 7,6,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 7 and "Ordenacao" = 6)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Calculou somente perímetros';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Calculou somente áreas';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Calculou perímetros e áreas';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 7º Ano - Ordem 7

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Propriedade da igualdade';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Calculou o valor da massa de cada bola de tênis para manter o equilíbrio da balança utilizando a propriedade da igualdade';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 7,7,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 7 and "Ordenacao" = 7)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não calculou o valor da massa de cada bola de tênis para manter o equilíbrio da balança utilizando a propriedade da igualdade';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Escreveu corretamente como encontrou a resposta';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não escreveu como encontrou a resposta';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 7º Ano - Ordem 8

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Propriedade da igualdade';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Calculou a idade de Osmir';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 7,8,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 7 and "Ordenacao" = 8)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não calculou a idade de Osmir';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Utilizou a escrita algébrica para encontrar a idade de Osmir';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não utilizou a escrita algébrica para encontrar a idade de Osmir';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 7º Ano - Ordem 9

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Números naturais e inteiros: significados, reta numerada e significado das operações';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Calculou a idade de Osmir';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 7,9,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 7 and "Ordenacao" = 9)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Resolveu o problema envolvendo um dos significados dos números inteiros';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu o problema envolvendo um dos significados dos números inteiros';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Identificou a temperatura correta no termômetro';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 7º Ano - Ordem 10

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Números naturais e inteiros: significados, reta numerada e significado das operações';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Resolveu o problema corretamente utilizando alguma operação numérica';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 7,10,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 7 and "Ordenacao" = 10)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Resolveu o problema corretamente utilizando outro tipo representação';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Resolveu incorretamente, pois utiliza apenas uma das informações';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreendeu a ideia do problema';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 8º Ano - Ordem 1

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Planejamento, execução e relatório de pesquisa';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não reconheceu as terminologias envolvendo uma pesquisa que apareceram na questão';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 8,1,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 8 and "Ordenacao" = 1)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Reconheceu um pouco das terminologias que apareceram na questão e que fazem parte de uma pesquisa';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Reconheceu a maioria das terminologias que apareceram na questão e que fazem parte de uma pesquisa';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Reconheceu todas as terminologias que apareceram na questão e que fazem parte de uma pesquisa';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;


--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 8º Ano - Ordem 2

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Planejamento, execução e relatório de pesquisa';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Calculou o valor da renda familiar per capita (em reais) e o número de pessoas na família';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 8,2,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 8 and "Ordenacao" = 2)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não calculou o valor da renda familiar per capita (em reais) e o número de pessoas na família';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Identificou o tema e a importância do título e da fonte';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não identificou o tema e nem a importância do título e da fonte';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 8º Ano - Ordem 3

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Poliedros e Medidas de comprimento, massa, tempo, temperatura e área/volume';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não identificou elementos geométricos presentes nos sólidos geométricos como altura, largura e profundidade';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 8,3,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 8 and "Ordenacao" = 3)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Identificou altura, largura e profundidade, mas não sabe realizar cálculo de volumes';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Identificou altura, largura e profundidade e consegue realizar cálculo de volumes';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Identificou altura, largura e profundidade e consegue realizar cálculo de volumes, fazendo generalizações para outras situações';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 8º Ano - Ordem 4

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Ângulos em polígonos';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não reconheceu os tipos de ângulos no triângulo';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 8,4,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 8 and "Ordenacao" = 4)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Reconheceu somente um dos tipos de ângulo (reto, agudo ou obtuso)';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Reconheceu dois ou três tipos de ângulo (reto, agudo ou obtuso)';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Reconheceu os tipos de ângulo (reto, agudo ou obtuso) e sabe pelo nome identificar os triângulos pela classificação quanto aos ângulos';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 8º Ano - Ordem 5

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Variação de grandezas: diretamente e inversamente proporcionais ou não proporcionais';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Calculou a variação de duas grandezas inversamente proporcionais expressando a relação por meio de uma sentença algébrica';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 8,5,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 8 and "Ordenacao" = 5)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Calculou a variação de duas grandezas inversamente proporcionais expressando a relação por meio de registro próprio';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não construiu e nem calculou a variação de duas grandezas inversamente proporcionais expressando a relação por meio de uma sentença algébrica';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não construiu e nem calculou a variação de duas grandezas inversamente proporcionais expressando a relação por meio de registro próprio';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 8º Ano - Ordem 6

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Variação de grandezas: diretamente e inversamente proporcionais ou não proporcionais';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Calculou o valor do Capital Inicial, registrando como pensou';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 8,6,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 8 and "Ordenacao" = 6)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Adicionou o valor dos juros e do montante para calcular o Capital Inicial';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Interpretou as informações, mas não calculou corretamente o Capital Inicial';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Informou o valor numérico corretamente, mas não registrou como pensou';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 8º Ano - Ordem 7

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Procedimentos de cálculos, Problemas envolvendo o significado das operações';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não determinou a fração de um número dado';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 8,7,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 8 and "Ordenacao" = 7)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Determinou a fração de um número dado';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Identificou a fração de uma fração';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Identificou o intervalo numérico entre duas frações';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 8º Ano - Ordem 8

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Procedimentos de cálculos, Problemas envolvendo o significado das operações';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não interpretou problemas que compara dois fluxos de cálculo';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 8,8,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 8 and "Ordenacao" = 8)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Interpretou operou dados numéricos, mas não comparou as informações entre duas situações distintas';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Interpretou operou dados numéricos, comparou as informações entre duas situações distintas, mas teve dificuldades de produzir registros conclusivos';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Interpretou e operou dados numéricos, comparou as informações entre duas situações distintas e produziu registros conclusivos respondendo a todas as perguntas';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 8º Ano - Ordem 9

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Cálculo de área';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não estabeleceu relação entre os dados numéricos fornecidos com as características da forma tridimensional apresentada';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 8,9,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 8 and "Ordenacao" = 9)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Relacionou os dados numéricos fornecidos com as características da forma geométrica apresentada, mas não determinou a área de uma das faces';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Relacionou os dados numéricos fornecidos com as características da forma geométrica apresentada, determinou a área de uma das faces, mas não utilizou a unidade de medida adequada';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Relacionou os dados numéricos fornecidos com as características da forma geométrica apresentada, determinou a área de uma das faces e registrou a unidade de medida corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 8º Ano - Ordem 10

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Cálculo de volume';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não estabeleceu relação entre os dados numéricos fornecidos com as características da forma tridimensional apresentada';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 8,10,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 8 and "Ordenacao" = 10)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Relacionou os dados numéricos fornecidos com as características da forma geométrica apresentada e não determinou o volume';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Relacionou os dados numéricos fornecidos com as características da forma geométrica apresentada e determinou o volume da figura';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Texto da opção 4 – Relacionou os dados numéricos fornecidos com as características da forma geométrica apresentada, determinou a área de uma face e o volume da figura';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 9º Ano - Ordem 1

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Planejamento, execução e relatório de pesquisa';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não reconheceu as terminologias envolvendo uma pesquisa que apareceram na questão';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 9,1,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 9 and "Ordenacao" = 1)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Reconheceu um pouco das terminologias que apareceram na questão e que fazem parte de uma pesquisa';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Reconheceu a maioria das terminologias que apareceram na questão e que fazem parte de uma pesquisa';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Reconheceu todas as terminologias que apareceram na questão e que fazem parte de uma pesquisa';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 9º Ano - Ordem 2

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Planejamento, execução e relatório de pesquisa';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Calculou o valor da renda familiar per capita (em reais) e o número de pessoas na família';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 9,2,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 9 and "Ordenacao" = 2)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não calculou o valor da renda familiar per capita, mas calculou o número de pessoas da família';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Identificou o tema e a importância do título e da fonte';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não identificou o tema e nem a importância do título e da fonte';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 9º Ano - Ordem 3

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Medidas de comprimento, massa, tempo, temperatura e área/volume';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreendeu a ideia, realizando registros aleatórios';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 9,3,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 9 and "Ordenacao" = 3)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia e errou o resultado';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia e acertou o resultado utilizando estratégias não convencionais e/ou outras estratégias';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou o resultado utilizando estratégias convencionais/ cálculo mental';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 9º Ano - Ordem 4

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Ângulos em polígonos';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreendeu a ideia, realizando registros aleatórios';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 9,4,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 9 and "Ordenacao" = 4)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Reconheceu parte da terminologia de ângulos que apareceram na questão, mas ainda não consolidou o conhecimento';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Reconheceu parte das terminologias sobre polígonos que apareceram na questão, mas ainda não consolidou o conhecimento';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Reconheceu todas as terminologias que apareceram na questão e acertou os resultados utilizando estratégias convencionais/ cálculo mental';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 9º Ano - Ordem 5

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Relações entre grandezas: diretamente, inversamente ou não proporcionais';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreendeu a ideia da situação-problema';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 9,5,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 9 and "Ordenacao" = 5)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia e errou o resultado';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia e acertou o resultado utilizando estratégias não convencionais e/ou outras estratégias';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou o resultado utilizando estratégias convencionais/ cálculo mental';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 9º Ano - Ordem 6

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Relações entre grandezas: diretamente, inversamente ou não proporcionais';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreendeu a ideia da situação-problema';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 9,6,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 9 and "Ordenacao" = 6)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia e errou o resultado';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia e acertou o resultado utilizando estratégias não convencionais e/ou outras estratégias';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou o resultado utilizando estratégias convencionais/ cálculo mental';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 9º Ano - Ordem 7

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Área';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreendeu a ideia de área';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 9,7,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 9 and "Ordenacao" = 7)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia, mas errou o cálculo';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Calculou apenas com os valores dispostos na situação-problema';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de área';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 9º Ano - Ordem 8

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Medidas de comprimento, capacidade e massa: uso de unidades padronizadas, comparações e estimativas - Área';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreendeu a ideia de área';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 9,8,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 9 and "Ordenacao" = 8)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia, mas errou o cálculo';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Calculou apenas com os valores dispostos na situação-problema';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de área';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 9º Ano - Ordem 9

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Problemas com números reais, porcentagens sucessivas, taxas percentuais e juros simples';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreendeu a ideia da situação-problema';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 9,9,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 9 and "Ordenacao" = 9)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia e errou o resultado';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia e acertou o resultado utilizando estratégias não convencionais e/ou outras estratégias';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou o resultado utilizando estratégias convencionais/ cálculo mental';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 9º Ano - Ordem 10

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
select p."Id" into perguntaId from public."Pergunta" p where p."Descricao" = 'Problemas com números reais, porcentagens sucessivas, taxas percentuais e juros simples';
select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreendeu a ideia da situação-problema';	

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 9,10,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 9 and "Ordenacao" = 10)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia e errou o resultado';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia e acertou o resultado utilizando estratégias não convencionais e/ou outras estratégias';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acertou o resultado utilizando estratégias convencionais/ cálculo mental';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5,perguntaAnoEscolarId);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao","PerguntaAnoEscolarId")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6,perguntaAnoEscolarId);

end $$;