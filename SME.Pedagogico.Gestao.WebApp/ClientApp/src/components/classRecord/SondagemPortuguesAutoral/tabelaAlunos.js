import React, { useState, useMemo, useEffect } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import Aluno from './aluno';
import { actionCreators as PortuguesStore } from "../../../store/SondagemPortuguesStore";
import Mocks from './mocks';

// import { Container } from './styles';

function TabelaAlunos({ filtros, periodos, idOrdemSelecionada, grupoSelecionado, salvar }) {
    const dispatch = useDispatch();

    const [ordenacaoAtual, setOrdenacaoAtual] = useState(0);

    const alunos = useSelector(store => store.sondagemPortugues.alunos);

    const emEdicao = useSelector(store => store.sondagemPortugues.emEdicao);

    const perguntas = useSelector(store => store.sondagemPortugues.perguntas);

    const periodoSelecionado = useSelector(store => store.sondagemPortugues.periodoSelecionado);

    const sequenciaOrdens = useSelector((store) => store.sondagemPortugues.sequenciaOrdens);

    console.log(sequenciaOrdens);

    const sequenciaOrdemAtual = useMemo(() => {
        if (!sequenciaOrdens || sequenciaOrdens.length <= 0)
            return 1;

        const index = sequenciaOrdens.findIndex(ordem => {
            return ordem.ordemId === idOrdemSelecionada;
        });

        if (index >= 0)
            return index + 1;

        if (sequenciaOrdens.length < 3) {
            return sequenciaOrdens.length + 1;
        }

        let indexNull = sequenciaOrdens.findIndex(ordem => ordem.ordemId === null);

        return indexNull === -1 ? 0 : indexNull + 1;

    }, [sequenciaOrdens, idOrdemSelecionada])

    const ultimaOrdenacao = useMemo(() => {
        if (!periodos) return;

        return periodos.length - 1;
    }, [periodos]);

    const primeiraOrdenacao = useMemo(() => {
        if (!periodos) return;

        return periodos.length - periodos.length;
    }, [periodos]);

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
        if (sequenciaOrdemAtual === 0)
            return;

        dispatch(PortuguesStore.listarPerguntasPortugues(sequenciaOrdemAtual, grupoSelecionado));
    }, [sequenciaOrdemAtual])

    useEffect(() => {
        if (ordenacaoAtual < 0)
            return;

        if (emEdicao) {
            console.log(alunos);
            salvar({ novoPeriodoId: periodos[ordenacaoAtual] });
            return;
        }


        dispatch(PortuguesStore.setar_periodo_selecionado(periodos[ordenacaoAtual]));
    }, [ordenacaoAtual])

    useEffect(() => {
        if (!periodoSelecionado)
            return;

        filtros.periodoId = periodoSelecionado.id;

        dispatch(PortuguesStore.listarAlunosPortugues(filtros));

    }, [periodoSelecionado])

    useEffect(() => {
        if (!idOrdemSelecionada && periodoSelecionado)
            return;

        dispatch(PortuguesStore.setar_periodo_selecionado(periodos[0]));
    }, [idOrdemSelecionada, periodos])

    useEffect(() => {
        dispatch(PortuguesStore.listarBimestres());
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
                return <Aluno aluno={alunoObjeto} perguntas={perguntas} periodo={periodoSelecionado} idOrdemSelecionada={idOrdemSelecionada} />
            })}
        </tbody>
    </table> : <div></div>;
}

export default TabelaAlunos;