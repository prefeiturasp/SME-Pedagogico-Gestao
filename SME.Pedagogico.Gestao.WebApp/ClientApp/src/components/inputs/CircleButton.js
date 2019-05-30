import React, { Component } from 'react';

export default class CircleButton extends Component {
    render() {
        const { iconClass, onClick, ...rest } = this.props;

        return (
            <div className="btn btn btn-primary rounded-circle d-flex justify-content-center align-items-center ml-2 sc-blue border-0" style={{ width: 40, height: 40 }} onClick={onClick}>
                <i className={iconClass}></i>
            </div>
        );
    }
}