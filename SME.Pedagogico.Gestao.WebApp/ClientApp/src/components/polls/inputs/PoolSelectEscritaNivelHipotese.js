import React, { Component } from 'react';
import './Common.css';

export default class PoolSelectEscritaNivelHipotese extends Component {
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

        if (value !== undefined && (value === "Nivel1" || value === "Nivel2" || value === "Nivel3" || value === "Nivel4" || value === "PS" || value === "SSV" || value === "SCV" || value === "SA" || value === "A")) {
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
                    <option className={"custom-select custom-select-sm text-white" + this.props.columnColor} value="Nivel1">Nível 1</option>
                    <option className={"custom-select custom-select-sm text-white" + this.props.columnColor} value="Nivel2">Nível 2</option>
                    <option className={"custom-select custom-select-sm text-white" + this.props.columnColor} value="Nivel3">Nível 3</option>
                    <option className={"custom-select custom-select-sm text-white" + this.props.columnColor} value="Nivel4">Nível 4</option>
                    <option className={"custom-select custom-select-sm text-white" + this.props.columnColor} value="PS">PS</option>
                    <option className={"custom-select custom-select-sm text-white" + this.props.columnColor} value="SSV">SSV</option>
                    <option className={"custom-select custom-select-sm text-white" + this.props.columnColor} value="SCV">SCV</option>
                    <option className={"custom-select custom-select-sm text-white" + this.props.columnColor} value="SA">SA</option>
                </select>
            </div>

        );
    }
}