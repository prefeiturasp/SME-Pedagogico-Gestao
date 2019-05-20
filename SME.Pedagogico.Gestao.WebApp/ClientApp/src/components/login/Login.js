import React, { Component } from 'react';
import { connect } from 'react-redux';
import { actionCreators } from '../../store/User';
import { bindActionCreators } from 'redux';

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
    }

    render() {
        return (
            <div id="login-component" className="vw-100 vh-100" style={{ overflow: "hidden" }}>
                <div className="h-100 d-flex justify-content-center d-flex align-items-center">
                    <div className="card shadow" style={{ width: "500px" }}>
                        <div className="card-body">
                            <h2 className="card-title">Login</h2>
                            <div className="card-text">
                                <form id="login-form" onSubmit={this.loginButtomClick}>
                                    <div className="d-flex align-items-center">
                                        <i className="fas fa-user login-icon"></i>&nbsp;
                                        <input autoFocus id="username" className="form-control login-control border-top-0 border-right-0 border-left-0" type="text" placeholder="Usuário" value={this.state.username} onChange={this.onTextChange} />
                                    </div>

                                    <div className="py-1"></div>

                                    <div className="d-flex align-items-center">
                                        <i className="fas fa-lock login-icon"></i>&nbsp;
                                        <input id="password" className="form-control login-control border-top-0 border-right-0 border-left-0" type="password" placeholder="Senha" value={this.state.password} onChange={this.onTextChange} />
                                    </div>

                                    {this.props.user.isUnauthorized &&
                                        <div className="text-danger">
                                            Usuário ou senha inválidos
                                        </div>
                                    }

                                    <div className="py-3"></div>

                                    <div className="float-right">
                                        {this.props.user.onAuthenticationRequest === false ?
                                            <button type="submit" className="btn btn-warning text-white">Entrar</button>
                                            :
                                            <button type="submit" className="btn btn-warning" style={{ width: 68.38 }}>
                                                <div className="spinner-border spinner-border-sm text-white" role="status">
                                                    <span className="sr-only">Carregando...</span>
                                                </div>
                                            </button>
                                        }
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

export default connect(
    state => ({ user: state.user }),
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Login);