import React, { Component } from 'react';

export default class PollReportPortugueseChart extends Component {
    componentDidMount() {
        var labels = [];
        var values = [];

        for (var i = 0; i < this.props.data.length; i++) {
            labels.push(this.props.data[i].name);
            values.push(this.props.data[i].value);
        }


        var echarts = require('echarts');

        // initialize echarts instance with prepared DOM
        var myChart = echarts.init(document.getElementById('chart'));
        // draw chart
        myChart.setOption({
            tooltip: {},
            xAxis: {
                data: labels
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
                data: values
            }]
        });
    }

    componentDidUpdate() {
        var labels = [];
        var values = [];

        for (var i = 0; i < this.props.data.length; i++) {
            labels.push(this.props.data[i].name);
            values.push(this.props.data[i].value);
        }


        var echarts = require('echarts');

        // initialize echarts instance with prepared DOM
        var myChart = echarts.init(document.getElementById('chart'));
        // draw chart
        myChart.setOption({
            tooltip: {},
            xAxis: {
                data: labels
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
                data: values
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