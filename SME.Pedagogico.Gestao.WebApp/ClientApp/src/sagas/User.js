import { takeLatest, call, put, all } from "redux-saga/effects";
import * as User from '../store/User';

export default function* () {
    yield all([
        takeLatest(User.types.LOGIN_REQUEST, LoginUserSaga),
        takeLatest(User.types.LOGOUT_REQUEST, LogoutUserSaga)
    ]);
}

function* LoginUserSaga({ credential }) {
    try {
        yield put({ type: User.types.ON_AUTHENTICATION_REQUEST });
        const data = yield call(authenticateUser, credential);

        if (data.status === 401) {
            yield put({ type: User.types.UNAUTHORIZED });
            yield put({ type: User.types.FINISH_AUTHENTICATION_REQUEST });
        }
        else {

            var user = {
                name: "",
                username: credential.username,
                email: "",
                token: data.token,
                session: data.session,
                refreshToken: data.refreshToken,
                isAuthenticated: true,
                lastAuthentication: new Date(),
                roles: data.roles,
                activeRole: null,
                listOccupations: data.listOccupations,
            };
            if (data.roles.length > 0)
                user.activeRole = data.roles[0];
            yield put({ type: User.types.FINISH_AUTHENTICATION_REQUEST });
            yield put({ type: User.types.SET_USER, user });
        }
    }
    catch (error) {
        yield put({ type: User.types.FINISH_AUTHENTICATION_REQUEST });
        yield put({ type: "API_CALL_ERROR" });
    }
}

function authenticateUser(credential) {
    return (fetch("/api/Auth/LoginIdentity", {
        method: "post",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(credential)
    })
        .then(response => response.json()));
}

function* LogoutUserSaga({ credential }) {
    try {
        yield call(logoutUser, credential);
        yield put({ type: User.types.LOGOUT_USER });
    }
    catch (error) {
        yield put({ type: "API_CALL_ERROR" });
    }
}

function logoutUser(credential) {
    return (fetch("/api/Auth/Logout", {
        method: "post",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(credential)
    })
        .then(response => response.json()));
}