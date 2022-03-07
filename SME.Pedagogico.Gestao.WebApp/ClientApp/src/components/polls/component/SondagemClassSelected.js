import React, { Component } from 'react';

import { connect } from 'react-redux';
import { actionCreators as actionCreatorsPoll } from '../../../store/Poll';
import { actionCreators as actionCreatorsData } from '../../../store/Data';
import { bindActionCreators } from 'redux';

import TwoSteps from '../../messaging/TwoSteps'

class SondagemClassSelected extends Component {
    constructor(props) {
        super(props);

        this.state = {
            showMessageMathNumericBox: false,
            showMessageMathCaBox: false,
            showMessageMathCmBox: false,
        }

        this.btnSetPollType = this.btnSetPollType.bind(this);

        this.btnCheckNumeric = this.btnCheckNumeric.bind(this);
        this.btnCheckCA = this.btnCheckCA.bind(this);
        this.btnCheckCM = this.btnCheckCM.bind(this);

        if(this.props.poll.selectedFilter.schoolYear < 2022){
            if (this.props.poll.pollTypeSelected === "Numeric") {

                this.props.pollMethods.get_poll_math_numbers_students(this.props.poll.selectedFilter);
            } else if (this.props.poll.pollTypeSelected === "CA") {

                this.props.pollMethods.get_poll_math_ca_students(this.props.poll.selectedFilter);
            } else if (this.props.poll.pollTypeSelected === "CM") {

                this.props.pollMethods.get_poll_math_cm_students(this.props.poll.selectedFilter);
            }
        }
        
        this.toggleMessageMathNumericBox = this.toggleMessageMathNumericBox.bind(this); 
        this.toggleMessageMathCaBox = this.toggleMessageMathCaBox.bind(this); 
        this.toggleMessageMathCmBox = this.toggleMessageMathCmBox.bind(this);

        this.btnSetPollTypeNumeric = this.btnSetPollTypeNumeric.bind(this);
        this.btnSetPollTypeCA = this.btnSetPollTypeCA.bind(this);
        this.btnSetPollTypeCM = this.btnSetPollTypeCM.bind(this);
    }

    btnCheckNumeric() {
        var numericStyle = "btn btn-outline-primary btn-sm btn-matematica btn-double-left border-right-0"
        if (this.props.poll.pollTypeSelected === "Numeric") {
            return numericStyle + " active"
        } else {
            return numericStyle;
        }
    }
    btnCheckCA() {
        var caStyle1 = "btn btn-outline-primary btn-sm btn-matematica btn-double-right border-left-0";
        var caStyle2 = "btn btn-outline-primary btn-sm btn-matematica border-left-0 border-right-0";
        var caStyle3 = "btn btn-outline-primary btn-sm btn-matematica btn-double-left border-right-0";
        if (this.props.poll.pollTypeSelected === "CA" && (this.props.poll.pollYear === "1")) {
            return caStyle1 + " active"
        } else if (this.props.poll.pollTypeSelected === "CA" && (this.props.poll.pollYear === "2" || this.props.poll.pollYear === "3")) {
            return caStyle2 + " active";
        } else if (this.props.poll.pollTypeSelected === "CA") {
            return caStyle3 + " active";
        } else {
            if (this.props.poll.pollYear === "1") {
                return caStyle1;
            }else if (this.props.poll.pollYear === "2" || this.props.poll.pollYear === "3") {
                return caStyle2;
            } else {
                return caStyle3;
            }
        }
    }
    btnCheckCM() {
        var cmStyle1 = "btn btn-outline-primary btn-sm btn-matematica btn-double-right border-left-0";
        if (this.props.poll.pollTypeSelected === "CM") { 
            return cmStyle1 + " active";
        } else {
            return cmStyle1;
        }
    }


    btnSetPollType(e) {
        this.props.pollMethods.set_poll_type_selected(e.currentTarget.value);
        this.props.dataMethods.reset_new_data_state();
    }

    btnSetPollTypeNumeric() {
        this.props.pollMethods.set_poll_type_selected("Numeric");
        this.props.dataMethods.reset_new_data_state();
    }
    btnSetPollTypeCA() {
        this.props.pollMethods.set_poll_type_selected("CA");
        this.props.dataMethods.reset_new_data_state();
    }
    btnSetPollTypeCM() {
        this.props.pollMethods.set_poll_type_selected("CM");
        this.props.dataMethods.reset_new_data_state();
    }
    toggleMessageMathNumericBox() {
        this.setState({
            showMessageMathNumericBox: !this.state.showMessageMathNumericBox,
        })
    }
    toggleMessageMathCaBox() {
        this.setState({
            showMessageMathCaBox: !this.state.showMessageMathCaBox,
        })
    }
    toggleMessageMathCmBox() {
        this.setState({
            showMessageMathCmBox: !this.state.showMessageMathCmBox,
        })
    }

    render() {
        var buttonRender;
        switch (this.props.poll.pollYear) {
            case "1":
                if (this.props.data.newDataToSave) {
                    buttonRender = <div className="btn-group mr-2 btn-group-sm pills" role="group" aria-label="Second group">
                        <button id="1Numeric" value="Numeric" onClick={this.toggleMessageMathNumericBox} type="button" className={this.btnCheckNumeric()}>1º ano - Números</button>
                        <button id="1CA" value="CA" onClick={this.toggleMessageMathCaBox} type="button" className={this.btnCheckCA()}>1º ano - CA</button>
                    </div>;
                } else {
                    buttonRender = <div className="btn-group mr-2 btn-group-sm pills" role="group" aria-label="Second group">
                        <button id="1Numeric" value="Numeric" onClick={this.btnSetPollType} type="button" className={this.btnCheckNumeric()}>1º ano - Números</button>
                        <button id="1CA" value="CA" onClick={this.btnSetPollType} type="button" className={this.btnCheckCA()}>1º ano - CA</button>
                    </div>;
                }
                break;
            case "2":
                if (this.props.data.newDataToSave) {
                    buttonRender = <div className="btn-group mr-2 btn-group-sm pills" role="group" aria-label="Third group">
                        <button id="2Numeric" value="Numeric" onClick={this.toggleMessageMathNumericBox} type="button" className={this.btnCheckNumeric()}>2º ano - Números</button>
                        <button id="2CA" value="CA" onClick={this.toggleMessageMathCaBox} type="button" className={this.btnCheckCA()}>2º ano - CA</button>
                        <button id="2CM" value="CM" onClick={this.toggleMessageMathCmBox} type="button" className={this.btnCheckCM()}>2º ano - CM</button>
                    </div>;
                } else {
                    buttonRender = <div className="btn-group mr-2 btn-group-sm pills" role="group" aria-label="Third group">
                        <button id="2Numeric" value="Numeric" onClick={this.btnSetPollType} type="button" className={this.btnCheckNumeric()}>2º ano - Números</button>
                        <button id="2CA" value="CA" onClick={this.btnSetPollType} type="button" className={this.btnCheckCA()}>2º ano - CA</button>
                        <button id="2CM" value="CM" onClick={this.btnSetPollType} type="button" className={this.btnCheckCM()}>2º ano - CM</button>
                    </div>;
                }

                break;
            case "3":
                if (this.props.data.newDataToSave) {
                    buttonRender = <div className="btn-group mr-2 btn-group-sm pills" role="group" aria-label="Fourth group">
                        <button id="3Numeric" value="Numeric" onClick={this.toggleMessageMathNumericBox} type="button" className={this.btnCheckNumeric()}>3º ano - Números</button>
                        <button id="3CA" value="CA" onClick={this.toggleMessageMathCaBox} type="button" className={this.btnCheckCA()}>3º ano - CA</button>
                        <button id="3CM" value="CM" onClick={this.toggleMessageMathCmBox} type="button" className={this.btnCheckCM()}>3º ano - CM</button>
                    </div>;
                } else {
                    buttonRender = <div className="btn-group mr-2 btn-group-sm pills" role="group" aria-label="Fourth group">
                        <button id="3Numeric" value="Numeric" onClick={this.btnSetPollType} type="button" className={this.btnCheckNumeric()}>3º ano - Números</button>
                        <button id="3CA" value="CA" onClick={this.btnSetPollType} type="button" className={this.btnCheckCA()}>3º ano - CA</button>
                        <button id="3CM" value="CM" onClick={this.btnSetPollType} type="button" className={this.btnCheckCM()}>3º ano - CM</button>
                    </div>;
                }

                break;
            case "4":
                if (this.props.data.newDataToSave) {
                    buttonRender = <div className="btn-group mr-2 btn-group-sm pills" role="group" aria-label="Fifth group">
                        <button id="4CA" value="CA" onClick={this.toggleMessageMathCaBox} type="button" className={this.btnCheckCA()}>4º ano - CA</button>
                        <button id="4CM" value="CM" onClick={this.toggleMessageMathCmBox} type="button" className={this.btnCheckCM()}>4º ano - CM</button>
                    </div>;
                } else {
                    buttonRender = <div className="btn-group mr-2 btn-group-sm pills" role="group" aria-label="Fifth group">
                        <button id="4CA" value="CA" onClick={this.btnSetPollType} type="button" className={this.btnCheckCA()}>4º ano - CA</button>
                        <button id="4CM" value="CM" onClick={this.btnSetPollType} type="button" className={this.btnCheckCM()}>4º ano - CM</button>
                    </div>;
                }

                break;
            case "5":
                if (this.props.data.newDataToSave) {
                    buttonRender = <div className="btn-group mr-2 btn-group-sm pills" role="group" aria-label="Sixth group">
                        <button id="5CA" value="CA" onClick={this.toggleMessageMathCaBox} type="button" className={this.btnCheckCA()}>5º ano - CA</button>
                        <button id="5CM" value="CM" onClick={this.toggleMessageMathCmBox} type="button" className={this.btnCheckCM()}>5º ano - CM</button>
                    </div>;
                } else {
                    buttonRender = <div className="btn-group mr-2 btn-group-sm pills" role="group" aria-label="Sixth group">
                        <button id="5CA" value="CA" onClick={this.btnSetPollType} type="button" className={this.btnCheckCA()}>5º ano - CA</button>
                        <button id="5CM" value="CM" onClick={this.btnSetPollType} type="button" className={this.btnCheckCM()}>5º ano - CM</button>
                    </div>;
                }

                break;
            case "6":
                if (this.props.data.newDataToSave) {
                    buttonRender = <div className="btn-group mr-2 btn-group-sm pills" role="group" aria-label="Seventh group">
                        <button id="6CA" value="CA" onClick={this.toggleMessageMathCaBox} type="button" className={this.btnCheckCA()}>6º ano - CA</button>
                        <button id="6CM" value="CM" onClick={this.toggleMessageMathCmBox} type="button" className={this.btnCheckCM()}>6º ano - CM</button>
                    </div>;
                } else {
                    buttonRender = <div className="btn-group mr-2 btn-group-sm pills" role="group" aria-label="Seventh group">
                        <button id="6CA" value="CA" onClick={this.btnSetPollType} type="button" className={this.btnCheckCA()}>6º ano - CA</button>
                        <button id="6CM" value="CM" onClick={this.btnSetPollType} type="button" className={this.btnCheckCM()}>6º ano - CM</button>
                    </div>;
                }

                break;
            default:
                buttonRender = "";

        }
        return (
            <div className="btn-planning">
                <hr />
                {buttonRender}

                <TwoSteps show={this.state.showMessageMathNumericBox} showControl={this.toggleMessageMathNumericBox} runMethod={this.btnSetPollTypeNumeric} />
                <TwoSteps show={this.state.showMessageMathCaBox} showControl={this.toggleMessageMathCaBox} runMethod={this.btnSetPollTypeCA} />
                <TwoSteps show={this.state.showMessageMathCmBox} showControl={this.toggleMessageMathCmBox} runMethod={this.btnSetPollTypeCM} />
            </div>
        );
    }
}

export default connect(
    state => (
        {
            poll: state.poll,
            data: state.data
        }
    ),
    dispatch => (
        {
            pollMethods: bindActionCreators(actionCreatorsPoll, dispatch),
            dataMethods: bindActionCreators(actionCreatorsData, dispatch)
        }
    )
)(SondagemClassSelected);