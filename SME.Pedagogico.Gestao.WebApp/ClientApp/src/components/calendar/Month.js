import React, { Component } from 'react';
import { connect } from 'react-redux';
import { actionCreators } from '../../store/Calendar';
import { bindActionCreators } from 'redux';
import { useTransition, animated } from 'react-spring';

function MonthChevronIcon(props) {
    const transitions = useTransition(props.isOpen, item => item, {
        from: { display: 'none' },
        enter: { display: 'block' },
        leave: { display: 'none' }
    });

    return (
        transitions.map(({ item, key, props }) =>
            item ?
                <animated.div style={props} key={key}>
                    <i className="fas fa-chevron-down"></i>
                </animated.div>
                :
                <animated.div style={props} key={key}>
                    <i className="fas fa-chevron-right text-white"></i>
                </animated.div>
        )
    );
}

class Month extends Component {
    constructor() {
        super();

        this.openMonth = this.openMonth.bind(this);
    }

    componentDidMount() {
        var currentDate = new Date();

        if ((currentDate.getMonth() + 1) === Number(this.props.month) && this.props.calendar.months[this.props.month].isOpen === false)
            this.openMonth();
    }

    openMonth() {
        this.props.toggleMonth(this.props.month);
    }

    render() {
        var month = Object.assign({}, this.props.calendar.months[this.props.month]);
        month.style = { backgroundColor: "#F7F9FA" };

        if (month.appointments > 0)
            month.chevronColor = "#10A3FB";

        if (month.isOpen) {
            month.chevronColor = "rgba(0,0,0,0)";
            month.className = month.className + " border-bottom-0";
            month.style = {};
        }

        return (
            <div className="col-3 w-100 px-0">
                <div className={month.className}>
                    <div className="d-flex align-items-center justify-content-center clickable" onClick={this.openMonth} style={{ backgroundColor: month.chevronColor, height: 75, width: 33 }}>
                        <MonthChevronIcon isOpen={month.isOpen} />
                    </div>

                    <div className="d-flex align-items-center w-100" style={month.style}>
                        <div className="w-100 pl-2">{month.name}</div>
                        <div className="flex-shrink-1 d-flex align-items-center pr-3">
                            <div className="pr-2">{month.appointments}</div>
                            <div><i className="far fa-calendar-alt"></i></div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

export default connect(
    state => ({ calendar: state.calendar }),
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Month);
