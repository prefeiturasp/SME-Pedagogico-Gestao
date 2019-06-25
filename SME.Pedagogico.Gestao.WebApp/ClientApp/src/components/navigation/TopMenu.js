import React, { Component } from 'react';

import './TopMenu.css'
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import { actionCreators } from '../../store/User';
import { actionCreators as pollRouterActionCreators } from '../../store/PollRouter';
import { actionCreators as dataActionCreators } from '../../store/Data';

import { bindActionCreators } from 'redux';
import { ROLES_ENUM } from '../../Enums';
import Breadcrumb from './Breadcrumb';

import TwoSteps from '../messaging/TwoSteps'

class TopMenu extends Component {
    constructor() {
        super();
        this.state = {
            isVisible: false,
            showMessageBox:false,
        }
        this.logout = this.logout.bind(this);
        this.changeRoutePoll = this.changeRoutePoll.bind(this);
        this.changeRoutePollReport = this.changeRoutePollReport.bind(this);
        this.setVisiblePoll = this.setVisiblePoll.bind(this);

        this.toggleMessageBox = this.toggleMessageBox.bind(this);
    }

    setVisiblePoll() {
        this.setState({
            isVisible: true     
        });
    }


    componentWillMount() {
      
        if (this.props.user.activeRole.roleName === ROLES_ENUM.PROFESSOR ||
            this.props.user.activeRole.roleName === ROLES_ENUM.COORDENADOR_PEDAGOGICO ||
            this.props.user.activeRole.roleName === ROLES_ENUM.ADMIN) {
           this.setVisiblePoll();
           this.changeRoutePoll();

        }

        else {
            this.changeRoutePollReport();
        }
        var pathname = document.location.pathname;
        switch (pathname) {
            case "/":
                this.changeRoutePoll();
                break;
            case "/Relatorios/Sondagem":
                this.changeRoutePollReport();
                break;
            default:
                break;
        }
    }

    logout() {
        this.props.userMethods.logout({ username: this.props.user.username, session: this.props.user.session });
    }

    changeRoutePoll() {
        this.props.pollRouterMethods.setActiveRoute("Sondagem");
        this.props.dataMethods.reset_new_data_state();
        
    }

    changeRoutePollReport() {
        this.props.pollRouterMethods.setActiveRoute("Relatórios");
        this.props.dataMethods.reset_new_data_state();
    }

    toggleMessageBox() {
        this.setState({
            showMessageBox: !this.state.showMessageBox,
        })
    }
    render() {
        
        return (
            <div id="top-menu" className="d-flex w-auto" >
         
                <TwoSteps show={this.state.showMessageBox} showControl={this.toggleMessageBox} runMethod={this.changeRoutePoll} />

                <div id="logo-content-top-menu" className="d-flex justify-content-center align-items-center clickable">
                    <Link to="/">
                        <img id="logo-top-menu" src="./img/RegistreSME_V3.svg" alt="Logo" />
                    </Link>
                </div>

                <div id="top-menu-bar" className="d-flex flex-fill align-items-center">
                    {/*<Breadcrumb id="breadcrumb-top-menu" className="d-flex flex-fill ml-4" />*/}
                    <div className="d-flex flex-fill ml-4"></div>

                    <div className="d-flex h-100">
                        {this.state.isVisible && <div className={this.props.pollRouter.activeRoute === "Sondagem" ? "border-left top-navigation-button-selected" : "border-left top-navigation-button"}>
                            <Link className="d-flex align-items-center h-100 w-100" to="/" onClick={this.changeRoutePoll}>
                                <small className="mx-3 font-weight-light text-muted">Sondagem</small>
                            </Link> 
                            
                        </div>}

                        <div className={this.props.pollRouter.activeRoute === "Relatórios" ? "mr-3 border border-top-0 border-bottom-0 top-navigation-button-selected" : "mr-3 border border-top-0 border-bottom-0 top-navigation-button"}>
                            <a className="d-flex align-items-center h-100 w-100" href="/Relatorios/Sondagem" onClick={this.changeRoutePollReport}>
                                <small className="mx-3 font-weight-light text-muted">Relat&oacute;rios</small>
                            </a>
                        </div>
                    </div>

                    <div className="d-flex">
                        <small className="d-flex align-items-center font-weight-light text-muted">{this.props.user.activeRole.roleName}</small>
                        <Link to="/Usuario/TrocarPerfil">
                            <div className="btn btn-outline-light rounded-circle d-flex justify-content-center align-items-center ml-2 mr-3 top-menu-button">
                                <i className="fas fa-chalkboard-teacher top-menu-button-icon"></i>
                            </div>
                        </Link>
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
    state => ({ user: state.user, pollRouter: state.pollRouter, data:state.data }),
    dispatch => ({ userMethods: bindActionCreators(actionCreators, dispatch), pollRouterMethods: bindActionCreators(pollRouterActionCreators, dispatch), dataMethods: bindActionCreators(dataActionCreators, dispatch) })
)(TopMenu);