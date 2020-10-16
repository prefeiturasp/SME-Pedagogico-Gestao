import React, { Component } from 'react';
import './Dashboard.css';
import { connect } from 'react-redux';
import { actionCreators } from '../../store/LeftMenu';
import { actionCreators as actionCreatorsPollReport } from "../../store/PollReport";
import { bindActionCreators } from 'redux';
import { Spring } from 'react-spring/renderprops';
import { animated } from 'react-spring';
import TopMenu from './TopMenu';
import LeftMenu from './LeftMenu';
import Loader from "../loader/Loader";

class Dashboard extends Component {
    constructor(props) {
        super(props);

        this.state = {
            viewportWidth: 0,
            viewportHeight: 0,
        }

        this.updateWindowDimensions = this.updateWindowDimensions.bind(this);
    }

    componentDidMount() {
        this.updateWindowDimensions();
        window.addEventListener("resize", this.updateWindowDimensions);
    }

    updateWindowDimensions() {
        this.setState({ viewportWidth: window.innerWidth, viewportHeight: window.innerHeight });
    }

    componentWillUnmount() {
        window.removeEventListener("resize", this.updateWindowDimensions);
    }

    handleClose = () => {
        this.props.pollReportMethods.printingPollReport(false);
        
    }

    render() {
        const { printing } = this.props.pollReport;

        return (
            <div id="dashboard-component" className="vh-100">
                <Loader 
                    isPrinting
                    loading={printing} 
                    handleClose={() => this.handleClose()} 
                >
                    <TopMenu />
                    {/*<LeftMenu />*/}

                    <Spring
                        from={{
                            width: this.state.viewportWidth
                        }}
                        to={{
                            width: this.props.leftMenuIsOpen ? (this.state.viewportWidth - 265) : this.state.viewportWidth,
                        }}>
                        {props =>
                            <animated.div id="dashboard-content" className="px-5 py-5" style={props}>
                                {this.props.children}
                            </animated.div>
                        }
                    </Spring>
                </Loader>
            </div>
        );
    }
}

export default connect(
    state => ({
        pollReport: state.pollReport,
        leftMenu: state.leftMenu,
    }),
    dispatch => ({
        pollReportMethods: bindActionCreators(actionCreatorsPollReport, dispatch),
        leftMenuMethods: bindActionCreators(actionCreators, dispatch),
    })
)(Dashboard);