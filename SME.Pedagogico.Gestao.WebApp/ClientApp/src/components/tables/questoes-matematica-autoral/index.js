import React, { useEffect } from "react";
import { useMemo } from "react";
import { useDispatch, useSelector } from "react-redux";
import { actionCreators } from "../../../store/SondagemAutoral";
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
import { Button, Form } from "antd";

const QuestoesMatematicaAutoral = () => {
  const dispatch = useDispatch();

  const bimestre = useSelector((store) => store.poll.bimestre);
  const filtros = useSelector((store) => store.poll.selectedFilter);
  const perguntas = useSelector((store) => store.autoral.listaPerguntas);
  const tipoSondagem = useSelector((store) => store.poll.pollTypeSelected);
  const carregandoAlunos = useSelector((store) => store.poll.carregandoAlunos);

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
    }
  }, [bimestre, dispatch, filtros, filtros.yearClassroom, tipoSondagem]);

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

  const dynamicColumns = alunos.map((aluno) => ({
    width: 54,
    align: "center",
    key: shortid.generate(),
    render: (dadosLinha) => (
      <LinhaAluno
        aluno={aluno}
        dadosLinha={dadosLinha}
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
        autoComplete="off"
        onFinish={onFinish}
        initialValues={{ remember: true }}
        >
          <>
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
          </>

          <Form.Item wrapperCol={{ offset: 8, span: 16 }}>
            <Button type="primary" htmlType="submit">
              Submit
            </Button>
          </Form.Item>
        </Form>
      ) : (
        <div style={{ height: "calc(100vh - 290px)" }}>
          <Loader loading={carregandoAlunos}></Loader>
        </div>
      )}
    </>
  );
};

export default QuestoesMatematicaAutoral;
