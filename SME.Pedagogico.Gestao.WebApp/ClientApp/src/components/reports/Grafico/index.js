import React, { useEffect } from "react";
import echarts from "echarts";
import { montarCampoToolTipGrafico } from "../../utils/utils";

function Grafico(props) {
  const { dados, id } = props;

  useEffect(() => construirGrafico(), [dados]);

  const format = (data) => {
    data = parseFloat(data);
    return data.toLocaleString("pt-BR");
  };

  const construirGrafico = () => {
    const myChart = echarts.init(document.getElementById(id));

    const dadosLabel = [];
    const dadosValores = [];

    dados.barras.forEach((item) => {
      dadosLabel.push(item.label);
      dadosValores.push(item.value);
    });

    myChart.setOption({
      tooltip: {
        formatter: function (params) {
          var val = format(params.value);
          return montarCampoToolTipGrafico(params.marker, params.name, val);
        },
      },
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
    <div className="d-flex flex-column col-12">
      <div
        className="d-flex justify-content-center align-items-center sc-gray"
        style={{ height: 35 }}
      >
        <div className="sc-text-size-1 font-weight-bold">
          {dados.nomeGrafico}
        </div>
      </div>
      <div
        className="d-flex flex-fill justify-content-center"
        style={{ position: "relative", top: -35 }}
      >
        <div>
          <div id={id} style={{ height: 400, width: 1024 }}></div>
        </div>
      </div>
    </div>
  );
}

export default Grafico;
