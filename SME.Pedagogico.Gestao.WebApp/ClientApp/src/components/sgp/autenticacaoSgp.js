import React, { useEffect, useCallback } from "react";
import createGuest from "cross-domain-storage/guest";
import { useDispatch, useSelector } from "react-redux";
import { withRouter } from "react-router-dom";

import { actionCreators } from "../../store/User";

import { CustomLoader } from "./autenticacaoSgp.css";

const AutenticacaoSgp = ({ history }) => {
  const { urlFrontSgp } = useSelector((store) => store.user);

  const dispatch = useDispatch();
  const validateProfilesToken = useCallback(
    (payload) => dispatch(actionCreators.validateProfilesToken(payload)),
    [dispatch]
  );
  const getUrlFrontSgp = useCallback(
    (payload) => dispatch(actionCreators.getUrlFrontSgp(payload)),
    [dispatch]
  );
  const setError = useCallback(
    (payload) => dispatch(actionCreators.setError(payload)),
    [dispatch]
  );
  const logout = useCallback(() => dispatch(actionCreators.logout()), [
    dispatch,
  ]);

  useEffect(() => {
    getUrlFrontSgp(history);
  }, [getUrlFrontSgp, history]);

  useEffect(() => {
    if (urlFrontSgp) {
      const crossDomainStorage = createGuest(urlFrontSgp);

      crossDomainStorage.get("persist:sme-sgp", (e, value) => {
        if (value) {
          const data = JSON.parse(value);
          const perfil = JSON.parse(data.perfil);
          const usuario = JSON.parse(data.usuario);
          validateProfilesToken({
            perfil,
            usuario,
            history,
          });
        }
      });
    }

    const timeout = setTimeout(() => {
      const msgError = "Erro interno. Tente novamente.";
      logout();
      setError(msgError);
      history.push("Login?redirect=/Relatorios/Sondagem");
    }, 180000);

    return () => clearTimeout(timeout);
  }, [history, logout, setError, urlFrontSgp, validateProfilesToken]);

  return (
    <CustomLoader loading={true}>
      <div></div>
    </CustomLoader>
  );
};

export default withRouter(AutenticacaoSgp);
