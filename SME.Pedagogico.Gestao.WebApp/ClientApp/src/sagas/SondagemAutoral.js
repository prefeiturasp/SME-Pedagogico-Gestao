import { takeLatest, call, put, all } from "redux-saga/effects";
import * as Autoral from "../store/SondagemAutoral";
import * as Filters from "../store/Filters";
import * as Poll from "../store/Poll";
import { parametrosParaUrl } from "../utils";
import { TIPO_PERIODO } from '../Enums'; 

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

const setCarregandoLista = (type, carregandoPerguntas) => ({
  type,
  carregandoPerguntas,
});

function* ListarPerguntas({ filtros }) {
  try {
    yield put(setCarregandoLista(Poll.types.SET_LOADING_PERGUNTAS, true));
    const listaPerguntas = yield call(listaPerguntasAPI, filtros);
    yield put({ type: Autoral.types.SETAR_PERGUNTAS, listaPerguntas });
  } catch (error) {
    yield put({ type: "API_CALL_ERROR" });
  } finally {
    yield put(setCarregandoLista(Poll.types.SET_LOADING_PERGUNTAS, false));
  }
}

function listaPerguntasAPI(filtros) {
  const params = parametrosParaUrl({
    anoEscolar: filtros.yearClassroom,
    anoLetivo: filtros.schoolYear,
    bimestre: filtros.bimestre || 0,
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
  const tipoCarregandoAlunos = Poll.types.SET_CARREGANDO_ALUNOS;
  try {
    yield put({ type: tipoCarregandoAlunos, carregandoAlunos: true });
    const data = yield call(listarAlunosMatApi, payload);
    var listaAlunosAutoralMatematica = data;
    yield put({
      type: Autoral.types.SETAR_ALUNOS_AUTORAL_MATEMATICA,
      listaAlunosAutoralMatematica,
    });
  } catch (error) {
    yield put({ type: "API_CALL_ERROR" });
  } finally {
    yield put({ type: tipoCarregandoAlunos, carregandoAlunos: false });
  }
}

function listarAlunosMatApi({ filtro, bimestre }) {
  var params;
  if (bimestre != null) params = parametrosParaUrl({ ...filtro, bimestre });
  else params = parametrosParaUrl({ ...filtro });

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

  try {
    const data = yield fetch("/api/SondagemAutoral/Matematica", {
      method: "post",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(payload.alunos),
    });
    yield put({
      type: Autoral.types.SETAR_STATUS_AUTORAL_MATEMATICA,
      status: data.status,
    });
  } catch (e) {
    console.log(e);
  }

  yield put({
    type: Poll.types.SET_LOADING_SALVAR,
    filters: false,
  });

  if (payload.yearClassroom < 2022) {
    yield put({
      type: Autoral.types.LISTAR_ALUNOS_AUTORAL_MATEMATICA,
      filtro: payload.filtro,
    });
  }
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
  var url = `/api/Filtros/ListarPeriodoDeAberturas/${schoolYear}`;//?tipoPeriodicidade=${TIPO_PERIODO.BIMESTRE}
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

function obterPeriodAbertoApi({
  bimestre,
  anoLetivo,
  tipoPeriodicidade = TIPO_PERIODO.BIMESTRE,
}) {
  const params = parametrosParaUrl({ bimestre, anoLetivo, tipoPeriodicidade });
  var url = `/api/SondagemAutoral/Matematica/Periodo/Aberto?${params}`;
  return fetch(url, {
    method: "get",
    headers: { "Content-Type": "application/json" },
  }).then((response) => response.json());
}
