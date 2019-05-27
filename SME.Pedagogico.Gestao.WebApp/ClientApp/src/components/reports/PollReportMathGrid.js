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
}

export default class PollReportMathGrid extends Component {
    constructor() {
        super();

        this.pollReportItems = [
            {
                orderName: "ORDEM 1",
                results: [
                    { testName: "Acertou", testIdeaQuantity: 60, testIdeaPercentage: 60, testResultQuantity: 60, testResultPercentage: 60 },
                    { testName: "Errou", testIdeaQuantity: 30, testIdeaPercentage: 30, testResultQuantity: 30, testResultPercentage: 30 },
                    { testName: "Não Resolveu", testIdeaQuantity: 45, testIdeaPercentage: 45, testResultQuantity: 45, testResultPercentage: 45 },
                ]
            },
            {
                orderName: "ORDEM 2",
                results: [
                    { testName: "Acertou", testIdeaQuantity: 60, testIdeaPercentage: 60, testResultQuantity: 60, testResultPercentage: 60 },
                    { testName: "Errou", testIdeaQuantity: 30, testIdeaPercentage: 30, testResultQuantity: 30, testResultPercentage: 30 },
                    { testName: "Não Resolveu", testIdeaQuantity: 45, testIdeaPercentage: 45, testResultQuantity: 45, testResultPercentage: 45 },
                ]
            },
            {
                orderName: "ORDEM 3",
                results: [
                    { testName: "Acertou", testIdeaQuantity: 60, testIdeaPercentage: 60, testResultQuantity: 60, testResultPercentage: 60 },
                    { testName: "Errou", testIdeaQuantity: 30, testIdeaPercentage: 30, testResultQuantity: 30, testResultPercentage: 30 },
                    { testName: "Não Resolveu", testIdeaQuantity: 45, testIdeaPercentage: 45, testResultQuantity: 45, testResultPercentage: 45 },
                ]
            },
            {
                orderName: "ORDEM 4",
                results: [
                    { testName: "Acertou", testIdeaQuantity: 60, testIdeaPercentage: 60, testResultQuantity: 60, testResultPercentage: 60 },
                    { testName: "Errou", testIdeaQuantity: 30, testIdeaPercentage: 30, testResultQuantity: 30, testResultPercentage: 30 },
                    { testName: "Não Resolveu", testIdeaQuantity: 45, testIdeaPercentage: 45, testResultQuantity: 45, testResultPercentage: 45 },
                ]
            },
        ];

        this.pollReportClassroom = [
            {
                code: "1", studentName: "Alvaro Ramos Grassi", poll: [
                    { order: 1, idea: "Acertou", result: "Errou" },
                    { order: 2, idea: "Acertou", result: "Errou" },
                    { order: 3, idea: "Acertou", result: "Errou" },
                    { order: 4, idea: "Acertou", result: "Errou" },
                ]
            },
            { code: "2", studentName: "Amanda Aparecida", poll: [
                    { order: 1, idea: "Errou", result: "Não Resolveu" },
                    { order: 1, idea: "Errou", result: "Não Resolveu" },
                    { order: 1, idea: "Errou", result: "Não Resolveu" },
                    { order: 4, idea: "Acertou", result: "Errou" },
                ]
            },
            {
                code: "3", studentName: "Anna Beatriz de Goes Callejon", poll: [
                    { order: 1, idea: "Acertou", result: "Acertou" },
                    { order: 2, idea: "Acertou", result: "Acertou" },
                    { order: 3, idea: "Acertou", result: "Acertou" },
                    { order: 4, idea: "Acertou", result: "Errou" },
                ]
            },
            {
                code: "4", studentName: "Caique Siqueira", poll: [
                    { order: 1, idea: "Acertou", result: "Errou" },
                    { order: 2, idea: "Acertou", result: "Errou" },
                    { order: 3, idea: "Acertou", result: "Errou" },
                    { order: 4, idea: "Acertou", result: "Errou" },
                ]
            },
        ];
    }

    render() {
        var { className } = this.props;

        if (className === undefined)
            className = "d-flex flex-column";
        else
            className += " d-flex flex-column";

        //======================= Seed =======================
        var reportItems = [];

        if (this.props.classroomReport === false)
            reportItems = this.pollReportItems;
        else
            reportItems = this.pollReportClassroom;

        var orders = this.pollReportClassroom[0].poll.length;
        //======================================================

        return (
            <div className={className}>
                {this.props.classroomReport === false ?
                    reportItems.map(item => {
                        return (
                            <div key={item.orderName}>
                                <PollReportMathGridHeader classroomReport={this.props.classroomReport} orderName={item.orderName} />

                                {item.results.map(result =>
                                    <PollReportMathGridItem {...result} />
                                )}

                                <PollReportGridTotal className="mb-4" totalIdeaQuantity="84" totalIdeaPercentage="100" totalResultQuantity="84" totalResultPercentage="100" />
                            </div>
                        );
                    })
                    :
                    <div>
                        <PollReportMathGridHeader classroomReport={this.props.classroomReport} orders={orders} />
                        {reportItems.map(item =>
                            <PollReportMathGridItem classroomReport={this.props.classroomReport} item={item}/>
                        )}
                    </div>
                }
            </div>
        );
    }
}