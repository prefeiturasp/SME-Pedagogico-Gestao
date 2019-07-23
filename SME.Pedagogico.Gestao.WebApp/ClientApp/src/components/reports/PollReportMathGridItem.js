import React, { Component } from 'react';

const PollReportGridItem1 = (props) => {
    return (
        <div className="col sc-lightpurple border-left border-white">
            <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center text-white font-weight-light">{props.idea}</div>
        </div>
    );
}

const PollReportGridItem2 = (props) => {
    return (
        <div className="col sc-darkblue border-left border-white">
            <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center text-white font-weight-light">{props.result}</div>
        </div>
    );
}

export default class PollReportMathGridItem extends Component {
    render() {

        if (this.props.classroomReport === true) {
            if (this.props.numbers === false) {
                const { item } = this.props;
              if(item !== undefined && item.poll !== undefined) {
                return (
                    <div className="d-flex poll-report-grid-item border-bottom">
                        <div className="col-1">
                            <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">{item.code}</div>
                        </div>
                        <div className="col-3">
                            <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">{item.studentName}</div>
                        </div>
                        {item.poll.map(gridItem =>
                            [<PollReportGridItem1 idea={gridItem.idea} />, <PollReportGridItem2 result={gridItem.result} />]
                        )}
                    </div>
                );
            }
        }
            else {
                const { item } = this.props;

                return (
                    <div className="d-flex poll-report-grid-item border-bottom">
                        <div className="col-1">
                            <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">{item.code}</div>
                        </div>
                        <div className="col-3">
                            <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">{item.studentName}</div>
                        </div>
                        {item.poll.map(gridItem => {
                            if (gridItem.result === "Escreve convencionalmente")
                                return (
                                    <div className="col sc-lightpurple border-left border-white">
                                        <div className="sc-text-size-000 d-flex flex-fill h-100 align-items-center justify-content-center text-white font-weight-light">{gridItem.result}</div>
                                    </div>
                                );
                            else
                                return (
                                    <div className="col sc-darkblue border-left border-white">
                                        <div className="sc-text-size-000 d-flex flex-fill h-100 align-items-center justify-content-center text-white font-weight-light">{gridItem.result}</div>
                                    </div>
                                );
                        })}
                    </div>
                );
            }
        }
        else {
            if (this.props.numbers !== true)
                return (
                    <div className="d-flex poll-report-grid-item border-bottom">
                        <div className="col-4">
                            <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">{this.props.testName}</div>
                        </div>
                        <div className="col-3 sc-lightpurple  border-right border-white">
                            <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center text-white font-weight-light">{this.props.testIdeaQuantity} Alunos</div>
                        </div>
                        <div className="col-1 sc-darkgray border-right border-white">
                            <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center text-white font-weight-light">{ this.props.testIdeaPercentage && this.props.testIdeaPercentage.toFixed(2)}%</div>
                        </div>
                        <div className="col-3 sc-darkblue  border-right border-white">
                            <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center text-white font-weight-light">{this.props.testResultQuantity} Alunos</div>
                        </div>
                        <div className="col-1 sc-darkgray border-right border-white">
                            <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center text-white font-weight-light">{this.props.testIdeaPercentage &&  this.props.testResultPercentage.toFixed(2)}%</div>
                        </div>
                    </div>
                );
            else
                return (
                    <div className="d-flex poll-report-grid-item border-bottom">
                        <div className="col-4">
                            <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">{this.props.testName}</div>
                        </div>
                        <div className={this.props.secondColor ? "col-7 sc-darkblue border-right border-white" : "col-7 sc-lightpurple border-right border-white"}>
                            <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center text-white font-weight-light">{this.props.testQuantity} Alunos</div>
                        </div>
                        <div className={this.props.secondColor ? "col-1 sc-darkblue border-right border-white" : "col-1 sc-lightpurple border-right border-white"}>
                            <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center text-white font-weight-light">{this.props.testPercentage.toFixed(2)}%</div>
                        </div>
                    </div>
                );
        }
    }
}