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
                    <small className="ml-2 pr-4"><b>{this.props.student.sequenceNumber}</b></small><small>{this.props.student.name}</small>
                </th>
                <th className="text-center border poll-select-container familiares_col">
                    <PollSelectYesNo subjectName="mathalfabetizacao" sequence={this.props.student.studentCodeEol} name="familiares1S" value={this.props.student.familiares1S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" disabled={false}/>
                </th>
                <th className="text-center border poll-select-container familiares_col">
                    <PollSelectYesNo subjectName="mathalfabetizacao" sequence={this.props.student.studentCodeEol} name="familiares2S" value={this.props.student.familiares2S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" disabled={false}/>
                </th>
                <th className="text-center border poll-select-container opacos_col">
                    <PollSelectYesNo subjectName="mathalfabetizacao" sequence={this.props.student.studentCodeEol} name="opacos1S" value={this.props.student.opacos1S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th className="text-center border poll-select-container opacos_col">
                    <PollSelectYesNo subjectName="mathalfabetizacao" sequence={this.props.student.studentCodeEol} name="opacos2S" value={this.props.student.opacos2S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th className="text-center border poll-select-container transparentes_col">
                    <PollSelectYesNo subjectName="mathalfabetizacao" sequence={this.props.student.studentCodeEol} name="transparentes1S" value={this.props.student.transparentes1S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th className="text-center border poll-select-container transparentes_col">
                    <PollSelectYesNo subjectName="mathalfabetizacao" sequence={this.props.student.studentCodeEol} name="transparentes2S" value={this.props.student.transparentes2S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th className="text-center border poll-select-container zero_col">
                    <PollSelectYesNo subjectName="mathalfabetizacao" sequence={this.props.student.studentCodeEol} name="terminamzero1S" value={this.props.student.terminamzero1S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th className="text-center border poll-select-container zero_col">
                    <PollSelectYesNo subjectName="mathalfabetizacao" sequence={this.props.student.studentCodeEol} name="terminamzero2S" value={this.props.student.terminamzero2S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th className="text-center border poll-select-container algarismos_col">
                    <PollSelectYesNo subjectName="mathalfabetizacao" sequence={this.props.student.studentCodeEol} name="algarismos1S" value={this.props.student.algarismos1S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th className="text-center border poll-select-container algarismos_col">
                    <PollSelectYesNo subjectName="mathalfabetizacao" sequence={this.props.student.studentCodeEol} name="algarismos2S" value={this.props.student.algarismos2S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th className="text-center border poll-select-container processo_col">
                    <PollSelectYesNo subjectName="mathalfabetizacao" sequence={this.props.student.studentCodeEol} name="processo1S" value={this.props.student.processo1S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th className="text-center border poll-select-container processo_col">
                    <PollSelectYesNo subjectName="mathalfabetizacao" sequence={this.props.student.studentCodeEol} name="processo2S" value={this.props.student.processo2S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th className="text-center border poll-select-container zeros_col">
                    <PollSelectYesNo subjectName="mathalfabetizacao" sequence={this.props.student.studentCodeEol} name="zerointercalados1S" value={this.props.student.zerointercalados1S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th className="text-center border poll-select-container zeros_col">
                    <PollSelectYesNo subjectName="mathalfabetizacao" sequence={this.props.student.studentCodeEol} name="zerointercalados2S" value={this.props.student.zerointercalados2S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
            </tr>
        );
    }
}