import React, { Component } from 'react';
import Card from '../containers/Card';
import PollFilter from '../classRecord/PollFilter';
import PollReportFilter from './PollReportFilter';
import PollReportBreadcrumb from './PollReportBreadcrumb';
import PollReportPortugueseGrid from './PollReportPortugueseGrid';
import PollReportMathGrid from './PollReportMathGrid';
import PollReportPortugueseChart from './PollReportPortugueseChart';
import PollReportMathChart from './PollReportMathChart';
import { connect } from 'react-redux';
import { actionCreators } from '../../store/PollReport';
import { bindActionCreators } from 'redux';

import TwoStepsSave from '../messaging/TwoStepsSave';

class PollReport extends Component {
    constructor(props) {
        super(props);

        this.classroomReport = true;

        this.state = {
            showMessage: false
        }

        this.printClick = this.printClick.bind(this);
        this.testMethod = this.testMethod.bind(this);
    }

    printClick() {
        var scale = 'scale(0.95)';
        document.body.style.webkitTransform = scale;    // Chrome, Opera, Safari
        document.body.style.msTransform = scale;       // IE 9
        document.body.style.transform = scale;     // General
        window.print();
        scale = 'scale(1)';
        document.body.style.webkitTransform = scale;    // Chrome, Opera, Safari
        document.body.style.msTransform = scale;       // IE 9
        document.body.style.transform = scale;     // General
    }

    testMethod() {
        this.setState({
            showMessage: !this.state.showMessage
        })
    }

    render() {
        var reportData = null;
        var chartData = null;

        if (this.props.pollReport.showReport === true) {
            reportData = this.props.pollReport.data;
            chartData = this.props.pollReport.chartData;
        }
        else {
            reportData = [];
            chartData = [];
        }

        this.classroomReport = this.props.pollReport.selectedFilter.classroomReport;

        return (
            <div>
                <Card className="mb-3">
                    <PollFilter reports={true} />
                </Card>

                <Card id="pollReport-card">
                    <div className="py-2 px-3">
                        <div className="d-flex">
                            <PollReportFilter />
                            <div className="flex-fill d-flex justify-content-end">
                                <div className="mt-auto">
                                    <button type="button" className="btn btn-sm btn-outline-primary" style={{ width: 109 }} onClick={this.printClick}>
                                        Imprimir | <i className="fas fa-print"></i>
                                    </button>
                                </div>
                            </div>
                        </div>

                        {this.props.pollReport.showReport === true && 
                            <div>
                                <PollReportBreadcrumb className="mt-4" name="Planilha" />

                                {this.props.pollReport.selectedFilter.discipline === "Língua Portuguesa" ?
                                    <PollReportPortugueseGrid className="mt-3" classroomReport={this.classroomReport} data={reportData} />
                                    :
                                    <PollReportMathGrid className="mt-3" classroomReport={this.classroomReport} data={reportData} />
                                }

                                <PollReportBreadcrumb className="mt-5" name="Gráfico" />

                                {this.props.pollReport.selectedFilter.discipline === "Língua Portuguesa" ?
                                    <PollReportPortugueseChart data={chartData} />
                                    :
                                    <div className="mt-4">
                                        {chartData.map(item => {
                                            var chartId = item.name.replace(" ", "").toLowerCase();

                                            return (
                                                <PollReportMathChart key={chartId} chartIds={[(chartId + "idea"), (chartId + "result")]} data={item} />
                                            );
                                        })}
                                    </div>
                                }
                            </div>
                        }
                    </div>
                </Card>

                <TwoStepsSave show={this.state.showMessage} showControl={this.testMethod} />

            </div>
        );
    }
}

export default connect(
    state => ({ pollReport: state.pollReport }),
    dispatch => bindActionCreators(actionCreators, dispatch)
)(PollReport);