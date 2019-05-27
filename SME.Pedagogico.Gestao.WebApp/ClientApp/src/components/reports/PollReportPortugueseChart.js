import React, { Component } from 'react';

export default class PollReportPortugueseChart extends Component {
    componentDidMount() {
        var echarts = require('echarts');

        // initialize echarts instance with prepared DOM
        var myChart = echarts.init(document.getElementById('chart'));
        // draw chart
        myChart.setOption({
            tooltip: {},
            xAxis: {
                data: ['PS', 'SSV', 'SCV', 'SA', 'A']
            },
            yAxis: {},
            series: [{
                name: 'Alunos',
                type: 'bar',
                itemStyle: {
                    normal: {
                        color: new echarts.graphic.LinearGradient(
                            0, 0, 0, 1,
                            [
                                { offset: 0, color: '#83bff6' },
                                { offset: 0.5, color: '#188df0' },
                                { offset: 1, color: '#188df0' }
                            ]
                        )
                    },
                    emphasis: {
                        color: new echarts.graphic.LinearGradient(
                            0, 0, 0, 1,
                            [
                                { offset: 0, color: '#2378f7' },
                                { offset: 0.7, color: '#2378f7' },
                                { offset: 1, color: '#83bff6' }
                            ]
                        )
                    }
                },
                data: [60, 30, 45, 23, 10]
            }]
        });
    }

    render() {
        return (
            <div className="d-flex flex-fill justify-content-center">
                <div id="chart" style={{ height: 400, width: 1156 }}></div>
            </div>
        );
    }
}