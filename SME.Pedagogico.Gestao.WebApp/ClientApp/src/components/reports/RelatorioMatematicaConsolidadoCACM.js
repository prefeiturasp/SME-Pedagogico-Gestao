import React from "react";
import {
  CabecalhoRelatorio,
  TotalRelatorio,
} from "./RelatorioMatematicaConsolidado.css";

const RelatorioMatematicaConsolidado = (props) => {
  const { dados } = props;

  const ItemRelatorio = (quantidade, porcentagem, indexSubPergunta) => {
    const corCelula =
      indexSubPergunta % 2 === 0 ? "sc-lightpurple" : "sc-darkblue";

    return (
      <>
        <div className={`col-3 ${corCelula}`}>
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light text-white">
            {quantidade} Alunos
          </div>
        </div>
        <div className="col-1 sc-darkgray">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light text-white">
            {porcentagem} %
          </div>
        </div>
      </>
    );
  };

  return (
    <div>
      <CabecalhoRelatorio className="d-flex poll-report-grid-header border-bottom border-white mt-3">
        <div className="col-4 sc-gray">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-bold">
            ORDEM {dados.ordenacao}
          </div>
        </div>
        <div className="col-8 sc-gray border-left border-white">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center">
            PROBLEMAS DE {dados.nome.toUpperCase()}
          </div>
        </div>
      </CabecalhoRelatorio>

      <div className="d-flex poll-report-grid-header border-bottom border-white">
        <div className="col-4 sc-gray border-right border-white"></div>
        {dados &&
          dados.subPerguntas &&
          dados.subPerguntas.map((subPergunta) => (
            <>
              <div className="col-3 sc-gray border-right border-right border-white">
                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center">
                  {subPergunta.nome}
                </div>
              </div>
              <div className="col-1 sc-gray border-right border-white">
                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center">
                  %
                </div>
              </div>
            </>
          ))}
      </div>
      {dados &&
        dados.subPerguntas &&
        dados.subPerguntas[0].respostas.map((resposta, index) => (
          <div className="d-flex poll-report-grid-item border-bottom">
            <div className="col-4">
              <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">
                {resposta.nome}
              </div>
            </div>
            {dados.subPerguntas.map((subPergunta, indexSubPergunta) => {
              const quantidade = subPergunta.respostas[index].quantidade;
              const porcentagem = subPergunta.respostas[index].porcentagem;
              return ItemRelatorio(quantidade, porcentagem, indexSubPergunta);
            })}
          </div>
        ))}

      <TotalRelatorio className="mb-4 d-flex poll-report-grid-item">
        <div className="col-4 sc-gray">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">
            TOTAL
          </div>
        </div>
        {dados &&
          dados.subPerguntas &&
          dados.subPerguntas.map((subPergunta) => {
            return (
              <>
                <div className="col-3 sc-gray">
                  <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">
                    {subPergunta.total.quantidade} Alunos
                  </div>
                </div>
                <div className="col-1 sc-gray">
                  <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">
                    {subPergunta.total.porcentagem} %
                  </div>
                </div>
              </>
            );
          })}
      </TotalRelatorio>
    </div>
  );
};

export default RelatorioMatematicaConsolidado;
