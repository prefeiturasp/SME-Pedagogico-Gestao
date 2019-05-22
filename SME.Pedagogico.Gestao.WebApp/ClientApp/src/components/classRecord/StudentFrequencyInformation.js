import React, { Component } from 'react';
import Card from '../containers/Card';

export default class StudentFrequencyInformation extends Component {
    render() {
        return (
            <td colSpan="7">
                <Card id="classRecord-poll">
                    {this.props.student.situacaoMatricula}
                </Card>
            </td>
        );
    }
}