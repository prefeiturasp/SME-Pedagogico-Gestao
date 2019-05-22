import React, { Component } from 'react';
import StudentPollMathAlfabetizacao from '../polls/StudentPollMathAlfabetizacao'
import LegendsYesNo from '../polls/component/LegendsYesNo'
import SondagemClassSelected from './component/SondagemClassSelected';
//Sondagem Matmática Alfabetização
//Falta o componente receber a lista de alunos
export default class StudentPollMathAlfabetizacaoCard extends Component {
    constructor(props) {
        super(props);

        this.state = {
            selectedClass: "custom-select custom-select-sm poll-select",
            selectedOrdem: "familiares_col",
            class:"1º ano" //1º/2º
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
            color: '#DADADA'
        };
        return (
            <div>
                <div id="wrapper">
                    <SondagemClassSelected />
                </div>
                <table className="table table-sm table-bordered table-hover table-sondagem-matematica" style={{ overflow: "hidden", overflowX: "auto" }}>
                    <thead>
                        <tr>
                            <th rowSpan="2" className="align-middle border text-color-purple"><div className="ml-2">Sondagem - {this.state.class} números</div></th>
                            <th colSpan="2" id="familiares_col_head" className="text-center border text-color-purple "><span style={pStyle}>&#60;</span><b className="p-4">Familiares ou frequentes</b><span value="opacos_col" onClick={this.hideShowOrdem} className="testcursor">&#62;</span></th>
                            <th colSpan="2" id="opacos_col_head" className="text-center border text-color-purple "><span value="familiares_col" onClick={this.hideShowOrdem} className="testcursor">&#60;</span><b className="p-4">Opacos</b><span value="transparentes_col" onClick={this.hideShowOrdem} className="testcursor">&#62;</span></th>
                            <th colSpan="2" id="transparentes_col_head" className="text-center border text-color-purple "><span value="opacos_col" onClick={this.hideShowOrdem} className="testcursor">&#60;</span><b className="p-4">Transparentes</b><span value="zero_col" onClick={this.hideShowOrdem} className="testcursor">&#62;</span></th>
                            <th colSpan="2" id="zero_col_head" className="text-center border text-color-purple "><span value="transparentes_col" onClick={this.hideShowOrdem} className="testcursor">&#60;</span><b className="p-4">Terminam em zero</b><span value="algarismos_col" onClick={this.hideShowOrdem} className="testcursor">&#62;</span></th>
                            <th colSpan="2" id="algarismos_col_head" className="text-center border text-color-purple "><span value="zero_col" onClick={this.hideShowOrdem} className="testcursor">&#60;</span><b className="p-4">Algarismos iguais</b><span value="processo_col" onClick={this.hideShowOrdem} className="testcursor">&#62;</span></th>
                            <th colSpan="2" id="processo_col_head" className="text-center border text-color-purple "><span value="algarismos_col" onClick={this.hideShowOrdem} className="testcursor">&#60;</span><b className="p-4">Processo de generalização</b><span value="zeros_col" onClick={this.hideShowOrdem} className="testcursor">&#62;</span></th>
                            <th colSpan="2" id="zeros_col_head" className="text-center border text-color-purple "><span value="processo_col" onClick={this.hideShowOrdem} className="testcursor">&#60;</span><b className="p-4">Zeros intercalados</b><span style={pStyle}>&#62;</span></th>
                        </tr>
                        <tr>
                            <th className="text-center border poll-select-container familiares_col"><small className="text-muted">1ºS</small></th>
                            <th className="text-center border poll-select-container familiares_col"><small className="text-muted">2ºS</small></th>
                            <th className="text-center border poll-select-container opacos_col"><small className="text-muted">1ºS</small></th>
                            <th className="text-center border poll-select-container opacos_col"><small className="text-muted">2ºS</small></th>
                            <th className="text-center border poll-select-container transparentes_col"><small className="text-muted">1ºS</small></th>
                            <th className="text-center border poll-select-container transparentes_col"><small className="text-muted">2ºS</small></th>
                            <th className="text-center border poll-select-container zero_col"><small className="text-muted">1ºS</small></th>
                            <th className="text-center border poll-select-container zero_col"><small className="text-muted">2ºS</small></th>
                            <th className="text-center border poll-select-container algarismos_col"><small className="text-muted">1ºS</small></th>
                            <th className="text-center border poll-select-container algarismos_col"><small className="text-muted">2ºS</small></th>
                            <th className="text-center border poll-select-container processo_col"><small className="text-muted">1ºS</small></th>
                            <th className="text-center border poll-select-container processo_col"><small className="text-muted">2ºS</small></th>
                            <th className="text-center border poll-select-container zeros_col"><small className="text-muted">1ºS</small></th>
                            <th className="text-center border poll-select-container zeros_col"><small className="text-muted">2ºS</small></th>
                        </tr>
                    </thead>

                    <tbody>

                        {this.props.students.map(student => (
                            <StudentPollMathAlfabetizacao key={student.sequence} student={student} updatePollStudent={this.props.updatePollStudent} />
                        ))}

                    </tbody>
                </table>
                <LegendsYesNo />
            </div>
        );
    }
}