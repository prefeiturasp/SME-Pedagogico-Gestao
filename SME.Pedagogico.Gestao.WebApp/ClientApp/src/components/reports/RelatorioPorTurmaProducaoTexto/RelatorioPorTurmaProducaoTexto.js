import React from "react";

const RelatorioPorTurmaProducaoTexto = (props) => {
  const { perguntas, alunos } = props;

  const getCabecalhoPerguntas = () => {
    return perguntas.map((pergunta) => {
      return (
        <div className="col sc-gray border-left border-white">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-bold">
            {pergunta.descricao}
          </div>
        </div>
      );
    });
  };

  const getDadosAlunos = (aluno) => {
    return perguntas.map((pergunta, index) => {
      const temPerguntaRespondida = aluno.perguntas
        ? aluno.perguntas.find((a) => a === pergunta.id)
        : false;
      const par = index % 2 === 0;
      const corCelula = par ? 'sc-lightpurple' : 'sc-darkblue';
      return (
        <div
          className={`col align-items-center justify-content-center d-flex flex-fill font-weight-light border-left text-white ${corCelula}`}
        >
          {temPerguntaRespondida ? (
            <i className="fas fa-check-circle ml-2" />
          ) : null}
        </div>
      );
    });
  };

  return (
    <div>
      <div className="d-flex poll-report-grid-header border-bottom border-white">
        <div className="col-1 sc-gray border-left border-white">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-bold">
            Código EOL
          </div>
        </div>
        <div className="col-3 sc-gray border-left border-white">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-bold">
            Nome do estudante
          </div>
        </div>
        {getCabecalhoPerguntas()}
      </div>
      {alunos.map((aluno) => {
        return (
          <div className="d-flex poll-report-grid-item border-bottom">
            <div className="col-1">
              <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">
                {aluno.codigoAluno}
              </div>
            </div>
            <div className="col-3">
              <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">
                {aluno.nomeAluno}
              </div>
            </div>
            {getDadosAlunos(aluno)}
          </div>
        );
      })}
    </div>
  );
};

export default RelatorioPorTurmaProducaoTexto;
