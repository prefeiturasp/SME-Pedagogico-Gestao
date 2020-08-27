import React from "react";

// import { Container } from './styles';

function SondagemAutoral({periodos}) {
  return (
    <div>
      <div id="wrapper">
        <SondagemClassSelected />
      </div>
      <table
        className="table table-sm table-bordered table-hover table-sondagem-matematica"
        style={{ overflow: "hidden", overflowX: "auto" }}
      >
        <thead>
          <tr>{perguntas.map(pergunta => {

          })}</tr>
          <tr>
            <th className="text-center border poll-select-container familiares_col">
              <small className="text-muted">1º Semestre</small>
            </th>
            <th className="text-center border poll-select-container familiares_col">
              <small className="text-muted">2º Semestre</small>
            </th>
          </tr>
        </thead>

        <tbody>
          {this.props.students.map((student) => (
            <StudentPollMathAlfabetizacao
              key={student.studentCodeEol}
              student={student}
              updatePollStudent={this.props.updatePollStudent}
              editLock1S={this.props.editLock1S}
              editLock2S={this.props.editLock2S}
            />
          ))}
        </tbody>
      </table>
      <LegendsYesNo />
    </div>
  );
}

export default SondagemAutoral;

var perguntas = [
  {
    id: "d53ba946-fb3d-4b20-8883-0f7dbab3bddb",
    descricao: "Problema de lógica",
    ordenacao: 1,
    respostas: [
      {
        id: "bc66297b-3f3a-4d8d-b6c4-ceea1696bc11",
        descricao: "Resolveu corretamente",
        ordenacao: 1,
      },
      {
        id: "04695943-0abf-4dd7-b8b8-9e850f5d8d2e",
        descricao: "Resolveu uma parte do problema corretamente",
        ordenacao: 2,
      },
      {
        id: "53911083-6799-4553-8e5e-3eaadec17a55",
        descricao: "Resolveu o problema incorretamente",
        ordenacao: 3,
      },
      {
        id: "a04c7a11-52d7-4fbc-9115-2df00eda1ad2",
        descricao: "Não registrou",
        ordenacao: 4,
      },
    ],
  },
  {
    id: "9d60c205-9a55-4f17-9254-b1d760d172fd",
    descricao: "Área e perímetro ",
    ordenacao: 2,
    respostas: [
      {
        id: "bc66297b-3f3a-4d8d-b6c4-ceea1696bc11",
        descricao: "Resolveu corretamente",
        ordenacao: 1,
      },
      {
        id: "aae9c109-bdb5-4391-b513-e5fd68d39d5a",
        descricao:
          "Compreende o que é área, mas não compreende o que é perímetro",
        ordenacao: 2,
      },
      {
        id: "ffa53f05-b71e-4ef8-9b10-7c932ca681db",
        descricao:
          "Compreende o que é perímetro, mas não compreende o que é área",
        ordenacao: 3,
      },
      {
        id: "a04c7a11-52d7-4fbc-9115-2df00eda1ad2",
        descricao: "Não registrou",
        ordenacao: 4,
      },
    ],
  },
  {
    id: "13eb098b-c9a6-46c5-b5cb-f4549cef94f0",
    descricao: "Sólidos geométricos",
    ordenacao: 3,
    respostas: [
      {
        id: "bc66297b-3f3a-4d8d-b6c4-ceea1696bc11",
        descricao: "Resolveu corretamente",
        ordenacao: 1,
      },
      {
        id: "7abb0305-441f-4d40-baea-4cc3f13a1a50",
        descricao:
          "Identificou os nomes das figuras e não determinou elementos de poliedros corretamente",
        ordenacao: 2,
      },
      {
        id: "0218ff47-5565-426c-8d12-07090a1b4ec9",
        descricao:
          "Não identificou nomes de figuras e não determinou elementos de poliedros corretamente",
        ordenacao: 3,
      },
      {
        id: "a04c7a11-52d7-4fbc-9115-2df00eda1ad2",
        descricao: "Não registrou",
        ordenacao: 4,
      },
    ],
  },
  {
    id: "21d6ae6b-f41e-4712-b71f-02cfc709e973",
    descricao: "Relações entre grandezas e porcentagem",
    ordenacao: 4,
    respostas: [
      {
        id: "bc66297b-3f3a-4d8d-b6c4-ceea1696bc11",
        descricao: "Resolveu corretamente",
        ordenacao: 1,
      },
      {
        id: "80d96e10-6be4-4ba4-8a84-4a7135e09b59",
        descricao:
          "Identificou corretamente a proporcionalidade e indicou a porcentagem corretamente, mas errou os cálculos",
        ordenacao: 2,
      },
      {
        id: "91c73b09-4ae9-4305-92bd-efa68ed9a4db",
        descricao:
          "Não identificou corretamente a proporcionalidade e indicou incorretamente a porcentagem",
        ordenacao: 3,
      },
      {
        id: "a04c7a11-52d7-4fbc-9115-2df00eda1ad2",
        descricao: "Não registrou",
        ordenacao: 4,
      },
    ],
  },
  {
    id: "ef810828-770d-4fa4-bde2-31f31fb48337",
    descricao: "Média, moda e mediana",
    ordenacao: 5,
    respostas: [
      {
        id: "bc66297b-3f3a-4d8d-b6c4-ceea1696bc11",
        descricao: "Resolveu corretamente",
        ordenacao: 1,
      },
      {
        id: "22cbd4e4-582f-46c4-a2ee-ff4f387453bc",
        descricao:
          "Identificou corretamente as três medidas de tendência central, mas erros os cálculos",
        ordenacao: 2,
      },
      {
        id: "56da5097-d043-475e-a083-edcec0a94fdc",
        descricao: "Não identificou uma ou mais medidas de tendência central",
        ordenacao: 3,
      },
      {
        id: "a04c7a11-52d7-4fbc-9115-2df00eda1ad2",
        descricao: "Não registrou",
        ordenacao: 4,
      },
    ],
  },
];