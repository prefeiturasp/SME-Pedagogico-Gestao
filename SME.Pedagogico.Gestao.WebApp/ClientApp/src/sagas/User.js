import { takeLatest, call, put } from "redux-saga/effects";
import * as User from '../store/User';

export default function* () {
    yield takeLatest(User.types.LOGIN_REQUEST, UserSaga);
}

function* UserSaga({ credential }) {
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