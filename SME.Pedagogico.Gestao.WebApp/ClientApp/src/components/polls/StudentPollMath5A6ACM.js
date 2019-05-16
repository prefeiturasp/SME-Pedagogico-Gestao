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
                    <small className="ml-2 pr-4"><b>{this.props.student.sequence}</b></small><small>{this.props.student.name}</small>
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem5_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t5i2" value={this.props.student.pollresults.math.t5i2} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
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
                <th colSpan="2" className="text-center border poll-select-container ordem6_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t6i2" value={this.props.student.pollresults.math.t6i2} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale"/>
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem6_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t6r2" value={this.props.student.pollresults.math.t6r2} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem6_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t6i4" value={this.props.student.pollresults.math.t6i4} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale"/>
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem6_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t6r4" value={this.props.student.pollresults.math.t6r4} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem7_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t7i2" value={this.props.student.pollresults.math.t7i2} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale"/>
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem7_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t7r2" value={this.props.student.pollresults.math.t7r2} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem7_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t7i4" value={this.props.student.pollresults.math.t7i4} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale"/>
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem7_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t7r4" value={this.props.student.pollresults.math.t7r4} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem8_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t8i2" value={this.props.student.pollresults.math.t8i2} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem8_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t8r2" value={this.props.student.pollresults.math.t8r2} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem8_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t8i4" value={this.props.student.pollresults.math.t8i4} updatePollStudent={this.props.updatePollStudent} columnColor="bg-bluescale" />
                </th>
                <th colSpan="2" className="text-center border poll-select-container ordem8_col">
                    <PollSelectRightWrong sequence={this.props.student.sequence} name="t8r4" value={this.props.student.pollresults.math.t8r4} updatePollStudent={this.props.updatePollStudent} columnColor="bg-lila" />
                </th>
            </tr>
        );
    }
}