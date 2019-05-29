import React, { Component } from 'react';
import PollSelectRightWrong from './inputs/PollSelectRightWrong'

export default class StudentPollMath3ACM extends Component {
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
                <th colSpan="2" className="text-center border poll-select-container ordem4_col">
                    <PollSelectRightWrong sequence={this.props.student.studentCodeEol} name="orderm4Ideia1S" value={this.props.student.orderm4Ideia1S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem4_col">
                    <PollSelectRightWrong sequence={this.props.student.studentCodeEol} name="orderm4Resultado1S" value={this.props.student.orderm4Resultado1S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem4_col">
                    <PollSelectRightWrong sequence={this.props.student.studentCodeEol} name="orderm4Ideia2S" value={this.props.student.orderm4Ideia2S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem4_col">
                    <PollSelectRightWrong sequence={this.props.student.studentCodeEol} name="orderm4Resultado2S" value={this.props.student.orderm4Resultado2S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem5_col">
                    <PollSelectRightWrong sequence={this.props.student.studentCodeEol} name="orderm5Ideia1S" value={this.props.student.orderm5Ideia1S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem5_col">
                    <PollSelectRightWrong sequence={this.props.student.studentCodeEol} name="orderm5Resultado1S" value={this.props.student.orderm5Resultado1S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem5_col">
                    <PollSelectRightWrong sequence={this.props.student.studentCodeEol} name="orderm5Ideia2S" value={this.props.student.orderm5Ideia2S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem5_col">
                    <PollSelectRightWrong sequence={this.props.student.studentCodeEol} name="orderm5Resultado2S" value={this.props.student.orderm5Resultado2S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
            </tr>
        );
    }
}