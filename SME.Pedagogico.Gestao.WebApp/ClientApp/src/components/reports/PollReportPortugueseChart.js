import React, { Component } from "react";

export default class PollReportPortugueseChart extends Component {
  constructor() {
    super();

    this.updateChart = this.updateChart.bind(this);
  }

  updateChart() {
    const { data } = this.props;
    const labels = data.map((item) => item.label);
    const values = data.map((item) => item.value);

    const echarts = require("echarts");

    // initialize echarts instance with prepared DOM
    const myChart = echarts.init(document.getElementById("chart"));
    // draw chart
    myChart.setOption({
      tooltip: {},
      xAxis: {
        data: labels,
      },
      yAxis: {},
      series: [
        {
          name: "Alunos",
          type: "bar",
          itemStyle: {
            normal: {
              color: "#0077BE",
            },
          },
          data: values,
        },
      ],
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
      <div className="d-flex flex-fill justify-content-center">
        <div id="chart" style={{ height: 400, width: 1156 }}></div>
      </div>
    );
  }
}
