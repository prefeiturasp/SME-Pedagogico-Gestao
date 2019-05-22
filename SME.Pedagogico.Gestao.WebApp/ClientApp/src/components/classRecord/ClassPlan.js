import React, { Component } from 'react';
import ClasPlanCss from './ClassPlan.css';
import Card from '../containers/Card';
import { connect } from 'react-redux';
import { actionCreators as actionCreatorsFrequency } from '../../store/Frequency';
import { actionCreators as actionCreatorsUser } from '../../store/User';
import { actionCreators as actionCreatorsClassRoom } from '../../store/ClassRoomStudents';
import { bindActionCreators } from 'redux';
import { RichTextBox } from '../inputs/RichTextBox';
import { EditorState } from 'draft-js';
import StudentFrequency from './StudentFrequency';
import StudentFrequencyInformation from './StudentFrequencyInformation';


class ClassPlan extends Component {

    constructor() {
        super();
        this.students = [];

        console.log(this.props, 'xxx')
        this.state = {
            checkFrequency: false,
            disabled: false, // pegar do plano de aula se o dia da aula for maior que a data atual
            numberLessons: 5 // pegar do plano de aula a quantidade de aulas de cada plano
        }

        this.checkboxChange = this.checkboxChange.bind(this);
        this.testClick = this.testClick.bind(this);
        this.disabledCheck = this.disabledCheck.bind(this);
        this.ClassRoomClick = this.ClassRoomClick.bind(this);
    }

    componentDidMount() {
        this.props.frequency.getStudents();

        this.checkFrequency = this.props.frequencyState.effectFrequency.checked;
        this.students = this.props.frequencyState.students.sort(function (a, b) {
            if (a.numeroAlunoChamada > b.numeroAlunoChamada)
                return (1);
            if (a.numeroAlunoChamada < b.numeroAlunoChamada)
                return (-1);

            return (0);
        });

    }


    checkboxChange(event) {

        var bool = event.target.checked;

        if (event.target.attributes.id.value == 'CheckFrequency') {
            const eff = {
                checked: bool
            }
            this.props.frequency.frequencyeffect(eff);
        }
        else {
            var listStudants = this.props.frequencyState.students;
            var codigoAluno = event.target.attributes.codigoAluno.value;
            var student = this.students.filter((item) => item.codigoAluno == codigoAluno);
            if (bool) {
                student[0].qtdFaltas += 1
            }
            else {
                student[0].qtdFaltas -= 1
            }
            var students = this.students;
            this.setState({ students: students })
            const eff = {
                students: this.students,
                checked: true
            }
            this.props.frequency.frequencyeffect(eff);
        }
    }

    testClick() {

        const eff = {
            students: this.students,
            checked: this.props.frequencyState.effectFrequency.checked
        }
        alert('Teste');
        this.props.frequency.frequencyeffect(eff);
    }

    ClassRoomClick() {
        var test = {
            EolCode: "12345",
            Schoolyear: 2019

        };
        this.props.classRoomStudents.get_classroom_students(test);
        var list = this.props.classRoomStudentsState.classRoom;
        debugger;

    }

    disabledCheck(event) {

        var bool = event.target.checked;

        this.setState({
            disabled: bool
        })
    }


    render() {

        return (

            <Card id="classRecord-classPlan">

                <div id="classRoom">
                    <button onClick={this.ClassRoomClick}>Click aqui meu jovem!</button>
                    <div> </div>

                </div>


                <div id="frequency">
                    <div className="btn buttom">
                        <button className="btn btn-warning text-white" id="btnSalvar" onClick={this.testClick}>Salvar</button>
                    </div>
                    <div className="d-flex flex-row-reverse form-check form-check-inline">
                        <div className="test cardEf p-2 custom-control custom-checkbox">
                            <span className="cardEf ">Data futura</span>
                            <input type="checkbox" className="custom-control-input" onChange={this.disabledCheck} id="CheckDisabled" name="CheckDisabled" />
                            <label className="custom-control-label" htmlFor="CheckDisabled"></label>
                        </div>
                    </div>
                    <div className="d-flex btn align-items-center" data-toggle="collapse" href="#multiCollapseExample0" role="button" aria-expanded="false" aria-controls="multiCollapseExample0">
                        <h5 className="font-weight-light text-color-purple">Frequência (preenchimento obrigatório)</h5>

                        <div className="d-flex flex-fill flex-row-reverse">
                            <i className="fas fa-chevron-circle-down text-secondary"></i>
                        </div>
                    </div>
                    <div id="multiCollapseExample0" className="collapse">
                        <hr className="header-rule" />
                        <div className="d-flex flex-row-reverse form-check form-check-inline">
                            <div className="test cardEf p-2 custom-control custom-checkbox">
                                <span className="cardEf ">Frequência Efetivada</span>
                                <input type="checkbox" className="custom-control-input" onChange={this.checkboxChange} disabled={this.state.disabled} checked={this.props.frequencyState.effectFrequency.checked} id="CheckFrequency" name="CheckFrequency" />
                                <label className="custom-control-label" htmlFor="CheckFrequency"></label>
                            </div>
                        </div>

                        <div id="tableFrequency">
                            <div className="table-responsive">
                                <table className="table table-sm table-bordered table-hover">
                                    <thead>
                                        <tr>
                                            <th scope="col"></th>
                                            <th scope="col"><i className="text-center fas fa-sort-numeric-down font-weight-light text-color-purple"></i></th>
                                            <th scope="col"><i className="text-center fas fa-sort-alpha-down font-weight-light text-color-purple"></i></th>
                                            <th scope="col"><span className="text-center font-weight-light text-color-purple">Faltas</span></th>
                                            <th scope="col"><span className="text-center font-weight-light text-color-purple">%Aula</span></th>
                                            <th scope="col" bgcolor="white" ><span className=" text-center font-weight-light text-color-purple">Avisos</span></th>
                                        </tr>

                                    </thead>
                                    {this.students.map(student => (<tbody key={student.numeroAluno}>
                                        <StudentFrequency
                                            student={student}
                                            numberLessons={this.numberLessons}
                                            checkFrequency={this.checkFrequency}
                                            checkboxChange={this.checkboxChange}
                                            disabled={this.state.disabled}
                                            numberLessons={this.state.numberLessons}
                                        />
                                        <tr className="collapse" id={"collapseExample" + student.codigoAluno}>
                                            <StudentFrequencyInformation student={student} />
                                        </tr>
                                    </tbody>
                                    ))}
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="desenvolvimentoAula">
                    <div className="d-flex btn align-items-center" data-toggle="collapse" href="#multiCollapseExample1" role="button" aria-expanded="false" aria-controls="multiCollapseExample1">
                        <h5 className="font-weight-light text-color-purple">Desenvolvimento da aula</h5>

                        <div className="d-flex flex-fill flex-row-reverse">
                            <i className="fas fa-chevron-circle-down text-secondary"></i>
                        </div>
                    </div>

                    <hr className="header-rule" />

                    <div id="multiCollapseExample1" className="collapse">
                        <RichTextBox name="desenvolvimentoAula" value={EditorState.createEmpty()} />
                    </div>
                </div>

            </Card>


        );
    }
}
export default connect(
    state => (
        {
            frequencyState: state.frequency,
            user: state.user,
            classRoomStudentsState: state.classRoomStudents
        }
    ),
    dispatch => (
        {
            frequency: bindActionCreators(actionCreatorsFrequency, dispatch),
            user: bindActionCreators(actionCreatorsUser, dispatch),
            classRoomStudents: bindActionCreators(actionCreatorsClassRoom, dispatch)
        }
    )
)(ClassPlan);