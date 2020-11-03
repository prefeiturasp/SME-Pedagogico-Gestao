import { takeLatest, call, put, all } from "redux-saga/effects";
import * as User from "../store/User";

export default function* () {
  yield all([
    takeLatest(User.types.LOGIN_REQUEST, LoginUserSaga),
    takeLatest(User.types.LOGOUT_REQUEST, LogoutUserSaga),
  ]);
}

function* LoginUserSaga({ credential }) {
  try {
    yield put({ type: User.types.ON_AUTHENTICATION_REQUEST });
    const usuario = yield call(authenticateUser, credential);

    if (usuario.status === 401) {
      yield put({ type: User.types.UNAUTHORIZED });
      yield put({ type: User.types.FINISH_AUTHENTICATION_REQUEST });
    } else {
      const permissoes = {
        "/": usuario.permissoes[0],
        "/Relatorios/Sondagem": usuario.permissoes[0],
        "/Usuario/TrocarPerfil": usuario.permissoes[1],
        };        
      const user = {
        name: "",
        username: credential.username,
        email: "",
        token: usuario.token,
        session: "",
        refreshToken: "",
        isAuthenticated: usuario.autenticado,
        lastAuthentication: new Date(),
        roles: "",
        activeRole: null,
        listOccupations: "",
        permissoes,
        possuiPerfilSmeOuDre: usuario.possuiPerfilSmeOuDre,
        possuiPerfilDre: usuario.possuiPerfilDre,
        possuiPerfilSme: usuario.possuiPerfilSme,
        ehProfessorCj: usuario.ehProfessorCj,
        ehProfessor: usuario.ehProfessor,
        ehProfessorPoa: usuario.ehProfessorPoa,
        ehProfessorCjInfantil: usuario.ehProfessorCjInfantil,
        ehProfessorInfantil: usuario.ehProfessorInfantil,
        perfil: usuario.perfisUsuario,
      };      
      yield put({ type: User.types.FINISH_AUTHENTICATION_REQUEST });
      yield put({ type: User.types.SET_USER, user });
    }
  } catch (error) {
    yield put({ type: User.types.FINISH_AUTHENTICATION_REQUEST });
    yield put({ type: "API_CALL_ERROR" });
  }
}

function authenticateUser(credential) {
  return fetch("/api/Auth/LoginIdentity", {
    method: "post",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(credential),
  }).then((response) => response.json());
}

function* LogoutUserSaga({ credential }) {
  try {
    yield put({ type: User.types.LOGOUT_USER });
  } catch (error) {
    yield put({ type: "API_CALL_ERROR" });
  }
}
