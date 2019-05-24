import React, { Component } from 'react';

export default class Card extends Component {
    render() {
        var { className, style, ...rest } = this.props;

        if (className === undefined)
            className = "card px-2 py-2";
        else
            className = className.concat(" card px-2 py-2");

        if (style === undefined)
            style = { boxShadow: "0px 6px 18px rgba(0, 0, 0, 0.06)", border: "none", overflow: "hidden" };
        else {
            style["boxShadow"] = "0px 6px 18px rgba(0, 0, 0, 0.06)";
            style["border"] = "none";
            style["overflow"] = "hidden";
        }

        return (
            <div className={className} style={style} {...rest}>
                {this.props.children}
            </div>
        );
    }
}