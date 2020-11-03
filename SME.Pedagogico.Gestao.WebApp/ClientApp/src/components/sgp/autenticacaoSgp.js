import { connect } from "react-redux";
import React, { Component } from "react";
import { bindActionCreators } from "redux";
import { actionCreators } from "../../store/User";
var createGuest = require("cross-domain-storage/guest");

class AutenticacaoSgp extends Component {
  constructor() {
    super();

    this.autenticaNoSondagemUsandoTokenSgp = this.autenticaNoSondagemUsandoTokenSgp.bind(
      this
    );
  }
  autenticaNoSondagemUsandoTokenSgp() {
    const component = this;
    const crossDomainStorage = createGuest(
      "http://localhost:3000/accessStorage"
    );
    crossDomainStorage.get("persist:sme-sgp", function (e, value) {
      if (value) {
        const jsonStorageSgp = JSON.parse(value);
        const usuario = JSON.parse(jsonStorageSgp.usuario);
        debugger;
       const perfil = JSON.parse(jsonStorageSgp.perfil);
          

        const permissoes = {
          "/": usuario.permissoes["/sondagem"],
          "/Relatorios/Sondagem": usuario.permissoes["/sondagem"],
          "/Usuario/TrocarPerfil": {
            podeAlterar: false,
            podeConsultar: true,
            podeExcluir: false,
            podeIncluir: false,
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
          perfil,
        };
        component.props.dispatch(
          actionCreators.loginSgp(user, component.props.history)
        );
      }
    });
  }
  componentDidMount() {
    this.autenticaNoSondagemUsandoTokenSgp();
  }
  render() {
    return <div>redirecionando para o Sondagem...Aguarde!!!</div>;
  }
}

export default connect((dispatch) =>
  bindActionCreators(actionCreators, dispatch)
)(AutenticacaoSgp);
