import React, { Component } from 'react';

export default class SondagemClassSelected extends Component {
    constructor(props) {
        super(props);

        this.state = {
        };
        
    }
    
    render() {
        var sondagemType,buttonRender;
        sondagemType = "1A";
        switch (sondagemType) {
            case "1A":
                buttonRender =  <div className="btn-group mr-2 btn-group-sm" role="group" aria-label="Second group">
                                    <button id="1A" type="button" className="btn btn-outline-primary btn-sm btn-matematica  btn-single">1º ano</button>
                                </div>;
                break;
            case "2A":
                buttonRender =  <div className="btn-group mr-2 btn-group-sm" role="group" aria-label="Third group">
                                    <button id="2A" type="button" className="btn btn-outline-primary btn-sm btn-matematica  btn-single">2º ano</button>
                                </div>;
                break;
            case "3A":
                buttonRender =  <div className="btn-group mr-2 btn-group-sm" role="group" aria-label="Fourth group">
                                    <button id="3CA" type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-left border-right-0">3º ano - CA</button>
                                    <button id="3CM" type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-right border-left-0">3º ano - CM</button>
                                </div>;
                break;
            case "4A":
                buttonRender =  <div className="btn-group mr-2 btn-group-sm" role="group" aria-label="Fifth group">
                                    <button id="4CA" type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-left border-right-0">4º ano - CA</button>
                                    <button id="4CM" type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-right border-left-0">4º ano - CM</button>
                                </div>;
                break;
            case "5A":
                buttonRender =  <div className="btn-group mr-2 btn-group-sm" role="group" aria-label="Sixth group">
                                    <button id="5CA" type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-left border-right-0">5º ano - CA</button>
                                    <button id="5CM" type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-right border-left-0">5º ano - CM</button>
                                </div>;
                break;
            case "6A":
                buttonRender =  <div className="btn-group mr-2 btn-group-sm" role="group" aria-label="Seventh group">
                                    <button id="6CA" type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-left border-right-0">6º ano - CA</button>
                                    <button id="6CM" type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-right border-left-0">6º ano - CM</button>
                                </div>;
                break;
            case "MT":
                buttonRender =  <div className="btn-group mr-2 btn-group-sm" role="group" aria-label="First group">
                                    <button id="MT" type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-single">Alfabetização</button>
                                </div>;
                break;
            default:
                buttonRender = "";

        }
        return (
            <div className="btn-planning">
                {buttonRender}
            </div>
        );
    }
}