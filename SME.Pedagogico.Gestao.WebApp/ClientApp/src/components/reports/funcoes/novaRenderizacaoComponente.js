import React from "react";

import PollReportBreadcrumb from "../PollReportBreadcrumb";
import RelatorioMatematicaConsolidado from "../RelatorioMatematicaConsolidado";
import RelatorioMatematicaConsolidadoCACM from "../RelatorioMatematicaConsolidadoCACM";
import GraficoConsolidadoMatematica from "../GraficoConsolidadoMatematica/GraficoConsolidadoMatematica";
import GraficoMatematicaCACM from "../GraficoMatematicaCACM/GraficoMatematicaCACM";

export const novaRenderizacaoComponente = (props) => {
  const { data, selectedFilter } = props.pollReport;
  const { CodigoCurso, proficiency } = selectedFilter;

  const ehAlfabetizacaoNumeros = CodigoCurso < 4 && proficiency !== "Números";

  const montarPlanilha = () => {
    const Componente = ehAlfabetizacaoNumeros
      ? RelatorioMatematicaConsolidadoCACM
      : RelatorioMatematicaConsolidado;

    return (
      data &&
      data.perguntas && (
        <>
          <PollReportBreadcrumb className="mt-4" name="Planilha" />
          {data.perguntas.map((dados) => (
            <Componente dados={dados} />
          ))}
        </>
      )
    );
  };

  const montarGraficos = () => {
    const Componente = ehAlfabetizacaoNumeros
      ? GraficoMatematicaCACM
      : GraficoConsolidadoMatematica;
    const classes = ehAlfabetizacaoNumeros ? "" : "row";

    return (
      data &&
      data.graficos && (
        <>
          <PollReportBreadcrumb className="mt-4" name="Sondagem Gráfico" />
          <div className={classes}>
            {data.graficos.map((dados, index) => (
              <Componente dados={dados} index={index} />
            ))}
          </div>
        </>
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
