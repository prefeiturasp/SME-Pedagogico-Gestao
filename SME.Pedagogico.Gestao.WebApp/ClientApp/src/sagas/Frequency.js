import { takeLatest, call, put } from "redux-saga/effects";
import * as Frequency from '../store/Frequency';

export default function* () {
    yield takeLatest(Frequency.types.EFFECT_FREQUENCY, UserSaga);
}

function* UserSaga({ efetiveFrequency }) {
    try {
        const data = yield call(effectFrequency, efetiveFrequency);

        yield put({ type: Frequency.types.RESPONSE_FREQUENCY, data });
      
    }
    catch (error) {
        yield put({ type: "API_CALL_ERROR" });
    }
}

function effectFrequency(efetiveFrequency) {
    return (fetch("/api/TesteMalucao", {
        method: "post",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(efetiveFrequency)
    })
        .then(response => response.json()));
}