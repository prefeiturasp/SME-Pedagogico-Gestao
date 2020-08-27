import React, { Component } from 'react';
import StudentPollMathAlfabetizacao from '../polls/StudentPollMathAlfabetizacao'
import LegendsYesNo from '../polls/component/LegendsYesNo'
import SondagemClassSelected from './component/SondagemClassSelected';

import { connect } from 'react-redux';
import { actionCreators as actionCreatorsPoll } from '../../store/Poll';
import { bindActionCreators } from 'redux';

//Sondagem Matmática Alfabetização
class StudentPollMathAlfabetizacaoCard extends Component {
    constructor(props) {
        super(props);

        this.state = {
            selectedClass: "custom-select custom-select-sm poll-select",
            selectedOrdem: "familiares_col",
            class:this.props.poll.pollYear //1º/2º setar o ano do aluno
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
            selectedOrdem: event.currentTarget.attributes[0].value
        });
        this.showOneHideAll(event.currentTarget.attributes[0].value);
    }
    render() {
        const pStyle = {
            color: '#DADADA'
        };
        var pollYear = this.props.poll.pollYear;
        return (
            <div>
                <div id="wrapper">
                    <SondagemClassSelected />
                </div>
                <table className="table table-sm table-bordered table-hover table-sondagem-matematica" style={{ overflow: "hidden", overflowX: "auto" }}>
                    <thead>
                        <tr>
                            <th rowSpan="2" className="align-middle border text-color-purple"><div className="ml-2">Sondagem - {pollYear}º ano | Números</div></th>
                            <th colSpan="2" id="familiares_col_head" className="text-center border text-color-purple "><span style={pStyle}><img src="./img/icon_pt_DADADA.svg" alt="seta esquerda inativa" style={{ height: 20 }} /> </span><b className="p-4">Familiares ou Frequentes</b><span value="opacos_col" onClick={this.hideShowOrdem} className="testcursor"><img src="./img/icon_pt_7C4DFF.svg" alt="seta direita ativa" style={{ height: 20 }} /></span></th>
                            <th colSpan="2" id="opacos_col_head" className="text-center border text-color-purple "><span value="familiares_col" onClick={this.hideShowOrdem} className="testcursor"><img src="./img/icon_2_pt_7C4DFF.svg" alt="seta esquerda ativa" style={{ height: 20 }} /></span><b className="p-4">Opacos</b><span value="transparentes_col" onClick={this.hideShowOrdem} className="testcursor"><img src="./img/icon_pt_7C4DFF.svg" alt="seta direita ativa" style={{ height: 20 }} /></span></th>
                            <th colSpan="2" id="transparentes_col_head" className="text-center border text-color-purple "><span value="opacos_col" onClick={this.hideShowOrdem} className="testcursor"><img src="./img/icon_2_pt_7C4DFF.svg" alt="seta esquerda ativa" style={{ height: 20 }} /></span><b className="p-4">Transparentes</b><span value="zero_col" onClick={this.hideShowOrdem} className="testcursor"><img src="./img/icon_pt_7C4DFF.svg" alt="seta direita ativa" style={{ height: 20 }} /></span></th>
                            <th colSpan="2" id="zero_col_head" className="text-center border text-color-purple "><span value="transparentes_col" onClick={this.hideShowOrdem} className="testcursor"><img src="./img/icon_2_pt_7C4DFF.svg" alt="seta esquerda ativa" style={{ height: 20 }} /></span><b className="p-4">Terminam em Zero</b><span value="algarismos_col" onClick={this.hideShowOrdem} className="testcursor"><img src="./img/icon_pt_7C4DFF.svg" alt="seta direita ativa" style={{ height: 20 }} /></span></th>
                            <th colSpan="2" id="algarismos_col_head" className="text-center border text-color-purple "><span value="zero_col" onClick={this.hideShowOrdem} className="testcursor"><img src="./img/icon_2_pt_7C4DFF.svg" alt="seta esquerda ativa" style={{ height: 20 }} /></span><b className="p-4">Algarismos Iguais</b><span value="processo_col" onClick={this.hideShowOrdem} className="testcursor"><img src="./img/icon_pt_7C4DFF.svg" alt="seta direita ativa" style={{ height: 20 }} /></span></th>
                            <th colSpan="2" id="processo_col_head" className="text-center border text-color-purple "><span value="algarismos_col" onClick={this.hideShowOrdem} className="testcursor"><img src="./img/icon_2_pt_7C4DFF.svg" alt="seta esquerda ativa" style={{ height: 20 }} /></span><b className="p-4">Processo de Generalização</b><span value="zeros_col" onClick={this.hideShowOrdem} className="testcursor"><img src="./img/icon_pt_7C4DFF.svg" alt="seta direita ativa" style={{ height: 20 }} /></span></th>
                            <th colSpan="2" id="zeros_col_head" className="text-center border text-color-purple "><span value="processo_col" onClick={this.hideShowOrdem} className="testcursor"><img src="./img/icon_2_pt_7C4DFF.svg" alt="seta esquerda ativa" style={{ height: 20 }} /></span><b className="p-4">Zero Intercalado</b><span style={pStyle}><img src="./img/icon_2_pt_DADADA.svg" alt="seta direita inativa" style={{ height: 20 }} /></span></th>
                        </tr>
                        <tr>
                            <th className="text-center border poll-select-container familiares_col"><small className="text-muted">1º Semestre</small></th>
                            <th className="text-center border poll-select-container familiares_col"><small className="text-muted">2º Semestre</small></th>
                            <th className="text-center border poll-select-container opacos_col"><small className="text-muted">1º Semestre</small></th>
                            <th className="text-center border poll-select-container opacos_col"><small className="text-muted">2º Semestre</small></th>
                            <th className="text-center border poll-select-container transparentes_col"><small className="text-muted">1º Semestre</small></th>
                            <th className="text-center border poll-select-container transparentes_col"><small className="text-muted">2º Semestre</small></th>
                            <th className="text-center border poll-select-container zero_col"><small className="text-muted">1º Semestre</small></th>
                            <th className="text-center border poll-select-container zero_col"><small className="text-muted">2º Semestre</small></th>
                            <th className="text-center border poll-select-container algarismos_col"><small className="text-muted">1º Semestre</small></th>
                            <th className="text-center border poll-select-container algarismos_col"><small className="text-muted">2º Semestre</small></th>
                            <th className="text-center border poll-select-container processo_col"><small className="text-muted">1º Semestre</small></th>
                            <th className="text-center border poll-select-container processo_col"><small className="text-muted">2º Semestre</small></th>
                            <th className="text-center border poll-select-container zeros_col"><small className="text-muted">1º Semestre</small></th>
                            <th className="text-center border poll-select-container zeros_col"><small className="text-muted">2º Semestre</small></th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.props.students.map(student =>
                            <StudentPollMathAlfabetizacao key={student.studentCodeEol} student={student} updatePollStudent={this.props.updatePollStudent} editLock1S={this.props.editLock1S} editLock2S={this.props.editLock2S}/>
                        )}
                    </tbody>
                </table>
                <LegendsYesNo />
            </div>
        );
    }
}

export default connect(
    state => (
        {
            poll: state.poll
        }
    ),
    dispatch => (
        {
            pollMethods: bindActionCreators(actionCreatorsPoll, dispatch)
        }
    )
)(StudentPollMathAlfabetizacaoCard);