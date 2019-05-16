import React, { Component } from 'react';
import CheckInline from '../inputs/CheckInline'

export default class StudentFrequency extends Component {
 
    render() {
        console.log(this.props.disabled, this.props.numberLessons)
        return (
            <tr>
                <td className="text-center align-middle" scope="row">
                    <a data-toggle="collapse" href={"#collapseExample" + this.props.student.codigoAluno} role="button" aria-expanded="false" aria-controls={"collapseExample" + this.props.student.codigoAluno}>
                        -
                    </a>
                </td>
                <td className="text-center align-middle">{this.props.student.numeroAlunoChamada}</td>
                <td className="align-middle">{this.props.student.nomeAluno}</td>
                <td>
                    <div className="col-sm-12 col-xs-12 form-check form-check-inline">
                        <CheckInline
                            codigoaluno={this.props.student.codigoAluno}
                            numberLessons={this.props.numberLessons} 
                            checkFrequency={this.props.checkFrequency}
                            checkboxChange={this.props.checkboxChange}
                            disabled={this.props.disabled}
                        /> 
                       
                    </div>
                </td>
                <td className="text-center" >
                    <span> 75% </span>
                    <div className="text-center progress">
                        <div className="progress-bar progress-bar-striped progress-bar-animated  divStyle2 " role="progressbar" aria-valuenow="75" aria-valuemin="0" aria-valuemax="100" ></div>
                    </div>
                </td>
                <td className="text-center" bgcolor="white"><i className="text-center fas fa-exclamation-circle text-muted"></i></td>
            </tr >
        );
    }


}




