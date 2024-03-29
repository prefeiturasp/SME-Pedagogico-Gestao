import React from "react";
import { Spring } from "react-spring/renderprops";
import { animated } from "react-spring";
import "./TwoStepsSave.css";
import { Card } from "reactstrap";
import PropTypes from "prop-types";

import {
  ButtonClose,
  MessageWrapper,
  ButtonDownload,
} from "./MessagemInformacao.css";

export default function MensagemInformacao({
  acaoFeedBack,
  exibir,
  linkPdf,
  mensagemPrincipal,
  botaoSim,
  botaoNao,
  titulo,
  confirmacao,
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
              <Card className="col-4 p-4">
                {linkPdf && (
                  <ButtonClose className="btn btn-lg" onClick={acaoFeedBack}>
                    <i className="fas fa-times"></i>
                  </ButtonClose>
                )}
                <div className="border-bottom sc-text-size-4">{titulo}</div>

                <MessageWrapper className="pt-2 sc-text-size-1">
                  {mensagemPrincipal}
                  {linkPdf && (
                    <ButtonDownload
                      href={linkPdf}
                      target="_blank"
                      class="btn-baixar-relatorio"
                    >
                      <i class="fas fa-arrow-down mr-2"></i>
                      Download
                    </ButtonDownload>
                  )}
                </MessageWrapper>
                {!linkPdf && !confirmacao && (
                  <div className="pt-5 d-flex justify-content-end">
                    <button
                      type="button"
                      className="col-3 btn btn-primary btn-sm sc-darkblue-button"
                      onClick={acaoFeedBack}
                    >
                      Ok
                    </button>
                  </div>
                )}
                {confirmacao && (
                  <div className="pt-5 d-flex justify-content-end">
                    <button
                      type="button"
                      className="btn btn-outline-primary btn-sm mr-3 sc-darkblue-outline-button btn-message"
                      onClick={botaoNao}
                    >
                      Não
                    </button>
                    <button
                      type="button"
                      className="btn btn-primary btn-sm sc-darkblue-button btn-message"
                      onClick={botaoSim}
                    >
                      Sim
                    </button>
                  </div>
                )}
              </Card>
            </div>
          </animated.div>
        )}
      </Spring>
    </div>
  );
}

MensagemInformacao.defaultProps = {
  acaoFeedBack: () => {},
  exibir: false,
  linkPdf: "",
  mesagemPrincipal: "",
  titulo: "",
  botaoSim: () => {},
  botaoNao: () => {},
  confirmacao: false,
};

MensagemInformacao.propTypes = {
  acaoFeedBack: PropTypes.func,
  exibir: PropTypes.bool,
  linkPdf: PropTypes.string,
  mesagemPrincipal: PropTypes.string,
  titulo: PropTypes.string,
  botaoSim: PropTypes.func,
  botaoNao: PropTypes.func,
  confirmacao: PropTypes.bool,
};
