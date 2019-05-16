import React, { Component } from 'react';
import './TopMenu.css'
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import { actionCreators } from '../../store/User';
import { bindActionCreators } from 'redux';
import Breadcrumb from './Breadcrumb';

class TopMenu extends Component {
    constructor() {
        super();

        this.logout = this.logout.bind(this);
    }

    logout() {
        this.props.logout({ username: this.props.user.username, session: this.props.user.session });
    }

    render() {
        return (
            <div id="top-menu" className="fixed-top d-flex w-auto">
                <div id="logo-content-top-menu" className="d-flex justify-content-center align-items-center clickable">
                    <Link to="/">
                        <img id="logo-top-menu" src="./img/LogoSGP_mobile.svg" alt="Logo SGP" />
                    </Link>
                </div>

                <div id="top-menu-bar" className="d-flex flex-fill align-items-center">
                    <Breadcrumb id="breadcrumb-top-menu" className="d-flex flex-fill ml-4" />

                    <div className="d-flex">
                        <small className="d-flex align-items-center font-weight-light text-muted">Professor</small>
                        <div className="btn btn-outline-light rounded-circle d-flex justify-content-center align-items-center ml-2 mr-3 top-menu-button">
                            <i className="fas fa-chalkboard-teacher  top-menu-button-icon"></i>
                        </div>
                    </div>

                    <div className="d-flex">
                        <small className="d-flex align-items-center font-weight-light text-muted">Sair</small>
                        <div className="btn btn-outline-light rounded-circle d-flex justify-content-center align-items-center ml-2 mr-3 top-menu-button" onClick={this.logout}>
                            <i className="fas fa-power-off top-menu-button-icon"></i>
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
)(TopMenu);