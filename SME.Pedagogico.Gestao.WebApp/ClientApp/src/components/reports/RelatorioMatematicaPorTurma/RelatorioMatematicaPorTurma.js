import React from "react";
import { CorpoRelatorio } from "./RelatorioMatematicaPorTurma.css";

const RelatorioMatematicaPorTurma = (props) => {
  const { alunos, perguntas, ehAlfabetizacaoCACM } = props;

  const construirPerguntas = () => {
    return (
      <div className="d-flex flex-column ">
        <div className="d-flex flex-column border-bottom border-white">
          <div className="d-flex ">
            {perguntas.map((pergunta) => {
              return (
                <div className="sc-gray d-flex align-items-center border-left border-white font-weight-bold poll-report-grid-header text-truncate tamanho-celula">
                  <div
                    className="sc-text-size-0 font-weight-bold text-truncate"
                    data-bs-toggle="tooltip"
                    title={pergunta.nome}
                  >
                    {pergunta.nome}
                  </div>
                </div>
              );
            })}
          </div>
        </div>
        {alunos.map((aluno) => {
          return (
            <div className="d-flex poll-report-grid-item border-bottom">
              {construirRepostas(aluno.perguntas)}
            </div>
          );
        })}
      </div>
    );
  };

  const constuirHeader = () => {
    return (
      <div className="d-flex flex-column poll-report-grid-header border-bottom border-white">
        <div className="d-flex poll-report-grid-header">
          <div className="primeira-linha sc-gray">
            <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-bold">
              Cod. EOL
            </div>
          </div>
          <div className="segunda-linha sc-gray">
            <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-bold">
              Nome do estudante
            </div>
          </div>
        </div>
        {alunos.map((aluno) =>
          construirItens(aluno.codigoAluno, aluno.nomeAluno)
        )}
      </div>
    );
  };

  const construirRepostas = (perguntasAluno) => {
    return perguntas.map((pergunta, index) => {
      const resposta = perguntasAluno.find((p) => p.id === pergunta.id);
      const par = index % 2 === 0;
      const corCelula =
        par && ehAlfabetizacaoCACM ? "sc-lightpurple" : "sc-darkblue";
      const corBorda = ehAlfabetizacaoCACM ? "" : "border-left border-white";

      return (
        <div
          className={`overflow-hidden ${corCelula} ${corBorda} tamanho-celula`}
        >
          <div className="sc-text-size-00 d-flex flex-fill h-100 align-items-center text-white font-weight-light">
            <span
              className="item-celula"
              data-toggle="tooltip"
              data-placement="bottom"
              title={resposta.valor || ""}
            >
              {resposta.valor || ""}
            </span>
          </div>
        </div>
      );
    });
  };

  const construirItens = (codigoEol, nomeEstudante) => {
    return (
      <div className="d-flex poll-report-grid-item border-bottom">
        <div className="primeira-linha">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">
            {codigoEol}
          </div>
        </div>
        <div className="segunda-linha">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">
            {nomeEstudante}
          </div>
        </div>
      </div>
    );
  };

  return (
    <>
      {alunos && alunos.length ? (
        <CorpoRelatorio>
          <div style={{ overflow: "auto" }}>
            <div className="d-flex">
              <div className="celulas-fixas">{constuirHeader()}</div>
              <div className="celulas-variaveis">{construirPerguntas()}</div>
            </div>
          </div>
        </CorpoRelatorio>
      ) : null}
    </>
  );
};

export default RelatorioMatematicaPorTurma;
