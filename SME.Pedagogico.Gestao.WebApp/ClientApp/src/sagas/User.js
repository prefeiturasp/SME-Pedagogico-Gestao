import { takeLatest, call, put, all, select } from "redux-saga/effects";
import * as User from "../store/User";

export default function* () {
  yield all([
    takeLatest(User.types.LOGIN_REQUEST, LoginUserSaga),
    takeLatest(User.types.LOGOUT_REQUEST, LogoutUserSaga),
    takeLatest(User.types.SET_PROFILE, SetProfileSaga),
  ]);
}

function* LoginUserSaga({ credential, history }) {
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
      
        
      const perfisEhMaiorQueUm = usuario.perfisUsuario.perfis.length > 1; 
      const perfilSelecionado = perfisEhMaiorQueUm ? {codigoPerfil: "", nomePerfil: ""} 
        : usuario.perfisUsuario.perfis[0];
      const rota = perfisEhMaiorQueUm ? "/Usuario/TrocarPerfil" : "/";

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
        possuiPerfilSmeOuDre: usuario.perfisUsuario.possuiPerfilSmeOuDre,
        possuiPerfilDre: usuario.perfisUsuario.possuiPerfilDre,
        possuiPerfilSme: usuario.perfisUsuario.possuiPerfilSme,
        ehProfessorCj: usuario.perfisUsuario.ehProfessorCj,
        ehProfessor: usuario.perfisUsuario.ehProfessor,
        ehProfessorPoa: usuario.perfisUsuario.ehProfessorPoa,
        ehProfessorCjInfantil: usuario.perfisUsuario.ehProfessorCjInfantil,
        ehProfessorInfantil: usuario.perfisUsuario.ehProfessorInfantil,
        perfil: { perfis : usuario.perfisUsuario.perfis, perfilSelecionado }, 
      };      
      yield put({ type: User.types.FINISH_AUTHENTICATION_REQUEST });
      yield put({ type: User.types.SET_USER, user });

      history.push(rota);
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

function* LogoutUserSaga() {
  try {
    yield put({ type: User.types.LOGOUT_USER });
  } catch (error) {
    yield put({ type: "API_CALL_ERROR" });
  }
}

function* SetProfileSaga ({perfilSelecionado, history}){
  try {
    const {user} = yield select();
    const {token: oldToken} =  user;
    const {perfis} = user.perfil;
    const {codigoPerfil: perfil} = perfilSelecionado;

    const data = yield call(fetch, `/api/Auth/ModificarPerfil?perfil=${perfil}`,
    {
      method: "put",
      headers: { "Content-Type": "application/json", token: oldToken },
    });

    const newUser = {
      ...user,
      perfil: {
          perfis,
          perfilSelecionado
      }
    }
    
    if(data.status === 200){
      const text = yield data.text();
      const {ehProfessor, token} = yield JSON.parse(text);

      newUser.ehProfessor =  ehProfessor;
      newUser.token = token;
    }   
      
    yield put({ type: "SET_USER", user: newUser});   
    
    history.push(user.redirectUrl);
  } catch (error) {
    yield put({ type: "API_CALL_ERROR" });    
  }
}