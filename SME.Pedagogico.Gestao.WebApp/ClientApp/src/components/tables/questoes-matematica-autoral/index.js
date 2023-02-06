import { Checkbox, Tooltip } from "antd";
import React, { useEffect } from "react";
import { useMemo } from "react";
import { useDispatch, useSelector } from "react-redux";
import { actionCreators } from "../../../store/SondagemAutoral";
import {
  NumeroChamadaTexto,
  RowTableContainer,
  TableContainer,
  Title,
} from "./styles";

const QuestoesMatematicaAutoral = () => {
  const dispatch = useDispatch();

  const bimestre = useSelector((store) => store.poll.bimestre);
  const filtros = useSelector((store) => store.poll.selectedFilter);
  const perguntas = useSelector((store) => store.autoral.listaPerguntas);
  const tipoSondagem = useSelector((store) => store.poll.pollTypeSelected);

  const alunos = useSelector(
    (store) => store.autoral.listaAlunosAutoralMatematica
  );

  const filtrosBusca = useMemo(() => {
    if (!filtros) return;

    return {
      anoLetivo: filtros.schoolYear,
      anoEscolar: filtros.yearClassroom,
      codigoDre: filtros.dreCodeEol,
      codigoUe: filtros.schoolCodeEol,
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
      !filtrosBusca ||
      !filtrosBusca.anoLetivo ||
      !filtrosBusca.anoEscolar ||
      !bimestre
    )
      return;

    dispatch(
      actionCreators.listaAlunosAutoralMatematica(filtrosBusca, bimestre)
    );
  }, [bimestre, dispatch, filtrosBusca]);

  const montarLinhas = (_, resposta) => {
    const columnsQuestoes = [
      {
        width: 500,
        fixed: "left",
        title: resposta?.descricao,
        dataIndex: "descricao",
      },
    ];

    alunos.forEach((aluno) => {
      const colunaAluno = {
        width: 54,
        align: "center",
        title: (
          <Tooltip title={aluno?.nomeAluno} placement="bottomRight">
            <NumeroChamadaTexto>{aluno?.numeroChamada}</NumeroChamadaTexto>
          </Tooltip>
        ),
        render: (resposta) =>
          // <Checkbox
          //   onChange={() => {
          //     console.log(aluno);
          //     console.log(resposta);
          //   }}
          // />
          "-",
      };

      columnsQuestoes.push(colunaAluno);
    });

    const respostas = resposta?.respostas?.length ? resposta.respostas : [];

    return (
      <RowTableContainer
        bordered
        pagination={false}
        scroll={{ x: "100%" }}
        dataSource={respostas}
        columns={columnsQuestoes}
      />
    );
  };

  const columns = useMemo(
    () => [
      {
        width: 500,
        key: "questoes",
        align: "center",
        title: <Title>Questões</Title>,
        render: montarLinhas,
        onCell: (_) => ({
          colSpan: 2,
        }),
      },
      {
        title: (
          <Title className="flex">
            <div>Estudantes</div>
            <span>
              <i className="fas fa-info-circle"></i>
              Veja o nome do aluno passando o mouse sobre o número.
            </span>
          </Title>
        ),
        onCell: () => ({
          colSpan: 0,
        }),
      },
    ],
    [alunos]
  );

  return (
    <TableContainer
      bordered
      columns={columns}
      pagination={false}
      dataSource={perguntas}
      scroll={{ y: "450px" }}
      locale={{ emptyText: "Sem dados" }}
    />
  );
};

export default QuestoesMatematicaAutoral;
