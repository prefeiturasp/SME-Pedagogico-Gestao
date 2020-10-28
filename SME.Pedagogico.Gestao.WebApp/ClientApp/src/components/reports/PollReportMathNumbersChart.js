import React, { Component } from 'react';

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
                data: ['Escreve conv.', 'Não escreve conv.', 'S. preenchimento']
            },
            yAxis: {},
            series: [{
                name: 'Alunos',
                type: 'bar',
                data: [{
                    value: this.props.value1,
                    itemStyle: { color: '#0077BE' },
                },
                {
                    value: this.props.value2,
                    itemStyle: { color: '#0077BE' },
                },
                {
                    value: this.props.value3,
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
            <div>
                <div className="d-flex justify-content-center align-items-center sc-gray mx-4" style={{ height: 35 }} >
                    <div className="sc-text-size-1 font-weight-bold">{this.props.name}</div>
                </div>
                <div id={"id-" + this.props.name.replace(" ", "").toLowerCase()} style={{ height: 400, width: 517 }}></div>
            </div>
        );
    }
}

const PollReportMathNumbersChart = ({ data }) => (            
    <div style={{display: "grid", gridTemplateColumns: "1fr 1fr"}}>
        {
            data && data.map(item => {
                const obj = {
                    name: item.order, 
                    value1: item.numbers[0] && item.numbers[0].quantity, 
                    value2: item.numbers[1] && item.numbers[1].quantity, 
                    value3: item.numbers[2] && item.numbers[2].quantity 
                };    
                return (                          
                    <div className="d-flex flex-fill justify-content-center">
                        {item.order !== null && <MathChart {...obj} />}
                    </div>                          
                );
            })
        }
    </div>
);

export default PollReportMathNumbersChart;