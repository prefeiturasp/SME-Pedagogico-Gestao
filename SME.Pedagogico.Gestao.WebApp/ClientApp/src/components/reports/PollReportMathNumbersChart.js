import React, { Component } from 'react';

export default class PollReportMathNumbersChart extends Component {
    componentDidMount() {
        var echarts = require('echarts');
        var myChart = echarts.init(document.getElementById("testeChart1"));

        myChart.setOption({
            tooltip: {},
            xAxis: {
                data: ['Escreve conv.', 'Não escreve conv.']
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
                data: [10, 5]
            }]
        });
    }

    render() {
        return (
            <div>
                <div className="d-flex flex-column">
                    <div className="d-flex flex-fill justify-content-center">
                        <div>
                            <div className="d-flex justify-content-center align-items-center sc-gray mx-4" style={{ height: 35 }} >
                                <div className="sc-text-size-1 font-weight-bold">teste</div>
                            </div>
                            <div id="testeChart1" style={{ height: 400, width: 517 }}></div>
                        </div>
                        <div>
                            <div style={{ height: 400, width: 517, backgroundColor: "rgb(12,12,12)" }}></div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}