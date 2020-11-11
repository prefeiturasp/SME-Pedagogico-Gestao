import React, { useEffect, useCallback, useState } from "react";
import { Link, withRouter } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";

import { actionCreators } from "../../store/User";
import { actionCreators as pollRouterActionCreators } from "../../store/PollRouter";
import { actionCreators as dataActionCreators } from "../../store/Data";

import TwoSteps from "../messaging/TwoSteps";
import permissoesMetodos from "../../utils/permissoes";

import "./TopMenu.css";

const TopMenu = ({ history }) => {
  const [showMessageBox, setShowMessageBox] = useState(false);
  const [isVisiblePoll, setIsVisiblePoll] = useState(false);
  const [isVisiblePollReport, setIsVisiblePollReport] = useState(false);
  const [isVisibleChangeProfile, setIsVisibleChangeProfile] = useState(false);

  const { username, session, perfil, permissoes } = useSelector(
    (store) => store.user
  );
  const { activeRoute } = useSelector((store) => store.pollRouter);
  const { nomePerfil } = perfil.perfilSelecionado;

  const dispatch = useDispatch();
  const logout = (data) => dispatch(actionCreators.logout(data));
  const setActiveRoute = useCallback(
    (data) => dispatch(pollRouterActionCreators.setActiveRoute(data)),
    [dispatch]
  );
  const resetData = useCallback(
    () => dispatch(dataActionCreators.reset_new_data_state()),
    [dispatch]
  );

  const handleLogout = () => {
    logout({
      username,
      session,
    });
  };

  const changeRoute = useCallback(
    (route) => {
      const isPoll = route.indexOf("Sondagem") >= 0;
      const chosenRoute = isPoll ? "/" : "/Relatorios/Sondagem";

      setActiveRoute(route);
      resetData();

      history.push(chosenRoute);
    },
    [history, resetData, setActiveRoute]
  );

  const toggleMessageBox = () => setShowMessageBox(!showMessageBox);

  useEffect(() => {
    if (nomePerfil) {
      setIsVisiblePollReport(true);
      setIsVisibleChangeProfile(true);
    }

    if (permissoesMetodos.PodeVisualizarSondagem(permissoes)) {
      setIsVisiblePoll(true);
      changeRoute("Sondagem");
      return;
    }

    setIsVisiblePoll(false);
    changeRoute("Relatórios");
  }, [changeRoute, nomePerfil, permissoes, permissoes.podeConsultar]);

  return (
    <div id="top-menu" className="d-flex w-auto">
      <TwoSteps
        show={showMessageBox}
        showControl={toggleMessageBox}
        runMethod={() => changeRoute("Sondagem")}
      />

      <div
        id="logo-content-top-menu"
        className="d-flex justify-content-center align-items-center clickable"
      >
        <Link to="/">
          <img
            id="logo-top-menu"
            src="./img/Logotipo_SondagemSME.svg"
            alt="Logo"
          />
        </Link>
      </div>

      <div id="top-menu-bar" className="d-flex flex-fill align-items-center">
        <div className="d-flex flex-fill ml-4"></div>
        <div className="d-flex h-100">
          {isVisiblePoll && (
            <div
              className={
                activeRoute === "Sondagem"
                  ? "border-left top-navigation-button-selected"
                  : "border-left top-navigation-button"
              }
            >
              <Link
                className="d-flex align-items-center h-100 w-100"
                to="/"
                onClick={() => changeRoute("Sondagem")}
              >
                <small className="mx-3 font-weight-light text-muted">
                  Sondagem
                </small>
              </Link>
            </div>
          )}
          {isVisiblePollReport && (
            <div
              className={
                activeRoute === "Relatórios"
                  ? "mr-3 border border-top-0 border-bottom-0 top-navigation-button-selected"
                  : "mr-3 border border-top-0 border-bottom-0 top-navigation-button"
              }
            >
              <Link
                className="d-flex align-items-center h-100 w-100"
                to="/Relatorios/Sondagem"
                onClick={() => changeRoute("Relatórios")}
              >
                <small className="mx-3 font-weight-light text-muted">
                  Relat&oacute;rios
                </small>
              </Link>
            </div>
          )}
        </div>

        {isVisibleChangeProfile && (
          <div className="d-flex">
            <small className="d-flex align-items-center font-weight-light text-muted">
              {nomePerfil}
            </small>
            <Link to="/Usuario/TrocarPerfil">
              <div className="btn btn-outline-light rounded-circle d-flex justify-content-center align-items-center ml-2 mr-3 top-menu-button">
                <i className="fas fa-chalkboard-teacher top-menu-button-icon"></i>
              </div>
            </Link>
          </div>
        )}

        <div className="d-flex">
          <small className="d-flex align-items-center font-weight-light text-muted">
            Sair
          </small>
          <div
            className="btn btn-outline-light rounded-circle d-flex justify-content-center align-items-center ml-2 mr-3 top-menu-button"
            onClick={handleLogout}
          >
            <i className="fas fa-power-off top-menu-button-icon"></i>
          </div>
        </div>
      </div>
    </div>
  );
};

export default withRouter(TopMenu);
