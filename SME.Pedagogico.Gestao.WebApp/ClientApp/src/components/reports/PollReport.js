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

class PollReport extends Component {
    constructor() {
        super();

        this.classroomReport = true;
        this.portChartData = [
            { name: "PS", value: 60 },
            { name: "SSV", value: 30 },
            { name: "SCV", value: 45 },
            { name: "SA", value: 23 },
            { name: "A", value: 50 },
        ];
        this.mathChartData = [
            {
                name: "ORDEM 1",
                idea: [60, 13, 30],
                result: [25, 30, 45]
            },
            {
                name: "ORDEM 2",
                idea: [20, 40, 30],
                result: [10, 15, 5]
            },
            {
                name: "ORDEM 3",
                idea: [60, 13, 30],
                result: [60, 30, 45]
            },
        ];
    }

    render() {
        return (
            <div>
                <Card className="mb-3">
                    <PollFilter />
                </Card>

                <Card id="pollReport-card">
                    <div className="py-2 px-3">
                        <div className="d-flex">
                            <PollReportFilter />
                            <div className="flex-fill d-flex justify-content-end">
                                <div className="mt-auto">
                                    <button type="button" className="btn btn-sm btn-outline-primary" style={{ width: 109 }}>
                                        Imprimir | <i className="fas fa-print"></i>
                                    </button>
                                </div>
                            </div>
                        </div>

                        {this.props.pollReport.showReport === true && 
                            <div>
                                <PollReportBreadcrumb className="mt-4" name="Planilha" />

                                {this.props.pollReport.selectedFilter.discipline === "Língua Portuguesa" ?
                                    <PollReportPortugueseGrid className="mt-3" classroomReport={this.classroomReport} />
                                    :
                                    <PollReportMathGrid className="mt-3" classroomReport={this.classroomReport} />
                                }

                                <PollReportBreadcrumb className="mt-5" name="Gráfico" />

                                {this.props.pollReport.selectedFilter.discipline === "Língua Portuguesa" ?
                                    <PollReportPortugueseChart data={this.portChartData} />
                                    :
                                    <div className="mt-4">
                                        {this.mathChartData.map(item => {
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
            </div>
        );
    }
}

export default connect(
    state => ({ pollReport: state.pollReport }),
    dispatch => bindActionCreators(actionCreators, dispatch)
)(PollReport);