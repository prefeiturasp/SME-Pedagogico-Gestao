import React, { Component } from 'react';
import { connect } from 'react-redux';
import { actionCreators } from '../../store/LeftMenu';
import { bindActionCreators } from 'redux';
import Card from '../containers/Card';

class Home extends Component {
    componentDidMount() {
        this.props.resetMenuState();
    }

    render() {
        return (
            <div className="row">
                <Card className="col-5 mr-2">
                    Home
                </Card>

                <Card className="col">
                    Home
                </Card>
            </div>
        );
    }
}

export default connect(
    state => ({ leftMenu: state.leftMenu }),
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Home);
