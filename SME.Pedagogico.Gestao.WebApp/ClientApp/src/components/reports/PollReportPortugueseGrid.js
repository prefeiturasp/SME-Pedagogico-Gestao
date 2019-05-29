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
                    <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center text-white font-weight-light">{props.studentPercentage.toFixed(2)}%</div>
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
                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-light">{props.studentPercentage.toFixed(2)}%</div>
            </div>
        </div>
    );
}

export default class PollReportPortugueseGrid extends Component {    
    render() {
        var { className } = this.props;

        if (className === undefined)
            className = "d-flex flex-column";
        else
            className += " d-flex flex-column";

        var totalStudents = 0;
        var totalPercentage = 0;

        if (this.props.classroomReport === false)
            for (var key in this.props.data) {
                totalStudents += this.props.data[key].studentQuantity;
                totalPercentage += this.props.data[key].studentPercentage;
            }

        return (
            <div className={className}>
                <PollReportGridHeader classroomReport={this.props.classroomReport} />

                {this.props.data.map(item =>
                    <PollReportGridItem {...item} classroomReport={this.props.classroomReport} />
                )}

                {this.props.classroomReport === false &&
                    <PollReportGridTotal studentQuantity={totalStudents} studentPercentage={totalPercentage}/>
                }
            </div>
        );
    }
}