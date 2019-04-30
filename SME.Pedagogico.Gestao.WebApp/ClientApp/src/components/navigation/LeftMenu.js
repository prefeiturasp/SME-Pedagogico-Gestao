import React, { Component } from 'react';
import './LeftMenu.css';
import { connect } from 'react-redux';
import { actionCreators } from '../../store/LeftMenu';
import { bindActionCreators } from 'redux';
import { Spring } from 'react-spring/renderprops';
import { animated } from 'react-spring';
import LeftMenuButton from './LeftMenuButton';
import LeftMenuItem from './LeftMenuItem';

class LeftMenu extends Component {
    render() {
        return (
            <div id="left-menu">
                <Spring
                    from={{
                        left: 0,
                    }}
                    to={{
                        left: this.props.leftMenu.leftMenuIsOpen ? 265 : 0,
                    }}>
                    {props =>
                        <LeftMenuButton style={props} />
                    }
                </Spring>

                <Spring
                    from={{
                        left: -265,
                    }}
                    to={{
                        left: this.props.leftMenu.leftMenuIsOpen ? 0 : -265,
                    }}>
                    {props =>
                        <animated.div id="left-menu-content" className="h-100 pt-5 d-flex flex-column justify-items-center" style={props}>
                            <div id="user-info" className="d-flex flex-column align-content-start align-items-center">
                                <div id="user-info-avatar" className="rounded-circle" style={{ overflow: "hidden", backgroundColor: "#E5E5E5" }}>
                                    <img src="./img/default_avatar.png" alt="User Avatar" style={{ maxHeight: "100%", maxWidth: "100%", verticalAlign: "middle" }} />
                                </div>
                                <div className="py-1"></div>
                                <div id="user-info-username" className="px-2 py-1 text-white">{this.props.user.username}</div>
                                <div id="user-info-profile" className="pt-1 clickable"><i className="fas fa-user-edit clickable"></i> Perfil</div>
                            </div>

                            <div className="d-flex flex-column align-content-start align-items-center flex-fill pt-4">
                                {this.props.leftMenu.menuItems.map(item =>
                                    <LeftMenuItem key={item.name} menuItem={item} selectMenuItem={this.props.selectMenuItem} selectMenuSubItem={this.props.selectMenuSubItem} />
                                )}
                            </div>

                            <div className="d-flex justify-content-center flex-column">
                                <img src="./img/logo_prefeitura_white.svg" className="pb-3" alt="Logo Prefeitura SP" />
                                <div className="text-white text-center" style={{ fontSize: '9px' }}>SME-SP - SGP</div>
                                <div className="text-white text-center pb-4" style={{ fontSize: '9px' }}>Todos os direitos reservados.</div>
                            </div>
                        </animated.div>
                    }
                </Spring>
            </div>
        );
    }
}

export default connect(
    state => ({ leftMenu: state.leftMenu, user: state.user }),
    dispatch => bindActionCreators(actionCreators, dispatch)
)(LeftMenu);
