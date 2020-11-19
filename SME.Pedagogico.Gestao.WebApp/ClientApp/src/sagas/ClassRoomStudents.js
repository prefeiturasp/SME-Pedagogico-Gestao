import { takeLatest, call, put, all } from "redux-saga/effects";
import * as ClassRoomStudents from '../store/ClassRoomStudents';

export default function* () {
    yield all([
        takeLatest(ClassRoomStudents.types.GET_CLASSROOM_STUDENTS, GetStudents),

    ]);
}

function* GetStudents({ classRoom }) {
    try {

        const data = yield call(getStudentsClassRoomRequestApi, classRoom);
        yield put({ type: ClassRoomStudents.types.SET_CLASSROOM_STUDENTS, data });       
    }

    catch (error) {
        yield put({ type: "API_CALL_ERROR" });
    }
}

function getStudentsClassRoomRequestApi(classRoom) {  
    return (fetch("/api/classRoomStudents/ListaAlunosDaTurma", {
        method: "post",
        headers: { 'content-type': 'application/json' },
        body: JSON.stringify(classRoom)
    }).then(response => response.json()));
}