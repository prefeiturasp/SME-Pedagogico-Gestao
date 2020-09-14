import React, { useEffect } from 'react';
import Select from './select';
import { actionCreators as PortuguesStore } from "../../../store/SondagemPortuguesStore";
import { useDispatch } from 'react-redux';
import RadioButtonGroup from './radioButton';

function Aluno({ aluno, perguntas, periodo, idOrdemSelecionada }) {
    const dispatch = useDispatch();

    const onChange = (respostaId, perguntaId) => {

        console.log(idOrdemSelecionada);
        dispatch(PortuguesStore.inserir_sequencia_ordem(idOrdemSelecionada));

        const dadosSalvar = {
            respostaId: respostaId,
            perguntaId: perguntaId,
            alunoId: aluno.codigoAluno,
            periodoId: periodo.id
        };

        dispatch(PortuguesStore.atualizar_resposta(dadosSalvar));
    };

    return <tr>
        <td className="align-middle">
            <small className="ml-2 pr-4">
                <b>{aluno.numeroChamada}</b>
            </small>
            <small>{aluno.nomeAluno}</small>
        </td>
        {perguntas && perguntas.map(pergunta => {
            const alunoResposta = aluno.respostas && aluno.respostas.find(resposta => resposta.pergunta == pergunta.id && resposta.periodoId === periodo.id);

            return <td className="align-middle">
                <Select lista={pergunta.respostas} valorId={alunoResposta && alunoResposta.resposta} onChangeSelect={onChange} dados={pergunta.id} />
            </td>
        })}
    </tr>;
}

export default Aluno;