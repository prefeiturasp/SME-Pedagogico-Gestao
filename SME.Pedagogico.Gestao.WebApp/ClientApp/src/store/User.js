export const types = {
    LOGIN_REQUEST: "LOGIN_REQUEST",
    SET_USER: "SET_USER",
    UNAUTHORIZED: "UNAUTHORIZED",
    LOGOUT_REQUEST: "LOGOUT_REQUEST",
    LOGOUT_USER: "LOGOUT_USER",
    ON_AUTHENTICATION_REQUEST: "ON_AUTHENTICATION_REQUEST",
    FINISH_AUTHENTICATION_REQUEST: "FINISH_AUTHENTICATION_REQUEST",
}
const initialState = {
    name: null,
    username: null,
    email: null,
    token: null,
    session: null,
    refreshToken: null,
    lastAuthentication: null,
    roles: null,
    isAuthenticated: false,
    isUnauthorized: false,
    activeRole: null,
    onAuthenticationRequest: false,
};

export const actionCreators = {
    login: (credential) => ({ type: types.LOGIN_REQUEST, credential }),
    setUser: (user) => ({ type: types.SET_USER, user }),
    logout: (credential) => ({ type: types.LOGOUT_REQUEST, credential })
};

export const reducer = (state, action) => {
    state = state || initialState;

    switch (action.type) {
        case types.SET_USER:
            return ({
                ...state,
                ...action.user,
                isUnauthorized: false,
            });
        case types.UNAUTHORIZED:
            return ({
                ...state,
                isUnauthorized: true,
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