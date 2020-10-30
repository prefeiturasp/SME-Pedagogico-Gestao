import React from "react";
import { CorpoRelatorio } from "./RelatorioMatematicaPorTurma.css";

const RelatorioMatematicaPorTurma = (props) => {
  const { alunos, perguntas } = props;

  const constuirHeader = () => {
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
        {perguntas.map((pergunta) => {
          return (
            <div className="col sc-gray border-left border-white font-weight-bold">
              <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-bold">
                {pergunta.nome}
              </div>
            </div>
          );
        })}
      </div>
    );
  };

  const construirItens = (codigoEol, nomeEstudante, perguntasAluno) => {
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
        {perguntas.map((pergunta) => {
          const resposta = perguntasAluno.find((p) => p.id === pergunta.id);
          return (
            <div className="col overflow-hidden">
              <div className="sc-text-size-00 d-flex flex-fill h-100 align-items-center">
                <span className="item-celula" data-toggle="tooltip" data-placement="bottom" title={resposta.valor || ""}>
                  {resposta.valor || ""}
                </span>
              </div>
            </div>
          );
        })}
      </div>
    );
  };

  return (
    <>
      {alunos && alunos.length ? (
        <CorpoRelatorio>
          {constuirHeader()}
          {alunos.map((aluno) =>
            construirItens(aluno.codigoAluno, aluno.nomeAluno, aluno.perguntas)
          )}
        </CorpoRelatorio>
      ) : null}
    </>
  );
};

export default RelatorioMatematicaPorTurma;
