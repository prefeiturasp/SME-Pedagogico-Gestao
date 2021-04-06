import React, { Component } from 'react';
import { connect } from 'react-redux';
import { actionCreators } from '../../store/Calendar';
import { bindActionCreators } from 'redux';
import { Transition } from 'react-spring/renderprops';
import { animated } from 'react-spring';
import Week from './Week';
import FullDay from './FullDay';

const WeekDayLabel = (props) => {
    return (
        <div className="col">
            <div className="text-small text-muted font-weight-light text-center" style={{ fontSize: 12 }}>{props.name}</div>
        </div>
    );
}

class FullMonth extends Component {
    constructor() {
        super();

        this.months = {};
        this.lastUsed = -1;
    }

    render() {
        var months = this.props.months.split(",");
        var month = -1;
        var weeks = [];
        var isOpen = false;

        for (var i = 0; i < months.length; i++)
            if (this.props.calendar.months[months[i]].isOpen) {
                isOpen = true;
                month += Number(months[i]);
            }

        if (month >= 0 && this.months[month] === undefined) {
            var currentDate = new Date();
            var date = new Date(currentDate.getFullYear(), month, 1);
            date.setDate(date.getDate() - date.getDay() - 1);

            for (var j = 0; j < 6; j++) {
                var week = [];

                for (var k = 0; k < 7; k++)
                    week.push(new Date(date.setDate(date.getDate() + 1)));

                weeks.push(week);
            }

            this.months[month] = weeks;
        }

        if (month === -1)
            weeks = this.months[this.lastUsed];
        else {
            weeks = this.months[month];
            this.lastUsed = month;
        }

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
                    overflow: 'hidden',
                }}
                leave={{
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
                        <Week firstWeek={true} days={weeks[0]} currentMonth={this.lastUsed} />
                        <FullDay days={weeks[0]} />
                        <Week days={weeks[1]} currentMonth={this.lastUsed} />
                        <FullDay days={weeks[1]} />
                        <Week days={weeks[2]} currentMonth={this.lastUsed} />
                        <FullDay days={weeks[2]} />
                        <Week days={weeks[3]} currentMonth={this.lastUsed} />
                        <FullDay days={weeks[3]} />
                        <Week days={weeks[4]} currentMonth={this.lastUsed} />
                        <FullDay days={weeks[4]} />
                        <Week className="pb-4" days={weeks[5]} currentMonth={this.lastUsed} />
                        <FullDay days={weeks[5]} />
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