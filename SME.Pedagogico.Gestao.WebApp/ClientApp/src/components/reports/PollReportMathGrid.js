import React, { Component } from 'react';
import './PollReportGrid.css';
import PollReportMathGridHeader from './PollReportMathGridHeader';
import PollReportMathGridItem from './PollReportMathGridItem';

const PollReportGridTotal = (props) => {
    var { className } = props;

    if (className === undefined)
        className = "d-flex poll-report-grid-item";
    else
        className += " d-flex poll-report-grid-item";

    if (props.numbers !== true)
        return (
            <div className={className}>
                <div className="col-4 sc-gray">
                    <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">TOTAL</div>
                </div>
                <div className="col-3 sc-gray">
                    <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">{props.totalIdeaQuantity} Alunos</div>
                </div>
                <div className="col-1 sc-gray">
                    <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">{props.totalIdeaPercentage}%</div>
                </div>
                <div className="col-3 sc-gray">
                    <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">{props.totalResultQuantity} Alunos</div>
                </div>
                <div className="col-1 sc-gray">
                    <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">{props.totalResultPercentage}%</div>
                </div>
            </div>
        );
    else
        return (
            <div className={className}>
                <div className="col-4 sc-gray">
                    <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">TOTAL</div>
                </div>
                <div className="col-7 sc-gray">
                    <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">{props.totalQuantity} Alunos</div>
                </div>
                <div className="col-1 sc-gray">
                    <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">{props.totalPercentage}%</div>
                </div>
            </div>
        );
}

export default class PollReportMathGrid extends Component {
    render() {
        var { className } = this.props;

        if (className === undefined)
            className = "d-flex flex-column";
        else
            className += " d-flex flex-column";

        var orders = 0;

        if (this.props.classroomReport && this.props.data !== undefined)
            if (this.props.data[0].poll !== undefined)
                orders = this.props.data[0].poll.length

        var data = this.props.data;
        data.totals = [];
        var indexes = [];

        if (data.ideaResults.length > 0)
            for (var i = 0; i < data.ideaResults.length; i++) {
                indexes.push(i);
                data.totals.push({
                    totalStudentIdeaQuantity: data.ideaResults[i].correctIdeaQuantity + data.ideaResults[i].incorrectIdeaQuantity + data.ideaResults[i].notAnsweredIdeaQuantity,
                    totalStudentIdeaPercentage: data.ideaResults[i].correctIdeaPercentage + data.ideaResults[i].incorrectIdeaPercentage + data.ideaResults[i].notAnsweredIdeaPercentage,
                    totalStudentResultQuantity: data.resultResults[i].correctResultQuantity + data.resultResults[i].incorrectResultQuantity + data.resultResults[i].notAnsweredResultQuantity,
                    totalStudentResultPercentage: data.resultResults[i].correctResultPercentage + data.resultResults[i].incorrectResultPercentage + data.resultResults[i].notAnsweredResultPercentage,
                });
            }
        else
            for (var j = 0; j < data.numerosResults.length; j++)
                indexes.push(j);

        return (
            <div className={className}>
                {this.props.classroomReport === false ?
                    indexes.map(index => {
                        if (data.ideaResults.length > 0)
                            return (
                                <div key={data.ideaResults[index].orderName}>
                                    <PollReportMathGridHeader classroomReport={this.props.classroomReport} orderName={data.ideaResults[index].orderName} />
                                    <PollReportMathGridItem
                                        classroomReport={this.props.classroomReport}
                                        testName="Acertou"
                                        testIdeaQuantity={data.ideaResults[index].correctIdeaQuantity}
                                        testIdeaPercentage={data.ideaResults[index].correctIdeaPercentage}
                                        testResultQuantity={data.resultResults[index].correctResultQuantity}
                                        testResultPercentage={data.resultResults[index].correctResultPercentage} />
                                    <PollReportMathGridItem
                                        classroomReport={this.props.classroomReport}
                                        testName="Errou"
                                        testIdeaQuantity={data.ideaResults[index].incorrectIdeaQuantity}
                                        testIdeaPercentage={data.ideaResults[index].incorrectIdeaPercentage}
                                        testResultQuantity={data.resultResults[index].incorrectResultQuantity}
                                        testResultPercentage={data.resultResults[index].incorrectResultPercentage} />
                                    <PollReportMathGridItem
                                        classroomReport={this.props.classroomReport}
                                        testName="Não Resolveu"
                                        testIdeaQuantity={data.ideaResults[index].notAnsweredIdeaQuantity}
                                        testIdeaPercentage={data.ideaResults[index].notAnsweredIdeaPercentage}
                                        testResultQuantity={data.resultResults[index].notAnsweredResultQuantity}
                                        testResultPercentage={data.resultResults[index].notAnsweredResultPercentage} />
                                    <PollReportGridTotal className="mb-4"
                                        totalIdeaQuantity={data.totals[index].totalStudentIdeaQuantity}
                                        totalIdeaPercentage={data.totals[index].totalStudentIdeaPercentage.toFixed(2)}
                                        totalResultQuantity={data.totals[index].totalStudentResultQuantity}
                                        totalResultPercentage={data.totals[index].totalStudentResultPercentage.toFixed(2)} />
                                </div>
                            );
                        else
                            return (
                                <div key={data.numerosResults[index].groupName}>
                                    <PollReportMathGridHeader classroomReport={this.props.classroomReport} orderName={data.numerosResults[index].groupName} numbers={true} />
                                    <PollReportMathGridItem
                                        numbers={true}
                                        classroomReport={this.props.classroomReport}
                                        testName={data.numerosResults[index].escreveConvencionalmenteText}
                                        testQuantity={data.numerosResults[index].escreveConvencionalmenteResultado}
                                        testPercentage={data.numerosResults[index].escreveConvencionalmentePercentage}
                                    />
                                    <PollReportMathGridItem
                                        numbers={true}
                                        secondColor={true}
                                        classroomReport={this.props.classroomReport}
                                        testName={"Não " + data.numerosResults[index].escreveConvencionalmenteText.toLowerCase()}
                                        testQuantity={data.numerosResults[index].naoEscreveConvencionalmenteResultado}
                                        testPercentage={data.numerosResults[index].naoEscreveConvencionalmentePercentage}
                                    />
                                    <PollReportGridTotal className="mb-4"
                                        numbers={true}
                                        totalQuantity={data.numerosResults[index].escreveConvencionalmenteResultado + data.numerosResults[index].naoEscreveConvencionalmenteResultado}
                                        totalPercentage={(data.numerosResults[index].escreveConvencionalmentePercentage + data.numerosResults[index].naoEscreveConvencionalmentePercentage).toFixed(2)}
                                    />
                                </div>
                            );
                    })
                    :
                    <div>
                        <PollReportMathGridHeader classroomReport={this.props.classroomReport} orders={orders} />
                        {this.props.data.map(item =>
                            <PollReportMathGridItem classroomReport={this.props.classroomReport} item={item}/> 
                        )}
                    </div>
                }
            </div>
        );
    }
}