import React, { Component } from 'react';
import './Common.css';

export default class PollSelectRightWrong extends Component {
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

        if (value !== undefined && (value === "A" || value === "E" || value === "NR")) {
            return (defaultColor + this.props.columnColor);
        } else {
            return (defaultColor + "text-white");
        }
    }

    onOptionChange(event) {
        this.props.updatePollStudent(this.props.sequence, "math", this.props.name, event.target.value);
    }

    render() {
        return (

            <div>
                <select id={"pollItem-" + this.props.name + "-" + this.props.sequence} value={this.props.value} className={this.getColor(this.props.value)} onChange={this.onOptionChange}>
                    <option defaultValue hidden className="text-muted" value=""></option>
                    <option className={"custom-select custom-select-sm text-white" + this.props.columnColor} value="A">A</option>
                    <option className={"custom-select custom-select-sm text-white" + this.props.columnColor} value="E">E</option>
                    <option className={"custom-select custom-select-sm text-white" + this.props.columnColor} value="NR">NR</option>
                </select>
            </div>

        );
    }
}