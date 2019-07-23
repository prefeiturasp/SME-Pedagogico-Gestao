import React, { Component } from 'react';
import StudentPollMath3ACM from '../polls/StudentPollMath3ACM'
import LegendsRightWrong from '../polls/component/LegendsRightWrong'
import SondagemClassSelected from '../polls/component/SondagemClassSelected'
//Sondagem Matmática 3 Ano CM
export default class StudentPollMath3ACMCard extends Component {
    constructor(props) {
        super(props);

        this.state = {
            selectedClass: "custom-select custom-select-sm poll-select",
            selectedOrdem: "ordem4"
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
        var allColumnToHide = ["ordem4", "ordem5"]
        var columnFiltered = allColumnToHide.filter((item) => item !== element)

        var all_col = document.getElementsByClassName("text-center border poll-select-container ");
        for (var i = 0; i < all_col.length; i++) { //esconde as colunas
            all_col[i].style.display = "none";
        }
        
        for (var j = 0; j < columnFiltered.length; j++) {
            document.getElementById(columnFiltered[j] + "_head").style.display = "none";//esconde head
            document.getElementById(columnFiltered[j] + "_table").style.display = "none";//esconde table com as tabelas com as informações
        }
        
        all_col = document.getElementsByClassName("text-center border poll-select-container " + element+"_col");
        for (var k = 0; k < all_col.length; k++) {//exibe as colunas respostas
            all_col[k].style.display = "table-cell";
        }

        document.getElementById(element + "_head").style.display = "table-cell";//exibe a head
        document.getElementById(element + "_table").style.display = "table-cell";//exibe table com as tabelas com as informações
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
        }
        return (
            <div>
                <div id="wrapper">
                   <SondagemClassSelected />
                </div>
            <table className="table table-sm table-bordered table-hover table-sondagem-matematica" style={{ overflow: "hidden", overflowX: "auto" }}>
                    <thead>
                        <tr>
                            <th rowSpan="5" className="align-middle border text-color-purple "><div className="ml-2">Sondagem - 3º ano | <b>Campo Multiplicativo</b></div></th>
                            <th colSpan="8" className="text-center border sondagem-matematica-title" id="ordem4_head"><span style={pStyle}><img src="./img/icon_mat_9975FF.svg" alt="seta esquerda" style={{ height: 20 }} /></span><b className="p-4">Ordem 4 - CONFIGURAÇÃO RETANGULAR</b><span value="ordem5" onClick={this.hideShowOrdem} className="testcursor"><img src="./img/icon_mat_FFFFFF.svg" alt="seta direita ativa" style={{ height: 20 }} /></span></th>
                            <th colSpan="8" className="text-center border sondagem-matematica-title" id="ordem5_head"><span value="ordem4" onClick={this.hideShowOrdem} className="testcursor"><img src="./img/icon_2_mat_FFFFFF.svg" alt="seta esquerda" style={{ height: 20 }} /></span><b className="p-4">Ordem 5 - PROPORCIONALIDADE</b><span style={pStyle}><img src="./img/icon_2_mat_9975FF.svg" alt="seta direita inativa" style={{ height: 20 }} /></span></th>
                        </tr>
                        <tr>
                            <th colSpan="8" id="ordem4_table">
                                <div className="container">
                                    <div className="row">
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
                                            <small>Dadas</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>Dadas</small>
                                        </div>
                                        <div className="col table-column-sondagem">
                                            <small>?</small>
                                        </div>
                                    </div>
                                </div>
                            </th>
                            <th colSpan="8" id="ordem5_table">
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
                            <th colSpan="4" className="text-center border poll-select-container ordem4_col"><small className="text-muted">1º Semestre</small></th>
                            <th colSpan="4" className="text-center border poll-select-container ordem4_col"><small className="text-muted">2º Semestre</small></th>
                            <th colSpan="4" className="text-center border poll-select-container ordem5_col"><small className="text-muted">1º Semestre</small></th>
                            <th colSpan="4" className="text-center border poll-select-container ordem5_col"><small className="text-muted">2º Semestre</small></th>
                        </tr>
                        <tr>
                            <th colSpan="2" className="text-center border poll-select-container ordem4_col"><small className="text-muted">Ideia</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem4_col"><small className="text-muted">Resultado</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem4_col"><small className="text-muted">Ideia</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem4_col"><small className="text-muted">Resultado</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem5_col"><small className="text-muted">Ideia</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem5_col"><small className="text-muted">Resultado</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem5_col"><small className="text-muted">Ideia</small></th>
                            <th colSpan="2" className="text-center border poll-select-container ordem5_col"><small className="text-muted">Resultado</small></th>
                        </tr>
                    </thead>

                    <tbody>

                        {this.props.students.map(student => (
                            <StudentPollMath3ACM key={student.studentCodeEol} student={student} updatePollStudent={this.props.updatePollStudent} editLock1S={this.props.editLock1S} editLock2S={this.props.editLock2S}/>
                        ))}

                    </tbody>
                </table>
                <LegendsRightWrong />
            </div>
        );
    }
}