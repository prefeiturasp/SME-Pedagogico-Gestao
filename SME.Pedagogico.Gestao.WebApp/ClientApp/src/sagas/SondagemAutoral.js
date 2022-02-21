import { takeLatest, call, put, all } from "redux-saga/effects";
import * as Autoral from "../store/SondagemAutoral";
import * as Filters from "../store/Filters";
import * as Poll from "../store/Poll";
import { parametrosParaUrl } from "../utils";

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
    takeLatest(Autoral.types.OBTER_PERIODO_ABERTO, obterPeriodoAberto),
  ]);
}

const setCarregandoListaPerguntas = (loadingPerguntas) => ({
  type: Poll.types.SET_LOADING_PERGUNTAS,
  loadingPerguntas,
});

function* ListarPerguntas({ filtros }) {
  try {
    yield put(setCarregandoListaPerguntas(true));
    const data = yield call(listaPerguntasAPI, filtros);
    var listaPerguntas = data;
    yield put({ type: Autoral.types.SETAR_PERGUNTAS, listaPerguntas });
  } catch (error) {
    yield put({ type: "API_CALL_ERROR" });
  } finally {
    yield put(setCarregandoListaPerguntas(false));
  }
}

function listaPerguntasAPI(filtros) {
  const params = parametrosParaUrl({
    anoEscolar: filtros.yearClassroom,
    anoLetivo: filtros.schoolYear,
  });
  const url = `/api/SondagemAutoral/Matematica/Perguntas?${params}`;
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

function* ListarAlunosAutoralMat({ payload }) {
  try {
    const data = yield call(listarAlunosMatApi, payload);
    var listaAlunosAutoralMatematica = data;
    yield put({
      type: Autoral.types.SETAR_ALUNOS_AUTORAL_MATEMATICA,
      listaAlunosAutoralMatematica,
    });
  } catch (error) {
    yield put({ type: "API_CALL_ERROR" });
  }
}

function listarAlunosMatApi({ filtro, bimestre, perguntaAnoEscolar }) {
  const params = parametrosParaUrl({ ...filtro, bimestre, perguntaAnoEscolar });
  var url = `/api/SondagemAutoral/Matematica?${params}`;
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

function* obterPeriodoAberto({ payload }) {
  try {
    const periodoAberto = yield call(obterPeriodAbertoApi, payload);
    yield put({ type: Autoral.types.SETAR_PERIODO_ABERTO, periodoAberto });
  } catch (error) {
    yield put({ type: "API_CALL_ERROR" });
  }
}

function obterPeriodAbertoApi({ bimestre, anoLetivo }) {
  const params = parametrosParaUrl({ bimestre, anoLetivo });
  var url = `/api/SondagemAutoral/Matematica/Periodo/Aberto?${params}`;
  return fetch(url, {
    method: "get",
    headers: { "Content-Type": "application/json" },
  }).then((response) => response.json());
}
