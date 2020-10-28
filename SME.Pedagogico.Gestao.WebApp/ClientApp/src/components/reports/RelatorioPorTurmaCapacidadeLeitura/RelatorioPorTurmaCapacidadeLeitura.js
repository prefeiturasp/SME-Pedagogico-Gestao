import React from "react";
import {
  CabecalhoOrdens,
  ItensCapacidadeLeituraPorTurma,
} from "./RelatorioPorTurmaCapacidadeLeitura.css";

const RelatorioPorTurmaCapacidadeLeitura = (props) => {
  const { ordens, perguntas, alunos } = props;

  const getCabecalhoOrdens = () => {
    return ordens.map((ordem) => {
      return (
        <div className="col-3 sc-gray border-left border-white">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-bold">
            {ordem.nome}
          </div>
        </div>
      );
    });
  };

  const getCabecalhoPerguntas = () => {
    return perguntas.map((ordem) => {
      return (
        <div className="col-1 sc-gray border-left border-white">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-bold">
            {ordem.nome}
          </div>
        </div>
      );
    });
  };

  const getDadosAlunos = aluno => {
    return ordens.map((ordem) => {
      const ordemAluno = aluno.ordens.find((o) => o.id === ordem.id);
      return perguntas.map((pergunta) => {
        const perguntaAluno =
          ordemAluno && ordemAluno.perguntas.find((p) => p.id === pergunta.id);
        return (
          <div className="col-1 border-right">
            <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">
              {perguntaAluno ? perguntaAluno.valor : ""}
            </div>
          </div>
        );
      });
    });
  };

  return (
    <div>
      <CabecalhoOrdens className="d-flex poll-report-grid-header border-bottom border-white">
        <div className="col-3" />
        {getCabecalhoOrdens()}
      </CabecalhoOrdens>
      <CabecalhoOrdens className="d-flex poll-report-grid-header border-bottom border-white">
        <div className="col-1 sc-gray border-left border-white">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-bold">
            Código EOL
          </div>
        </div>
        <div className="col-2 sc-gray border-left border-white">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-bold">
            Nome do estudante
          </div>
        </div>
        {ordens.map(() => {
          return getCabecalhoPerguntas();
        })}
      </CabecalhoOrdens>
      {alunos.map((aluno) => {
        return (
          <ItensCapacidadeLeituraPorTurma className="d-flex poll-report-grid-item border-bottom">
            <div className="col-1">
              <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">
                {aluno.codigoAluno}
              </div>
            </div>
            <div className="col-2 border-right">
              <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">
                <span>{aluno.nomeAluno}</span>
              </div>
            </div>
            {getDadosAlunos(aluno)}
          </ItensCapacidadeLeituraPorTurma>
        );
      })}
    </div>
  );
};

export default RelatorioPorTurmaCapacidadeLeitura;
