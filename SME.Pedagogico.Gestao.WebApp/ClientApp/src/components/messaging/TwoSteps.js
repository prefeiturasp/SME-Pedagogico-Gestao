import React, { Component } from 'react';
import './TwoSteps.css';
import Card from '../containers/Card';
import { Spring } from 'react-spring/renderprops';
import { animated } from 'react-spring';

export default class TwoSteps extends Component {
    constructor() {
        super();

        this.state = {
            step: 1,
        };

        this.hideMessage = this.hideMessage.bind(this);
        this.resetState = this.resetState.bind(this);
    }

    hideMessage(event) {
        if (event.target.id === "block-screen")
            this.props.showControl();
    }

    resetState() {
        this.props.showControl();
    }

    render() {
        var { runMethod } = this.props;

        if (runMethod !== undefined)
            runMethod = (event) => { this.props.runMethod(); this.resetState() };

        return (
            <div>
                <Spring
                    from={{
                        display: "none",
                        opacity: 0
                    }}
                    to={{
                        display: this.props.show ? "block" : "none",
                        opacity: this.props.show ? 1 : 0
                    }}>
                    {props =>
                        <animated.div style={props}>
                            <div id="block-screen" className="block-screen d-flex justify-content-center align-items-center" onClick={this.hideMessage}>
                                <Card className="col-5 p-4">
                                    <div className="border-bottom sc-text-size-4">
                                        Atenção
                                        </div>

                                    <div className="pt-4 sc-text-size-1">
                                        Existem alterações que não foram salvas!
                                            <br />
                                        Deseja continuar sem salvar?
                                        </div>

                                    <div className="pt-5 d-flex justify-content-end">
                                        <button type="button" className="btn btn-outline-primary btn-sm mr-3 sc-darkblue-outline-button btn-message" onClick={this.props.showControl}>Não</button>
                                        <button type="button" className="btn btn-primary btn-sm sc-darkblue-button btn-message" onClick={runMethod}>Sim</button>
                                    </div>
                                </Card>
                            </div>
                        </animated.div>
                    }
                </Spring>
            </div>
        );
    }
}