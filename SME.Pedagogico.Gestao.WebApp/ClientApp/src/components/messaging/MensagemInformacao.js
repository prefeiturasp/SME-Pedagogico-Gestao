import React, { useEffect, useState } from "react";
import { Spring, Transition } from "react-spring/renderprops";
import { useTransition, animated } from "react-spring";
import "./TwoStepsSave.css";
import { Card } from "reactstrap";

export default function MesangemInformacao({
  acaoFeedBack,
  exibir,
  mensagemFinal,
  mesagemPrincipal,
  palavraEmNegrito,
  titulo,
}) {
  return (
    <div>
      <Spring
        from={{
          display: "none",
          opacity: 0,
        }}
        to={{
          display: exibir ? "block" : "none",
          opacity: exibir ? 1 : 0,
        }}
      >
        {(props) => (
          <animated.div style={props}>
            <div
              id="block-screen"
              className="block-screen d-flex justify-content-center align-items-center"
            >
              <Card className="col-5 p-4">
                <div className="border-bottom sc-text-size-4">{titulo}</div>

                <div className="pt-4 sc-text-size-1">
                  {mesagemPrincipal}
                  <strong>{palavraEmNegrito}</strong>
                  {mensagemFinal}
                </div>

                <div className="pt-5 d-flex justify-content-end">
                  <button
                    type="button"
                    className="col-3 btn btn-primary btn-sm sc-darkblue-button"
                    onClick={acaoFeedBack}
                  >
                    Ok
                  </button>
                </div>
              </Card>
            </div>
          </animated.div>
        )}
      </Spring>
    </div>
  );
}
