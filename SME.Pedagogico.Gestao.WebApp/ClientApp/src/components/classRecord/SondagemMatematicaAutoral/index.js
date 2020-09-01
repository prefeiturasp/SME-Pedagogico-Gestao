﻿import React, { useState, useMemo, memo, useEffect } from "react";
import AlunoSondagemMatematicaAutoral from "./aluno";
import { useSelector, useDispatch } from "react-redux";
import { actionCreators } from "../../../store/SondagemAutoral";

function SondagemMatematicaAutoral() {
  const dispatch = useDispatch();

  const filtros = useSelector((store) => store.filters);

  const [indexSelecionado, setIndexSelecionado] = useState(1);

  const periodosLista = useSelector((store) => store.autoral.listaPeriodos);

  const perguntas = useSelector((store) => store.autoral.listaPerguntas);

  const alunosStore = useSelector(
    (store) => store.autoral.listaAlunosAutoralMatematica
  );
  const [alunos, setAlunos] = useState(alunosStore);

  const anoEscolar = useSelector(
    (store) => store.poll.selectedFilter.yearClassroom
  );

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

  const obterIndexAlunoAlteracao = (alunoIdState) => {
    return alunos.findIndex((x) => x.codigoAluno === alunoIdState);
  };

  const obterIndexRespostasAluno = (aluno, perguntaId, periodoId) => {
    if (!aluno.respostas || aluno.respostas.length === 0) return null;

    return aluno.respostas.findIndex(
      (x) => x.pergunta === perguntaId && x.periodo === periodoId
    );
  };

  const onChangeAluno = (
    novoValor,
    perguntaIdState,
    periodoIdState,
    alunoIdState,
    sondagemIdState
  ) => {
    const indexAluno = obterIndexAlunoAlteracao(alunoIdState);

    if (indexAluno < 0) return;

    const indexResposta = obterIndexRespostasAluno(
      alunoIdState,
      perguntaIdState,
      periodoIdState
    );

    if (!indexResposta || indexResposta <= -1) {
      if (!alunos[indexAluno].respostas) {
        alunos[indexAluno].respostas = [];
      }

      alunos[indexAluno].respostas.push({
        periodoId: periodoIdState,
        pergunta: perguntaIdState,
        resposta: novoValor,
      });
    } else {
      alunos[indexAluno].respostas[indexResposta].resposta = novoValor;
    }

    setAlunos(alunos);
  };

  useEffect(() => {
    dispatch(actionCreators.listarPeriodos());
    dispatch(actionCreators.listarPerguntas());
    dispatch(actionCreators.listaAlunosAutoralMatematica());
  }, []);

  useEffect(() => {
    setAlunos(alunosStore);
  }, [alunosStore]);

  useEffect(() => {
    setIndexSelecionado(primeiraOrdenacao);
  }, [perguntas]);

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
              onChangeAluno={onChangeAluno}
            />
          ))}
      </tbody>
    </table>
  );
}

export default memo(SondagemMatematicaAutoral);
