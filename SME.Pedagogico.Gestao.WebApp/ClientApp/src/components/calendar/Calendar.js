import React, { Component } from 'react';
import Month from './Month';

export default class Calendar extends Component {
    render() {
        return (
            <div>
                <div className="col-2">
                    <input type="text" className="form-control form-control-sm" />
                </div>

                <div className="d-flex">
                    <Month name="Janeiro" chevronBarColor="#C4C4C4" />
                    <Month name="Fevereiro" chevronBarColor="red" />
                    <Month name="Março" chevronBarColor="#C4C4C4" />
                    <Month name="Abril" chevronBarColor="#C4C4C4" />
                </div>
            </div>
        );
    }
}