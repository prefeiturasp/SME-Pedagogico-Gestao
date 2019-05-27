import React, { Component } from 'react';
import Card from '../containers/Card';
import PollFilter from '../classRecord/PollFilter';
import PollReportFilter from './PollReportFilter';
import PollReportBreadcrumb from './PollReportBreadcrumb';
import PollReportPortugueseGrid from './PollReportPortugueseGrid';
import PollReportMathGrid from './PollReportMathGrid';
import PollReportPortugueseChart from './PollReportPortugueseChart';
import PollReportMathChart from './PollReportMathChart';

export default class PollReport extends Component {
    constructor() {
        super();

        this.pollReportType = "portuguese";
        this.classroomReport = false;
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

                        <PollReportBreadcrumb className="mt-4" name="Planilha" />

                        {this.pollReportType === "portuguese" ?
                            <PollReportPortugueseGrid className="mt-3" classroomReport={this.classroomReport} />
                            :
                            <PollReportMathGrid className="mt-3" classroomReport={this.classroomReport} />
                        }

                        <PollReportBreadcrumb className="mt-5" name="Gráfico" />

                        {this.pollReportType === "portuguese" ?
                            <PollReportPortugueseChart />
                            :
                            <PollReportPortugueseChart />
                        }
                    </div>
                </Card>
            </div>
        );
    }
}