import React, { useMemo } from 'react';
import Select from './select';
import { actionCreators as PortuguesStore } from "../../../store/SondagemPortuguesStore";
import { useDispatch, useSelector } from 'react-redux';
import RadioButtonGroup from './radioButton';
import CheckBox from './checkbox';
import { TIPO_PERIODO } from "../../../Enums";

function Aluno({ aluno, perguntas, periodo, idOrdemSelecionada, grupoSelecionado }) {
    const dispatch = useDispatch();
    const periodosAbertura = useSelector(store => store.filters.period);

    const verificarPeriodoAberto = (bimestre, tipoPeriodicidade = TIPO_PERIODO.BIMESTRE) => {
        var todayDate = new Date();
        todayDate.setHours(0, 0, 0, 0);
        if (!periodosAbertura) return false;
        const aberto = periodosAbertura.find(p => p.bimestre === bimestre && p.tipoPeriodicidade === tipoPeriodicidade);

        if (!aberto) return false;

        return new Date(aberto.dataInicio) <= todayDate && new Date(aberto.dataFim) >= todayDate;
    }

    const bloqueadoPeriodoAbertura = useMemo(() => {
        switch (periodo.id) {
            case "fbd8b833-d7dc-4d04-9af6-50c1aaa2f8c0":
                return !verificarPeriodoAberto(1);
            case "05ce183c-cb37-44fb-9c30-dac5ae5b8d37":
                return !verificarPeriodoAberto(2);
            case "a8d3311a-b71e-45ce-8667-cef062334949":
                return !verificarPeriodoAberto(3);
            case "aa7f39fc-3b50-4aea-bd05-4bbe7cba687c":
                return !verificarPeriodoAberto(4);
            case "c93c1c4a-abb9-43a4-a8cd-283e4df365d8":
                return !verificarPeriodoAberto(1, TIPO_PERIODO.SEMESTRE);
            case "8de86d08-b7a1-45df-b775-07550714756b":
                return !verificarPeriodoAberto(2, TIPO_PERIODO.SEMESTRE);
            default:
                return true;
        }
    }, [periodo.id, verificarPeriodoAberto])

    const onChange = (respostaId, perguntaId) => {
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
                        <Select lista={pergunta.respostas} valorId={alunoResposta && alunoResposta.resposta} bloqueado={bloqueadoPeriodoAbertura} onChangeSelect={onChange} dados={pergunta.id} />
                    </td>
                });

            case "6a3d323a-2c44-4052-ba68-13a8dead299a":
                return (<RadioButtonGroup lista={perguntas} valor={aluno && aluno.respostas} periodoId={periodo.id} bloqueado={bloqueadoPeriodoAbertura} codigoAluno={aluno.codigoAluno} />);

            case "263b55b8-efa2-480c-80ad-f4e8f0935e12":
                return (<CheckBox lista={perguntas} valor={aluno && aluno.respostas} periodoId={periodo.id} bloqueado={bloqueadoPeriodoAbertura} codigoAluno={aluno.codigoAluno} />)

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