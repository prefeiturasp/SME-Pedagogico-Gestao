import React, { Component } from 'react';
import { connect } from 'react-redux';
import { actionCreators } from '../../store/Calendar';
import { bindActionCreators } from 'redux';

class WeekDay extends Component {
    constructor() {
        super();

        this.isOpen = false;
        this.lastSelectedDay = undefined;

        this.selectDayClick = this.selectDayClick.bind(this);
    }

    selectDayClick() {
        this.props.selectDay(this.props.day);
        this.lastSelectedDay = this.props.day;
        this.isOpen = !this.isOpen;
    }

    render() {
        var { style, className, day, currentMonth, selectDay, selectedDay, toggleMonth, ...rest } = this.props;

        if (day === selectedDay)
            this.lastSelectedDay = selectedDay;

        if (this.lastSelectedDay !== selectedDay || selectedDay === undefined || this.lastSelectedDay === undefined || this.lastSelectedDay.getMonth() !== currentMonth)
            this.isOpen = false;
        else
            this.isOpen = true;

        if (style === undefined)
            style = { height: 61, cursor: "pointer" };

        if (day.getDay() === 0)
            style["backgroundColor"] = "#FEE4E2";
        else if (day.getDay() === 6)
            style["backgroundColor"] = "#F7F9FA";

        if (className !== undefined)
            className = className + " col border border-left-0 border-bottom-0";
        else
            className = "col border border-left-0 border-bottom-0";

        if (this.isOpen === false)
            className = className.replace(" border-bottom-0", " border-bottom");

        var formatedDay = day.getDate();

        if (formatedDay < 10)
            formatedDay = "0" + formatedDay;

        var dayStyle = {
            position: "relative",
            top: 30,
            cursor: "pointer",
        };

        if (currentMonth !== day.getMonth())
            dayStyle["color"] = "rgba(66, 71, 74, 0.3)";

        return (
            <div className={className} style={style} {...rest} onClick={this.selectDayClick}>
                <div className="w-100 h-100 d-flex">
                    <div style={dayStyle}>{formatedDay}</div>
                </div>
            </div>
        );
    }
}

class Week extends Component {
    render() {
        var { calendar, firstWeek, days, currentMonth, selectDay, toggleMonth, ...rest } = this.props;

        const childProps = {
            selectDay: selectDay,
            selectedDay: this.props.calendar.selectedDay,
            currentMonth: currentMonth
        };

        return (
            <div {...rest}>
                {firstWeek ?
                    <div className="w-100 d-flex">
                        <WeekDay day={days[0]} {...childProps} />
                        <WeekDay day={days[1]} {...childProps} />
                        <WeekDay day={days[2]} {...childProps} />
                        <WeekDay day={days[3]} {...childProps} />
                        <WeekDay day={days[4]} {...childProps} />
                        <WeekDay day={days[5]} {...childProps} />
                        <WeekDay className="border-right-0" day={days[6]} {...childProps} />
                    </div>
                    :
                    <div className="w-100 d-flex">
                        <WeekDay className="border-top-0" day={days[0]} {...childProps} />
                        <WeekDay className="border-top-0" day={days[1]} {...childProps} />
                        <WeekDay className="border-top-0" day={days[2]} {...childProps} />
                        <WeekDay className="border-top-0" day={days[3]} {...childProps} />
                        <WeekDay className="border-top-0" day={days[4]} {...childProps} />
                        <WeekDay className="border-top-0" day={days[5]} {...childProps} />
                        <WeekDay className="border-top-0 border-right-0" day={days[6]} {...childProps} />
                    </div>
                }
            </div>
        );
    }
}

export default connect(
    state => ({ calendar: state.calendar }),
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Week);