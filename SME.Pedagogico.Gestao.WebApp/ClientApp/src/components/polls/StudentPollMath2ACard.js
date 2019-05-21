import React, { Component } from 'react';
import StudentPollMath1A2A from '../polls/StudentPollMath1A2A'
import LegendsRightWrong from '../polls/component/LegendsRightWrong'
import SondagemClassSelected from '../polls/component/SondagemClassSelected'
//Sondagem Matmática 2 Ano
//Falta o componente receber a lista de alunos
export default class StudentPollMath2ACard extends Component {
    constructor(props) {
        super(props);

        this.state = {
            selectedClass: "custom-select custom-select-sm poll-select",
            selectedOrdem: "ordem1"

        };
        this.hideShowOrdem = this.hideShowOrdem.bind(this);
        this.showOneHideAll = this.showOneHideAll.bind(this);
    }
    componentDidMount() {
        this.showOneHideAll(this.state.selectedOrdem);
    }
    componentDidUpdate() {
        this.showOneHideAll(this.state.selectedOrdem);
    }
    showOneHideAll(element) {
        var allColumnToHide = ["ordem1", "ordem2", "ordem3"]
        var columnFiltered = allColumnToHide.filter((item) => item !== element)

        var all_col = document.getElementsByClassName("text-center border poll-select-container ");
        for (var i = 0; i < all_col.length; i++) { //esconde as colunas
            all_col[i].style.display = "none";
        }
        
        for (var j = 0; j < columnFiltered.length; j++) {
            document.getElementById(columnFiltered[j] + "_head").style.display = "none";//esconde head
            document.getElementById(columnFiltered[j] + "_table").style.display = "none";//esconde table com as tabelas com as informações
            document.getElementById(columnFiltered[j] + "_col").style.display = "none";
            if (columnFiltered[j] === "ordem1") { //mudança por causa da ordem1 que possui divisões de coluna
                document.getElementById(columnFiltered[j] + "_col2").style.display = "none";
                document.getElementById(columnFiltered[j] + "_table2").style.display = "none";
            }
        }
        
        all_col = document.getElementsByClassName("text-center border poll-select-container " + element+"_col");
        for (var k = 0; k < all_col.length; k++) {//exibe as colunas respostas
            all_col[k].style.display = "table-cell";
        }

        document.getElementById(element + "_head").style.display = "table-cell";//exibe a head
        document.getElementById(element + "_col").style.display = "table-cell";//exibe a coluna da ordem
        document.getElementById(element + "_table").style.display = "table-cell";//exibe table com as tabelas com as informações
        if (element === "ordem1") {
            document.getElementById(element + "_col2").style.display = "table-cell"
            document.getElementById(element + "_table2").style.display = "table-cell";
        }
    }
    hideShowOrdem(event) {
        this.setState({
            selectedOrdem: event.target.attributes[0].value
        });
        this.showOneHideAll(event.target.attributes[0].value);
    }
    render() {
        const pStyle = {
            color: '#DADADA'
        }
        return (
            <div>
                <div id="wrapper">
                    <SondagemClassSelected />
                </div>
            <table className="table table-sm table-bordered table-hover table-sondagem-matematica" style={{ overflow: "hidden", overflowX: "auto" }}>
                    <thead>
                        <tr>
                            <th rowSpan="5" className="align-middle border text-color-purple "><div className="ml-2">Sondagem - 2º ano</div></th>
                            <th colSpan="8" className="text-center border sondagem-matematica-title" id="ordem1_head"><span style={pStyle}>&#60;</span><b className="p-4">Ordem 1 - ideia: COMPOSIÇÃO</b><span value="ordem2" onClick={this.hideShowOrdem} className="testcursor">&#62;</span></th>
                            <th colSpan="8" className="text-center border sondagem-matematica-title" id="ordem2_head"><span value="ordem1" onClick={this.hideShowOrdem} className="testcursor">&#60;</span><b className="p-4">Ordem 2 - ideia: TRANFORMAÇÃO</b><span value="ordem3" onClick={this.hideShowOrdem} className="testcursor">&#62;</span></th>
                            <th colSpan="8" className="text-center border sondagem-matematica-title" id="ordem3_head"><span value="ordem2" onClick={this.hideShowOrdem} className="testcursor">&#60;</span><b className="p-4">Ordem 3 - ideia: PROPORCIONALIDADE</b><span style={pStyle}>&#62;</span></th>
                        </tr>
                        <tr>
                            <th colSpan="4" className="text-center border text-color-purple" id="ordem1_col"><small>Problemas 2º Bimestre</small></th>
                            <th colSpan="4" className="text-center border text-color-purple" id="ordem1_col2"><small>Problemas 4º Bimestre</small></th>
                            <th colSpan="8" className="text-center border text-color-purple" id="ordem2_col"><small>Problemas 2º e 4º Bimestre</small></th>
                            <th colSpan="8" className="text-center border text-color-purple" id="ordem3_col"><small>Problemas 2º e 4º Bimestre</small></th>
                        </tr>
                        <tr>
                            <th colSpan="4" id="ordem1_table">
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
                                            <small>?</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>Dada</small>
                                        </div>
                                    </div>
                                </div>
                            </th>
                            <th colSpan="4" id="ordem1_table2">
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
                                            <small>?</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>Dada</small>
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
                                            <small>Transformação</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>Estado final</small>
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
                            <th colSpan="8" id="ordem3_table">
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
                        </tr>
                        <tr>
                            <th colSpan="4" className="text-center border poll-select-container ordem1_col"><small className="text-muted">2ºB</small></th>
                            <th colSpan="4" className="text-center border poll-select-container ordem1_col"><small className="text-muted">4ºB</small></th>
                            <th colSpan="4" className="text-center border poll-select-container ordem2_col"><small className="text-muted">2ºB</small></th>
                            <th colSpan="4" className="text-center border poll-select-container ordem2_col"><small className="text-muted">4ºB</small></th>
                            <th colSpan="4" className="text-center border poll-select-container ordem3_col"><small className="text-muted">2ºB</small></th>
                            <th colSpan="4" className="text-center border poll-select-container ordem3_col"><small className="text-muted">4ºB</small></th>
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
                        </tr>
                    </thead>

                    <tbody>

                        {this.props.students.map(student => (
                            <StudentPollMath1A2A key={student.sequence} student={student} updatePollStudent={this.props.updatePollStudent} />
                        ))}

                    </tbody>
                </table>
                <LegendsRightWrong />
            </div>
        );
    }
}