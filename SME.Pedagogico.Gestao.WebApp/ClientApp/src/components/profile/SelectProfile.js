import React, { Component } from "react";
import "./SelectProfile.css";
import Card from "../containers/Card";
import { connect } from "react-redux";
import { actionCreators } from "../../store/User";
import { bindActionCreators } from "redux";

const ChangeProfileButton = (props) => {
  return (
    <div className="pt-3" name={props.roleId} onClick={props.onClick}>
      <div className="d-flex flex-fill profile-button align-items-center clickable">
        <div className="sc-text-size-0 d-flex flex-fill pl-4 profile-button-text">
          {props.profileName}
        </div>
        <div className="pr-2 d-flex align-items-center profile-button-text profile-button-icon">
          <div className="mr-2 profile-button-separator"></div>
          <i className="fas fa-share-square"></i>
        </div>
      </div>
    </div>
  );
};

class SelectProfile extends Component {
  constructor() {
    super();

    this.selectRole = this.selectRole.bind(this);
  }

  selectRole(event) {
    const nomePerfil = event.target.innerText;
    const { user, setProfile, history } = this.props;
    const perfilSelecionado = user.perfil.perfis.find(
      (item) => nomePerfil === item.nomePerfil
    );

    setProfile(perfilSelecionado, history);
  }

  render() {
    const {
      isLoadingProfile,
      perfil: { perfis },
    } = this.props.user;

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
            perfis.map((item) => (
              <ChangeProfileButton
                key={item.codigoPerfil}
                profileName={item.nomePerfil}
                roleId={item.codigoPerfil}
                onClick={this.selectRole}
              />
            ))
          )}
        </Card>
      </div>
    );
  }
}

export default connect(
  (state) => ({ user: state.user }),
  (dispatch) => bindActionCreators(actionCreators, dispatch)
)(SelectProfile);
