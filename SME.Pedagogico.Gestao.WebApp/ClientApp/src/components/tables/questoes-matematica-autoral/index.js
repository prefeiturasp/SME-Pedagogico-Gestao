import { Checkbox, Tooltip } from "antd";
import React from "react";
import { RowTableContainer, TableContainer, Title } from "./styles";

const QuestoesMatematicaAutoral = () => {
  const alunos = [
    {
      id: 1,
      nomeAluno: "ANA CAROLINA",
      numeroChamada: "1",
    },
    {
      id: 2,
      nomeAluno: "CAIQUE DOS SANTOS",
      numeroChamada: "2",
    },
  ];

  const questoes = [
    {
      id: 123,
      descricao: "Questão 1: Resolver problemas do Eixo Números",
      respostas: [
        { id: 1, descricao: "Acertou a questão" },
        { id: 2, descricao: "Acertou parcialmente a questão" },
        { id: 3, descricao: "Errou a questão" },
      ],
    },
  ];

  const montarLinhasRespostas = (_, questao) => {
    const columnsQuestoes = [
      {
        title: questao?.descricao,
        dataIndex: "descricao",
      },
    ];
    const respostas = questao?.respostas?.length ? questao.respostas : [];

    return (
      <RowTableContainer
        pagination={false}
        columns={columnsQuestoes}
        dataSource={respostas}
      />
    );
  };

  const montarLinhasEstudantes = (_, questao) => {
    const columnsAlunos = [];

    alunos.forEach((aluno) => {
      const colunaAluno = {
        title: (
          <Tooltip title={aluno?.nomeAluno}>{aluno?.numeroChamada}</Tooltip>
        ),
        render: (resposta) => (
          <Checkbox
            onChange={() => {
              console.log(aluno);
              console.log(resposta);
            }}
          />
        ),
      };

      columnsAlunos.push(colunaAluno);
    });

    const respostas = questao?.respostas?.length ? questao.respostas : [];

    return (
      <RowTableContainer
        pagination={false}
        columns={columnsAlunos}
        dataSource={respostas}
      />
    );
  };

  const columns = [
    {
      width: 500,
      fixed: "left",
      align: "center",
      key: "questoes",
      title: "Questões",
      render: montarLinhasRespostas,
    },
    {
      title: (
        <Title>
          <div>Estudantes</div>
          <span>Veja o nome do aluno passando o mouse sobre o número.</span>
        </Title>
      ),
      render: montarLinhasEstudantes,
      key: "estudantes",
    },
  ];

  return (
    <TableContainer
      bordered
      columns={columns}
      pagination={false}
      dataSource={questoes}
      scroll={{ x: "100%" }}
    />
  );
};

export default QuestoesMatematicaAutoral;
