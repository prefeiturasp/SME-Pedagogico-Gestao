CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo respostas
insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Acerta o resultado utilizando estratégias convencionais/ cálculo mental.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Acerta o resultado utilizando estratégias convencionais/ cálculo mental.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Acerta o resultado utilizando estratégias não convencionais e/ou outras estratégias.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Acerta o resultado utilizando estratégias não convencionais e/ou outras estratégias.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende a ideia, mas erra o resultado.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende a ideia, mas erra o resultado.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não compreende a ideia da situação-problema.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não compreende a ideia da situação-problema.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não resolve a questão.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não resolve a questão.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Estudante ausente.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Estudante ausente.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende a ideia de regularidade e acerta a sequência.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende a ideia de regularidade e acerta a sequência.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende a ideia de regularidade, mas erra a sequência.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende a ideia de regularidade, mas erra a sequência.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Copia segmento(s) da sequência existente na situação-problema.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Copia segmento(s) da sequência existente na situação-problema.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não compreende a ideia de regularidade.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não compreende a ideia de regularidade.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende a ideia de localização e movimentação.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende a ideia de localização e movimentação.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende a ideia de localização, mas erra os comandos, confundindo direita com esquerda, e vice-versa.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende a ideia de localização, mas erra os comandos, confundindo direita com esquerda, e vice-versa.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende a ideia de movimentação, mas não se atenta às especificidades da solicitação.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende a ideia de movimentação, mas não se atenta às especificidades da solicitação.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não compreende a ideia de localização e movimentação.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não compreende a ideia de localização e movimentação.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende a ideia de movimentação, mas não utiliza linguagem convencional.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende a ideia de movimentação, mas não utiliza linguagem convencional.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende a ideia de perímetro e acerta o resultado.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende a ideia de perímetro e acerta o resultado.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreendeu a ideia de perímetro, mas erra o resultado.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreendeu a ideia de perímetro, mas erra o resultado.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Indica apenas a soma entre a medida da largura e do comprimento.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Indica apenas a soma entre a medida da largura e do comprimento.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não compreende a ideia.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não compreende a ideia.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Realiza a leitura de dados explícitos e implícitos.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Realiza a leitura de dados explícitos e implícitos.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Realiza a leitura de dados explícitos e compreende a ideia de dados implícitos, mas não o identifica corretamente.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Realiza a leitura de dados explícitos e compreende a ideia de dados implícitos, mas não o identifica corretamente.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Realiza somente a leitura de dados explícitos.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Realiza somente a leitura de dados explícitos.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não realiza a leitura de dados explícitos no gráfico.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não realiza a leitura de dados explícitos no gráfico.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende a ideia, explicitando adequadamente na tabela os dados do gráfico.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende a ideia, explicitando adequadamente na tabela os dados do gráfico.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreendeu a ideia, mas inverte a correlação dos dados linha/coluna.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreendeu a ideia, mas inverte a correlação dos dados linha/coluna.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não correlaciona corretamente os dados de linha e coluna.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não correlaciona corretamente os dados de linha e coluna.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende a ideia de igualdade e acerta o resultado.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende a ideia de igualdade e acerta o resultado.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende a ideia de igualdade, mas erra o resultado.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende a ideia de igualdade, mas erra o resultado.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Copia dado(s) existentes na situação-problema.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Copia dado(s) existentes na situação-problema.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Realiza uma operação aleatória com os dados apresentados pelo problema que não conduz à resposta correta.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Realiza uma operação aleatória com os dados apresentados pelo problema que não conduz à resposta correta.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende a ideia de localização, mas não compreende os comandos para a movimentação.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende a ideia de localização, mas não compreende os comandos para a movimentação.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende a ideia de perímetro.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende a ideia de perímetro.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende a ideia, mas erra o cálculo.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende a ideia, mas erra o cálculo.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Opera apenas com os valores apresentados na questão.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Opera apenas com os valores apresentados na questão.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Realiza a leitura de dados explícitos, compreende a ideia de dado implícito, mas não o identifica corretamente.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Realiza a leitura de dados explícitos, compreende a ideia de dado implícito, mas não o identifica corretamente.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Realiza somente a leitura de dados explícitos no gráfico.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Realiza somente a leitura de dados explícitos no gráfico.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não realiza a leitura de dados explícitos em gráficos.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não realiza a leitura de dados explícitos em gráficos.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende a ideia, explicitando adequadamente os dados do gráfico na tabela.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende a ideia, explicitando adequadamente os dados do gráfico na tabela.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende a ideia, mas inverte a correlação dos dados linha/coluna.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende a ideia, mas inverte a correlação dos dados linha/coluna.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não correlaciona corretamente os dados de linha e coluna.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não correlaciona corretamente os dados de linha e coluna.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compara e/ou ordena números racionais na representação decimal.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compara e/ou ordena números racionais na representação decimal.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Faz a leitura de números racionais como se fossem números naturais, colocando em ordem decrescente.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Faz a leitura de números racionais como se fossem números naturais, colocando em ordem decrescente.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Faz a leitura de números racionais como se fossem números naturais, colocando em ordem crescente.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Faz a leitura de números racionais como se fossem números naturais, colocando em ordem crescente.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não compara e/ou ordena números racionais na representação decimal.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não compara e/ou ordena números racionais na representação decimal.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende a ideia e acerta o resultado utilizando estratégias não convencionais e/ou outras estratégias.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende a ideia e acerta o resultado utilizando estratégias não convencionais e/ou outras estratégias.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende que o número racional apresentado representa uma parte de um todo, mas não encontra o valor correto.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende que o número racional apresentado representa uma parte de um todo, mas não encontra o valor correto.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não compreende que o número racional apresentado representa uma parte de um todo.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não compreende que o número racional apresentado representa uma parte de um todo.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende a ideia e acerta o resultado.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende a ideia e acerta o resultado.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende parcialmente a ideia: acerta parte do(s) resultado(s).' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende parcialmente a ideia: acerta parte do(s) resultado(s).');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreenda a ideia mas erra o resultado.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreenda a ideia mas erra o resultado.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende a ideia de plano cartesiano e acerta as coordenadas.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende a ideia de plano cartesiano e acerta as coordenadas.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende parcialmente a ideia: acerta parte da(s) coordenada(s).' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende parcialmente a ideia: acerta parte da(s) da(s) coordenada(s).');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende parcialmente a ideia: inverte a localização nos eixos.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende parcialmente a ideia: inverte a localização nos eixos.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende a ideia de área.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende a ideia de área.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Realiza uma operação inadequada com os valores apresentados na situação-problema.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Realiza uma operação inadequada com os valores apresentados na situação-problema.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Realiza a leitura de dados explícitos e compreende a ideia de dado implícito, mas não o identifica corretamente.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Realiza a leitura de dados explícitos e compreende a ideia de dado implícito, mas não o identifica corretamente.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Representa corretamente no gráfico os dados representados na tabela.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Representa corretamente no gráfico os dados representados na tabela.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Representa parcialmente no gráfico os dados representados na tabela.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Representa parcialmente no gráfico os dados representados na tabela.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não considera as características de um gráfico de colunas.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não considera as características de um gráfico de colunas.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não representa os dados corretamente e desconsidera as características de um gráfico de colunas.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não representa os dados corretamente e desconsidera as características de um gráfico de colunas.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Regista “Não conheço” em todas as opções.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Regista “Não conheço” em todas as opções.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Regista “Conheço um pouco” em todas as opções.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Regista “Conheço um pouco” em todas as opções.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Registra em parte das opções: “Não conheço”, “Conheço um pouco” e “Conheço”.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Registra em parte das opções: “Não conheço”, “Conheço um pouco” e “Conheço”.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Registra “Conheço” em todas as opções.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Registra “Conheço” em todas as opções.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não identifica o tema e a importância do título e da fonte, nem calcula corretamente o valor da renda familiar per capita (em reais) e o número de pessoas na família.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não identifica o tema e a importância do título e da fonte, nem calcula corretamente o valor da renda familiar per capita (em reais) e o número de pessoas na família.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não identifica o tema e a importância do título e da fonte, mas calcula corretamente o valor da renda familiar per capita (em reais) ou o número de pessoas na família.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não identifica o tema e a importância do título e da fonte, mas calcula corretamente o valor da renda familiar per capita (em reais) ou o número de pessoas na família.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Identifica a tema e a importância do título e da fonte, mas calcula incorretamente o valor da renda familiar per capita (em reais) ou o número de pessoas na família.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Identifica a tema e a importância do título e da fonte, mas calcula incorretamente o valor da renda familiar per capita (em reais) ou o número de pessoas na família.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Identifica o tema e a importância do título e da fonte e calcula corretamente o valor da renda familiar per capita (em reais) e o número de pessoas na família.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Identifica o tema e a importância do título e da fonte e calcula corretamente o valor da renda familiar per capita (em reais) e o número de pessoas na família.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Confunde sólidos com figuras planas.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Confunde sólidos com figuras planas.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Reconhece alguns sólidos geométricos, entre os apresentados.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Reconhece alguns sólidos geométricos, entre os apresentados.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Reconhece a maioria dos sólidos geométricos apresentados.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Reconhece a maioria dos sólidos geométricos apresentados.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Reconhece todos os sólidos geométricos apresentados.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Reconhece todos os sólidos geométricos apresentados.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não consegue identificar os ângulos de 180° e 360° nas representações.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não consegue identificar os ângulos de 180° e 360° nas representações.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Reconhece somente o ângulo de 180° nas representações.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Reconhece somente o ângulo de 180° nas representações.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Reconhece somente o ângulo de 360° nas representações.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Reconhece somente o ângulo de 360° nas representações.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Reconhece os ângulos de 180° e 360° nas representações.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Reconhece os ângulos de 180° e 360° nas representações.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não identifica medidas de tempo e não realiza conversões.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não identifica medidas de tempo e não realiza conversões.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Identifica medidas de tempo, diferencia hora de minuto, mão não se ateve a informação que o intervalo é de 15 minutos ao invés de 10 minutos.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Identifica medidas de tempo, diferencia hora de minuto, mão não se ateve a informação que o intervalo é de 15 minutos ao invés de 10 minutos.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Identifica medidas de tempo, diferencia hora de minuto, mas não se ateve a informação que a aula começa 5 minutos depois da entrada.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Identifica medidas de tempo, diferencia hora de minuto, mas não se ateve a informação que a aula começa 5 minutos depois da entrada.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Identifica medidas de tempo e realiza conversões corretamente.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Identifica medidas de tempo e realiza conversões corretamente.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não reconhece o significado de perímetro e nem de área.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não reconhece o significado de perímetro e nem de área.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Calcula somente o perímetro.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Calcula somente o perímetro.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Calcula somente a área.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Calcula somente a área.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Calcula o perímetro e a área.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Calcula o perímetro e a área.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Indica o valor incorreto da massa de cada bola de tênis e o registro de como pensou também está equivocado.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Indica o valor incorreto da massa de cada bola de tênis e o registro de como pensou também está equivocado.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Indica o valor incorreto da massa de cada bola de tênis, mas o registro de como pensou está correto.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Indica o valor incorreto da massa de cada bola de tênis, mas o registro de como pensou está correto.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Indica o valor correto da massa de cada bola de tênis, mas não demonstra como encontrou a resposta.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Indica o valor correto da massa de cada bola de tênis, mas não demonstra como encontrou a resposta.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Indica o valor correto da massa de cada bola de tênis e demonstra corretamente como encontrou a resposta.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Indica o valor correto da massa de cada bola de tênis e demonstra corretamente como encontrou a resposta.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não interpreta as escritas algébricas correspondentes e erra a idade.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não interpreta as escritas algébricas correspondentes e erra a idade.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Interpreta as escritas algébricas correspondentes, mas erra a idade.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Interpreta as escritas algébricas correspondentes, mas erra a idade.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não consegue interpretar as escritas algébricas, mas acerta a idade.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não consegue interpretar as escritas algébricas, mas acerta a idade.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Reconhece as escritas algébricas correspondentes e acerta a idade.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Reconhece as escritas algébricas correspondentes e acerta a idade.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não compreende a ideia do problema, conceito de reta numerada e não consegue esboçar uma tentativa de resolução, ainda que incorreta.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não compreende a ideia do problema, conceito de reta numerada e não consegue esboçar uma tentativa de resolução, ainda que incorreta.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Calcula incorretamente a diferença entre as temperaturas, mas representa corretamente no termômetro.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Calcula incorretamente a diferença entre as temperaturas, mas representa corretamente no termômetro.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Calcula corretamente a diferença entre as temperaturas, mas representa incorretamente no termômetro.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Calcula corretamente a diferença entre as temperaturas, mas representa incorretamente no termômetro.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende os conceitos envolvidos (localização de número na reta numerada e diferença entre inteiros).' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende os conceitos envolvidos (localização de número na reta numerada e diferença entre inteiros).');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não compreende a ideia do problema e erra a resposta.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não compreende a ideia do problema e erra a resposta.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende a ideia do problema, mas erra a resposta.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende a ideia do problema, mas erra a resposta.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não compreende a ideia do problema, mas acerta a resposta.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não compreende a ideia do problema, mas acerta a resposta.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende os conceitos envolvidos e acerta a resposta.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende os conceitos envolvidos e acerta a resposta.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não conhece as terminologias envolvendo uma pesquisa que apareceram na questão.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não conhece as terminologias envolvendo uma pesquisa que apareceram na questão.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Conhece algumas terminologias que apareceram na questão.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Conhece algumas terminologias que apareceram na questão.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Conhece todas as terminologias que apareceram na questão.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Conhece todas as terminologias que apareceram na questão.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não identifica os dados apresentados e nem calcula o valor da renda familiar per capita.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não identifica os dados apresentados e nem calcula o valor da renda familiar per capita.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Determina o número de familiares a partir das demais informações (Família B).' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Determina o número de familiares a partir das demais informações (Família B).');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Determina a renda per capita a partir das demais informações (Família C).' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Determina a renda per capita a partir das demais informações (Família C).');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Determina o número de familiares e a renda per capita (Famílias B e C).' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Determina o número de familiares e a renda per capita (Famílias B e C).');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não compreende o conceito das dimensões e erra o volume e a capacidade.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não compreende o conceito das dimensões e erra o volume e a capacidade.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Identifica todas as dimensões, mas erra o volume (item I)' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Identifica todas as dimensões, mas erra o volume (item I)');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Identifica todas as dimensões, mas erra a capacidade (item II)' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Identifica todas as dimensões, mas erra a capacidade (item II)');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Identifica todas as dimensões e acerta o volume e a capacidade.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Identifica todas as dimensões e acerta o volume e a capacidade.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não reconhece os tipos de ângulos no triângulo.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não reconhece os tipos de ângulos no triângulo.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Reconhece somente um dos tipos de ângulo (reto, agudo ou obtuso).' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Reconhece somente um dos tipos de ângulo (reto, agudo ou obtuso).');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Reconhece dois ou três tipos de ângulo (reto, agudo ou obtuso).' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Reconhece dois ou três tipos de ângulo (reto, agudo ou obtuso).');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Reconhece os tipos de ângulo (reto, agudo ou obtuso) e identifica os triângulos segundo as medidas dos ângulos.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Reconhece os tipos de ângulo (reto, agudo ou obtuso) e identifica os triângulos segundo as medidas dos ângulos.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Interpreta a variação como diretamente proporcional e resolve por meio de desenhos, esquemas ou operações aritméticas.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Interpreta a variação como diretamente proporcional e resolve por meio de desenhos, esquemas ou operações aritméticas.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Interpreta a variação como diretamente proporcional e resolve por meio de expressões algébricas.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Interpreta a variação como diretamente proporcional e resolve por meio de expressões algébricas.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Identifica a variação inversamente proporcional e resolve por meio de desenhos, esquemas ou operações aritméticas.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Identifica a variação inversamente proporcional e resolve por meio de desenhos, esquemas ou operações aritméticas.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Identifica a variação inversamente proporcional e resolve por meio de expressões algébricas.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Identifica a variação inversamente proporcional e resolve por meio de expressões algébricas.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não organiza os dados do problema para calcular o valor do capital inicial.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não organiza os dados do problema para calcular o valor do capital inicial.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Interpreta as informações, mas erra o valor do capital inicial.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Interpreta as informações, mas erra o valor do capital inicial.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Informa o valor do capital inicial corretamente, mas não registra como pensou.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Informa o valor do capital inicial corretamente, mas não registra como pensou.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Organiza os dados do problema e acerta o valor do capital inicial.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Organiza os dados do problema e acerta o valor do capital inicial.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não consegue interpretar os dados do problema para chegar à resposta.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não consegue interpretar os dados do problema para chegar à resposta.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Utiliza os dados do problema, mas erra a localização dos números racionais na reta numerada.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Utiliza os dados do problema, mas erra a localização dos números racionais na reta numerada.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Determina somente a distância entre as casas de Maria e Rita.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Determina somente a distância entre as casas de Maria e Rita.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Resolve o problema corretamente (itens a, b e c).' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Resolve o problema corretamente (itens a, b e c).');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Utiliza os dados do problema para realizar operações que não conduzem às respostas.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Utiliza os dados do problema para realizar operações que não conduzem às respostas.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Resolve corretamente um dos itens e erra os demais.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Resolve corretamente um dos itens e erra os demais.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Resolve corretamente os itens I e II, mas não compara duas informações distintas (item III).' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Resolve corretamente os itens I e II, mas não compara duas informações distintas (item III).');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Resolve corretamente todos os itens do problema.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Resolve corretamente todos os itens do problema.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não reconhece as dimensões da base do tanque e erra a sua área.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não reconhece as dimensões da base do tanque e erra a sua área.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não reconhece as dimensões da base do tanque, mas acerta a da superfície.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não reconhece as dimensões da base do tanque, mas acerta a da superfície.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Reconhece as dimensões da base do tanque, mas erra a sua área.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Reconhece as dimensões da base do tanque, mas erra a sua área.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Determina a base do tanque corretamente.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Determina a base do tanque corretamente.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não reconhece as dimensões do tanque necessárias para o cálculo do seu volume.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não reconhece as dimensões do tanque necessárias para o cálculo do seu volume.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Reconhece as dimensões do tanque, mas realiza operações aleatórias que não determinam o seu volume.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Reconhece as dimensões do tanque, mas realiza operações aleatórias que não determinam o seu volume.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Reconhece as dimensões do tanque, mas erra o produto entre os 3 valores.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Reconhece as dimensões do tanque, mas erra o produto entre os 3 valores.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Determina o volume do tanque corretamente.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Determina o volume do tanque corretamente.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Desconhece termos do problema e não organiza as informações para chegar à resposta.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Desconhece termos do problema e não organiza as informações para chegar à resposta.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Organiza as informações apresentadas no problema, mas erra a resposta.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Organiza as informações apresentadas no problema, mas erra a resposta.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Determina o salário médio, mas não registra se este valor representa, ou não, todos os salários da empresa.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Determina o salário médio, mas não registra se este valor representa, ou não, todos os salários da empresa.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Resolve o problema corretamente.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Resolve o problema corretamente.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Calcula o valor da renda familiar per capita, mas não calcula o número de pessoas da família.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Calcula o valor da renda familiar per capita, mas não calcula o número de pessoas da família.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não calcula o valor da renda familiar per capita, mas calcula o número de pessoas da família.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não calcula o valor da renda familiar per capita, mas calcula o número de pessoas da família.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não compreende o enunciado, realizando registros desconectados com o texto.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não compreende o enunciado, realizando registros desconectados com o texto.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende o enunciado, mas erra o volume de um paralelepípedo.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende o enunciado, mas erra o volume de um paralelepípedo.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Calcula corretamente o volume de uma peça, mas erra o volume da montagem.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Calcula corretamente o volume de uma peça, mas erra o volume da montagem.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não determina as medidas dos ângulos e não classifica a figura corretamente.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não determina as medidas dos ângulos e não classifica a figura corretamente.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Classifica a figura corretamente, mas erra as medidas dos ângulos.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Classifica a figura corretamente, mas erra as medidas dos ângulos.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não classifica a figura corretamente, mas acerta as medidas dos ângulos.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não classifica a figura corretamente, mas acerta as medidas dos ângulos.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Resolve o problema.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Resolve o problema.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não estabelece relações entre as grandezas.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não estabelece relações entre as grandezas.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Responde corretamente somente uma questão, por meio de operações aritméticas (cálculo escrito ou mental).' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Responde corretamente somente uma questão, por meio de operações aritméticas (cálculo escrito ou mental).');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Responde corretamente as duas questões, por meio de operações aritméticas (cálculo escrito ou mental).' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Responde corretamente as duas questões, por meio de operações aritméticas (cálculo escrito ou mental).');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Responde corretamente as duas questões, por meio de equacionamento (regra de três).' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Responde corretamente as duas questões, por meio de equacionamento (regra de três).');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não interpreta o problema e erra todas as respostas.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não interpreta o problema e erra todas as respostas.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Determina corretamente somente a medida do lado da sala de leitura.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Determina corretamente somente a medida do lado da sala de leitura.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Determina corretamente somente a medida do lado da sala de leitura e do comprimento do ambiente da escola.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Determina corretamente somente a medida do lado da sala de leitura e do comprimento do ambiente da escola.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Resolve todas as questões corretamente.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Resolve todas as questões corretamente.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não interpreta o texto, pois faz registros desconectados do problema.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não interpreta o texto, pois faz registros desconectados do problema.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Erra a área do quadrado e determina área de um triângulo coerente a partir desse valor.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Erra a área do quadrado e determina área de um triângulo coerente a partir desse valor.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Calcula corretamente a área de um quadrado, mas não calcula a área de um triângulo.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Calcula corretamente a área de um quadrado, mas não calcula a área de um triângulo.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Não compreende a ideia da situação-problema envolvendo porcentagens.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Não compreende a ideia da situação-problema envolvendo porcentagens.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Compreende a ideia envolvendo porcentagem, mas erra os resultados.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Compreende a ideia envolvendo porcentagem, mas erra os resultados.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Resolve corretamente o item a, mas erra o item b, ou vice-versa.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Resolve corretamente o item a, mas erra o item b, ou vice-versa.');

insert into public."Resposta" ("Id", "Descricao")  
select uuid_generate_v4()::text,'Resolve corretamente o item I, mas erra o item b, ou vice-versa.' 
where not exists (select 1 from public."Resposta" where "Descricao" = 'Resolve corretamente o item I, mas erra o item b, ou vice-versa.');

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo Pergunta, PerguntaAnoEscolar e PerguntaResposta - 4º Ano - Ordem 1

do $$
declare 
	respostaId text;
	perguntaId text;
begin
	
insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Problema do campo multiplicativo envolvendo o significado de configuração retangular','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4,1,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acerta o resultado utilizando estratégias convencionais/ cálculo mental.';	
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acerta o resultado utilizando estratégias não convencionais e/ou outras estratégias.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia, mas erra o resultado';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreende a ideia da situação-problema';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolve a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo Pergunta, PerguntaAnoEscolar e PerguntaResposta - 4º Ano - Ordem 2

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Problema do campo multiplicativo envolvendo o significado de proporcionalidade','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4,2,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acerta o resultado utilizando estratégias convencionais/ cálculo mental.';	
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acerta o resultado utilizando estratégias não convencionais e/ou outras estratégias.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia, mas erra o resultado';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreende a ideia da situação-problema';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolve a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);
	
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo Pergunta, PerguntaAnoEscolar e PerguntaResposta - 4º Ano - Ordem 3

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Padrões em sequências figurais','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4,3,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia de regularidade e acerta a sequência.';	
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia de regularidade, mas erra a sequência.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Copia segmento(s) da sequência existente na situação-problema.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreende a ideia de regularidade.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolve a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo Pergunta, PerguntaAnoEscolar e PerguntaResposta - 4º Ano - Ordem 4

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Padrões em sequências figurais','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4,4,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia de regularidade e acerta a sequência.';	
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia de regularidade, mas erra a sequência.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Copia segmento(s) da sequência existente na situação-problema.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreende a ideia de regularidade.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolve a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo Pergunta, PerguntaAnoEscolar e PerguntaResposta - 4º Ano - Ordem 5

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Localização e movimentação espacial','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4,5,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia de localização e movimentação.';	
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia de localização, mas erra os comandos, confundindo direita com esquerda, e vice-versa.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia de movimentação, mas não se atenta às especificidades da solicitação.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreende a ideia de localização e movimentação.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolve a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo Pergunta, PerguntaAnoEscolar e PerguntaResposta - 4º Ano - Ordem 6

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Localização e movimentação espacial','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4,6,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 6);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia de localização e movimentação.';	
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia de localização, mas erra os comandos, confundindo direita com esquerda, e vice-versa.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia de movimentação, mas não utiliza linguagem convencional.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreende a ideia de localização e movimentação.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolve a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);


--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo Pergunta, PerguntaAnoEscolar e PerguntaResposta - 4º Ano - Ordem 7

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Perímetro de figuras planas','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4,7,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 7);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia de perímetro e acerta o resultado.';	
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de perímetro, mas erra o resultado.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Indica apenas a soma entre a medida da largura e do comprimento.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreende a ideia.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolve a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);


--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo Pergunta, PerguntaAnoEscolar e PerguntaResposta - 4º Ano - Ordem 8

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Perímetro de figuras planas','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4,8,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 8);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia de perímetro e acerta o resultado.';	
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia de perímetro, mas erra o resultado.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Indica apenas a soma entre a medida da largura e do comprimento.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreende a ideia.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolve a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo Pergunta, PerguntaAnoEscolar e PerguntaResposta - 4º Ano - Ordem 9

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Leitura e interpretação de gráficos','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4,9,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 9);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Realiza a leitura de dados explícitos e implícitos.';	
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Realiza a leitura de dados explícitos e compreende a ideia de dados implícitos, mas não o identifica corretamente.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Realiza somente a leitura de dados explícitos.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não realiza a leitura de dados explícitos no gráfico.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolve a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo Pergunta, PerguntaAnoEscolar e PerguntaResposta - 4º Ano - Ordem 10

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Leitura e interpretação de gráficos','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 4,10,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 4 and "Ordenacao" = 10);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia, explicitando adequadamente na tabela os dados do gráfico.';	
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreendeu a ideia, mas inverte a correlação dos dados linha/coluna.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não correlaciona corretamente os dados de linha e coluna.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não realiza a leitura de dados explícitos no gráfico.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolve a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo Pergunta, PerguntaAnoEscolar e PerguntaResposta - 5º Ano - Ordem 1

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Problema do campo multiplicativo envolvendo o significado de configuração retangular','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5,1,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acerta o resultado utilizando estratégias convencionais/ cálculo mental.';	
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acerta o resultado utilizando estratégias não convencionais e/ou outras estratégias.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia, mas erra o resultado.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreende a ideia da situação-problema.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolve a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo Pergunta, PerguntaAnoEscolar e PerguntaResposta - 5º Ano - Ordem 2

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Problema do campo multiplicativo envolvendo o significado de proporcionalidade','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5,2,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acerta o resultado utilizando estratégias convencionais/ cálculo mental.';	
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Acerta o resultado utilizando estratégias não convencionais e/ou outras estratégias.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia, mas erra o resultado.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreende a ideia da situação-problema.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolve a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo Pergunta, PerguntaAnoEscolar e PerguntaResposta - 5º Ano - Ordem 3

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Álgebra - propriedades da igualdade','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5,3,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia de igualdade e acerta o resultado.';	
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia de igualdade, mas erra o resultado.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Copia dado(s) existentes na situação-problema.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Realiza uma operação aleatória com os dados apresentados pelo problema que não conduz à resposta correta.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolve a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo Pergunta, PerguntaAnoEscolar e PerguntaResposta - 5º Ano - Ordem 4

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Álgebra - propriedades da igualdade','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5,4,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia de igualdade e acerta o resultado.';	
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia de igualdade, mas erra o resultado.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Copia dado(s) existentes na situação-problema.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Realiza uma operação aleatória com os dados apresentados pelo problema que não conduz à resposta correta.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolve a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo Pergunta, PerguntaAnoEscolar e PerguntaResposta - 5º Ano - Ordem 5

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Localização e movimentação espacial','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5,5,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia de localização e movimentação.';	
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia de localização, mas erra os comandos, confundindo direita com esquerda, e vice-versa.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia de movimentação, mas não utiliza linguagem convencional.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreende a ideia de localização e movimentação.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolve a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo Pergunta, PerguntaAnoEscolar e PerguntaResposta - 5º Ano - Ordem 6

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Localização e movimentação espacial','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5,6,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 6);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia de localização e movimentação.';	
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia de localização, mas não compreende os comandos para a movimentação.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia de movimentação, mas não se atenta às especificidades da solicitação.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreende a ideia de localização e movimentação.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolve a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo Pergunta, PerguntaAnoEscolar e PerguntaResposta - 5º Ano - Ordem 7

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Perímetro de figuras planas','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5,7,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 7);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia de perímetro.';	
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia, mas erra o cálculo.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Opera apenas com os valores apresentados na questão.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreende a ideia.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolve a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo Pergunta, PerguntaAnoEscolar e PerguntaResposta - 5º Ano - Ordem 8

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Perímetro de figuras planas','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5,8,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 8);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia de perímetro.';	
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia, mas erra o cálculo.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Opera apenas com os valores apresentados na questão.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não compreende a ideia.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolve a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo Pergunta, PerguntaAnoEscolar e PerguntaResposta - 5º Ano - Ordem 9

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Tabela simples e de dupla entrada, gráficos de colunas, de linhas, barras e pictóricos','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5,9,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 9);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Realiza a leitura de dados explícitos e implícitos.';	
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Realiza a leitura de dados explícitos, compreende a ideia de dado implícito, mas não o identifica corretamente.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Realiza somente a leitura de dados explícitos no gráfico.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não realiza a leitura de dados explícitos em gráficos.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolve a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--> Inserindo Pergunta, PerguntaAnoEscolar e PerguntaResposta - 5º Ano - Ordem 10

insert into public."Pergunta" ("Id", "Descricao","ComponenteCurricularId") 
values (uuid_generate_v4()::text,'Tabela simples e de dupla entrada, gráficos de colunas, de linhas, barras e pictóricos','9f3d8467-2f6e-4bcb-a8e9-12e840426aba')
returning "Id" into perguntaId;

insert into public."PerguntaAnoEscolar" ("Id","PerguntaId","AnoEscolar", "Ordenacao", "InicioVigencia")
select uuid_generate_v4()::text, perguntaId, 5,10,'2022-01-01'
where not exists (select "Id" from public."PerguntaAnoEscolar" where "PerguntaId" = perguntaId and "AnoEscolar" = 5 and "Ordenacao" = 10);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia, explicitando adequadamente os dados do gráfico na tabela.';	
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 1);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Compreende a ideia, mas inverte a correlação dos dados linha/coluna.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 2);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não correlaciona corretamente os dados de linha e coluna.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 3);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não realiza a leitura de dados explícitos no gráfico.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 4);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Não resolve a questão';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 5);

select p."Id" into respostaId from public."Resposta" p where p."Descricao" = 'Estudante ausente.';
insert into public."PerguntaResposta" ("Id", "PerguntaId", "RespostaId", "Ordenacao")
values (uuid_generate_v4()::text, perguntaId, respostaId, 6);



end $$;