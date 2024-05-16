import React, { useEffect, useMemo } from "react";
import Select from "./select";
import { actionCreators as PortuguesStore } from "../../../store/SondagemPortuguesStore";
import { useSelector, useDispatch } from "react-redux";
import SeletorDeOrdem from "./seletorDeordem";
import TabelaAlunos from "./tabelaAlunos";
import { actionCreators as dataStore } from "../../../store/Data";
import { actionCreators as pollStore } from "../../../store/Poll";
import { TIPO_PERIODO } from "../../../Enums";
import {
  showModalConfirm,
  showModalError,
} from "../../../service/modal-service";
import { SalvaSondagemPortuguesAsync } from "../../../sagas/SondagemPortugues";
import { ALERTA_DESEJA_SALVAR_AGORA, ALERTA_ESTUDANTE_SEM_RESPOSTA_SELECIONADA } from "../../../utils/constants";

function SondagemPortuguesAutoral() {
  const dispatch = useDispatch();

  const grupoSelecionado = useSelector((store) => store.sondagemPortugues.grupoSelecionado);

  const idOrdemSelecionada = useSelector((store) => store.sondagemPortugues.ordemSelecionada);

  const filtros = useSelector((store) => store.poll.selectedFilter);

  const alunos = useSelector((store) => store.sondagemPortugues.alunos);

  const perguntas = useSelector((store) => store.sondagemPortugues.perguntas);

  const sequenciasOrdens = useSelector(store => store.sondagemPortugues.sequenciaOrdens);

  const filtrosBusca = useSelector(store => store.sondagemPortugues.filtros);

  const emEdicao = useSelector((store) => store.sondagemPortugues.emEdicao);

  const periodoSelecionado = useSelector(store => store.sondagemPortugues.periodoSelecionado);

  const periodos = useSelector((store) => store.sondagemPortugues.periodos);

  const grupos = useSelector((store) => store.sondagemPortugues.grupos);

  const ordens = useMemo(() => {
    if (
      !grupoSelecionado ||
      grupoSelecionado === "" ||
      !grupos ||
      grupos.length === 0 ||
      grupoSelecionado.indexOf("Selecione o grupo") >=0
    )
      return [];

    const grupo = grupos.find((grupo) => grupo.id === grupoSelecionado);

    return grupo.ordem;
  }, [grupoSelecionado, grupos,]);

  const setarModoEdicaoPoll = () => {
    dispatch(dataStore.set_new_data_state());
    dispatch(pollStore.setDataToSaveTrue());
  };

  const sairModoEdicaoPoll = () => {
    dispatch(dataStore.reset_new_data_state());
    dispatch(pollStore.set_poll_data_saved_state());
    dispatch(PortuguesStore.setar_emEdicao(false));
  };

  const onChangeGruposConfirmacao = (novoGrupoId) => {
    showModalConfirm({
      content: ALERTA_DESEJA_SALVAR_AGORA,
      onOk: () => {
        salvar({ novaOrdem: null, novoPeriodoId: null }).then(
          (continuar = true) => {
            if (!continuar) return false;

            setTimeout(() => {
              dispatch(PortuguesStore.selecionar_grupo(novoGrupoId));
              dispatch(PortuguesStore.setar_emEdicao(false));
            }, 1000);

            return true;
          }
        );
      },
      onCancel: () => {
        dispatch(PortuguesStore.selecionar_grupo(novoGrupoId));
        dispatch(PortuguesStore.setar_emEdicao(false));
      },
    });
  };

  const onChangeGrupos = (grupoId) => {
    if (!emEdicao) {
      dispatch(PortuguesStore.selecionar_grupo(grupoId));
      return;
    }

    onChangeGruposConfirmacao(grupoId);
  };

  const onClickOrdemConfirmacao = (novaOrdemId) => {
    showModalConfirm({
      content: ALERTA_DESEJA_SALVAR_AGORA,
      onOk: () => {
        salvar({ novaOrdem: novaOrdemId }).then((continuar = true) => {
          if (!continuar) return false;

          setTimeout(() => {
            dispatch(PortuguesStore.setar_emEdicao(false));
            dispatch(PortuguesStore.setar_ordem_selecionada(novaOrdemId));
            dispatch(
              PortuguesStore.listarAlunosPortugues({
                ...filtrosBusca,
                ordemId: novaOrdemId,
              })
            );
          }, 1000);

          return true;
        });
      },
      onCancel: () => {
        dispatch(PortuguesStore.setar_emEdicao(false));
        dispatch(PortuguesStore.setar_ordem_selecionada(novaOrdemId));
        dispatch(
          PortuguesStore.listarAlunosPortugues({
            ...filtrosBusca,
            ordemId: novaOrdemId,
          })
        );
      },
    });
  };

  const onClickOrdem = (id) => {
    if (emEdicao) {
      onClickOrdemConfirmacao(id);
      return;
    }

    dispatch(PortuguesStore.setar_ordem_selecionada(id));
    dispatch(PortuguesStore.listarAlunosPortugues({ ...filtrosBusca, ordemId: id }));
  };

  const salvar = async ({ novaOrdem, novoPeriodoId }) => {
    let alunosMutaveis = Object.assign([], alunos);
    let filtrosMutaveis = Object.assign({}, filtrosBusca);

    const sequenciaOrdemSelecionada = sequenciasOrdens ? sequenciasOrdens.findIndex(sequencia => sequencia.ordemId === idOrdemSelecionada) : 0;

    return executarSalvamento({
      perguntasSalvar: perguntas,
      alunosMutaveis,
      filtrosMutaveis,
      sequenciaOrdemSelecionada,
      novaOrdem,
      periodoSelecionadoSalvar: periodoSelecionado,
      novoPeriodoId,
      idOrdem: idOrdemSelecionada,
      grupo: grupoSelecionado,
    });
  };

  const temEstudantesSemResposta = (grupo, alunosMutaveis, perguntasSalvar) => {
    if (
      grupo === "e27b99a3-789d-43fb-a962-7df8793622b1" // IAD - Capacidade de leitura
    ) {
      const estudanteSemResposta = alunosMutaveis.find((estudante) => {
        const respostas = estudante?.respostas;
        const semResposta = !respostas?.length;

        if (semResposta) return true;

        if (respostas?.length) {
          const semRespostasEmTodasPerguntas =
            respostas?.length < perguntasSalvar?.length;

          if (semRespostasEmTodasPerguntas) return true;
          
          const semRespostasEmAlgumaPergunta = respostas.find(
            (item) => !item?.resposta || item?.resposta === "Selecione o grupo"
          );

          return !!semRespostasEmAlgumaPergunta;
        }

        return false;
      });

      if (estudanteSemResposta) return true;
    }

    if (
      grupo === "6a3d323a-2c44-4052-ba68-13a8dead299a" || // IAD - Leitura em voz alta
      grupo === "263b55b8-efa2-480c-80ad-f4e8f0935e12" // IAD - Produção de texto
    ) {
      const estudanteSemResposta = alunosMutaveis.find((estudante) => {
        const respostas = estudante?.respostas;
        const semRespostas = !respostas?.length;

        if (semRespostas) return true;

        const semRespostasEmAlgumaPergunta = respostas.find(
          (item) => !item?.resposta
        );

        return !!semRespostasEmAlgumaPergunta;
      });

      if (estudanteSemResposta) return true;
    }

    return false;
  };

  const validouEstudantesSemResposta = (
    grupo,
    alunosMutaveis,
    perguntasSalvar
  ) => {
    let continuar = true;

    const exibirModalErro = temEstudantesSemResposta(
      grupo,
      alunosMutaveis,
      perguntasSalvar
    );

    if (exibirModalErro) {
      showModalError({
        content: ALERTA_ESTUDANTE_SEM_RESPOSTA_SELECIONADA,
      });
      continuar = false;
    }

    return continuar;
  };

  const executarSalvamento = ({
    perguntasSalvar,
    alunosMutaveis,
    filtrosMutaveis,
    sequenciaOrdemSelecionada,
    novaOrdem,
    novoPeriodoId,
    periodoSelecionadoSalvar,
    grupo,
    idOrdem,
  }) => {
    alunosMutaveis.forEach((aluno) => {
      aluno.grupoId = grupo;
      aluno.ordemId = idOrdem;
      aluno.sequenciaOrdemSalva = sequenciaOrdemSelecionada;
    });
    
    const continuar = validouEstudantesSemResposta(
      grupo,
      alunosMutaveis,
      perguntasSalvar
    );

    if (!continuar) return false;

    try {
      return SalvaSondagemPortuguesAsync({
        alunos: alunosMutaveis,
        filtro: filtrosMutaveis,
        novaOrdem,
        novoPeriodoId,
      }).then(() => {
        dispatch(PortuguesStore.setar_emEdicao(false));
        return true;
      });
    } catch (e) {
      dispatch(pollStore.setLoadingSalvar(false));
      return false;
    }
  };

  useEffect(() => {
    if (emEdicao) {
      setarModoEdicaoPoll();
    } else {
      sairModoEdicaoPoll();
    }
  }, [emEdicao])

  useEffect(() => {
    dispatch(PortuguesStore.setar_ordem_selecionada(null));
    dispatch(PortuguesStore.setar_perguntas(null));
    dispatch(PortuguesStore.limpar_todas_ordens_selecionadas());
    const ehSondagemSemestral = filtrosBusca && filtrosBusca.anoLetivo >= 2024 && filtrosBusca.anoEscolar >= 4;
    dispatch(PortuguesStore.listarPeriodos(ehSondagemSemestral ? TIPO_PERIODO.SEMESTRE : TIPO_PERIODO.BIMESTRE));
    if (grupoSelecionado){
      dispatch(PortuguesStore.listarSequenciaOrdens({ ...filtrosBusca, grupoId: grupoSelecionado }));      
    }
  }, [grupoSelecionado])

  useEffect(() => {
    const grupo = grupos && grupoSelecionado && grupos.find(g => g.id === grupoSelecionado);

    if (grupo && !grupo.ordemVisivel)
      dispatch(PortuguesStore.setar_ordem_selecionada(ordens[0].id));

    if (grupo)
      dispatch(PortuguesStore.listarPerguntasPortugues(1, grupoSelecionado));

  }, [ordens])

  useEffect(() => {
    dispatch(PortuguesStore.salvar_filtros_consulta_salvamento({
      anoLetivo: filtros.schoolYear,
      anoEscolar: filtros.yearClassroom,
      codigoDre: filtros.dreCodeEol,
      codigoUe: filtros.schoolCodeEol,
      codigoTurma: filtros.classroomCodeEol,
      componenteCurricular: "c65b2c0a-7a58-4d40-b474-23f0982f14b1",
      ordemId: idOrdemSelecionada,
      periodoId: periodoSelecionado && periodoSelecionado.id,
      grupoId: grupoSelecionado,
    }));
  }, [filtros, idOrdemSelecionada, periodoSelecionado, grupoSelecionado]);

  useEffect(() => {
    dispatch(PortuguesStore.listarGrupos());
    dispatch(PortuguesStore.salvar_funcao_salvamento(executarSalvamento));

    return () => {
      dispatch(PortuguesStore.setar_alunos([]));
      dispatch(PortuguesStore.setar_periodos([]));
      dispatch(PortuguesStore.setar_grupos([]));
      dispatch(PortuguesStore.setar_emEdicao(false));
      dispatch(PortuguesStore.setar_ordem_selecionada(null));
      dispatch(PortuguesStore.limpar_todas_ordens_selecionadas());
      dispatch(PortuguesStore.selecionar_grupo(null));
      dispatch(PortuguesStore.salvar_funcao_salvamento(null));
      dispatch(PortuguesStore.setar_sequencia_ordens([]));
      sairModoEdicaoPoll();
    };
  }, []);

  return (
    <div className="container-fluid">
      <div className="row container-fluid">
        <Select
          lista={grupos}
          valorId={grupoSelecionado}
          className="col-md-2"
          onChangeSelect={onChangeGrupos}
        />
        <div className="col-md-10 d-flex justify-content-center">
          <SeletorDeOrdem ordens={ordens} onClick={onClickOrdem} ordemSelecionada={idOrdemSelecionada} ordensSalvas={sequenciasOrdens} />
        </div>
      </div>

      <div className="row container-fluid">
        {
          idOrdemSelecionada && idOrdemSelecionada !== "" && <TabelaAlunos periodos={periodos} grupoSelecionado={grupoSelecionado} filtros={filtrosBusca} salvar={salvar} idOrdemSelecionada={idOrdemSelecionada}></TabelaAlunos>
        }
      </div>
    </div>
  );
}

export default SondagemPortuguesAutoral;
