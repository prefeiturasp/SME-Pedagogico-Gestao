import React, { Component } from 'react';

import { connect } from 'react-redux';
import { actionCreators as actionCreatorsPoll } from '../../../store/Poll';
import { bindActionCreators } from 'redux';

class SondagemClassSelected extends Component {
    constructor(props) {
        super(props);

        this.btnSetPollType = this.btnSetPollType.bind(this);
        
    }
    btnSetPollType(e) {
        this.props.pollMethods.set_poll_type_selected(e.currentTarget.value);
        //var classRoomMock = {
        //    "dreCodeEol": "108100 ",
        //    "schoolCodeEol": "000191",
        //    "classroomCodeEol": "1996441",
        //    "schoolYear": "2019",
        //    "yearClassroom": "6"
        //}
        var classRoomMock = this.props.poll.selectedFilter;

        this.props.pollMethods.set_poll_list_initial_state();
        if (this.props.poll.pollTypeSelected === "Numeric") {
            
            this.props.pollMethods.get_poll_math_numbers_students(classRoomMock);
        } else if (this.props.poll.pollTypeSelected === "CA") {
            
            this.props.pollMethods.get_poll_math_ca_students(classRoomMock);
        } else if (this.props.poll.pollTypeSelected === "CM") {
            
            this.props.pollMethods.get_poll_math_cm_students(classRoomMock);
        } 
    }
    render() {
        var buttonRender;
        switch (this.props.poll.pollYear) {
            case "1":
                buttonRender =  <div className="btn-group mr-2 btn-group-sm" role="group" aria-label="Second group">
                                    <button id="1Numeric" value="Numeric" onClick={this.btnSetPollType} type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-left border-right-0">1º ano - Números</button>
                                    <button id="1CA" value="CA" onClick={this.btnSetPollType} type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-right border-left-0">1º ano - CA</button>
                                </div>;
                break;
            case "2":
                buttonRender =  <div className="btn-group mr-2 btn-group-sm" role="group" aria-label="Third group">
                                    <button id="2Numeric" value="Numeric" onClick={this.btnSetPollType} type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-left border-right-0">2º ano - Números</button>
                                    <button id="2ACA" value="CA" onClick={this.btnSetPollType} type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-right border-left-0">2º ano - CA</button>
                                </div>;
                break;
            case "3":
                buttonRender = <div className="btn-group mr-2 btn-group-sm" role="group" aria-label="Fourth group">
                                    <button id="3Numeric" value="Numeric" onClick={this.btnSetPollType} type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-left border-right-0">3º ano - Números</button>
                                    <button id="3CA" value="CA" onClick={this.btnSetPollType} type="button" className="btn btn-outline-primary btn-sm btn-matematica border-left-0 border-right-0">3º ano - CA</button>
                                    <button id="3CM" value="CM" onClick={this.btnSetPollType} type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-right border-left-0">3º ano - CM</button>
                                </div>;
                break;
            case "4":
                buttonRender =  <div className="btn-group mr-2 btn-group-sm" role="group" aria-label="Fifth group">
                                    <button id="4CA" value="CA" onClick={this.btnSetPollType} type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-left border-right-0">4º ano - CA</button>
                                    <button id="4CM" value="CM" onClick={this.btnSetPollType} type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-right border-left-0">4º ano - CM</button>
                                </div>;
                break;
            case "5":
                buttonRender =  <div className="btn-group mr-2 btn-group-sm" role="group" aria-label="Sixth group">
                                    <button id="5CA" value="CA" onClick={this.btnSetPollType} type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-left border-right-0">5º ano - CA</button>
                                    <button id="5CM" value="CM" onClick={this.btnSetPollType} type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-right border-left-0">5º ano - CM</button>
                                </div>;
                break;
            case "6":
                buttonRender =  <div className="btn-group mr-2 btn-group-sm" role="group" aria-label="Seventh group">
                                    <button id="6CA" value="CA" onClick={this.btnSetPollType} type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-left border-right-0">6º ano - CA</button>
                                    <button id="6CM" value="CM" onClick={this.btnSetPollType} type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-double-right border-left-0">6º ano - CM</button>
                                </div>;
                break;
            case "MT"://retirar posteriormente
                buttonRender =  <div className="btn-group mr-2 btn-group-sm" role="group" aria-label="First group">
                                    <button id="MT" type="button" className="btn btn-outline-primary btn-sm btn-matematica btn-single">Alfabetização</button>
                                </div>;
                break;
            default:
                buttonRender = "";

        }
        return (
            <div className="btn-planning">
                {buttonRender}
            </div>
        );
    }
}

export default connect(
    state => (
        {
            poll: state.poll
        }
    ),
    dispatch => (
        {
            pollMethods: bindActionCreators(actionCreatorsPoll, dispatch)
        }
    )
)(SondagemClassSelected);