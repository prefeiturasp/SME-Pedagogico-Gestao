import React from "react";

import PollReportBreadcrumb from "../PollReportBreadcrumb";
import RelatorioMatematicaConsolidado from "../RelatorioMatematicaConsolidado";
import GraficoConsolidadoMatematica from "../GraficoConsolidadoMatematica/GraficoConsolidadoMatematica";

export const novaRenderizacaoComponente = (props) => {
  const { data, selectedFilter } = props.pollReport;
  const { CodigoCurso, proficiency } = selectedFilter;

  const montarPlanilha = () => {
    if (CodigoCurso < 4 && proficiency !== "Números") {
      return "menor P";
    }
    return (
      data &&
      data.perguntas && (
        <>
          <PollReportBreadcrumb className="mt-4" name="Planilha" />
          {data.perguntas.map((dados) => (
            <RelatorioMatematicaConsolidado dados={dados} />
          ))}
        </>
      )
    );
  };

  const montarGraficos = () => {
    if (CodigoCurso < 4 && proficiency !== "Números") {
      return "menor G";
    }
    return (
      data &&
      data.graficos && (
        <div className="row">
          {data.graficos.map((dados, index) => (
            <GraficoConsolidadoMatematica dados={dados} index={index} />
          ))}
        </div>
      )
    );
  };

  return (
    <>
      {montarPlanilha()}
      {montarGraficos()}
    </>
  );
};
