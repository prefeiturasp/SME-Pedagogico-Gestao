export const types = {
    GET_DRE: "GET_DRE",
    LIST_DRES: "LIST_DRES",
    GET_SCHOOL: "GET_SCHOOL",
    LIST_SCHOOLS: "LIST_SCHOOLS",
    GET_CLASSROOM: "GET_CLASSROOM",
    LIST_CLASSROOM: "LIST_CLASSROOM",
    ACTIVEDRECODE: "ACTIVEDRECODE",
    ACTIVESCHOOLCODE: "ACTIVESCHOOLCODE",
    ACTIVECLASSROOMCODE: "ACTIVECLASSROOMCODE",
    RESET_POLL_FILTERS: "RESET_POLL_FILTERS,"

    //UNAUTHORIZED: "UNAUTHORIZED",
    //LOGOUT_REQUEST: "LOGOUT_REQUEST",
    //LOGOUT_USER: "LOGOUT_USER",
    //ON_AUTHENTICATION_REQUEST: "ON_AUTHENTICATION_REQUEST",
    //FINISH_AUTHENTICATION_REQUEST: "FINISH_AUTHENTICATION_REQUEST",
}
const initialState = {
    listDres: [],
    shoolYear: null,
    scholls: [],
    listClassRoom: null,
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
    getClassroom: (classRoomFilter) => ({ type: types.GET_CLASSROOM, classRoomFilter }),
    listClassRoom: () => ({ type: types.LIST_CLASSROOM }),
    activeClassroom: (codeClass) => ({ type: types.ACTIVECLASSROOMCODE, codeClass }),
    resetPollFilters: () => ({ type: types.RESET_POLL_FILTERS }),
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
        case types.LIST_CLASSROOM:
            return ({
                ...state,
                listClassRoom: action.listClassRoom,
            });
        case types.ACTIVEDRECODE:
            return ({
                ...state,
                activeDreCode: action.schoolCode.dreCodeEol,
            });
        case types.ACTIVESCHOOLCODE:
            return ({
                ...state,
                activeSchollsCode: action.classRoomFilter.schoolCodeEol,
            });
        case types.ACTIVECLASSROOMCODE:
            return ({
                ...state,
                activeClassRoomCode: action.codeClass,
            });
        case types.RESET_POLL_FILTERS:
            return ({
                ...state,
                ...initialState
            })
        default:
            return (state);
    }
};