import { takeLatest, put, all, call } from "redux-saga/effects";

import { types } from "../store/User";
import { montarObjetoUsuario } from "../utils";
import { STATUS_CODE_ENUM } from "../Enums";

function* ValidateProfilesSaga({ perfil, usuario, history }) {
  try {
    let url = "/";
    const { perfis } = perfil;

    yield put({ type: types.SET_ERROR, msgError: "" });

    const data = yield call(fetch, "/api/auth/ValidarPerfisToken", {
      method: "put",
      headers: { "Content-Type": "application/json", token: usuario.token },
      body: JSON.stringify(perfis),
    });

    if (data.status === STATUS_CODE_ENUM.UNAUTHORIZED)
      yield call(setErrorSgp, data);
    if (data.status === STATUS_CODE_ENUM.OK) {
      const text = yield data.text();
      const { menus, perfis: novoPerfil, token } = yield JSON.parse(text);

      const perfilVazio = { codigoPerfil: "", nomePerfil: "" };
      const perfisEhMaiorQueUm = novoPerfil.length > 1;
      const perfilSelecionado = perfisEhMaiorQueUm
        ? perfilVazio
        : novoPerfil[0];

      url = perfisEhMaiorQueUm
        ? "/Usuario/TrocarPerfil"
        : "/Relatorios/Sondagem";

      const permissoes = {
        podeAlterar: false,
        podeConsultar: menus[0].podeConsultar,
        podeExcluir: false,
        podeIncluir: false,
      };
      const user = montarObjetoUsuario({
        permissoes,
        usuario,
        username: usuario.rf,
        token,
        isAuthenticated: usuario.logado,
        perfil: {
          perfilSelecionado,
          perfis: novoPerfil,
        },
      });

      yield put({ type: types.SET_USER, user });
    }

    history.push(url);
  } catch (error) {
    yield put({ type: types.LOGOUT_USER });
    history.push("Login?redirect=/Relatorios/Sondagem");
    yield put({ type: "API_CALL_ERROR" });
    yield put({ type: types.SET_ERROR, msgError: error.message });
  }
}

function* setErrorSgp(data) {
  const text = yield data.text();
  let msgError = yield JSON.parse(text);

  if (msgError.mensagens) {
    msgError = msgError.mensagens[0];
  }
  throw new Error(msgError);
}

export default function* () {
  yield all([takeLatest(types.VALIDATE_PROFILES_TOKEN, ValidateProfilesSaga)]);
}
