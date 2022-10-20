import React from "react";
import { useDispatch, useSelector } from "react-redux";

import Card from "../containers/Card";
import { actionCreators } from "../../store/User";
import ProfileItem from "./ProfileItem";

import "./SelectProfile.css";

const SelectProfile = ({ history }) => {
  const {
    isLoadingProfile,
    perfil: { perfis },
  } = useSelector((store) => store.user);
  const dispatch = useDispatch();
  const setProfile = (payload) =>
    dispatch(actionCreators.setProfile(payload, history));

  const handleClick = (event) => {
    const nomePerfil = event.target.innerText;
    console.log(nomePerfil);
    console.log(perfis);    
    const perfilSelecionado = perfis.find(
      (item) => nomePerfil === item.nomePerfil
    );
    console.log(perfilSelecionado);
    setProfile(perfilSelecionado);
  };

  return (
    <div className="d-flex justify-content-center">
      <Card className="col-5 px-4 py-4 mt-5">
        <div className="d-flex flex-fill border-bottom sc-text-size-4 text-muted">
          Mudar Perfil
        </div>

        <div className="py-2"></div>

        {isLoadingProfile ? (
          <div className="spinner-border spinner-profile" role="status"></div>
        ) : (
          perfis.map(({ codigoPerfil, nomePerfil }) => (
            <ProfileItem
              key={codigoPerfil}
              profileName={nomePerfil}
              roleId={codigoPerfil}
              onClick={handleClick}
            />
          ))
        )}
      </Card>
    </div>
  );
};

export default SelectProfile;
