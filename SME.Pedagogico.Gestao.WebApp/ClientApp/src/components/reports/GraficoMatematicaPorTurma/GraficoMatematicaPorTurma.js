import React from "react";
import GraficoMatematica from "../GraficoMatematica/GraficoMatematica";

const GraficoMatematicaPorTurma = (props) => {
  const { dados, index } = props;

  return (
    <GraficoMatematica dados={dados} index={index}/>
  );
};

export default GraficoMatematicaPorTurma;
