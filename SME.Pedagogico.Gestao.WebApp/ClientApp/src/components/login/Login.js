import React, { Component } from 'react';
import './Login.css'
import { connect } from 'react-redux';
import { actionCreators } from '../../store/User';
import { bindActionCreators } from 'redux';
import { withRouter } from "react-router";

class Login extends Component {
    constructor() {
        super();

        this.state = {
            username: "",
            password: ""
        };

        this.onTextChange = this.onTextChange.bind(this);
        this.loginButtomClick = this.loginButtomClick.bind(this);
    }

    // Limpa a mensagem de erro se o usuário recarregar a página
    //componentDidMount() {
    //    this.props.logout();
    //}

    onTextChange(event) {
        this.setState({
            [event.target.id]: event.target.value
        })
    }

    loginButtomClick(event) {
        event.preventDefault();

        const credential = {
            username: this.state.username,
            password: this.state.password
        };

        this.props.login(credential);

        const { history } = this.props;
        history.push("/Usuario/TrocarPerfil");
    }

    render() {
        return (
            <div id="login-component" className="vw-100 vh-100" style={{ overflow: "hidden", backgroundColor: "rgba(0,0,0,0.7)" }}>
                <div className="h-100 d-flex flex-column justify-content-center align-items-center">
                    <div className="py-4"><img id="logo-login" src="./img/Logotipo_SondagemSME.svg" alt="Logo" /></div>

                    <div className="card shadow">
                        <div className="card-body">
                            <div className="card-text">
                                <form id="login-form" onSubmit={this.loginButtomClick}>
                                    <div className="d-flex align-items-center">
                                        <i className="fas fa-user login-icon" style={{ color: "rgba(102, 102, 102, 0.5)"}}></i>&nbsp;
                                        <input autoFocus id="username" className="form-control login-control border-top-0 border-right-0 border-left-0" type="text" placeholder="Usuário (Utilizar o mesmo do SGP)" value={this.state.username} onChange={this.onTextChange} />
                                    </div>

                                    <div className="py-1"></div>

                                    <div className="d-flex align-items-center">
                                        <i className="fas fa-lock login-icon" style={{ color: "rgba(102, 102, 102, 0.5)" }}></i>&nbsp;
                                        <input id="password" className="form-control login-control border-top-0 border-right-0 border-left-0" type="password" placeholder="Senha (Utilizar a mesma do SGP)" value={this.state.password} onChange={this.onTextChange} />
                                    </div>

                                    {this.props.user.isUnauthorized &&
                                        <div className="text-danger text-login">
                                            Usuário ou senha inválidos
                                        </div>
                                    }

                                    <div className="py-3"></div>

                                    
                                    {this.props.user.onAuthenticationRequest === false ?
                                        <button type="submit" className="btn btn-login text-white">Entrar</button>
                                        :
                                        <button type="submit" className="btn btn-login text-white">
                                            <div className="spinner-border spinner-border-sm text-white" role="status">
                                                <span className="sr-only">Carregando...</span>
                                            </div>
                                        </button>
                                    }
                                    
                                </form>
                            </div>
                        </div>
                    </div>

                    <div className="py-5"><img id="logo-prefeitura-login" src="./img/logo_prefeitura_white.svg" alt="Logo Prefeitura" /></div>
                </div>
            </div>
        );
    }
}

export default connect(
    state => ({ user: state.user }),
    dispatch => bindActionCreators(actionCreators, dispatch)
)(withRouter(Login));