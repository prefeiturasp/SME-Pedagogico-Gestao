import React, { Component } from 'react';
import './Poll.css'
import Card from '../containers/Card';

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

export default class Poll extends Component {
    constructor(props) {
        super(props);
        this.state = {
            pollStudents: [],
            sondagemType: "6ACM",//PT,MT,1A,2A,3ACA,3ACM,4ACA,4ACM,5ACA,5ACM,6ACA,6ACM
        }

        this.updatePollStudent = this.updatePollStudent.bind(this);
        this.savePollStudent = this.savePollStudent.bind(this);
    }
    componentDidMount() {
        var students = [];
        var student = {
            "name": "Eduarda dos Santos Costa",
            "sequence": 1,
            "pollresults":
            {
                "portuguese":
                {
                    "t1e": "",
                    "t1l": "",
                    "t2e": "SSV",
                    "t2l": "2",
                    "t3e": "SCV",
                    "t3l": "3",
                    "t4e": "A",
                    "t4l": "4",
                },
                "mathalfabetizacao":
                {
                    "t1b2": "N",
                    "t1b4": "N",

                    "t2b2": "S",
                    "t2b4": "S",

                    "t3b2": "S",
                    "t3b4": "N",

                    "t4b2": "N",
                    "t4b4": "N",

                    "t5b2": "N",
                    "t5b4": "S",

                    "t6b2": "S",
                    "t6b4": "N",

                    "t7b2": "N",
                    "t7b4": "N",


                },
                "math":
                {
                    "t1i2": "A",
                    "t1r2": "",
                    "t1i4": "E",
                    "t1r4": "NR",

                    "t2i2": "",
                    "t2r2": "NR",
                    "t2i4": "A",
                    "t2r4": "E",

                    "t3i2": "A",
                    "t3r2": "A",
                    "t3i4": "A",
                    "t3r4": "A",

                    "t4i2": "",
                    "t4r2": "",
                    "t4i4": "",
                    "t4r4": "",

                    "t5i2": "A",
                    "t5r2": "E",
                    "t5i4": "NR",
                    "t5r4": "",

                    "t6i2": "",
                    "t6r2": "E",
                    "t6i4": "NR",
                    "t6r4": "A",

                    "t7i2": "NR",
                    "t7r2": "",
                    "t7i4": "",
                    "t7r4": "",

                    "t8i2": "E",
                    "t8r2": "E",
                    "t8i4": "E",
                    "t8r4": "E"

                },
            },

        };
        students.push(student);
        student = {
            "name": "José Santos Costa",
            "sequence": 2,
            "pollresults":
            {
                "portuguese":
                {
                    "t1e": "PS",
                    "t1l": "4",
                    "t2e": "SSV",
                    "t2l": "3",
                    "t3e": "A",
                    "t3l": "2",
                    "t4e": "",
                    "t4l": "",
                },
                "mathalfabetizacao":
                {
                    "t1b2": "N",
                    "t1b4": "S",

                    "t2b2": "S",
                    "t2b4": "N",

                    "t3b2": "",
                    "t3b4": "",

                    "t4b2": "N",
                    "t4b4": "N",

                    "t5b2": "S",
                    "t5b4": "S",

                    "t6b2": "S",
                    "t6b4": "N",

                    "t7b2": "S",
                    "t7b4": "N",


                },
                "math":
                {
                    "t1i2": "A",
                    "t1r2": "",
                    "t1i4": "E",
                    "t1r4": "NR",

                    "t2i2": "",
                    "t2r2": "NR",
                    "t2i4": "A",
                    "t2r4": "E",

                    "t3i2": "A",
                    "t3r2": "A",
                    "t3i4": "A",
                    "t3r4": "A",

                    "t4i2": "",
                    "t4r2": "",
                    "t4i4": "",
                    "t4r4": "",

                    "t5i2": "A",
                    "t5r2": "E",
                    "t5i4": "NR",
                    "t5r4": "",

                    "t6i2": "",
                    "t6r2": "E",
                    "t6i4": "NR",
                    "t6r4": "A",

                    "t7i2": "NR",
                    "t7r2": "",
                    "t7i4": "",
                    "t7r4": "",

                    "t8i2": "E",
                    "t8r2": "E",
                    "t8i4": "E",
                    "t8r4": "E"

                },
            },

        };
        students.push(student);

        this.setState({ pollStudents: students });
    }

    updatePollStudent(sequence, subjectName, propertyName, value) {
        var pollStudents = this.state.pollStudents;

        for (var i = 0; i < pollStudents.length; i++) {
            if (pollStudents[i].sequence === sequence) {

                if (subjectName === "portuguese") {
                    switch (propertyName) {
                        case "t1e":
                            pollStudents[i].pollresults.portuguese.t1e = value;
                            break;
                        case "t1l":
                            pollStudents[i].pollresults.portuguese.t1l = value;
                            break;
                        case "t2e":
                            pollStudents[i].pollresults.portuguese.t2e = value;
                            break;
                        case "t2l":
                            pollStudents[i].pollresults.portuguese.t2l = value;
                            break;
                        case "t3e":
                            pollStudents[i].pollresults.portuguese.t3e = value;
                            break;
                        case "t3l":
                            pollStudents[i].pollresults.portuguese.t3l = value;
                            break;
                        case "t4e":
                            pollStudents[i].pollresults.portuguese.t4e = value;
                            break;
                        case "t4l":
                            pollStudents[i].pollresults.portuguese.t4l = value;
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
    }

    savePollStudent() {
        console.log(this.props);
        alert(this.props);
    }

    render() {
        var componentRender;
        var sondagemType = this.state.sondagemType;

        if (this.state.sondagemType === "PT") {
            document.getElementsByName("portugues-tab").className = "btn btn-outline-primary btn-sm btn-planning active";
            document.getElementsByName("matematica-tab").className = "btn btn-outline-primary btn-sm btn-planning";

        } else {
            document.getElementsByName("portugues-tab").className = "btn btn-outline-primary btn-sm btn-planning";
            document.getElementsByName("matematica-tab").className = "btn btn-outline-primary btn-sm btn-planning active";
        }

        switch (sondagemType) {
            case "1A":
                componentRender = <StudentPollMath1ACard students={this.state.pollStudents} updatePollStudent={this.updatePollStudent} />;
                break;
            case "2A":
                componentRender = <StudentPollMath2ACard students={this.state.pollStudents} updatePollStudent={this.updatePollStudent} />;
                break;
            case "3ACA":
                componentRender = <StudentPollMath3ACACard students={this.state.pollStudents} updatePollStudent={this.updatePollStudent} />;
                break;
            case "3ACM":
                componentRender = <StudentPollMath3ACMCard students={this.state.pollStudents} updatePollStudent={this.updatePollStudent} />;
                break;
            case "4ACA":
                componentRender = <StudentPollMath4ACACard students={this.state.pollStudents} updatePollStudent={this.updatePollStudent} />;
                break;
            case "4ACM":
                componentRender = <StudentPollMath4ACMCard students={this.state.pollStudents} updatePollStudent={this.updatePollStudent} />;
                break;
            case "5ACA":
                componentRender = <StudentPollMath5ACACard students={this.state.pollStudents} updatePollStudent={this.updatePollStudent} />;
                break;
            case "5ACM":
                componentRender = <StudentPollMath5ACMCard students={this.state.pollStudents} updatePollStudent={this.updatePollStudent} />;
                break;
            case "6ACA":
                componentRender = <StudentPollMath6ACACard students={this.state.pollStudents} updatePollStudent={this.updatePollStudent} />;
                break;
            case "6ACM":
                componentRender = <StudentPollMath6ACMCard students={this.state.pollStudents} updatePollStudent={this.updatePollStudent} />;
                break;
            case "PT":
                componentRender = <StudentPollPortugueseCard students={this.state.pollStudents} updatePollStudent={this.updatePollStudent} />;
                break;
            case "MT":
                componentRender = <StudentPollMathAlfabetizacaoCard students={this.state.pollStudents} updatePollStudent={this.updatePollStudent} />;
                break;
            default:
                componentRender = <StudentPollMathAlfabetizacaoCard students={this.state.pollStudents} updatePollStudent={this.updatePollStudent} />;

        }
        return (
            <Card id="classRecord-poll">
                <nav className="container-tabpanel navbar"><div className="form-inline">
                    <button className="btn btn-outline-primary btn-sm">EF-1C - EMF - MARIA APARECIDA DO NASCIMENTO</button></div>
                    <ul className="nav navbar-nav ml-auto">
                        <li className="nav-item">
                            <div className="form-inline">
                                <button className="btn btn-warning text-white" disabled="">Salvar</button></div>
                        </li>
                    </ul>
                </nav>
                <hr className="horizontal-rule bg-azul-ux" />
                <ul className="nav" id="myTab" role="tablist">
                    <li className="nav-item">
                        <a className="btn btn-outline-primary btn-sm btn-planning active" id="portugues-tab" data-toggle="tab" href="#portugues" role="tab" aria-controls="portuguesPoll" aria-selected="true">Portugu&ecirc;s</a>
                    </li>
                    <li className="nav-item">
                        <a className="btn btn-outline-primary btn-sm btn-planning" id="matematica-tab" data-toggle="tab" href="#matematica" role="tab" aria-controls="matematicaPoll" aria-selected="false">Matem&aacute;tica</a>
                    </li>
                </ul>


                {componentRender}{/*renderiza o componente de sondagem correspondente*/}



            </Card>
        );
    }
}