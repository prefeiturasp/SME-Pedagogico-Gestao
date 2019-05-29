﻿import { actionChannel } from "redux-saga/effects";

export const types = {
    SET_POLL_INFO: "SET_POLL_INFO",
    SET_POLL_TYPE_SELECTED: "SET_POLL_TYPE_SELECTED",
    UPDATE_POLL_STUDENTS: "UPDATE_POLL_STUDENTS",

    GET_POLL_PORTUGUESE_STUDENTS: "GET_POLL_PORTUGUESE_STUDENTS",
    SET_POLL_PORTUGUESE_STUDENTS: "SET_POLL_PORTUGUESE_STUDENTS",
    SAVE_POLL_PORTUGUESE: "SAVE_POLL_PORTUGUESE",
        
    GET_POLL_MATH_NUMBERS_STUDENTS: "GET_POLL_MATH_NUMBERS_STUDENTS",
    SET_POLL_MATH_NUMBERS_STUDENTS: "SET_POLL_MATH_NUMBERS_STUDENTS",
    SAVE_POLL_MATH_NUMBERS_STUDENTS: "SAVE_POLL_MATH_NUMBERS_STUDENTS",

    GET_POLL_MATH_CA_STUDENTS: "GET_POLL_MATH_CA_STUDENTS",
    SET_POLL_MATH_CA_STUDENTS: "SET_POLL_MATH_CA_STUDENTS",
    SAVE_POLL_MATH_CA_STUDENTS: "SAVE_POLL_MATH_CA_STUDENTS",

    GET_POLL_MATH_CM_STUDENTS: "GET_POLL_MATH_CM_STUDENTS",
    SET_POLL_MATH_CM_STUDENTS: "SET_POLL_MATH_CM_STUDENTS",
    SAVE_POLL_MATH_CM_STUDENTS: "SAVE_POLL_MATH_CM_STUDENTS",
}

const initialState = {
    pollSelected: null, //MT/PT
    pollTypeSelected: null, //somente matemática  CA/CM/Numeric
    pollYear: null, //1,2,3...6
    classRoom: [],
    students:[]
}

export const actionCreators = {
    set_poll_info: (pollSelected, pollTypeSelected, pollYear) => ({ type: types.SET_POLL_INFO, pollSelected, pollTypeSelected, pollYear }),
    set_poll_type_selected: (pollTypeSelected) => ({ type: types.SET_POLL_TYPE_SELECTED, pollTypeSelected }),


    update_poll_students: (pollstudents) => ({ type: types.UPDATE_POLL_STUDENTS, pollstudents }),
    set_poll_portuguese_students: (pollstudents) => ({ type: types.SET_POLL_PORTUGUESE_STUDENTS, pollstudents }),

    get_poll_portuguese_students: (classRoom) => ({ type: types.GET_POLL_PORTUGUESE_STUDENTS, classRoom }),
    save_poll_portuguese_student: (pollstudents) => ({ type: types.SAVE_POLL_PORTUGUESE, pollstudents }),

    get_poll_math_numbers_students: (classRoom) => ({ type: types.GET_POLL_MATH_NUMBERS_STUDENTS, classRoom }),
    set_poll_math_numbers_students: (classRoom) => ({ type: types.SET_POLL_MATH_NUMBERS_STUDENTS, classRoom }),
    save_poll_math_numbers_students: (pollstudents) => ({ type: types.SAVE_POLL_MATH_NUMBERS_STUDENTS, pollstudents }),

    get_poll_math_ca_students: (classRoom) => ({ type: types.GET_POLL_MATH_CA_STUDENTS, classRoom }),
    set_poll_math_ca_students: (classRoom) => ({ type: types.SET_POLL_MATH_CA_STUDENTS, classRoom }),
    save_poll_math_ca_students: (pollstudents) => ({ type: types.SAVE_POLL_MATH_CA_STUDENTS, pollstudents }),

    get_poll_math_cm_students: (classRoom) => ({ type: types.GET_POLL_MATH_CM_STUDENTS, classRoom }),
    set_poll_math_cm_students: (classRoom) => ({ type: types.SET_POLL_MATH_CM_STUDENTS, classRoom }),
    save_poll_math_cm_students: (pollstudents) => ({ type: types.SAVE_POLL_MATH_CM_STUDENTS, pollstudents }),
}

export const reducer = (state, action, pollSelected, pollTypeSelected, pollYear, pollstudents) => {
    state = state || initialState;

    switch (action.type) {
         
        case types.SET_POLL_INFO:
            return ({ ...state, pollSelected: action.pollSelected, pollTypeSelected: action.pollTypeSelected, pollYear: action.pollYear });
        case types.SET_POLL_TYPE_SELECTED:
            return ({ ...state, pollTypeSelected: action.pollTypeSelected});
        case types.SET_POLL_PORTUGUESE_STUDENTS:
            return ({
                ...state, students: action.data,
            });
        case types.SET_POLL_MATH_NUMBERS_STUDENTS:
            return ({
                ...state, students: action.data,
            });
        case types.SET_POLL_MATH_CA_STUDENTS:
            return ({
                ...state, students: action.data,
            });
        case types.SET_POLL_MATH_CM_STUDENTS:
            return ({
                ...state, students: action.data,
            });
        case types.UPDATE_POLL_STUDENTS:
            return ({
                ...state, students: action.pollstudents
            });
        default:
            return (state);
    }
}