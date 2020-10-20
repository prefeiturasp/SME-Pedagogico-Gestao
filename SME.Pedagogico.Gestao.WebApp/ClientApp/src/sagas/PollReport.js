﻿import { takeLatest, call, put, all, select } from "redux-saga/effects";
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

async function fetchWithTimeout(url, options, delay) {
  const timer = new Promise((resolve) => {
    setTimeout(resolve, delay, {
      timeout: true,
    });
  });
  const response = await Promise.race([
    fetch(url, options),
    timer
  ]);
  return response;
}

function* setError(mensagem) {
  yield put({
    type: PollReport.types.SET_POLL_REPORT_LINK_PDF,
    linkPdf: "",
  });

  yield put({
    type: PollReport.types.SHOW_POLL_REPORT_MESSAGE_ERROR,
    showMessageError: true,
    messageError: mensagem,
  });  
} 

function* resetPollReport () {
  yield put({
    type: PollReport.types.CANCEL_POLL_REPORT_REQUEST,
    cancelPollReportRequest: false,
  });

  yield put({
    type: PollReport.types.SET_POLL_REPORT_LINK_PDF,
    linkPdf: "",
  });
}

function* PrintPollReportSaga({ parameters }) {
  try {
    yield call(resetPollReport)
    
    const data = yield call(fetchWithTimeout, "api/v1/relatorios/sync", {
      method: "post",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(parameters),
    }, 300000);
    
    const { pollReport } = yield select();
    const { cancelPollReportRequest } = pollReport; 
    let mensagem ="Erro ao gerar relatório. Tente novamente mais tarde."  
       
    if(data.status === 200){
      const linkPdf = yield data.text();
     
      yield put({
        type: PollReport.types.SET_POLL_REPORT_LINK_PDF,
        linkPdf,
      });

      if(!cancelPollReportRequest){
        yield put({
          type: PollReport.types.SHOW_POLL_REPORT_MESSAGE_SUCCESS,
          showMessageSuccess: true,
        });   
      }
      
      return;
    } 

    if(!cancelPollReportRequest && (data.status === 500 || data.status === 601) ){
      const response = yield data.json();
      if(response) {
         mensagem = response.mensagens.reduce(msg => msg.concat());         
      }
    }
    
    if(!cancelPollReportRequest){
      yield call(setError, mensagem);      
    }

  } catch (error) {   
    const { pollReport } = yield select();
    const { cancelPollReportRequest } = pollReport;   
    let mensagem = "Erro ao gerar relatório. Tente novamente mais tarde."  
    
    if(!cancelPollReportRequest){
      yield call(setError, mensagem);      
    }  

  } finally {
    yield put({
      type: PollReport.types.PRINTING_POLL_REPORT,
      printing: false,
    });

    yield put({
      type: PollReport.types.CANCEL_POLL_REPORT_REQUEST,
      cancelPollReportRequest: false,
    });
  }
}
