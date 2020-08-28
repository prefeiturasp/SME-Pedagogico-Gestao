import React, { useState, useMemo, memo, useEffect } from "react";
import AlunoSondagemMatematicaAutoral from "./aluno";
import { useSelector, useDispatch } from "react-redux";
import { actionCreators } from "../../../store/SondagemAutoral";

function SondagemMatematicaAutoral() {
  const perguntas = [
    {
      id: "d53ba946-fb3d-4b20-8883-0f7dbab3bddb",
      descricao: "Problema de lógica",
      ordenacao: 1,
      respostas: [
        {
          id: "bc66297b-3f3a-4d8d-b6c4-ceea1696bc11",
          descricao: "Resolveu corretamente",
          ordenacao: 1,
        },
        {
          id: "04695943-0abf-4dd7-b8b8-9e850f5d8d2e",
          descricao: "Resolveu uma parte do problema corretamente",
          ordenacao: 2,
        },
        {
          id: "53911083-6799-4553-8e5e-3eaadec17a55",
          descricao: "Resolveu o problema incorretamente",
          ordenacao: 3,
        },
        {
          id: "a04c7a11-52d7-4fbc-9115-2df00eda1ad2",
          descricao: "Não registrou",
          ordenacao: 4,
        },
      ],
    },
    {
      id: "9d60c205-9a55-4f17-9254-b1d760d172fd",
      descricao: "Área e perímetro ",
      ordenacao: 2,
      respostas: [
        {
          id: "bc66297b-3f3a-4d8d-b6c4-ceea1696bc11",
          descricao: "Resolveu corretamente",
          ordenacao: 1,
        },
        {
          id: "aae9c109-bdb5-4391-b513-e5fd68d39d5a",
          descricao:
            "Compreende o que é área, mas não compreende o que é perímetro",
          ordenacao: 2,
        },
        {
          id: "ffa53f05-b71e-4ef8-9b10-7c932ca681db",
          descricao:
            "Compreende o que é perímetro, mas não compreende o que é área",
          ordenacao: 3,
        },
        {
          id: "a04c7a11-52d7-4fbc-9115-2df00eda1ad2",
          descricao: "Não registrou",
          ordenacao: 4,
        },
      ],
    },
    {
      id: "13eb098b-c9a6-46c5-b5cb-f4549cef94f0",
      descricao: "Sólidos geométricos",
      ordenacao: 3,
      respostas: [
        {
          id: "bc66297b-3f3a-4d8d-b6c4-ceea1696bc11",
          descricao: "Resolveu corretamente",
          ordenacao: 1,
        },
        {
          id: "7abb0305-441f-4d40-baea-4cc3f13a1a50",
          descricao:
            "Identificou os nomes das figuras e não determinou elementos de poliedros corretamente",
          ordenacao: 2,
        },
        {
          id: "0218ff47-5565-426c-8d12-07090a1b4ec9",
          descricao:
            "Não identificou nomes de figuras e não determinou elementos de poliedros corretamente",
          ordenacao: 3,
        },
        {
          id: "a04c7a11-52d7-4fbc-9115-2df00eda1ad2",
          descricao: "Não registrou",
          ordenacao: 4,
        },
      ],
    },
    {
      id: "21d6ae6b-f41e-4712-b71f-02cfc709e973",
      descricao: "Relações entre grandezas e porcentagem",
      ordenacao: 4,
      respostas: [
        {
          id: "bc66297b-3f3a-4d8d-b6c4-ceea1696bc11",
          descricao: "Resolveu corretamente",
          ordenacao: 1,
        },
        {
          id: "80d96e10-6be4-4ba4-8a84-4a7135e09b59",
          descricao:
            "Identificou corretamente a proporcionalidade e indicou a porcentagem corretamente, mas errou os cálculos",
          ordenacao: 2,
        },
        {
          id: "91c73b09-4ae9-4305-92bd-efa68ed9a4db",
          descricao:
            "Não identificou corretamente a proporcionalidade e indicou incorretamente a porcentagem",
          ordenacao: 3,
        },
        {
          id: "a04c7a11-52d7-4fbc-9115-2df00eda1ad2",
          descricao: "Não registrou",
          ordenacao: 4,
        },
      ],
    },
    {
      id: "ef810828-770d-4fa4-bde2-31f31fb48337",
      descricao: "Média, moda e mediana",
      ordenacao: 5,
      respostas: [
        {
          id: "bc66297b-3f3a-4d8d-b6c4-ceea1696bc11",
          descricao: "Resolveu corretamente",
          ordenacao: 1,
        },
        {
          id: "22cbd4e4-582f-46c4-a2ee-ff4f387453bc",
          descricao:
            "Identificou corretamente as três medidas de tendência central, mas erros os cálculos",
          ordenacao: 2,
        },
        {
          id: "56da5097-d043-475e-a083-edcec0a94fdc",
          descricao: "Não identificou uma ou mais medidas de tendência central",
          ordenacao: 3,
        },
        {
          id: "a04c7a11-52d7-4fbc-9115-2df00eda1ad2",
          descricao: "Não registrou",
          ordenacao: 4,
        },
      ],
    },
  ];

  const alunos = [
    {
      id: "73a6c501-5b5c-4c70-852a-76aefabfbc00",
      codigoAluno: "4199972",
      nomeAluno: "KAUE PEREIRA DE FREITAS",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: [
        {
          periodoId: "c93c1c4a-abb9-43a4-a8cd-283e4df365d8",
          pergunta: "d53ba946-fb3d-4b20-8883-0f7dbab3bddb",
          resposta: "bc66297b-3f3a-4d8d-b6c4-ceea1696bc11",
        },
      ],
    },
    {
      id: null,
      codigoAluno: "4199972",
      nomeAluno: "KAUE PEREIRA DE FREITAS",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "4417583",
      nomeAluno: "ANDRE ARAO FELIX",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "4452724",
      nomeAluno: "MIGUEL GUIRALDELI MUNHOES",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "4456328",
      nomeAluno: "GABRIEL ALMEIDA DUARTE",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "4478355",
      nomeAluno: "LUCAS GABRIEL LINO",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "4480823",
      nomeAluno: "SABRINA SILVA RODRIGUES",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "4481543",
      nomeAluno: "GUILHERME AUGUSTO KAMPF BAPTISTA",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "4501017",
      nomeAluno: "JOICE FERMI GARIGLIO",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "4515536",
      nomeAluno: "SARAH DE JESUS FERREIRA LIMA",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "4593444",
      nomeAluno: "MARIA EDUARDA GONCALVES",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "4616841",
      nomeAluno: "FLAVIO FERREIRA SOUZA COSTA",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "4642853",
      nomeAluno: "GABRIELA DA SILVA",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "4656653",
      nomeAluno: "SABRINA FREITAS HIPOLITO",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "4672938",
      nomeAluno: "JULIA IMPERIO TEIXEIRA",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "4711531",
      nomeAluno: "EDUARDA AFFONSO ALVES TALANSKI",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "4731117",
      nomeAluno: "VITORIA LAUREANO RAMOS",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "4751782",
      nomeAluno: "MARIA EDUARDA RAMOS DIB",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "4765763",
      nomeAluno: "RIAN ALVES DE OLIVEIRA",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "4809526",
      nomeAluno: "MARIANA AMARANTE DE CAMPOS ARRUDA",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "4832854",
      nomeAluno: "YASMIN BARBOSA TAVARES",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "4855767",
      nomeAluno: "CAUANE LUIZA BENICIO BRITO",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "4889292",
      nomeAluno: "ELISA DE SOUZA GONDIM JOZIAS",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "5005850",
      nomeAluno: "TALITA VIEIRA ALMEIDA",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "5012895",
      nomeAluno: "LUCAS MATHEUS GOMES FERREIRA",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "5048542",
      nomeAluno: "ANA CAROLINA SOARES",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "5121160",
      nomeAluno: "BIANCA DE CAMPOS LOPES FARATRO",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "5149372",
      nomeAluno: "LUCAS DOMICIANO DE OLIVEIRA",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "5173306",
      nomeAluno: "GIOVANNA VICTORIA PEREIRA GOMES",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "5220639",
      nomeAluno: "SUELLEN LIMA SENA",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "5302551",
      nomeAluno: "DAVI DA SILVA BARBOSA",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "5532699",
      nomeAluno: "GIOVANA SIQUEIRA ALVES",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "5623752",
      nomeAluno: "HELENA VIEIRA CARDOSO",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "5683211",
      nomeAluno: "ENRICO RODRIGUES ARISTIDES DE SOUZA",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "5926755",
      nomeAluno: "CAUAN ALVES TAPETY",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "7147593",
      nomeAluno: "DANIEL FAGUNDES COELHO",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "7432681",
      nomeAluno: "MARTHA DUARTE MIRANDA",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "7531591",
      nomeAluno: "ANDREY GOMES CORREIA",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
    {
      id: null,
      codigoAluno: "7572553",
      nomeAluno: "KATHERYNE PIETROSKI FALCAO",
      codigoTurma: "2117440",
      codigoDre: "108800",
      codigoUe: "094765",
      anoLetivo: 2020,
      anoTurma: 7,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      respostas: null,
    },
  ];

  const dispatch = useDispatch();
  const filtros = useSelector((store) => store.filters);
  
  const [indexSelecionado, setIndexSelecionado] = useState(1);
  const periodosLista = useSelector((store) => store.listaPeriodos);
  const perguntasLista = useSelector((store) => store.listaPerguntas);

  console.log(perguntasLista);
  console.log(periodosLista);

  const itemSelecionado = useMemo(() => {
    return perguntas.filter((x) => x.ordenacao == indexSelecionado);
  }, [indexSelecionado]);

  const avancar = () => {
    if (indexSelecionado == perguntas.length - 1) return;

    setIndexSelecionado((oldState) => oldState + 1);
  };

  const recuar = () => {
    if (indexSelecionado == 1) return;

    setIndexSelecionado((oldState) => oldState - 1);
  };

  useEffect(() => {
    dispatch(actionCreators.listarPeriodos());
    dispatch(actionCreators.listarPerguntas());
  }, []);

  const pStyle = {
    color: "#DADADA",
  };

  return (
    <table
      className="table table-sm table-bordered table-hover table-sondagem-matematica"
      style={{ overflow: "hidden", overflowX: "auto" }}
    >
      <thead>
        <tr>
          <th rowSpan="2" className="align-middle border text-color-purple">
            <div className="ml-2">Sondagem - Blaº ano | Números</div>
          </th>
          {itemSelecionado.map((pergunta, index) => (
            <th
              colSpan="2"
              key={pergunta.id}
              id={`col_head_${pergunta.id}`}
              className="text-center border text-color-purple"
            >
              <span
                value="opacos_col"
                onClick={() => recuar()}
                className="testcursor"
                aria-disabled={pergunta.ordenacao <= 1}
                disabled={pergunta.ordenacao <= 1}
              >
                <img
                  src="./img/icon_2_pt_7C4DFF.svg"
                  alt="seta esquerda ativa"
                  style={{ height: 20 }}
                />
              </span>
              <b className="p-4">{pergunta.descricao}</b>
              {pergunta.ordenacao < perguntas.length - 1 ? (
                <span
                  value="zero_col"
                  onClick={() => avancar()}
                  className="testcursor"
                >
                  <img
                    src="./img/icon_pt_7C4DFF.svg"
                    alt="seta direita ativa"
                    style={{ height: 20 }}
                  />
                </span>
              ) : null}
            </th>
          ))}
        </tr>
        <tr>
          {periodosLista &&
            periodosLista.map((periodo) => (
              <th
                key={periodo.id}
                className="text-center border poll-select-container"
              >
                <small className="text-muted">{periodo.descricao}</small>
              </th>
            ))}
        </tr>
      </thead>
      <tbody>
        {periodosLista &&
          alunos.map((aluno) => (
            <AlunoSondagemMatematicaAutoral
              aluno={aluno}
              periodos={periodosLista}
              perguntaSelecionada={itemSelecionado}
            />
          ))}
      </tbody>
    </table>
  );
}

export default memo(SondagemMatematicaAutoral);
