import React from "react";

const RelatorioPorTurmaLeituraVozAlta = (props) => {
  const { perguntas, alunos } = props;

  const getDadosAlunos = (aluno) => {
    return aluno.perguntas && aluno.perguntas.length
      ? perguntas.find((p) => p.id === aluno.perguntas[0]).descricao
      : "";
  };

  return (
    <div>
      <div className="d-flex poll-report-grid-header border-bottom border-white">
        <div className="col-1 sc-gray border-left border-white">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-bold">
            Código EOL
          </div>
        </div>
        <div className="col-4 sc-gray border-left border-white">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-bold">
            Nome do estudante
          </div>
        </div>
        <div className="col-7 sc-gray border-left border-white">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-bold"></div>
        </div>
      </div>
      {alunos.map((aluno) => {
        return (
          <div className="d-flex poll-report-grid-item border-bottom">
            <div className="col-1">
              <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">
                {aluno.codigoAluno}
              </div>
            </div>
            <div className="col-4">
              <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">
                {aluno.nomeAluno}
              </div>
            </div>
            <div className="col-7 sc-lightpurple">
              <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light text-white">
                {getDadosAlunos(aluno)}
              </div>
            </div>
          </div>
        );
      })}
    </div>
  );
};

export default RelatorioPorTurmaLeituraVozAlta;
