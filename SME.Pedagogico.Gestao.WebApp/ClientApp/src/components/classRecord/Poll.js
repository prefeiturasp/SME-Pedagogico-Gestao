import React, { Component } from 'react';
import './Poll.css'
import Card from '../containers/Card';
import PollFilter from './PollFilter';

import { ClassRoomEnum } from '../polls/component/ClassRoomHelper'
import { connect } from 'react-redux';
import { actionCreators as actionCreatorsPoll } from '../../store/Poll';
import { actionCreators as actionCreatorsPollOptionSelectLock } from '../../store/PollOptionSelectLock';
import { actionCreators as actionCreatorsData } from '../../store/Data';

import { bindActionCreators } from 'redux';

import StudentPollMathAlfabetizacaoCard from '../polls/StudentPollMathAlfabetizacaoCard'
import StudentPollMath1ACard from '../polls/StudentPollMath1ACard'
import StudentPollMath2ACard from '../polls/StudentPollMath2ACard'
import StudentPollMath2ACMCard from '../polls/StudentPollMath2ACMCard'
import StudentPollMath3ACACard from '../polls/StudentPollMath3ACACard'
import StudentPollMath3ACMCard from '../polls/StudentPollMath3ACMCard'
import StudentPollMath4ACACard from '../polls/StudentPollMath4ACACard'
import StudentPollMath4ACMCard from '../polls/StudentPollMath4ACMCard'
import StudentPollMath5ACACard from '../polls/StudentPollMath5ACACard'
import StudentPollMath5ACMCard from '../polls/StudentPollMath5ACMCard'
import StudentPollMath6ACACard from '../polls/StudentPollMath6ACACard'
import StudentPollMath6ACMCard from '../polls/StudentPollMath6ACMCard'
import StudentPollPortugueseCard from '../polls/StudentPollPortugueseCard'

import TwoStepsSave from '../messaging/TwoStepsSave';
import TwoSteps from '../messaging/TwoSteps'
import { actionCreators } from '../../store/Calendar';

class Poll extends Component {
    constructor(props) {
        super(props);
        this.state = {
            navSelected: "",
            didAnswerPoll: false, //usar para perguntar para salvar sondagem
            sondagemType: ClassRoomEnum.ClassEmpty,
            showMessageBox: false, //para botao save
            showMessagePortugueseBox: false, //para botao para abrir portugues
            showMessageMathBox: false, //para botao para abrir matematica
        }
        this.componentRender = this.componentRender.bind(this);

        this.updatePollStudent = this.updatePollStudent.bind(this);
        this.savePollStudent = this.savePollStudent.bind(this);

        this.toggleButton = this.toggleButton.bind(this);

        this.openPortuguesePoll = this.openPortuguesePoll.bind(this);
        this.openMathPoll = this.openMathPoll.bind(this);

        this.checkButtonPortuguese = this.checkButtonPortuguese.bind(this);
        this.checkButtonMath = this.checkButtonMath.bind(this);
        this.checkButtonSave = this.checkButtonSave.bind(this);
        this.checkPollCard = this.checkPollCard.bind(this);


        this.props.pollMethods.set_poll_info(null, null, null);
        this.props.pollMethods.reset_poll_selected_filter_state();


        this.toggleMessageBox = this.toggleMessageBox.bind(this); //para salvar
        this.toggleMessagePortugueseBox = this.toggleMessagePortugueseBox.bind(this); //para botao portugues
        this.toggleMessageMathBox = this.toggleMessageMathBox.bind(this); //para botao matematica
        
        var todayDate = new Date();
        if (new Date("2019-06-13") <= todayDate && todayDate <= new Date("2019-07-27")) {
            this.props.pollOptionSelectLockMethods.set_poll_1b_lock(false);
            this.props.pollOptionSelectLockMethods.set_poll_2b_lock(false);
            this.props.pollOptionSelectLockMethods.set_poll_3b_lock(true);
            this.props.pollOptionSelectLockMethods.set_poll_4b_lock(true);

            this.props.pollOptionSelectLockMethods.set_poll_1s_lock(false);
            this.props.pollOptionSelectLockMethods.set_poll_2s_lock(true);
        } else if (new Date("2019-09-16") <= todayDate && todayDate <= new Date("2019-10-12")) {
            this.props.pollOptionSelectLockMethods.set_poll_1b_lock(true);
            this.props.pollOptionSelectLockMethods.set_poll_2b_lock(true);
            this.props.pollOptionSelectLockMethods.set_poll_3b_lock(false);
            this.props.pollOptionSelectLockMethods.set_poll_4b_lock(true);

            this.props.pollOptionSelectLockMethods.set_poll_1s_lock(true);
            this.props.pollOptionSelectLockMethods.set_poll_2s_lock(true);
        } else if (new Date("2019-11-15") <= todayDate && todayDate <= new Date("2019-12-15")) {
            this.props.pollOptionSelectLockMethods.set_poll_1b_lock(true);
            this.props.pollOptionSelectLockMethods.set_poll_2b_lock(true);
            this.props.pollOptionSelectLockMethods.set_poll_3b_lock(true);
            this.props.pollOptionSelectLockMethods.set_poll_4b_lock(false);

            this.props.pollOptionSelectLockMethods.set_poll_1s_lock(true);
            this.props.pollOptionSelectLockMethods.set_poll_2s_lock(false);
        } 
    }

    toggleMessageBox() {
        this.setState({
            showMessageBox: !this.state.showMessageBox,
        })
    }
    toggleMessagePortugueseBox() {
        this.setState({
            showMessagePortugueseBox: !this.state.showMessagePortugueseBox,
        })
    }

    toggleMessageMathBox() {
        this.setState({
            showMessageMathBox: !this.state.showMessageMathBox,
        })
    }

    componentDidUpdate() {
        if (this.state.navSelected === "portugues-tab" && document.getElementById("portugues-tab") !== null && document.getElementById("matematica-tab") !== null) {
            document.getElementById("portugues-tab").className = "btn btn-outline-primary btn-sm btn-planning active";
            document.getElementById("matematica-tab").className = "btn btn-outline-primary btn-sm btn-planning";
        } else if (this.state.navSelected === "matematica-tab" && document.getElementById("portugues-tab") !== null && document.getElementById("matematica-tab") !== null) {
            document.getElementById("portugues-tab").className = "btn btn-outline-primary btn-sm btn-planning";
            document.getElementById("matematica-tab").className = "btn btn-outline-primary btn-sm btn-planning active";
        }

        if (this.props.poll.newDataToSave) {
            if (document.getElementById("btnSave")!==null) {
                document.getElementById("btnSave").className = "btn btn-save text-white";
            }
        } else {
            if (document.getElementById("btnSave") !== null) {
                document.getElementById("btnSave").className = "btn btn-save text-white deactive";
            }
        }

        
    }

    componentDidMount() {
        
    }
    componentWillUpdate() {
        
    }

    componentRender() {
        var componentRender;

        var sondagemType = this.props.poll.pollSelected

        if (this.props.poll.pollSelected === ClassRoomEnum.ClassPT) {
            componentRender = <StudentPollPortugueseCard students={this.props.poll.students} updatePollStudent={this.updatePollStudent} editLock1b={this.props.pollOptionSelectLock.poll_1b_lock} editLock2b={this.props.pollOptionSelectLock.poll_2b_lock} editLock3b={this.props.pollOptionSelectLock.poll_3b_lock} editLock4b={this.props.pollOptionSelectLock.poll_4b_lock}/>;
        } else if (this.props.poll.pollSelected === ClassRoomEnum.ClassMT) {
            if (this.props.poll.pollTypeSelected === "Numeric" && (this.props.poll.pollYear === "1" || this.props.poll.pollYear === "2" || this.props.poll.pollYear === "3")) {
                componentRender = <StudentPollMathAlfabetizacaoCard students={this.props.poll.studentsPollMathNumbers} updatePollStudent={this.updatePollStudent} editLock1S={this.props.pollOptionSelectLock.poll_1s_lock} editLock2S={this.props.pollOptionSelectLock.poll_2s_lock}/>;
            } else if (this.props.poll.pollYear === "1") {
                if (this.props.poll.pollTypeSelected === "CA") {
                    componentRender = <StudentPollMath1ACard students={this.props.poll.studentsPollMathCA} updatePollStudent={this.updatePollStudent} editLock1S={this.props.pollOptionSelectLock.poll_1s_lock} editLock2S={this.props.pollOptionSelectLock.poll_2s_lock}/>;
                }
            } else if (this.props.poll.pollYear === "2") {
                if (this.props.poll.pollTypeSelected === "CA") {
                    componentRender = <StudentPollMath2ACard students={this.props.poll.studentsPollMathCA} updatePollStudent={this.updatePollStudent} editLock1S={this.props.pollOptionSelectLock.poll_1s_lock} editLock2S={this.props.pollOptionSelectLock.poll_2s_lock}/>;
                } else if (this.props.poll.pollTypeSelected === "CM") {
                    componentRender = <StudentPollMath2ACMCard students={this.props.poll.studentsPollMathCM} updatePollStudent={this.updatePollStudent} editLock1S={this.props.pollOptionSelectLock.poll_1s_lock} editLock2S={this.props.pollOptionSelectLock.poll_2s_lock}/>;
                }
            } else if (this.props.poll.pollYear === "3") {
                if (this.props.poll.pollTypeSelected === "CA") {
                    componentRender = <StudentPollMath3ACACard students={this.props.poll.studentsPollMathCA} updatePollStudent={this.updatePollStudent} editLock1S={this.props.pollOptionSelectLock.poll_1s_lock} editLock2S={this.props.pollOptionSelectLock.poll_2s_lock}/>;
                } else if (this.props.poll.pollTypeSelected === "CM") {
                    componentRender = <StudentPollMath3ACMCard students={this.props.poll.studentsPollMathCM} updatePollStudent={this.updatePollStudent} editLock1S={this.props.pollOptionSelectLock.poll_1s_lock} editLock2S={this.props.pollOptionSelectLock.poll_2s_lock}/>;
                }
            } else if (this.props.poll.pollYear === "4") {
                if (this.props.poll.pollTypeSelected === "CA") {
                    componentRender = <StudentPollMath4ACACard students={this.props.poll.studentsPollMathCA} updatePollStudent={this.updatePollStudent} editLock1S={this.props.pollOptionSelectLock.poll_1s_lock} editLock2S={this.props.pollOptionSelectLock.poll_2s_lock}/>;
                } else if (this.props.poll.pollTypeSelected === "CM") {
                    componentRender = <StudentPollMath4ACMCard students={this.props.poll.studentsPollMathCM} updatePollStudent={this.updatePollStudent} editLock1S={this.props.pollOptionSelectLock.poll_1s_lock} editLock2S={this.props.pollOptionSelectLock.poll_2s_lock}/>;
                }
            } else if (this.props.poll.pollYear === "5") {
                if (this.props.poll.pollTypeSelected === "CA") {
                    componentRender = <StudentPollMath5ACACard students={this.props.poll.studentsPollMathCA} updatePollStudent={this.updatePollStudent} editLock1S={this.props.pollOptionSelectLock.poll_1s_lock} editLock2S={this.props.pollOptionSelectLock.poll_2s_lock}/>;
                } else if (this.props.poll.pollTypeSelected === "CM") {
                    componentRender = <StudentPollMath5ACMCard students={this.props.poll.studentsPollMathCM} updatePollStudent={this.updatePollStudent} editLock1S={this.props.pollOptionSelectLock.poll_1s_lock} editLock2S={this.props.pollOptionSelectLock.poll_2s_lock}/>;
                }
            } else if (this.props.poll.pollYear === "6") {
                if (this.props.poll.pollTypeSelected === "CA") {
                    componentRender = <StudentPollMath6ACACard students={this.props.poll.studentsPollMathCA} updatePollStudent={this.updatePollStudent} editLock1S={this.props.pollOptionSelectLock.poll_1s_lock} editLock2S={this.props.pollOptionSelectLock.poll_2s_lock}/>;
                } else if (this.props.poll.pollTypeSelected === "CM") {
                    componentRender = <StudentPollMath6ACMCard students={this.props.poll.studentsPollMathCM} updatePollStudent={this.updatePollStudent} editLock1S={this.props.pollOptionSelectLock.poll_1s_lock} editLock2S={this.props.pollOptionSelectLock.poll_2s_lock}/>;
                }
            }
        } else {
            componentRender = "";
        }
        console.log(this.props.poll.pollSelected + " " + this.props.poll.pollTypeSelected + " " + this.props.poll.pollYear);


        return (componentRender);
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
                                case "orderm8Resultado2S":
                                    pollStudents[i].orderm8Resultado2S = value;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        }
                    }
                }
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
                                case "orderm8Resultado2S":
                                    pollStudents[i].orderm8Resultado2S = value;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        }
                    }
                }
                this.props.pollMethods.update_poll_math_cm_students(pollStudents);
            }

        }
        this.props.dataMethods.set_new_data_state();
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
                
                console.log(response);
                console.log(this.props.poll.pollSelected);
            }
            this.props.dataMethods.reset_new_data_state();
        } else {
            //alert(this.props.poll.pollSelected);
        }
        console.log(this.props);
        
    }

    toggleButton(elementSeleted) {
        this.setState({
            navSelected: elementSeleted,
        });
    }

    openPortuguesePoll() {
        debugger;
        //this.toggleButton(element.currentTarget.id);//portugues-tab
        this.props.dataMethods.reset_new_data_state();
        this.toggleButton("portugues-tab");
        var classRoomMock = this.props.poll.selectedFilter;

        this.props.pollMethods.set_poll_list_initial_state();
        this.props.pollMethods.set_poll_info(ClassRoomEnum.ClassPT, "", classRoomMock.yearClassroom); //passar pollSelected, pollTypeSelected, pollYear
        this.props.pollMethods.get_poll_portuguese_students(classRoomMock);
    }
    
    openMathPoll() {
        //this.toggleButton(element.currentTarget.id);
        this.props.dataMethods.reset_new_data_state();
        this.toggleButton("matematica-tab");
        var classRoomMock = this.props.poll.selectedFilter;

        this.props.pollMethods.set_poll_list_initial_state();
        if (classRoomMock.yearClassroom === "1" || classRoomMock.yearClassroom === "2" || classRoomMock.yearClassroom === "3") {
            this.props.pollMethods.set_poll_info(ClassRoomEnum.ClassMT, "Numeric", classRoomMock.yearClassroom);
        } else {
            this.props.pollMethods.set_poll_info(ClassRoomEnum.ClassMT, "CA", classRoomMock.yearClassroom);
        }
        
        if (this.props.poll.pollTypeSelected === "Numeric") {
            
            this.props.pollMethods.get_poll_math_numbers_students(classRoomMock);
        } else if (this.props.poll.pollTypeSelected === "CA") {
            
            this.props.pollMethods.get_poll_math_ca_students(classRoomMock);
        } else if (this.props.poll.pollTypeSelected === "CM") {
            
            this.props.pollMethods.get_poll_math_cm_students(classRoomMock);
        }
    }

    checkButtonPortuguese() {
        var btn;
        if (this.props.poll.selectedFilter.yearClassroom !== null && parseInt(this.props.poll.selectedFilter.yearClassroom) < 4 && this.props.poll.selectedFilter.yearClassroom !== undefined) {
            if (this.props.data.newDataToSave) {
                btn = <li className="nav-item">
                    <button className="btn btn-outline-primary btn-sm btn-planning" onClick={this.toggleMessagePortugueseBox}>Língua Portuguesa</button>
                    <TwoSteps show={this.state.showMessagePortugueseBox} showControl={this.toggleMessagePortugueseBox} runMethod={this.openPortuguesePoll} />

                </li>;
            } else {
                btn = <li className="nav-item">
                    <button className="btn btn-outline-primary btn-sm btn-planning" id="portugues-tab" onClick={this.openPortuguesePoll}>Língua Portuguesa</button>
                </li>;
            }
        }
        return (btn);
    }

    checkButtonMath() {
        var btn;
        if (this.props.poll.selectedFilter.yearClassroom !== null && parseInt(this.props.poll.selectedFilter.yearClassroom) < 7 && this.props.poll.selectedFilter.yearClassroom !== undefined) {
            
            if (this.props.data.newDataToSave) {
                btn = <li className="nav-item">
                    <button className="btn btn-outline-primary btn-sm btn-planning" onClick={this.toggleMessageMathBox}>Matem&aacute;tica</button>
                    <TwoSteps show={this.state.showMessageMathBox} showControl={this.toggleMessageMathBox} runMethod={this.openMathPoll} />
                </li>
            } else {
                btn = <li className="nav-item">
                    <button className="btn btn-outline-primary btn-sm btn-planning" id="matematica-tab" onClick={this.openMathPoll}>Matem&aacute;tica</button>
                </li>
            }
        }
        return (btn); 
    }

    checkButtonSave() {
        var btn;
        if (this.props.poll.selectedFilter.yearClassroom !== null && parseInt(this.props.poll.selectedFilter.yearClassroom) < 7 && this.props.poll.selectedFilter.yearClassroom !== undefined) {
            btn = <li className="nav-item">
                    <div className="form-inline">
                    <button id="btnSave" className="btn btn-save text-white deactive" onClick={this.toggleMessageBox} disabled={!this.props.poll.newDataToSave}>Salvar</button>
                    </div>

                    <TwoStepsSave show={this.state.showMessageBox} showControl={this.toggleMessageBox} runMethod={this.savePollStudent} />
                  </li>
        }
        return (btn);
    }

    
    checkPollCard() {
        if (this.props.poll.selectedFilter.yearClassroom !== null && parseInt(this.props.poll.selectedFilter.yearClassroom) < 7 && this.props.poll.selectedFilter.yearClassroom !== undefined) {
            return "false";
        } else {
            return "true";
        }
    }
    
    render() {
        return (
            <>
                <Card className="mb-3">
                    <PollFilter reports={false} />
                </Card> 
                <Card id="classRecord-poll" hide={this.checkPollCard()}>
                    <nav className="container-tabpanel navbar">
                        <ul className="nav" role="tablist">
                            {this.checkButtonPortuguese()}
                            {this.checkButtonMath()}
                        </ul>
                        <ul className="nav navbar-nav ml-auto">
                            {this.checkButtonSave()}
                        </ul>
                    </nav>
                    {this.componentRender()}
                </Card>
            </>
        );
    }
}
export default connect(
    state => (
        {
            poll: state.poll,
            pollOptionSelectLock: state.pollOptionSelectLock,
            data:state.data
        }
    ),
    dispatch => (
        {
            pollMethods: bindActionCreators(actionCreatorsPoll, dispatch),
            pollOptionSelectLockMethods: bindActionCreators(actionCreatorsPollOptionSelectLock, dispatch),
            dataMethods: bindActionCreators(actionCreatorsData, dispatch)
        }
    )
)(Poll);