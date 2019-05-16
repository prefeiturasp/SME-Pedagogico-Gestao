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
                    <small className="ml-2 pr-4"><b>{this.props.student.sequence}</b></small><small>{this.props.student.name}</small>
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem4_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t4i2" value={this.props.student.pollresults.math.t4i2} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem4_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t4r2" value={this.props.student.pollresults.math.t4r2} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem4_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t4i4" value={this.props.student.pollresults.math.t4i4} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale"/>
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem4_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t4r4" value={this.props.student.pollresults.math.t4r4} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem5_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t5i2" value={this.props.student.pollresults.math.t5i2} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale"/>
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem5_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t5r2" value={this.props.student.pollresults.math.t5r2} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem5_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t5i4" value={this.props.student.pollresults.math.t5i4} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale"/>
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem5_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t5r4" value={this.props.student.pollresults.math.t5r4} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
            </tr>
        );
    }
}