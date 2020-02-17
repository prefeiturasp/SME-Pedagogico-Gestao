import React, { Component } from 'react';
import { connect } from 'react-redux';
import { actionCreators } from '../../store/PollReport';
import { bindActionCreators } from 'redux';

class MathChart extends Component {
    constructor() {
        super();

        this.updateChart = this.updateChart.bind(this);
    }

    updateChart() {
        var echarts = require('echarts');
        var myChart = echarts.init(document.getElementById("id-" + this.props.name.replace(" ", "").toLowerCase()));

        myChart.setOption({
            tooltip: {},
            xAxis: {
                data: ['Escreve conv.', 'Não escreve conv.']
            },
            yAxis: {},
            series: [{
                name: 'Alunos',
                type: 'bar',
                data: [{
                    value: this.props.value1,
                    itemStyle: { color: '#9C96F6' },
                },
                {
                    value: this.props.value2,
                    itemStyle: { color: '#0077BE' },
                }]
            }]
        });
    }

    componentDidMount() {
        this.updateChart();
    }

    componentDidUpdate() {
        this.updateChart();
    }

    render() {
        return (
            <div style={{ width: 517 }}>
                <div className="d-flex justify-content-center align-items-center sc-gray mx-4" style={{ height: 35 }} >
                    <div className="sc-text-size-1 font-weight-bold">{this.props.name}</div>
                </div>
                <div id={"id-" + this.props.name.replace(" ", "").toLowerCase()} style={{ height: 400, width: 517 }}></div>
            </div>
        );
    }
}

const ChartTitle = (props) => {
    return (
        <div className="d-flex flex-fill justify-content-center align-items-center sc-gray" style={{ height: 35 }} >
            <div className="sc-text-size-1 font-weight-bold">{props.title}</div>
        </div>
    );
}

const ChartLabel = (props) => {
    return (
        <div className="mx-5" style={{ position: 'relative', top: -30 }}>
            <div className="d-flex justify-content-center border border-top-0" style={{ height: 7 }}></div>
            <div className="d-flex justify-content-center sc-text-size-1 text-muted">{props.label}</div>
        </div>
    );
}

  class PollReportMathChartClassroom extends Component {
    constructor() {
        super();

        this.updateChart = this.updateChart.bind(this);
    }

    updateChart() {
       if (this.props.pollReport.selectedFilter.proficiency !== "Números")  {
            var echarts = require('echarts');

            // initialize echarts instance with prepared DOM
            var myChart = echarts.init(document.getElementById(this.props.chartIds[0]));
            var myChart2 = echarts.init(document.getElementById(this.props.chartIds[1]));

            // draw chart
            myChart.setOption({
                tooltip: {},
                xAxis: {
                    data: ['Acertou', 'Errou', 'Não Resolveu']
                },
                yAxis: {},
                series: [{
                    name: 'Alunos',
                    type: 'bar',
                    itemStyle: {
                        normal: {
                            color: '#9C96F6'
                        },
                    },
                    data: this.props.data.idea
                }]
            });

            myChart2.setOption({
                tooltip: {},
                xAxis: {
                    data: ['Acertou', 'Errou', 'Não Resolveu']
                },
                yAxis: {},
                series: [{
                    name: 'Alunos',
                    type: 'bar',
                    itemStyle: {
                        normal: {
                            color: '#0077BE'
                        },
                    },
                    data: this.props.data.result
                }]
            });
        }
    }

    componentDidMount() {
        this.updateChart();
    }

    componentDidUpdate() {
        this.updateChart();
    }
   
    render() {
        var { data } = this.props;

        if (data !== undefined) {
            if (this.props.pollReport.selectedFilter.proficiency !== "Números")
                return (
                    <div className="d-flex flex-column">
                        <ChartTitle title={data.name} />
                        <div className="d-flex flex-fill justify-content-center" style={{ position: 'relative', top: -35 }}>
                            <div>
                                <div id={this.props.chartIds[0]} style={{ height: 400, width: 517 }}></div>
                                <ChartLabel label="Ideia" />
                            </div>
                            <div>
                                <div id={this.props.chartIds[1]} style={{ height: 400, width: 517 }}></div>
                                <ChartLabel label="Resultado" />
                            </div>
                        </div>
                    </div>
                );
            else if(this.props.pollReport.selectedFilter.proficiency === "Números" && Array.isArray(data))
                return (
                    <div className="d-flex flex-fill justify-content-center flex-wrap">
                        {data.map(item =>
                            <MathChart name={item.name} value1={item.idea[0]} value2={item.result[0]} />
                        )}
                    </div>
                );
        }
        
    }
}
export default connect(
    state => ({ pollReport: state.pollReport }),
    dispatch => bindActionCreators(actionCreators, dispatch)
)(PollReportMathChartClassroom);