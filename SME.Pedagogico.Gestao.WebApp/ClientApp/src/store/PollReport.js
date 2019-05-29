export const types = {
    SET_POLL_REPORT_FILTER: "SET_POLL_REPORT_FILTER",
    SHOW_POLL_REPORT_REQUEST: "SHOW_POLL_REPORT_REQUEST",
    HIDE_POLL_REPORT_REQUEST: "HIDE_POLL_REPORT_REQUEST",
    GET_POLL_REPORT_REQUEST: "GET_POLL_REPORT_REQUEST",
    SET_POLL_REPORT_DATA: "SET_POLL_REPORT_DATA",
    POLL_REPORT_API_REQUEST_FAIL: "POLL_REPORT_API_REQUEST_FAIL",
    POLL_REPORT_REQUEST_NOT_FOUND: "POLL_REPORT_REQUEST_NOT_FOUND",
}

const initialState = {
    filters: {
        math: {
            name: "Matemática",
            proficiencies: [
                { label: "Campo Aditivo", value: "campoAditivo" },
                { label: "Campo Multiplicativo", value: "campoMultiplicativo" },
                { label: "Números", value: "numeros" },
            ],
            terms: [
                { label: "1° Semestre", value: "semestre1" },
                { label: "2° Semestre", value: "semestre2" },
            ]
        },
        port: {
            name: "Língua Portuguesa",
            proficiencies: [
                { label: "Leitura", value: "leitura" },
                { label: "Escrita", value: "escrita" },
            ],
            terms: [
                { label: "1° Bimestre", value: "bimestre1" },
                { label: "2° Bimestre", value: "bimestre2" },
                { label: "3° Bimestre", value: "bimestre3" },
                { label: "4° Bimestre", value: "bimestre4" },
            ]
        }
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
}

export const actionCreators = {
    setPollReportFilter: (selectedFilter) => ({ type: types.SET_POLL_REPORT_FILTER, selectedFilter }),
    showPollReport: () => ({ type: types.SHOW_POLL_REPORT_REQUEST }),
    hidePollReport: () => ({ type: types.HIDE_POLL_REPORT_REQUEST }),
    getPollReport: (parameters) => ({ type: types.GET_POLL_REPORT_REQUEST, parameters }),
}

export const reducer = (state, action) => {
    state = state || initialState;

    switch (action.type) {
        case types.SET_POLL_REPORT_FILTER:
            return ({
                ...state,
                selectedFilter: action.selectedFilter,
            });
        case types.SHOW_POLL_REPORT_REQUEST:
            return ({
                ...state,
                showReport: true,
            });
        case types.HIDE_POLL_REPORT_REQUEST:
            return ({
                ...state,
                showReport: false,
            });
        case types.SET_POLL_REPORT_DATA:
            return ({
                ...state,
                data: action.pollReportResponse.data,
                chartData: action.pollReportResponse.chartData
            });
        default:
            return (state);
    }
}