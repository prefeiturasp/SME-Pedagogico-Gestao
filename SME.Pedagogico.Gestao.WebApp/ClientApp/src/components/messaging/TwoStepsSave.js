import React, { Component } from "react";
import "./TwoStepsSave.css";
import Card from "../containers/Card";
import { Spring } from "react-spring/renderprops";
import { animated } from "react-spring";

export default class TwoStepsSave extends Component {
  constructor() {
    super();

    this.state = {
      step: 1,
    };

    this.hideMessage = this.hideMessage.bind(this);
    this.nextStep = this.nextStep.bind(this);
      this.resetState = this.resetState.bind(this);
  }

  hideMessage(event) {
    if (event.target.id === "block-screen") this.props.showControl();
  }

  nextStep() {
    this.setState({
      step: this.state.step >= 2 ? 1 : 2,
    });
  }

  resetState() {
    this.nextStep();
      this.props.showControl();

   }

  render() {
      var { runMethod } = this.props;
      console.log('props', this.props);
    if (runMethod === undefined) runMethod = this.nextStep;
    else
        runMethod = (event) => {
            this.props.runMethod()
                .finally(() => this.nextStep());
      };

    return (
        <div>
            {console.log('status', this.props.status)}
        <Spring
          from={{
            display: "none",
            opacity: 0,
          }}
          to={{
            display: this.props.show ? "block" : "none",
            opacity: this.props.show ? 1 : 0,
          }}
          >
          {(props) => (
            <animated.div style={props}>
              <div
                id="block-screen"
                className="block-screen d-flex justify-content-center align-items-center"
                onClick={this.hideMessage}
              >
                           
                  {this.state.step === 1 ? (
                  <Card className="col-5 p-4">
                    <div className="border-bottom sc-text-size-4">Atenção</div>

                    <div className="pt-4 sc-text-size-1">
                      Deseja salvar as informações?
                    </div>

                    <div className="pt-5 d-flex justify-content-end">
                      <button
                        type="button"
                        className="btn btn-outline-primary btn-sm mr-3 sc-darkblue-outline-button"
                        onClick={this.props.showControl}
                      >
                        Cancelar
                      </button>
                      <button
                        type="button"
                        className="btn btn-primary btn-sm sc-darkblue-button"
                        onClick={runMethod}
                      >
                        Salvar Alterações
                      </button>
                    </div>
                  </Card>
                ) : (this.props.status !== 200  && this.props.status !== null )? (
                  <Card className="col-5 p-4">
                    <div className="border-bottom sc-text-size-4">Erro</div>

                    <div className="pt-4 sc-text-size-1">
                      Seus dados de sondagem não foram salvos.
                    </div>

                    <div className="pt-5 d-flex justify-content-end">
                      <button
                        type="button"
                        className="col-3 btn btn-primary btn-sm sc-darkblue-button"
                        onClick={this.resetState}
                      >
                        Ok
                      </button>
                    </div>
                  </Card>
                ) : (this.props.status !== null) ? (
                  <Card className="col-5 p-4">
                    <div className="border-bottom sc-text-size-4">Sucesso</div>

                    <div className="pt-4 sc-text-size-1">
                      Seus dados de sondagem foram salvos com sucesso.
                    </div>

                    <div className="pt-5 d-flex justify-content-end">
                      <button
                        type="button"
                        className="col-3 btn btn-primary btn-sm sc-darkblue-button"
                        onClick={this.resetState}
                      >
                        Ok
                      </button>
                    </div>
                                </Card>
                            ) : this.resetState}
              </div>
            </animated.div>
          )}
        </Spring>
      </div>
    );
  }
}
