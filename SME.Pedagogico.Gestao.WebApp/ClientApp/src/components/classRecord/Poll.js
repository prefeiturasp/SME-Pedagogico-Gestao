import React, { Component } from 'react';
import './Poll.css'
import Card from '../containers/Card';
import PollFilter from './PollFilter';

import { ClassRoomEnum } from '../polls/component/ClassRoomHelper'
import { connect } from 'react-redux';
import { actionCreators as actionCreatorsPoll } from '../../store/Poll';
import { bindActionCreators } from 'redux';

import StudentPollMathAlfabetizacaoCard from '../polls/StudentPollMathAlfabetizacaoCard'
import StudentPollMath1ACard from '../polls/StudentPollMath1ACard'
import StudentPollMath2ACard from '../polls/StudentPollMath2ACard'
import StudentPollMath3ACACard from '../polls/StudentPollMath3ACACard'
import StudentPollMath3ACMCard from '../polls/StudentPollMath3ACMCard'
import StudentPollMath4ACACard from '../polls/StudentPollMath4ACACard'
import StudentPollMath4ACMCard from '../polls/StudentPollMath4ACMCard'
import StudentPollMath5ACACard from '../polls/StudentPollMath5ACACard'
import StudentPollMath5ACMCard from '../polls/StudentPollMath5ACMCard'
import StudentPollMath6ACACard from '../polls/StudentPollMath6ACACard'
import StudentPollMath6ACMCard from '../polls/StudentPollMath6ACMCard'
import StudentPollPortugueseCard from '../polls/StudentPollPortugueseCard'

class Poll extends Component {
    constructor(props) {
        super(props);
        this.state = {
            pollStudents: [],
            navSelected: "",
            didAnswerPoll: false, //usar para perguntar para salvar sondagem
            sondagemType: ClassRoomEnum.ClassEmpty,//Retirar o default depois//PT,MT,1A,2A,3ACA,3ACM,4ACA,4ACM,5ACA,5ACM,6ACA,6ACM
        }

        this.updatePollStudent = this.updatePollStudent.bind(this);
        this.savePollStudent = this.savePollStudent.bind(this);

        this.toggleButton = this.toggleButton.bind(this);

        this.openPortuguesePoll = this.openPortuguesePoll.bind(this);
        this.openMathSubPoll = this.openMathSubPoll.bind(this);
        this.openMathBtnSubPoll = this.openMathBtnSubPoll.bind(this);
        this.openMathPoll = this.openMathPoll.bind(this);

        this.props.pollMethods.set_poll_info(null, null, null);
    }
    componentDidUpdate() {//ver em ClassPlan o método ClassRoomClick
        
        if (this.state.navSelected === "portugues-tab" && document.getElementById("portugues-tab") !== null && document.getElementById("matematica-tab") !== null) {
            document.getElementById("portugues-tab").className = "btn btn-outline-primary btn-sm btn-planning active";
            document.getElementById("matematica-tab").className = "btn btn-outline-primary btn-sm btn-planning";
        } else if (this.state.navSelected === "matematica-tab" && document.getElementById("portugues-tab") !== null && document.getElementById("matematica-tab") !== null) {
            document.getElementById("portugues-tab").className = "btn btn-outline-primary btn-sm btn-planning";
            document.getElementById("matematica-tab").className = "btn btn-outline-primary btn-sm btn-planning active";
        }
    }

    componentDidMount() {
     
    }
    
    updatePollStudent(sequence, subjectName, propertyName, value) {
        var pollStudents = this.state.pollStudents;
        for (var i = 0; i < pollStudents.length; i++) {
            if (pollStudents[i].studentCodeEol === sequence) {
                if (subjectName === "portuguese") {
                    switch (propertyName) {
                        case "t1e":
                            pollStudents[i].t1e = value;
                            break;
                        case "t1l":
                            pollStudents[i].t1l = value;
                            break;
                        case "t2e":
                            pollStudents[i].t2e = value;
                            break;
                        case "t2l":
                            pollStudents[i].t2l = value;
                            break;
                        case "t3e":
                            pollStudents[i].t3e = value;
                            break;
                        case "t3l":
                            pollStudents[i].t3l = value;
                            break;
                        case "t4e":
                            pollStudents[i].t4e = value;
                            break;
                        case "t4l":
                            pollStudents[i].t4l = value;
                            break;
                        default:
                            break;
                    }
                    break;
                } else if (subjectName === "mathalfabetizacao") {
                    switch (propertyName) {
                        case "familiares1S":
                            pollStudents[i].familiares1S = value;
                            break;
                        case "familiares2S":
                            pollStudents[i].familiares2S = value;
                            break;
                        case "opacos1S":
                            pollStudents[i].opacos1S = value;
                            break;
                        case "opacos2S":
                            pollStudents[i].opacos2S = value;
                            break;
                        case "transparentes1S":
                            pollStudents[i].transparentes1S = value;
                            break;
                        case "transparentes2S":
                            pollStudents[i].transparentes2S = value;
                            break;
                        case "terminamzero1S":
                            pollStudents[i].terminamzero1S = value;
                            break;
                        case "terminamzero2S":
                            pollStudents[i].terminamzero2S = value;
                            break;
                        case "algarismos1S":
                            pollStudents[i].algarismos1S = value;
                            break;
                        case "algarismos2S":
                            pollStudents[i].algarismos2S = value;
                            break;
                        case "processo1S":
                            pollStudents[i].processo1S = value;
                            break;
                        case "processo2S":
                            pollStudents[i].processo2S = value;
                            break;
                        case "zerointercalados1S":
                            pollStudents[i].zerointercalados1S = value;
                            break;
                        case "zerointercalados2S":
                            pollStudents[i].zerointercalados2S = value;
                            break;
                        default:
                            break;
                    }
                    break;
                } else if (subjectName === "math") {
                    switch (propertyName) {
                        case "orderm1Ideia1S":
                            pollStudents[i].orderm1Ideia1S = value;
                            break;
                        case "orderm1Resultado1S":
                            pollStudents[i].orderm1Resultado1S = value;
                            break;
                        case "orderm1Ideia2S":
                            pollStudents[i].orderm1Ideia2S = value;
                            break;
                        case "orderm1Resultado2S":
                            pollStudents[i].orderm1Resultado2S = value;
                            break;

                        case "orderm2Ideia1S":
                            pollStudents[i].orderm2Ideia1S = value;
                            break;
                        case "orderm2Resultado1S":
                            pollStudents[i].orderm2Resultado1S = value;
                            break;
                        case "orderm2Ideia2S":
                            pollStudents[i].orderm2Ideia2S = value;
                            break;
                        case "orderm2Resultado2S":
                            pollStudents[i].orderm2Resultado2S = value;
                            break;

                        case "orderm3Ideia1S":
                            pollStudents[i].orderm3Ideia1S = value;
                            break;
                        case "orderm3Resultado1S":
                            pollStudents[i].orderm3Resultado1S = value;
                            break;
                        case "orderm3Ideia2S":
                            pollStudents[i].orderm3Ideia2S = value;
                            break;
                        case "orderm3Resultado2S":
                            pollStudents[i].orderm3Resultado2S = value;
                            break;

                        case "orderm4Ideia1S":
                            pollStudents[i].orderm4Ideia1S = value;
                            break;
                        case "orderm4Resultado1S":
                            pollStudents[i].orderm4Resultado1S = value;
                            break;
                        case "orderm4Ideia2S":
                            pollStudents[i].orderm4Ideia2S = value;
                            break;
                        case "orderm4Resultado2S":
                            pollStudents[i].orderm4Resultado2S = value;
                            break;

                        case "orderm5Ideia1S":
                            pollStudents[i].orderm5Ideia1S = value;
                            break;
                        case "orderm5Resultado1S":
                            pollStudents[i].orderm5Resultado1S = value;
                            break;
                        case "orderm5Ideia2S":
                            pollStudents[i].orderm5Ideia2S = value;
                            break;
                        case "orderm5Resultado2S":
                            pollStudents[i].orderm5Resultado2S = value;
                            break;

                        case "orderm6Ideia1S":
                            pollStudents[i].orderm6Ideia1S = value;
                            break;
                        case "orderm6Resultado1S":
                            pollStudents[i].orderm6Resultado1S = value;
                            break;
                        case "orderm6Ideia2S":
                            pollStudents[i].orderm6Ideia2S = value;
                            break;
                        case "orderm6Resultado2S":
                            pollStudents[i].orderm6Resultado2S = value;
                            break;

                        case "orderm7Ideia1S":
                            pollStudents[i].orderm7Ideia1S = value;
                            break;
                        case "orderm7Resultado1S":
                            pollStudents[i].orderm7Resultado1S = value;
                            break;
                        case "orderm7Ideia2S":
                            pollStudents[i].orderm7Ideia2S = value;
                            break;
                        case "orderm7Resultado2S":
                            pollStudents[i].orderm7Resultado2S = value;
                            break;

                        case "orderm8Ideia1S":
                            pollStudents[i].orderm8Ideia1S = value;
                            break;
                        case "orderm8Resultado1S":
                            pollStudents[i].orderm8Resultado1S = value;
                            break;
                        case "orderm8Ideia2S":
                            pollStudents[i].orderm8Ideia2S = value;
                            break;
                        case "orderm8Resultado2S8Ideia2S":
                            pollStudents[i].orderm8Resultado2S8Ideia2S = value;
                            break;
                        default:
                            break;
                    }
                    break;
                }

            }
        }
        
        this.setState({ pollStudents: pollStudents });
        this.props.pollMethods.update_poll_students(pollStudents);
        //this.props.poll.students = pollStudents;
    }

    savePollStudent() {
        if (this.props.poll.pollSelected !== null) {
            if (this.props.poll.pollSelected === ClassRoomEnum.ClassPT) {
                var response = this.props.pollMethods.save_poll_portuguese_student(this.props.poll.students);
                debugger;
                alert(this.props.poll.pollSelected + response);
            } else if (this.props.poll.pollSelected === ClassRoomEnum.ClassMT) {
                //if number

                //if ordem
                alert(this.props.poll.pollSelected);
            } 
        } else {
            alert(this.props.poll.pollSelected);
        }
        console.log(this.props);
        
    }

    toggleButton(elementSeleted) {
        this.setState({
            navSelected: elementSeleted,
        });

        //debugger;
        
    }
    openPortuguesePoll(element) {
        this.toggleButton(element.currentTarget.id);
        //aqui vai ter que mudar de acordo com o ano que entrar...
        this.setState({
            sondagemType: ClassRoomEnum.ClassPT,
        });
        var test = {
            EolCode: "12345",
            Schoolyear: 2019

        };

        this.props.pollMethods.set_poll_info(ClassRoomEnum.ClassPT, "", "1"); //passar pollSelected, pollTypeSelected, pollYear
        this.props.pollMethods.get_poll_portuguese_students(test);
        this.setState({ pollStudents: this.props.poll.students });
    }
    
    openMathPoll(element) {
        this.toggleButton(element.currentTarget.id);
        this.setState({
            sondagemType: ClassRoomEnum.ClassMT,
        });
        this.openMathSubPoll();
        //alert("Poll Matematica");
    }

    openMathSubPoll() { 
        this.props.pollMethods.set_poll_info(ClassRoomEnum.ClassMT, "", "1"); //passar pollSelected, pollTypeSelected, pollYear
        this.props.pollMethods.get_poll_math_numbers_students();
        this.setState({ pollStudents: this.props.poll.students});
        debugger;
        //this.toggleButton(element.currentTarget.id);
        //literacyMathPoll
        //subMathPoll //1A 2A 3ACA 3ACM .. 6ACA 6ACM
    }

    openMathBtnSubPoll(element) {
        //disparar para atualizar o ano, tipo
        //this.props.pollMethods.set_poll_info(ClassRoomEnum.ClassMT, this.props.state.pollTypeSelected, "1"); 
        //metodo que o boao vai disparar //mudar nome
    }
    render() {
        var componentRender;
        var sondagemType = this.state.sondagemType;

        switch (sondagemType) {
            case ClassRoomEnum.Class1A:
                componentRender = <StudentPollMath1ACard students={this.state.pollStudents} updatePollStudent={this.updatePollStudent} />;
                break;
            case ClassRoomEnum.Class2A:
                componentRender = <StudentPollMath2ACard students={this.state.pollStudents} updatePollStudent={this.updatePollStudent} />;
                break;
            case ClassRoomEnum.Class3ACA:
                componentRender = <StudentPollMath3ACACard students={this.state.pollStudents} updatePollStudent={this.updatePollStudent} />;
                break;
            case ClassRoomEnum.Class3ACM:
                componentRender = <StudentPollMath3ACMCard students={this.state.pollStudents} updatePollStudent={this.updatePollStudent} />;
                break;
            case ClassRoomEnum.Class4ACA:
                componentRender = <StudentPollMath4ACACard students={this.state.pollStudents} updatePollStudent={this.updatePollStudent} />;
                break;
            case ClassRoomEnum.Class4ACM:
                componentRender = <StudentPollMath4ACMCard students={this.state.pollStudents} updatePollStudent={this.updatePollStudent} />;
                break;
            case ClassRoomEnum.Class5ACA:
                componentRender = <StudentPollMath5ACACard students={this.state.pollStudents} updatePollStudent={this.updatePollStudent} />;
                break;
            case ClassRoomEnum.Class5ACM:
                componentRender = <StudentPollMath5ACMCard students={this.state.pollStudents} updatePollStudent={this.updatePollStudent} />;
                break;
            case ClassRoomEnum.Class6ACA:
                componentRender = <StudentPollMath6ACACard students={this.state.pollStudents} updatePollStudent={this.updatePollStudent} />;
                break;
            case ClassRoomEnum.Class6ACM:
                componentRender = <StudentPollMath6ACMCard students={this.state.pollStudents} updatePollStudent={this.updatePollStudent} />;
                break;
            case ClassRoomEnum.ClassPT:
                componentRender = <StudentPollPortugueseCard students={this.state.pollStudents} updatePollStudent={this.updatePollStudent} />;
                break;
            case ClassRoomEnum.ClassMT:
                debugger;
                componentRender = <StudentPollMathAlfabetizacaoCard students={this.state.pollStudents} updatePollStudent={this.updatePollStudent} />;
                break;
            default:
                componentRender = "";

        }
        return (
            <>
                <Card className="mb-3">
                    <PollFilter />
                </Card> 
                <Card id="classRecord-poll">
                    <nav className="container-tabpanel navbar"><div className="form-inline">
                        <button className="btn btn-outline-primary btn-sm">[Em desenvolvimento]EF-1C - EMF - MARIA APARECIDA DO NASCIMENTO</button></div>
                        <ul className="nav navbar-nav ml-auto">
                            <li className="nav-item">
                                <div className="form-inline">
                                    <button className="btn btn-save text-white" onClick={this.savePollStudent} disabled="">Salvar</button></div>
                            </li>
                        </ul>
                    </nav>
                    <hr className="horizontal-rule bg-azul-ux" />
                    <ul className="nav" role="tablist">
                        <li className="nav-item">
                            <button className="btn btn-outline-primary btn-sm btn-planning" id="portugues-tab" onClick={this.openPortuguesePoll}>Língua Portuguesa</button>
                        </li>
                        <li className="nav-item">
                            <button className="btn btn-outline-primary btn-sm btn-planning" id="matematica-tab" onClick={this.openMathPoll}>Matem&aacute;tica</button>
                        </li>
                    </ul>


                    {componentRender}{/*renderiza o componente de sondagem correspondente*/}



                </Card>
            </>
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
)(Poll);