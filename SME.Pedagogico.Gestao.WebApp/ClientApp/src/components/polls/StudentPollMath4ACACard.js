﻿import React, { Component } from 'react';
import StudentPollMath4A5A6ACA from '../polls/StudentPollMath4A5A6ACA'
import LegendsRightWrong from '../polls/component/LegendsRightWrong'
//Sondagem Matmática 4 Ano CA
//Falta o componente receber a lista de alunos
export default class StudentPollMath4ACACard extends Component {
    constructor(props) {
        super(props);

        this.state = {
            selectedClass: "custom-select custom-select-sm poll-select",
            selectedOrdem: "ordem1"
        };
        this.hideShowOrdem = this.hideShowOrdem.bind(this);
        this.showOneHideAll = this.showOneHideAll.bind(this);
    }
    componentDidUpdate() {
        this.showOneHideAll(this.state.selectedOrdem);
    }
    showOneHideAll(element) {
        var allColumnToHide = ["ordem1", "ordem2", "ordem3", "ordem4"]
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
                            <button type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-left border-right-0 active">4º ano - CA</button>
                            <button type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-right border-left-0">4º ano - CM</button>
                        </div>
                        <div className="btn-group mr-2 btn-group-sm" role="group" aria-label="Sixth group">
                            <button type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-left border-right-0">5º ano - CA</button>
                            <button type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-right border-left-0">5º ano - CM</button>
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
                            <th rowSpan="5" className="align-middle border text-color-purple "><div className="ml-2"><small>Sondagem - 4º ano <b>Campo aditivo</b></small></div></th>
                            <th colSpan="8" className="text-center border sondagem-matematica-title" id="ordem1_head"><span style={pStyle}>&#60;</span><small className="p-4">Ordem 1 - ideia: COMPOSIÇÃO</small><span value="ordem2" onClick={this.hideShowOrdem}>&#62;</span></th>
                            <th colSpan="8" className="text-center border sondagem-matematica-title" id="ordem2_head"><span value="ordem1" onClick={this.hideShowOrdem}>&#60;</span><small className="p-4">Ordem 2 - ideia: TRANFORMAÇÃO</small><span value="ordem3" onClick={this.hideShowOrdem}>&#62;</span></th>
                            <th colSpan="8" className="text-center border sondagem-matematica-title" id="ordem3_head"><span value="ordem2" onClick={this.hideShowOrdem}>&#60;</span><small className="p-4">Ordem 3 - ideia: COMPOSIÇÃO DE TRANSF.</small><span value="ordem4" onClick={this.hideShowOrdem}>&#62;</span></th>
                            <th colSpan="8" className="text-center border sondagem-matematica-title" id="ordem4_head"><span value="ordem3" onClick={this.hideShowOrdem}>&#60;</span><small className="p-4">Ordem 4 - ideia: COMPARAÇÃO</small><span style={pStyle}>&#62;</span></th>
                        </tr>
                        <tr>
                            <th colSpan="8" className="text-center border text-color-purple" id="ordem1_col"><small>Problemas 2º e 4º Bimestre</small></th>
                            <th colSpan="8" className="text-center border text-color-purple" id="ordem2_col"><small>Problemas 2º e 4º Bimestre</small></th>
                            <th colSpan="8" className="text-center border text-color-purple" id="ordem3_col"><small>Problemas 2º e 4º Bimestre</small></th>
                            <th colSpan="8" className="text-center border text-color-purple" id="ordem4_col"><small>Problemas 2º e 4º Bimestre</small></th>
                        </tr>
                        <tr>
                            <th colSpan="8" id="ordem1_table">
                                <div className="container">
                                    <div className="row">
                                        <div className="col table-column-sondagem">
                                            <small>Todo</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>Parte</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>Parte</small>
                                        </div>
                                    </div>
                                    <div className="row">
                                        <div className="col table-column-sondagem">
                                            <small>Dado</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>Dada</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>?</small>
                                        </div>
                                    </div>
                                </div>
                            </th>
                            <th colSpan="8" id="ordem2_table">
                                <div className="container">
                                    <div className="row">
                                        <div className="col table-column-sondagem">
                                            <small>Estado inicial</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>Estado final</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>Transformação</small>
                                        </div>
                                    </div>
                                    <div className="row">
                                        <div className="col table-column-sondagem">
                                            <small>?</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>Dado</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>Dada</small>
                                        </div>
                                    </div>
                                </div>
                            </th>
                            <th colSpan="8" id="ordem3_table">
                                <table className="table table-bordered table-sondagem" cellSpacing="2">
                                    <tbody>
                                        <tr>
                                            <th rowSpan="2" className="align-middle"><small>Estado Inicial</small></th>
                                            <th colSpan="2"><small>Transformações</small></th>
                                            <th rowSpan="2" className="align-middle"><small>Estado Final</small></th>
                                        </tr>
                                        <tr>
                                            <th><small>TI</small></th>
                                            <th><small>T2</small></th>
                                        </tr>
                                        <tr>
                                            <td><small>Dado</small></td>
                                            <td><small>Dada</small></td>
                                            <td><small>Dada</small></td>
                                            <td><small>?</small></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </th>
                            <th colSpan="8" id="ordem4_table">
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
                                            <small>Dada</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>?</small>
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
                            <th colSpan="2" className="text-center border poll-select-container ordem1_col"><small className="text-muted">Ideia</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem1_col"><small className="text-muted">Resultado</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem1_col"><small className="text-muted">Ideia</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem1_col"><small className="text-muted">Resultado</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem2_col"><small className="text-muted">Ideia</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem2_col"><small className="text-muted">Resultado</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem2_col"><small className="text-muted">Ideia</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem2_col"><small className="text-muted">Resultado</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem3_col"><small className="text-muted">Ideia</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem3_col"><small className="text-muted">Resultado</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem3_col"><small className="text-muted">Ideia</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem3_col"><small className="text-muted">Resultado</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem4_col"><small className="text-muted">Ideia</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem4_col"><small className="text-muted">Resultado</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem4_col"><small className="text-muted">Ideia</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem4_col"><small className="text-muted">Resultado</small></th>
                        </tr>
                    </thead>

                    <tbody>

                        {this.props.students.map(student => (
                            <StudentPollMath4A5A6ACA key={student.sequence} student={student} updatePollStudent={this.props.updatePollStudent} />
                        ))}

                    </tbody>
                </table>
            </div>
        );
    }
}