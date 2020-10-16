import React, { useEffect } from "react";
import echarts from "echarts";

const Teste = () => {
  const respostas = [
    { nome: "Resolveu corretamente", value: 10 },
    { nome: "Resolveu incorretamente", value: 62 },
    { nome: "Resolveu uma parte", value: 50 },
    { nome: "Não registrou", value: 18 },
    { nome: "Sem preenchimento", value: 20 },
  ];

  useEffect(() => {
    var myChart = echarts.init(document.getElementById("id-teste"));
    myChart.setOption({
      tooltip: {
        trigger: "axis",
        axisPointer: {
          type: "line",
        },
      },
      xAxis: {
        type: "category",
        data: respostas.map((c) => c.nome),
        splitLine: {
          show: true,
        },
      },
      yAxis: {},
      series: [
        {
          data: respostas.map((c) => c.value),
          name: "Alunos",
          type: "bar",
          itemStyle: {
            normal: {
              color: "#0077BE",
            },
          },
        },
      ],
    });
  }, []);

  return (
    <div>
      <div
        className="d-flex justify-content-center align-items-center sc-gray mx-4"
        style={{ height: 35 }}
      >
        <div className="sc-text-size-1 font-weight-bold">Nome do grafico</div>
      </div>
      <div id={"id-teste"} style={{ height: 400, width: 1024 }}></div>
    </div>
  );
};

export default Teste;
