// Store filters 	
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
    RESET_POLL_FILTERS: "RESET_POLL_FILTERS",
    GET_FILTERS_TEACHER: "GET_FILTERS_TEACHER",
    SET_FILTERS_TEACHER: "SET_FILTERS_TEACHER",
    GET_DRE_ADM: "GET_DRE_ADM",

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
    filterTeachers: null,
};

export const actionCreators = {
    getListDres: () => ({ type: types.GET_DRE }),
    listDre: () => ({ type: types.LIST_DRES }),
    getSchool: (schoolCode) => ({ type: types.GET_SCHOOL, schoolCode }),
    listSchool: () => ({ type: types.LIST_SCHOOLS }),
    getClassroom: (classRoomFilter) => ({ type: types.GET_CLASSROOM, classRoomFilter }),
    listClassRoom: () => ({ type: types.LIST_CLASSROOM }),
    activeClassroom: (codeClass) => ({ type: types.ACTIVECLASSROOMCODE, codeClass }),
    resetPollFilters: () => ({ type: types.RESET_POLL_FILTERS }),
    getFilters_teacher: (profileOccupatios) => ({ type: types.GET_FILTERS_TEACHER, profileOccupatios }),
    activeDreCode: (schoolCode) => ({ type: types.ACTIVEDRECODE, schoolCode }),
    activeSchoolCode: (classRoomFilter) => ({ type: types.ACTIVESCHOOLCODE, classRoomFilter  }),
    getDreAdm: (userName) => ({type: types.GET_DRE_ADM, userName}),
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
            });
        case types.SET_FILTERS_TEACHER:
            return ({
                ...state,
                filterTeachers: action.filters,
                scholls: action.filters.escolas,
                listDres: action.filters.drEs,
                listClassRoom: action.filters.turmas
            });
          
        default:
            return (state);
    }
};