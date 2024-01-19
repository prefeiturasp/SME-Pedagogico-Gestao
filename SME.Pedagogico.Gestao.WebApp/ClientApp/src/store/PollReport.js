export const types = {
  SET_POLL_REPORT_FILTER: "SET_POLL_REPORT_FILTER",
  RESET_POLL_REPORT_FILTER: "RESET_POLL_REPORT_FILTER",
  SHOW_POLL_REPORT_REQUEST: "SHOW_POLL_REPORT_REQUEST",
  HIDE_POLL_REPORT_REQUEST: "HIDE_POLL_REPORT_REQUEST",
  GET_POLL_REPORT_REQUEST: "GET_POLL_REPORT_REQUEST",
  SET_POLL_REPORT_DATA: "SET_POLL_REPORT_DATA",
  POLL_REPORT_API_REQUEST_FAIL: "POLL_REPORT_API_REQUEST_FAIL",
  POLL_REPORT_REQUEST_NOT_FOUND: "POLL_REPORT_REQUEST_NOT_FOUND",
  RESET_DATA: "RESET_DATA",
  PRINT_POLL_REPORT: "PRINT_POLL_REPORT",
  PRINTING_POLL_REPORT: "PRINTING_POLL_REPORT",
  SET_POLL_REPORT_LINK_PDF: "SET_POLL_REPORT_LINK_PDF",
  SHOW_POLL_REPORT_MESSAGE_SUCCESS: "SHOW_POLL_REPORT_MESSAGE_SUCCESS",
  SHOW_POLL_REPORT_MESSAGE_ERROR: "SHOW_POLL_REPORT_MESSAGE_ERROR",
  CANCEL_POLL_REPORT_REQUEST: "CANCEL_POLL_REPORT_REQUEST",
  ABORT_CONTROLLER_POLL_REPORT_REQUEST: "ABORT_CONTROLLER_POLL_REPORT_REQUEST",
  SET_LOADING_SEARCH_POLL_REPORT: "SET_LOADING_SEARCH_POLL_REPORT",
};

const initialState = {
  filters: {
    math: {
      id: 1,
      name: "Matemática",
      proficiencies: [
        { id: 1, label: "Campo Aditivo", value: "campoAditivo" },
        { id: 2, label: "Campo Multiplicativo", value: "campoMultiplicativo" },
        { id: 3, label: "Números", value: "numeros" },
      ],
      terms: [
        { label: "1° Semestre", value: "semestre1" },
        { label: "2° Semestre", value: "semestre2" },
      ],
      newTerms: [
        { label: "1° Bimestre", value: "bimestre1" },
        { label: "2° Bimestre", value: "bimestre2" },
        { label: "3° Bimestre", value: "bimestre3" },
        { label: "4° Bimestre", value: "bimestre4" },
      ],
    },
    port: {
      id: 2,
      name: "Língua Portuguesa",
      proficiencies: [
        { id: 4, label: "Leitura", value: "leitura" },
        { id: 5, label: "Escrita", value: "escrita" },
      ],
      terms: [
        { label: "1° Bimestre", value: "bimestre1" },
        { label: "2° Bimestre", value: "bimestre2" },
        { label: "3° Bimestre", value: "bimestre3" },
        { label: "4° Bimestre", value: "bimestre4" },
      ],
      newTerms: [
        { label: "1° Semestre", value: "semestre1" },
        { label: "2° Semestre", value: "semestre2" },
      ],
    },
  },
  selectedFilter: {
    discipline: null,
    proficiency: null,
    term: null,
    classroomReport: false,
  },
  showReport: false,
  data: null,
  chartData: null,
  printing: false,
  linkPdf: "",
  showMessageSuccess: false,
  showMessageError: false,
  cancelPollReportRequest: false,
  messageError: "",
  abortController: null,
  loadingSearchPollReport: false,
};

export const actionCreators = {
  setPollReportFilter: (selectedFilter) => ({
    type: types.SET_POLL_REPORT_FILTER,
    selectedFilter,
  }),
  resetPollReportFilter: () => ({ type: types.RESET_POLL_REPORT_FILTER }),
  showPollReport: () => ({ type: types.SHOW_POLL_REPORT_REQUEST }),
  hidePollReport: () => ({ type: types.HIDE_POLL_REPORT_REQUEST }),
  getPollReport: (parameters) => ({
    type: types.GET_POLL_REPORT_REQUEST,
    parameters,
  }),
  resetData: () => ({ type: types.RESET_DATA }),
  printPollReport: (parameters) => ({
    type: types.PRINT_POLL_REPORT,
    parameters,
  }),
  printingPollReport: (printing) => ({
    type: types.PRINTING_POLL_REPORT,
    printing,
  }),
  showMessageSuccessPollReport: (showMessageSuccess) => ({
    type: types.SHOW_POLL_REPORT_MESSAGE_SUCCESS,
    showMessageSuccess,
  }),
  showMessageErrorPollReport: (showMessageError, messageError) => ({
    type: types.SHOW_POLL_REPORT_MESSAGE_ERROR,
    showMessageError,
    messageError,
  }),
  cancelPollReportRequest: (cancelPollReportRequest) => ({
    type: types.CANCEL_POLL_REPORT_REQUEST,
    cancelPollReportRequest,
  }),
  setLoadingSearchPollReport: (loadingSearchPollReport) => ({
    type: types.SET_LOADING_SEARCH_POLL_REPORT,
    loadingSearchPollReport,
  }),
};

export const reducer = (state, action) => {
  state = state || initialState;
  switch (action.type) {
    case types.SET_POLL_REPORT_FILTER:
      return {
        ...state,
        selectedFilter: action.selectedFilter,
      };
    case types.RESET_POLL_REPORT_FILTER:
      return {
        ...state,
        selectedFilter: initialState.selectedFilter,
      };
    case types.SHOW_POLL_REPORT_REQUEST:
      return {
        ...state,
        showReport: true,
      };
    case types.HIDE_POLL_REPORT_REQUEST:
      return {
        ...state,
        showReport: false,
      };
    case types.RESET_DATA:
      return {
        ...state,
        data: null,
        chartData: null,
      };
    case types.SET_POLL_REPORT_DATA:
        return {
          ...state,
          data: action.pollReportResponse.data,
          chartData: action?.pollReportResponse?.chartData || action?.pollReportResponse?.data?.graficos,
        };
    case types.PRINTING_POLL_REPORT:
      return {
        ...state,
        printing: action.printing,
      };
    case types.SET_POLL_REPORT_LINK_PDF:
      return {
        ...state,
        linkPdf: action.linkPdf,
      };
    case types.SHOW_POLL_REPORT_MESSAGE_SUCCESS:
      return {
        ...state,
        showMessageSuccess: action.showMessageSuccess,
      };
    case types.SHOW_POLL_REPORT_MESSAGE_ERROR:
      return {
        ...state,
        showMessageError: action.showMessageError,
        messageError: action.messageError,
      };
    case types.CANCEL_POLL_REPORT_REQUEST:
      return {
        ...state,
        cancelPollReportRequest: action.cancelPollReportRequest,
      };
    case types.ABORT_CONTROLLER_POLL_REPORT_REQUEST:
      return {
        ...state,
        abortController: action.abortController,
      };
    case types.SET_LOADING_SEARCH_POLL_REPORT:
      return {
        ...state,
        loadingSearchPollReport: action.loadingSearchPollReport,
      };
    default:
      return state;
  }
};
