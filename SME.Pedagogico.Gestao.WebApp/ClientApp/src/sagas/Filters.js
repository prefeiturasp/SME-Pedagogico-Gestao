import { takeLatest, call, put, all } from "redux-saga/effects";
import * as Filters from "../store/Filters";

export default function*() {
  yield all([
    takeLatest(Filters.types.GET_DRE, GetDres),
    takeLatest(Filters.types.GET_SCHOOL, GetSchools),
    takeLatest(Filters.types.GET_CLASSROOM, GetClassRoom),
    takeLatest(Filters.types.GET_FILTERS_TEACHER, GetFiltersTeacher),
    takeLatest(Filters.types.GET_DRE_ADM, GetDreAdm),
    takeLatest(Filters.types.GET_PERIOD, GetPeriod)
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

function* GetDres({}) {
  try {
    const data = yield call(getDresAPI);
    var listDres = data;
    yield put({ type: Filters.types.LIST_DRES, listDres });
  } catch (error) {
    yield put({ type: "API_CALL_ERROR" });
  }
}

function* GetPeriod({schoolYear}) {
  try {
    const data = yield call(getPeriodApi, schoolYear);
    var listPeriod = data;
    yield put({ type: Filters.types.SET_PERIOD, listPeriod})
  }catch (error) {
    yield put({ type: "API_CALL_ERROR" });
  }

}

function* GetSchools({ schoolCode }) {
  try {
    const data = yield call(getSchoolsAPI, schoolCode);
    var listSchool = data;
    yield put({ type: Filters.types.LIST_SCHOOLS, listSchool });
    yield put({ type: Filters.types.ACTIVEDRECODE, schoolCode });
  } catch (error) {
    yield put({ type: "API_CALL_ERROR" });
  }
}

function* GetClassRoom({ classRoomFilter }) {
  try {
    const data = yield call(getClassRoomAPI, classRoomFilter);
    var listClassRoom = data;
    yield put({ type: Filters.types.LIST_CLASSROOM, listClassRoom });
    yield put({ type: Filters.types.ACTIVESCHOOLCODE, classRoomFilter });
  } catch (error) {
    yield put({ type: "API_CALL_ERROR" });
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
    headers: {"Content-Type": "application/json"} 
  }).then(response => response.json());
};

function getDreAdmApi(userName) {

  return fetch("/api/Cargo/RetornaCodigoDREAdm", {
    method: "post",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(userName)
  }).then(response => response.json());
};

function getTeacherFiltersApi(profileOccupatios) {
  return fetch("/api/Cargo/PerfilServidor", {
    method: "post",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(profileOccupatios)
  }).then(response => response.json());
}
function getSchoolsAPI(schoolCode) {
  return fetch("/api/Filtros/ListarEscolasPorDre", {
    method: "post",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(schoolCode)
  }).then(response => response.json());
}

function getClassRoomAPI(classRoomFilter) {
  return fetch("/api/Filtros/ListarTurmasPorEscola", {
    method: "post",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(classRoomFilter)
  }).then(response => response.json());
}

function getDresAPI() {
  return fetch("/api/Filtros/ListarDres", {
    method: "get",
    headers: { "Content-Type": "application/json" }
    //body: JSON.stringify(credential)
  }).then(response => response.json());
}
