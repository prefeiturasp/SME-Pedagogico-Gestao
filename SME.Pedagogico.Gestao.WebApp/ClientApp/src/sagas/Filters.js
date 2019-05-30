import { takeLatest, call, put, all } from "redux-saga/effects";
import * as Filters from '../store/Filters';

export default function* () {
    yield all([
        takeLatest(Filters.types.GET_DRE, GetDres),
        takeLatest(Filters.types.GET_SCHOOL, GetSchools),
        takeLatest(Filters.types.GET_CLASSROOM, GetClassRoom)
    ]);
}

function* GetDres({ }) {
    try {

        const data = yield call(getDresAPI);
        var listDres = data;
        yield put({ type: Filters.types.LIST_DRES, listDres })
    }
    catch (error) {
        yield put({ type: "API_CALL_ERROR" });
    }
}

function* GetSchools({ schoolCode }) {
    try {
        debugger;
        const data = yield call(getSchoolsAPI, schoolCode);
        var listSchool = data;
        yield put({ type: Filters.types.LIST_SCHOOLS, listSchool })
        debugger;
    }
    catch (error) {
        yield put({ type: "API_CALL_ERROR" });
    }
}

function* GetClassRoom({ classRoomFilter }) {
    try {
        debugger;
        const data = yield call(getClassRoomAPI, classRoomFilter);
        var listClassRoom = data;
        yield put({ type: Filters.types.LIST_CLASSROOM, listClassRoom })
        debugger;
    }
    catch (error) {
        yield put({ type: "API_CALL_ERROR" });
    }
}


function getSchoolsAPI(schoolCode) {
    debugger;
    return (fetch("/api/Filtros/ListarEscolasPorDre", {
        method: "post",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(schoolCode)
    })
        .then(response => response.json()));
}


function getClassRoomAPI(classRoomFilter) {
  
    return (fetch("/api/Filtros/ListarTurmasPorEscola", {
        method: "post",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(classRoomFilter)
    })
        .then(response => response.json()));
}

function getDresAPI() {
    debugger;
    return (fetch("/api/Filtros/ListarDres", {
        method: "get",
        headers: { 'Content-Type': 'application/json' },
        //body: JSON.stringify(credential)
    })
        .then(response => response.json()));
}