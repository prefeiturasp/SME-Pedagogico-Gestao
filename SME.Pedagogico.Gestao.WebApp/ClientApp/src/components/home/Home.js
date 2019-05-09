import React, { Component } from 'react';
import { connect } from 'react-redux';
import { actionCreators } from '../../store/LeftMenu';
import { bindActionCreators } from 'redux';
import Card from '../containers/Card';
import Calendar from '../calendar/Calendar';

class Home extends Component {
    componentDidMount() {
        this.props.resetMenuState();
    }

    render() {
        return (
            <div id="home-container" className="row">
                <Card className="col">
                    <Calendar name="Calendário Escolar de 2019" />
                </Card>
            </div>
        );
    }
}

export default connect(
    state => ({ leftMenu: state.leftMenu }),
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Home);
