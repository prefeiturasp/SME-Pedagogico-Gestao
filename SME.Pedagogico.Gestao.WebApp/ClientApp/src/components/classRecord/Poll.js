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
            navSelected: "",
            didAnswerPoll: false, //usar para perguntar para salvar sondagem
            sondagemType: ClassRoomEnum.ClassEmpty,//Retirar o default depois//PT,MT,1A,2A,3ACA,3ACM,4ACA,4ACM,5ACA,5ACM,6ACA,6ACM
        }

        this.updatePollStudent = this.updatePollStudent.bind(this);
        this.savePollStudent = this.savePollStudent.bind(this);

        this.toggleButton = this.toggleButton.bind(this);

        this.openPortuguesePoll = this.openPortuguesePoll.bind(this);
        this.openMathSubPoll = this.openMathSubPoll.bind(this);
        this.openMathPoll = this.openMathPoll.bind(this);

        
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
        this.props.pollMethods.set_poll_info(null, null, null);
    }
    
    updatePollStudent(sequence, subjectName, propertyName, value) {
        if (this.props.poll.pollSelected === ClassRoomEnum.ClassPT) {
            var pollStudents = this.props.poll.students;
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
                    }
                }
            }
            //this.setState({ pollStudents: pollStudents });
            this.props.pollMethods.update_poll_students(pollStudents);

        } else if (this.props.poll.pollSelected === ClassRoomEnum.ClassMT) {
            if (this.props.poll.pollTypeSelected === "Numeric") {
                var pollStudents = this.props.poll.studentsPollMathNumbers;
                for (var i = 0; i < pollStudents.length; i++) {
                    if (pollStudents[i].studentCodeEol === sequence) {
                        if (subjectName === "mathalfabetizacao") {
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
                        }
                    }
                }
                //this.setState({ pollStudents: pollStudents });
                this.props.pollMethods.update_poll_math_numbers_students(pollStudents);
            } else if (this.props.poll.pollTypeSelected === "CA") {
                var pollStudents = this.props.poll.studentsPollMathCA;
                for (var i = 0; i < pollStudents.length; i++) {
                    if (pollStudents[i].studentCodeEol === sequence) {
                        if (subjectName === "math") {
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
                //this.setState({ pollStudents: pollStudents });
                this.props.pollMethods.update_poll_math_ca_students(pollStudents);
            } else if (this.props.poll.pollTypeSelected === "CM") {
                var pollStudents = this.props.poll.studentsPollMathCM;
                for (var i = 0; i < pollStudents.length; i++) {
                    if (pollStudents[i].studentCodeEol === sequence) {
                        if (subjectName === "math") {
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
                //this.setState({ pollStudents: pollStudents });
                this.props.pollMethods.update_poll_math_cm_students(pollStudents);
            }

        }
    }

    savePollStudent() {
        if (this.props.poll.pollSelected !== null) {
            if (this.props.poll.pollSelected === ClassRoomEnum.ClassPT) {
                var response = this.props.pollMethods.save_poll_portuguese_student(this.props.poll.students);
            } else if (this.props.poll.pollSelected === ClassRoomEnum.ClassMT) {
                if (this.props.poll.pollTypeSelected === "Numeric") {
                    console.log(this.props.poll.studentsPollMathNumbers);
                    var response = this.props.pollMethods.save_poll_math_numbers_students(this.props.poll.studentsPollMathNumbers);
                } else if (this.props.poll.pollTypeSelected === "CA") {
                    console.log(this.props.poll.studentsPollMathCA);
                    var response = this.props.pollMethods.save_poll_math_ca_students(this.props.poll.studentsPollMathCA);
                } else if (this.props.poll.pollTypeSelected === "CM") {
                    console.log(this.props.poll.studentsPollMathCM);
                    var response = this.props.pollMethods.save_poll_math_cm_students(this.props.poll.studentsPollMathCM);
                } 
                debugger;
                console.log(response);
                console.log(this.props.poll.pollSelected);
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

        
        
    }
    openPortuguesePoll(element) {
        this.toggleButton(element.currentTarget.id);
        //aqui vai ter que mudar de acordo com o ano que entrar...
        this.setState({
            sondagemType: ClassRoomEnum.ClassPT,
        });
        var classRoomMock = {
            "dreCodeEol": "4",
            "schoolCodeEol": "44",
            "classroomCodeEol": "1992661",
            "schoolYear": "2019",
            "yearClassroom": "1"
        } 


        this.props.pollMethods.set_poll_info(this.state.sondagemType, "", classRoomMock.yearClassroom); //passar pollSelected, pollTypeSelected, pollYear
        this.props.pollMethods.get_poll_portuguese_students(classRoomMock);
        this.setState({
            pollStudents: this.props.poll.students,
        });
    }
    
    openMathPoll(element) {
        this.toggleButton(element.currentTarget.id);
        this.openMathSubPoll();
    }

    openMathSubPoll() {
        var classRoomMock = {
            "dreCodeEol": "108100 ",
            "schoolCodeEol": "000191",
            "classroomCodeEol": "1996399",
            "schoolYear": "2019",
            "yearClassroom": "1"
        }

        if (classRoomMock.yearClassroom === "1" || classRoomMock.yearClassroom === "2" || classRoomMock.yearClassroom === "3") {
            this.props.pollMethods.set_poll_info(ClassRoomEnum.ClassMT, "Numeric", classRoomMock.yearClassroom); //passar pollSelected, pollTypeSelected, pollYear
        } else {
            this.props.pollMethods.set_poll_info(ClassRoomEnum.ClassMT, "CA", classRoomMock.yearClassroom); //passar pollSelected, pollTypeSelected, pollYear
        }
        this.setState({
            sondagemType: this.props.poll.pollSelected,
        });


        if (this.props.poll.pollTypeSelected === "Numeric") {
            debugger;
            this.props.pollMethods.get_poll_math_numbers_students(classRoomMock);
        } else if (this.props.poll.pollTypeSelected === "CA") {
            debugger;
            this.props.pollMethods.get_poll_math_ca_students(classRoomMock);
        } else if (this.props.poll.pollTypeSelected === "CM") {
            debugger;
            this.props.pollMethods.get_poll_math_cm_students(classRoomMock);
        } 

        
        //this.setState({ pollStudents: this.props.poll.students});
        
        debugger;
        //this.toggleButton(element.currentTarget.id);
        //literacyMathPoll
        //subMathPoll //1A 2A 3ACA 3ACM .. 6ACA 6ACM
    }

    render() {
        var componentRender;
        var sondagemType = this.state.sondagemType;

        
        if (sondagemType === ClassRoomEnum.ClassPT) {
            componentRender = <StudentPollPortugueseCard students={this.props.poll.students} updatePollStudent={this.updatePollStudent} />;
        } else if (sondagemType === ClassRoomEnum.ClassMT) {
            if (this.props.poll.pollTypeSelected === "Numeric" && (this.props.poll.pollYear ==="1" || this.props.poll.pollYear === "2" || this.props.poll.pollYear === "3")) {
                componentRender = <StudentPollMathAlfabetizacaoCard students={this.props.poll.studentsPollMathNumbers} updatePollStudent={this.updatePollStudent} />;
            } else if (this.props.poll.pollYear === "1") {
                if (this.props.poll.pollTypeSelected === "CA") {
                    componentRender = <StudentPollMath1ACard students={this.props.poll.studentsPollMathCA} updatePollStudent={this.updatePollStudent} />;
                } 
            } else if (this.props.poll.pollYear === "2") {
                if (this.props.poll.pollTypeSelected === "CA") {
                    componentRender = <StudentPollMath2ACard students={this.props.poll.studentsPollMathCA} updatePollStudent={this.updatePollStudent} />;
                } 
            } else if (this.props.poll.pollYear === "3") {
                if (this.props.poll.pollTypeSelected === "CA") {
                    componentRender = <StudentPollMath3ACACard students={this.props.poll.studentsPollMathCA} updatePollStudent={this.updatePollStudent} />;
                } else if (this.props.poll.pollTypeSelected === "CM") {
                    componentRender = <StudentPollMath3ACMCard students={this.props.poll.studentsPollMathCM} updatePollStudent={this.updatePollStudent} />;
                }
            } else if (this.props.poll.pollYear === "4") {
                if (this.props.poll.pollTypeSelected === "CA") {
                    componentRender = <StudentPollMath4ACACard students={this.props.poll.studentsPollMathCA} updatePollStudent={this.updatePollStudent} />;
                } else if (this.props.poll.pollTypeSelected === "CM") {
                    componentRender = <StudentPollMath4ACMCard students={this.props.poll.studentsPollMathCM} updatePollStudent={this.updatePollStudent} />;
                }
            } else if (this.props.poll.pollYear === "5") {
                if (this.props.poll.pollTypeSelected === "CA") {
                    componentRender = <StudentPollMath5ACACard students={this.props.poll.studentsPollMathCA} updatePollStudent={this.updatePollStudent} />;
                } else if (this.props.poll.pollTypeSelected === "CM") {
                    componentRender = <StudentPollMath5ACMCard students={this.props.poll.studentsPollMathCM} updatePollStudent={this.updatePollStudent} />;
                }
            } else if (this.props.poll.pollYear === "6") {
                if (this.props.poll.pollTypeSelected === "CA") {
                    componentRender = <StudentPollMath6ACACard students={this.props.poll.studentsPollMathCA} updatePollStudent={this.updatePollStudent} />;
                } else if (this.props.poll.pollTypeSelected === "CM") {
                    componentRender = <StudentPollMath6ACMCard students={this.props.poll.studentsPollMathCM} updatePollStudent={this.updatePollStudent} />;
                }
            }
            
        } else {
            componentRender = "";
        }
        console.log(this.props.poll.pollSelected + " " + this.props.poll.pollTypeSelected + " " + this.props.poll.pollYear);

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