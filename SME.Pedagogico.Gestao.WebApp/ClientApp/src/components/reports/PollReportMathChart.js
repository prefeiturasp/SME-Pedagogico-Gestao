import React, { Component } from 'react';

export default class PollReportPortugueseChart extends Component {
    componentDidMount() {
        var echarts = require('echarts');

        // initialize echarts instance with prepared DOM
        var myChart = echarts.init(document.getElementById('chart'));
        // draw chart
        myChart.setOption({
            legend: {},
            tooltip: {},
            dataset: {
                source: [
                    ['type', 'IDEIA', 'RESULTADO'],
                    ['Acertou', 41.1, 30.4],
                    ['Errou', 86.5, 92.1],
                    ['Não Resolveu', 24.1, 67.2]
                ]
            },
            xAxis: { type: 'category' },
            yAxis: {},
            // Declare several bar series, each will be mapped
            // to a column of dataset.source by default.
            series: [
                { type: 'bar', seriesLayoutBy: 'row' },
                { type: 'bar', seriesLayoutBy: 'row' },
                { type: 'bar', seriesLayoutBy: 'row' },
            ]
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