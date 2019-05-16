import React, { Component } from 'react';
import PollSelectYesNo from './inputs/PollSelectYesNo'

export default class StudentPollMathAlfabetizacao extends Component {
    constructor(props) {
        super(props);

        this.state = {
            selectedClass: "custom-select custom-select-sm poll-select"
        };
        
    }

    render() {
        return (
            <tr>
                <th className="align-middle">
                    <small className="ml-2 pr-4"><b>{this.props.student.sequence}</b></small><small>{this.props.student.name}</small>
                </th>
                <th className="text-center border poll-select-container familiares_col">
                    <PollSelectYesNo subjectName="mathalfabetizacao" sequence={this.props.student.sequence} name="t1b2" value={this.props.student.pollresults.mathalfabetizacao.t1b2} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th className="text-center border poll-select-container familiares_col">
                    <PollSelectYesNo subjectName="mathalfabetizacao"  sequence={this.props.student.sequence} name="t1b4" value={this.props.student.pollresults.mathalfabetizacao.t1b4} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th className="text-center border poll-select-container opacos_col">
                    <PollSelectYesNo subjectName="mathalfabetizacao"  sequence={this.props.student.sequence} name="t2b2" value={this.props.student.pollresults.mathalfabetizacao.t2b2} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale"/>
                </th>
                <th className="text-center border poll-select-container opacos_col">
                    <PollSelectYesNo subjectName="mathalfabetizacao" sequence={this.props.student.sequence} name="t2b4" value={this.props.student.pollresults.mathalfabetizacao.t2b4} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th className="text-center border poll-select-container transparentes_col">
                    <PollSelectYesNo subjectName="mathalfabetizacao" sequence={this.props.student.sequence} name="t3b2" value={this.props.student.pollresults.mathalfabetizacao.t3b2} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale"/>
                </th>
                <th className="text-center border poll-select-container transparentes_col">
                    <PollSelectYesNo subjectName="mathalfabetizacao" sequence={this.props.student.sequence} name="t3b4" value={this.props.student.pollresults.mathalfabetizacao.t3b4} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th className="text-center border poll-select-container zero_col">
                    <PollSelectYesNo subjectName="mathalfabetizacao" sequence={this.props.student.sequence} name="t4b2" value={this.props.student.pollresults.mathalfabetizacao.t4b2} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale"/>
                </th>
                <th className="text-center border poll-select-container zero_col">
                    <PollSelectYesNo subjectName="mathalfabetizacao" sequence={this.props.student.sequence} name="t4b4" value={this.props.student.pollresults.mathalfabetizacao.t4b4} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th className="text-center border poll-select-container algarismos_col">
                    <PollSelectYesNo subjectName="mathalfabetizacao" sequence={this.props.student.sequence} name="t5b2" value={this.props.student.pollresults.mathalfabetizacao.t5b2} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale"/>
                </th>
                <th className="text-center border poll-select-container algarismos_col">
                    <PollSelectYesNo subjectName="mathalfabetizacao" sequence={this.props.student.sequence} name="t5b4" value={this.props.student.pollresults.mathalfabetizacao.t5b4} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th className="text-center border poll-select-container processo_col">
                    <PollSelectYesNo subjectName="mathalfabetizacao" sequence={this.props.student.sequence} name="t6b2" value={this.props.student.pollresults.mathalfabetizacao.t6b2} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale"/>
                </th>
                <th className="text-center border poll-select-container processo_col">
                    <PollSelectYesNo subjectName="mathalfabetizacao" sequence={this.props.student.sequence} name="t6b4" value={this.props.student.pollresults.mathalfabetizacao.t6b4} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th className="text-center border poll-select-container zeros_col">
                    <PollSelectYesNo subjectName="mathalfabetizacao" sequence={this.props.student.sequence} name="t7b2" value={this.props.student.pollresults.mathalfabetizacao.t7b2} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale"/>
                </th>
                <th className="text-center border poll-select-container zeros_col">
                    <PollSelectYesNo subjectName="mathalfabetizacao" sequence={this.props.student.sequence} name="t7b4" value={this.props.student.pollresults.mathalfabetizacao.t7b4} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
            </tr>
        );
    }
}