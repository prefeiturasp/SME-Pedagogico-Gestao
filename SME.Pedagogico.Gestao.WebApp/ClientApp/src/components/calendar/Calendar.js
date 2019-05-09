import React, { Component } from 'react';
import Month from './Month';
import FullMonth from './FullMonth';

export default class Calendar extends Component {
    render() {
        return (
            <div className="px-3 pt-3 pb-5">
                <div className="col-2 px-0 pb-4">
                    <input type="text" className="form-control form-control-sm" value={this.props.name} readOnly style={{ backgroundColor: "rgba(0,0,0,0)" }} />
                </div>

                <div className="d-flex">
                    <Month month="1" />
                    <Month month="2" />
                    <Month month="3" />
                    <Month month="4" />
                </div>

                <FullMonth months="1,2,3,4"/>

                <div className="d-flex">
                    <Month month="5" />
                    <Month month="6" />
                    <Month month="7" />
                    <Month month="8" />
                </div>

                <FullMonth months="5,6,7,8" />

                <div className="d-flex">
                    <Month month="9" />
                    <Month month="10" />
                    <Month month="11" />
                    <Month month="12" />
                </div>

                <FullMonth months="9,10,11,12" />
            </div>
        );
    }
}