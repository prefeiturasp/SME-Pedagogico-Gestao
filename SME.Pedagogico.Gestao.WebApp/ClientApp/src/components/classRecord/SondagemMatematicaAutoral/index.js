import React, { useState, useMemo, memo, useEffect } from "react";
import AlunoSondagemMatematicaAutoral from "./aluno";
import { useSelector, useDispatch } from "react-redux";
import { actionCreators } from "../../../store/SondagemAutoral";

function SondagemMatematicaAutoral() {
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
  const periodosLista = useSelector((store) => store.autoral.listaPeriodos);
  const perguntas = useSelector((store) => store.autoral.listaPerguntas);
  const anoEscolar = useSelector((store) => store.poll.selectedFilter.yearClassroom);

  const itemSelecionado = useMemo(() => {
    if (!perguntas || perguntas.length === 0) return {};

    return perguntas.find((x) => x.ordenacao == indexSelecionado);
  }, [indexSelecionado]);

  const ultimaOrdenacao = useMemo(() => {
    if (!perguntas || perguntas.length === 0) return 0;

    return perguntas[perguntas.length - 1].ordenacao;
  }, [perguntas]);

  const primeiraOrdenacao = useMemo(() => {
    if (!perguntas || perguntas.length === 0) return 0;

    return perguntas[0].ordenacao;
  }, [perguntas]);

  const avancar = () => {
    if (indexSelecionado == ultimaOrdenacao) return;

    setIndexSelecionado((oldState) => oldState + 1);
  };

  const recuar = () => {
    if (indexSelecionado == primeiraOrdenacao) return;

    setIndexSelecionado((oldState) => oldState - 1);
  };

  useEffect(() => {
    dispatch(actionCreators.listarPeriodos());
    dispatch(actionCreators.listarPerguntas());
  }, []);

  useEffect(() => {
    setIndexSelecionado(primeiraOrdenacao);
  },[perguntas])

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
            <div className="ml-2">Sondagem - {anoEscolar}º ano</div>
          </th>
          <th
            colSpan="2"
            key={itemSelecionado.id}
            id={`col_head_${itemSelecionado.id}`}
            className="text-center border text-color-purple"
          >
            <span
              value="opacos_col"
              onClick={() => recuar()}
              className="testcursor"
            >
              <img
                src="./img/icon_2_pt_7C4DFF.svg"
                alt="seta esquerda ativa"
                style={{ height: 20 }}
              />
            </span>
            <b className="p-4">{itemSelecionado.descricao}</b>
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
          </th>
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
