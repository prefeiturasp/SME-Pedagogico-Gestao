import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import { actionCreators } from '../../store/LeftMenu';
import { bindActionCreators } from 'redux';

class Breadcrumb extends Component {
    render() {
        const breadcrumbs = [];
        breadcrumbs.push(<Link key="Home" to="/"><small className="font-weight-light text-muted">Home</small></Link>);

        if (this.props.leftMenu.breadcrumb.length > 1)
            for (var i = 1; i < this.props.leftMenu.breadcrumb.length; i++)
                if (this.props.leftMenu.breadcrumb[i].link === null) {
                    breadcrumbs.push(<div key={i}><small className="mx-2"><i className="fas fa-chevron-circle-right text-muted"></i></small></div>);
                    breadcrumbs.push(<div key={this.props.leftMenu.breadcrumb[i].page}><small className="font-weight-light text-muted">{this.props.leftMenu.breadcrumb[i].page}</small></div>);
                }
                else {
                    breadcrumbs.push(<div key={i}><small className="mx-2"><i className="fas fa-chevron-circle-right text-muted"></i></small></div>);
                    breadcrumbs.push(<Link key={this.props.leftMenu.breadcrumb[i].page} to={this.props.leftMenu.breadcrumb[i].link}><small className="font-weight-light text-muted">{this.props.leftMenu.breadcrumb[i].page}</small></Link>);
                }

        const { id, className, style } = this.props;

        return (
            <div id={id} className={className} style={style}>
                {breadcrumbs}
            </div>
        );
    }
}

export default connect(
    state => ({ leftMenu: state.leftMenu }),
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Breadcrumb);
