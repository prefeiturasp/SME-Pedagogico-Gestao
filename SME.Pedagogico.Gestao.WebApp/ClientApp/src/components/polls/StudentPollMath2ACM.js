import React, { Component } from 'react';
import PollSelectRightWrong from './inputs/PollSelectRightWrong'

export default class StudentPollMath2ACM extends Component {
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
                <th colSpan="2" className="text-center border poll-select-container ordem3_col">
                    <PollSelectRightWrong sequence={this.props.student.studentCodeEol} name="orderm3Ideia1S" value={this.props.student.orderm3Ideia1S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" disabled={this.props.editLock1S}/>
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem3_col">
                    <PollSelectRightWrong sequence={this.props.student.studentCodeEol} name="orderm3Resultado1S" value={this.props.student.orderm3Resultado1S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" disabled={this.props.editLock1S}/>
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem3_col">
                    <PollSelectRightWrong sequence={this.props.student.studentCodeEol} name="orderm3Ideia2S" value={this.props.student.orderm3Ideia2S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" disabled={this.props.editLock2S}/>
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem3_col">
                    <PollSelectRightWrong sequence={this.props.student.studentCodeEol} name="orderm3Resultado2S" value={this.props.student.orderm3Resultado2S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" disabled={this.props.editLock2S}/>
                </th>
            </tr>
        );
    }
}