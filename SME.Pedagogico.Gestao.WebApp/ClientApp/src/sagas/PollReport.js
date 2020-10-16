import { takeLatest, call, put, all } from "redux-saga/effects";
import * as PollReport from "../store/PollReport";

export default function* () {
  yield all([
    takeLatest(PollReport.types.GET_POLL_REPORT_REQUEST, GetPollReportSaga),
    takeLatest(PollReport.types.PRINT_POLL_REPORT, PrintPollReportSaga),
  ]);
}

function* GetPollReportSaga({ parameters }) {
  try {
    const data = yield call(getPollReportData, parameters);

        if (data.status === 401)
            yield put({ type: PollReport.types.POLL_REPORT_REQUEST_NOT_FOUND });
        else {
            var pollReportResponse = null;
            if (parameters.discipline === "Língua Portuguesa" && parameters.classroomReport)
                pollReportResponse = {
                    data: data.results,
                    chartData: data.chartData
            }
            else if (!parameters.classroomReport) {
                if((Number(parameters.CodigoCurso)>=7 &&
                    parameters.discipline === "Matemática" &&
                    !parameters.proficiency) ||
                    (Number(parameters.CodigoCurso)>=4 &&
                    parameters.discipline === "Língua Portuguesa")){
                    pollReportResponse = {
                        data: data,
                        chartData: null
                    }   
                }else{
                    pollReportResponse = {
                        data: {
                            numerosResults: data.results.numerosResults,
                            ideaResults: data.results.ideaResults,
                            resultResults: data.results.resultResults
                        },
                        chartData: {
                            chartIdeaData: data.chartIdeaData,
                            chartNumberData: data.chartNumberData,
                            chartResultData: data.chartResultData
                        }
                    }
                }
            }  else {
              pollReportResponse = {
                data: data.results,
                chartData: data.chartData,
              };
            }

      yield put({
        type: PollReport.types.SET_POLL_REPORT_DATA,
        pollReportResponse,
      });
    }

    yield put({ type: PollReport.types.SHOW_POLL_REPORT_REQUEST });
  } catch (error) {
    yield put({ type: PollReport.types.POLL_REPORT_API_REQUEST_FAIL });
  }
}

function getPollReportData(parameters) {
  return fetch("/api/RelatorioSondagem/ObterDados", {
    method: "post",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(parameters),
  }).then((response) => response.json());
}

function* PrintPollReportSaga({ parameters }) {
  try {
    const data = yield call(fetch, "api/v1/relatorios/sync", {
      method: "post",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(parameters),
    });
    
   if(data.status === 200){
      const linkPdf = yield data.text();
      
      yield put({
        type: PollReport.types.SET_POLL_REPORT_LINK_PDF,
        linkPdf,
      });

      yield put({
        type: PollReport.types.SHOW_POLL_REPORT_MESSAGE_SUCCESS,
        showMessageSuccess: true,
      });   
    } else {
      yield put({
        type: PollReport.types.SHOW_POLL_REPORT_MESSAGE_SUCCESS,
        showMessageSuccess: false,
      }); 
    }
  } catch (error) {
    yield put({
      type: PollReport.types.SHOW_POLL_REPORT_MESSAGE_SUCCESS,
      showMessageSuccess: false,
    }); 
  } finally {
    yield put({
      type: PollReport.types.PRINTING_POLL_REPORT,
      printing: false,
    });
  }
}
