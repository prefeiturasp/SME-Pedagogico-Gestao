import React, { useEffect, useCallback } from "react";
import createGuest from "cross-domain-storage/guest";
import { useDispatch, useSelector } from "react-redux";
import { withRouter } from "react-router-dom";

import { actionCreators } from "../../store/User";

import { CustomLoader } from "./autenticacaoSgp.css";

const AutenticacaoSgp = ({ history }) => {
  const { urlSgp } = useSelector((store) => store.user);

  const dispatch = useDispatch();
  const validateProfilesToken = useCallback(
    (payload) => dispatch(actionCreators.validateProfilesToken(payload)),
    [dispatch]
  );
  const getUrlSgp = useCallback(
    (payload) => dispatch(actionCreators.getUrlSgp(payload)),
    [dispatch]
  );

  useEffect(() => {
    getUrlSgp(history);
  }, [getUrlSgp, history]);

  useEffect(() => {
    const crossDomainStorage = createGuest(urlSgp);

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
  }, [history, urlSgp, validateProfilesToken]);

  return (
    <CustomLoader loading={true}>
      <div></div>
    </CustomLoader>
  );
};

export default withRouter(AutenticacaoSgp);
