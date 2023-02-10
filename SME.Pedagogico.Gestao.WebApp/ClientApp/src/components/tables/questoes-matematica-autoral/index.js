import React, { useCallback, useEffect } from "react";
import { useMemo } from "react";
import { useDispatch, useSelector } from "react-redux";
import { actionCreators } from "../../../store/SondagemAutoral";
import { actionCreators as pollStore } from "../../../store/Poll";
import { actionCreators as dataStore } from "../../../store/Data";
import Loader from "../../loader/Loader";
import shortid from "shortid";
import {
  PerguntaContainer,
  RespostaContainer,
  TableColumn,
  TableContainer,
  TableHeader,
} from "./styles";
import LinhaAluno from "./linha-aluno";
import { Form } from "antd";
import _ from "lodash";

const QuestoesMatematicaAutoral = () => {
  const dispatch = useDispatch();

  const bimestre = useSelector((store) => store.poll.bimestre);
  const filtros = useSelector((store) => store.poll.selectedFilter);
  const perguntas = useSelector((store) => store.autoral.listaPerguntas);
  const tipoSondagem = useSelector((store) => store.poll.pollTypeSelected);
  const carregandoAlunos = useSelector((store) => store.poll.carregandoAlunos);
  const periodoAberto = useSelector((store) => store.autoral.periodoAberto);

  const [form] = Form.useForm();

  const alunos = useSelector(
    (store) => store.autoral.listaAlunosAutoralMatematica
  );

  const filtrosBusca = useMemo(() => {
    if (!filtros) return;

    return {
      codigoDre: filtros.dreCodeEol,
      anoLetivo: filtros.schoolYear,
      codigoUe: filtros.schoolCodeEol,
      anoEscolar: filtros.yearClassroom,
      codigoTurma: filtros.classroomCodeEol,
      componenteCurricular: "9f3d8467-2f6e-4bcb-a8e9-12e840426aba",
    };
  }, [filtros]);

  useEffect(() => {
    if (filtros.yearClassroom && bimestre) {
      dispatch(actionCreators.obterPeriodoAberto(filtros.schoolYear, bimestre));
      dispatch(actionCreators.listarPerguntas({ ...filtros, bimestre }));

      dispatch(
        pollStore.setFunctionButtonSave((alunosRedux) => {
          persistencia(alunosRedux);
        })
      );
    }
  }, [bimestre, dispatch, filtros, filtros.yearClassroom, tipoSondagem]);

  const setarModoEdicao = () => {
    dispatch(dataStore.set_new_data_state());
    dispatch(pollStore.setDataToSaveTrue());
    dispatch(actionCreators.setarEmEdicao(true));
  };

  const sairModoEdicao = useCallback(() => {
    dispatch(dataStore.reset_new_data_state());
    dispatch(pollStore.set_poll_data_saved_state());
    dispatch(actionCreators.setarEmEdicao(false));
  }, [dispatch]);

  const atualizarRespostasAlunosParaSalvar = (alunosMutaveis, novosValores) => {
    if (!alunosMutaveis || !novosValores) return;

    Object.entries(novosValores).forEach(([key, value]) => {
      if (value === undefined) return;

      const [perguntaId, codigoAluno] = key.split("|");

      const aluno = alunosMutaveis.find((a) => a.codigoAluno === codigoAluno);

      if (!aluno) return;
      if (!aluno.respostas) aluno.respostas = [];

      const resposta = aluno.respostas.find((r) => r.pergunta === perguntaId);

      if (resposta) {
        resposta.resposta = value;
      } else {
        aluno.respostas.push({
          bimestre: Number(aluno.bimestre),
          pergunta: perguntaId,
          periodoId: "",
          resposta: value,
        });
      }
    });

    return alunosMutaveis;
  };

  const persistencia = useCallback(
    async (listaAlunosRedux) => {
      const alunosMutaveis = _.cloneDeep(listaAlunosRedux);
      alunosMutaveis.forEach((element) => {
        if (!element.bimestre) {
          element.bimestre = bimestre;
        }
      });

      const alunosSalvar = atualizarRespostasAlunosParaSalvar(
        alunosMutaveis,
        form.getFieldsValue()
      );

      try {
        await dispatch(
          actionCreators.salvaSondagemAutoralMatematica(alunosSalvar)
        );
      } catch (e) {
        dispatch(pollStore.setLoadingSalvar(false));
      }
      sairModoEdicao();
    },
    [dispatch, sairModoEdicao, bimestre, form]
  );

  useEffect(() => {
    if (
      !bimestre ||
      !filtrosBusca ||
      !filtrosBusca.anoLetivo ||
      !filtrosBusca.anoEscolar
    )
      return;

    dispatch(
      actionCreators.listaAlunosAutoralMatematica(filtrosBusca, bimestre)
    );

    return () => {
      dispatch(actionCreators.limparAlunosAutoralMatematica());
    };
  }, [bimestre, dispatch, filtrosBusca]);

  const novasPerguntas = perguntas?.flatMap(({ id, descricao, respostas }) => [
    {
      id,
      descricao,
      ehPergunta: true,
    },
    ...respostas.map((resposta) => ({
      perguntaId: id,
      ehResposta: true,
      id: shortid.generate(),
      repostaId: resposta?.id,
      descricao: resposta?.descricao,
    })),
  ]);

  const columns = [
    {
      width: 500,
      fixed: "left",
      key: "questoes",
      render: ({ descricao, ehPergunta }) =>
        ehPergunta ? (
          <PerguntaContainer>{descricao}</PerguntaContainer>
        ) : (
          <RespostaContainer>{descricao}</RespostaContainer>
        ),
    },
  ];

  const dynamicColumns = alunos?.map((aluno) => ({
    width: 54,
    align: "center",
    key: shortid.generate(),
    render: (dadosLinha) => (
      <LinhaAluno
        key={shortid.generate()}
        aluno={aluno}
        dadosLinha={dadosLinha}
        onChange={() => setarModoEdicao()}
        periodoAberto={periodoAberto}
      />
    ),
  })) || [];

  const colunas = [...columns, ...dynamicColumns];

  return (
    <>
      {alunos && alunos?.length ? (
        <Form form={form} autoComplete="off" initialValues={{ remember: true }}>
          <TableHeader>
            <TableColumn>Questões</TableColumn>

            <TableColumn>
              <div>Estudantes</div>
              <span>
                <i className="fas fa-info-circle"></i>
                Veja o nome do aluno passando o mouse sobre o número.
              </span>
            </TableColumn>
          </TableHeader>

          <TableContainer
            bordered
            rowKey="id"
            columns={colunas}
            pagination={false}
            dataSource={novasPerguntas}
            locale={{ emptyText: "Sem dados" }}
            scroll={{ y: "calc(100vh - 200px)" }}
          />
        </Form>
      ) : (
        <div style={{ height: "calc(100vh - 290px)" }}>
          <Loader loading={carregandoAlunos} />
        </div>
      )}
    </>
  );
};

export default React.memo(QuestoesMatematicaAutoral);
