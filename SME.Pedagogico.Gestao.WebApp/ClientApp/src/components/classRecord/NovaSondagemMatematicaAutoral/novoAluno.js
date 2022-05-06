import React from "react";
import AutoralSelect from "./select";

function NovoAlunoSondagemMatematicaAutoral({
    perguntaSelecionada,
    aluno,
    onChangeAluno,
    ehAutoral,
}) {
    return (
        <>
            {ehAutoral ? (
                
                <>
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
                            valor={obtenhaRespostaAutoral(perguntaSelecionada, aluno)}
                            perguntaId={perguntaSelecionada.id}
                            alunoId={aluno.codigoAluno}
                            sondagemId={aluno.id}
                            key={aluno.id}
                            id={aluno.id}
                            onChange={onChangeAluno}
                            disabled={false}
                            mostraToolTipItens
                        ></AutoralSelect>
                    </th>
                </tr> 
        </>
      ) : (
        <>
          <tr>
            <td className="align-middle">
              <small className="ml-2 pr-4">
                <b>{aluno.numeroChamada}</b>
              </small>
              <small>{aluno.nomeAluno}</small>
            </td>
            {perguntaSelecionada.perguntas &&
              perguntaSelecionada.perguntas.map((item) => {
                const acharReposta =
                  aluno.respostas &&
                  aluno.respostas.find((resp) => resp.pergunta === item.id);

                return (
                  <td className="text-center align-center">
                    <AutoralSelect
                      lista={item.respostas}
                      valor={acharReposta && acharReposta.resposta}
                      perguntaId={perguntaSelecionada.id}
                      subPerguntaId={item.id}
                      alunoId={aluno.codigoAluno}
                      sondagemId={aluno.id}
                      onChange={onChangeAluno}
                      mostraToolTipItens
                    ></AutoralSelect>
                  </td>
                );
              })}
          </tr>
        </>
      )}
    </>
  );
}

function obtenhaRespostaAutoral(perguntaSelecionada, aluno) {
    var acharReposta = perguntaSelecionada &&
        aluno &&
        aluno.respostas &&
        aluno.respostas.find((resp) => resp.pergunta === perguntaSelecionada.id);

    return acharReposta && acharReposta.resposta;
}

export default NovoAlunoSondagemMatematicaAutoral;
