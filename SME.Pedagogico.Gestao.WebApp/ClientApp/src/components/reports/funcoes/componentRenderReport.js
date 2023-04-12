import React from "react";
import { montarPlanilha } from "./montarPlanilha";
import { montarGraficos } from "./montarGraficos";

export const componentRenderReport = (props) => {
  let reportData = [];
  let chartData = [];
  let indexes = [];
  let numbers = false;
  const classroomReport = props.pollReport.selectedFilter.classroomReport;
  
  if (props.pollReport.showReport === true) {    
    const codigoCurso = props.pollReport.selectedFilter.CodigoCurso;
    if (codigoCurso >= 1 && codigoCurso <= 3 || (props.pollReport.data && props.pollReport.data.results)) {
      reportData = props.pollReport.data && props.pollReport.data.results ? props.pollReport.data.results : [];
      chartData = props.pollReport.data && props.pollReport.data.chartData ?  props.pollReport.data.chartData: [];      
    } else {
      reportData = props.pollReport.data;
      chartData = props.pollReport.chartData;
    }
  }

  if (props.pollReport.showReport === true) {
    if (
      chartData &&
      chartData.chartIdeaData !== undefined &&
      chartData.chartIdeaData.length > 0
    ) {
      chartData.totals = [];

      for (let i = 0; i < chartData.chartIdeaData.length; i++) {
        indexes.push(i);
        chartData.totals.push({
          name: "ORDEM " + chartData.chartIdeaData[i].order,
          idea: new Array(chartData.chartIdeaData[i].idea.length),
          result: new Array(chartData.chartResultData[i].result.length),
        });

        for (let j = 0; j < chartData.chartIdeaData[i].idea.length; j++) {
          switch (chartData.chartIdeaData[i].idea[j].description) {
            case "Acertou":
              chartData.totals[i].idea[0] =
                chartData.chartIdeaData[i].idea[j].quantity;
              break;
            case "Errou":
              chartData.totals[i].idea[1] =
                chartData.chartIdeaData[i].idea[j].quantity;
              break;
            case "Não Resolveu":
              chartData.totals[i].idea[2] =
                chartData.chartIdeaData[i].idea[j].quantity;
              break;
            case "Sem preenchimento":
              chartData.totals[i].idea[3] =
                chartData.chartIdeaData[i].idea[j].quantity;
              break;
            default:
              break;
          }
        }

        for (let j = 0; j < chartData.chartResultData[i].result.length; j++) {
          switch (chartData.chartResultData[i].result[j].description) {
            case "Acertou":
              chartData.totals[i].result[0] =
                chartData.chartResultData[i].result[j].quantity;
              break;
            case "Errou":
              chartData.totals[i].result[1] =
                chartData.chartResultData[i].result[j].quantity;
              break;
            case "Não Resolveu":
              chartData.totals[i].result[2] =
                chartData.chartResultData[i].result[j].quantity;
              break;
            case "Sem preenchimento":
              chartData.totals[i].result[3] =
                chartData.chartResultData[i].result[j].quantity;
              break;
            default:
              break;
          }
        }
      }
    }
  }

  if (
    reportData &&
    reportData !== [] &&
    reportData.length > 0 &&
    reportData[0].poll !== undefined
  )
    if (reportData[0].poll[0].order === 0) numbers = true;

  return (
    <>
      {props.pollReport.showReport ? (
        <div>
          {montarPlanilha(props, reportData, classroomReport)}
          {montarGraficos(props, chartData, classroomReport, indexes, numbers)}
        </div>
      ) : null}
    </>
  );
};
