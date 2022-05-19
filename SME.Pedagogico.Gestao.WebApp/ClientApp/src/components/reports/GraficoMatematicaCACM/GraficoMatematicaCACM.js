import React, { useCallback, useEffect } from "react";
import echarts from "echarts";
import { montarCampoToolTipGrafico } from "../../utils/utils";

const GraficoMatematicaCACM = (props) => {
  const { dados, index } = props;

  useEffect(() => construirGrafico(), [construirGrafico, dados]);

  const format = (data) => {
    data = parseFloat(data);
    return data.toLocaleString("pt-BR");
  };

  const posicaoToolTip = (posicaoX, texto) => {
    return texto.length > 50 ? posicaoX - 100 : posicaoX - 100;
  };

  const construirGrafico = useCallback(() => {
    dados &&
      dados.listaDeGrafico &&
      dados.listaDeGrafico.forEach(({ nomeGrafico, barras }, indexGrafico) => {
        const myChart = echarts.init(
          document.getElementById(`grafico-${nomeGrafico}-${index}`)
        );
        const dadosValores = [];
        const dadosLabel = [];
        const corGrafico = indexGrafico % 2 === 0 ? "#9C96F6" : "#0077BE";

        barras.forEach((item) => {
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
              return montarCampoToolTipGrafico(
                params.marker,
                params.name,
                valor
              );
            },
          },
          xAxis: {
            type: "category",
            data: dadosLabel,
            show: false,
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
                  color: corGrafico,
                },
              },
              backgroundStyle: {
                color: "rgba(220, 220, 220, 0.8)",
              },
            },
          ],
        });
      });
  }, [dados, index]);

  const ChartTitle = (props) => {
    return (
      <div
        className="d-flex flex-fill justify-content-center align-items-center sc-gray"
        style={{ height: 35 }}
      >
        <div className="sc-text-size-1 font-weight-bold">{props.title}</div>
      </div>
    );
  };

  const ChartLabel = (props) => {
    return (
      <div className="mx-5" style={{ position: "relative", top: -30 }}>
        <div
          className="d-flex justify-content-center border border-top-0"
          style={{ height: 7 }}
        ></div>
        <div className="d-flex justify-content-center sc-text-size-1 text-muted">
          {props.label}
        </div>
      </div>
    );
  };

  return (
    <div className="d-flex flex-column">
      <ChartTitle
        title={`ORDEM ${dados.ordenacao} - ${dados.nome.toUpperCase()}`}
      />
      <div
        className="d-flex flex-fill justify-content-center"
        style={{ position: "relative", top: -35 }}
      >
        {dados &&
          dados.listaDeGrafico &&
          dados.listaDeGrafico.map(({ nomeGrafico }, indexGrafico) => (
            <React.Fragment key={indexGrafico}>
              <div>
                <div
                  id={`grafico-${nomeGrafico}-${index}`}
                  style={{ height: 400, width: 517 }}
                ></div>
                <ChartLabel label={nomeGrafico} />
              </div>
            </React.Fragment>
          ))}
      </div>
    </div>
  );
};

export default GraficoMatematicaCACM;
