import React, { useEffect, memo, useMemo } from "react";
import AutoralSelect from "./select";

function AlunoSondagemMatematicaAutoral({
  perguntaSelecionada,
  periodos,
  aluno,
  onChangeAluno
}) {

  


  return (
    <tr>
      <th className="align-middle">
        <small className="ml-2 pr-4">
          <b>{aluno.numeroChamada}</b>
        </small>
        <small>{aluno.nomeAluno}</small>
      </th>
      {periodos.map((periodo, i) => {
        const resposta = aluno.respostas
          ? aluno.respostas.find(
              (x) =>
                x.periodoId === periodo.id &&
                x.pergunta === perguntaSelecionada.id
            )
          : null;

        const respostaSelect =
          resposta && resposta.resposta && resposta.resposta !== {}
            ? resposta.resposta
            : "";

        return (
          <th className="text-center align-center">
            <AutoralSelect
              lista={perguntaSelecionada.respostas}
              valor={respostaSelect}
              perguntaId={perguntaSelecionada.id}
              alunoId={aluno.codigoAluno}
              sondagemId={aluno.id}
                    periodoId={periodo.id}
                    key={i}
                    id={i}
              onChange={onChangeAluno}
              disabled={false}
            ></AutoralSelect>
          </th>
        );
      })}
    </tr>
  );
}

export default AlunoSondagemMatematicaAutoral;
