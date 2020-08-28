import React, { useEffect, memo } from "react";


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
          ? aluno.respostas.find(
              (x) =>
                x.periodoId === periodo.id &&
                x.pergunta === perguntaSelecionada.id
            )
          : [];
        return (
          <th>
            <small>{resposta && resposta.resposta ? resposta.resposta : "Vazio"}</small>
          </th>
        );
      })}
    </tr>
  );
}

export default memo(AlunoSondagemMatematicaAutoral);
