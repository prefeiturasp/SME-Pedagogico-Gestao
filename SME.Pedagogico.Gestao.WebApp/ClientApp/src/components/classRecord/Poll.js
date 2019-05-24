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
                        case "t1b2":
                            pollStudents[i].pollresults.mathalfabetizacao.t1b2 = value;
                            break;
                        case "t1b4":
                            pollStudents[i].pollresults.mathalfabetizacao.t1b4 = value;
                            break;
                        case "t2b2":
                            pollStudents[i].pollresults.mathalfabetizacao.t2b2 = value;
                            break;
                        case "t2b4":
                            pollStudents[i].pollresults.mathalfabetizacao.t2b4 = value;
                            break;
                        case "t3b2":
                            pollStudents[i].pollresults.mathalfabetizacao.t3b2 = value;
                            break;
                        case "t3b4":
                            pollStudents[i].pollresults.mathalfabetizacao.t3b4 = value;
                            break;
                        case "t4b2":
                            pollStudents[i].pollresults.mathalfabetizacao.t4b2 = value;
                            break;
                        case "t4b4":
                            pollStudents[i].pollresults.mathalfabetizacao.t4b4 = value;
                            break;
                        case "t5b2":
                            pollStudents[i].pollresults.mathalfabetizacao.t5b2 = value;
                            break;
                        case "t5b4":
                            pollStudents[i].pollresults.mathalfabetizacao.t5b4 = value;
                            break;
                        case "t6b2":
                            pollStudents[i].pollresults.mathalfabetizacao.t6b2 = value;
                            break;
                        case "t6b4":
                            pollStudents[i].pollresults.mathalfabetizacao.t6b4 = value;
                            break;
                        case "t7b2":
                            pollStudents[i].pollresults.mathalfabetizacao.t7b2 = value;
                            break;
                        case "t7b4":
                            pollStudents[i].pollresults.mathalfabetizacao.t7b4 = value;
                            break;
                        default:
                            break;
                    }
                    break;
                } else if (subjectName === "math") {
                    switch (propertyName) {
                        case "t1i2":
                            pollStudents[i].pollresults.math.t1i2 = value;
                            break;
                        case "t1r2":
                            pollStudents[i].pollresults.math.t1r2 = value;
                            break;
                        case "t1i4":
                            pollStudents[i].pollresults.math.t1i4 = value;
                            break;
                        case "t1r4":
                            pollStudents[i].pollresults.math.t1r4 = value;
                            break;

                        case "t2i2":
                            pollStudents[i].pollresults.math.t2i2 = value;
                            break;
                        case "t2r2":
                            pollStudents[i].pollresults.math.t2r2 = value;
                            break;
                        case "t2i4":
                            pollStudents[i].pollresults.math.t2i4 = value;
                            break;
                        case "t2r4":
                            pollStudents[i].pollresults.math.t2r4 = value;
                            break;

                        case "t3i2":
                            pollStudents[i].pollresults.math.t3i2 = value;
                            break;
                        case "t3r2":
                            pollStudents[i].pollresults.math.t3r2 = value;
                            break;
                        case "t3i4":
                            pollStudents[i].pollresults.math.t3i4 = value;
                            break;
                        case "t3r4":
                            pollStudents[i].pollresults.math.t3r4 = value;
                            break;

                        case "t4i2":
                            pollStudents[i].pollresults.math.t4i2 = value;
                            break;
                        case "t4r2":
                            pollStudents[i].pollresults.math.t4r2 = value;
                            break;
                        case "t4i4":
                            pollStudents[i].pollresults.math.t4i4 = value;
                            break;
                        case "t4r4":
                            pollStudents[i].pollresults.math.t4r4 = value;
                            break;

                        case "t5i2":
                            pollStudents[i].pollresults.math.t5i2 = value;
                            break;
                        case "t5r2":
                            pollStudents[i].pollresults.math.t5r2 = value;
                            break;
                        case "t5i4":
                            pollStudents[i].pollresults.math.t5i4 = value;
                            break;
                        case "t5r4":
                            pollStudents[i].pollresults.math.t5r4 = value;
                            break;

                        case "t6i2":
                            pollStudents[i].pollresults.math.t6i2 = value;
                            break;
                        case "t6r2":
                            pollStudents[i].pollresults.math.t6r2 = value;
                            break;
                        case "t6i4":
                            pollStudents[i].pollresults.math.t6i4 = value;
                            break;
                        case "t6r4":
                            pollStudents[i].pollresults.math.t6r4 = value;
                            break;

                        case "t7i2":
                            pollStudents[i].pollresults.math.t7i2 = value;
                            break;
                        case "t7r2":
                            pollStudents[i].pollresults.math.t7r2 = value;
                            break;
                        case "t7i4":
                            pollStudents[i].pollresults.math.t7i4 = value;
                            break;
                        case "t7r4":
                            pollStudents[i].pollresults.math.t7r4 = value;
                            break;

                        case "t8i2":
                            pollStudents[i].pollresults.math.t8i2 = value;
                            break;
                        case "t8r2":
                            pollStudents[i].pollresults.math.t8r2 = value;
                            break;
                        case "t8i4":
                            pollStudents[i].pollresults.math.t8i4 = value;
                            break;
                        case "t8r4":
                            pollStudents[i].pollresults.math.t8r4 = value;
                            break;
                        default:
                            break;
                    }
                    break;
                }

            }
        }
        
        this.setState({ pollStudents: pollStudents });
        debugger;
        this.props.poll.students = pollStudents;
    }

    savePollStudent() {
        console.log(this.props);
        alert(this.props);
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
        
        this.props.pollMethods.get_poll_portuguese_students(test);
        this.props.pollMethods.set_poll_info(ClassRoomEnum.ClassPT, "", "1"); //passar pollSelected, pollTypeSelected, pollYear
        this.setState({ pollStudents: this.props.poll.students });
    }
    
    openMathPoll(element) {
        this.toggleButton(element.currentTarget.id);
        this.setState({
            sondagemType: ClassRoomEnum.ClassMT,
        });
        //alert("Poll Matematica");
    }

    openMathSubPoll(element) { //mudar nome
        //this.toggleButton(element.currentTarget.id);
        //literacyMathPoll
        //subMathPoll //1A 2A 3ACA 3ACM .. 6ACA 6ACM

        alert("Poll Alfabetizacao Matematica");
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