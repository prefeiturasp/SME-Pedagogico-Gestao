import React, { Component } from 'react';
import SelectChangeColor from '../inputs/SelectChangeColor';

export default class PollReportFilter extends Component {
    render() {
        const options = [
            { value: "1", label: "One" },
            { value: "2", label: "Two" },
            { value: "3", label: "Three" },
            { value: "4", label: "Four" },
        ];

        return (
            <div className="d-flex flex-column d-inline-flex">
                <span className="sc-text-blue sc-text-size-1">Filtro para Relat&oacute;rios</span>
                <div className="pt-2 d-inline-flex">
                    <SelectChangeColor className="custom-select-sm" defaultText="Matéria" options={options} />
                    <div className="px-2"></div>
                    <SelectChangeColor className="custom-select-sm" defaultText="Proficiência" options={options} />
                    <div className="px-2"></div>
                    <SelectChangeColor className="custom-select-sm" defaultText="Período" options={options} />
                    <div className="px-2"></div>
                    <button type="button" className="btn btn-sm btn-outline-primary" style={{ width: 109 }}>Buscar</button>
                </div>
            </div>
        );
    }
}