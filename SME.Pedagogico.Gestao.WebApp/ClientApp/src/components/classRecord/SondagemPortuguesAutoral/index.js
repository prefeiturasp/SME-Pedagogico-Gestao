import React, { useEffect, useMemo } from "react";
import Select from "./select";
import { actionCreators as PortuguesStore } from "../../../store/SondagemPortuguesStore";
import { useSelector, useDispatch } from "react-redux";
import SeletorDeOrdem from "./seletorDeordem";
import TabelaAlunos from "./tabelaAlunos";
import { actionCreators as dataStore } from "../../../store/Data";
import { actionCreators as pollStore } from "../../../store/Poll";

function SondagemPortuguesAutoral() {
  const dispatch = useDispatch();

  const grupoSelecionado = useSelector(
    (store) => store.sondagemPortugues.grupoSelecionado
  );

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
      grupos.length === 0
    )
      return [];

    const grupo = grupos.find((grupo) => grupo.id === grupoSelecionado);

    return grupo.ordem;
  }, [grupoSelecionado, grupos]);

  const onChangeGrupos = (grupoId) => {
    dispatch(PortuguesStore.selecionar_grupo(grupoId));
  };

  const setarModoEdicaoPoll = () => {
    dispatch(dataStore.set_new_data_state());
    dispatch(pollStore.setDataToSaveTrue());
  };

  const sairModoEdicaoPoll = () => {
    dispatch(dataStore.reset_new_data_state());
    dispatch(pollStore.set_poll_data_saved_state());
  };


  const onClickOrdem = (id) => {
    if (emEdicao) {
      salvar({ novaOrdem: id });
      return;
    }

    dispatch(PortuguesStore.setar_ordem_selecionada(id));
    dispatch(PortuguesStore.listarAlunosPortugues({ ...filtrosBusca, ordemId: id }));
  };

  const salvar = ({ novaOrdem, novoPeriodoId }) => {
    let alunosMutaveis = Object.assign([], alunos);
    let filtrosMutaveis = Object.assign({}, filtrosBusca);

    const sequenciaOrdemSelecionada = sequenciasOrdens ? sequenciasOrdens.findIndex(sequencia => sequencia === idOrdemSelecionada) : 0;

    executarSalvamento({ perguntasSalvar: perguntas, alunosMutaveis, filtrosMutaveis, sequenciaOrdemSelecionada, novaOrdem, periodoSelecionadoSalvar: periodoSelecionado, novoPeriodoId, idOrdem: idOrdemSelecionada, grupo: grupoSelecionado });
  }

  const executarSalvamento = ({ perguntasSalvar, alunosMutaveis, filtrosMutaveis, sequenciaOrdemSelecionada, novaOrdem, novoPeriodoId, periodoSelecionadoSalvar, grupo, idOrdem }) => {
    perguntasSalvar.forEach((pergunta) => {

      const respostaSalvar = {
        resposta: null,
        pergunta: pergunta.id,
        periodoId: periodoSelecionadoSalvar && periodoSelecionadoSalvar.id
      };

      alunosMutaveis.forEach(aluno => {

        aluno.grupoId = grupo;
        aluno.ordemId = idOrdem;
        aluno.sequenciaOrdemSalva = sequenciaOrdemSelecionada + 1;

        if (!aluno.respostas || aluno.respostas.length === 0) {
          aluno.respostas = [];
          aluno.respostas.push(respostaSalvar);
          return;
        }

        const index = aluno.respostas.findIndex(resposta => {
          return resposta => resposta.perguntaId === pergunta.id && resposta.periodoId === periodoSelecionadoSalvar.id;
        });

        if (index !== -1)
          return;

        aluno.respostas.push(respostaSalvar);
      });

    });

    dispatch(PortuguesStore.salvarSondagemPortugues({ alunos: alunosMutaveis, filtro: filtrosMutaveis, novaOrdem, novoPeriodoId }));
    dispatch(PortuguesStore.setar_emEdicao(false));
  }

  useEffect(() => {
    if (emEdicao) {
      setarModoEdicaoPoll();
    } else {
      sairModoEdicaoPoll();
    }
  }, [emEdicao])

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
    }));
  }, [filtros, idOrdemSelecionada, periodoSelecionado]);

  useEffect(() => {
    dispatch(PortuguesStore.listarGrupos());
    dispatch(PortuguesStore.salvar_funcao_salvamento(executarSalvamento));

    return () => {
      dispatch(PortuguesStore.setar_alunos([]));
      dispatch(PortuguesStore.setar_periodos([]));
      dispatch(PortuguesStore.setar_grupos([]));
      dispatch(PortuguesStore.setar_ordem_selecionada(null));
      dispatch(PortuguesStore.limpar_todas_ordens_selecionadas());
      dispatch(PortuguesStore.selecionar_grupo(null));
      dispatch(PortuguesStore.salvar_funcao_salvamento(null));

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
      </div>
      <div className="row d-flex justify-content-center">
        <SeletorDeOrdem ordens={ordens} onClick={onClickOrdem} ordemSelecionada={idOrdemSelecionada} />
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
