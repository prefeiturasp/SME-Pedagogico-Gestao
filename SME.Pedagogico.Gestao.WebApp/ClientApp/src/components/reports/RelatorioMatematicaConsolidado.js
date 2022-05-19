import React from "react";
import {
  CabecalhoRelatorio,
  TotalRelatorio,
} from "./RelatorioMatematicaConsolidado.css";

const RelatorioMatematicaConsolidado = (props) => {
  const { dados } = props;

  const ItemRelatorio = (nome, quantidade, porcentagem) => {
    return (
      <div className="d-flex poll-report-grid-item border-bottom">
        <div className="col-4">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">
            {nome}
          </div>
        </div>
        <div className="col-7 sc-lightpurple">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light text-white">
            {quantidade} Alunos
          </div>
        </div>
        <div className="col-1 sc-darkgray">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light text-white">
            {porcentagem} %
          </div>
        </div>
      </div>
    );
  };

  return (
    <div>
      <CabecalhoRelatorio className="d-flex poll-report-grid-header border-bottom border-white">
        <div className="col-4 sc-gray">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-bold">
            {dados.nome}
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
      </CabecalhoRelatorio>
      {dados.respostas.map((resposta) =>
        ItemRelatorio(resposta.nome, resposta.quantidade, resposta.porcentagem)
      )}
      <TotalRelatorio className="mb-4 d-flex poll-report-grid-item">
        <div className="col-4 sc-gray">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">
            TOTAL
          </div>
        </div>
        <div className="col-7 sc-gray">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">
            {dados.total.quantidade} Alunos
          </div>
        </div>
        <div className="col-1 sc-gray">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">
            {dados.total.porcentagem} %
          </div>
        </div>
      </TotalRelatorio>
    </div>
  );
};

export default RelatorioMatematicaConsolidado;
