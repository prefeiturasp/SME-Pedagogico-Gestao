import React, { useEffect, useMemo } from "react";
import Select from "./select";
import { actionCreators as PortuguesStore } from "../../../store/SondagemPortuguesStore";
import { useSelector, useDispatch } from "react-redux";
import SeletorDeOrdem from "./seletorDeordem";
import Mocks from "./mocks";
import TabelaAlunos from "./tabelaAlunos";

function SondagemPortuguesAutoral() {
  const dispatch = useDispatch();

  const grupoSelecionado = useSelector(
    (store) => store.sondagemPortugues.grupoSelecionado
  );

  const filtros = useSelector((store) => store.poll.selectedFilter);

  const idOrdemSelecionada = useSelector((store) => store.sondagemPortugues.ordemSelecionada);

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

  const onChangeGrupos = (grupoId) => {
    dispatch(PortuguesStore.selecionar_grupo(grupoId));
  };

  const onClickOrdem = (id) => {
    dispatch(PortuguesStore.inserir_sequencia_ordem(id));
  };

  useEffect(() => {
    dispatch(PortuguesStore.listarGrupos());    
    dispatch(PortuguesStore.setar_alunos(Mocks.alunos));

    return () => {
      dispatch(PortuguesStore.setar_alunos([]));
      dispatch(PortuguesStore.setar_periodos([]));
      dispatch(PortuguesStore.setar_grupos([]));
      dispatch(PortuguesStore.setar_ordem_selecionada(null));
      dispatch(PortuguesStore.limpar_todas_ordens_selecionadas());
      dispatch(PortuguesStore.selecionar_grupo(null));
    };
  }, []);

  useEffect(() => {
    console.log(ordens);
  }, [ordens]);

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
          idOrdemSelecionada && idOrdemSelecionada !== "" && <TabelaAlunos periodos={periodos} filtros={filtrosBusca} idOrdemSelecionada={idOrdemSelecionada}></TabelaAlunos>
        }
      </div>
    </div>
  );
}

export default SondagemPortuguesAutoral;
