import { takeLatest, call, put, all } from "redux-saga/effects";
import * as Filters from '../store/Filters';

export default function* () {
    yield all([
        takeLatest(Filters.types.GET_DRE, GetDres),
        takeLatest(Filters.types.GET_SCHOOL, GetSchools)
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
        
        const data = yield call(getSchoolsAPI, schoolCode);
        var listSchool = data;
        yield put({ type: Filters.types.LIST_SCHOOLS, listSchool })
    }
    catch (error) {
        yield put({ type: "API_CALL_ERROR" });
    }
}


function getSchoolsAPI(schoolCode) {
    debugger;
    return (fetch("/api/Filtros/ListarEscolasPorDre/" + schoolCode.code + "/" + schoolCode.schoolYear, {
        method: "get",
        headers: { 'Content-Type': 'application/json' },
        //body: JSON.stringify(credential)
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