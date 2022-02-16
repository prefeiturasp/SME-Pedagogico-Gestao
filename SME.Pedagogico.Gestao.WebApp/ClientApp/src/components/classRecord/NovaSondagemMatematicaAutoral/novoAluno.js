import React from "react";
import AutoralSelect from "./select";

function NovoAlunoSondagemMatematicaAutoral({
  perguntaSelecionada,
  periodos,
  aluno,
  onChangeAluno,
}) {
  return (
    <tr>
      <th className="align-middle">
        <small className="ml-2 pr-4">
          <b>{aluno.numeroChamada}</b>
        </small>
        <small>{aluno.nomeAluno}</small>
      </th>
      <th className="text-center align-center">
        <AutoralSelect
          lista={perguntaSelecionada.respostas}
          valor={aluno.respostas && aluno.respostas[0].resposta}
          perguntaId={perguntaSelecionada.id}
          alunoId={aluno.codigoAluno}
          sondagemId={aluno.id}
          //periodoId={periodo.id}
          key={aluno.id}
          id={aluno.id}
          onChange={onChangeAluno}
          disabled={false}
          mostraToolTipItens
        ></AutoralSelect>
      </th>
    </tr>
  );
}

export default NovoAlunoSondagemMatematicaAutoral;
