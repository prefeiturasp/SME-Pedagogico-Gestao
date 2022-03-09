import React from "react";
import GraficoMatematica from "../GraficoMatematica/GraficoMatematica";

const GraficoConsolidadoMatematica = (props) => {
  const { dados, index, esconderTresLinhas } = props;

  return (
    <GraficoMatematica
      dados={dados}
      index={index}
      esconderTresLinhas={esconderTresLinhas}
    />
  );
};

export default GraficoConsolidadoMatematica;
