import React, { Component } from 'react';
import './LeftMenuButton.css';
import { connect } from 'react-redux';
import { actionCreators } from '../../store/LeftMenu';
import { bindActionCreators } from 'redux';
import { useTransition, animated } from 'react-spring';

function LeftMenuButtonIcon(props) {
    const transitions = useTransition(props.isOpen, item => item, {
        from: { display: 'none' },
        enter: { display: 'block' },
        leave: { display: 'none' }
    });

    return (
        transitions.map(({ item, key, props }) =>
            item ?
                <animated.div style={props} key={key}>
                    <i id="left-menu-button-icon" className="fas fa-arrow-left text-white"></i>
                </animated.div>
                :
                <animated.div style={props} key={key}>
                    <i id="left-menu-button-icon" className="fas fa-arrow-right text-white"></i>
                </animated.div>
        )
    );
}

class LeftMenuButton extends Component {
    render() {
        return (
            <div id="left-menu-button" className="clickable" onClick={this.props.openMenu} style={this.props.style}>
                <LeftMenuButtonIcon isOpen={this.props.leftMenuIsOpen} />
            </div>
        );
    }
}

export default connect(
    state => state.leftMenu,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(LeftMenuButton);
