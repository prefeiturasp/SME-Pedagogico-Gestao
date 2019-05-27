import React, { Component } from 'react';
import './PollReportGrid.css';

const PollReportGridHeader = (props) => {
    if (props.classroomReport === true)
        return (
            <div className="d-flex poll-report-grid-header">
                <div className="col sc-gray">
                    <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center">#</div>
                </div>
                <div className="col-11 sc-gray border-right border-white">
                    <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center">Alunos</div>
                </div>
            </div>
        );
    else
        return (
            <div className="d-flex poll-report-grid-header">
                <div className="col sc-gray border-right border-white">
                    <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center">Proficiência</div>
                </div>
                <div className="col-7 sc-gray border-right border-right border-white">
                    <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center">Alunos</div>
                </div>
                <div className="col-1 sc-gray border-right border-white">
                    <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center">%</div>
                </div>
            </div>
        );
};

const PollReportGridItem = (props) => {
    if (props.classroomReport === true)
        return (
            <div className="d-flex poll-report-grid-item border-bottom">
                <div className="col">
                    <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">{props.code}</div>
                </div>
                <div className="col-5">
                    <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">{props.studentName}</div>
                </div>
                <div className="col-6 sc-darkblue border-right border-white">
                    <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center text-white font-weight-light">{props.studentValue}</div>
                </div>
            </div>
        );
    else
        return (
            <div className="d-flex poll-report-grid-item border-bottom">
                <div className="col">
                    <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">{props.optionName}</div>
                </div>
                <div className="col-7 sc-darkblue border-right border-white">
                    <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center text-white font-weight-light">{props.studentQuantity} Alunos</div>
                </div>
                <div className="col-1 sc-darkblue border-right border-white">
                    <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center text-white font-weight-light">{props.studentPercentage}%</div>
                </div>
            </div>
        );
};

const PollReportGridTotal = (props) => {
    return (
        <div className="d-flex poll-report-grid-item">
            <div className="col sc-gray">
                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-light">TOTAL</div>
            </div>
            <div className="col-7 sc-gray">
                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">{props.studentQuantity} Alunos</div>
            </div>
            <div className="col-1 sc-gray">
                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">{props.studentPercentage}%</div>
            </div>
        </div>
    );
}

export default class PollReportPortugueseGrid extends Component {
    constructor() {
        super();

        this.pollReportItems = [
            { optionName: "Pré-Silábico", studentQuantity: "60", studentPercentage: "35,71" },
            { optionName: "Silábico sem Valor", studentQuantity: "30", studentPercentage: "17,86" },
            { optionName: "Silábico com Valor", studentQuantity: "45", studentPercentage: "26,78" },
            { optionName: "Silábico Alfabético", studentQuantity: "23", studentPercentage: "13,69" },
            { optionName: "Alfabético", studentQuantity: "10", studentPercentage: "5,95" },
        ];
        this.pollReportClassroom = [
            { code: "1", studentName: "Alvaro Ramos Grassi", studentValue: "Pré-Silábico" },
            { code: "2", studentName: "Amanda Aparecida", studentValue: "Pré-Silábico" },
            { code: "3", studentName: "Anna Beatriz de Goes Callejon", studentValue: "Silábico Alfabético" },
            { code: "4", studentName: "Caique Siqueira", studentValue: "Alfabético" },
        ];
    }
    
    render() {
        var { className } = this.props;

        if (className === undefined)
            className = "d-flex flex-column";
        else
            className += " d-flex flex-column";

        //======================= Seed //=======================
        var reportItems = [];

        if (this.props.classroomReport === false)
            reportItems = this.pollReportItems;
        else
            reportItems = this.pollReportClassroom;
        //======================================================

        return (
            <div className={className}>
                <PollReportGridHeader classroomReport={this.props.classroomReport} />

                {reportItems.map(item =>
                    <PollReportGridItem {...item} classroomReport={this.props.classroomReport} />
                )}

                {this.props.classroomReport === false &&
                    <PollReportGridTotal studentQuantity="168" studentPercentage="100"/>
                }
            </div>
        );
    }
}