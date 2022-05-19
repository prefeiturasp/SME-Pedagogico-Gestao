import React, { Component } from 'react';

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

export default class PollReportMathChart extends Component {
    constructor() {
        super();

        this.updateChart = this.updateChart.bind(this);
    }

    updateChart() {
        var echarts = require('echarts');

        // initialize echarts instance with prepared DOM
        var myChart = echarts.init(document.getElementById(this.props.chartIds[0]));
        var myChart2 = echarts.init(document.getElementById(this.props.chartIds[1]));

        // draw chart
        myChart.setOption({
            tooltip: {},
            xAxis: {
                data: ['Acertou', 'Errou', 'Não Resolveu', 'S. preenchimento'],
                show: false,
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
                data: ['Acertou', 'Errou', 'Não Resolveu', 'S. preenchimento'],
                show: false,
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

    componentDidMount() {
        this.updateChart();
    }

    componentDidUpdate() {
        this.updateChart();
    }

    render() {
        return (
            <div className="d-flex flex-column">
                <ChartTitle title={this.props.data.name} />
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
    }
}