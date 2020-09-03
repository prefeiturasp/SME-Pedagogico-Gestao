import React, { useState, useMemo, memo, useEffect } from "react";
import AlunoSondagemMatematicaAutoral from "./aluno";
import { useSelector, useDispatch } from "react-redux";
import { actionCreators } from "../../../store/SondagemAutoral";
import { actionCreators as dataStore } from "../../../store/Data";
import { actionCreators as pollStore } from "../../../store/Poll";
import { data } from "jquery";

function SondagemMatematicaAutoral() {
  const dispatch = useDispatch();

  const filtros = useSelector((store) => store.poll.selectedFilter);

  const [indexSelecionado, setIndexSelecionado] = useState(1);

  const periodosLista = useSelector((store) => store.autoral.listaPeriodos);

  const perguntas = useSelector((store) => store.autoral.listaPerguntas);

  const alunos = useSelector(
    (store) => store.autoral.listaAlunosAutoralMatematica
  );

  const setarModoEdicao = () => {
    dispatch(dataStore.set_new_data_state());
    dispatch(pollStore.setDataToSaveTrue());
  };

  const sairModoEdicao = () => {
    dispatch(dataStore.reset_new_data_state());
    dispatch(pollStore.set_poll_data_saved_state());
  };

  const filtrosBusca = useMemo(() => {
    return {
      anoLetivo: filtros.schoolYear,
      anoEscolar: filtros.yearClassroom,
      codigoDre: filtros.dreCodeEol,
      codigoUe: filtros.schoolCodeEol,
      codigoTurma: filtros.classroomCodeEol,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
    };
  }, filtros);

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

    salvar().then((x) => {
      setIndexSelecionado((oldState) => oldState + 1);
      sairModoEdicao();
    });
  };

  const recuar = () => {
    if (indexSelecionado == primeiraOrdenacao) return;

    salvar().then((x) => {
      setIndexSelecionado((oldState) => oldState - 1);
      sairModoEdicao();
    });
  };

  const salvar = async () => {
    await persistencia(alunos, perguntas, periodosLista);
  };

  const persistencia = async (
    listaAlunosRedux,
    perguntasRedux,
    periodosRedux
  ) => {
    let alunosMutaveis = Object.assign([], listaAlunosRedux);

    alunosMutaveis.forEach((aluno) => {
      perguntasRedux.forEach((pergunta) => {
        periodosRedux.forEach((periodo) => {
          const resposta = {
            periodoId: periodo.id,
            pergunta: pergunta.id,
            resposta: null,
          };

          if (!aluno.respostas || aluno.respostas.length === 0) {
            aluno.respostas = [];
            aluno.respostas.push(resposta);
          }

          var indexResposta = aluno.respostas.findIndex(
            (resposta) =>
              resposta.pergunta === pergunta.id &&
              resposta.periodoId === periodo.id
          );
          if (indexResposta < 0) {
            aluno.respostas.push(resposta);
          }
        });
      });
    });

    dispatch(
      actionCreators.salvaSondagemAutoralMatematica(
        alunosMutaveis,
        filtrosBusca
      )
    );

    sairModoEdicao();
  };

  const obterIndexAlunoAlteracao = (alunoIdState) => {
    return alunos.findIndex((x) => x.codigoAluno === alunoIdState);
  };

  const obterIndexRespostasAluno = (aluno, perguntaId, periodoId) => {
    if (!aluno.respostas || aluno.respostas.length === 0) return null;

    return aluno.respostas.findIndex(
      (x) => x.pergunta === perguntaId && x.periodoId === periodoId
    );
  };

  const onChangeAluno = (
    novoValor,
    perguntaIdState,
    periodoIdState,
    alunoIdState,
    sondagemIdState
  ) => {
    setarModoEdicao();

    let alunosMutaveis = Object.assign([], alunos);

    const indexAluno = obterIndexAlunoAlteracao(alunoIdState);

    if (indexAluno < 0) return;

    const indexResposta = obterIndexRespostasAluno(
      alunosMutaveis[indexAluno],
      perguntaIdState,
      periodoIdState
    );

    if (
      indexResposta === null ||
      indexResposta === undefined ||
      indexResposta <= -1
    ) {
      console.log(alunosMutaveis[indexAluno].respostas);
      if (!alunosMutaveis[indexAluno].respostas) {
        alunosMutaveis[indexAluno].respostas = [];
      }

      alunosMutaveis[indexAluno].respostas.push({
        periodoId: periodoIdState,
        pergunta: perguntaIdState,
        resposta: novoValor,
      });
    } else {
      alunosMutaveis[indexAluno].respostas[indexResposta].resposta = novoValor;
    }

    dispatch(
      actionCreators.setarAlunosAutoralmatematicaPreSalvar(alunosMutaveis)
    );
  };

  useEffect(() => {
    dispatch(actionCreators.listarPeriodos());
    dispatch(actionCreators.listarPerguntas());
    dispatch(actionCreators.listaAlunosAutoralMatematica(filtrosBusca));
    dispatch(
      pollStore.setFunctionButtonSave(
        (alunosRedux, perguntasRedux, periodosRedux) => {
          persistencia(alunosRedux, perguntasRedux, periodosRedux);
        }
      )
    );

    return () => {
      dispatch(actionCreators.setarAlunosAutoralmatematicaPreSalvar([]));
      sairModoEdicao();
    };
  }, []);

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
          alunos &&
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

export default SondagemMatematicaAutoral;
