﻿import React, { Component } from 'react';
import './Common.css';

export default class PollSelectRead extends Component {
    constructor(props) {
        super(props);

        this.state = {
            selectedClass: "custom-select custom-select-sm poll-select"
        };

        this.getColor = this.getColor.bind(this);
        this.onOptionChange = this.onOptionChange.bind(this);
    }

    getColor(value) {
        var defaultColor = "custom-select custom-select-sm ";

        if (value !== undefined && (value === "1" || value === "2" || value === "3" || value === "4")) {
            return (defaultColor + this.props.columnColor);
        } else {
            return (defaultColor + "text-white");
        }
    }

    onOptionChange(event) {
        this.props.updatePollStudent(this.props.sequence, this.props.subjectName, this.props.name, event.target.value);
    }

    render() {
        return (

            <div>
                <select id={"pollItem-" + this.props.name + "-" + this.props.sequence} value={this.props.value} className={this.getColor(this.props.value)} onChange={this.onOptionChange}>
                    <option defaultValue hidden className="text-muted" value=""></option>
                    <option className={"custom-select custom-select-sm text-white" + this.props.columnColor} value="1">Nível 1</option>
                    <option className={"custom-select custom-select-sm text-white" + this.props.columnColor} value="2">Nível 2</option>
                    <option className={"custom-select custom-select-sm text-white" + this.props.columnColor} value="3">Nível 3</option>
                    <option className={"custom-select custom-select-sm text-white" + this.props.columnColor} value="4">Nível 4</option>
                </select>
            </div>

        );
    }
}