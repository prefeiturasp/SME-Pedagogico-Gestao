CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo respostas
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante acertou a questão dando como resposta a moeda de 1 real' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante acertou a questão dando como resposta a moeda de 1 real');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante errou a questão dando como resposta a moeda de 10 centavos' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante errou a questão dando como resposta a moeda de 10 centavos');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante respondeu outra moeda de valor diferente' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante respondeu outra moeda de valor diferente');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante respondeu mais de uma moeda' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante respondeu mais de uma moeda');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não resolveu a questão' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não resolveu a questão');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Estudante ausente' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Estudante ausente');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante completou corretamente todo o quadro' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante completou corretamente todo o quadro');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante acertou o quadro parcialmente' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante acertou o quadro parcialmente');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante confundiu valores maiores com valores menores' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante confundiu valores maiores com valores menores');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante preencheu o quadro aleatóriamente e de forma incorreta' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante preencheu o quadro aleatóriamente e de forma incorreta');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante respondeu corretamente todas as questões' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante respondeu corretamente todas as questões');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante ordenou corretamente, mas não identidicou quem pesa mais de 2kg' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante ordenou corretamente, mas não identidicou quem pesa mais de 2kg');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não ordenou corretamente, mas identificou quem pesa mais de 2kg' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não ordenou corretamente, mas identificou quem pesa mais de 2kg');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante errou todas as questões' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante errou todas as questões');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante respondeu corretamente toda a questão' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante respondeu corretamente toda a questão');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante acertou parcialmente algumas transformações de unidades de medida' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante acertou parcialmente algumas transformações de unidades de medida');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante somente registrou os ingredientes e as medidas do enunciado da questão, mas não fez as conversões' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante somente registrou os ingredientes e as medidas do enunciado da questão, mas não fez as conversões');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante errou todas as conversões de unidades de medida' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante errou todas as conversões de unidades de medida');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante ordenou corretamente os números e identificou os números pares' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante ordenou corretamente os números e identificou os números pares');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante ordenou os números corretamente, mas não identificou os números pares' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante ordenou os números corretamente, mas não identificou os números pares');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não ordenou os números corretamente, porém identificou os números pares' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não ordenou os números corretamente, porém identificou os números pares');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não respondeu corretamente nenhum dos itens da questão' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não respondeu corretamente nenhum dos itens da questão');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante registrou corretamente a regra de cada sequência e completou com os números que estão faltando em cada linha' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante registrou corretamente a regra de cada sequência e completou com os números que estão faltando em cada linha');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não registrou corretamente a regra de cada sequência, mas completou corretamente os valores faltantes nas linhas' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não registrou corretamente a regra de cada sequência, mas completou corretamente os valores faltantes nas linhas');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante registrou corretamente a regularidade de cada sequência, porém errou os valores faltantes nas linhas' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante registrou corretamente a regularidade de cada sequência, porém errou os valores faltantes nas linhas');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não registrou corretamente a regra de cada sequência e errou os valores faltantes nas linhas' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não registrou corretamente a regra de cada sequência e errou os valores faltantes nas linhas');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante calculou corretamente todas as operações apresentadas' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante calculou corretamente todas as operações apresentadas');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante calculou apenas os valores de uma das operações: adição ou subtração' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante calculou apenas os valores de uma das operações: adição ou subtração');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante calculou apenas as operações cujo resultado final está sendo solicitado' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante calculou apenas as operações cujo resultado final está sendo solicitado');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante errou todas as operações' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante errou todas as operações');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante compôs corretamente todos os números' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante compôs corretamente todos os números');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante compôs corretamente os números 725 e 859 e errou a Composição do número 590' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante compôs corretamente os números 725 e 859 e errou a Composição do número 590');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante compôs corretamente apenas o número 590' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante compôs corretamente apenas o número 590');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante errou a Composição de todos os números' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante errou a Composição de todos os números');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante identificou corretamente todas as figuras geométricas que correspondem à superfície do cilindro' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante identificou corretamente todas as figuras geométricas que correspondem à superfície do cilindro');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante identificou apenas o cálculo como parte da planificação da superfície do cilindro' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante identificou apenas o cálculo como parte da planificação da superfície do cilindro');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante identificou apenas o retângulo como parte da planificação da superfície do cilindro' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante identificou apenas o retângulo como parte da planificação da superfície do cilindro');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante respondeu que o triângulo e/ou pentágono compõem a superfície do cilindro' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante respondeu que o triângulo e/ou pentágono compõem a superfície do cilindro');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante associou corretamente todas as planificações com os sólidos correspondentes' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante associou corretamente todas as planificações com os sólidos correspondentes');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante associou apenas as planificações das superfícies dos corpos redondos' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante associou apenas as planificações das superfícies dos corpos redondos');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante identifica apenas as planificações dos poliedros' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante identifica apenas as planificações dos poliedros');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante associou apenas apenas a planificação da superfície do cubo' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante associou apenas apenas a planificação da superfície do cubo');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante ordenou em ordem descrescente e localizou corretamente o número na reta numérica' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante ordenou em ordem descrescente e localizou corretamente o número na reta numérica');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante ordenou parcialmente os números em ordem descrescente e localizou corretamente o número na reta numérica' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante ordenou parcialmente os números em ordem descrescente e localizou corretamente o número na reta numérica');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não ordenou os números em ordem descrescente, mas localizou corretamente o número na reta numérica' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não ordenou os números em ordem descrescente, mas localizou corretamente o número na reta numérica');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante errou toda a questão' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante errou toda a questão');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante registrou o número esperado e escreveu por extenso corretamente' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante registrou o número esperado e escreveu por extenso corretamente');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante registrou o número esperado, mas não escreveu por extenso corretamente' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante registrou o número esperado, mas não escreveu por extenso corretamente');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não registrou o número esperado, mas escreveu por extenso corretamente' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não registrou o número esperado, mas escreveu por extenso corretamente');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante acertou o resultado utilizando estratégias convencionais/cálculo mental' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante acertou o resultado utilizando estratégias convencionais/cálculo mental');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante acertou o resultado utilizando estratégias não convencionais e/ou outras estratégias' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante acertou o resultado utilizando estratégias não convencionais e/ou outras estratégias');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante compreendeu a ideia, mas errou o resultado' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante compreendeu a ideia, mas errou o resultado');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante identificou todas as figuras espaciais e todas as figuras planas' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante identificou todas as figuras espaciais e todas as figuras planas');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante identificou apenas as figuras espaciais' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante identificou apenas as figuras espaciais');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante identificou apenas as figuras planas' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante identificou apenas as figuras planas');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante identificou a quantidade de faces de todas as figuras espaciais' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante identificou a quantidade de faces de todas as figuras espaciais');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante identificou a quantidade de faces apenas na pirâmide' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante identificou a quantidade de faces apenas na pirâmide');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante identificou a quantidade faces visíveis das figuras' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante identificou a quantidade faces visíveis das figuras');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante localizou a informação corretamente' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante localizou a informação corretamente');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante localizou a informação na linha, mas errou a coluna' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante localizou a informação na linha, mas errou a coluna');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante localizou a informação na coluna, mas errou a linha' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante localizou a informação na coluna, mas errou a linha');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não compreendeu a ideia do problema' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não compreendeu a ideia do problema');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante realiza a leitura de dados explícitos e implícitos' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante realiza a leitura de dados explícitos e implícitos');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante realiza a leitura de dados explícitos e compreende a ideia de dado implícito, mas não o identifica corretamente' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante realiza a leitura de dados explícitos e compreende a ideia de dado implícito, mas não o identifica corretamente');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante realiza somente a leitura de dados explícitos no gráfico' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante realiza somente a leitura de dados explícitos no gráfico');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não realiza a leitura de dados apresentados em gráficos' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não realiza a leitura de dados apresentados em gráficos');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante resolveu a questão corretamente' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante resolveu a questão corretamente');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante calculou corretamente a quantidade de horas, porém errou a quantidade de minutos.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante calculou corretamente a quantidade de horas, porém errou a quantidade de minutos.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante realizou outro cálculo e não considerou pm e am' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante realizou outro cálculo e não considerou pm e am');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não compreendeu o problema e copiou um dos números presentes no texto' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não compreendeu o problema e copiou um dos números presentes no texto');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante calculou corretamente a quantidade de horas, porém errou a quantidade de minutos' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante calculou corretamente a quantidade de horas, porém errou a quantidade de minutos');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante adicionou os dois valores e obteve 23h90, ou 24h30, podendo ou não converter os minutos somados' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante adicionou os dois valores e obteve 23h90, ou 24h30, podendo ou não converter os minutos somados');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não compreendeu o problema e copiou um dos três números presentes no texto' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não compreendeu o problema e copiou um dos três números presentes no texto');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante contou a quantidade de pedaços de cada sabor da pizza, representando-a por um número natural (a)' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante contou a quantidade de pedaços de cada sabor da pizza, representando-a por um número natural (a)');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante identificou parcialmente a relação parte/todo, mas relacionou o todo com o número 8 (quantidade de partes que normalmente uma pizza vem dividida) (c)' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante identificou parcialmente a relação parte/todo, mas relacionou o todo com o número 8 (quantidade de partes que normalmente uma pizza vem dividida) (c)');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não identificou a relação parte/todo, mas a relação parte/parte (d)' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não identificou a relação parte/todo, mas a relação parte/parte (d)');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante representou o número 1/2 onde deve ser representado o número 2' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante representou o número 1/2 onde deve ser representado o número 2');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante representou o número 1/2 onde deve ser representado o número 1/8' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante representou o número 1/2 onde deve ser representado o número 1/8');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante planificou a base da pirâmide quadrada, mas teve dificuldade em representar as faces triangulares da planificação' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante planificou a base da pirâmide quadrada, mas teve dificuldade em representar as faces triangulares da planificação');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante planificou superfície da pirâmide com outra base (triangular, retangular, etc.) e representou as faces triangulares' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante planificou superfície da pirâmide com outra base (triangular, retangular, etc.) e representou as faces triangulares');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não compreendeu o problema e representou apenas o triângulo, associando-o à ideia de representação da pirâmide' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não compreendeu o problema e representou apenas o triângulo, associando-o à ideia de representação da pirâmide');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante identificou que é a planificação da superfície de um prisma, mas o prisma de base pentagonal' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante identificou que é a planificação da superfície de um prisma, mas o prisma de base pentagonal');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante relacionou o paralelepípedo com a planificação da superfície de uma pirâmide de base retangular' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante relacionou o paralelepípedo com a planificação da superfície de uma pirâmide de base retangular');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante relacionou o paralelepípedo com a planificação da superfície de uma pirâmide de base triangular' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante relacionou o paralelepípedo com a planificação da superfície de uma pirâmide de base triangular');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não compreendeu o conceito de probabilidade e respondeu 26' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não compreendeu o conceito de probabilidade e respondeu 26');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante se aproximou da noção de probabilidade e registrou 26/24 ou 24/26' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante se aproximou da noção de probabilidade e registrou 26/24 ou 24/26');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante demonstrou que não sabe o que é probabilidade' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante demonstrou que não sabe o que é probabilidade');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não compreendeu o conceito de probabilidade e respondeu o número 5, pois considerou apenas o trecho um número maior do que quatro' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não compreendeu o conceito de probabilidade e respondeu o número 5, pois considerou apenas o trecho um número maior do que quatro');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não compreendeu o conceito de probabilidade e respondeu os números 5 e 6 porque considerou apenas o trecho um número maior do que quatro' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não compreendeu o conceito de probabilidade e respondeu os números 5 e 6 porque considerou apenas o trecho um número maior do que quatro');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante resolveu a questão corretamente e se baseou nas propriedades da igualdade' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante resolveu a questão corretamente e se baseou nas propriedades da igualdade');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante resolveu a questão corretamente, mas realizou todas as divisões' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante resolveu a questão corretamente, mas realizou todas as divisões');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não compreendeu as propriedades da igualdade e respondeu que Juliano tem razão' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não compreendeu as propriedades da igualdade e respondeu que Juliano tem razão');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não compreendeu as propriedades da igualdade e respondeu que Martha tem razão' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não compreendeu as propriedades da igualdade e respondeu que Martha tem razão');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante resolveu a questão corretamente, mas realizou as operações' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante resolveu a questão corretamente, mas realizou as operações');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante compreendeu as propriedades da igualdade, mas errou os cálculos das operações' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante compreendeu as propriedades da igualdade, mas errou os cálculos das operações');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não compreendeu a questão e respondeu um número aleatório' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não compreendeu a questão e respondeu um número aleatório');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não compreendeu o enunciado da questão e acertou os resultados das operações' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não compreendeu o enunciado da questão e acertou os resultados das operações');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante compreendeu o enunciado da questão e errou os resultados das operações' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante compreendeu o enunciado da questão e errou os resultados das operações');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não compreendeu o enunciado da questão e errou os resultados das operações' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não compreendeu o enunciado da questão e errou os resultados das operações');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreendeu o enunciado e acertou o resultado das operações' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreendeu o enunciado e acertou o resultado das operações');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não considerou corretamente a ordem das operações, mas acertou os resultados das operações' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não considerou corretamente a ordem das operações, mas acertou os resultados das operações');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante considerou corretamente a ordem das operações, mas errou os resultados das operações' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante considerou corretamente a ordem das operações, mas errou os resultados das operações');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não considerou corretamente a ordem das operações e errou os resultados das operações' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não considerou corretamente a ordem das operações e errou os resultados das operações');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não indicou a expressão numérica que resolve o problema, mas calculou o troco corretamente' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não indicou a expressão numérica que resolve o problema, mas calculou o troco corretamente');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante indicou a expressão numérica que resolve o problema, mas não calculou o troco corretamente' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante indicou a expressão numérica que resolve o problema, mas não calculou o troco corretamente');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não indicou a expressão numérica que resolve o problema e não calculou o troco corretamente' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não indicou a expressão numérica que resolve o problema e não calculou o troco corretamente');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante compreendeu a situação e realizou os cálculos corretamente para uma forma de gelo' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante compreendeu a situação e realizou os cálculos corretamente para uma forma de gelo');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante compreendeu a situação, mas errou os cálculos e/ou não sabe que 1 000 mL equivale a 1 L' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante compreendeu a situação, mas errou os cálculos e/ou não sabe que 1 000 mL equivale a 1 L');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não compreendeu a situação e realizou cálculos aleatórios com os números que aparecem no texto do problema' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não compreendeu a situação e realizou cálculos aleatórios com os números que aparecem no texto do problema');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante compreendeu o conceito de volume e acertou o resultado das operações' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante compreendeu o conceito de volume e acertou o resultado das operações');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não compreendeu o conceito de volume e realizou as operações 2 + 2 ou 2 x 2' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não compreendeu o conceito de volume e realizou as operações 2 + 2 ou 2 x 2');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não compreendeu o conceito de volume e realizou a operação 2 + 2 + 2 ou 3 x 2' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não compreendeu o conceito de volume e realizou a operação 2 + 2 + 2 ou 3 x 2');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não compreendeu o conceito de volume e realizou operações aleatórias 5 x 2 ou 6 x 2' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não compreendeu o conceito de volume e realizou operações aleatórias 5 x 2 ou 6 x 2');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante identificou somente a planificação da superfície de uma pirâmide, denominando-a corretamente' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante identificou somente a planificação da superfície de uma pirâmide, denominando-a corretamente');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante identificou as planificações das superfícies das duas pirâmides, mas não conseguiu denominar ambas, ou uma delas' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante identificou as planificações das superfícies das duas pirâmides, mas não conseguiu denominar ambas, ou uma delas');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não compreendeu a diferença entre prismas e pirâmides por meio das planificações de suas superfícies e não conseguiu nomear as pirâmides' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não compreendeu a diferença entre prismas e pirâmides por meio das planificações de suas superfícies e não conseguiu nomear as pirâmides');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante afirmou que entre os poliedros apresentados, nenhum possui a mesma quantidade de faces e de vértices' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante afirmou que entre os poliedros apresentados, nenhum possui a mesma quantidade de faces e de vértices');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante comprendeu o que é face e vértice de um poliedro, mas não conseguiu determinar as respectivas quantidades corretamente' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante comprendeu o que é face e vértice de um poliedro, mas não conseguiu determinar as respectivas quantidades corretamente');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante demonstrou que não sabe o que é uma face ou um vértice de um poliedro' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante demonstrou que não sabe o que é uma face ou um vértice de um poliedro');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante acertou a letra com maior chance de ser sorteada, mas não calculou a respectiva probabilidade' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante acertou a letra com maior chance de ser sorteada, mas não calculou a respectiva probabilidade');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante acertou a letra com maior chance de ser sorteada, mas errou a respectiva probabilidade' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante acertou a letra com maior chance de ser sorteada, mas errou a respectiva probabilidade');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante demonstrou que não sabe o que é probabilidade e/ou o que é um evento' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante demonstrou que não sabe o que é probabilidade e/ou o que é um evento');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante reconheceu o espaço amostral (a), não reconheceu o evento específico (b) e nem calculou a probabilidade (c)' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante reconheceu o espaço amostral (a), não reconheceu o evento específico (b) e nem calculou a probabilidade (c)');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante reconheceu o espaço amostral (a) e o evento específico (b), mas errou a probabilidade (c)' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante reconheceu o espaço amostral (a) e o evento específico (b), mas errou a probabilidade (c)');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante demonstrou que não sabe o que é probabilidade, evento e/ou ao acaso' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante demonstrou que não sabe o que é probabilidade, evento e/ou ao acaso');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante resolveu o problema corretamente, por meio de dados numéricos organizados (quadro de dados, sentenças matemáticas e/ou equações)' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante resolveu o problema corretamente, por meio de dados numéricos organizados (quadro de dados, sentenças matemáticas e/ou equações)');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante estruturou algumas informações do problema de forma lógica, mas apresentou a resposta inadequada' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante estruturou algumas informações do problema de forma lógica, mas apresentou a resposta inadequada');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante resolveu o problema corretamente, por meio de desenho, esquemas ou contagens pictóricas' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante resolveu o problema corretamente, por meio de desenho, esquemas ou contagens pictóricas');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não estruturou os dados do problema de forma lógica e/ou realizou cálculos aleatórios com números presentes no texto' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não estruturou os dados do problema de forma lógica e/ou realizou cálculos aleatórios com números presentes no texto');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante resolveu o problema corretamente, por meio de uma sentença matemática ou dados esteuturados' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante resolveu o problema corretamente, por meio de uma sentença matemática ou dados esteuturados');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante estruturou algumas informações do problema, mas apresentou resposta inadequada' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante estruturou algumas informações do problema, mas apresentou resposta inadequada');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante determinou corretamente o percentual de 10%, mas desconsiderou o desconto, gerando resposta inadequada' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante determinou corretamente o percentual de 10%, mas desconsiderou o desconto, gerando resposta inadequada');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante determinou, corretamente, o percentual de 2%, mas desconsiderou o acréscimo (juros), gerando resposta inadequada' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante determinou, corretamente, o percentual de 2%, mas desconsiderou o acréscimo (juros), gerando resposta inadequada');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante estruturou a escrita do cálculo do volume do paralelepípedo com dados faltantes, apresentando resposta inadequada' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante estruturou a escrita do cálculo do volume do paralelepípedo com dados faltantes, apresentando resposta inadequada');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante estruturou a escrita do cálculo do volume do paralelepípedo incluindo as três dimensões e/ou unidade de medida, mas apresentou resposta inadequada' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante estruturou a escrita do cálculo do volume do paralelepípedo incluindo as três dimensões e/ou unidade de medida, mas apresentou resposta inadequada');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante realizou cálculos aleatórios com o número presente no texto e apresentou a unidade de medida' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante realizou cálculos aleatórios com o número presente no texto e apresentou a unidade de medida');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante solucionou adequadamente o cálculo do volume da escultura, mas não indicou a unidade de medida' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante solucionou adequadamente o cálculo do volume da escultura, mas não indicou a unidade de medida');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não solucionou adequadamente o cálculo do volume da escultura e não indicou a unidade de medida' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não solucionou adequadamente o cálculo do volume da escultura e não indicou a unidade de medida');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante reconheceu as características da transformação e representou adequadamente parte do trapézio simétrico em relação ao eixo r' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante reconheceu as características da transformação e representou adequadamente parte do trapézio simétrico em relação ao eixo r');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante reconheceu as características da transformação, representou adequadamente o trapézio simétrico em relação ao eixo r, mas não o identificou por A’B’C’D’' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante reconheceu as características da transformação, representou adequadamente o trapézio simétrico em relação ao eixo r, mas não o identificou por A’B’C’D’');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não reconheceu as características da transformação e representou inadequadamente o trapézio simétrico em relação ao eixo r' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não reconheceu as características da transformação e representou inadequadamente o trapézio simétrico em relação ao eixo r');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante errou as nomenclaturas das transformações geométricas de dois casos' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante errou as nomenclaturas das transformações geométricas de dois casos');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante errou a nomenclatura de uma transformação geométrica' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante errou a nomenclatura de uma transformação geométrica');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante errou as nomenclaturas das transformações geométricas dos três casos' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante errou as nomenclaturas das transformações geométricas dos três casos');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante calculou corretamente a probabilidade de ser retirado um número par e calculou, incorretamente, a probabilidade de retirar um número par e maior que 15' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante calculou corretamente a probabilidade de ser retirado um número par e calculou, incorretamente, a probabilidade de retirar um número par e maior que 15');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante calculou incorretamente a probabilidade de ser retirado um número par e calculou, corretamente, a probabilidade de retirar um número par maior que 15' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante calculou incorretamente a probabilidade de ser retirado um número par e calculou, corretamente, a probabilidade de retirar um número par maior que 15');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante calculou incorretamente as duas probabilidades: retirar um número par e retirar um número par e maior que 15' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante calculou incorretamente as duas probabilidades: retirar um número par e retirar um número par e maior que 15');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante calculou incorretamente a probabilidade do resultado do lançamento de um dado de seis faces ser um número maior que 4 e apresentou 6/6 como resposta' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante calculou incorretamente a probabilidade do resultado do lançamento de um dado de seis faces ser um número maior que 4 e apresentou 6/6 como resposta');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante calculou incorretamente a probabilidade do resultado do lançamento de um dado de seis faces ser um número maior que 4 e apresentou 5/6 como resposta' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante calculou incorretamente a probabilidade do resultado do lançamento de um dado de seis faces ser um número maior que 4 e apresentou 5/6 como resposta');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante calculou incorretamente a probabilidade do resultado do lançamento de um dado de seis faces ser um número maior que 4 e apresentou 4/6 como resposta' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante calculou incorretamente a probabilidade do resultado do lançamento de um dado de seis faces ser um número maior que 4 e apresentou 4/6 como resposta');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante determinou o valor de duas camisetas, por meio de desenho, esquemas ou tentativa e erro), mas não encontrou o valor de 4 camisetas' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante determinou o valor de duas camisetas, por meio de desenho, esquemas ou tentativa e erro), mas não encontrou o valor de 4 camisetas');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante determinou o valor de duas camisetas, por meio do cálculo mental ou das operações ou da álgebra, mas não encontrou o valor das 4 camisetas' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante determinou o valor de duas camisetas, por meio do cálculo mental ou das operações ou da álgebra, mas não encontrou o valor das 4 camisetas');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não compreendeu o enunciado do problema, realizando operações aleatórias com os números do texto' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não compreendeu o enunciado do problema, realizando operações aleatórias com os números do texto');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não compreendeu o enunciado do problema e respondeu 2 como resposta, pois o cliente tem direito a dois pasteis de brinde' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não compreendeu o enunciado do problema e respondeu 2 como resposta, pois o cliente tem direito a dois pasteis de brinde');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante compreendeu o enunciado do problema, mas não apresentou todas as possibilidades possíveis' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante compreendeu o enunciado do problema, mas não apresentou todas as possibilidades possíveis');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante compreendeu parcialmente o problema, pois realizou as duas porcentagens corretamente, mas ambas a partir de 2 000 reais' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante compreendeu parcialmente o problema, pois realizou as duas porcentagens corretamente, mas ambas a partir de 2 000 reais');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante compreendeu o problema, mas errou os cálculos das duas porcentagens' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante compreendeu o problema, mas errou os cálculos das duas porcentagens');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não compreendeu o problema e determinou 30% do valor ou realizou operações aleatórias com os números do texto' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não compreendeu o problema e determinou 30% do valor ou realizou operações aleatórias com os números do texto');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante compreendeu parcialmente o problema, pois realizou as duas porcentagens corretamente, mas ambas a partir de 200 reais' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante compreendeu parcialmente o problema, pois realizou as duas porcentagens corretamente, mas ambas a partir de 200 reais');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não compreendeu o problema e determinou 15% do valor, ou realizou operações aleatórias com os números do texto' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não compreendeu o problema e determinou 15% do valor, ou realizou operações aleatórias com os números do texto');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante indicou apenas o eixo de simetria horizontal' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante indicou apenas o eixo de simetria horizontal');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante indicou apenas o eixo de simetria vertical' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante indicou apenas o eixo de simetria vertical');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante demonstrou que não sabe o que é um eixo de simetria' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante demonstrou que não sabe o que é um eixo de simetria');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não compreendeu o problema pois fez uma cópia da figura, desconsiderando a reflexão' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não compreendeu o problema pois fez uma cópia da figura, desconsiderando a reflexão');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante compreendeu parcialmenre o problema, pois desconsiderou as medidas dos lados e dos ângulos correspondentes na figura refletida, mas tentou manter a sua forma' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante compreendeu parcialmenre o problema, pois desconsiderou as medidas dos lados e dos ângulos correspondentes na figura refletida, mas tentou manter a sua forma');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante demonstrou que não sabe o que representa a linha AB' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante demonstrou que não sabe o que representa a linha AB');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não compreendeu o problema, pois registrou que a largura da coluna mais alta deveria ser maior do que a largura da coluna mais baixa' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não compreendeu o problema, pois registrou que a largura da coluna mais alta deveria ser maior do que a largura da coluna mais baixa');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante compreendeu o problema parcialmente, mas registrou que o erro está, por exemplo, na reprentação dos números 50 000 e 75 000 no eixo vertical' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante compreendeu o problema parcialmente, mas registrou que o erro está, por exemplo, na reprentação dos números 50 000 e 75 000 no eixo vertical');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não compreendeu o problema, pois discordou da questão e demonstrou que o gráfico está correto' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não compreendeu o problema, pois discordou da questão e demonstrou que o gráfico está correto');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não compreendeu o problema, pois registrou a empresa LATAM, ou as colunas TOTAL nos dois gráficos, ou a coluna TOTAL no gráfico de 2021' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não compreendeu o problema, pois registrou a empresa LATAM, ou as colunas TOTAL nos dois gráficos, ou a coluna TOTAL no gráfico de 2021');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante compreendeu parcialmente o problema, pois indicou a diferença entre as duas colunas TOTAL, mas não demonstrou a impossibilidade de atribuir um valor numérico a esta diferença' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante compreendeu parcialmente o problema, pois indicou a diferença entre as duas colunas TOTAL, mas não demonstrou a impossibilidade de atribuir um valor numérico a esta diferença');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não compreendeu o problema e opera com os números que aparecem no texto (por exemplo: realizou a subtração 2021 - 2012)' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não compreendeu o problema e opera com os números que aparecem no texto (por exemplo: realizou a subtração 2021 - 2012)');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante não compreendeu o problema porque faz operações aleatórias com os números 3 e 7' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante não compreendeu o problema porque faz operações aleatórias com os números 3 e 7');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante compreendeu parcialmente o problem porque identificou todas as chances de sair soma 3 e todas as chances de sair soma 7, mas não calculou as probabilidades' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante compreendeu parcialmente o problem porque identificou todas as chances de sair soma 3 e todas as chances de sair soma 7, mas não calculou as probabilidades');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante compreendeu o problema, mas não determinou todas as sequências possíveis e não justificou porque acontecer três caras é menos provável' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante compreendeu o problema, mas não determinou todas as sequências possíveis e não justificou porque acontecer três caras é menos provável');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante compreendeu o problema, determinou todas as sequências possíveis, mas não justificou porque acontecer três caras é menos provável' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante compreendeu o problema, determinou todas as sequências possíveis, mas não justificou porque acontecer três caras é menos provável');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'O estudante demonstrou que não sabe o que é uma sequência ou o significado de provável ou o significado de em qualquer ordem' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'O estudante demonstrou que não sabe o que é uma sequência ou o significado de provável ou o significado de em qualquer ordem');

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 4º Ano

do $$
declare 
	respostaId text;
	perguntaId text;
	perguntaAnoEscolarId text;
begin
	
--> Questão 1
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Problemas envolvendo o sistema monetário brasileiro','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;	

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4, 1, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 1)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante acertou a questão dando como resposta a moeda de 1 real';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante errou a questão dando como resposta a moeda de 10 centavos';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante respondeu outra moeda de valor diferente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante respondeu mais de uma moeda';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 2
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Problemas envolvendo o sistema monetário brasileiro','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4, 2, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 2)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante completou corretamente todo o quadro';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante acertou o quadro parcialmente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante confundiu valores maiores com valores menores';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante preencheu o quadro aleatóriamente e de forma incorreta';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 3
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Capacidade e massa: uso de unidades padronizadas, comparações e estimativas','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4, 3, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 3)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante respondeu corretamente todas as questões';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante ordenou corretamente, mas não identidicou quem pesa mais de 2kg';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não ordenou corretamente, mas identificou quem pesa mais de 2kg';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante errou todas as questões';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 4
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Capacidade e massa: uso de unidades padronizadas, comparações e estimativas','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4, 4, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 4)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante respondeu corretamente toda a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante acertou parcialmente algumas transformações de unidades de medida';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante somente registrou os ingredientes e as medidas do enunciado da questão, mas não fez as conversões';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante errou todas as conversões de unidades de medida';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 5
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Sistema de numeração decimal: leitura, escrita, comparação e ordenação de números naturais','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4, 5, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 5)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante ordenou corretamente os números e identificou os números pares';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante ordenou os números corretamente, mas não identificou os números pares';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não ordenou os números corretamente, porém identificou os números pares';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não respondeu corretamente nenhum dos itens da questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 6
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Sistema de numeração decimal: leitura, escrita, comparação e ordenação de números naturais','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4, 6, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 6)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante registrou corretamente a regra de cada sequência e completou com os números que estão faltando em cada linha';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não registrou corretamente a regra de cada sequência, mas completou corretamente os valores faltantes nas linhas';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante registrou corretamente a regularidade de cada sequência, porém errou os valores faltantes nas linhas';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não registrou corretamente a regra de cada sequência e errou os valores faltantes nas linhas';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 7
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Composição e deComposição de números naturais','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4, 7, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 7)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante calculou corretamente todas as operações apresentadas';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante calculou apenas os valores de uma das operações: adição ou subtração';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante calculou apenas as operações cujo resultado final está sendo solicitado';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante errou todas as operações';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 8
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Composição e deComposição de números naturais','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4, 8, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 8)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante compôs corretamente todos os números';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante compôs corretamente os números 725 e 859 e errou a Composição do número 590';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante compôs corretamente apenas o número 590';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante errou a Composição de todos os números';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 9
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Planificação de figuras geométricas espaciais','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4, 9, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 9)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante identificou corretamente todas as figuras geométricas que correspondem à superfície do cilindro';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante identificou apenas o cálculo como parte da planificação da superfície do cilindro';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante identificou apenas o retângulo como parte da planificação da superfície do cilindro';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante respondeu que o triângulo e/ou pentágono compõem a superfície do cilindro';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 10
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Planificação de figuras geométricas espaciais','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4, 10, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 10)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante associou corretamente todas as planificações com os sólidos correspondentes';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante associou apenas as planificações das superfícies dos corpos redondos';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante identifica apenas as planificações dos poliedros';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante associou apenas apenas a planificação da superfície do cubo';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 5º Ano

--> Questão 1
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Sistema de numeração decimal: leitura, escrita, ordenação e localização na reta numerada de números naturais','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5, 1, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 1)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante ordenou em ordem descrescente e localizou corretamente o número na reta numérica';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante ordenou parcialmente os números em ordem descrescente e localizou corretamente o número na reta numérica';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não ordenou os números em ordem descrescente, mas localizou corretamente o número na reta numérica';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante errou toda a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 2
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Sistema de numeração decimal: leitura, escrita, ordenação e localização na reta numerada de números naturais','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5, 2, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 2)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante registrou o número esperado e escreveu por extenso corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante registrou o número esperado, mas não escreveu por extenso corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não registrou o número esperado, mas escreveu por extenso corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante errou toda a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 3
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Propriedades da igualdade','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5, 3, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 3)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante acertou o resultado utilizando estratégias convencionais/cálculo mental';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante acertou o resultado utilizando estratégias não convencionais e/ou outras estratégias';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante compreendeu a ideia, mas errou o resultado';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante errou toda a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 4
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Propriedades da igualdade','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5, 4, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 4)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante acertou o resultado utilizando estratégias convencionais/cálculo mental';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante acertou o resultado utilizando estratégias não convencionais e/ou outras estratégias';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante compreendeu a ideia, mas errou o resultado';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante errou toda a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 5
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Medidas de temperatura','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5, 5, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 5)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante acertou o resultado utilizando estratégias convencionais/cálculo mental';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante acertou o resultado utilizando estratégias não convencionais e/ou outras estratégias';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante compreendeu a ideia, mas errou o resultado';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante errou toda a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 6
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Medidas de tempo','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5, 6, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 6)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante acertou o resultado utilizando estratégias convencionais/cálculo mental';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante acertou o resultado utilizando estratégias não convencionais e/ou outras estratégias';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante compreendeu a ideia, mas errou o resultado';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante errou toda a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 7
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Figuras espaciais: diferenças e similaridades','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5, 7, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 7)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante identificou todas as figuras espaciais e todas as figuras planas';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante identificou apenas as figuras espaciais';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante identificou apenas as figuras planas';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante errou toda a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 8
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Figuras espaciais: diferenças e similaridades','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5, 8, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 8)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante identificou a quantidade de faces de todas as figuras espaciais';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante identificou a quantidade de faces apenas na pirâmide';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante identificou a quantidade faces visíveis das figuras';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante errou toda a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 9
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Tabela Simples e de dupla entrada, tráficos de colunas, gráficos de linhas, barras e pictóricos','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5, 9, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 9)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante localizou a informação corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante localizou a informação na linha, mas errou a coluna';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante localizou a informação na coluna, mas errou a linha';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu a ideia do problema';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 10
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Tabela Simples e de dupla entrada, tráficos de colunas, gráficos de linhas, barras e pictóricos','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5, 10, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 10)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante realiza a leitura de dados explícitos e implícitos';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante realiza a leitura de dados explícitos e compreende a ideia de dado implícito, mas não o identifica corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante realiza somente a leitura de dados explícitos no gráfico';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não realiza a leitura de dados apresentados em gráficos';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 6º Ano

--> Questão 1: 
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId")
values (uuid_generate_v4()::text,'Problemas envolvendo medidas de tempo','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 6, 1, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 6 and "Ordenacao" = 1)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante calculou corretamente a quantidade de horas, porém errou a quantidade de minutos';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante realizou outro cálculo e não considerou pm e am';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu o problema e copiou um dos números presentes no texto';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 2: 
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId")
values (uuid_generate_v4()::text,'Problemas envolvendo medidas de tempo','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 6, 2, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 6 and "Ordenacao" = 2)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante calculou corretamente a quantidade de horas, porém errou a quantidade de minutos';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante adicionou os dois valores e obteve 23h90, ou 24h30, podendo ou não converter os minutos somados';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu o problema e copiou um dos três números presentes no texto';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 3: 
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId")
values (uuid_generate_v4()::text,'números racionais:leitura, escrita,comparação, ordenação e localização na reta numerada','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 6, 3, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 6 and "Ordenacao" = 3)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante contou a quantidade de pedaços de cada sabor da pizza, representando-a por um número natural (a)';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante identificou parcialmente a relação parte/todo, mas relacionou o todo com o número 8 (quantidade de partes que normalmente uma pizza vem dividida) (c)';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não identificou a relação parte/todo, mas a relação parte/parte (d)';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 4: 
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId")
values (uuid_generate_v4()::text,'números racionais:leitura, escrita,comparação, ordenação e localização na reta numerada','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 6, 4, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 6 and "Ordenacao" = 4)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante representou o número 1/2 onde deve ser representado o número 2';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante representou o número 1/2 onde deve ser representado o número 1/8';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

--> Questão 5: 
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId")
values (uuid_generate_v4()::text, 'Planificação de superfícies de poliedros','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 6, 5, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 6 and "Ordenacao" = 5)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante planificou a base da pirâmide quadrada, mas teve dificuldade em representar as faces triangulares da planificação';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante planificou superfície da pirâmide com outra base (triangular, retangular, etc.) e representou as faces triangulares';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu o problema e representou apenas o triângulo, associando-o à ideia de representação da pirâmide';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 6: 
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId")
values (uuid_generate_v4()::text, 'Planificação de superfícies de poliedros','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 6, 6, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 6 and "Ordenacao" = 6)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante identificou que é a planificação da superfície de um prisma, mas o prisma de base pentagonal';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante relacionou o paralelepípedo com a planificação da superfície de uma pirâmide de base retangular';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante relacionou o paralelepípedo com a planificação da superfície de uma pirâmide de base triangular';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 7: 
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId")
values (uuid_generate_v4()::text, 'Cálculo de probabilidade','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 6, 7, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 6 and "Ordenacao" = 7)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu o conceito de probabilidade e respondeu 26';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante se aproximou da noção de probabilidade e registrou 26/24 ou 24/26';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante demonstrou que não sabe o que é probabilidade';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 8: 
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId")
values (uuid_generate_v4()::text, 'Cálculo de probabilidade','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 6, 8, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 6 and "Ordenacao" = 8)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu o conceito de probabilidade e respondeu o número 5, pois considerou apenas o trecho um número maior do que quatro';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu o conceito de probabilidade e respondeu os números 5 e 6 porque considerou apenas o trecho um número maior do que quatro';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante demonstrou que não sabe o que é probabilidade';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 9:
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId")
values (uuid_generate_v4()::text, 'Propriedades da igualdade','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;
 
insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 6, 9, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 6 and "Ordenacao" = 9)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente e se baseou nas propriedades da igualdade';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente, mas realizou todas as divisões';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu as propriedades da igualdade e respondeu que Juliano tem razão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu as propriedades da igualdade e respondeu que Martha tem razão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 10: 
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId")
values (uuid_generate_v4()::text, 'Propriedades da igualdade','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 6, 10, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 6 and "Ordenacao" = 10)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente e se baseou nas propriedades da igualdade';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente, mas realizou as operações';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante compreendeu as propriedades da igualdade, mas errou os cálculos das operações';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu a questão e respondeu um número aleatório';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 7º Ano

--> Questão 1
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Problemas envolvendo os significados dos campos aditivo e multiplicativo com números naturais e/ou racionais','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 7, 1, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 7 and "Ordenacao" = 1)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu o enunciado da questão e acertou os resultados das operações';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante compreendeu o enunciado da questão e errou os resultados das operações';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu o enunciado da questão e errou os resultados das operações';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 2
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Problemas envolvendo os significados dos campos aditivo e multiplicativo com números naturais e/ou racionais','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 7, 2, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 7 and "Ordenacao" = 2)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu o enunciado e acertou o resultado das operações';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu o enunciado da questão e acertou os resultados das operações';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante compreendeu o enunciado da questão e errou os resultados das operações';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu o enunciado da questão e errou os resultados das operações';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 3
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Sinais de associação','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 7, 3, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 7 and "Ordenacao" = 3)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não considerou corretamente a ordem das operações, mas acertou os resultados das operações';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante considerou corretamente a ordem das operações, mas errou os resultados das operações';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não considerou corretamente a ordem das operações e errou os resultados das operações';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 4
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'O estudante não considerou corretamente a ordem das operações e errou os resultados das operações','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 7, 4, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 7 and "Ordenacao" = 4)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não indicou a expressão numérica que resolve o problema, mas calculou o troco corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante indicou a expressão numérica que resolve o problema, mas não calculou o troco corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não indicou a expressão numérica que resolve o problema e não calculou o troco corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 5
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Objeto de conhecimento: Problemas envolvendo as medidas de comprimento, massa, tempo, temperatura e capacidade, utilizando, quando necessário, as transformações de unidade','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 7, 5, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 7 and "Ordenacao" = 5)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante compreendeu a situação e realizou os cálculos corretamente para uma forma de gelo';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante compreendeu a situação, mas errou os cálculos e/ou não sabe que 1 000 mL equivale a 1 L';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu a situação e realizou cálculos aleatórios com os números que aparecem no texto do problema';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 6
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Objeto de conhecimento: Volumes de cubos, paralelepípedos, prismas e cilindros','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 7, 6, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 7 and "Ordenacao" = 6)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante compreendeu o conceito de volume e acertou o resultado das operações';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu o conceito de volume e realizou as operações 2 + 2 ou 2 x 2';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu o conceito de volume e realizou a operação 2 + 2 + 2 ou 3 x 2';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu o conceito de volume e realizou operações aleatórias 5 x 2 ou 6 x 2';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 7
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Objeto de conhecimento: Poliedros: diferenças e similaridades; planificação; exploração e classificação; relações entre os elementos de um poliedro','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 7, 7, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 7 and "Ordenacao" = 7)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante identificou somente a planificação da superfície de uma pirâmide, denominando-a corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante identificou as planificações das superfícies das duas pirâmides, mas não conseguiu denominar ambas, ou uma delas';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu a diferença entre prismas e pirâmides por meio das planificações de suas superfícies e não conseguiu nomear as pirâmides';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 8
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Objeto de conhecimento: Poliedros: diferenças e similaridades; planificação; exploração e classificação; relações entre os elementos de um poliedro','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 7, 8, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 7 and "Ordenacao" = 8)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante afirmou que entre os poliedros apresentados, nenhum possui a mesma quantidade de faces e de vértices';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante comprendeu o que é face e vértice de um poliedro, mas não conseguiu determinar as respectivas quantidades corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante demonstrou que não sabe o que é uma face ou um vértice de um poliedro';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 9
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Objeto de Conhecimento: Problemas envolvendo espaço amostral e probabilidade de ocorrência de eventos','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 7, 9, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 7 and "Ordenacao" = 9)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante acertou a letra com maior chance de ser sorteada, mas não calculou a respectiva probabilidade';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante acertou a letra com maior chance de ser sorteada, mas errou a respectiva probabilidade';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante demonstrou que não sabe o que é probabilidade e/ou o que é um evento';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 10
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Objeto de Conhecimento: Problemas envolvendo espaço amostral e probabilidade de ocorrência de eventos','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 7, 10, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 7 and "Ordenacao" = 10)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante reconheceu o espaço amostral (a), não reconheceu o evento específico (b) e nem calculou a probabilidade (c)';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante reconheceu o espaço amostral (a) e o evento específico (b), mas errou a probabilidade (c)';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante demonstrou que não sabe o que é probabilidade, evento e/ou ao acaso';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 8º Ano

--> Questão 1
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Conjuntos numéricos: operações e resolução de problemas','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 8, 1, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 8 and "Ordenacao" = 1)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu o problema corretamente, por meio de dados numéricos organizados (quadro de dados, sentenças matemáticas e/ou equações)';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante estruturou algumas informações do problema de forma lógica, mas apresentou a resposta inadequada';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu o problema corretamente, por meio de desenho, esquemas ou contagens pictóricas';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não estruturou os dados do problema de forma lógica e/ou realizou cálculos aleatórios com números presentes no texto';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 2
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Conjuntos numéricos: operações e resolução de problemas','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 8, 2, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 8 and "Ordenacao" = 2)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu o problema corretamente, por meio de uma sentença matemática ou dados esteuturados';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante estruturou algumas informações do problema, mas apresentou resposta inadequada';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu o problema corretamente, por meio de desenho, esquemas ou contagens pictóricas';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não estruturou os dados do problema de forma lógica e/ou realizou cálculos aleatórios com números presentes no texto';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 3
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Porcentagem / Educação financeira','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 8, 3, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 8 and "Ordenacao" = 3)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante estruturou algumas informações do problema, mas apresentou resposta inadequada';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante determinou corretamente o percentual de 10%, mas desconsiderou o desconto, gerando resposta inadequada';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não estruturou os dados do problema de forma lógica e/ou realizou cálculos aleatórios com números presentes no texto';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 4
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Porcentagem / Educação financeira','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 8, 4, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 8 and "Ordenacao" = 4)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante estruturou algumas informações do problema, mas apresentou resposta inadequada';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante determinou, corretamente, o percentual de 2%, mas desconsiderou o acréscimo (juros), gerando resposta inadequada';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não estruturou os dados do problema de forma lógica e/ou realizou cálculos aleatórios com números presentes no texto';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 5
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Volumes de cubos, paralelepípedos, prismas e cilindros','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 8, 5, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 8 and "Ordenacao" = 5)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante estruturou a escrita do cálculo do volume do paralelepípedo com dados faltantes, apresentando resposta inadequada';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante estruturou a escrita do cálculo do volume do paralelepípedo incluindo as três dimensões e/ou unidade de medida, mas apresentou resposta inadequada';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não estruturou os dados do problema de forma lógica e/ou realizou cálculos aleatórios com números presentes no texto';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 6
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Volumes de cubos, paralelepípedos, prismas e cilindros','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 8, 6, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 8 and "Ordenacao" = 6)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante realizou cálculos aleatórios com o número presente no texto e apresentou a unidade de medida';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante solucionou adequadamente o cálculo do volume da escultura, mas não indicou a unidade de medida';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não solucionou adequadamente o cálculo do volume da escultura e não indicou a unidade de medida';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 7
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'transformações geométricas: translação, reflexão e rotação no plano','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 8, 7, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 8 and "Ordenacao" = 7)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante reconheceu as características da transformação e representou adequadamente parte do trapézio simétrico em relação ao eixo r';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante reconheceu as características da transformação, representou adequadamente o trapézio simétrico em relação ao eixo r, mas não o identificou por A’B’C’D’';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não reconheceu as características da transformação e representou inadequadamente o trapézio simétrico em relação ao eixo r';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 8
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'transformações geométricas: translação, reflexão e rotação no plano','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 8, 8, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 8 and "Ordenacao" = 8)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante errou as nomenclaturas das transformações geométricas de dois casos';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante errou a nomenclatura de uma transformação geométrica';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante errou as nomenclaturas das transformações geométricas dos três casos';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 9
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Problemas envolvendo espaço amostral e probabilidade de ocorrência de eventos','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 8, 9, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 8 and "Ordenacao" = 9)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante calculou corretamente a probabilidade de ser retirado um número par e calculou, incorretamente, a probabilidade de retirar um número par e maior que 15';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante calculou incorretamente a probabilidade de ser retirado um número par e calculou, corretamente, a probabilidade de retirar um número par maior que 15';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante calculou incorretamente as duas probabilidades: retirar um número par e retirar um número par e maior que 15';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 10
insert into public."Pergunta" ("Id", "Descricao", "ComponenteCurricularId")
values (uuid_generate_v4()::text,'Problemas envolvendo espaço amostral e probabilidade de ocorrência de eventos','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 8, 10, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 8 and "Ordenacao" = 10)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante calculou incorretamente a probabilidade do resultado do lançamento de um dado de seis faces ser um número maior que 4 e apresentou 6/6 como resposta';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante calculou incorretamente a probabilidade do resultado do lançamento de um dado de seis faces ser um número maior que 4 e apresentou 5/6 como resposta';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante calculou incorretamente a probabilidade do resultado do lançamento de um dado de seis faces ser um número maior que 4 e apresentou 4/6 como resposta';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo PerguntaAnoEscolar e PerguntaResposta - 9º Ano

--> Questão 1: 
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId")
values (uuid_generate_v4()::text,'Conjuntos numéricos: operações e resolução de problemas','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 9, 1, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 9 and "Ordenacao" = 1)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante determinou o valor de duas camisetas, por meio de desenho, esquemas ou tentativa e erro), mas não encontrou o valor de 4 camisetas';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante determinou o valor de duas camisetas, por meio do cálculo mental ou das operações ou da álgebra, mas não encontrou o valor das 4 camisetas';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu o enunciado do problema, realizando operações aleatórias com os números do texto';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 2: 
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId")
values (uuid_generate_v4()::text,'Conjuntos numéricos: operações e resolução de problemas','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 9, 2, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 9 and "Ordenacao" = 2)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu o enunciado do problema e respondeu 2 como resposta, pois o cliente tem direito a dois pasteis de brinde';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante compreendeu o enunciado do problema, mas não apresentou todas as possibilidades possíveis';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu o enunciado do problema, realizando operações aleatórias com os números do texto';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 3: 
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId")
values (uuid_generate_v4()::text,'Porcentagem','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 9, 3, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 9 and "Ordenacao" = 3)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante compreendeu parcialmente o problema, pois realizou as duas porcentagens corretamente, mas ambas a partir de 2 000 reais';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante compreendeu o problema, mas errou os cálculos das duas porcentagens';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu o problema e determinou 30% do valor ou realizou operações aleatórias com os números do texto';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 4: 
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId")
values (uuid_generate_v4()::text,'Porcentagem','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 9, 4, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 9 and "Ordenacao" = 4)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante compreendeu parcialmente o problema, pois realizou as duas porcentagens corretamente, mas ambas a partir de 200 reais';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante compreendeu o problema, mas errou os cálculos das duas porcentagens';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu o problema e determinou 15% do valor, ou realizou operações aleatórias com os números do texto';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 5: 
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId")
values (uuid_generate_v4()::text,'transformações geométricas: translação, reflexão e rotação no plano','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 9, 5, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 9 and "Ordenacao" = 5)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante indicou apenas o eixo de simetria horizontal';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante indicou apenas o eixo de simetria vertical';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante demonstrou que não sabe o que é um eixo de simetria';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 6: 
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId")
values (uuid_generate_v4()::text,'transformações geométricas: translação, reflexão e rotação no plano','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 9, 6, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 9 and "Ordenacao" = 6)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu o problema pois fez uma cópia da figura, desconsiderando a reflexão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante compreendeu parcialmenre o problema, pois desconsiderou as medidas dos lados e dos ângulos correspondentes na figura refletida, mas tentou manter a sua forma';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante demonstrou que não sabe o que representa a linha AB';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 7: 
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId")
values (uuid_generate_v4()::text,'Gráficos e tabelas: usos e elementos constitutivos','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 9, 7, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 9 and "Ordenacao" = 7)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu o problema, pois registrou que a largura da coluna mais alta deveria ser maior do que a largura da coluna mais baixa';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante compreendeu o problema parcialmente, mas registrou que o erro está, por exemplo, na reprentação dos números 50 000 e 75 000 no eixo vertical';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu o problema, pois discordou da questão e demonstrou que o gráfico está correto';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 8:
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId")
values (uuid_generate_v4()::text,'Gráficos e tabelas: usos e elementos constitutivos','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 9, 8, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 9 and "Ordenacao" = 8)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu o problema, pois registrou a empresa LATAM, ou as colunas TOTAL nos dois gráficos, ou a coluna TOTAL no gráfico de 2021';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante compreendeu parcialmente o problema, pois indicou a diferença entre as duas colunas TOTAL, mas não demonstrou a impossibilidade de atribuir um valor numérico a esta diferença';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu o problema e opera com os números que aparecem no texto (por exemplo: realizou a subtração 2021 - 2012)';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 9: 
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId")
values (uuid_generate_v4()::text,'Problemas envolvendo espaço amostral e probabilidade de ocorrência de eventos','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 9, 9, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 9 and "Ordenacao" = 9)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante não compreendeu o problema porque faz operações aleatórias com os números 3 e 7';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante compreendeu parcialmente o problem porque identificou todas as chances de sair soma 3 e todas as chances de sair soma 7, mas não calculou as probabilidades';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante demonstrou que não sabe o que é probabilidade';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--> Questão 10: 
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId")
values (uuid_generate_v4()::text,'Problemas envolvendo espaço amostral e probabilidade de ocorrência de eventos','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id", "PerguntaId", "AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 9, 10, '2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 9 and "Ordenacao" = 10)
returning "Id" into perguntaAnoEscolarId;

insert into public."PerguntaAnoEscolarBimestre" ("PerguntaAnoEscolarId", "Bimestre")
select perguntaAnoEscolarId, 4
where not exists (select "Id" from public."PerguntaAnoEscolarBimestre" where "PerguntaAnoEscolarId" = perguntaAnoEscolarId and "Bimestre" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante resolveu a questão corretamente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante compreendeu o problema, mas não determinou todas as sequências possíveis e não justificou porque acontecer três caras é menos provável';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante compreendeu o problema, determinou todas as sequências possíveis, mas não justificou porque acontecer três caras é menos provável';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'O estudante demonstrou que não sabe o que é uma sequência ou o significado de provável ou o significado de em qualquer ordem';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolveu a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

end $$;