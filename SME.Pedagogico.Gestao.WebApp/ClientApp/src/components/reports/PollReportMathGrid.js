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

                                <PollReportGridTotal className="mb-4" totalIdeaQuantity="84" totalIdeaPercentage="100" totalResultQuantity="84" totalResultPercentage="100" />
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