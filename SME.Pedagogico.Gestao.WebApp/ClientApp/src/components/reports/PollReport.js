import React, { Component } from 'react';
import Card from '../containers/Card';
import PollFilter from '../classRecord/PollFilter';
import PollReportFilter from './PollReportFilter';
import PollReportBreadcrumb from './PollReportBreadcrumb';
import PollReportPortugueseGrid from './PollReportPortugueseGrid';
import PollReportChart from './PollReportChart';

export default class PollReport extends Component {
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

                        <PollReportPortugueseGrid className="mt-3" classroomReport={false} />

                        <PollReportBreadcrumb className="mt-5" name="Gráfico" />

                        <PollReportChart />
                    </div>
                </Card>
            </div>
        );
    }
}