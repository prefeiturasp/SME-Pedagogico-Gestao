export const types = {
    GET_DRE: "GET_DRE",
    LIST_DRES: "LIST_DRES",
    GET_SCHOOL: "GET_SCHOOL",
    LIST_SCHOOLS: "LIST_SCHOOLS",
    GET_CLASSROOM: "GET_CLASSROOM",
    LIST_CLASSROOM: "LIST_CLASSROOM",
    //UNAUTHORIZED: "UNAUTHORIZED",
    //LOGOUT_REQUEST: "LOGOUT_REQUEST",
    //LOGOUT_USER: "LOGOUT_USER",
    //ON_AUTHENTICATION_REQUEST: "ON_AUTHENTICATION_REQUEST",
    //FINISH_AUTHENTICATION_REQUEST: "FINISH_AUTHENTICATION_REQUEST",
}
const initialState = {
    listDres: [],
    shoolYear: null,
    dres: null,
    scholls: [],
    classRoom: null,
    yearClassRoom: null,
    activeDreCode: null,
    activeSchollsCode: null,
    activeYearClassRoomCode: null,
    activeClassRoomCode: null,
};

export const actionCreators = {
    getDre: () => ({ type: types.GET_DRE }),
    listDre: () => ({type: types.LIST_DRES}),
    getSchool: (schoolCode) => ({ type: types.GET_SCHOOL, schoolCode }),
    listSchool: () => ({ type: types.LIST_SCHOOLS }),
    getClassroom: (classroomCode) => ({ type: types.GET_CLASSROOM, classroomCode }),
    listClassRoom: () => ({ type: types.LIST_CLASSROOM }),

};

export const reducer = (state, action) => {
    state = state || initialState;

    switch (action.type) {
        case types.LIST_DRES:
            return ({
                ...state,
                listDres: action.listDres
            });
        case types.LIST_SCHOOLS:
            return ({
                ...state,
                scholls: action.listSchool,
            });
        case types.LOGOUT_USER:
            return ({
                ...state,
                ...initialState
            });
        case types.ON_AUTHENTICATION_REQUEST:
            return ({
                ...state,
                onAuthenticationRequest: true,
            });
        case types.FINISH_AUTHENTICATION_REQUEST:
            return ({
                ...state,
                onAuthenticationRequest: false,
            });
        default:
            return (state);
    }
};