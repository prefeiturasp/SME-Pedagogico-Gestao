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
    const { user: oldUser } = yield select();
    const { token: oldToken } = oldUser;
    const { perfis } = perfil;
    let url = "/";

    console.log("perfis ==> ", perfis);
    console.log("perfi ==> ", perfil);
    const data = yield call(fetch, "/api/auth/ValidarPerfisToken", {
      method: "put",
      headers: { "Content-Type": "application/json", token: oldToken },
      body: JSON.stringify(perfis),
    });

    if (data.status === 200) {
      const text = yield data.text();
      const { permissoes, perfil: novoPerfil } = yield JSON.parse(text);
      url = "/Relatorios/Sondagem";

      // const permissoesSondagem = usuario.permissoes["/sondagem"];
      // const permissoes = {
      //   "/": permissoesSondagem,
      //   "/Relatorios/Sondagem": permissoesSondagem,
      //   "/Usuario/TrocarPerfil": {
      //     podeAlterar: false,
      //     podeConsultar: true,
      //     podeExcluir: false,
      //     podeIncluir: false,
      //   },
      // };

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
          ...perfil,
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
