import React, { Component } from 'react';

const ClassReportColumnName = (props) => {
    const { number } = props;
    var className = "col sc-gray border-left border-white";

    if (number === 1)
        var className = "col sc-gray";

    return (
        <div className={className}>
            <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-bold">ORDEM {number}</div>
        </div>
    );
}

const ClassReportColumn1 = () => {
    return (
        <div className="col sc-gray border-left border-white">
            <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center">Ideia</div>
        </div>
    );
}

const ClassReportColumn2 = () => {
    return (
        <div className="col sc-gray border-left border-white">
            <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center">Resultado</div>
        </div>
    );
}

export default class PollReportMathGridHeader extends Component {
    render() {
        var { orders, headers } = this.props;
        var orderIndexes = [];

        for (var i = 0; i < Number(orders); i++)
            orderIndexes.push(i + 1);

        if (this.props.classroomReport === true) {
            if (this.props.numbers !== true)
                return (
                    <div>
                        <div className="d-flex poll-report-grid-header border-bottom border-white">
                            <div className="col-4"></div>
                            <div className="col-8 sc-gray">
                                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center">PROBLEMAS DE COMPOSIÇÃO</div>
                            </div>
                        </div>
                        <div className="d-flex poll-report-grid-header border-bottom border-white">
                            <div className="col-4 "></div>
                            {orderIndexes.map(item =>
                                <ClassReportColumnName number={item} />
                            )}
                        </div>
                        <div className="d-flex poll-report-grid-header">
                            <div className="col-1 sc-gray">
                                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center">#</div>
                            </div>
                            <div className="col-3 sc-gray">
                                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center">Alunos</div>
                            </div>
                            {orderIndexes.map(item =>
                                [<ClassReportColumn1 />, <ClassReportColumn2 />]
                            )}
                        </div>
                    </div>
                );
            else
                return (
                    <div>
                        <div className="d-flex poll-report-grid-header border-bottom border-white">
                            <div className="col-1 sc-gray">
                                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-bold">#</div>
                            </div>
                            <div className="col-3 sc-gray">
                                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-bold">Alunos</div>
                            </div>
                            {headers.map(item => {
                                return (
                                    <div className="col sc-gray border-left border-white font-weight-bold">
                                        <div className="sc-text-size-00 d-flex flex-fill h-100 align-items-center">{item.idea}</div>
                                    </div>
                                );
                            })}
                        </div>
                    </div>
                );
        }
        else {
            if (this.props.numbers !== true)
                return (
                    <div>
                        <div className="d-flex poll-report-grid-header border-bottom border-white">
                            <div className="col-4 sc-gray">
                                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-bold">ORDEM {this.props.orderName}</div>
                            </div>
                            <div className="col-8 sc-gray">
                                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center">PROBLEMAS DE COMPOSIÇÃO</div>
                            </div>
                        </div>
                        <div className="d-flex poll-report-grid-header border-bottom border-white">
                            <div className="col-4 sc-gray border-right border-white"></div>
                            <div className="col-3 sc-gray border-right border-right border-white">
                                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center">Ideia</div>
                            </div>
                            <div className="col-1 sc-gray border-right border-white">
                                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center">%</div>
                            </div>
                            <div className="col-3 sc-gray border-right border-right border-white">
                                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center">Resultado</div>
                            </div>
                            <div className="col-1 sc-gray border-right border-white">
                                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center">%</div>
                            </div>
                        </div>
                    </div>
                );
            else
                return (
                    <div>
                        <div className="d-flex poll-report-grid-header border-bottom border-white">
                            <div className="col-4 sc-gray">
                                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center font-weight-bold">{this.props.orderName}</div>
                            </div>
                            <div className="col-7 sc-gray border-left border-white">
                                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-bold">Alunos</div>
                            </div>
                            <div className="col-1 sc-gray border-left border-white">
                                <div className="sc-text-size-0 d-flex flex-fill h-100 align-items-center justify-content-center font-weight-bold">%</div>
                            </div>
                        </div>
                    </div>
                );
        }
    }
}