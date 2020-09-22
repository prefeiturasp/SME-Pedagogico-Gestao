import React, { useEffect, useMemo } from 'react';
import Select from './select';
import { actionCreators as PortuguesStore } from "../../../store/SondagemPortuguesStore";
import { useDispatch } from 'react-redux';
import RadioButtonGroup from './radioButton';
import CheckBox from './checkbox';

function Aluno({ aluno, perguntas, periodo, idOrdemSelecionada, grupoSelecionado }) {
    const dispatch = useDispatch();

    const ehRadioButton = useMemo(() => grupoSelecionado === "6a3d323a-2c44-4052-ba68-13a8dead299a")

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

    const obterComponentesResposta = () => {
        switch (grupoSelecionado) {
            case 'e27b99a3-789d-43fb-a962-7df8793622b1':
                return perguntas && perguntas.map(pergunta => {
                    const alunoResposta = aluno.respostas && aluno.respostas.find(resposta => resposta.pergunta == pergunta.id && resposta.periodoId === periodo.id);

                    return <td className="align-middle">
                        <Select lista={pergunta.respostas} valorId={alunoResposta && alunoResposta.resposta} onChangeSelect={onChange} dados={pergunta.id} />
                    </td>
                });

            case "6a3d323a-2c44-4052-ba68-13a8dead299a":
                return (<RadioButtonGroup lista={perguntas} valor={aluno && aluno.respostas} periodoId={periodo.id} codigoAluno={aluno.codigoAluno} />);

            case "263b55b8-efa2-480c-80ad-f4e8f0935e12":
                return (<CheckBox lista={perguntas} valor={aluno && aluno.respostas} periodoId={periodo.id} codigoAluno={aluno.codigoAluno} />)

            default:
                return (<div></div>)
        };
    };

    return <tr>
        <td className="align-middle">
            <small className="ml-2 pr-4">
                <b>{aluno.numeroChamada}</b>
            </small>
            <small>{aluno.nomeAluno}</small>
        </td>
        {obterComponentesResposta()}
    </tr>;
}

export default Aluno;