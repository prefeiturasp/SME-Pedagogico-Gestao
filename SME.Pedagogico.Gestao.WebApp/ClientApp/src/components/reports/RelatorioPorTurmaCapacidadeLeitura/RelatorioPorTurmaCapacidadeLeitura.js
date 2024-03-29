import React from "react";
import {
  CabecalhoOrdens,
  EOLColumn,
  ItensCapacidadeLeituraPorTurma,
} from "./RelatorioPorTurmaCapacidadeLeitura.css";

const RelatorioPorTurmaCapacidadeLeitura = (props) => {
  const { ordens, perguntas, alunos } = props;

  const getCabecalhoOrdens = () => {
    return ordens.map((ordem) => {
      return (
        <div key={ordem.id} className="col-3 sc-gray border-right border-white">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-bold">
            {ordem.nome}
          </div>
        </div>
      );
    });
  };

  const getCabecalhoPerguntas = () => {
    return perguntas.map((ordem, index) => {
      return (
        <div key={ordem.id} className="col-1 sc-gray border-right border-white">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-bold">
            {ordem.nome}
          </div>
        </div>
      );
    });
  };

  const getDadosAlunos = (aluno) => {
    return ordens.map((ordem) => {
      const ordemAluno = aluno.ordens.find((o) => o.id === ordem.id);
      return perguntas.map((pergunta, index) => {
        let corCelula = "";
        switch (index) {
          case 1:
            corCelula = "sc-darkblue";
            break;
          case 2:
            corCelula = "sc-darkgray";
            break;
          default:
            corCelula = "sc-lightpurple";
            break;
        }
        const perguntaAluno =
          ordemAluno && ordemAluno.perguntas.find((p) => p.id === pergunta.id);
        return (
          <div
            key={`${ordem.id}-${pergunta.id}`}
            className={`col-1 border-right ${corCelula}`}
          >
            <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light text-white">
              {perguntaAluno && perguntaAluno.valor ? perguntaAluno.valor : ""}
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
        <EOLColumn className="col-auto sc-gray border-right border-white">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-bold">
            Código EOL
          </div>
        </EOLColumn>

        <div className="col sc-gray border-right border-white">
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
          <ItensCapacidadeLeituraPorTurma
            key={aluno.codigoAluno}
            className="d-flex border-bottom"
          >
            <EOLColumn className="col-auto">
              <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">
                {aluno.codigoAluno}
              </div>
            </EOLColumn>

            <div className="col border-right">
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
