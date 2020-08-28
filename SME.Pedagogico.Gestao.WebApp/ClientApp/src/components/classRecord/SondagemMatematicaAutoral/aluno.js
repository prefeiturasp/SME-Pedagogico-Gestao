import React, { useEffect, memo } from "react";

// import { Container } from './styles';

function AlunoSondagemMatematicaAutoral({
  perguntaSelecionada,
  periodos,
  aluno,
}) {

  return (
    <tr>
      <th className="align-middle">
        <small className="ml-2 pr-4">
          <b>{0}</b>
        </small>
        <small>{aluno.nomeAluno}</small>
      </th>
      {periodos.map((periodo) => {
        const resposta = aluno.respostas
          ? aluno.respostas.find((x) => {
            var retorno =
              x.periodoId === periodo.id &&
              x.perguntaId === perguntaSelecionada.id;

              return retorno;
          })
          : [];
        return (
          <th>
            <small>
              {resposta ? resposta.resposta : "Vazio"}
            </small>
          </th>
        );
      })}
    </tr>
  );
}

export default memo(AlunoSondagemMatematicaAutoral);
