import React, { Component } from 'react';

const ClickableButton = (props) => {
    return (
        <div className="btn btn btn-primary rounded-circle d-flex justify-content-center align-items-center sc-blue border-0"
            style={{ width: 40, height: 40 }}
            onClick={props.onClick}>
            <i className={props.iconClass}></i>
        </div>
    );
};

const DisabledButton = (props) => {
    return (
        <div className="rounded-circle d-flex justify-content-center align-items-center sc-gray border-0"
            style={{ width: 40, height: 40 }}>
            <i className={props.iconClass}></i>
        </div>
    );
}

export default class CircleButton extends Component {
    render() {
        const { iconClass, onClick, disabled } = this.props;

        return (
            <>
                {disabled ? <DisabledButton iconClass={iconClass} /> : <ClickableButton onClick={onClick} iconClass={iconClass} />}
            </>
        );
    }
}