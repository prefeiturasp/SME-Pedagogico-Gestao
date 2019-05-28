import React, { Component } from 'react';
import PollSelectWrite from './inputs/PollSelectWrite'
import PollSelectReadWriteLevel from './inputs/PollSelectReadWriteLevel'

export default class StudentPollPortuguese extends Component {
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
                <th className="text-center border poll-select-container 1bim_col">
                    <PollSelectWrite subjectName="portuguese" sequence={this.props.student.studentCodeEol} name="t1e" value={this.props.student.t1e} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th className="text-center border poll-select-container 1bim_col">
                    <PollSelectReadWriteLevel subjectName="portuguese" sequence={this.props.student.studentCodeEol} name="t1l" value={this.props.student.t1l} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th className="text-center border poll-select-container 2bim_col">
                    <PollSelectWrite subjectName="portuguese" sequence={this.props.student.studentCodeEol} name="t2e" value={this.props.student.t2e} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th className="text-center border poll-select-container 2bim_col">
                    <PollSelectReadWriteLevel subjectName="portuguese" sequence={this.props.student.studentCodeEol} name="t2l" value={this.props.student.t2l} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th className="text-center border poll-select-container 3bim_col">
                    <PollSelectWrite subjectName="portuguese" sequence={this.props.student.studentCodeEol} name="t3e" value={this.props.student.t3e} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th className="text-center border poll-select-container 3bim_col">
                    <PollSelectReadWriteLevel subjectName="portuguese" sequence={this.props.student.studentCodeEol} name="t3l" value={this.props.student.t3l} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th className="text-center border poll-select-container 4bim_col">
                    <PollSelectWrite subjectName="portuguese" sequence={this.props.student.studentCodeEol} name="t4e" value={this.props.student.t4e} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th className="text-center border poll-select-container 4bim_col">
                    <PollSelectReadWriteLevel subjectName="portuguese" sequence={this.props.student.studentCodeEol} name="t4l" value={this.props.student.t4l} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                
            </tr>
        );
    }
}