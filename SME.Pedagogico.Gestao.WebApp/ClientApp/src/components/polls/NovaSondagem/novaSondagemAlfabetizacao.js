import React from "react";
import { useSelector } from "react-redux";

import SondagemClassSelected from "../component/SondagemClassSelected";
import NovaSondagemCACM from "./novaSondagemCACM";
import NovaSondagemMatematicaAutoral from "../../classRecord/NovaSondagemMatematicaAutoral";

const NovaSondagemAlfabetizacao = () => {
  const bimestre = useSelector((store) => store.poll.bimestre);
  const tipoSondagem = useSelector((store) => store.poll.pollTypeSelected);

  const montarDados = () => {
    if (tipoSondagem === "Numeric") {
      return <NovaSondagemMatematicaAutoral />;
    }
    return <NovaSondagemCACM />;
  };

  if (!bimestre) return "";
  return (
    <>
      <div id="wrapper">
        <SondagemClassSelected />
      </div>
      {montarDados()}
    </>
  );
};

export default NovaSondagemAlfabetizacao;
