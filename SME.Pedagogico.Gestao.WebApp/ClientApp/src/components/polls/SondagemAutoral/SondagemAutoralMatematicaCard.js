import React from "react";

// import { Container } from './styles';

function SondagemAutoral({periodos, perguntas}) {
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
