import React, { Component } from 'react';
import Frequency from '../../sagas/Frequency';

export default class CheckInline extends Component {
    constructor() {
        super();

        this.state = {
            checkFrequency: false
        }
    }

    render() {
        const codigoaluno = this.props.codigoaluno;
        const numberLessons = this.props.numberLessons;
        const items = []

        for (var i = 0; i < numberLessons; i++) {
            items.push(<div className="col-sm-2 col-xs-2 custom-control custom-checkbox" key={"customCheck" + codigoaluno + i}>
                <input
                    type="checkbox"
                    className="custom-control-input"
                    id={"customCheck" + codigoaluno + i}
                    onChange={this.props.checkboxChange}
                    codigoaluno={codigoaluno}
                    disabled={this.props.disabled}
                />
                <label
                    className="text-center align-middle custom-control-label"
                    htmlFor={"customCheck" + codigoaluno + i}>
                </label>
            </div>)
        }
        return (
            <div className="col-sm-12 col-xs-12 form-check form-check-inline">
                {items}
            </div>
        )
    }
}