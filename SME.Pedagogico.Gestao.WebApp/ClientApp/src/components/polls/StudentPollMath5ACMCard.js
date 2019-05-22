import React, { Component } from 'react';
import StudentPollMath5A6ACM from '../polls/StudentPollMath5A6ACM'
import LegendsRightWrong from '../polls/component/LegendsRightWrong'
//Sondagem Matmática 5 Ano CM
//Falta o componente receber a lista de alunos
export default class StudentPollMath5ACMCard extends Component {
    constructor(props) {
        super(props);

        this.state = {
            selectedClass: "custom-select custom-select-sm poll-select",
            selectedOrdem: "ordem5"
        };
        this.hideShowOrdem = this.hideShowOrdem.bind(this);
        this.showOneHideAll = this.showOneHideAll.bind(this);
    }
    componentDidUpdate() {
        this.showOneHideAll(this.state.selectedOrdem);
    }
    showOneHideAll(element) {
        var allColumnToHide = ["ordem5", "ordem6", "ordem7", "ordem8"]
        var columnFiltered = allColumnToHide.filter((item) => item !== element)

        var all_col = document.getElementsByClassName("text-center border poll-select-container ");
        for (var i = 0; i < all_col.length; i++) { //esconde as colunas
            all_col[i].style.display = "none";
        }

        for (var j = 0; j < columnFiltered.length; j++) {
            document.getElementById(columnFiltered[j] + "_head").style.display = "none";//esconde head
            document.getElementById(columnFiltered[j] + "_table").style.display = "none";//esconde table com as tabelas com as informações
            document.getElementById(columnFiltered[j] + "_col").style.display = "none";
        }

        all_col = document.getElementsByClassName("text-center border poll-select-container " + element + "_col");
        for (var k = 0; k < all_col.length; k++) {//exibe as colunas respostas
            all_col[k].style.display = "table-cell";
        }

        document.getElementById(element + "_head").style.display = "table-cell";//exibe a head
        document.getElementById(element + "_col").style.display = "table-cell";//exibe a coluna da ordem
        document.getElementById(element + "_table").style.display = "table-cell";//exibe table com as tabelas com as informações
    }
    hideShowOrdem(event) {
        this.setState({
            selectedOrdem: event.target.attributes[0].value
        });
        this.showOneHideAll(event.target.attributes[0].value);
    }
    render() {
        const pStyle = {
            color: 'gray'
        }
        return (
            <div>
                <div id="wrapper">
                    <LegendsRightWrong />
                    <div>
                        <div className="btn-group mr-2 btn-group-sm" role="group" aria-label="First group">
                            <button type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-single">Alfabetização</button>
                        </div>
                        <div className="btn-group mr-2 btn-group-sm" role="group" aria-label="Second group">
                            <button type="button" className="btn btn-outline-primary btn-sm btn-matematica  btn-single">1º ano</button>
                        </div>
                        <div className="btn-group mr-2 btn-group-sm" role="group" aria-label="Third group">
                            <button type="button" className="btn btn-outline-primary btn-sm btn-matematica  btn-single">2º ano</button>
                        </div>
                        <div className="btn-group mr-2 btn-group-sm" role="group" aria-label="Fourth group">
                            <button type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-left border-right-0">3º ano - CA</button>
                            <button type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-right border-left-0">3º ano - CM</button>
                        </div>
                        <div className="btn-group mr-2 btn-group-sm" role="group" aria-label="Fifth group">
                            <button type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-left border-right-0">4º ano - CA</button>
                            <button type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-right border-left-0">4º ano - CM</button>
                        </div>
                        <div className="btn-group mr-2 btn-group-sm" role="group" aria-label="Sixth group">
                            <button type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-left border-right-0">5º ano - CA</button>
                            <button type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-right border-left-0 active">5º ano - CM</button>
                        </div>
                        <div className="btn-group mr-2 btn-group-sm" role="group" aria-label="Seventh group">
                            <button type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-left border-right-0">6º ano - CA</button>
                            <button type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-right border-left-0">6º ano - CM</button>
                        </div>
                    </div>
                </div>
                <table className="table table-sm table-bordered table-hover table-sondagem-matematica" style={{ overflow: "hidden", overflowX: "auto" }}>
                    <thead>
                        <tr>
                            <th rowSpan="5" className="align-middle border text-color-purple "><div className="ml-2"><small>Sondagem - 5º ano <b>Campo Multiplicativo</b></small></div></th>
                            <th colSpan="8" className="text-center border sondagem-matematica-title" id="ordem5_head"><span style={pStyle}>&#60;</span><small className="p-4">Ordem 5 - ideia: COMBINATÓRIA</small><span value="ordem6" onClick={this.hideShowOrdem}>&#62;</span></th>
                            <th colSpan="8" className="text-center border sondagem-matematica-title" id="ordem6_head"><span value="ordem5" onClick={this.hideShowOrdem}>&#60;</span><small className="p-4">Ordem 6 - ideia: CONFIGURAÇÃO REGULAR</small><span value="ordem7" onClick={this.hideShowOrdem}>&#62;</span></th>
                            <th colSpan="8" className="text-center border sondagem-matematica-title" id="ordem7_head"><span value="ordem6" onClick={this.hideShowOrdem}>&#60;</span><small className="p-4">Ordem 7 - ideia: PROPORCIONALIDADE</small><span value="ordem8" onClick={this.hideShowOrdem}>&#62;</span></th>
                            <th colSpan="8" className="text-center border sondagem-matematica-title" id="ordem8_head"><span value="ordem7" onClick={this.hideShowOrdem}>&#60;</span><small className="p-4">Ordem 8 - ideia: MULTIPLICAÇÃO COMPARATIVA</small><span style={pStyle}>&#62;</span></th>
                        </tr>
                        <tr>
                            <th colSpan="8" className="text-center border text-color-purple" id="ordem5_col"><small>Problemas 2º e 4º Bimestre</small></th>
                            <th colSpan="8" className="text-center border text-color-purple" id="ordem6_col"><small>Problemas 2º e 4º Bimestre</small></th>
                            <th colSpan="8" className="text-center border text-color-purple" id="ordem7_col"><small>Problemas 2º e 4º Bimestre</small></th>
                            <th colSpan="8" className="text-center border text-color-purple" id="ordem8_col"><small>Problemas 2º e 4º Bimestre</small></th>
                        </tr>
                        <tr>
                            <th colSpan="8" id="ordem5_table">
                                <div className="container">
                                    <div className="row">
                                        <div className="col table-column-sondagem">
                                            <small>Atributo 1</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>Atributo 2</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>Total de combinações</small>
                                        </div>
                                    </div>
                                    <div className="row">
                                        <div className="col table-column-sondagem">
                                            <small>Dado</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>Dado</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>?</small>
                                        </div>
                                    </div>
                                </div>
                            </th>
                            <th colSpan="8" id="ordem6_table">
                                <div className="container">
                                    <div className="row">
                                        <div className="col table-column-sondagem">
                                            <small>Problema</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>Linhas</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>Colunas</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>Total</small>
                                        </div>
                                    </div>
                                    <div className="row">
                                        <div className="col table-column-sondagem">
                                            <small>2° Bl</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>Dadas</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>Dadas</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>?</small>
                                        </div>
                                    </div>
                                    <div className="row">
                                        <div className="col table-column-sondagem">
                                            <small>4° Bl</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>Dadas</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>?</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>Total</small>
                                        </div>
                                    </div>
                                </div>
                            </th>
                            <th colSpan="8" id="ordem7_table">
                                <div className="container">
                                    <div className="row">
                                        <div className="col table-column-sondagem">
                                            <small>Grandeza I</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>Grandeza II</small>
                                        </div>
                                    </div>
                                    <div className="row">
                                        <div className="col table-column-sondagem">
                                            <small>Dada</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>Dada</small>
                                        </div>
                                    </div>
                                    <div className="row">
                                        <div className="col table-column-sondagem">
                                            <small>Dada</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>?</small>
                                        </div>
                                    </div>
                                </div>
                            </th>
                            <th colSpan="8" id="ordem8_table">
                                <div className="container">
                                    <div className="row">
                                        <div className="col table-column-sondagem">
                                            <small>Valor maior</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>Valor menor</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>&#8800; entre valores</small>
                                        </div>
                                    </div>
                                    <div className="row">
                                        <div className="col table-column-sondagem">
                                            <small>Dado</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>?</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>Dada</small>
                                        </div>
                                    </div>
                                </div>
                            </th>
                        </tr>
                        <tr>
                            <th colSpan="4" className="text-center border poll-select-container"><small className="text-muted">2ºB</small></th>
                            <th colSpan="4" className="text-center border poll-select-container"><small className="text-muted">4ºB</small></th>
                            <th colSpan="4" className="text-center border poll-select-container"><small className="text-muted">2ºB</small></th>
                            <th colSpan="4" className="text-center border poll-select-container"><small className="text-muted">4ºB</small></th>
                            <th colSpan="4" className="text-center border poll-select-container"><small className="text-muted">2ºB</small></th>
                            <th colSpan="4" className="text-center border poll-select-container"><small className="text-muted">4ºB</small></th>
                            <th colSpan="4" className="text-center border poll-select-container"><small className="text-muted">2ºB</small></th>
                            <th colSpan="4" className="text-center border poll-select-container"><small className="text-muted">4ºB</small></th>
                        </tr>
                        <tr>
                            <th colSpan="2" className="text-center border poll-select-container ordem5_col"><small className="text-muted">Ideia</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem5_col"><small className="text-muted">Resultado</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem5_col"><small className="text-muted">Ideia</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem5_col"><small className="text-muted">Resultado</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem6_col"><small className="text-muted">Ideia</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem6_col"><small className="text-muted">Resultado</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem6_col"><small className="text-muted">Ideia</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem6_col"><small className="text-muted">Resultado</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem7_col"><small className="text-muted">Ideia</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem7_col"><small className="text-muted">Resultado</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem7_col"><small className="text-muted">Ideia</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem7_col"><small className="text-muted">Resultado</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem8_col"><small className="text-muted">Ideia</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem8_col"><small className="text-muted">Resultado</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem8_col"><small className="text-muted">Ideia</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem8_col"><small className="text-muted">Resultado</small></th>
                        </tr>
                    </thead>

                    <tbody>

                        {this.props.students.map(student => (
                            <StudentPollMath5A6ACM key={student.sequence} student={student} updatePollStudent={this.props.updatePollStudent} />
                        ))}

                    </tbody>
                </table>
            </div>
        );
    }
}