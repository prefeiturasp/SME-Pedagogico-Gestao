import React, { Component } from 'react';
import { connect } from 'react-redux';
import { actionCreators as actionCreatorsPoll } from '../../store/Poll';
import { bindActionCreators } from 'redux';

import StudentPollPortuguese from '../polls/StudentPollPortuguese'
import StudentPollPortuguese3A from '../polls/StudentPollPortuguese3A'
import StudentPollPortuguese3ANivelHipotese from '../polls/StudentPollPortuguese3ANivelHipotese'
import LegendsReadWrite from '../polls/component/LegendsReadWrite'
import LegendsReadWrite3A from '../polls/component/LegendsReadWrite3A'

class StudentPollPortugueseCard extends Component {
    constructor(props) {
        super(props);

        this.state = {
            selectedClass: "custom-select custom-select-sm poll-select",
            selectedOrdem: "1bim_col",
            bimestreSelecionado: "1bim_col",
            segundoBimestre: 2,
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
        var allColumnToHide = ["1bim_col", "2bim_col", "3bim_col","4bim_col"]
        var columnFiltered = allColumnToHide.filter((item) => item !== element)
        
        var all_col = document.getElementsByClassName("text-center border poll-select-container ");
        for (var i = 0; i < all_col.length; i++) {
            all_col[i].style.display = "none";
        }

        for (var j = 0; j < columnFiltered.length; j++) {
            document.getElementById(columnFiltered[j]+ "_head").style.display = "none";
        }
                                                    
        all_col = document.getElementsByClassName("text-center border poll-select-container " + element);
        for (var k = 0; k < all_col.length; k++) {
            all_col[k].style.display = "table-cell";
        }
        
        document.getElementById(element + "_head").style.display = "table-cell";

    }
    hideShowOrdem(event) {
        this.setState({ 
            selectedOrdem: event.currentTarget.attributes[0].value,
            bimestreSelecionado: event.currentTarget.attributes[0].value
        });
        this.showOneHideAll(event.currentTarget.attributes[0].value);
    }
    render() {
        var componentLegendRender, rendererStudentPollPortuguese;
        var anoLetivo = 2023;
        const pStyle = {
            color: '#DADADA'
        };

        if (this.props.poll.pollYear === "3" && this.props.poll.selectedFilter.schoolYear <= anoLetivo && this.state.bimestreSelecionado === "1bim_col") {
            componentLegendRender = <LegendsReadWrite3A />
            rendererStudentPollPortuguese = this.props.students.map(student => (
                <StudentPollPortuguese3A key={student.sequenceNumber} student={student} updatePollStudent={this.props.updatePollStudent} editLock1b={this.props.editLock1b} editLock2b={this.props.editLock2b} editLock3b={this.props.editLock3b} editLock4b={this.props.editLock4b}/>
            ));
        } else if (this.props.poll.pollYear === "3" && this.props.poll.selectedFilter.schoolYear <= anoLetivo && parseInt(this.state.bimestreSelecionado.slice(0, 1)) >= this.state.segundoBimestre){
            componentLegendRender = <LegendsReadWrite />;
            rendererStudentPollPortuguese = this.props.students.map(student => (
                <StudentPollPortuguese3ANivelHipotese key={student.sequenceNumber} student={student} updatePollStudent={this.props.updatePollStudent} editLock1b={this.props.editLock1b} editLock2b={this.props.editLock2b} editLock3b={this.props.editLock3b} editLock4b={this.props.editLock4b}/>
            ));
        }else {
            componentLegendRender = <LegendsReadWrite />;
            rendererStudentPollPortuguese = this.props.students.map(student => (
                <StudentPollPortuguese key={student.sequenceNumber} student={student} updatePollStudent={this.props.updatePollStudent} editLock1b={this.props.editLock1b} editLock2b={this.props.editLock2b} editLock3b={this.props.editLock3b} editLock4b={this.props.editLock4b}/>
            ));    
        }

        return (
            <div>
                <table className="table table-sm table-bordered table-hover table-sondagem-matematica" style={{ overflow: "hidden", overflowX: "auto" }}>
                    <thead>
                        <tr>
                            <th rowSpan="2" className="align-middle border text-color-purple"><div className="ml-2">Sondagem</div></th>
                            <th colSpan="2" id="1bim_col_head" className="text-center border text-color-purple "><span style={pStyle}><img src="./img/icon_pt_DADADA.svg" alt="seta esquerda inativa" style={{ height: 20 }} /></span><b className="p-4">1° Bimestre</b><span value="2bim_col" onClick={this.hideShowOrdem} className="testcursor"><img src="./img/icon_pt_7C4DFF.svg" alt="seta direita ativa" style={{height:20}}/></span></th>
                            <th colSpan="2" id="2bim_col_head" className="text-center border text-color-purple "><span value="1bim_col" onClick={this.hideShowOrdem} className="testcursor"><img src="./img/icon_2_pt_7C4DFF.svg" alt="seta esquerda ativa" style={{ height: 20 }} /></span><b className="p-4">2° Bimestre</b><span value="3bim_col" onClick={this.hideShowOrdem} className="testcursor"><img src="./img/icon_pt_7C4DFF.svg" alt="seta direita ativa" style={{ height: 20 }} /></span></th>
                            <th colSpan="2" id="3bim_col_head" className="text-center border text-color-purple "><span value="2bim_col" onClick={this.hideShowOrdem} className="testcursor"><img src="./img/icon_2_pt_7C4DFF.svg" alt="seta esquerda ativa" style={{ height: 20 }} /></span><b className="p-4">3° Bimestre</b><span value="4bim_col" onClick={this.hideShowOrdem} className="testcursor"><img src="./img/icon_pt_7C4DFF.svg" alt="seta direita inativa" style={{ height: 20 }} /></span></th>
                            <th colSpan="2" id="4bim_col_head" className="text-center border text-color-purple "><span value="3bim_col" onClick={this.hideShowOrdem} className="testcursor"><img src="./img/icon_2_pt_7C4DFF.svg" alt="seta esquerda ativa" style={{ height: 20 }} /></span><b className="p-4">4° Bimestre</b><span style={pStyle}><img src="./img/icon_2_pt_DADADA.svg" alt="seta direita inativa"  style={{height:20}}/></span></th>
                        </tr>
                        <tr>
                            <th className="text-center border poll-select-container 1bim_col"><small className="text-muted">Escrita</small></th>
                            <th className="text-center border poll-select-container 1bim_col"><small className="text-muted">Leitura</small></th>
                            <th className="text-center border poll-select-container 2bim_col"><small className="text-muted">Escrita</small></th>
                            <th className="text-center border poll-select-container 2bim_col"><small className="text-muted">Leitura</small></th>
                            <th className="text-center border poll-select-container 3bim_col"><small className="text-muted">Escrita</small></th>
                            <th className="text-center border poll-select-container 3bim_col"><small className="text-muted">Leitura</small></th>
                            <th className="text-center border poll-select-container 4bim_col"><small className="text-muted">Escrita</small></th>
                            <th className="text-center border poll-select-container 4bim_col"><small className="text-muted">Leitura</small></th>
                        </tr>
                    </thead>

                    <tbody>

                        {rendererStudentPollPortuguese}

                    </tbody>
                </table>
                
                {componentLegendRender}
                    
                
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
)(StudentPollPortugueseCard);