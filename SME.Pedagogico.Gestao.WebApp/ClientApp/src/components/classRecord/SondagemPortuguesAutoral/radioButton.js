import React from 'react';
import { actionCreators as PortuguesStore } from "../../../store/SondagemPortuguesStore";
import { useDispatch } from 'react-redux';

function RadioButtonGroup({ lista, valor, codigoAluno, bloqueado, periodoId }) {
    const dispatch = useDispatch();

    const respostaVerdadeira = (perguntaId) => {
        var pergunta = lista.find(x => x.id === perguntaId);

        if (!pergunta)
            return;

        const respostas = pergunta.respostas.find(x => x.verdadeiro);

        return respostas;
    }

    const verificaSeChecado = perguntaId => {
        if (!valor || valor.length === 0)
            return false;

        const resposta = valor.find(resposta => resposta.pergunta === perguntaId);

        if (!resposta || resposta.length === 0)
            return false;

        const respVerdadeira = respostaVerdadeira(perguntaId);

        const respostaDaPergunta = resposta.pergunta === perguntaId && resposta.periodoId === periodoId && respVerdadeira && resposta.resposta === respVerdadeira.id;

        return respostaDaPergunta;
    }

    const onClick = event => {
        const perguntaId = document.querySelector(`input[name="${event.target.name}"]:checked`).value;

        if (!perguntaId)
            return;

        const pergunta = lista.find(pergunta => pergunta.id === perguntaId);

        if (!pergunta)
            return;

        const resposta = respostaVerdadeira(perguntaId);

        if (!resposta)
            return;

        const respostaAluno = {
            respostaId: resposta.id,
            perguntaId: pergunta.id,
            alunoId: codigoAluno,
            periodoId: periodoId
        };

        dispatch(PortuguesStore.atualizar_resposta_radio_button(respostaAluno))
    }


    return (
        <>
            {
                lista && lista.map(pergunta => {
                    return (
                        <td className="justify-content-center">
                            <div class="form-check justify-content-center justify-items-center justify-self-center">
                                <input class="form-check-input justify-self-center" perguntaid={pergunta.id} disabled={bloqueado} checked={verificaSeChecado(pergunta.id)} onClick={onClick} type="radio" name={codigoAluno} value={pergunta.id} />
                            </div>
                        </td>
                    );
                })
            }
        </>);
}

export default RadioButtonGroup;