import React, { useEffect, useMemo } from "react";
import Select from "./select";
import { actionCreators as PortuguesStore } from "../../../store/SondagemPortuguesStore";
import { useSelector, useDispatch } from "react-redux";
import SeletorDeOrdem from "./seletorDeordem";

const gruposLista = [
  {
    id: "e27b99a3-789d-43fb-a962-7df8793622b1",
    descricao: "Capacidade de leitura",
    ordemVisivel: true,
    ordem: [
      {
        id: "ad53a26a-e9d5-4732-a086-212dc20f3af7",
        descricao: "Ordem do argumentar",
        ordenacao: 1,
      },
      {
        id: "2382e530-c426-46fe-83b6-84461257aabc",
        descricao: "Ordem da descrição de ações",
        ordenacao: 2,
      },
      {
        id: "9913da2a-dc3d-45e6-a1e5-34b386cc1202",
        descricao: "Ordem do discurso em versos",
        ordenacao: 3,
      },
      {
        id: "d0fcd18f-d626-4ca1-900d-6f85b1ad690f",
        descricao: "Ordem do expor",
        ordenacao: 4,
      },
      {
        id: "f4213141-94b9-4b91-a65f-56348a3f8399",
        descricao: "Ordem do narrar",
        ordenacao: 5,
      },
      {
        id: "9467c76f-4b87-43be-93d6-d243e6a856ec",
        descricao: "Ordem do relatar",
        ordenacao: 6,
      },
    ],
  },
];

function SondagemPortuguesAutoral() {
  const dispatch = useDispatch();

  const grupoSelecionado = useSelector(
    (store) => store.sondagemPortugues.grupoSelecionado
  );

  const grupos = useSelector((store) => store.sondagemPortugues.grupos);

  const ordens = useMemo(() => {
    if (
      !grupoSelecionado ||
      grupoSelecionado === "" ||
      !grupos ||
      grupos.length === 0
    )
      return [];

    console.log(grupoSelecionado);
    console.log(grupos);

    const grupo = grupos.find((grupo) => grupo.id === grupoSelecionado);

    return grupo.ordem;
  }, [grupoSelecionado, grupos]);

  const onChangeGrupos = (grupoId) => {
    dispatch(PortuguesStore.selecionar_grupo(grupoId));
  };

  useEffect(() => {
    dispatch(PortuguesStore.setar_grupos(gruposLista));
  }, []);

  useEffect(() => {
    console.log(ordens);
  }, [ordens]);

  return (
    <div className="container-fluid">
      <Select
        lista={grupos}
        valorId={grupoSelecionado}
        onChangeSelect={onChangeGrupos}
      />
      <SeletorDeOrdem ordens={ordens} />
    </div>
  );
}

export default SondagemPortuguesAutoral;
