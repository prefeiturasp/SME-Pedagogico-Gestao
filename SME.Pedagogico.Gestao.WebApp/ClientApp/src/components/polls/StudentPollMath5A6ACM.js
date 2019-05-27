import React, { Component } from 'react';
import PollSelectRightWrong from './inputs/PollSelectRightWrong'

export default class StudentPollMath5A6ACM extends Component {
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
                    <small className="ml-2 pr-4"><b>{this.props.sequenceNumber}</b></small><small>{this.props.student.name}</small>
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
                <th colSpan="2" className="text-center border poll-select-container ordem6_col">
                    <PollSelectRightWrong sequence={this.props.student.studentCodeEol} name="orderm6Ideia1S" value={this.props.student.orderm6Ideia1S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem6_col">
                    <PollSelectRightWrong sequence={this.props.student.studentCodeEol} name="orderm6Resultado1S" value={this.props.student.orderm6Resultado1S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem6_col">
                    <PollSelectRightWrong sequence={this.props.student.studentCodeEol} name="orderm6Ideia2S" value={this.props.student.orderm6Ideia2S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem6_col">
                    <PollSelectRightWrong sequence={this.props.student.studentCodeEol} name="orderm6Resultado2S" value={this.props.student.orderm6Resultado2S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem7_col">
                    <PollSelectRightWrong sequence={this.props.student.studentCodeEol} name="orderm7Ideia1S" value={this.props.student.orderm7Ideia1S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem7_col">
                    <PollSelectRightWrong sequence={this.props.student.studentCodeEol} name="orderm7Resultado1S" value={this.props.student.orderm7Resultado1S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem7_col">
                    <PollSelectRightWrong sequence={this.props.student.studentCodeEol} name="orderm7Ideia2S" value={this.props.student.orderm7Ideia2S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem7_col">
                    <PollSelectRightWrong sequence={this.props.student.studentCodeEol} name="orderm7Resultado2S" value={this.props.student.orderm7Resultado2S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem8_col">
                    <PollSelectRightWrong sequence={this.props.student.studentCodeEol} name="orderm8Ideia1S" value={this.props.student.orderm8Ideia1S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem8_col">
                    <PollSelectRightWrong sequence={this.props.student.studentCodeEol} name="orderm8Resultado1S" value={this.props.student.orderm8Resultado1S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem8_col">
                    <PollSelectRightWrong sequence={this.props.student.studentCodeEol} name="orderm8Ideia2S" value={this.props.student.orderm8Ideia2S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem8_col">
                    <PollSelectRightWrong sequence={this.props.student.studentCodeEol} name="orderm8Resultado2S8Ideia2S" value={this.props.student.orderm8Resultado2S8Ideia2S} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
            </tr>
        );
    }
}