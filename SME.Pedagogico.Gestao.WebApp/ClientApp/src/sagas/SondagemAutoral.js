import { takeLatest, call, put, all } from "redux-saga/effects";
import * as Autoral from "../store/SondagemAutoral";
import * as Filters from "../store/Filters";
import * as Poll from "../store/Poll";

export default function* () {
  yield all([
    takeLatest(Autoral.types.LISTAR_PERGUNTAS, ListarPerguntas),
    takeLatest(Autoral.types.LISTAR_PERIODOS, ListarPeriodos),
    takeLatest(
      Autoral.types.LISTAR_ALUNOS_AUTORAL_MATEMATICA,
      ListarAlunosAutoralMat
    ),
    takeLatest(
      Autoral.types.SALVAR_SONDAGEM_AUTORAL_MATEMATICA,
      SalvaSondagemAutoralMat
    ),
    takeLatest(Filters.types.GET_PERIOD, GetPeriod),
  ]);
}

function* ListarPerguntas({ anoEscolar }) {
  try {
    const data = yield call(listaPerguntasAPI, anoEscolar);
    var listaPerguntas = data;
    yield put({ type: Autoral.types.SETAR_PERGUNTAS, listaPerguntas });
  } catch (error) {
    yield put({ type: "API_CALL_ERROR" });
  }
}

function listaPerguntasAPI(anoEscolar) {
  var url = `/api/SondagemAutoral/Matematica/Perguntas?anoEscolar=${anoEscolar}`;
  return fetch(url, {
    method: "get",
    headers: { "Content-Type": "application/json" },
  }).then((response) => response.json());
}

function* ListarPeriodos() {
  try {
    const data = yield call(listarPeriodosAPI);
    var listaPeriodos = data;
    yield put({ type: Autoral.types.SETAR_PERIODOS, listaPeriodos });
  } catch (error) {
    yield put({ type: "API_CALL_ERROR" });
  }
}

function listarPeriodosAPI() {
  var url = `/api/SondagemAutoral/Matematica/Periodos`;
  return fetch(url, {
    method: "get",
    headers: { "Content-Type": "application/json" },
  }).then((response) => response.json());
}

function* ListarAlunosAutoralMat({ filtro }) {
  try {
    const data = yield call(listarAlunosMatApi, filtro);
    var listaAlunosAutoralMatematica = data;
    yield put({
      type: Autoral.types.SETAR_ALUNOS_AUTORAL_MATEMATICA,
      listaAlunosAutoralMatematica,
    });
  } catch (error) {
    yield put({ type: "API_CALL_ERROR" });
  }
}

function listarAlunosMatApi(filtro) {
  var url = `/api/SondagemAutoral/Matematica?${new URLSearchParams(filtro)}`;
  return fetch(url, {
    method: "get",
    headers: { "Content-Type": "application/json" },
  }).then((response) => response.json());
}

function* SalvaSondagemAutoralMat({ payload }) {
  yield put({
    type: Poll.types.SET_LOADING_SALVAR,
    filters: true,
  });

  yield fetch("/api/SondagemAutoral/Matematica", {
    method: "post",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(payload.alunos),
  });

  yield put({
    type: Poll.types.SET_LOADING_SALVAR,
    filters: false,
  });

  yield put({
    type: Autoral.types.LISTAR_ALUNOS_AUTORAL_MATEMATICA,
    filtro: payload.filtro,
  });
}

function* GetPeriod({ schoolYear }) {
  try {
    const data = yield call(getPeriodApi, schoolYear);
    var listPeriod = data;
    yield put({ type: Filters.types.SET_PERIOD, listPeriod });
  } catch (error) {
    yield put({ type: "API_CALL_ERROR" });
  }
}

// Filter Sagas

function getPeriodApi(schoolYear) {
  var url = `/api/Filtros/ListarPeriodoDeAberturas/${schoolYear}`;
  return fetch(url, {
    method: "get",
    headers: { "Content-Type": "application/json" },
  }).then((response) => response.json());
}
