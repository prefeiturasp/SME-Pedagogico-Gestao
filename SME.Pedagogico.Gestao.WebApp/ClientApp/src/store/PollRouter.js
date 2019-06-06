export const types = {
    SET_ACTIVE_ROUTE: "SET_ACTIVE_ROUTE",
    RESET_ACTIVE_ROUTE: "RESET_ACTIVE_ROUTE",
}

const initialState = {
    activeRoute: null,
}

export const actionCreators = {
    setActiveRoute: (route) => ({ type: types.SET_ACTIVE_ROUTE, route }),
    resetActiveRoute: () => ({ type: types.RESET_ACTIVE_ROUTE }),
}

export const reducer = (state, action) => {
    state = state || initialState;

    switch (action.type) {
        case types.SET_ACTIVE_ROUTE:
            return ({
                ...state,
                activeRoute: action.route,
            });
        case types.RESET_ACTIVE_ROUTE:
            return ({
                ...state,
                ...initialState,
            });
        default:
            return (state);
    }
}