import React, { useEffect } from "react";
import { TituloGrafico } from "./GraficoMatematicaPorTurma.css";
import echarts from "echarts";

const GraficoMatematicaPorTurma = (props) => {
  const { dados, index } = props;

  useEffect(() => construirGrafico(), [dados]);

  const construirGrafico = () => {
    const myChart = echarts.init(document.getElementById(`grafico-${index}`));

    const dadosLabel = [];
    const dadosValores = [];

    dados.barras.forEach((item) => {
      dadosLabel.push(item.label);
      dadosValores.push(item.value);
    });

    myChart.setOption({
      tooltip: {},
      xAxis: {
        type: "category",
        data: dadosLabel,
      },
      yAxis: {
        type: "value",
      },
      series: [
        {
          data: dadosValores,
          type: "bar",
          showBackground: true,
          itemStyle: {
            normal: {
              color: "#9C96F6",
            },
          },
          backgroundStyle: {
            color: "rgba(220, 220, 220, 0.8)",
          },
        },
      ],
    });
  };

  return (
    <div className="d-flex flex-column col-4">
      <TituloGrafico
        className="d-flex flex-fill justify-content-center align-items-center sc-gray"
        style={{ height: 35 }}
      >
        <div className="sc-text-size-1 font-weight-bold">
          {dados.nomeGrafico}
        </div>
      </TituloGrafico>
      <div
        className="d-flex flex-fill justify-content-center"
        style={{ position: "relative", top: -35 }}
      >
        <div>
          <div
            id={`grafico-${index}`}
            style={{ height: 400, width: 517 }}
          ></div>
        </div>
      </div>
    </div>
  );
};

export default GraficoMatematicaPorTurma;
