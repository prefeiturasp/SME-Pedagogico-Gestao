import React, { useEffect } from 'react';
import Select from './select';

function Aluno({ aluno, perguntas, periodo }) {

    const onChange = (respostaId) => {

    };

    return <tr>
        <th className="align-middle">
            <small className="ml-2 pr-4">
                <b>{aluno.numeroChamada}</b>
            </small>
            <small>{aluno.nomeAluno}</small>
        </th>
        {perguntas && perguntas.map(pergunta => {
            const alunoResposta = aluno.respostas && aluno.respostas.find(resposta => resposta.pergunta == pergunta.id && resposta.periodoId === periodo.id);

            return <th className="align-middle">
                <Select lista={pergunta.respostas} valorId={alunoResposta && alunoResposta.resposta} onChangeSelect={onChange} />
            </th>
        })}
    </tr>;
}

export default Aluno;