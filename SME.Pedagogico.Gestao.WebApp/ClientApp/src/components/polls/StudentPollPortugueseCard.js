import React, { Component } from 'react';
import StudentPollPortuguese from '../polls/StudentPollPortuguese'
import LegendsReadWrite from '../polls/component/LegendsReadWrite'
//Sondagem Portugues
//verificar novamente as turmas que a sondagem de portugues será aplicada
//Falta o componente receber a lista de alunos
export default class StudentPollPortugueseCard extends Component {
    constructor(props) {
        super(props);

        this.state = {
            selectedClass: "custom-select custom-select-sm poll-select",
            selectedOrdem: "1bim_col"
        };
        this.hideShowOrdem = this.hideShowOrdem.bind(this);
        this.showOneHideAll = this.showOneHideAll.bind(this);
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
                    <LegendsReadWrite />
                    <div>
                        <div className="btn-group mr-2 btn-group-sm" role="group" aria-label="First group">
                            <button type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-single active">Português</button>
                        </div>
                        
                    </div>
                </div>
             <table className="table table-sm table-bordered table-hover table-sondagem-matematica" style={{ overflow: "hidden", overflowX: "auto" }}>
                    <thead>
                        <tr>
                            <th rowSpan="2" className="align-middle border text-color-purple"><div className="ml-2"><small><b>Sondagem</b></small></div></th>
                            <th colSpan="2" id="1bim_col_head" className="text-center border text-color-purple "><span style={pStyle}>&#60;</span><small><b className="p-4">1° Bimestre</b></small><span value="2bim_col" onClick={this.hideShowOrdem}>&#62;</span></th>
                            <th colSpan="2" id="2bim_col_head" className="text-center border text-color-purple "><span value="1bim_col" onClick={this.hideShowOrdem}>&#60;</span><small><b className="p-4">2° Bimestre</b></small><span value="3bim_col" onClick={this.hideShowOrdem}>&#62;</span></th>
                            <th colSpan="2" id="3bim_col_head" className="text-center border text-color-purple "><span value="2bim_col" onClick={this.hideShowOrdem}>&#60;</span><small><b className="p-4">3° Bimestre</b></small><span value="4bim_col" onClick={this.hideShowOrdem}>&#62;</span></th>
                            <th colSpan="2" id="4bim_col_head" className="text-center border text-color-purple "><span value="3bim_col" onClick={this.hideShowOrdem}>&#60;</span><small><b className="p-4">4° Bimestre</b></small><span style={pStyle}>&#62;</span></th>
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

                        {this.props.students.map(student => (
                            <StudentPollPortuguese key={student.sequence} student={student} updatePollStudent={this.props.updatePollStudent} />
                        ))}

                    </tbody>
                </table>
            </div>
        );
    }
}