import React, { Component } from 'react';

export default class Select extends Component {
    constructor() {
        super();

        this.state = {
            optionChanged: false,
        };

        this.setColor = this.setColor.bind(this);
    }

    componentDidMount() {
        this.setState({
            optionChanged: false,
        });
    }

    setColor() {
        this.setState({
            optionChanged: true,
        });
    }

    render() {
        var { defaultText, options, className, disabled, onChange, ...rest } = this.props;
        defaultText = (defaultText === undefined ? "Selecione uma opção" : " " + defaultText);
        options = options === undefined ? [] : options;
        className = className === undefined ? "custom-select" : className + " custom-select";

        if (onChange === undefined)
            onChange = () => this.setColor();
        else
            onChange = (event) => { this.props.onChange(event); this.setColor(); }

        var style = {};

        if (this.state.optionChanged)
            style = {
                backgroundColor: "#1E90FF",
                color: "white"
            };

        return (
            <select className={className} {...rest} onChange={onChange} style={style} disabled={disabled} >
                <option defaultValue hidden className="text-muted" value="">{defaultText}</option>
                {options.map(option =>
                    <option value={option.value}>{option.label}</option>
                )};
            </select>
        );
    }
}