export const types = {
    OPEN_MONTH_REQUEST: "OPEN_MONTH_REQUEST",
    TOGGLE_FULLMONTH_REQUEST: "TOGGLE_FULLMONTH_REQUEST",
    SELECT_DAY_REQUEST: "SELECT_DAY_REQUEST",
}
const initialState = {
    months: {
        1: {
            name: "Janeiro",
            className: "d-flex border",
            appointments: 0,
            chevronColor: "#C4C4C4",
            isOpen: false,
        },
        2: {
            name: "Fevereiro",
            className: "d-flex border border-left-0",
            appointments: 0,
            chevronColor: "#C4C4C4",
            isOpen: false,
        },
        3: {
            name: "Março",
            className: "d-flex border border-left-0",
            appointments: 0,
            chevronColor: "#C4C4C4",
            isOpen: false,
        },
        4: {
            name: "Abril",
            className: "d-flex border border-left-0",
            appointments: 0,
            chevronColor: "#C4C4C4",
            isOpen: false,
        },
        5: {
            name: "Maio",
            className: "d-flex border border-top-0",
            appointments: 0,
            chevronColor: "#C4C4C4",
            isOpen: false,
        },
        6: {
            name: "Junho",
            className: "d-flex border border-top-0 border-left-0",
            appointments: 6,
            chevronColor: "#C4C4C4",
            isOpen: false,
        },
        7: {
            name: "Julho",
            className: "d-flex border border-top-0 border-left-0",
            appointments: 0,
            chevronColor: "#C4C4C4",
            isOpen: false,
        },
        8: {
            name: "Agosto",
            className: "d-flex border border-top-0 border-left-0",
            appointments: 0,
            chevronColor: "#C4C4C4",
            isOpen: false,
        },
        9: {
            name: "Setembro",
            className: "d-flex border border-top-0",
            appointments: 0,
            chevronColor: "#C4C4C4",
            isOpen: false,
        },
        10: {
            name: "Outubro",
            className: "d-flex border border-top-0 border-left-0",
            appointments: 0,
            chevronColor: "#C4C4C4",
            isOpen: false,
        },
        11: {
            name: "Novembro",
            className: "d-flex border border-top-0 border-left-0",
            appointments: 0,
            chevronColor: "#C4C4C4",
            isOpen: false,
        },
        12: {
            name: "Dezembro",
            className: "d-flex border border-top-0 border-left-0",
            appointments: 0,
            chevronColor: "#C4C4C4",
            isOpen: false,
        },
    },
    selectedDay: undefined,
};

export const actionCreators = {
    toggleMonth: (month) => ({ type: types.TOGGLE_FULLMONTH_REQUEST, month }),
    selectDay: (day) => ({ type: types.SELECT_DAY_REQUEST, day }),
};

export const reducer = (state, action) => {
    state = state || initialState;

    switch (action.type) {
        case types.TOGGLE_FULLMONTH_REQUEST:
            var months = Object.assign({}, initialState.months);
            var value = state.months[action.month].isOpen;

            for (var key in months)
                months[key].isOpen = false;

            months[action.month].isOpen = !value;

            return ({
                ...state,
                months: months
            });
        case types.SELECT_DAY_REQUEST:
            var selectedDay = action.day;

            if (state.selectedDay === selectedDay)
                selectedDay = undefined;

            return ({
                ...state,
                selectedDay: selectedDay
            })
        default:
            return (state);
    }
};