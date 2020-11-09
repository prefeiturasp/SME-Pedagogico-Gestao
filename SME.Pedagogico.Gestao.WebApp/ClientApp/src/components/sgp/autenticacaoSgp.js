import React, { useEffect } from "react";
import createGuest from "cross-domain-storage/guest";
import { useDispatch } from "react-redux";
import { withRouter } from "react-router-dom";

import { actionCreators } from "../../store/User";

import { CustomLoader } from "./autenticacaoSgp.css";

const AutenticacaoSgp = ({ history }) => {
  const dispatch = useDispatch();
  const validateProfilesToken = (payload) =>
    dispatch(actionCreators.validateProfilesToken(payload));

  useEffect(() => {
    const crossDomainStorage = createGuest(
      "http://localhost:3000/accessStorage"
    );

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
  }, []);

  return (
    <CustomLoader loading={true}>
      <div></div>
    </CustomLoader>
  );
};

export default withRouter(AutenticacaoSgp);
