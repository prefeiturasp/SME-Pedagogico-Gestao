import { takeLatest, put, all } from "redux-saga/effects";
import * as User from "../store/User";

function* LoginTokenSgpSaga({ user, history }) {
  try {
    yield put({ type: User.types.SET_USER, user });
    history.push("/Relatorios/Sondagem");
  } catch (error) {
    yield put({ type: User.types.FINISH_AUTHENTICATION_REQUEST });
    yield put({ type: "API_CALL_ERROR" });
  }
}

export default function* () {
  yield all([takeLatest(User.types.LOGIN_SGP_REQUEST, LoginTokenSgpSaga)]);
}
