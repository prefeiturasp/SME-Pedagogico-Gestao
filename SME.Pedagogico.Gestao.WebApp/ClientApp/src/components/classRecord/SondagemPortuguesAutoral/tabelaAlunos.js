import React, { useState, useMemo, useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import Aluno from "./aluno";
import { actionCreators as PortuguesStore } from "../../../store/SondagemPortuguesStore";
import MensagemLimparSelecao from "./mensagemLimparSelecao";
import Loader from "../../loader/Loader";

function TabelaAlunos({
  filtros,
  periodos,
  idOrdemSelecionada,
  grupoSelecionado,
  salvar,
}) {
  const dispatch = useDispatch();

  const [ordenacaoAtual, setOrdenacaoAtual] = useState(0);
  const [carregandoAlunos, setCarregandoAlunos] = useState(false);

  const [exibirConfirmacaoExclusao, setExibirConfirmacaoExclusao] =
    useState(false);

  const [mostrarMensagemConfirmacao, setMostrarMensagemConfirmacao] =
    useState(false);

  const alunos = useSelector((store) => store.sondagemPortugues.alunos);

  const emEdicao = useSelector((store) => store.sondagemPortugues.emEdicao);

  const perguntas = useSelector((store) => store.sondagemPortugues.perguntas);

  let periodoSelecionado = useSelector(
    (store) => store.sondagemPortugues.periodoSelecionado
  );

  if (!periodoSelecionado) periodoSelecionado = periodos[0];

  const exibirLimparCampos = useMemo(() => {
    if (!periodoSelecionado) return false;

    return grupoSelecionado === "e27b99a3-789d-43fb-a962-7df8793622b1";
  }, [periodoSelecionado]);

  const sequenciaOrdens = useSelector(
    (store) => store.sondagemPortugues.sequenciaOrdens
  );

  const ehEdicao = useMemo(() => {
    return alunos && alunos.findIndex((aluno) => aluno.id !== null) >= 0;
  }, [alunos]);

  const sequenciaOrdemAtual = useMemo(() => {
    if (!sequenciaOrdens || sequenciaOrdens.length <= 0) return 1;

    const ordem = sequenciaOrdens.find((ordem) => {
      return ordem.ordemId === idOrdemSelecionada;
    });

    if (ordem) return ordem.sequenciaOrdemSalva;

    for (let index = 1; index < 4; index++) {
      const ordem = sequenciaOrdens.find(
        (seq) => seq.sequenciaOrdemSalva === index
      );

      if (ordem) continue;

      return index;
    }
  }, [sequenciaOrdens, idOrdemSelecionada]);

  const ultimaOrdenacao = useMemo(() => {
    if (!periodos) return;

    return periodos.length - 1;
  }, [periodos]);

  const primeiraOrdenacao = useMemo(() => {
    if (!periodos) return;

    return periodos.length - periodos.length;
  }, [periodos]);

  const trocarExibirConfirmacaoExclusao = () => {
    if (mostrarMensagemConfirmacao) {
      setMostrarMensagemConfirmacao(false);
      setExibirConfirmacaoExclusao(false);
      return;
    }
    setExibirConfirmacaoExclusao(false);
  };

  const avancar = () => {
    if (ordenacaoAtual == ultimaOrdenacao) return;

    setCarregandoAlunos(true);
    setOrdenacaoAtual((oldState) => oldState + 1);
  };

  const recuar = () => {
    if (ordenacaoAtual == primeiraOrdenacao) return;

    setCarregandoAlunos(true);
    setOrdenacaoAtual((oldState) => oldState - 1);
  };

  const solicitarLimparSelecao = () => {
    setExibirConfirmacaoExclusao(true);
  };

  const limparSelecao = () => {
    if (!ehEdicao) {
      dispatch(PortuguesStore.limpar_respostas_alunos());
      dispatch(PortuguesStore.remover_sequencia_ordens(idOrdemSelecionada));
    } else {
      dispatch(PortuguesStore.excluir_sondagem_portugues(filtros));
    }
  };

  useEffect(() => {
    if (sequenciaOrdemAtual === 0 || sequenciaOrdemAtual === -1) return;

    dispatch(
      PortuguesStore.listarPerguntasPortugues(
        sequenciaOrdemAtual,
        grupoSelecionado
      )
    );
  }, [sequenciaOrdemAtual]);

  useEffect(() => {
    if (ordenacaoAtual < 0) return;

    if (emEdicao) {
      salvar({ novoPeriodoId: periodos[ordenacaoAtual] });
      return;
    }

    dispatch(
      PortuguesStore.setar_periodo_selecionado(periodos[ordenacaoAtual])
    );
  }, [ordenacaoAtual]);

  useEffect(() => {
    alunos && setCarregandoAlunos(false);
  }, [alunos]);

  useEffect(() => {
    if (!periodoSelecionado) return;

    filtros.periodoId = periodoSelecionado.id;

    dispatch(PortuguesStore.listarAlunosPortugues(filtros));
  }, [periodoSelecionado]);

  useEffect(() => {
    if (!idOrdemSelecionada && periodoSelecionado) return;

    setOrdenacaoAtual(0);
    dispatch(PortuguesStore.setar_periodo_selecionado(periodos[0]));
  }, [idOrdemSelecionada, periodos]);

  useEffect(() => {
    dispatch(PortuguesStore.listarBimestres());
  }, []);

  const ehPrimeiraOrdenacao = ordenacaoAtual === 0;
  const ehUltimaOrdenacao = ordenacaoAtual === ultimaOrdenacao;

  const voltarDesabilitado = ehPrimeiraOrdenacao || carregandoAlunos;
  const avancarDesabilitado = ehUltimaOrdenacao || carregandoAlunos;

  return periodoSelecionado ? (
    <>
      <table
        className="table table-sm table-bordered table-hover table-sondagem-matematica"
        style={{ overflow: "hidden", overflowX: "auto" }}
      >
        <thead>
          <tr>
            <th rowSpan="2" className="align-middle border text-color-purple">
              <div className="ml-2">Sondagem - {filtros.anoEscolar}º ano</div>
            </th>
            <th
              colSpan={
                perguntas && perguntas.length > 0 ? perguntas.length + 1 : 6
              }
              key="sdadsadasd"
              id="sdadsadasd"
              className="text-center border text-color-purple"
            >
              <span
                value="opacos_col"
                onClick={() => {
                  recuar();
                }}
                className="testcursor"
                disabled={voltarDesabilitado}
              >
                <img
                  src={
                    voltarDesabilitado
                      ? `./img/icon_pt_DADADA.svg`
                      : `./img/icon_2_pt_7C4DFF.svg`
                  }
                  alt={`seta esquerda ${
                    voltarDesabilitado ? "inativa" : "ativa"
                  }`}
                  style={{ height: 20 }}
                />
              </span>
              <b className="p-4">{periodoSelecionado.descricao}</b>
              <span
                value="zero_col"
                onClick={() => {
                  avancar();
                }}
                className="testcursor"
                disabled={avancarDesabilitado}
              >
                <img
                  src={
                    avancarDesabilitado
                      ? `./img/icon_2_pt_DADADA.svg`
                      : `./img/icon_pt_7C4DFF.svg`
                  }
                  alt={`seta direita ${
                    avancarDesabilitado ? "inativa" : "ativa"
                  }`}
                  style={{ height: 20 }}
                />
              </span>
              {exibirLimparCampos ? (
                <>
                  <button
                    disabled={!(emEdicao || ehEdicao)}
                    onClick={solicitarLimparSelecao}
                    className="btn btn-link float-right pr-3"
                  >
                    Limpar seleções
                  </button>
                </>
              ) : (
                <></>
              )}
            </th>
          </tr>
          <tr>
            {perguntas &&
              perguntas.length &&
              perguntas.map((pergunta) => (
                <th
                  style={{ width: "10%" }}
                  key={pergunta.id}
                  className="text-center border poll-select-container"
                >
                  <small className="text-muted">{pergunta.descricao}</small>
                </th>
              ))}
          </tr>
        </thead>
        <tbody>
          <Loader loading={carregandoAlunos} />

          {alunos &&
            perguntas &&
            perguntas.length > 0 &&
            alunos.length > 0 &&
            alunos.map((alunoObjeto) => {
              return (
                <Aluno
                  aluno={alunoObjeto}
                  perguntas={perguntas}
                  periodo={periodoSelecionado}
                  grupoSelecionado={grupoSelecionado}
                  idOrdemSelecionada={idOrdemSelecionada}
                />
              );
            })}
        </tbody>
      </table>

      <MensagemLimparSelecao
        controleExibicao={trocarExibirConfirmacaoExclusao}
        acaoPrincipal={async () => {
          setMostrarMensagemConfirmacao(true);
          limparSelecao();
        }}
        exibir={exibirConfirmacaoExclusao}
        ehEdicao={ehEdicao}
        acaoSecundaria={() => Promise.resolve()}
      />
    </>
  ) : (
    <div></div>
  );
}

export default TabelaAlunos;
