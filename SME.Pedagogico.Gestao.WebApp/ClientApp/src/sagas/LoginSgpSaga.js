import { takeLatest, put, all, call } from "redux-saga/effects";

import { types } from "../store/User";
import { montarObjetoUsuario } from "../utils";
import { STATUS_CODE } from "../Enums";

function* ValidateProfilesSaga({ perfil, usuario, history }) {
  try {
    let url = "/";
    const { perfis } = perfil;

    const data = yield call(fetch, "/api/auth/ValidarPerfisToken", {
      method: "put",
      headers: { "Content-Type": "application/json", token: usuario.token },
      body: JSON.stringify(perfis),
    });

    if (data.status === STATUS_CODE.OK) {
      const text = yield data.text();
      const { perfis: novoPerfil } = yield JSON.parse(text);

      const perfilVazio = { codigoPerfil: "", nomePerfil: "" };
      const perfisEhMaiorQueUm = novoPerfil.length > 1;
      const perfilSelecionado = perfisEhMaiorQueUm ? perfilVazio : perfis;

      url = perfisEhMaiorQueUm
        ? "/Usuario/TrocarPerfil"
        : "/Relatorios/Sondagem";

      const permissoes = {
        podeAlterar: false,
        podeConsultar: false,
        podeExcluir: false,
        podeIncluir: false,
      };
      const user = montarObjetoUsuario({
        permissoes,
        usuario,
        username: usuario.rf,
        token: usuario.token,
        isAuthenticated: usuario.logado,
        perfil: {
          perfilSelecionado,
          perfis: novoPerfil,
        },
      });

      yield put({ type: types.SET_USER, user });
    } else {
      url = "/Login?Redirect=/";
    }

    history.push(url);
  } catch (error) {
    yield put({ type: "API_CALL_ERROR" });
    yield put({ type: types.FINISH_AUTHENTICATION_REQUEST });
  }
}

export default function* () {
  yield all([takeLatest(types.VALIDATE_PROFILES_TOKEN, ValidateProfilesSaga)]);
}
