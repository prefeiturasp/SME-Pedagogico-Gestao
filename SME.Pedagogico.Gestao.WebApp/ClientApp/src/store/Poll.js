export const types = {
    SET_POLL_INFO:"SET_POLL_INFO",
    UPDATE_POLL_STUDENTS: "UPDATE_POLL_STUDENTS",

    GET_POLL_PORTUGUESE_STUDENTS: "GET_POLL_PORTUGUESE_STUDENTS",
    SET_POLL_PORTUGUESE_STUDENTS: "SET_POLL_PORTUGUESE_STUDENTS",
    SAVE_POLL_PORTUGUESE: "SAVE_POLL_PORTUGUESE",

    
    GET_POLL_MATH_NUMBERS_STUDENTS: "GET_POLL_MATH_NUMBERS_STUDENTS",
    SAVE_POLL_MATH_NUMBERS_STUDENTS: "SAVE_POLL_MATH_NUMBERS_STUDENTS",

}

const initialState = {
    pollSelected: null,
    pollTypeSelected: null,
    pollYear: null,
    classRoom: [],
    students:[]
}

export const actionCreators = {
    set_poll_info: (pollSelected, pollTypeSelected, pollYear) => ({ type: types.SET_POLL_INFO, pollSelected, pollTypeSelected, pollYear }),

    update_poll_students: (pollstudents) => ({ type: types.UPDATE_POLL_STUDENTS, pollstudents }),
    set_poll_portuguese_students: (pollstudents) => ({ type: types.SET_POLL_PORTUGUESE_STUDENTS, pollstudents }),

    get_poll_portuguese_students: (classRoom) => ({ type: types.GET_POLL_PORTUGUESE_STUDENTS, classRoom }),
    save_poll_portuguese_student: (pollstudents) => ({ type: types.SAVE_POLL_PORTUGUESE, pollstudents }),

    get_poll_math_numbers_students: () => ({ type: types.GET_POLL_MATH_NUMBERS_STUDENTS}),
}

export const reducer = (state, action, pollSelected, pollTypeSelected, pollYear, pollstudents) => {
    state = state || initialState;

    switch (action.type) {
         
        case types.SET_POLL_INFO:
            return ({ ...state, pollSelected: action.pollSelected, pollTypeSelected: action.pollTypeSelected, pollYear: action.pollYear });
        //case types.GET_POLL_PORTUGUESE_STUDENTS:
        //    var students = [{
        //        "name":"Eduarda dos Santos Costa",
        //        "studentCodeEol": "1",
        //        "sequenceNumber":"1",
        //        "dreCodeEol": "4",
        //        "schoolCodeEol": "44",
        //        "classroomCodeEol": "33",
        //        "schoolYear": "2019",
        //        "yearClassroom": "1",

        //        "t1e": "",
        //        "t1l": "",
        //        "t2e": "SSV",
        //        "t2l": "2",
        //        "t3e": "SCV",
        //        "t3l": "3",
        //        "t4e": "A",
        //        "t4l": "4",
        //    },
        //        {
        //        "name": "José Santos Costa",
        //        "studentCodeEol": "2",
        //        "sequenceNumber": "2",
        //        "dreCodeEol": "4",
        //        "schoolCodeEol": "44",
        //        "classroomCodeEol": "33",
        //        "schoolYear": "2019",
        //        "yearClassroom": "1",

        //        "t1e": "PS",
        //        "t1l": "4",
        //        "t2e": "SSV",
        //        "t2l": "3",
        //        "t3e": "A",
        //        "t3l": "2",
        //        "t4e": "",
        //        "t4l": "",
        //    }]
        //    return ({ ...state, classRoom: action.classRoom, students: students});
        case types.SET_POLL_PORTUGUESE_STUDENTS:
         
            return ({
               
                ...state, students: action.data,
            });
   
        case types.UPDATE_POLL_STUDENTS:
            return ({
                ...state, students: action.pollstudents
            });
        case types.GET_POLL_MATH_NUMBERS_STUDENTS:
            var students = [{
                "name": "Eduarda dos Santos Costa",
                "studentCodeEol": "1",
                "sequenceNumber": "1",
                "dreCodeEol": "4",
                "schoolCodeEol": "44",
                "classroomCodeEol": "33",
                "schoolYear": "2019",
                "yearClassroom": "1",

                "familiares1S": "S",
                "familiares2S": "",

                "opacos1S": "S",
                "opacos2S": "",

                "transparentes1S": "N",
                "transparentes2S": "",

                "terminamzero1S": "S",
                "terminamzero2S": "",

                "algarismos1S": "S",
                "algarismos2S": "N",

                "processo1S": "S",
                "processo2S": "",

                "zerointercalados1S": "S",
                "zerointercalados2S": "",
                
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

                "familiares1S": "S",
                "familiares2S": "N",

                "opacos1S": "S",
                "opacos2S": "N",

                "transparentes1S": "N",
                "transparentes2S": "",

                "terminamzero1S": "",
                "terminamzero2S": "",

                "algarismos1S": "",
                "algarismos2S": "",

                "processo1S": "",
                "processo2S": "",

                "zerointercalados1S": "",
                "zerointercalados2S": "",
            }]
            return ({ ...state, classRoom: action.classRoom, students: students });
        default:
            return (state);
    }
}