﻿export const types = {
    LOGIN_REQUEST: "LOGIN_REQUEST",
    SET_USER: "SET_USER",
    UNAUTHORIZED: "UNAUTHORIZED",
    LOGOUT_REQUEST: "LOGOUT_REQUEST",
}
const initialState = {
    name: null,
    username: null,
    email: null,
    token: null,
    refreshToken: null,
    lastAuthentication: null,
    roles: null,
    isAuthenticated: false,
    isUnauthorized: false,
};

export const actionCreators = {
    login: (credential) => ({ type: types.LOGIN_REQUEST, credential }),
    setUser: (user) => ({ type: types.SET_USER, user }),
    logout: () => ({ type: types.LOGOUT_REQUEST })
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
        case types.LOGOUT_REQUEST:
            return ({
                ...state,
                ...initialState
            });
        default:
            return (state);
    }
};