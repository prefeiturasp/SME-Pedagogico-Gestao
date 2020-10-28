import React from "react";
import GraficoCapacidadeLeitura from "./GraficoCapacidadeLeitura";

const GraficoConsolidadoCapacidadeLeitura = (props) => {
  const { dados } = props;

  return (
    <div>
      <div
        className="col-12 d-flex flex-fill justify-content-center align-items-center sc-gray mb-2"
        style={{ height: 35 }}
      >
        <div className="sc-text-size-1 font-weight-bold">{dados.ordem}</div>
      </div>
      <div className="row">
        {dados.perguntasGrafico.map((pergunta, index) => {
          return (
            <GraficoCapacidadeLeitura
              dados={pergunta}
              grupo={dados.ordem}
              index={index}
            />
          );
        })}
      </div>
    </div>
  );
};

export default GraficoConsolidadoCapacidadeLeitura;
