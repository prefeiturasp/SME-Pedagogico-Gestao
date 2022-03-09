import React from "react";

import PollReportBreadcrumb from "../PollReportBreadcrumb";
import PollReportPortugueseChart from "../PollReportPortugueseChart";
import PollReportMathChart from "../PollReportMathChart";
import PollReportMathNumbersChart from "../PollReportMathNumbersChart";
import PollReportMathChartClassroom from "../PollReportMathChartClassroom";
import GraficoPorTurmaLeituraVozAlta from "../GraficoPorTurmaLeituraVozAlta/GraficoPorTurmaLeituraVozAlta";
import GraficoMatematicaPorTurma from "../GraficoMatematicaPorTurma/GraficoMatematicaPorTurma";
import GraficoPorTurmaProducaoTexto from "../GraficoPorTurmaProducaoTexto/GraficoPorTurmaProducaoTexto";
import GraficoPorTurmaCapacidadeLeitura from "../GraficoPorTurmaCapacidadeLeitura/GraficoPorTurmaCapacidadeLeitura";
import GraficoConsolidadoLeituraVozAlta from "../GraficoConsolidadoLeituraVozAlta";
import GraficoConsolidadoProducaoTexto from "../GraficoConsolidadoProducaoTexto";
import GraficoConsolidadoMatematica from "../GraficoConsolidadoMatematica/GraficoConsolidadoMatematica";
import GraficoConsolidadoCapacidadeLeitura from "../GraficoConsolidadoCapacidadeLeitura";

import { GrupoDto } from "../../dtos/grupoDto";
import { DISCIPLINES_ENUM } from "../../../Enums";

export const montarGraficos = (
  props,
  chartData,
  classroomReport,
  indexes,
  numbers
) => {
  const montarGraficoPorTurmaPortuguesAcimaDoQuartoAno = (graficos) => {
    switch (props.pollReport.selectedFilter.grupoId) {
      case GrupoDto.CAPACIDADE_LEITURA:
        return (
          <div className="row">
            {graficos.map((dados) => {
              return <GraficoPorTurmaCapacidadeLeitura dados={dados} />;
            })}
          </div>
        );
      case GrupoDto.LEITURA_EM_VOZ_ALTA:
        return (
          <div className="row">
            {graficos.map((dados) => {
              return <GraficoPorTurmaLeituraVozAlta dados={dados} />;
            })}
          </div>
        );
      case GrupoDto.PRODUCAO_DE_TEXTO:
        return (
          <div className="mb-4">
            {graficos.map((dados) => {
              return <GraficoPorTurmaProducaoTexto dados={dados} />;
            })}
          </div>
        );
      default:
        break;
    }
  };

  const montarGraficoConsolidadosPortuguesAcimaDoQuartoAno = (graficos) => {
    switch (props.pollReport.selectedFilter.grupoId) {
      case GrupoDto.CAPACIDADE_LEITURA:
        return (
          <div className="row">
            {graficos.map((dados) => {
              return <GraficoConsolidadoCapacidadeLeitura dados={dados} />;
            })}
          </div>
        );
      case GrupoDto.LEITURA_EM_VOZ_ALTA:
        return (
          <div className="row">
            {graficos.map((dados) => {
              return <GraficoConsolidadoLeituraVozAlta dados={dados} />;
            })}
          </div>
        );
      case GrupoDto.PRODUCAO_DE_TEXTO:
        return (
          <div className="mb-4">
            {graficos.map((dados) => {
              return <GraficoConsolidadoProducaoTexto dados={dados} />;
            })}
          </div>
        );
      default:
        break;
    }
  };

  const montarPortugues = () => {
    const codigoCursoMaiorIgualQuatro =
      Number(props.pollReport.selectedFilter.CodigoCurso) >= 4;

    if (codigoCursoMaiorIgualQuatro) {
      if (classroomReport) {
        return montarGraficoPorTurmaPortuguesAcimaDoQuartoAno(chartData);
      }
      return montarGraficoConsolidadosPortuguesAcimaDoQuartoAno(chartData);
    }
    return <PollReportPortugueseChart data={chartData} />;
  };

  const montarGraficoMatematicaAutoral = () => {
    if (classroomReport) {
      return chartData.map((dados, index) => (
        <GraficoMatematicaPorTurma dados={dados} index={index} />
      ));
    }

    return chartData.map((dados, index) => (
      <GraficoConsolidadoMatematica dados={dados} index={index} />
    ));
  };

  const montarGraficosAlfabetizacao = () => {
    const ehNumeros = props.pollReport.selectedFilter.proficiency === "Números";

    //Consilidado de Numeros
    if (!classroomReport && ehNumeros) {
      return <PollReportMathNumbersChart data={chartData.chartNumberData} />;
    }

    //Consilidado de Aditivo e Multiplicativo
    if (!classroomReport && !ehNumeros) {
      return indexes.map((index) => {
        const chartId = "ordem" + chartData.chartIdeaData[index].order;
        return (
          <PollReportMathChart
            key={chartId}
            chartIds={[chartId + "idea" + index, chartId + "result" + index]}
            data={chartData.totals[index]}
          />
        );
      });
    }

    // Por Turma de Numeros
    if (classroomReport && ehNumeros && chartData && chartData.length) {
      return (
        Array.isArray(chartData) && (
          <PollReportMathChartClassroom data={chartData} numbers={numbers} />
        )
      );
    }

    // Por Turma Aditivo e Multiplicativo
    if (classroomReport && !ehNumeros && chartData && chartData.length) {
      return (
        Array.isArray(chartData) &&
        chartData.map((item, index) => {
          const order =
            item.name !== null ? item.name.replace(" ", "").toLowerCase() : "";
          const chart1Id = order + "-ideaChart" + index;
          const chart2Id = order + "-resultChart" + index;
          return (
            <PollReportMathChartClassroom
              data={item}
              chartIds={[chart1Id, chart2Id]}
              numbers={numbers}
            />
          );
        })
      );
    }
  };

  const montarDados = () => {
    const ehPortugues =
      props.pollReport.selectedFilter.discipline ===
      DISCIPLINES_ENUM.DISCIPLINA_PORTUGUES.Descricao;
    const ehMatematica =
      props.pollReport.selectedFilter.discipline ===
      DISCIPLINES_ENUM.DISCIPLINA_MATEMATICA.Descricao;
    const codigoCursoMaiorIgualSete =
      Number(props.pollReport.selectedFilter.CodigoCurso) >= 7;

    if (ehPortugues) {
      return montarPortugues();
    }
    if (ehMatematica && codigoCursoMaiorIgualSete) {
      return <div className="row">{montarGraficoMatematicaAutoral()}</div>;
    }

    return <div className="mt-4">{montarGraficosAlfabetizacao()}</div>;
  };

  return (
    <>
      <PollReportBreadcrumb className="mt-5" name="Gráfico" />
      {!!chartData && montarDados()}
    </>
  );
};
