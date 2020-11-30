import { takeLatest, call, put, all, select } from "redux-saga/effects";

import * as Filters from "../store/Filters";
import { types } from "../store/User";
import { ROUTES_ENUM } from "../Enums";

export default function* () {
  yield all([
    takeLatest(Filters.types.GET_DRE, GetDres),
    takeLatest(Filters.types.GET_SCHOOL, GetSchools),
    takeLatest(Filters.types.GET_CLASSROOM, GetClassRoom),
    takeLatest(Filters.types.GET_FILTERS_TEACHER, GetFiltersTeacher),
    takeLatest(Filters.types.GET_DRE_ADM, GetDreAdm),
    takeLatest(Filters.types.GET_PERIOD, GetPeriod),
    takeLatest(
      Filters.types.GET_LIST_DISCIPLINES_BY_CLASSROOM,
      GetDisciplinesByClassroom
    ),
  ]);
}

function* GetDreAdm({ userName }) {
  try {
    const data = yield call(getDreAdmApi, userName);
    var listDres = data;
    yield put({ type: Filters.types.LIST_DRES, listDres });
  } catch (error) {
    yield put({ type: "API_CALL_ERROR" });
  }
}

function* GetDres() {
  try {
    const {
      user,
      filters,
      pollRouter: { activeRoute },
    } = yield select();
    const { token, possuiPerfilSme } = user;
    const { setSchoolYear: anoLetivo } = filters;
    const listDres = yield call(getDresAPI, token, anoLetivo);
    const isPollReport = activeRoute === ROUTES_ENUM.RELATORIOS;
    const todas = { codigoDRE: "todas", nomeDRE: "Todas", siglaDRE: "Todas" };

    if (listDres.mensagens) {
      throw new Error(listDres.mensagens);
    }

    if (isPollReport && possuiPerfilSme) {
      listDres.unshift(todas);
    }

    yield put({ type: Filters.types.LIST_DRES, listDres });
  } catch (error) {
    yield put({ type: types.LOGOUT_USER });
    yield put({ type: "API_CALL_ERROR" });
    yield put({ type: types.SET_ERROR, msgError: error.message });
  }
}

function* GetDisciplinesByClassroom({ disciplinesFilter }) {
  try {
    const { user } = yield select();
    const { token } = user;
    const data = yield call(
      getDisciplinesByClassroomAPI,
      disciplinesFilter,
      token
    );

    if (data.mensagens) {
      throw new Error(data.mensagens);
    }

    const listDisciplines = data;
    yield put({ type: Filters.types.LIST_DISCIPLINES, listDisciplines });
    yield put({ type: Filters.types.DISCIPLINES_FILTER, disciplinesFilter });
  } catch (error) {
    yield put({ type: types.LOGOUT_USER });
    yield put({ type: "API_CALL_ERROR" });
    yield put({ type: types.SET_ERROR, msgError: error.message });
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

function* GetSchools({ schoolCode }) {
  try {
    const {
      user,
      pollRouter: { activeRoute },
    } = yield select();
    const { token, possuiPerfilSme, possuiPerfilDre, perfil } = user;
    const ehProfessor =
      perfil.perfilSelecionado.nomePerfil.indexOf("Professor") >= 0;
    const ehTodas = schoolCode.dreCodeEol === "todas";
    const listSchool = !ehTodas
      ? yield call(getSchoolsAPI, schoolCode, token)
      : [];
    const isPollReport = activeRoute === ROUTES_ENUM.RELATORIOS;
    const todas = { codigoEscola: "todas", nomeEscola: "Todas" };

    if (listSchool.mensagens) {
      throw new Error(listSchool.mensagens);
    }

    if (isPollReport && !ehProfessor && (possuiPerfilSme || possuiPerfilDre)) {
      listSchool.unshift(todas);
    }

    yield put({ type: Filters.types.LIST_SCHOOLS, listSchool });
    yield put({ type: Filters.types.ACTIVEDRECODE, schoolCode });
  } catch (error) {
    yield put({ type: types.LOGOUT_USER });
    yield put({ type: "API_CALL_ERROR" });
    yield put({ type: types.SET_ERROR, msgError: error.message });
  }
}

function* GetClassRoom({ classRoomFilter }) {
  try {
    const { user } = yield select();
    const { token } = user;
    const schoolCodeEolIsEmpty = classRoomFilter.schoolCodeEol.length;
    const data = schoolCodeEolIsEmpty
      ? yield call(getClassRoomAPI, classRoomFilter, token)
      : [];

    if (data.mensagens) {
      throw new Error(data.mensagens);
    }

    const listClassRoom = data;
    yield put({ type: Filters.types.LIST_CLASSROOM, listClassRoom });
    yield put({ type: Filters.types.ACTIVESCHOOLCODE, classRoomFilter });
  } catch (error) {
    yield put({ type: types.LOGOUT_USER });
    yield put({ type: "API_CALL_ERROR" });
    yield put({ type: types.SET_ERROR, msgError: error.message });
  }
}

function* GetFiltersTeacher({ profileOccupatios }) {
  try {
    const data = yield call(getTeacherFiltersApi, profileOccupatios);
    var filters = data;
    yield put({ type: Filters.types.SET_FILTERS_TEACHER, filters });
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

function getDreAdmApi(userName) {
  return fetch("/api/Cargo/RetornaCodigoDREAdm", {
    method: "post",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(userName),
  }).then((response) => response.json());
}

function getTeacherFiltersApi(profileOccupatios) {
  return fetch("/api/Cargo/PerfilServidor", {
    method: "post",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(profileOccupatios),
  }).then((response) => response.json());
}
function getSchoolsAPI(schoolCode, token) {
  return fetch("/api/Filtros/ListarEscolasPorDre", {
    method: "post",
    headers: { "Content-Type": "application/json", token },
    body: JSON.stringify(schoolCode),
  }).then((response) => response.json());
}

function getClassRoomAPI(classRoomFilter, token) {
  return fetch("/api/Filtros/ListarTurmasPorEscola", {
    method: "post",
    headers: { "Content-Type": "application/json", token },
    body: JSON.stringify(classRoomFilter),
  }).then((response) => response.json());
}

function getDresAPI(token, anoLetivo) {
  return fetch(`/api/Filtros/ListarDres?anoLetivo=${anoLetivo}`, {
    method: "get",
    headers: { "Content-Type": "application/json", token },
  }).then((response) => response.json());
}

function getDisciplinesByClassroomAPI(disciplinesFilter, token) {
  return fetch("/api/Filtros/ListarDisciplinasPorRfTurma", {
    method: "post",
    headers: { "Content-Type": "application/json", token },
    body: JSON.stringify(disciplinesFilter),
  }).then((response) => response.json());
}
