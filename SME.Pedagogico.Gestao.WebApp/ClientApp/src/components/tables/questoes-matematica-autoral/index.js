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
    console.log("ALUNOS", alunosMutaveis);
    console.log("VALORES DO FORM", novosValores);
    debugger;

    Object.entries(novosValores).forEach(entry => {
      const [key, value] = entry;

      if (value) {
        const [perguntaId, codigoAluno] = key.split("|");
        const dadosAluno = alunosMutaveis?.filter(
          (i) => i.codigoAluno === codigoAluno
        );

        if (dadosAluno.length && dadosAluno.respostas.length) {
          const alunoJaTemRespostaParaPergunta = dadosAluno.respostas.findIndex(
            (i) => i.pergunta === perguntaId
          );

          if (alunoJaTemRespostaParaPergunta > -1) {
            dadosAluno.respostas[alunoJaTemRespostaParaPergunta].resposta =
              value;
          } else {
            const novaResposta = {
              bimestre: 1,
              pergunta: perguntaId,
              periodoId: "",
              resposta: value,
            };

            dadosAluno.respostas.push(novaResposta);
          }
        } else if (dadosAluno.length) {
          const novaResposta = {
            bimestre: 1,
            pergunta: perguntaId,
            periodoId: "",
            resposta: value,
          };

          dadosAluno.respostas.push(novaResposta);
        }
      }
    });

    // TODO Atualizar alunosMutaveis com os valores que estão no form para salvar os alunos
    return alunosMutaveis;
  };

  const persistencia = useCallback(
    async (listaAlunosRedux) => {
      debugger;
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

  const onChangeAluno = () => {
    setarModoEdicao();
  };

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

  const dynamicColumns = alunos.map((aluno) => ({
    width: 54,
    align: "center",
    key: shortid.generate(),
    render: (dadosLinha) => (
      <LinhaAluno
        aluno={aluno}
        dadosLinha={dadosLinha}
        onChange={onChangeAluno}
      />
    ),
  }));

  const colunas = [...columns, ...dynamicColumns];

  const onFinish = (values) => {
    console.log("Success:", values);
  };

  return (
    <>
      {alunos && !!alunos.length ? (
        <Form
          form={form}
          autoComplete="off"
          onFinish={onFinish}
          initialValues={{ remember: true }}
        >
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
          <Loader loading={carregandoAlunos}></Loader>
        </div>
      )}
    </>
  );
};

export default React.memo(QuestoesMatematicaAutoral);
