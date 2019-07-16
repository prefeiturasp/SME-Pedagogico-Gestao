import React, { Component } from 'react';
import './Common.css';

export default class PollSelectYesNo extends Component {
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

        if (value !== undefined && (value === "S" || value === "N")) {
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
                <select id={"pollItem-" + this.props.name + "-" + this.props.sequence} value={this.props.value} className={this.getColor(this.props.value)} onChange={this.onOptionChange} disabled={this.props.disabled ? true : null}>
                    <option defaultValue hidden className="text-muted" value=""></option>
                    <option className={"custom-select custom-select-sm text-white" + this.props.columnColor} value=""></option>
                    <option className={"custom-select custom-select-sm text-white" + this.props.columnColor} value="S">S</option>
                    <option className={"custom-select custom-select-sm text-white" + this.props.columnColor} value="N">N</option>
                </select>
            </div>

        );
    }
}