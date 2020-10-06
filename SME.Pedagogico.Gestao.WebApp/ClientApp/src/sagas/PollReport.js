﻿import { takeLatest, call, put, all } from "redux-saga/effects";
import * as PollReport from '../store/PollReport';

export default function* () {
    yield all([
        takeLatest(PollReport.types.GET_POLL_REPORT_REQUEST, GetPollReportSaga),
    ]);
}

function* GetPollReportSaga({ parameters }) {
    try {
        const data = yield call(getPollReportData, parameters);

        if (data.status === 401)
            yield put({ type: PollReport.types.POLL_REPORT_REQUEST_NOT_FOUND });
        else {
            var pollReportResponse = null;
            if (parameters.discipline !== "Matemática")
                pollReportResponse = {
                    data: data.results,
                    chartData: data.chartData
            }
            else if (parameters.classroomReport === false) {
                if(Number(parameters.CodigoCurso)>=7 &&
                    parameters.discipline === "Matemática" &&
                    !parameters.proficiency){
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
            }

            else {
                pollReportResponse = {
                    data: data.results,
                    chartData: data.chartData
                };
            }

            yield put({ type: PollReport.types.SET_POLL_REPORT_DATA, pollReportResponse });
        }

        yield put({ type: PollReport.types.SHOW_POLL_REPORT_REQUEST });
    }
    catch (error) {
        yield put({ type: PollReport.types.POLL_REPORT_API_REQUEST_FAIL });
    }
}

function getPollReportData(parameters) {
    return (fetch("/api/RelatorioSondagem/ObterDados", {
        method: "post",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(parameters)
    })
        .then(response => response.json()));
}