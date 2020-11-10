import { takeLatest, put, all, call, select } from "redux-saga/effects";
import * as User from "../store/User";

// function* LoginTokenSgpSaga({ user, history }) {
//   try {
//     yield put({ type: User.types.SET_USER, user });
//     history.push("/Relatorios/Sondagem");
//   } catch (error) {
//     yield put({ type: User.types.FINISH_AUTHENTICATION_REQUEST });
//     yield put({ type: "API_CALL_ERROR" });
//   }
// }

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
      const permissoes = {
        "/": permissoesSondagem,
        "/Relatorios/Sondagem": permissoesSondagem,
        "/Usuario/TrocarPerfil": {
          podeAlterar: menus.podeAlterar,
          podeConsultar: menus.podeConsultar,
          podeExcluir: menus.podeExcluir,
          podeIncluir: menus.podeIncluir,
        },
      };

      const user = {
        name: "",
        username: usuario.rf,
        email: "",
        token: usuario.token,
        session: "",
        refreshToken: "",
        isAuthenticated: usuario.logado,
        lastAuthentication: new Date(),
        roles: "",
        activeRole: null,
        listOccupations: "",
        permissoes: permissoes,
        possuiPerfilSmeOuDre: usuario.possuiPerfilSmeOuDre,
        possuiPerfilDre: usuario.possuiPerfilDre,
        possuiPerfilSme: usuario.possuiPerfilSme,
        ehProfessorCj: usuario.ehProfessorCj,
        ehProfessor: usuario.ehProfessor,
        ehProfessorPoa: usuario.ehProfessorPoa,
        ehProfessorCjInfantil: usuario.ehProfessorCjInfantil,
        ehProfessorInfantil: usuario.ehProfessorInfantil,
        perfil: {
          perfilSelecionado,
          perfis: novoPerfil,
        },
      };

      yield put({ type: User.types.SET_USER, user });
    }

    history.push(url);
  } catch (error) {
    yield put({ type: User.types.FINISH_AUTHENTICATION_REQUEST });
    yield put({ type: "API_CALL_ERROR" });
  }
}

export default function* () {
  yield all([
    // takeLatest(User.types.LOGIN_SGP_REQUEST, LoginTokenSgpSaga),
    takeLatest(User.types.VALIDATE_PROFILES_TOKEN, ValidateProfilesSaga),
  ]);
}
