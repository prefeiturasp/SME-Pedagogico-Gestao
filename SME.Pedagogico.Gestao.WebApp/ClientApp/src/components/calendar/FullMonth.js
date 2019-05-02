import React, { Component } from 'react';
import { connect } from 'react-redux';
import { actionCreators } from '../../store/Calendar';
import { bindActionCreators } from 'redux';
import { Spring, Transition } from 'react-spring/renderprops';
import { animated } from 'react-spring';

const WeekDayLabel = (props) => {
    return (
        <div className="col">
            <div className="text-small text-muted font-weight-light text-center" style={{ fontSize: 12 }}>{props.name}</div>
        </div>
    );
}

const WeekDay = (props) => {
    var { style, className, ...rest } = props;

    if (style === undefined)
        style = { height: 61 };

    if (className !== undefined)
        className = className + " col border border-left-0";
    else
        className = "col border border-left-0";

    return (
        <div className={className} style={style} {...rest}>

        </div>
    );
}

class FullMonth extends Component {
    render() {
        var months = this.props.months.split(",");
        var isOpen = false;

        for (var i = 0; i < months.length; i++)
            if (this.props.calendar.months[months[i]].isOpen)
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
                    height: 'auto',
                    maxHeight: '500px',
                    overflow: 'hidden',
                }}
                leave={{
                    //display: 'none',
                    height: 0,
                    overflow: 'hidden',
                }}>
                {toggle => toggle && (props =>
                    <animated.div className="border border-top-0 w-100" style={props}>
                        <div className="w-100 d-flex pt-4">
                            <WeekDayLabel name="Domingo" />
                            <WeekDayLabel name="Segunda" />
                            <WeekDayLabel name="Terça" />
                            <WeekDayLabel name="Quarta" />
                            <WeekDayLabel name="Quinta" />
                            <WeekDayLabel name="Sexta" />
                            <WeekDayLabel name="Sábado" />
                        </div>
                        <div className="w-100 d-flex">
                            <WeekDay className="" />
                            <WeekDay className="" />
                            <WeekDay className="" />
                            <WeekDay className="" />
                            <WeekDay className="" />
                            <WeekDay className="" />
                            <WeekDay className="border-right-0" />
                        </div>
                        <div className="w-100 d-flex">
                            <WeekDay className="border-top-0" />
                            <WeekDay className="border-top-0" />
                            <WeekDay className="border-top-0" />
                            <WeekDay className="border-top-0" />
                            <WeekDay className="border-top-0" />
                            <WeekDay className="border-top-0" />
                            <WeekDay className="border-top-0 border-right-0" />
                        </div>
                        <div className="w-100 d-flex">
                            <WeekDay className="border-top-0" />
                            <WeekDay className="border-top-0" />
                            <WeekDay className="border-top-0" />
                            <WeekDay className="border-top-0" />
                            <WeekDay className="border-top-0" />
                            <WeekDay className="border-top-0" />
                            <WeekDay className="border-top-0 border-right-0" />
                        </div>
                        <div className="w-100 d-flex">
                            <WeekDay className="border-top-0" />
                            <WeekDay className="border-top-0" />
                            <WeekDay className="border-top-0" />
                            <WeekDay className="border-top-0" />
                            <WeekDay className="border-top-0" />
                            <WeekDay className="border-top-0" />
                            <WeekDay className="border-top-0 border-right-0" />
                        </div>
                        <div className="w-100 d-flex pb-4">
                            <WeekDay className="border-top-0" />
                            <WeekDay className="border-top-0" />
                            <WeekDay className="border-top-0" />
                            <WeekDay className="border-top-0" />
                            <WeekDay className="border-top-0" />
                            <WeekDay className="border-top-0" />
                            <WeekDay className="border-top-0 border-right-0" />
                        </div>
                    </animated.div>
                )}
            </Transition>
        );
    }
}

export default connect(
    state => ({ calendar: state.calendar }),
    dispatch => bindActionCreators(actionCreators, dispatch)
)(FullMonth);
