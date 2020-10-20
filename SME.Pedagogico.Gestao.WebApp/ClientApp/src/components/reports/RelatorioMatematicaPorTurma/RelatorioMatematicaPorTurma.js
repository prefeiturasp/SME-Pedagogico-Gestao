import React from "react";

const RelatorioMatematicaPorTurma = (props) => {
  const { dados } = props;

  const constuirHeader = (colunas) => {
    return (
      <div className="d-flex poll-report-grid-header border-bottom border-white">
        <div className="col-1 sc-gray">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-bold">
            Cod. EOL
          </div>
        </div>
        <div className="col-3 sc-gray">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-bold">
            Nome do estudante
          </div>
        </div>
        {colunas.map((coluna) => {
          return (
            <div className="col sc-gray border-left border-white font-weight-bold">
              <div className="sc-text-size-00 d-flex flex-fill h-100 align-items-center">
                {coluna.nome}
              </div>
            </div>
          );
        })}
      </div>
    );
  };

  const construirItens = (codigoEol, nomeEstudante, itens) => {
    return (
      <div className="d-flex poll-report-grid-item border-bottom">
        <div className="col-1">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">
            {codigoEol}
          </div>
        </div>
        <div className="col-3">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">
            {nomeEstudante}
          </div>
        </div>
        {itens.map((item) => {
          return (
            <div className="col">
              <div className="sc-text-size-00 d-flex flex-fill h-100 align-items-center">
                {item.resposta}
              </div>
            </div>
          );
        })}
      </div>
    );
  };

  return (
    <>
      {dados && dados.length ? (
        <div>
          {constuirHeader(dados[0].ordens)}
          {dados.map((item) =>
            construirItens(item.codigoEol, item.nomeEstudante, item.ordens)
          )}
        </div>
      ) : null}
    </>
  );
};

export default RelatorioMatematicaPorTurma;
