import React, { Component } from 'react';
import Card from '../containers/Card';
import PollFilter from '../classRecord/PollFilter';
import PollReportFilter from './PollReportFilter';
import PollReportBreadcrumb from './PollReportBreadcrumb';
import PollReportPortugueseGrid from './PollReportPortugueseGrid';
import PollReportMathGrid from './PollReportMathGrid';
import PollReportPortugueseChart from './PollReportPortugueseChart';
import PollReportMathChart from './PollReportMathChart';
import PollReportMathNumbersChart from './PollReportMathNumbersChart';
import { connect } from 'react-redux';
import { actionCreators } from '../../store/PollReport';
import { bindActionCreators } from 'redux';

class PollReport extends Component {
    constructor(props) {
        super(props);

        this.classroomReport = true;

        this.state = {
            showMessage: false
        }

        this.printClick = this.printClick.bind(this);
    }

    printClick() {
        //var scale = 'scale(0.6)';
        //document.body.style.webkitTransform = scale;    // Chrome, Opera, Safari
        //document.body.style.msTransform = scale;       // IE 9
        //document.body.style.transform = scale;     // General
        window.print();
        //scale = 'scale(1)';
        //document.body.style.webkitTransform = scale;    // Chrome, Opera, Safari
        //document.body.style.msTransform = scale;       // IE 9
        //document.body.style.transform = scale;     // General
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

        var indexes = [];

        if (this.props.pollReport.showReport === true) {
            if (chartData.chartIdeaData !== undefined && chartData.chartIdeaData.length > 0) {
                chartData.totals = [];

                for (var i = 0; i < chartData.chartIdeaData.length; i++) {
                    indexes.push(i);
                    chartData.totals.push({
                        name: "ORDEM " + chartData.chartIdeaData[i].order,
                        idea: new Array(chartData.chartIdeaData[i].idea.length),
                        result: new Array(chartData.chartResultData[i].result.length),
                    });

                    for (var j = 0; j < chartData.chartIdeaData[i].idea.length; j++) {
                        switch (chartData.chartIdeaData[i].idea[j].description) {
                            case "Acertou":
                                chartData.totals[i].idea[0] = chartData.chartIdeaData[i].idea[j].quantity;
                                break;
                            case "Errou":
                                chartData.totals[i].idea[1] = chartData.chartIdeaData[i].idea[j].quantity;
                                break;
                            case "Não Resolveu":
                                chartData.totals[i].idea[2] = chartData.chartIdeaData[i].idea[j].quantity;
                                break;
                            default:
                                break;
                        }
                    }

                    for (var j = 0; j < chartData.chartResultData[i].result.length; j++) {
                        switch (chartData.chartResultData[i].result[j].description) {
                            case "Acertou":
                                chartData.totals[i].result[0] = chartData.chartResultData[i].result[j].quantity;
                                break;
                            case "Errou":
                                chartData.totals[i].result[1] = chartData.chartResultData[i].result[j].quantity;
                                break;
                            case "Não Resolveu":
                                chartData.totals[i].result[2] = chartData.chartResultData[i].result[j].quantity;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            else {

            }
        }

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
                                    {chartData.chartIdeaData.length > 0 ?
                                        indexes.map(index => {
                                            var chartId = "ordem" + chartData.chartIdeaData[index].order;

                                            return (
                                                <PollReportMathChart key={chartId} chartIds={[(chartId + "idea"), (chartId + "result")]} data={chartData.totals[index]} />
                                            );
                                        })
                                        :
                                        <PollReportMathNumbersChart data={chartData} />
                                    }
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