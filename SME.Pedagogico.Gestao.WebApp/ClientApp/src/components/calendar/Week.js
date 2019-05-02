import React, { Component } from 'react';

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

export default class Week extends Component {
    render() {
        return (
            <div className="w-100 d-flex">
                <WeekDay className="" />
                <WeekDay className="" />
                <WeekDay className="" />
                <WeekDay className="" />
                <WeekDay className="" />
                <WeekDay className="" />
                <WeekDay className="border-right-0" />
            </div>
        );
    }
}