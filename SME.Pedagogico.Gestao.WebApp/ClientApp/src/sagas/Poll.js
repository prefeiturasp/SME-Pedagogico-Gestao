import { takeLatest, call, put, all } from "redux-saga/effects";
import * as Poll from '../store/Poll';

export default function* () {
    yield all([
      //  takeLatest(Poll.types.GET_POLL_PORTUGUESE_STUDENTS, GetStudents),
        takeLatest(Poll.types.SAVE_POLL_PORTUGUESE, SavePollPortuguese),
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
  
    return (fetch("/api/classRoomStudents/ListaAlunosDaTurma", {
        method: "post",
        headers: { 'content-type': 'application/json' },
        body: JSON.stringify(classRoom)
    })
        .then(response => response.json()));
    debugger;
   
    //return lStudants;
}

function* SavePollPortuguese({ students }) {
    debugger;
    //return (yield fetch("/api/", {
    //            method: "post",
    //            headers: { 'Content-Type': 'application/json' },
    //            body: JSON.stringify(students)
    //        }).then(response => response.json())
    //);
    return (yield true);
} 