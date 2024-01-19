import { takeLatest, call, put, all } from "redux-saga/effects";
import * as Autoral from "../store/SondagemPortuguesStore";
import * as Poll from "../store/Poll";

export default function* () {
  yield all([
    takeLatest(Autoral.types.LISTAR_GRUPOS, ListarGrupos),
    takeLatest(
      Autoral.types.LISTAR_COMPONENTE_CURRICULAR,
      ListarComponenteCurricular
      ),
    takeLatest(Autoral.types.LISTAR_PERIODOS, ListarPeriodos),
    takeLatest(Autoral.types.LISTAR_PERGUNTAS_PORTUGUES, ListarPerguntas),
    takeLatest(
      Autoral.types.EXCLUIR_SONDAGEM_PORTUGUES,
      ExcluirSondagemPortugues
    ),
    takeLatest(Autoral.types.LISTAR_SEQUENCIA_ORDENS, ListarSequenciaOrdens),
    takeLatest(Autoral.types.LISTAR_ALUNOS_PORTUGUES, ListarAlunosPortugues),
    takeLatest(Autoral.types.SALVAR_SONDAGEM_PORTUGUES, SalvaSondagemPortugues),
  ]);
}

function* ExcluirSondagemPortugues({ payload }) {
  try {
    yield call(ExcluirSondagemPortuguesApi, payload);

    yield put({
      type: Autoral.types.LISTAR_SEQUENCIA_ORDENS,
      payload: payload,
    });

    yield put({
      type: Autoral.types.LISTAR_ALUNOS_PORTUGUES,
      payload: payload,
    });
  } catch (error) {
    yield put({ type: "API_CALL_ERROR" });
  }
}

function ExcluirSondagemPortuguesApi(filtro) {
  const url = `/api/SondagemPortugues/ExcluirSondagemPortugues?${new URLSearchParams(
    filtro
  )}`;

  return fetch(url, {
    method: "delete",
    headers: { "Content-Type": "application/json" },
  });
}

function* ListarGrupos() {
  try {
    const data = yield call(listarGruposAPI);
    var payload = data;
    yield put({ type: Autoral.types.SETAR_GRUPOS, payload });
  } catch (error) {
    yield put({ type: "API_CALL_ERROR" });
  }
}

function listarGruposAPI() {
  var url = `/api/SondagemPortugues/Grupos`;
  return fetch(url, {
    method: "get",
    headers: { "Content-Type": "application/json" },
  }).then((response) => response.json());
}
function* ListarComponenteCurricular() {
  try {
    const data = yield call(listarComponenteCurricularAPI);
    var payload = data;
    yield put({ type: Autoral.types.SETAR_COMPONENTE_CURRICULAR, payload });
  } catch (error) {
    yield put({ type: "API_CALL_ERROR" });
  }
}

function listarComponenteCurricularAPI() {
  var url = `/api/SondagemPortugues/ComponenteCurricular`;
  return fetch(url, {
    method: "get",
    headers: { "Content-Type": "application/json" },
  }).then((response) => response.json());
}

function* ListarPeriodos({ payload }) {
  try {
    const data = yield call(listarPeriodosAPI, payload);
    var payload = data;
    yield put({ type: Autoral.types.SETAR_PERIODOS, payload });
  } catch (error) {
    yield put({ type: "API_CALL_ERROR" });
  }
}

function listarPeriodosAPI({ tipoPeriodo }) {
    var url = `/api/SondagemPortugues/Periodos?tipoPeriodo=${tipoPeriodo}`;
  return fetch(url, {
    method: "get",
    headers: { "Content-Type": "application/json" },
  }).then((response) => response.json());
}

function* ListarPerguntas({ payload }) {
  try {
    const data = yield call(listaPerguntasAPI, payload);
    yield put({ type: Autoral.types.SETAR_PERGUNTAS, payload: data });
  } catch (error) {
    yield put({ type: "API_CALL_ERROR_PERGUNTAS" });
  }
}

function listaPerguntasAPI({ sequenciaOrdem, grupoId }) {
  var url = `/api/SondagemPortugues/Perguntas?sequenciaOrdem=${sequenciaOrdem}&grupoId=${grupoId}`;
  return fetch(url, {
    method: "get",
    headers: { "Content-Type": "application/json" },
  })
    .then((response) => response.json())
    .catch((error) => {});
}

function* ListarSequenciaOrdens({ payload }) {
  try {
    const data = yield call(listarSequenciaOrdensApi, payload);

    yield put({
      type: Autoral.types.SETAR_SEQUENCIA_ORDENS,
      payload: data,
    });
  } catch (error) {
    yield put({ type: "API_CALL_ERROR" });
  }
}

function listarSequenciaOrdensApi(filtro) {
  var url = `api/SondagemPortugues/SequenciaDeOrdens?${new URLSearchParams(
    filtro
  )}`;
  return fetch(url, {
    method: "get",
    headers: { "Content-Type": "application/json" },
  }).then((response) => response.json());
}

function* ListarAlunosPortugues({ payload }) {
  try {
    const data = yield call(listarAlunosPortuguesApi, payload);

    yield put({
      type: Autoral.types.SETAR_ALUNOS_PORTUGUES,
      payload: data,
    });
  } catch (error) {
    yield put({ type: "API_CALL_ERROR" });
  }
}

function listarAlunosPortuguesApi(filtro) {
  var url = `/api/SondagemPortugues/ListarSondagemPortuguesAutoral?${new URLSearchParams(
    filtro
  )}`;
  return fetch(url, {
    method: "get",
    headers: { "Content-Type": "application/json" },
  }).then((response) => response.json());
}

function* SalvaSondagemPortugues({ payload }) {
  yield put({
    type: Poll.types.SET_LOADING_SALVAR,
    filters: true,
  });

  try {
    const data = yield fetch(
      "/api/SondagemPortugues/SondagemPortuguesAutoral",
      {
        method: "post",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(payload.alunos),
      }
    );
    yield put({
      type: Autoral.types.SETAR_STATUS_AUTORAL_PORTUGUES,
      status: data.status,
    });
  } catch (e) {
    console.log(e);
  }

  yield put({
    type: Poll.types.SET_LOADING_SALVAR,
    filters: false,
  });

  if (payload.novaOrdem) {
    yield put({
      type: Autoral.types.SETAR_ORDEM_SELECIONADA,
      payload: payload.novaOrdem,
    });

    payload.filtro.ordemId = payload.novaOrdem;
  }

  if (payload.novoPeriodoId) {
    yield put({
      type: Autoral.types.SETAR_PERIODO_SELECIONADO,
      payload: payload.novoPeriodoId,
    });

    payload.filtro.periodoId = payload.novoPeriodoId.id;
  }

  yield put({
    type: Autoral.types.LISTAR_ALUNOS_PORTUGUES,
    payload: payload.filtro,
  });
}
