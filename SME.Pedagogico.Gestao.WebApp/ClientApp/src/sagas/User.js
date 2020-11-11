import { takeLatest, call, put, all, select } from "redux-saga/effects";

import { types } from "../store/User";
import { montarObjetoUsuario, montarObjetoPermissoes } from "../utils";
import { STATUS_CODE } from "../Enums";

function* LoginUserSaga({ credential, history }) {
  try {
    yield put({ type: types.ON_AUTHENTICATION_REQUEST });
    const usuario = yield call(authenticateUser, credential);

    if (usuario.status === STATUS_CODE.UNAUTHORIZED) {
      yield put({ type: types.UNAUTHORIZED });
      yield put({ type: types.FINISH_AUTHENTICATION_REQUEST });
    } else {
      const store = yield select();

      const perfilVazio = { codigoPerfil: "", nomePerfil: "" };
      const perfisEhMaiorQueUm = usuario.perfisUsuario.perfis.length > 1;
      const perfilSelecionado = perfisEhMaiorQueUm
        ? perfilVazio
        : usuario.perfisUsuario.perfis[0];
      const rota = perfisEhMaiorQueUm
        ? "/Usuario/TrocarPerfil"
        : store.user.redirectUrl;

      const permissoes = montarObjetoPermissoes({
        podeAlterar: false,
        podeConsultar: false,
        podeExcluir: false,
        podeIncluir: false,
      });
      const user = montarObjetoUsuario({
        permissoes,
        usuario: usuario.perfisUsuario,
        token: usuario.token,
        username: credential.username,
        isAuthenticated: usuario.autenticado,
        perfil: { ...usuario.perfisUsuario, perfilSelecionado },
      });

      yield put({ type: types.FINISH_AUTHENTICATION_REQUEST });
      yield put({ type: types.SET_USER, user });

      history.push(rota);
    }
  } catch (error) {
    yield put({ type: "API_CALL_ERROR" });
    yield put({ type: types.FINISH_AUTHENTICATION_REQUEST });
  }
}

function authenticateUser(credential) {
  return fetch("/api/Auth/LoginIdentity", {
    method: "post",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(credential),
  }).then((response) => response.json());
}

function* LogoutUserSaga() {
  try {
    yield put({ type: types.LOGOUT_USER });
  } catch (error) {
    yield put({ type: "API_CALL_ERROR" });
  }
}

function* SetProfileSaga({ perfilSelecionado, history }) {
  try {
    const { user } = yield select();
    const { token: oldToken } = user;
    const { perfis } = user.perfil;
    const { codigoPerfil: perfil } = perfilSelecionado;

    const data = yield call(
      fetch,
      `/api/Auth/ModificarPerfil?perfil=${perfil}`,
      {
        method: "put",
        headers: { "Content-Type": "application/json", token: oldToken },
      }
    );

    const newUser = {
      ...user,
      perfil: {
        perfis,
        perfilSelecionado,
      },
    };

    if (data.status === STATUS_CODE.OK) {
      const text = yield data.text();
      const { ehProfessor, token } = yield JSON.parse(text);

      newUser.ehProfessor = ehProfessor;
      newUser.token = token;
    }

    yield put({ type: "SET_USER", user: newUser });

    history.push(user.redirectUrl);
  } catch (error) {
    yield put({ type: "API_CALL_ERROR" });
  }
}

export default function* () {
  yield all([
    takeLatest(types.LOGIN_REQUEST, LoginUserSaga),
    takeLatest(types.LOGOUT_REQUEST, LogoutUserSaga),
    takeLatest(types.SET_PROFILE, SetProfileSaga),
  ]);
}
