import React, { Component } from 'react';

export default class Month extends Component {
    render() {
        return (
            <div className="d-flex">
                <div className="d-flex align-items-center justify-content-center" style={{ backgroundColor: this.props.chevronBarColor, height: 75, width: 33 }}>
                    <i className="fas fa-chevron-right text-white"></i>
                </div>

                <div className="d-flex align-items-center" style={{ width: 265, height: 75 }}>
                    <div className="w-100 pl-2">{this.props.name}</div>
                    <div className="flex-shrink-1 d-flex align-items-center pr-3">
                        <div className="pr-2">0</div>
                        <div><i class="far fa-calendar-alt"></i></div>
                    </div>
                </div>
            </div>
        );
    }
}