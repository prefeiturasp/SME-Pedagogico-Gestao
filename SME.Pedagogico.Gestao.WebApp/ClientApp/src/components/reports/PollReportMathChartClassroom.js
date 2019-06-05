import React, { Component } from 'react';

const ChartTitle = (props) => {
    return (
        <div className="d-flex flex-fill justify-content-center align-items-center sc-gray" style={{ height: 35 }} >
            <div className="sc-text-size-1 font-weight-bold">{props.title}</div>
        </div>
    );
}

export default class PollReportMathChartClassroom extends Component {
    render() {
        var { data } = this.props;

        if (data !== undefined)
            return (
                <div>
                    <ChartTitle title={data[0].name} />
                </div>
            );
        else
            return (
                <div></div>
            );
    }
}