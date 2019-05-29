import React, { Component } from 'react';
import './TwoStepsSave.css';
import Card from '../containers/Card';
import { Spring, Transition } from 'react-spring/renderprops';
import { useTransition, animated } from 'react-spring';

export default class TwoStepsSave extends Component {
    constructor() {
        super();

        this.hideMessage = this.hideMessage.bind(this);
    }

    hideMessage(e) {
        e.stopPropagation();
        e.nativeEvent.stopImmediatePropagation();
        this.props.showControl();
    }

    render() {
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
                            <div className="block-screen d-flex justify-content-center align-items-center" onClick={this.hideMessage}>
                                <Card />
                            </div>
                        </animated.div>
                    }
                </Spring>
            </div>
        );
    }
}