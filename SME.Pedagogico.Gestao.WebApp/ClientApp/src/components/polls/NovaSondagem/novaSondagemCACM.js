import React, { useState, useMemo, useEffect, useCallback } from "react";
import { useSelector, useDispatch } from "react-redux";

import { actionCreators } from "../../../store/SondagemAutoral";
import { actionCreators as dataStore } from "../../../store/Data";
import { actionCreators as pollStore } from "../../../store/Poll";
import Loader from "../../loader/Loader";
import CabecalhoPerguntaAutoral from "../../classRecord/NovaSondagemMatematicaAutoral/cabecalhoPerguntaAutoral";
import {
  setasDireitaAlfabetizacao,
  setasEsquerdaAlfabetizacao,
} from "../../utils/utils";
import NovoAlunoSondagemMatematicaAutoral from "../../classRecord/NovaSondagemMatematicaAutoral/novoAluno";
import { GRUPO_SONDAGEM } from "../../../Enums";
import { SalvaSondagemAutoralMatAsync } from "../../../sagas/SondagemAutoral";
import { validouEstudantesSemRespostaMatematicaCACM } from "../../../utils/validacoes";
import { showModalConfirm } from "../../../service/modal-service";
import { ALERTA_DESEJA_SALVAR_AGORA } from "../../../utils/constants";

function NovaSondagemCACM() {
  const dispatch = useDispatch();

  const filtros = useSelector((store) => store.poll.selectedFilter);
  const tipoSondagem = useSelector((store) => store.poll.pollTypeSelected);

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

  const carregandoPerguntas = useSelector(
    (store) => store.poll.carregandoPerguntas
  );

  const carregandoAlunos = useSelector((store) => store.poll.carregandoAlunos);

  const tamanhoLinhas =
    itemSelecionado && itemSelecionado.perguntas
      ? itemSelecionado.perguntas.length
      : 0;

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

    const pergunta = perguntas.find(
      (x) => x.ordenacao === Number(indexSelecionado)
    );

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
    if (!perguntas || perguntas.length === 0 || perguntas.mensagens) return 0;

    return perguntas[perguntas.length - 1].ordenacao;
  }, [perguntas]);

  const primeiraOrdenacao = useMemo(() => {
    if (!perguntas || perguntas.length === 0 || perguntas.mensagens) return 0;

    return perguntas[0].ordenacao;
  }, [perguntas]);

  const avancar = () => {
    if (indexSelecionado === ultimaOrdenacao) return;

    if (!emEdicao) {
      setIndexSelecionado((oldState) => oldState + 1);
      return;
    }

    showModalConfirm({
      content: ALERTA_DESEJA_SALVAR_AGORA,
      onOk: () => {
        salvar().then((continuar = true) => {
          if (!continuar) return false;

          setIndexSelecionado((oldState) => oldState + 1);
          sairModoEdicao();

          return true;
        });
      },
      onCancel: () => {
        setIndexSelecionado((oldState) => oldState + 1);
        sairModoEdicao();
      },
    });
  };

  const recuar = () => {
    if (indexSelecionado === primeiraOrdenacao) return;

    if (!emEdicao) {
      setIndexSelecionado((oldState) => oldState - 1);
      return;
    }

    showModalConfirm({
      content: ALERTA_DESEJA_SALVAR_AGORA,
      onOk: () => {
        salvar().then((continuar = true) => {
          if (!continuar) return false;

          setIndexSelecionado((oldState) => oldState - 1);
          sairModoEdicao();

          return true;
        });
      },
      onCancel: () => {
        setIndexSelecionado((oldState) => oldState - 1);
        sairModoEdicao();
      },
    });
  };

  const salvar = async () => {
    return await persistencia(alunos, filtrosBusca);
  };

  const persistencia = useCallback(
    async (listaAlunosRedux, filtrosBuscaPersistencia) => {
      const alunosMutaveis = Object.assign([], listaAlunosRedux);
      alunosMutaveis.forEach((element) => {
        if (!element.bimestre) {
          element.bimestre = bimestre;
        }
      });

      const continuar = await validouEstudantesSemRespostaMatematicaCACM(alunosMutaveis);

      if (!continuar) return false;

      try {
        return SalvaSondagemAutoralMatAsync({
          alunos: alunosMutaveis,
          filtro: filtrosBuscaPersistencia,
        }).then(() => {
          sairModoEdicao();
          return true;
        });
      } catch (e) {
        dispatch(pollStore.setLoadingSalvar(false));
        return false;
      }
    },
    [dispatch, sairModoEdicao, bimestre]
  );

  const obterIndexAlunoAlteracao = (alunoIdState) => {
    return alunos.findIndex((x) => x.codigoAluno === alunoIdState);
  };

  const obterIndexRespostasAluno = (aluno, perguntaId, subPerguntaId) => {
    if (!aluno.respostas || aluno.respostas.length === 0) return null;

    return aluno.respostas.findIndex((item) => item.pergunta === subPerguntaId);
  };

  const onChangeAluno = (
    novoValor,
    perguntaIdState,
    alunoIdState,
    sondagemId,
    subPerguntaId
  ) => {
    setarModoEdicao();

    let alunosMutaveis = Object.assign([], alunos);

    const indexAluno = obterIndexAlunoAlteracao(alunoIdState);

    if (indexAluno < 0) return;

    const indexResposta = obterIndexRespostasAluno(
      alunosMutaveis[indexAluno],
      perguntaIdState,
      subPerguntaId
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
        pergunta: subPerguntaId,
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
      !bimestre ||
      !perguntas
    )
      return;

    const idSubPerguntas =
      itemSelecionado &&
      itemSelecionado.perguntas &&
      itemSelecionado.perguntas.map((item) => item.id);

    dispatch(
      pollStore.obterAlunosAlfabetizacao({
        filtrosBusca,
        bimestre,
        perguntas: idSubPerguntas,
      })
    );
  }, [bimestre, dispatch, filtrosBusca, itemSelecionado, perguntas]);

  useEffect(() => {
    if (filtros.yearClassroom && bimestre) {
      dispatch(actionCreators.obterPeriodoAberto(filtros.schoolYear, bimestre));
      dispatch(
        pollStore.obterPerguntasAlfabetizacao({
          ...filtros,
          grupo: GRUPO_SONDAGEM[tipoSondagem],
          bimestre,
        })
      );
      dispatch(
        pollStore.setFunctionButtonSave(
          (
            alunosRedux,
            perguntasRedux,
            periodosRedux,
            filtrosSelecionadosSalvar
          ) => {
            return persistencia(
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
  }, [bimestre, dispatch, filtros, persistencia, sairModoEdicao, tipoSondagem]);

  useEffect(() => {
    setIndexSelecionado(primeiraOrdenacao);
  }, [perguntas, primeiraOrdenacao]);

  const montarDados = () => {
    if (carregandoAlunos) {
      return (
        <div style={{ paddingBottom: 170 }}>
          <Loader loading={carregandoAlunos}> </Loader>
        </div>
      );
    }
    return (
      <>
        {alunos &&
          !!alunos.length &&
          alunos.map((aluno) => (
            <NovoAlunoSondagemMatematicaAutoral
              aluno={aluno}
              salvar={salvar}
              perguntaSelecionada={itemSelecionado}
              onChangeAluno={onChangeAluno}
              ehAutoral={false}
            />
          ))}
      </>
    );
  };

  if (!bimestre) return "";
  if (carregandoPerguntas) {
    return (
      <div style={{ paddingBottom: 140 }}>
        <Loader loading={carregandoPerguntas}> </Loader>
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
          <CabecalhoPerguntaAutoral
            props={{
              tamanhoLinhas,
              anoEscolar,
              itemSelecionado,
              recuar,
              avancar,
              tipoSondagem,
              primeiraOrdenacao,
              ultimaOrdenacao,
              indexSelecionado,
              setasDireita: setasDireitaAlfabetizacao,
              setasEsquerda: setasEsquerdaAlfabetizacao,
              classes: "sondagem-matematica-title",
            }}
          />
        </tr>
        {itemSelecionado &&
          itemSelecionado.perguntas &&
          !!itemSelecionado.perguntas.length && (
            <tr>
              {itemSelecionado.perguntas.map((item) => (
                <td className="text-center border poll-select-container ordem3_col">
                  <small className="text-muted">{item.descricao}</small>
                </td>
              ))}
            </tr>
          )}
      </thead>
      <tbody>{montarDados()}</tbody>
    </table>
  );
}

export default NovaSondagemCACM;
