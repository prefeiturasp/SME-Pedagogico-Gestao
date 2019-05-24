import React, { Component } from 'react';
import SelectChangeColor from '../inputs/SelectChangeColor';
import CircleButton from '../inputs/CircleButton';

export default class PollFilter extends Component {
    render() {
        const options = [
            { value: "1", label: "One" },
            { value: "2", label: "Two" },
            { value: "3", label: "Three" },
            { value: "4", label: "Four" },
        ];

        return (
            <div className="py-2 px-3 d-flex align-items-center">
                <SelectChangeColor className="" defaultText="Ano" options={options} disabled="true" />
                <div className="px-2"></div>
                <SelectChangeColor className="col-4" defaultText="Selecione a DRE" options={options} />
                <div className="px-2"></div>
                <SelectChangeColor className="col-4" defaultText="Escola" options={options} />
                <div className="px-2"></div>
                <SelectChangeColor className="" defaultText="Curso" options={options} />
                <div className="px-2"></div>
                <SelectChangeColor className="" defaultText="Turma" options={options} />
                <div className="px-2"></div>
                <CircleButton iconClass="fas fa-search" />
            </div>
        );
    }
}