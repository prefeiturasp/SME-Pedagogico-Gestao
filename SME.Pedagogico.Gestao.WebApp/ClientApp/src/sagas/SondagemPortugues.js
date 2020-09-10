import { takeLatest, call, put, all } from "redux-saga/effects";
import * as Autoral from "../store/SondagemPortuguesStore";


export default function* () {
    yield all([
        takeLatest(Autoral.types.LISTAR_GRUPOS, ListarGrupos),
        takeLatest(Autoral.types.LISTAR_COMPONENTE_CURRICULAR, ListarComponenteCurricular),
        takeLatest(Autoral.types.LISTAR_BIMESTRES, ListarBimestres),
        takeLatest(Autoral.types.LISTAR_PERGUNTAS_PORTUGUES, ListarPerguntas),
        takeLatest(Autoral.types.LISTAR_SEQUENCIA_ORDENS, ListarSequenciaOrdens),
        takeLatest(
            Autoral.types.LISTAR_ALUNOS_PORTUGUES,
            ListarAlunosPortugues
        ),
        takeLatest(
            Autoral.types.SALVAR_SONDAGEM_PORTUGUES,
            SalvaSondagemPortugues
        ),
        
    ]);
}

function* ListarGrupos({ }) {
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
function* ListarComponenteCurricular({ }) {
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

function* ListarBimestres({ }) {
    try {
        const data = yield call(listarBimestresAPI);
        var payload = data;
        yield put({ type: Autoral.types.SETAR_BIMESTRES, payload });
    } catch (error) {
        yield put({ type: "API_CALL_ERROR" });
    }
}

function listarBimestresAPI() {
    var url = `/api/SondagemPortugues/ComponenteCurricular`;
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

function listaPerguntasAPI(sequenciaOrdem) {
    debugger
    var url = `/api/SondagemPortugues/Perguntas?sequenciaOrdem=${sequenciaOrdem}`;
    return fetch(url, {
        method: "get",
        headers: { "Content-Type": "application/json" },
    }).then((response) => response.json());
}


function* ListarSequenciaOrdens({ payload }) {
    try {
        const data = yield call(listarSequenciaOrdensApi, payload);
        yield put({
            type: Autoral.types.SETAR_SEQUENCIA_ORDENS,
            payload:data,
        });
    } catch (error) {
        yield put({ type: "API_CALL_ERROR" });
    }
}

function listarSequenciaOrdensApi(filtro) {
    var url = `api/SondagemPortugues/SequenciaDeOrdens?${new URLSearchParams(filtro)}`;
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
            payload:data,
        });
    } catch (error) {
        yield put({ type: "API_CALL_ERROR" });
    }
}

function listarAlunosPortuguesApi(filtro) {
    var url = `/api/SondagemPortugues/ListarSondagemPortuguesAutoral?${new URLSearchParams(filtro)}`;
    return fetch(url, {
        method: "get",
        headers: { "Content-Type": "application/json" },
    }).then((response) => response.json());
}

function* SalvaSondagemPortugues({ payload }) {
    yield fetch("/api/SondagemPortugues/SondagemPortuguesAutoral", {
        method: "post",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(payload.alunos),
    });

    yield put({
        type: Autoral.types.LISTAR_ALUNOS_PORTUGUES,
        filtro: payload.filtro,
    });
}



