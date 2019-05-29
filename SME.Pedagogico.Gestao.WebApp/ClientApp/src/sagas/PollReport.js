import { takeLatest, call, put, all } from "redux-saga/effects";
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
            var pollReportResponse = {
                data: data.results,
                chartData: data.chartData
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