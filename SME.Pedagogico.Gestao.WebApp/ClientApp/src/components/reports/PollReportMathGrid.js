﻿import React, { Component } from "react";
import "./PollReportGrid.css";
import PollReportMathGridHeader from "./PollReportMathGridHeader";
import PollReportMathGridItem from "./PollReportMathGridItem";
import { actionCreators } from "../../store/PollReport";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
const PollReportGridTotal = (props) => {
  var { className } = props;

  if (className === undefined) className = "d-flex poll-report-grid-item";
  else className += " d-flex poll-report-grid-item";

  if (props.numbers !== true)
    return (
      <div className={className}>
        <div className="col-4 sc-gray">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">
            TOTAL
          </div>
        </div>
        <div className="col-3 sc-gray">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">
            {props.totalIdeaQuantity} Alunos
          </div>
        </div>
        <div className="col-1 sc-gray">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">
            {props.totalIdeaPercentage}%
          </div>
        </div>
        <div className="col-3 sc-gray">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">
            {props.totalResultQuantity} Alunos
          </div>
        </div>
        <div className="col-1 sc-gray">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">
            {props.totalResultPercentage}%
          </div>
        </div>
      </div>
    );
  else
    return (
      <div className={className}>
        <div className="col-4 sc-gray">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">
            TOTAL
          </div>
        </div>
        <div className="col-7 sc-gray">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">
            {props.totalQuantity} Alunos
          </div>
        </div>
        <div className="col-1 sc-gray">
          <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">
            {props.totalPercentage}%
          </div>
        </div>
      </div>
    );
};

class PollReportMathGrid extends Component {
  render() {
    var { className } = this.props;

    if (className === undefined) className = "d-flex flex-column";
    else className += " d-flex flex-column";

    var orders = 0;

    if (
      this.props.classroomReport &&
      this.props.data !== undefined &&
      this.props.data.length > 0
    )
      if (this.props.data[0].poll !== undefined)
        orders = this.props.data[0].poll.length;

    var { data } = this.props;

    data.totals = [];
    var indexes = [];

    if (this.props.classroomReport === false && data.ideaResults !== undefined)
      if (data.ideaResults.length > 0)
        for (var i = 0; i < data.ideaResults.length; i++) {
          indexes.push(i);
          data.totals.push({
            totalStudentIdeaQuantity:
              data.ideaResults[i].correctIdeaQuantity +
              data.ideaResults[i].incorrectIdeaQuantity +
              data.ideaResults[i].notAnsweredIdeaQuantity +
              data.ideaResults[i].semPreenchimento,
            totalStudentResultQuantity:
              data.resultResults[i].correctResultQuantity +
              data.resultResults[i].incorrectResultQuantity +
              data.resultResults[i].notAnsweredResultQuantity +
              data.resultResults[i].semPreenchimento,
          });
        }
      else if (
        data.numerosResults !== undefined &&
        data.numerosResults.length > 0
      )
        for (var j = 0; j < data.numerosResults.length; j++) indexes.push(j);

    var numberTest = false;

    if (this.props.classroomReport === true && data !== undefined)
      if (data !== undefined) {
        if (this.props.pollReport.selectedFilter.proficiency === "Números") {
          numberTest = true;
        }
      }
    return (
      <div className={className}>
        {this.props.classroomReport === false &&
          indexes.map((index) => {
            if (data.ideaResults.length > 0)
              return (
                <div key={data.ideaResults[index].orderName}>
                  <PollReportMathGridHeader
                    classroomReport={this.props.classroomReport}
                    orderName={data.ideaResults[index].orderName}
                    orderTitle={data.resultResults[index].orderTitle}
                  />
                  <PollReportMathGridItem
                    classroomReport={this.props.classroomReport}
                    testName="Acertou"
                    testIdeaQuantity={
                      data.ideaResults[index].correctIdeaQuantity
                    }
                    testIdeaPercentage={
                      data.ideaResults[index].correctIdeaPercentage
                    }
                    testResultQuantity={
                      data.resultResults[index].correctResultQuantity
                    }
                    testResultPercentage={
                      data.resultResults[index].correctResultPercentage
                    }
                  />
                  <PollReportMathGridItem
                    classroomReport={this.props.classroomReport}
                    testName="Errou"
                    testIdeaQuantity={
                      data.ideaResults[index].incorrectIdeaQuantity
                    }
                    testIdeaPercentage={
                      data.ideaResults[index].incorrectIdeaPercentage
                    }
                    testResultQuantity={
                      data.resultResults[index].incorrectResultQuantity
                    }
                    testResultPercentage={
                      data.resultResults[index].incorrectResultPercentage
                    }
                  />
                  <PollReportMathGridItem
                    classroomReport={this.props.classroomReport}
                    testName="Não resolveu"
                    testIdeaQuantity={
                      data.ideaResults[index].notAnsweredIdeaQuantity
                    }
                    testIdeaPercentage={
                      data.ideaResults[index].notAnsweredIdeaPercentage
                    }
                    testResultQuantity={
                      data.resultResults[index].notAnsweredResultQuantity
                    }
                    testResultPercentage={
                      data.resultResults[index].notAnsweredResultPercentage
                    }
                  />
                  <PollReportMathGridItem
                    classroomReport={this.props.classroomReport}
                    testName="Sem preenchimento"
                    testIdeaQuantity={data.ideaResults[index].semPreenchimento}
                    testIdeaPercentage={
                      data.ideaResults[index].semPreenchimentoPorcentagem
                    }
                    testResultQuantity={
                      data.resultResults[index].semPreenchimento
                    }
                    testResultPercentage={
                      data.resultResults[index].semPreenchimentoPorcentagem
                    }
                  />
                  <PollReportGridTotal
                    className="mb-4"
                    totalIdeaQuantity={
                      data.totals[index].totalStudentIdeaQuantity
                    }
                    totalIdeaPercentage={(100).toFixed(2)}
                    totalResultQuantity={
                      data.totals[index].totalStudentResultQuantity
                    }
                    totalResultPercentage={(100).toFixed(2)}
                  />
                </div>
              );
            else
              return (
                <div key={data.numerosResults[index].groupName}>
                  <PollReportMathGridHeader
                    classroomReport={this.props.classroomReport}
                    orderName={data.numerosResults[index].groupName}
                    numbers={true}
                  />
                  <PollReportMathGridItem
                    numbers={true}
                    classroomReport={this.props.classroomReport}
                    testName="Escreve convencionalmente"
                    testQuantity={
                      data.numerosResults[index]
                        .escreveConvencionalmenteResultado
                    }
                    testPercentage={
                      data.numerosResults[index]
                        .escreveConvencionalmentePercentage
                    }
                  />
                  <PollReportMathGridItem
                    numbers={true}
                    secondColor={true}
                    classroomReport={this.props.classroomReport}
                    testName="Não escreve convencionalmente"
                    testQuantity={
                      data.numerosResults[index]
                        .naoEscreveConvencionalmenteResultado
                    }
                    testPercentage={
                      data.numerosResults[index]
                        .naoEscreveConvencionalmentePercentage
                    }
                  />
                  <PollReportMathGridItem
                    numbers={true}
                    secondColor={true}
                    classroomReport={this.props.classroomReport}
                    testName="Sem Preenchimento"
                    testQuantity={
                      data.numerosResults[index].semPreenchimentoResultado
                    }
                    testPercentage={
                      data.numerosResults[index].semPreenchimentoPorcentagem
                    }
                  />
                  <PollReportGridTotal
                    className="mb-4"
                    numbers={true}
                    totalQuantity={data.numerosResults[index].totalDeAlunos}
                    totalPercentage={data.numerosResults[
                      index
                    ].totalPorcentagem.toFixed(2)}
                  />
                </div>
              );
          })}
        {this.props.data.length > 0 && this.props.data[0].poll !== undefined && (
          <div>
            <PollReportMathGridHeader
              classroomReport={this.props.classroomReport}
              orders={orders}
              numbers={numberTest}
              headers={data.length > 0 ? data[0].poll : []}
            />
            {Array.isArray(this.props.data) &&
              this.props.data.map((item) => (
                <PollReportMathGridItem
                  classroomReport={this.props.classroomReport}
                  item={item}
                  numbers={numberTest}
                />
              ))}
          </div>
        )}
      </div>
    );
  }
}

export default connect(
  (state) => ({ pollReport: state.pollReport }),
  (dispatch) => bindActionCreators(actionCreators, dispatch)
)(PollReportMathGrid);
