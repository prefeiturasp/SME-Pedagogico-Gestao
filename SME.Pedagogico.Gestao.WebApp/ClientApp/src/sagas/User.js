import { takeLatest, call, put, all, select } from "redux-saga/effects";

import { types } from "../store/User";
import { montarObjetoUsuario } from "../utils";
import { STATUS_CODE_ENUM } from "../Enums";

function* LoginUserSaga({ credential, history }) {
  try {
    yield put({ type: types.ON_AUTHENTICATION_REQUEST });
    yield put({ type: types.SET_ERROR, msgError: "" });

    const data = yield call(fetch, "/api/Auth/LoginIdentity", {
      method: "post",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(credential),
    });

    console.log(data);

    if (data.status === STATUS_CODE_ENUM.UNAUTHORIZED)
      yield call(setError, data);
    if (data.status === STATUS_CODE_ENUM.OK) {
      const text = yield data.text();
      const usuario = yield JSON.parse(text);

      const store = yield select();

      const perfilVazio = { codigoPerfil: "", nomePerfil: "" };
      const perfisEhMaiorQueUm = usuario.perfisUsuario.perfis.length > 1;
      const perfilSelecionado = perfisEhMaiorQueUm
        ? perfilVazio
        : usuario.perfisUsuario.perfis[0];
      const rota = perfisEhMaiorQueUm
        ? "/Usuario/TrocarPerfil"
        : store.user.redirectUrl;

      const permissoes = {
        podeAlterar: false,
        podeConsultar: usuario.permissoes[0].podeConsultar,
        podeExcluir: false,
        podeIncluir: false,
      };
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
    yield put({ type: types.SET_ERROR, msgError: error.message });
  } finally {
    yield put({ type: types.FINISH_AUTHENTICATION_REQUEST });
  }
}

function* setError(data) {
  const text = yield data.text();
  let msgError = yield JSON.parse(text);

  if (msgError.mensagens) {
    msgError = msgError.mensagens[0];
  }
  throw new Error(msgError);
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
    yield put({ type: types.SET_ERROR, msgError: "" });
    yield put({ type: types.SET_LOADING_PROFILE, isLoadingProfile: true });

    const { user } = yield select();
    const { token: oldToken } = user;
    const { perfis } = user.perfil;
    const { codigoPerfil: perfil } = perfilSelecionado;
    let url = "/";

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

    if (data.status === STATUS_CODE_ENUM.UNAUTHORIZED)
      yield call(setError, data);
    if (data.status === STATUS_CODE_ENUM.OK) {
      const text = yield data.text();
      const { menus, ehProfessor, token } = yield JSON.parse(text);

      if (!ehProfessor) url = "/Relatorios/Sondagem";

      newUser.ehProfessor = ehProfessor;
      newUser.token = token;
      newUser.permissoes.podeConsultar = menus[0].podeConsultar;
    }

    yield put({ type: "SET_USER", user: newUser });

    history.push(url);
  } catch (error) {
    yield put({ type: types.LOGOUT_USER });
    yield put({ type: "API_CALL_ERROR" });
    yield put({ type: types.SET_ERROR, msgError: error.message });
  } finally {
    yield put({ type: types.SET_LOADING_PROFILE, isLoadingProfile: false });
  }
}

export default function* () {
  yield all([
    takeLatest(types.LOGIN_REQUEST, LoginUserSaga),
    takeLatest(types.LOGOUT_REQUEST, LogoutUserSaga),
    takeLatest(types.SET_PROFILE, SetProfileSaga),
  ]);
}
