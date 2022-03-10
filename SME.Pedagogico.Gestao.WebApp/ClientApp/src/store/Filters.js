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
  SET_SCHOOLYEAR: "SET_SCHOOLYEAR",
  GET_PERIOD: "GET_PERIOD",
  SET_PERIOD: "SET_PERIOD",
  PERIODO_ABERTURA_MAT: "PERIODO_ABERTURA_MAT",
  GET_LIST_DISCIPLINES_BY_CLASSROOM: "GET_LIST_DISCIPLINES_BY_CLASSROOM",
  LIST_DISCIPLINES: "LIST_DISCIPLINES",
  DISCIPLINES_FILTER: "DISCIPLINES_FILTER",
  RESET_FILTERS: "RESET_FILTERS",
};

const initialState = {
  listDres: [],
  setSchoolYear: null,
  scholls: [],
  listClassRoom: null,
  yearClassRoom: null,
  activeDreCode: null,
  activeSchollsCode: null,
  activeYearClassRoomCode: null,
  activeClassRoomCode: null,
  filterTeachers: null,
  period: null,
  abertura1Semestre: false,
  abertura2Semestre: false,
  listDisciplines: [],
};

export const actionCreators = {
  getListDres: () => ({
    type: types.GET_DRE,
  }),
  listDre: () => ({
    type: types.LIST_DRES,
  }),
  getSchool: (schoolCode) => ({
    type: types.GET_SCHOOL,
    schoolCode,
  }),
  listSchool: () => ({
    type: types.LIST_SCHOOLS,
  }),
  getClassroom: (classRoomFilter) => ({
    type: types.GET_CLASSROOM,
    classRoomFilter,
  }),
  listClassRoom: () => ({
    type: types.LIST_CLASSROOM,
  }),
  activeClassroom: (codeClass) => ({
    type: types.ACTIVECLASSROOMCODE,
    codeClass,
  }),
  setSchoolYear: (schoolYear) => ({
    type: types.SET_SCHOOLYEAR,
    schoolYear,
  }),
  resetPollFilters: () => ({
    type: types.RESET_POLL_FILTERS,
  }),
  getFilters_teacher: (profileOccupatios) => ({
    type: types.GET_FILTERS_TEACHER,
    profileOccupatios,
  }),
  activeDreCode: (schoolCode) => ({
    type: types.ACTIVEDRECODE,
    schoolCode,
  }),
  activeSchoolCode: (classRoomFilter) => ({
    type: types.ACTIVESCHOOLCODE,
    classRoomFilter,
  }),
  getDreAdm: (userName) => ({
    type: types.GET_DRE_ADM,
    userName,
  }),
  getPeriod: (schoolYear) => ({
    type: types.GET_PERIOD,
    schoolYear,
  }),
  setPeriod: () => ({
    type: types.SET_PERIOD,
  }),
  verificaPeriodosMatematica: () => ({
    type: types.PERIODO_ABERTURA_MAT,
  }),
  getDisciplinesByClassroom: (disciplinesFilter) => ({
    type: types.GET_LIST_DISCIPLINES_BY_CLASSROOM,
    disciplinesFilter,
  }),
  listDisciplines: () => ({
    type: types.LIST_DISCIPLINES,
  }),
  resetFilters: () => ({
    type: types.RESET_FILTERS,
  }),
};

export const reducer = (state, action) => {
  state = state || initialState;
  switch (action.type) {
    case types.LIST_DRES:
      return {
        ...state,
        listDres: action.listDres,
      };
    case types.LIST_SCHOOLS:
      return {
        ...state,
        scholls: action.listSchool,
      };
    case types.LIST_CLASSROOM:
      return {
        ...state,
        listClassRoom: action.listClassRoom,
      };
    case types.ACTIVEDRECODE:
      return {
        ...state,
        activeDreCode: action.schoolCode.dreCodeEol,
      };
    case types.ACTIVESCHOOLCODE:
      return {
        ...state,
        activeSchollsCode: action.classRoomFilter.schoolCodeEol,
      };
    case types.ACTIVECLASSROOMCODE:
      return {
        ...state,
        activeClassRoomCode: action.codeClass,
      };
    case types.RESET_POLL_FILTERS:
      return {
        ...state,
        ...initialState,
        listDisciplines: state.listDisciplines,
      };
    case types.SET_FILTERS_TEACHER:
      return {
        ...state,
        filterTeachers: action.filters,
        scholls: action.filters.escolas,
        listDres: action.filters.drEs,
        listClassRoom: action.filters.turmas,
      };
    case types.SET_SCHOOLYEAR:
      return {
        ...state,
        setSchoolYear: action.schoolYear,
      };
    case types.SET_PERIOD:
      return {
        ...state,
        period: action.listPeriod,
      };
    case types.PERIODO_ABERTURA_MAT:
      var todayDate = new Date();
      let estadoRetorno = {
        ...state,
      };

      state &&
        state.period &&
        state.period.length &&
        state.period.forEach((item) => {
          if (item.bimestre === 2) {
            if (
              todayDate >= new Date(item.dataInicio) &&
              todayDate <= new Date(item.dataFim)
            ) {
              estadoRetorno = {
                ...state,
                abertura1Semestre: true,
              };
            }
          }
          if (item.bimestre === 4) {
            if (
              todayDate >= new Date(item.dataInicio) &&
              todayDate <= new Date(item.dataFim)
            ) {
              estadoRetorno = {
                ...state,
                ...estadoRetorno,
                abertura2Semestre: true,
              };
            }
          }
        });
      return estadoRetorno;
    case types.LIST_DISCIPLINES:
      return {
        ...state,
        listDisciplines: action.listDisciplines,
      };
    case types.RESET_FILTERS:
      return {
        ...state,
        activeDreCode: null,
        activeSchollsCode: null,
        activeClassRoomCode: null,
        scholls: [],
        listClassRoom: null,
        yearClassRoom: null,
      };
    default:
      return state;
  }
};
