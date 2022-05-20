import React from "react";
import {
  CabecalhoCapacidadeLeitura,
  TotalCapacidadeLeitura,
  CabecalhoOrdem,
} from "./RelatorioConsolidadeCapacidadeLeitura.css";

const RelatorioConsolidadoCapacidadeLeitura = (props) => {
  const { dados } = props;

  const construirItemRelatorio = (reposta) => {
    return (
      <div className="d-flex poll-report-grid-item border-bottom">
        <div className="col-4">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">
            {reposta.nome}
          </div>
        </div>
        <div className="col-7 sc-lightpurple">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light text-white">
            {reposta.quantidade} Alunos
          </div>
        </div>
        <div className="col-1 sc-darkgray">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light text-white">
            {reposta.porcentagem} %
          </div>
        </div>
      </div>
    );
  };

  return (
    <div>
      <CabecalhoOrdem className="d-flex poll-report-grid-header border-bottom border-white">
        <div className="col-12 sc-gray">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-bold">
            {dados.ordem}
          </div>
        </div>
      </CabecalhoOrdem>
      {dados.perguntas.map((pergunta, index) => {
        return (
          <>
            <CabecalhoCapacidadeLeitura className="d-flex poll-report-grid-header border-bottom border-white">
              <div className="col-4 sc-gray">
                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-bold">
                  {pergunta.nome}
                </div>
              </div>
              <div className="col-7 sc-gray border-left border-white">
                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-bold">
                  Alunos
                </div>
              </div>
              <div className="col-1 sc-gray border-left border-white">
                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-bold">
                  %
                </div>
              </div>
            </CabecalhoCapacidadeLeitura>
            {pergunta.respostas.map((resposta) => {
              return construirItemRelatorio(resposta);
            })}
            <TotalCapacidadeLeitura className="d-flex poll-report-grid-item border-bottom border-white">
              <div className="col-4 sc-gray">
                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">
                  TOTAL
                </div>
              </div>
              <div className="col-7 sc-gray">
                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">
                  {pergunta.total.quantidade} Alunos
                </div>
              </div>
              <div className="col-1 sc-gray">
                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">
                  {pergunta.total.porcentagem} %
                </div>
              </div>
            </TotalCapacidadeLeitura>
          </>
        );
      })}
    </div>
  );
};

export default RelatorioConsolidadoCapacidadeLeitura;
