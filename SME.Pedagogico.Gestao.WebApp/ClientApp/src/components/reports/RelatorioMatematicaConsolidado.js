import React from "react";

const HeaderRelatorio = (props) => {
  const { pergunta } = props;
  return (
    <div className="d-flex poll-report-grid-header border-bottom border-white">
      <div className="col-4 sc-gray">
        <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-bold">
          {pergunta}
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
    </div>
  );
};

const ItemRelatorio = (props) => {
  const { nome, quantidade, porcentagem } = props;
  return (
    <div className="d-flex poll-report-grid-item border-bottom">
      <div className="col-4">
        <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">
          {nome}
        </div>
      </div>
      <div className="col-7">
        <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">
          {quantidade} Alunos
        </div>
      </div>
      <div className="col-1">
        <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">
          {porcentagem} %
        </div>
      </div>
    </div>
  );
};

const TotalRelatorio = props => {
  const {quantidade, porcentagem} = props;
  return (
    <div className="mb-4 d-flex poll-report-grid-item">
      <div className="col-4 sc-gray">
        <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">
          TOTAL
        </div>
      </div>
      <div className="col-7 sc-gray">
        <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">
          {quantidade} Alunos
        </div>
      </div>
      <div className="col-1 sc-gray">
        <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">
          {porcentagem} %
        </div>
      </div>
    </div>
  );
};

const RelatorioMatematicaConsolidado = props => {
  const {dados} = props;
  return (
    <div>
      <HeaderRelatorio pergunta={dados.nome} />
      {dados.respostas.map((resposta) => (
        <ItemRelatorio
          nome={resposta.nome}
          quantidade={resposta.quantidade}
          porcentagem={resposta.porcentagem}
        />
      ))}
      <TotalRelatorio
        quantidade={dados.total.quantidade}
        porcentagem={dados.total.porcentagem}
      />
    </div>
  );
};

export default RelatorioMatematicaConsolidado;
