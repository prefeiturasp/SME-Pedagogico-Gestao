import React from "react";

import PollReportBreadcrumb from "../PollReportBreadcrumb";
import RelatorioMatematicaConsolidado from "../RelatorioMatematicaConsolidado";
import RelatorioMatematicaConsolidadoCACM from "../RelatorioMatematicaConsolidadoCACM";
import GraficoConsolidadoMatematica from "../GraficoConsolidadoMatematica/GraficoConsolidadoMatematica";
import GraficoMatematicaCACM from "../GraficoMatematicaCACM/GraficoMatematicaCACM";
import RelatorioMatematicaPorTurma from "../RelatorioMatematicaPorTurma/RelatorioMatematicaPorTurma";
import RelatorioMatematicaPorTurmaCACM from "../RelatorioMatematicaPorTurma/RelatorioMatematicaPorTurmaCACM";

export const novaRenderizacaoComponente = (props) => {
  const { data, selectedFilter } = props.pollReport;
  const { CodigoCurso, proficiency } = selectedFilter;

  const ehAlfabetizacaoCACM = CodigoCurso < 4 && proficiency !== "Números";
  const ehAlfabetizacaoNumero = CodigoCurso < 4 && proficiency === "Números";
  const ehRelatorioPorTurma = props.pollReport.selectedFilter.classroomReport;

  const dataMocado = JSON.parse(
    '{"perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","nome":"Números naturais e inteiros: significados, reta numerada e significado das operações"},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","nome":"Área e perímetro "},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","nome":"Sólidos geométricos"},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","nome":"Relações entre grandezas e porcentagem"},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","nome":"Média, moda e mediana"}],"alunos":[{"codigoAluno":5044680,"nomeAluno":"AGATA IASMIN ESTEVAO AMORIM","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":4973946,"nomeAluno":"ALAN FELIPE GARCIA LIMA","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":6119952,"nomeAluno":"ARTHUR AUGUSTO DE SANTANA","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":5785230,"nomeAluno":"BIANCA MANTOVANI BARBOSA","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":4911054,"nomeAluno":"BRUNA ALMEIDA DA SILVA VIEIRA","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":6023154,"nomeAluno":"ELTON ANTONIO DE OLIVEIRA CHAVES","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":5706416,"nomeAluno":"FABRICIO DO NASCIMENTO NUNES","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":5820282,"nomeAluno":"GABRIEL HENRIQUE FLAUZINO REIS","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":5201648,"nomeAluno":"GUSTAVO DOS SANTOS OLIVEIRA","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":5313584,"nomeAluno":"JOAO RICARDO SILVA SANTOS","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":5179410,"nomeAluno":"JUAN CARDOSO DOS SANTOS","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":5597490,"nomeAluno":"KAMILLA MOREIRA DOS SANTOS","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":6024616,"nomeAluno":"KAMILLY LOPES DA SILVA","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":5786367,"nomeAluno":"KAUA DE SOUSA MONTE","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":5180528,"nomeAluno":"LEUAN MARQUES DE SOUSA","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":6309967,"nomeAluno":"LOUISE MENDES DUARTE DA SILVA","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":7557222,"nomeAluno":"MARCELA APARECIDA SANTOS DA SILVA","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":4948331,"nomeAluno":"MARCOS HENRIQUE LIMA GONCALVES","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":5802601,"nomeAluno":"MARIA EDUARDA ALVES DOS SANTOS","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":5222508,"nomeAluno":"MARIA EDUARDA DOS SANTOS","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":4961083,"nomeAluno":"MARIA EDUARDA FORTES SOUZA","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":5612467,"nomeAluno":"MARIANE BEZERRA DE SOUZA","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":5731366,"nomeAluno":"MATHEUS DE ALENCAR SILVA","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":5699865,"nomeAluno":"NICKOLLY LOYOLA SOBRINHO","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":7292491,"nomeAluno":"RAFAEL SILVA CONCEICAO","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":4770834,"nomeAluno":"RYAN FELIPE ALMEIDA DE SOUZA","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":5241395,"nomeAluno":"RYAN FURTADO DE MELO","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":5075588,"nomeAluno":"SARAH SILVA DO NASCIMENTO","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":5078953,"nomeAluno":"VICTOR HUGO VIEIRA DA SILVA","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":5658806,"nomeAluno":"VITOR INOCENCIO MARQUES DA SILVA","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":5179059,"nomeAluno":"YAN GUSTAVO SANTOS GALVAO","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]},{"codigoAluno":4735711,"nomeAluno":"YARA DIAS DA SILVA","perguntas":[{"id":"d53ba946-fb3d-4b20-8883-0f7dbab3bddb","valor":""},{"id":"9d60c205-9a55-4f17-9254-b1d760d172fd","valor":""},{"id":"13eb098b-c9a6-46c5-b5cb-f4549cef94f0","valor":""},{"id":"21d6ae6b-f41e-4712-b71f-02cfc709e973","valor":""},{"id":"ef810828-770d-4fa4-bde2-31f31fb48337","valor":""}]}],"graficos":[{"nomeGrafico":"Números naturais e inteiros: significados, reta numerada e significado das operações","barras":[{"label":"Resolveu corretamente","value":0},{"label":"Resolveu uma parte do problema corretamente","value":0},{"label":"Resolveu o problema incorretamente","value":0},{"label":"Não registrou","value":0},{"label":"Sem Preenchimento","value":32}]},{"nomeGrafico":"Área e perímetro ","barras":[{"label":"Resolveu corretamente","value":0},{"label":"Compreende o que é área, mas não compreende o que é perímetro","value":0},{"label":"Compreende o que é perímetro, mas não compreende o que é área","value":0},{"label":"Não registrou","value":0},{"label":"Sem Preenchimento","value":32}]},{"nomeGrafico":"Sólidos geométricos","barras":[{"label":"Resolveu corretamente","value":0},{"label":"Identificou os nomes das figuras e não determinou elementos de poliedros corretamente","value":0},{"label":"Não identificou nomes de figuras e não determinou elementos de poliedros corretamente","value":0},{"label":"Não registrou","value":0},{"label":"Sem Preenchimento","value":32}]},{"nomeGrafico":"Relações entre grandezas e porcentagem","barras":[{"label":"Resolveu corretamente","value":0},{"label":"Identificou corretamente a proporcionalidade e indicou a porcentagem corretamente, mas errou os cálculos","value":0},{"label":"Não identificou corretamente a proporcionalidade e indicou incorretamente a porcentagem","value":0},{"label":"Não registrou","value":0},{"label":"Sem Preenchimento","value":32}]},{"nomeGrafico":"Média, moda e mediana","barras":[{"label":"Resolveu corretamente","value":0},{"label":"Identificou corretamente as três medidas de tendência central, mas erros os cálculos","value":0},{"label":"Não identificou uma ou mais medidas de tendência central","value":0},{"label":"Não registrou","value":0},{"label":"Sem Preenchimento","value":32}]}]}'
  );

  const dataCACM = {
    alunos: [
      {
        codigoAluno: "6641591",
        nomeAluno: "ANA LIVIA PEREIRA DOS SANTOS",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "7146990",
        nomeAluno: "ARTHUR OLIVEIRA",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "6634466",
        nomeAluno: "CAUAN SANTOS CARDOSO",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "6732096",
        nomeAluno: "DANIEL BORGES GOULART",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "7088960",
        nomeAluno: "DANYELLE RAMOS SOUZA DO CARMO",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "6733108",
        nomeAluno: "EDUARDA DALBIANCHI RIBEIRO",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "7622840",
        nomeAluno: "EMANUEL DE JESUS LOPEZ FIGUERA",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "6449508",
        nomeAluno: "GUSTAVO ANDRADE SODRE",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "6704418",
        nomeAluno: "HELOISA VENTURA DE OLIVEIRA SOUZA",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "6252280",
        nomeAluno: "ISABELLY ALESSANDRA SANTOS DA COSTA",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "6369670",
        nomeAluno: "ISABELLY DE SOUZA MARTINS",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "6148877",
        nomeAluno: "JOAO MIGUEL COUTO DE ARAUJO",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "6190193",
        nomeAluno: "JOAO MIGUEL NOGUEIRA DE CARVALHO",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "6375156",
        nomeAluno: "JOAO VICTOR VIEIRA ORTEGA",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "7134154",
        nomeAluno: "JULIA PYETRA SOUZA ANDRADE",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "7236270",
        nomeAluno: "LAURA DE SOUZA ROCHA",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "6211230",
        nomeAluno: "LORENA CAVALCANTE",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "6253814",
        nomeAluno: "LUCAS DANIEL DA SILVA CARVALHO",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "6683480",
        nomeAluno: "LUIZA GUTIERREZ RIBEIRO SCHIAVI",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "7432642",
        nomeAluno: "MANUELLA ROMANO SOLEDADE",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "6282131",
        nomeAluno: "MARIA HELENA SOUZA NUNES BRITO",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "6262980",
        nomeAluno: "MARIA LUIZA SILVA DIAS",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "6438002",
        nomeAluno: "MIGUEL LIMA DE MELO",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "6634471",
        nomeAluno: "NICOLAS SANTOS CARDOSO",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "6174933",
        nomeAluno: "PALOMA SANTANA XAVIER",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "7296608",
        nomeAluno: "PIETRO HENRIQUE SILVA SARCHI",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "6270396",
        nomeAluno: "ROBERTA GABRIELA BRITO",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "6385628",
        nomeAluno: "SOFIA SANTOS RABELO",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "6471397",
        nomeAluno: "THALLES DAMASCENO SANTOS",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "6184274",
        nomeAluno: "VANESSA LELIS CHAGAS BEZERRA SILVA",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
      {
        codigoAluno: "6471143",
        nomeAluno: "VITORIA JULIA GOMES CORREA",
        perguntas: [
          {
            nomePergunta: " 1 - COMPOSIÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
          {
            nomePergunta: " 2 - TRANSFORMAÇÃO",
            subPerguntas: [
              { nomeSubPergunta: "idea", resposta: "Não Resolveu" },
              { nomeSubPergunta: "resultado", resposta: "Não Resolveu" },
            ],
          },
        ],
      },
    ],
    graficos: [
      {
        nomeAluno: "Composição",
        ordenacao: 1,
        listaDeGrafico: [
          {
            nomeGrafico: "Ideia",
            barras: [
              {
                label: "Acertou",
                value: 2,
              },
              {
                label: "Errou",
                value: 2,
              },
              {
                label: "Não resolveu",
                value: 1,
              },
              {
                label: "Sem preenchimento",
                value: 83,
              },
            ],
          },
          {
            nomeGrafico: "Resultado",
            barras: [
              {
                label: "Acertou",
                value: 1,
              },
              {
                label: "Errou",
                value: 2,
              },
              {
                label: "Não resolveu",
                value: 2,
              },
              {
                label: "Sem preenchimento",
                value: 83,
              },
            ],
          },
        ],
      },
      {
        nome: "Transformação",
        ordenacao: 2,
        listaDeGrafico: [
          {
            nomeGrafico: "Ideia",
            barras: [
              {
                label: "Acertou",
                value: 0,
              },
              {
                label: "Errou",
                value: 0,
              },
              {
                label: "Não resolveu",
                value: 0,
              },
              {
                label: "Sem preenchimento",
                value: 88,
              },
            ],
          },
          {
            nomeGrafico: "Resultado",
            barras: [
              {
                label: "Acertou",
                value: 0,
              },
              {
                label: "Errou",
                value: 0,
              },
              {
                label: "Não resolveu",
                value: 0,
              },
              {
                label: "Sem preenchimento",
                value: 88,
              },
            ],
          },
        ],
      },
      {
        nome: "Comparação",
        ordenacao: 3,
        listaDeGrafico: [
          {
            nomeGrafico: "Ideia",
            barras: [
              {
                label: "Acertou",
                value: 0,
              },
              {
                label: "Errou",
                value: 0,
              },
              {
                label: "Não resolveu",
                value: 0,
              },
              {
                label: "Sem preenchimento",
                value: 88,
              },
            ],
          },
          {
            nomeGrafico: "Resultado",
            barras: [
              {
                label: "Acertou",
                value: 0,
              },
              {
                label: "Errou",
                value: 0,
              },
              {
                label: "Não resolveu",
                value: 0,
              },
              {
                label: "Sem preenchimento",
                value: 88,
              },
            ],
          },
        ],
      },
    ],
  };

  const montarPlanilhaPorTurma = () => {
    const Componente = ehAlfabetizacaoCACM
      ? RelatorioMatematicaPorTurmaCACM
      : RelatorioMatematicaPorTurma;
    const dados = ehAlfabetizacaoCACM ? dataCACM : dataMocado;

    return (
      dados && (
        <>
          <PollReportBreadcrumb className="mt-4" name="Planilha" />
          <Componente
            alunos={dados.alunos}
            perguntas={dados.perguntas}
            corUnica={ehAlfabetizacaoCACM}
          />
        </>
      )
    );
  };

  const montarPlanilha = () => {
    if (ehRelatorioPorTurma) {
      return montarPlanilhaPorTurma();
    }

    const Componente = ehAlfabetizacaoCACM
      ? RelatorioMatematicaConsolidadoCACM
      : RelatorioMatematicaConsolidado;

    return (
      data &&
      data.perguntas && (
        <>
          <PollReportBreadcrumb className="mt-5" name="Planilha" />
          {data.perguntas.map((dados, index) => (
            <Componente dados={dados} key={index} />
          ))}
        </>
      )
    );
  };

  const montarGraficos = () => {
    const classes = ehAlfabetizacaoCACM ? "mt-4" : "row mt-4";
    const Componente = ehAlfabetizacaoCACM
      ? GraficoMatematicaCACM
      : GraficoConsolidadoMatematica;
    const dadosEsc = !ehRelatorioPorTurma
      ? data
      : ehAlfabetizacaoCACM
      ? dataCACM
      : dataMocado;

    return (
      // data &&
      // data.graficos && (

      dadosEsc &&
      dadosEsc.graficos && (
        <>
          <PollReportBreadcrumb className="mt-5" name="Sondagem Gráfico" />
          <div className={classes}>
            {
              //data.graficos.map((dados, index) => (
              dadosEsc.graficos.map((dados, index) => (
                <Componente
                  dados={dados}
                  index={index}
                  key={index}
                  esconderTresLinhas={ehAlfabetizacaoNumero}
                />
              ))
            }
          </div>
        </>
      )
    );
  };

  return (
    <>
      {montarPlanilha()}
      {montarGraficos()}
    </>
  );
};
