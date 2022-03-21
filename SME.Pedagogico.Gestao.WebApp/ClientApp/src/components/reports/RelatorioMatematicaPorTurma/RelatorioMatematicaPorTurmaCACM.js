import React from "react";
import { CorpoRelatorio } from "./RelatorioMatematicaPorTurma.css";

const RelatorioMatematicaPorTurmaCACM = (props) => {
  const { alunos, perguntas } = props;

  const construirCabeçalho = () => {
    return (
      <div className="d-flex poll-report-grid-header border-bottom border-white mt-3">
        <div class="col-4 "></div>
        {perguntas.map((pergunta) => (
          <div className="col sc-gray border-left border-white">
            <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-bold">
              ORDEM {pergunta.ordenacao} - {pergunta.nome.toUpperCase()}
            </div>
          </div>
        ))}
      </div>
    );
  };

  const construirSubCabecalho = () => {
    return (
      <div className="d-flex poll-report-grid-header border-bottom border-white">
        <div className="col-1 sc-gray">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center">
            Cod. EOL
          </div>
        </div>
        <div className="col-3 sc-gray">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center">
            Nome do estudante
          </div>
        </div>
        {perguntas.map((pergunta) =>
          pergunta.perguntasFilhas.map((perguntasFilha) => {
            return (
              <div class="col sc-gray border-left border-white">
                <div class="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center">
                  {perguntasFilha.nome}
                </div>
              </div>
            );
          })
        )}
      </div>
    );
  };

  const construirItens = (aluno) => {
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

        {perguntas.map((pergunta) =>
          pergunta.perguntasFilhas.map((perguntasFilha, index) => {
            const par = index % 2 === 0;
            const corCelula = par ? "sc-lightpurple" : "sc-darkblue";
            let perguntaRepondida = undefined;
            aluno.perguntas.forEach((pergunta) => {
              const resp = pergunta.subPerguntas.find(
                (subPergunta) => subPergunta.subPerguntaId === perguntasFilha.id
              );
              perguntaRepondida = resp;
            });
            const resposta = perguntaRepondida
              ? perguntaRepondida.resposta
              : "";

            return (
              <div
                className={`col overflow-hidden border-left border-white ${corCelula}`}
              >
                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center text-white font-weight-light">
                  <span
                    className="item-celula"
                    data-toggle="tooltip"
                    data-placement="bottom"
                    title={resposta}
                  >
                    {resposta}
                  </span>
                </div>
              </div>
            );
          })
        )}
      </div>
    );
  };

  return (
    <>
      {alunos && alunos.length ? (
        <>
          {construirCabeçalho()}
          <CorpoRelatorio>
            {construirSubCabecalho()}
            {alunos.map((aluno) => construirItens(aluno))}
          </CorpoRelatorio>
        </>
      ) : null}
    </>
  );
};

export default RelatorioMatematicaPorTurmaCACM;
