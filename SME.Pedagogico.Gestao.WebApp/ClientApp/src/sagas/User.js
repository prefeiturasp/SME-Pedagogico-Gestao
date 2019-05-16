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
        const data = yield call(authenticateUser, credential);

        if (data.status === 401)
            yield put({ type: User.types.UNAUTHORIZED });
        else {
            const user = {
                name: "",
                username: credential.username,
                email: "",
                token: data.token,
                session: data.session,
                refreshToken: data.refreshToken,
                isAuthenticated: true,
                lastAuthentication: new Date(),
                //TODO: Pegar valores do perfil do usuário
                roles: [
                    "Admin",
                    "Supervisor"
                ]
            };

            yield put({ type: User.types.SET_USER, user });
        }
    }
    catch (error) {
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