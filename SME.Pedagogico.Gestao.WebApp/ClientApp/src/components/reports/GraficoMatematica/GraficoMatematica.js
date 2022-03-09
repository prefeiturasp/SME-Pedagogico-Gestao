import React, { useCallback, useEffect } from "react";
import echarts from "echarts";
import { montarCampoToolTipGrafico } from "../../utils/utils";

const GraficoMatematica = (props) => {
  const { dados, index, esconderTresLinhas } = props;

  const classes = esconderTresLinhas ? "" : "col-xl-4";

  useEffect(() => construirGrafico(), [construirGrafico, dados]);

  const format = (data) => {
    data = parseFloat(data);
    return data.toLocaleString("pt-BR");
  };

  const posicaoToolTip = (posicaoX, texto) => {
    return texto.length > 50 ? posicaoX - 100 : posicaoX - 100;
  };

  const construirGrafico = useCallback(() => {
    const myChart = echarts.init(document.getElementById(`grafico-${index}`));

    const dadosLabel = [];
    const dadosValores = [];

    dados.barras.forEach((item) => {
      dadosLabel.push(item.label);
      dadosValores.push(item.value);
    });

    myChart.setOption({
      tooltip: {
        position: function (posicao, conteudo) {
          return [posicaoToolTip(posicao[0], conteudo.name), 300];
        },
        formatter: function (params) {
          var valor = format(params.value);
          return montarCampoToolTipGrafico(params.marker, params.name, valor);
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
  }, [dados.barras, index]);

  return (
    <div className={`d-flex flex-column col-sm-6 ${classes}`}>
      <div
        className="d-flex flex-fill justify-content-center align-items-center sc-gray"
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
          <div
            id={`grafico-${index}`}
            style={{ height: 400, width: 517 }}
          ></div>
        </div>
      </div>
    </div>
  );
};

export default GraficoMatematica;
