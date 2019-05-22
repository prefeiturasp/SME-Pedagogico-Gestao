export const types = {
    GET_CLASSROOM_STUDENTS: "GET_CLASSROOM_STUDENTS",
    SET_CLASSROOM_STUDENTS: "SET_CLASSROOM_STUDENTS",

}

const initialState = {
    classRoom: []
}

export const actionCreators = {
    get_classroom_students: (classRoom) => ({
        type: types.GET_CLASSROOM_STUDENTS, classRoom
    })
}

export const reducer = (state, action) => {
    state = state || initialState;

    switch (action.type) {
        case types.SET_CLASSROOM_STUDENTS:
            return ({
                ...state,
                classRoom: action.data,
            });
        default:
            return (state);
    }
}