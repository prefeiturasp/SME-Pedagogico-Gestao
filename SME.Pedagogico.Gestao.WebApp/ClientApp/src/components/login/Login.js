import React, { useCallback, useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { withRouter } from "react-router";

import { actionCreators } from "../../store/User";

import "./Login.css";

const Login = ({ history }) => {
  const [state, setState] = useState({
    username: "",
    password: "",
  });

  const { username, password } = state;
  const { redirectUrl, msgError, onAuthenticationRequest } = useSelector(
    (store) => store.user
  );
  const dispatch = useDispatch();
  const login = (payload) => dispatch(actionCreators.login(payload));
  const setError = (payload) => dispatch(actionCreators.setError(payload));
  const setRedirectUrl = useCallback(
    (payload) => dispatch(actionCreators.setRedirectUrl(payload)),
    [dispatch]
  );

  const onTextChange = (event) => {
    const { id, value } = event.target;

    setState((oldState) => ({
      ...oldState,
      [id]: value,
    }));
  };

  const loginButtonClick = (event) => {
    event.preventDefault();

    if (username && password) {
      login(
        {
          username,
          password,
        },
        history
      );
      return;
    }

    setError(
      "Você precisa informar um usuário e senha para acessar o sistema."
    );
  };

  useEffect(() => {
    if (!redirectUrl) {
      const { search } = history.location;
      const redirect = search.replace("?redirect=", "");
      const ehTrocarPerfil = redirect.indexOf("TrocarPerfil") > 0;
      const redirectUrl = ehTrocarPerfil ? "/" : redirect;
      setRedirectUrl(redirectUrl);
    }
  }, [history.location, setRedirectUrl, redirectUrl]);

  return (
    <div
      id="login-component"
      className="vw-100 vh-100"
      style={{ overflow: "hidden", backgroundColor: "rgba(0,0,0,0.7)" }}
    >
      <div className="h-100 d-flex flex-column justify-content-center align-items-center">
        <div className="py-4">
          <img
            id="logo-login"
            src="./img/Logotipo_SondagemSME.svg"
            alt="Logo"
          />
        </div>

        <div className="card shadow">
          <div className="card-body">
            <div className="card-text">
              <form id="login-form" onSubmit={loginButtonClick}>
                <div className="d-flex align-items-center">
                  <i
                    className="fas fa-user login-icon"
                    style={{ color: "rgba(102, 102, 102, 0.5)" }}
                  ></i>
                  &nbsp;
                  <input
                    autoFocus
                    id="username"
                    className="form-control login-control border-top-0 border-right-0 border-left-0"
                    type="text"
                    placeholder="Usuário (Utilizar o mesmo do SGP)"
                    value={username}
                    onChange={onTextChange}
                  />
                </div>
                <div className="py-1"></div>
                <div className="d-flex align-items-center">
                  <i
                    className="fas fa-lock login-icon"
                    style={{ color: "rgba(102, 102, 102, 0.5)" }}
                  ></i>
                  &nbsp;
                  <input
                    id="password"
                    className="form-control login-control border-top-0 border-right-0 border-left-0"
                    type="password"
                    placeholder="Senha (Utilizar a mesma do SGP)"
                    value={password}
                    onChange={onTextChange}
                  />
                </div>

                <div className="py-3"></div>

                <button type="submit" className="btn btn-login text-white">
                  {onAuthenticationRequest ? (
                    <div
                      className="spinner-border spinner-border-sm text-white"
                      role="status"
                    >
                      <span className="sr-only">Carregando...</span>
                    </div>
                  ) : (
                    "Entrar"
                  )}
                </button>

                {msgError && (
                  <div className="d-flex justify-content-center mt-4">
                    <div className="text-danger text-login">{msgError}</div>
                  </div>
                )}
              </form>
            </div>
          </div>
        </div>

        <div className="py-5">
          <img
            id="logo-prefeitura-login"
            src="./img/logo_prefeitura_white.svg"
            alt="Logo Prefeitura"
          />
        </div>
      </div>
    </div>
  );
};

export default withRouter(Login);
