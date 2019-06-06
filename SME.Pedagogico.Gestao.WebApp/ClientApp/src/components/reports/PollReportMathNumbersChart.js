import React, { Component } from 'react';

class MathChart extends Component {
    componentDidMount() {
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

export default class PollReportMathNumbersChart extends Component {
    render() {
        var familiares = null;
        var opacos = null;
        var transparentes = null;
        var terminamZero = null;
        var algarismos = null;
        var processoGeneralizacao = null;
        var zeroIntercalado = null;

        for (var i = 0; i < this.props.data.length; i++)
            switch (this.props.data[i].order) {
                case "Familiares":
                    familiares = { name: "Familiares", value1: this.props.data[i].numbers[0].quantity, value2: this.props.data[i].numbers[1].quantity }
                    break;
                case "Opacos":
                    opacos = { name: "Opacos", value1: this.props.data[i].numbers[0].quantity, value2: this.props.data[i].numbers[1].quantity }
                    break;
                case "Transparentes":
                    transparentes = { name: "Transparentes", value1: this.props.data[i].numbers[0].quantity, value2: this.props.data[i].numbers[1].quantity }
                    break;
                case "Terminam em zero":
                    terminamZero = { name: "Terminam em zero", value1: this.props.data[i].numbers[0].quantity, value2: this.props.data[i].numbers[1].quantity }
                    break;
                case "Algarismos":
                    algarismos = { name: "Algarismos", value1: this.props.data[i].numbers[0].quantity, value2: this.props.data[i].numbers[1].quantity }
                    break;
                case "Processo de generalização":
                    processoGeneralizacao = { name: "Processo de generalização", value1: this.props.data[i].numbers[0].quantity, value2: this.props.data[i].numbers[1].quantity }
                    break;
                case "Zero intercalados":
                    zeroIntercalado = { name: "Zero intercalados", value1: this.props.data[i].numbers[0].quantity, value2: this.props.data[i].numbers[1].quantity }
                    break;
                default:
                    break;
            }
        debugger;

        return (
            <div>
                <div className="d-flex flex-column">
                    <div className="d-flex flex-fill justify-content-center">
                        {familiares !== null && <MathChart {...familiares} />}
                        {opacos !== null && <MathChart {...opacos} />}
                    </div>
                    <div className="d-flex flex-fill justify-content-center">
                        {transparentes !== null && <MathChart {...transparentes} />}
                        {terminamZero !== null && <MathChart {...terminamZero} />}
                    </div>
                    <div className="d-flex flex-fill justify-content-center">
                        {algarismos !== null && <MathChart {...algarismos} />}
                        {processoGeneralizacao !== null && <MathChart {...processoGeneralizacao} />}
                    </div>
                    <div className="d-flex flex-fill justify-content-center">
                        {zeroIntercalado !== null && <MathChart {...zeroIntercalado} />}
                        <div style={{ height: 400, width: 517 }}></div>
                    </div>
                </div>
            </div>
        );
    }
}