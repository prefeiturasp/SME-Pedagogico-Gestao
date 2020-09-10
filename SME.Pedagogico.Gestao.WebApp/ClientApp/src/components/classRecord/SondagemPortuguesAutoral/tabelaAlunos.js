import React, { useState, useMemo, useEffect } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import Aluno from './aluno';
import { actionCreators as PortuguesStore } from "../../../store/SondagemPortuguesStore";
import Mocks from './mocks';

// import { Container } from './styles';

function TabelaAlunos({ filtros, periodos }) {
    const dispatch = useDispatch();

    const [ordenacaoAtual, setOrdenacaoAtual] = useState(0);

    const alunos = useSelector(store => store.sondagemPortugues.alunos);

    const perguntas = useSelector(store => store.sondagemPortugues.perguntas);

    console.log(alunos)

    const ultimaOrdenacao = useMemo(() => {
        if (!periodos) return;

        return periodos.length - 1;
    }, [periodos]);

    const primeiraOrdenacao = useMemo(() => {
        if (!periodos) return;

        return periodos.length - periodos.length;
    }, [periodos]);

    const periodoSelecionado = useMemo(() => {
        if (!periodos) return;

        return periodos[ordenacaoAtual];
    }, [ordenacaoAtual, periodos]);

    const avancar = () => {
        if (ordenacaoAtual == ultimaOrdenacao)
            return;

        setOrdenacaoAtual(oldState => oldState + 1);
    }

    const recuar = () => {
        if (ordenacaoAtual == primeiraOrdenacao)
            return;

        setOrdenacaoAtual(oldState => oldState - 1);
    }

    useEffect(() => {
        dispatch(PortuguesStore.setar_perguntas(Mocks.perguntas));
    }, [])

    return periodoSelecionado ? <table
        className="table table-sm table-bordered table-hover table-sondagem-matematica"
        style={{ overflow: "hidden", overflowX: "auto" }}
    >
        <thead>
            <tr>
                <th rowSpan="2" className="align-middle border text-color-purple">
                    <div className="ml-2">Sondagem - {filtros.anoEscolar}º ano</div>
                </th>
                <th
                    colSpan="2"
                    key=""
                    id=""
                    className="text-center border text-color-purple"
                >
                    <span
                        value="opacos_col"
                        onClick={() => { recuar() }}
                        className="testcursor"
                    >
                        <img
                            src="./img/icon_2_pt_7C4DFF.svg"
                            alt="seta esquerda ativa" z
                            style={{ height: 20 }}
                        />
                    </span>
                    <b className="p-4">{periodoSelecionado.descricao}</b>
                    <span
                        value="zero_col"
                        onClick={() => { avancar() }}
                        className="testcursor"
                    >
                        <img
                            src="./img/icon_pt_7C4DFF.svg"
                            alt="seta direita ativa"
                            style={{ height: 20 }}
                        />
                    </span>
                </th>
            </tr>
            <tr>
                {perguntas &&
                    perguntas.map((pergunta) => (
                        <th
                            key={pergunta.id}
                            className="text-center border poll-select-container"
                        >
                            <small className="text-muted">{pergunta.descricao}</small>
                        </th>
                    ))}
            </tr>
        </thead>
        <tbody>
            {alunos && perguntas && perguntas.length > 0 && alunos.length > 0 && alunos.map(alunoObjeto => {
                return <Aluno aluno={alunoObjeto} perguntas={perguntas} periodo={periodoSelecionado} />
            })}
        </tbody>
    </table> : <div></div>;
}

export default TabelaAlunos;