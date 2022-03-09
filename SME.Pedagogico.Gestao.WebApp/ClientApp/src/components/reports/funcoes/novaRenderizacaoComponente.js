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
          <PollReportBreadcrumb className="mt-5" name="Planilha" />
          {data.perguntas.map((dados, index) => (
            <Componente dados={dados} key={index} />
          ))}
        </>
      )
    );
  };

  const montarGraficos = () => {
    const Componente = ehAlfabetizacaoNumeros
      ? GraficoMatematicaCACM
      : GraficoConsolidadoMatematica;
    const classes = ehAlfabetizacaoNumeros ? "mt-4" : "row mt-4";

    return (
      data &&
      data.graficos && (
        <>
          <PollReportBreadcrumb className="mt-5" name="Sondagem Gráfico" />
          <div className={classes}>
            {data.graficos.map((dados, index) => (
              <Componente dados={dados} index={index} key={index} />
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
