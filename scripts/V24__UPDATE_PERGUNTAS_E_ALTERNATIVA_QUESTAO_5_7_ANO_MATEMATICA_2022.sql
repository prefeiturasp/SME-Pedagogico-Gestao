do $$
declare
perguntaId text;
respostaId text;

begin 
	
	-- Alteração de alternativa 2 da questão 2 do 7 ano
	select pae."PerguntaId" into perguntaId from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 7 and pae."Ordenacao" = 5 and pae."InicioVigencia" = '2022-01-01'; 
	select pr."RespostaId" into respostaId from "PerguntaResposta" pr where pr."PerguntaId" = perguntaId and pr."Ordenacao" = 2;
	
    update public."Resposta" 
	set "Descricao" = 'Identifica medidas de tempo, diferencia hora de minuto, mas não se ateve a informação que o intervalo é de 15 minutos ao invés de 10 minutos.'
	where "Id" = respostaId;

   	-- Alteração de perguntas
	
	-- 4 ano

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 4 and pae."Ordenacao" = 1 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 1: Problema do campo multiplicativo envolvendo o significado de configuração retangular' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 4 and pae."Ordenacao" = 2 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 2: Problema do campo multiplicativo envolvendo o significado de proporcionalidade' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 4 and pae."Ordenacao" = 3 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 3: Padrões em sequências figurais' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 4 and pae."Ordenacao" = 4 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 4: Padrões em sequências figurais' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 4 and pae."Ordenacao" = 5 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 5: Localização e movimentação espacial' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 4 and pae."Ordenacao" = 6 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 6: Localização e movimentação espacial' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 4 and pae."Ordenacao" = 7 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 7: Perímetro de figuras planas' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 4 and pae."Ordenacao" = 8 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 8: Perímetro de figuras planas' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 4 and pae."Ordenacao" = 9 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 9: Leitura e interpretação de gráficos' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 4 and pae."Ordenacao" = 10 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 10: Leitura e interpretação de gráficos' 
	where "Id" = perguntaId;

	-- 5 ano

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 5 and pae."Ordenacao" = 1 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 1: Problema do campo multiplicativo envolvendo o significado de configuração retangular' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 5 and pae."Ordenacao" = 2 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 2: Problema do campo multiplicativo envolvendo o significado de proporcionalidade' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 5 and pae."Ordenacao" = 3 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 3: Álgebra - propriedades da igualdade' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 5 and pae."Ordenacao" = 4 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 4: Álgebra - propriedades da igualdade' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 5 and pae."Ordenacao" = 5 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 5: Localização e movimentação espacial' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 5 and pae."Ordenacao" = 6 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 6: Localização e movimentação espacial' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 5 and pae."Ordenacao" = 7 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 7: Perímetro de figuras planas' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 5 and pae."Ordenacao" = 8 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 8: Perímetro de figuras planas' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 5 and pae."Ordenacao" = 9 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 9: Tabela simples e de dupla entrada, gráficos de colunas, de linhas, barras e pictóricos' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 5 and pae."Ordenacao" = 10 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 10: Tabela simples e de dupla entrada, gráficos de colunas, de linhas, barras e pictóricos' 
	where "Id" = perguntaId;

	-- 6 ano

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 6 and pae."Ordenacao" = 1 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 1: Números racionais: leitura, escrita, comparação, ordenação e representação na reta numerada; equivalência' 
	where "Id" = perguntaId;
	
	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 6 and pae."Ordenacao" = 2 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 2: Problemas envolvendo os significados dos campos aditivo e multiplicativo com números naturais e/ou racionais' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 6 and pae."Ordenacao" = 3 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 3: Relação de igualdade em diferentes sentenças matemáticas envolvendo adições ou subtrações' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 6 and pae."Ordenacao" = 4 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 4: Álgebra - propriedades da igualdade' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 6 and pae."Ordenacao" = 5 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 5: Localização e movimentação: representação, descrição e interpretação da localização e/ou movimentação de pontos no 1º quadrante do plano cartesiano' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 6 and pae."Ordenacao" = 6 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 6: Localização e movimentação: representação, descrição e interpretação da localização e/ou movimentação de pontos no 1º quadrante do plano cartesiano' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 6 and pae."Ordenacao" = 7 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 7: Área de retângulo' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 6 and pae."Ordenacao" = 8 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 8: Área de retângulo' 
	where "Id" = perguntaId;

    select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 6 and pae."Ordenacao" = 9 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 9: Problemas com dados representados em gráficos e/ou tabelas' 
	where "Id" = perguntaId;

    select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 6 and pae."Ordenacao" = 10 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 10: Problemas com dados representados em gráficos e/ou tabelas' 
	where "Id" = perguntaId;

    -- 7 ano

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 7 and pae."Ordenacao" = 1 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 1: Planejamento e realização de pesquisas' 
	where "Id" = perguntaId;
	
	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 7 and pae."Ordenacao" = 2 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 2: Planejamento e realização de pesquisas' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 7 and pae."Ordenacao" = 3 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 3: Sólidos: diferenças e similaridades' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 7 and pae."Ordenacao" = 4 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 4: Ângulos: representações, giros e medidas' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 7 and pae."Ordenacao" = 5 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 5: Medidas de tempo' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 7 and pae."Ordenacao" = 6 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 6: Perímetro e área de retângulos' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 7 and pae."Ordenacao" = 7 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 7: Propriedade da igualdade' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 7 and pae."Ordenacao" = 8 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 8: Propriedade da igualdade' 
	where "Id" = perguntaId;

    select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 7 and pae."Ordenacao" = 9 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 9: Números naturais e inteiros: significados, reta numerada e significado das operações' 
	where "Id" = perguntaId;

    select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 7 and pae."Ordenacao" = 10 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 10: Números naturais e inteiros: significados, reta numerada e significado das operações' 
	where "Id" = perguntaId;

    -- 8 ano

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 8 and pae."Ordenacao" = 1 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 1: Planejamento, execução e relatório de pesquisa' 
	where "Id" = perguntaId;
	
	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 8 and pae."Ordenacao" = 2 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 2: Planejamento, execução e relatório de pesquisa' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 8 and pae."Ordenacao" = 3 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 3: Poliedros e Medidas de comprimento, capacidade e volume' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 8 and pae."Ordenacao" = 4 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 4: Ângulos em polígonos' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 8 and pae."Ordenacao" = 5 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 5: Variação de grandezas: diretamente e inversamente proporcionais ou não proporcionais' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 8 and pae."Ordenacao" = 6 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 6: Variação de grandezas: diretamente e inversamente proporcionais ou não proporcionais' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 8 and pae."Ordenacao" = 7 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 7: Números racionais: comparação, ordenação e localização na reta numerada' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 8 and pae."Ordenacao" = 8 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 8: Procedimentos de cálculos, Problemas envolvendo o significado das operações' 
	where "Id" = perguntaId;

    select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 8 and pae."Ordenacao" = 9 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 9: Cálculo de área' 
	where "Id" = perguntaId;

    select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 8 and pae."Ordenacao" = 10 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 10: Cálculo de volume' 
	where "Id" = perguntaId;

    -- 9 ano

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 9 and pae."Ordenacao" = 1 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 1: Medidas de tendência central' 
	where "Id" = perguntaId;
	
	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 9 and pae."Ordenacao" = 2 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 2: Planejamento, execução e relatório de pesquisa' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 9 and pae."Ordenacao" = 3 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 3: Medidas de comprimento e volume' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 9 and pae."Ordenacao" = 4 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 4: Ângulos em polígonos' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 9 and pae."Ordenacao" = 5 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 5: Relações entre grandezas: diretamente, inversamente ou não proporcionais' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 9 and pae."Ordenacao" = 6 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 6: Relações entre grandezas: diretamente, inversamente ou não proporcionais' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 9 and pae."Ordenacao" = 7 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 7: Área de figuras planas e expressões algébricas' 
	where "Id" = perguntaId;

	select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 9 and pae."Ordenacao" = 8 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 8: Medidas de comprimento e Área' 
	where "Id" = perguntaId;

    select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 9 and pae."Ordenacao" = 9 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 9: Problemas com números reais, porcentagens sucessivas, taxas percentuais e juros simples' 
	where "Id" = perguntaId;

    select pae."PerguntaId" into perguntaid from "PerguntaAnoEscolar" pae where pae."AnoEscolar" = 9 and pae."Ordenacao" = 10 and pae."InicioVigencia" = '2022-01-01';	
	update "Pergunta" set "Descricao" = 'Questão 10: Problemas com números reais, porcentagens sucessivas, taxas percentuais e juros simples' 
	where "Id" = perguntaId;
end $$;