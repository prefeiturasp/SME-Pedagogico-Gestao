export const types = {
  SET_POLL_INFO: "SET_POLL_INFO",
  SET_POLL_TYPE_SELECTED: "SET_POLL_TYPE_SELECTED",
  SET_POLL_LIST_INITIAL_STATE: "SET_POLL_LIST_INITIAL_STATE",
  SET_POLL_DATA_SAVED_STATE: "SET_POLL_DATA_SAVED_STATE",
  RESET_POLL_SELECTED_FILTER_STATE: "RESET_POLL_SELECTED_FILTER_STATE",

  UPDATE_POLL_STUDENTS: "UPDATE_POLL_STUDENTS",
  GET_POLL_PORTUGUESE_STUDENTS: "GET_POLL_PORTUGUESE_STUDENTS",
  SET_POLL_PORTUGUESE_STUDENTS: "SET_POLL_PORTUGUESE_STUDENTS",
  SAVE_POLL_PORTUGUESE: "SAVE_POLL_PORTUGUESE",

  GET_POLL_MATH_NUMBERS_STUDENTS: "GET_POLL_MATH_NUMBERS_STUDENTS",
  SET_POLL_MATH_NUMBERS_STUDENTS: "SET_POLL_MATH_NUMBERS_STUDENTS",
  UPDATE_POLL_MATH_NUMBERS_STUDENTS: "UPDATE_POLL_MATH_NUMBERS_STUDENTS",
  SAVE_POLL_MATH_NUMBERS_STUDENTS: "SAVE_POLL_MATH_NUMBERS_STUDENTS",

  GET_POLL_MATH_CA_STUDENTS: "GET_POLL_MATH_CA_STUDENTS",
  SET_POLL_MATH_CA_STUDENTS: "SET_POLL_MATH_CA_STUDENTS",
  UPDATE_POLL_MATH_CA_STUDENTS: "UPDATE_POLL_MATH_CA_STUDENTS",
  SAVE_POLL_MATH_CA_STUDENTS: "SAVE_POLL_MATH_CA_STUDENTS",

  GET_POLL_MATH_CM_STUDENTS: "GET_POLL_MATH_CM_STUDENTS",
  SET_POLL_MATH_CM_STUDENTS: "SET_POLL_MATH_CM_STUDENTS",
  UPDATE_POLL_MATH_CM_STUDENTS: "UPDATE_POLL_MATH_CM_STUDENTS",
  SAVE_POLL_MATH_CM_STUDENTS: "SAVE_POLL_MATH_CM_STUDENTS",

  SET_SELECTED_FILTER: "SET_SELECTED_FILTER",
  SET_DATA_TO_SAVE_TRUE: "SET_DATA_TO_SAVE_TRUE",

  SET_FUNCTION_BUTTON_SAVE: "SET_FUNCTION_BUTTON_SAVE",
  SET_LOADING_SALVAR: "SET_LOADING_SALVAR",
  SET_BIMESTRE: "SET_BIMESTRE",
  SET_LOADING_PERGUNTAS: "SET_LOADING_PERGUNTAS",
  SET_NAVEGACAO_SELECIONADA: "SET_NAVEGACAO_SELECIONADA",
  OBTER_ALUNOS_ALFABETIZACAO: "OBTER_ALUNOS_ALFABETIZACAO",
  OBTER_PERGUNTAS_ALFABETIZACAO: "OBTER_PERGUNTAS_ALFABETIZACAO",
};

const initialState = {
  pollSelected: null, //MT/PT
  pollTypeSelected: null, //somente matemática  CA/CM/Numeric
  pollYear: null, //1,2,3...6
  classRoom: [],
  students: [], //students for poll Portuguese
  studentsPollMathNumbers: [], //students for poll math numbers
  studentsPollMathCA: [], //students for poll math CA
  studentsPollMathCM: [], //students for poll math CM
  onClickButtonSave: null,
  selectedFilter: {
    dreCodeEol: null,
    schoolCodeEol: null,
    classroomCodeEol: null,
    schoolYear: null,
    yearClassroom: null,
    rfCode: null,
  },
  newDataToSave: false,
  loadingSalvar: false,
  bimestre: null,
  loadingPerguntas: false,
  navSelected: "",
};

export const actionCreators = {
  set_poll_info: (pollSelected, pollTypeSelected, pollYear) => ({
    type: types.SET_POLL_INFO,
    pollSelected,
    pollTypeSelected,
    pollYear,
  }),
  set_poll_type_selected: (pollTypeSelected) => ({
    type: types.SET_POLL_TYPE_SELECTED,
    pollTypeSelected,
  }),
  set_poll_list_initial_state: () => ({
    type: types.SET_POLL_LIST_INITIAL_STATE,
  }),
  set_poll_data_saved_state: () => ({ type: types.SET_POLL_DATA_SAVED_STATE }),
  reset_poll_selected_filter_state: () => ({
    type: types.RESET_POLL_SELECTED_FILTER_STATE,
  }),

  update_poll_students: (pollstudents) => ({
    type: types.UPDATE_POLL_STUDENTS,
    pollstudents,
  }),
  set_poll_portuguese_students: (pollstudents) => ({
    type: types.SET_POLL_PORTUGUESE_STUDENTS,
    pollstudents,
  }),

  get_poll_portuguese_students: (classRoom) => ({
    type: types.GET_POLL_PORTUGUESE_STUDENTS,
    classRoom,
  }),
  save_poll_portuguese_student: (pollstudents) => ({
    type: types.SAVE_POLL_PORTUGUESE,
    pollstudents,
  }),

  get_poll_math_numbers_students: (classRoom) => ({
    type: types.GET_POLL_MATH_NUMBERS_STUDENTS,
    classRoom,
  }),
  set_poll_math_numbers_students: (classRoom) => ({
    type: types.SET_POLL_MATH_NUMBERS_STUDENTS,
    classRoom,
  }),
  update_poll_math_numbers_students: (pollstudents) => ({
    type: types.UPDATE_POLL_MATH_NUMBERS_STUDENTS,
    pollstudents,
  }),
  save_poll_math_numbers_students: (pollstudents) => ({
    type: types.SAVE_POLL_MATH_NUMBERS_STUDENTS,
    pollstudents,
  }),

  get_poll_math_ca_students: (classRoom) => ({
    type: types.GET_POLL_MATH_CA_STUDENTS,
    classRoom,
  }),
  set_poll_math_ca_students: (classRoom) => ({
    type: types.SET_POLL_MATH_CA_STUDENTS,
    classRoom,
  }),
  update_poll_math_ca_students: (pollstudents) => ({
    type: types.UPDATE_POLL_MATH_CA_STUDENTS,
    pollstudents,
  }),
  save_poll_math_ca_students: (pollstudents) => ({
    type: types.SAVE_POLL_MATH_CA_STUDENTS,
    pollstudents,
  }),

  get_poll_math_cm_students: (classRoom) => ({
    type: types.GET_POLL_MATH_CM_STUDENTS,
    classRoom,
  }),
  set_poll_math_cm_students: (classRoom) => ({
    type: types.SET_POLL_MATH_CM_STUDENTS,
    classRoom,
  }),
  update_poll_math_cm_students: (pollstudents) => ({
    type: types.UPDATE_POLL_MATH_CM_STUDENTS,
    pollstudents,
  }),
  save_poll_math_cm_students: (pollstudents) => ({
    type: types.SAVE_POLL_MATH_CM_STUDENTS,
    pollstudents,
  }),

  setSelectedFilter: (filters) => ({
    type: types.SET_SELECTED_FILTER,
    filters,
  }),

  setDataToSaveTrue: () => ({ type: types.SET_DATA_TO_SAVE_TRUE }),

  setFunctionButtonSave: (payload) => ({
    type: types.SET_FUNCTION_BUTTON_SAVE,
    payload,
  }),

  setLoadingSalvar: (payload) => ({
    type: types.SET_LOADING_SALVAR,
    payload,
  }),

  setBimestre: (payload) => ({
    type: types.SET_BIMESTRE,
    payload,
  }),

  setNavegacaoSelecionada: (payload) => ({
    type: types.SET_NAVEGACAO_SELECIONADA,
    payload,
  }),

  obterAlunosAlfabetizacao: (payload) => ({
    type: types.OBTER_ALUNOS_ALFABETIZACAO,
    payload,
  }),

  obterPerguntasAlfabetizacao: (payload) => ({
    type: types.OBTER_PERGUNTAS_ALFABETIZACAO,
    payload,
  }),
};

export const reducer = (state, action) => {
  state = state || initialState;

  switch (action.type) {
    case types.SET_POLL_INFO:
      return {
        ...state,
        pollSelected: action.pollSelected,
        pollTypeSelected: action.pollTypeSelected,
        pollYear: action.pollYear,
        newDataToSave: false,
      };
    case types.SET_FUNCTION_BUTTON_SAVE:
      return {
        ...state,
        onClickButtonSave: action.payload,
      };
    case types.SET_POLL_TYPE_SELECTED:
      return {
        ...state,
        pollTypeSelected: action.pollTypeSelected,
        newDataToSave: false,
      };
    case types.SET_POLL_LIST_INITIAL_STATE:
      return {
        ...state,
        students: initialState.students,
        studentsPollMathNumbers: initialState.studentsPollMathNumbers,
        studentsPollMathCA: initialState.studentsPollMathCA,
        studentsPollMathCM: initialState.studentsPollMathCM,
        newDataToSave: false,
      };
    case types.SET_POLL_DATA_SAVED_STATE:
      return { ...state, newDataToSave: false };
    case types.SET_DATA_TO_SAVE_TRUE:
      return { ...state, newDataToSave: true };
    case types.RESET_POLL_SELECTED_FILTER_STATE:
      return {
        ...state,
        selectedFilter: initialState.selectedFilter,
        students: initialState.students,
        studentsPollMathNumbers: initialState.studentsPollMathNumbers,
        studentsPollMathCA: initialState.studentsPollMathCA,
        studentsPollMathCM: initialState.studentsPollMathCM,
        newDataToSave: false,
      };
    case types.SET_POLL_PORTUGUESE_STUDENTS:
      return {
        ...state,
        students: action.data,
      };
    case types.SET_POLL_MATH_NUMBERS_STUDENTS:
      return {
        ...state,
        studentsPollMathNumbers: action.data,
      };
    case types.SET_POLL_MATH_CA_STUDENTS:
      return {
        ...state,
        studentsPollMathCA: action.data,
      };
    case types.SET_POLL_MATH_CM_STUDENTS:
      return {
        ...state,
        studentsPollMathCM: action.data,
      };
    case types.UPDATE_POLL_STUDENTS:
      return {
        ...state,
        students: action.pollstudents,
        newDataToSave: true,
      };
    case types.UPDATE_POLL_MATH_NUMBERS_STUDENTS:
      return {
        ...state,
        studentsPollMathNumbers: action.pollstudents,
        newDataToSave: true,
      };
    case types.UPDATE_POLL_MATH_CA_STUDENTS:
      return {
        ...state,
        studentsPollMathCA: action.pollstudents,
        newDataToSave: true,
      };
    case types.UPDATE_POLL_MATH_CM_STUDENTS:
      return {
        ...state,
        studentsPollMathCM: action.pollstudents,
        newDataToSave: true,
      };

    case types.SET_SELECTED_FILTER:
      return {
        ...state,
        selectedFilter: action.filters,
        pollSelected: initialState.pollSelected,
        pollTypeSelected: initialState.pollTypeSelected,
        pollYear: initialState.pollYear,
        students: initialState.students,
        studentsPollMathNumbers: initialState.studentsPollMathNumbers,
        studentsPollMathCA: initialState.studentsPollMathCA,
        studentsPollMathCM: initialState.studentsPollMathCM,
        newDataToSave: false,
      };
    case types.SET_LOADING_SALVAR:
      return {
        ...state,
        loadingSalvar: action.filters,
      };

    case types.SET_BIMESTRE:
      return {
        ...state,
        bimestre: action.payload,
      };

    case types.SET_LOADING_PERGUNTAS:
      return {
        ...state,
        loadingPerguntas: action.loadingPerguntas,
      };

    case types.SET_NAVEGACAO_SELECIONADA:
      return {
        ...state,
        navSelected: action.payload,
      };

    default:
      return state;
  }
};
