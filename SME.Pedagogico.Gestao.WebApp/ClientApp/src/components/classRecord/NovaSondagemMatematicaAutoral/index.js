﻿import React, { useState, useMemo, useEffect, useCallback } from "react";
import NovoAlunoSondagemMatematicaAutoral from "./novoAluno";
import { useSelector, useDispatch } from "react-redux";
import { actionCreators } from "../../../store/SondagemAutoral";
import { actionCreators as dataStore } from "../../../store/Data";
import { actionCreators as pollStore } from "../../../store/Poll";
import { actionCreators as filterStore } from "../../../store/Filters";
import Loader from "../../loader/Loader";

function NovaSondagemMatematicaAutoral() {
  const dispatch = useDispatch();

  const filtros = useSelector((store) => store.poll.selectedFilter);

  const [indexSelecionado, setIndexSelecionado] = useState(1);

  const emEdicao = useSelector((store) => store.autoral.emEdicao);

  const itemSelecionado = useSelector(
    (store) => store.autoral.perguntaSelecionada
  );

  const perguntas = useSelector((store) => store.autoral.listaPerguntas);

  const alunos = useSelector(
    (store) => store.autoral.listaAlunosAutoralMatematica
  );

  const bimestre = useSelector((store) => store.poll.bimestre);

  const loadingPerguntas = useSelector((store) => store.poll.loadingPerguntas);

  const setarModoEdicao = () => {
    dispatch(dataStore.set_new_data_state());
    dispatch(pollStore.setDataToSaveTrue());
  };

  const sairModoEdicao = useCallback(() => {
    dispatch(dataStore.reset_new_data_state());
    dispatch(pollStore.set_poll_data_saved_state());
    dispatch(actionCreators.setarEmEdicao(false));
  }, [dispatch]);

  useEffect(() => {
    if (!perguntas || perguntas.length === 0 || perguntas.mensagens) return;

    const pergunta = perguntas.find((x) => x.ordenacao == indexSelecionado);

    if (!pergunta) return;

    dispatch(actionCreators.setarPerguntaSelecionada(pergunta));
  }, [dispatch, indexSelecionado, perguntas]);

  const filtrosBusca = useMemo(() => {
    if (!filtros || !itemSelecionado) return;

    return {
      anoLetivo: filtros.schoolYear,
      anoEscolar: filtros.yearClassroom,
      codigoDre: filtros.dreCodeEol,
      codigoUe: filtros.schoolCodeEol,
      codigoTurma: filtros.classroomCodeEol,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
      perguntaId: itemSelecionado && itemSelecionado.id,
    };
  }, [filtros, itemSelecionado]);

  const anoEscolar = useSelector(
    (store) => store.poll.selectedFilter.yearClassroom
  );

  const ultimaOrdenacao = useMemo(() => {
    console.log("perguntas", perguntas);
    if (!perguntas || perguntas.length === 0 || perguntas.mensagens) return 0;

    return perguntas[perguntas.length - 1].ordenacao;
  }, [perguntas]);

  const primeiraOrdenacao = useMemo(() => {
    if (!perguntas || perguntas.length === 0 || perguntas.mensagens) return 0;

    return perguntas[0].ordenacao;
  }, [perguntas]);

  const avancar = () => {
    if (indexSelecionado == ultimaOrdenacao) return;

    if (!emEdicao) {
      setIndexSelecionado((oldState) => oldState + 1);
      return;
    }

    salvar().then((x) => {
      setIndexSelecionado((oldState) => oldState + 1);
      sairModoEdicao();
    });
  };

  const recuar = () => {
    if (indexSelecionado == primeiraOrdenacao) return;

    if (!emEdicao) {
      setIndexSelecionado((oldState) => oldState - 1);
      return;
    }

    salvar().then((x) => {
      setIndexSelecionado((oldState) => oldState - 1);
      sairModoEdicao();
    });
  };

  const salvar = async () => {
    await persistencia(alunos, filtrosBusca);
  };

  const persistencia = useCallback(
    async (listaAlunosRedux, filtrosBuscaPersistencia) => {
      let alunosMutaveis = Object.assign([], listaAlunosRedux);

      try {
        await dispatch(
          actionCreators.salvaSondagemAutoralMatematica(
            alunosMutaveis,
            filtrosBuscaPersistencia
          )
        );
      } catch (e) {
        dispatch(pollStore.setLoadingSalvar(false));
      }

      sairModoEdicao();
    },
    [dispatch, sairModoEdicao]
  );

  const obterIndexAlunoAlteracao = (alunoIdState) => {
    return alunos.findIndex((x) => x.codigoAluno === alunoIdState);
  };

  const obterIndexRespostasAluno = (aluno, perguntaId) => {
    if (!aluno.respostas || aluno.respostas.length === 0) return null;

    return aluno.respostas.findIndex((x) => x.pergunta === perguntaId);
  };

  const onChangeAluno = (novoValor, perguntaIdState, alunoIdState) => {
    setarModoEdicao();

    let alunosMutaveis = Object.assign([], alunos);

    const indexAluno = obterIndexAlunoAlteracao(alunoIdState);

    if (indexAluno < 0) return;

    const indexResposta = obterIndexRespostasAluno(
      alunosMutaveis[indexAluno],
      perguntaIdState
    );

    if (
      indexResposta === null ||
      indexResposta === undefined ||
      indexResposta <= -1
    ) {
      if (!alunosMutaveis[indexAluno].respostas) {
        alunosMutaveis[indexAluno].respostas = [];
      }

      alunosMutaveis[indexAluno].respostas.push({
        bimestre,
        pergunta: perguntaIdState,
        resposta: novoValor,
      });
    } else {
      alunosMutaveis[indexAluno].respostas[indexResposta].resposta = novoValor;
    }

    dispatch(
      actionCreators.setarAlunosAutoralmatematicaPreSalvar(alunosMutaveis)
    );

    dispatch(actionCreators.setarEmEdicao(true));
  };

  useEffect(() => {
    if (
      !filtrosBusca ||
      !filtrosBusca.perguntaId ||
      !filtrosBusca.anoLetivo ||
      !filtrosBusca.anoEscolar ||
      !bimestre
    )
      return;

    dispatch(
      actionCreators.listaAlunosAutoralMatematica(filtrosBusca, bimestre)
    );
  }, [bimestre, dispatch, filtrosBusca]);

  useEffect(() => {
    if (filtros.yearClassroom && bimestre) {
      dispatch(actionCreators.obterPeriodoAberto(filtros.schoolYear, bimestre));
      dispatch(actionCreators.listarPerguntas(filtros));
      dispatch(
        pollStore.setFunctionButtonSave(
          (
            alunosRedux,
            perguntasRedux,
            periodosRedux,
            filtrosSelecionadosSalvar
          ) => {
            persistencia(
              alunosRedux,
              perguntasRedux,
              periodosRedux,
              filtrosSelecionadosSalvar
            );
          }
        )
      );
    }

    return () => {
      dispatch(actionCreators.setarAlunosAutoralmatematicaPreSalvar([]));
      sairModoEdicao();
      dispatch(pollStore.setFunctionButtonSave(null));
    };
  }, [
    bimestre,
    dispatch,
    filtros,
    filtros.yearClassroom,
    persistencia,
    sairModoEdicao,
  ]);

  useEffect(() => {
    setIndexSelecionado(primeiraOrdenacao);
  }, [perguntas, primeiraOrdenacao]);

  if (!bimestre) return "";
  if (loadingPerguntas) {
    return (
      <div style={{ paddingBottom: 120 }}>
        <Loader loading={loadingPerguntas}> </Loader>
      </div>
    );
  }

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
            key={itemSelecionado && itemSelecionado.id}
            id={`col_head_${itemSelecionado && itemSelecionado.id}`}
            className="text-center border text-color-purple"
            style={{ maxWidth: 40 }}
          >
            <div
              className="d-flex justify-content-center align-items-center"
              style={{
                height: 30,
              }}
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
              <b
                className="p-4 text-nowrap overflow-hidden text-truncate"
                data-bs-toggle="tooltip"
                title={itemSelecionado && itemSelecionado.descricao}
              >
                {itemSelecionado && itemSelecionado.descricao}
              </b>
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
            </div>
          </th>
        </tr>
      </thead>
      <tbody>
        {alunos &&
          !!alunos.length &&
          alunos.map((aluno) => (
            <NovoAlunoSondagemMatematicaAutoral
              aluno={aluno}
              salvar={salvar}
              perguntaSelecionada={itemSelecionado}
              onChangeAluno={onChangeAluno}
            />
          ))}
      </tbody>
    </table>
  );
}

export default NovaSondagemMatematicaAutoral;