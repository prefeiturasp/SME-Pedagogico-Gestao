import React, { Component } from 'react';
import StudentPollMathAlfabetizacao from '../polls/StudentPollMathAlfabetizacao'
import LegendsYesNo from '../polls/component/LegendsYesNo'
//Sondagem Matmática Alfabetização
//Falta o componente receber a lista de alunos
export default class StudentPollMathAlfabetizacaoCard extends Component {
    constructor(props) {
        super(props);

        this.state = {
            selectedClass: "custom-select custom-select-sm poll-select",
            selectedOrdem: "familiares_col"
        };
        this.hideShowOrdem = this.hideShowOrdem.bind(this);
        this.showOneHideAll = this.showOneHideAll.bind(this);
    }
    componentDidUpdate() {
        this.showOneHideAll(this.state.selectedOrdem);
    }
    showOneHideAll(element) {
        var allColumnToHide = ["familiares_col", "opacos_col", "transparentes_col", "zero_col", "algarismos_col", "processo_col", "zeros_col"];
        var columnFiltered = allColumnToHide.filter((item) => item !== element)

        var all_col = document.getElementsByClassName("text-center border poll-select-container ");
        for (var i = 0; i < all_col.length; i++) {
            all_col[i].style.display = "none";
        }

        for (var j = 0; j < columnFiltered.length; j++) {
            document.getElementById(columnFiltered[j] + "_head").style.display = "none";
        }

        all_col = document.getElementsByClassName("text-center border poll-select-container " + element);
        for (var k = 0; k < all_col.length; k++) {
            all_col[k].style.display = "table-cell";
        }
        document.getElementById(element + "_head").style.display = "table-cell";
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
        };
        return (
            <div>
                <div id="wrapper">
                    <LegendsYesNo />
                    <div>
                        <div className="btn-group mr-2 btn-group-sm" role="group" aria-label="First group">
                            <button type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-single active">Alfabetização</button>
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
                            <th rowSpan="2" className="align-middle border text-color-purple"><div className="ml-2"><small>Sondagem - Alfabetização</small></div></th>
                            <th colSpan="2" id="familiares_col_head" className="text-center border text-color-purple "><span style={pStyle}>&#60;</span><small className="p-4">Familiares ou frequentes</small><span value="opacos_col" onClick={this.hideShowOrdem}>&#62;</span></th>
                            <th colSpan="2" id="opacos_col_head" className="text-center border text-color-purple "><span value="familiares_col" onClick={this.hideShowOrdem}>&#60;</span><small className="p-4">Opacos</small><span value="transparentes_col" onClick={this.hideShowOrdem}>&#62;</span></th>
                            <th colSpan="2" id="transparentes_col_head" className="text-center border text-color-purple "><span value="opacos_col" onClick={this.hideShowOrdem}>&#60;</span><small className="p-4">Transparentes</small><span value="zero_col" onClick={this.hideShowOrdem}>&#62;</span></th>
                            <th colSpan="2" id="zero_col_head" className="text-center border text-color-purple "><span value="transparentes_col" onClick={this.hideShowOrdem}>&#60;</span><small className="p-4">Terminam em zero</small><span value="algarismos_col" onClick={this.hideShowOrdem}>&#62;</span></th>
                            <th colSpan="2" id="algarismos_col_head" className="text-center border text-color-purple "><span value="zero_col" onClick={this.hideShowOrdem}>&#60;</span><small className="p-4">Algarismos iguais</small><span value="processo_col" onClick={this.hideShowOrdem}>&#62;</span></th>
                            <th colSpan="2" id="processo_col_head" className="text-center border text-color-purple "><span value="algarismos_col" onClick={this.hideShowOrdem}>&#60;</span><small className="p-4">Processo de generalização</small><span value="zeros_col" onClick={this.hideShowOrdem}>&#62;</span></th>
                            <th colSpan="2" id="zeros_col_head" className="text-center border text-color-purple "><span value="processo_col" onClick={this.hideShowOrdem}>&#60;</span><small className="p-4">Zeros intercalados</small><span style={pStyle}>&#62;</span></th>
                        </tr>
                        <tr>
                            <th className="text-center border poll-select-container familiares_col"><small className="text-muted">2ºB</small></th>
                            <th className="text-center border poll-select-container familiares_col"><small className="text-muted">4ºB</small></th>
                            <th className="text-center border poll-select-container opacos_col"><small className="text-muted">2ºB</small></th>
                            <th className="text-center border poll-select-container opacos_col"><small className="text-muted">4ºB</small></th>
                            <th className="text-center border poll-select-container transparentes_col"><small className="text-muted">2ºB</small></th>
                            <th className="text-center border poll-select-container transparentes_col"><small className="text-muted">4ºB</small></th>
                            <th className="text-center border poll-select-container zero_col"><small className="text-muted">2ºB</small></th>
                            <th className="text-center border poll-select-container zero_col"><small className="text-muted">4ºB</small></th>
                            <th className="text-center border poll-select-container algarismos_col"><small className="text-muted">2ºB</small></th>
                            <th className="text-center border poll-select-container algarismos_col"><small className="text-muted">4ºB</small></th>
                            <th className="text-center border poll-select-container processo_col"><small className="text-muted">2ºB</small></th>
                            <th className="text-center border poll-select-container processo_col"><small className="text-muted">4ºB</small></th>
                            <th className="text-center border poll-select-container zeros_col"><small className="text-muted">2ºB</small></th>
                            <th className="text-center border poll-select-container zeros_col"><small className="text-muted">4ºB</small></th>
                        </tr>
                    </thead>

                    <tbody>

                        {this.props.students.map(student => (
                            <StudentPollMathAlfabetizacao key={student.sequence} student={student} updatePollStudent={this.props.updatePollStudent} />
                        ))}

                    </tbody>
                </table>
            </div>
        );
    }
}