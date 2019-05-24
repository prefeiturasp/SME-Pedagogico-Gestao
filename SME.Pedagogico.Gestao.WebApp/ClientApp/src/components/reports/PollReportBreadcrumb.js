import React, { Component } from 'react';

export default class PollReportBreadcrumb extends Component {
    render() {
        var { className } = this.props;

        if (className === undefined)
            className = "border-top border-bottom";
        else
            className += " border-top border-bottom";

        return (
            <div className={className}>
                <div className="mx-1 my-2">
                    <span className="sc-text-purple sc-text-size-2">Sondagem {this.props.name} / </span>
                    <span className="sc-text-size-1 text-muted font-weight-light">1° Ano / </span>
                    <span className="sc-text-size-1 text-muted font-weight-light">Lingua Portuguesa / </span>
                    <span className="sc-text-size-1 text-muted font-weight-light">Escrita / </span>
                    <span className="sc-text-size-1 text-muted font-weight-light">1° Bimestre</span>
                </div>
            </div>
        );
    }
}