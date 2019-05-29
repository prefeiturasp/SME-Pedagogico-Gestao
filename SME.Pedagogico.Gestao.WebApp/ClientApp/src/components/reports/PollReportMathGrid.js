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
    render() {
        var { className } = this.props;

        if (className === undefined)
            className = "d-flex flex-column";
        else
            className += " d-flex flex-column";

        var orders = 0;

        if (this.props.classroomReport)
            orders = this.props.data[0].poll.length

        var data = this.props.data;

        var totalStudentIdeaQuantity = 0;
        var totalStudentIdeaPercentage = 0;
        var totalStudentResultQuantity = 0;
        var totalStudentResultPercentage = 0;

        if (this.props.classroomReport === false) {
            for (var i = 0; i < data.length; i++) {
                data[i].totalStudentIdeaQuantity = 0;
                data[i].totalStudentIdeaPercentage = 0;
                data[i].totalStudentResultQuantity = 0;
                data[i].totalStudentResultPercentage = 0;

                for (var j = 0; j < data[i].results.length; j++) {
                    data[i].totalStudentIdeaQuantity += data[i].results[j].testIdeaQuantity;
                    data[i].totalStudentIdeaPercentage += data[i].results[j].testIdeaPercentage;
                    data[i].totalStudentResultQuantity += data[i].results[j].testResultQuantity;
                    data[i].totalStudentResultPercentage += data[i].results[j].testResultPercentage;
                }
            }
        }

        return (
            <div className={className}>
                {this.props.classroomReport === false ?
                    this.props.data.map(item => {
                        return (
                            <div key={item.orderName}>
                                <PollReportMathGridHeader classroomReport={this.props.classroomReport} orderName={item.orderName} />

                                {item.results.map(result =>
                                    <PollReportMathGridItem {...result} />
                                )}

                                <PollReportGridTotal className="mb-4"
                                    totalIdeaQuantity={item.totalStudentIdeaQuantity}
                                    totalIdeaPercentage={item.totalStudentIdeaPercentage.toFixed(2)}
                                    totalResultQuantity={item.totalStudentResultQuantity}
                                    totalResultPercentage={item.totalStudentResultPercentage.toFixed(2)} />
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