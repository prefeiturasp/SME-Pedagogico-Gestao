import { takeLatest, call, put, all } from "redux-saga/effects";
import * as Poll from '../store/Poll';

export default function* () {
    yield all([
        takeLatest(Poll.types.GET_POLL_PORTUGUESE_STUDENTS, GetStudents),
        takeLatest(Poll.types.SAVE_POLL_PORTUGUESE, SavePollPortuguese),

        takeLatest(Poll.types.GET_POLL_MATH_NUMBERS_STUDENTS, GetStudentsMathNumbers),
        takeLatest(Poll.types.SAVE_POLL_MATH_NUMBERS_STUDENTS, SavePollMathNumbers),

        takeLatest(Poll.types.GET_POLL_MATH_CA_STUDENTS, GetStudentsMathCA),
        takeLatest(Poll.types.SAVE_POLL_MATH_CA_STUDENTS, SavePollMathCA),

        takeLatest(Poll.types.GET_POLL_MATH_CM_STUDENTS, GetStudentsMathCM),
        takeLatest(Poll.types.SAVE_POLL_MATH_CM_STUDENTS, SavePollMathCM),
    ]);
}

function* GetStudents({ classRoom }) {
    try {
        const data = yield call(getStudentsPollPortugueseRequestApi, classRoom);

        yield put({ type: Poll.types.SET_POLL_PORTUGUESE_STUDENTS, data });
    }

    catch (error) {
        yield put({ type: "API_CALL_ERROR" });
    }
}

function getStudentsPollPortugueseRequestApi(classRoom) {
  
    return (fetch("/api/sondagemPortugues/ListarSondagemPortugues", {
        method: "post",
        headers: { 'content-type': 'application/json' },
        body: JSON.stringify(classRoom)
    }).then(response => response.json()));
}

function* SavePollPortuguese(students) {
    try {
        yield put({ type: Poll.types.SET_POLL_DATA_SAVED_STATE });
        var data = yield fetch("/api/sondagemPortugues/IncluirSondagemPortugues", {
            method: "post",
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(students.pollstudents)
        }).then(response => response.json());
        return (data.status);
    } catch (error) {
    }
} 


function* GetStudentsMathNumbers({ classRoom }) {
    try {
        
        const data = yield call(getStudentsPollMathNumbersRequestApi, classRoom);
        
        yield put({ type: Poll.types.SET_POLL_MATH_NUMBERS_STUDENTS, data });
        
    }

    catch (error) {
        yield put({ type: "API_CALL_ERROR" });
    }
}

function getStudentsPollMathNumbersRequestApi(classRoom) {
    var data = [];
    try {
        data = fetch("/api/sondagemMatematica/ListaSondagemNumeros", {
            method: "post",
            headers: { 'content-type': 'application/json' },
            body: JSON.stringify(classRoom)
        }).then(response => response.json())
    } catch (e) {
    }
    
    return (data);
}

function* SavePollMathNumbers(students) {
    try {
        yield put({ type: Poll.types.SET_POLL_DATA_SAVED_STATE });
        var data = yield fetch("/api/sondagemMatematica/GravaSondagemNumeros", {
            method: "post",
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(students.pollstudents)
        }).then(response => response.json());
        return (data);
    } catch (error) {
        
    }
}


function* GetStudentsMathCA({ classRoom }) {
    try {
        const data = yield call(getStudentsPollMathCARequestApi, classRoom);

        yield put({ type: Poll.types.SET_POLL_MATH_CA_STUDENTS, data });
    }

    catch (error) {
        yield put({ type: "API_CALL_ERROR" });
    }
}

function getStudentsPollMathCARequestApi(classRoom) {
    return (fetch("/api/sondagemMatematica/ListaSondagemCA", {
        method: "post",
        headers: { 'content-type': 'application/json' },
        body: JSON.stringify(classRoom)
    }).then(response => response.json()));
}

function* SavePollMathCA(students) {
    try {
        yield put({ type: Poll.types.SET_POLL_DATA_SAVED_STATE });
        var data = yield fetch("/api/sondagemMatematica/GravaSondagemCA", {
            method: "post",
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(students.pollstudents)
        }).then(response => response.json());
        return (data);
    } catch (error) {
    }
}


function* GetStudentsMathCM({ classRoom }) {
    try {
        const data = yield call(getStudentsPollMathCMRequestApi, classRoom);

        yield put({ type: Poll.types.SET_POLL_MATH_CM_STUDENTS, data });
    }

    catch (error) {
        yield put({ type: "API_CALL_ERROR" });
    }
}

function getStudentsPollMathCMRequestApi(classRoom) {
    return (fetch("/api/sondagemMatematica/ListaSondagemCM", {
        method: "post",
        headers: { 'content-type': 'application/json' },
        body: JSON.stringify(classRoom)
    }).then(response => response.json()));
}

function* SavePollMathCM(students) {
    try {
        yield put({ type: Poll.types.SET_POLL_DATA_SAVED_STATE });
        var data = yield fetch("/api/sondagemMatematica/GravaSondagemCM", {
            method: "post",
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(students.pollstudents)
        }).then(response => response.json());
        return (data);
    } catch (error) {
    }
}