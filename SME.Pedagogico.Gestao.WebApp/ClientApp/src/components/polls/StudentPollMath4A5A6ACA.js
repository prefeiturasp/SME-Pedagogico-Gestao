import React, { Component } from 'react';
import PollSelectRightWrong from './inputs/PollSelectRightWrong'

export default class StudentPollMath4A5A6ACA extends Component {
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
                <th colSpan="2" className="text-center border poll-select-container ordem1_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t1i2" value={this.props.student.pollresults.math.t1i2} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem1_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t1r2" value={this.props.student.pollresults.math.t1r2} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem1_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t1i4" value={this.props.student.pollresults.math.t1i4} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem1_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t1r4" value={this.props.student.pollresults.math.t1r4} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem2_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t2i2" value={this.props.student.pollresults.math.t2i2} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem2_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t2r2" value={this.props.student.pollresults.math.t2r2} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem2_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t2i4" value={this.props.student.pollresults.math.t2i4} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem2_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t2r4" value={this.props.student.pollresults.math.t2r4} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem3_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t3i2" value={this.props.student.pollresults.math.t3i2} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem3_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t3r2" value={this.props.student.pollresults.math.t3r2} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem3_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t3i4" value={this.props.student.pollresults.math.t3i4} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem3_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t3r4" value={this.props.student.pollresults.math.t3r4} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem4_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t4i2" value={this.props.student.pollresults.math.t4i2} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem4_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t4r2" value={this.props.student.pollresults.math.t4r2} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem4_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t4i4" value={this.props.student.pollresults.math.t4i4} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem4_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t4r4" value={this.props.student.pollresults.math.t4r4} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
            </tr>
        );
    }
}