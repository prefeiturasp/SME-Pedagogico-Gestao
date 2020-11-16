import { takeLatest, put } from "redux-saga/effects";
import * as Frequency from "../store/Frequency";

export default function* () {
  yield takeLatest(Frequency.types.FREQUENCY_EFFECT_REQUEST, FrequencySaga);
}

function* FrequencySaga({ efetiveFrequency }) {
  try {
    yield put({ type: Frequency.types.RESPONSE_FREQUENCY });
  } catch (error) {
    yield put({ type: "API_CALL_ERROR" });
  }
}
