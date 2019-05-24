export const types = {
    SET_POLL_INFO:"SET_POLL_INFO",
    GET_POLL_PORTUGUESE_STUDENTS: "GET_POLL_PORTUGUESE_STUDENTS",
    SET_POLL_PORTUGUESE_STUDENTS: "SET_POLL_PORTUGUESE_STUDENTS",

}

const initialState = {
    pollSelected: null,
    pollTypeSelected: null,
    pollYear: null,
    classRoom: [],
    students:[]
}

export const actionCreators = {
    get_poll_portuguese_students: (classRoom) => ({ type: types.GET_POLL_PORTUGUESE_STUDENTS, classRoom }),
    set_poll_info: (pollSelected, pollTypeSelected, pollYear) => ({ type: types.SET_POLL_INFO, pollSelected, pollTypeSelected, pollYear })

}

export const reducer = (state, action, pollSelected, pollTypeSelected, pollYear) => {
    state = state || initialState;
    switch (action.type) {
        case types.GET_POLL_PORTUGUESE_STUDENTS:
            var students = [{
                "name":"Eduarda dos Santos Costa",
                "studentCodeEol": "1",
                "sequenceNumber":"1",
                "dreCodeEol": "4",
                "schoolCodeEol": "44",
                "classroomCodeEol": "33",
                "schoolYear": "2019",
                "yearClassroom": "1",

                "t1e": "",
                "t1l": "",
                "t2e": "SSV",
                "t2l": "2",
                "t3e": "SCV",
                "t3l": "3",
                "t4e": "A",
                "t4l": "4",
            },
                {
                "name": "José Santos Costa",
                "studentCodeEol": "2",
                "sequenceNumber": "2",
                "dreCodeEol": "4",
                "schoolCodeEol": "44",
                "classroomCodeEol": "33",
                "schoolYear": "2019",
                "yearClassroom": "1",

                "t1e": "PS",
                "t1l": "4",
                "t2e": "SSV",
                "t2l": "3",
                "t3e": "A",
                "t3l": "2",
                "t4e": "",
                "t4l": "",
            }]
            return ({ ...state, classRoom: action.classRoom, students: students});
        case types.SET_POLL_PORTUGUESE_STUDENTS:
            return ({...state,classRoom: action.data,
            });
        case types.SET_POLL_INFO:
            return ({ ...state, pollSelected: action.pollSelected, pollTypeSelected: action.pollTypeSelected, pollYear:action.pollYear });
        default:
            return (state);
    }
}