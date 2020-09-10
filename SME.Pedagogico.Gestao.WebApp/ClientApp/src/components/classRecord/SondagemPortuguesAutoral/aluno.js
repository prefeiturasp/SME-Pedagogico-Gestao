import React, { useEffect } from 'react';
import Select from './select';
import { actionCreators as PortuguesStore } from "../../../store/SondagemPortuguesStore";
import { useDispatch } from 'react-redux';

function Aluno({ aluno, perguntas, periodo, onChangeAluno }) {
    const dispatch = useDispatch();

    const onChange = (respostaId, perguntaId) => {

        const dadosSalvar = {
            respostaId: respostaId,
            perguntaId: perguntaId,
            alunoId: aluno.codigoAluno,
            periodoId: periodo.id
        };

        dispatch(PortuguesStore.atualizar_resposta(dadosSalvar));
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
                <Select lista={pergunta.respostas} valorId={alunoResposta && alunoResposta.resposta} onChangeSelect={onChange} dados={pergunta.id} />
            </th>
        })}
    </tr>;
}

export default Aluno;