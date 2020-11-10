import { takeLatest, put, all, call } from "redux-saga/effects";

import { types } from "../store/User";
import { montarObjetoUsuario, montarObjetoPermissoes } from "../utils";

function* ValidateProfilesSaga({ perfil, usuario, history }) {
  try {
    const { perfis } = perfil;
    let url = "/";

    const data = yield call(fetch, "/api/auth/ValidarPerfisToken", {
      method: "put",
      headers: { "Content-Type": "application/json", token: usuario.token },
      body: JSON.stringify(perfis),
    });

    if (data.status === 200) {
      const text = yield data.text();
      const { menus, perfis: novoPerfil } = yield JSON.parse(text);
      const perfisEhMaiorQueUm = perfis.length > 1;
      url = perfisEhMaiorQueUm
        ? "/Usuario/TrocarPerfil"
        : "/Relatorios/Sondagem";
      const perfilSelecionado = perfisEhMaiorQueUm
        ? { codigoPerfil: "", nomePerfil: "" }
        : perfis;

      const permissoesSondagem = usuario.permissoes["/sondagem"];
      console.log("usuario ===>", usuario);
      const permissoes = montarObjetoPermissoes(permissoesSondagem);

      // const permissoes = {
      //   "/": permissoesSondagem,
      //   "/Relatorios/Sondagem": permissoesSondagem,
      //   "/Usuario/TrocarPerfil": {
      //     podeAlterar: menus.podeAlterar,
      //     podeConsultar: menus.podeConsultar,
      //     podeExcluir: menus.podeExcluir,
      //     podeIncluir: menus.podeIncluir,
      //   },
      // };

      const user = montarObjetoUsuario({
        permissoes,
        usuario,
        username: usuario.rf,
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
    yield put({ type: "API_CALL_ERROR" });
    yield put({ type: types.FINISH_AUTHENTICATION_REQUEST });

    history.push("Login?redirect=/");
  }
}

export default function* () {
  yield all([
    // takeLatest(types.LOGIN_SGP_REQUEST, LoginTokenSgpSaga),
    takeLatest(types.VALIDATE_PROFILES_TOKEN, ValidateProfilesSaga),
  ]);
}
