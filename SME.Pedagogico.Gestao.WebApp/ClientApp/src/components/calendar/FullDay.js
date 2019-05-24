import React, { Component } from 'react';
import { connect } from 'react-redux';
import { actionCreators } from '../../store/Calendar';
import { bindActionCreators } from 'redux';
import { Transition } from 'react-spring/renderprops';
import { animated } from 'react-spring';

const NoEvent = () => {
    return (
        <div className="d-flex w-100 h-100 justify-content-center d-flex align-items-center" style={{ fontSize: 25, color: "#A4A4A4" }}>
            Sem evento
        </div>
    );
}

class FullDay extends Component {
    render() {
        var isOpen = false;

        for (var i = 0; i < this.props.days.length; i++)
            if (this.props.days[i] === this.props.calendar.selectedDay)
                isOpen = true;

        return (
            <Transition
                items={isOpen}
                from={{
                    display: 'none',
                    height: 0,
                    overflow: 'hidden'
                }}
                enter={{
                    display: 'block',
                    height: 212,
                    overflow: 'hidden',
                }}
                leave={{
                    //display: 'none',
                    height: 0,
                    overflow: 'hidden',
                }}>
                {toggle => toggle && (props =>
                    <animated.div className="border-bottom" style={props}>
                        <NoEvent />
                    </animated.div>
                )}
            </Transition>
        );
    }
}

export default connect(
    state => ({ calendar: state.calendar }),
    dispatch => bindActionCreators(actionCreators, dispatch)
)(FullDay);