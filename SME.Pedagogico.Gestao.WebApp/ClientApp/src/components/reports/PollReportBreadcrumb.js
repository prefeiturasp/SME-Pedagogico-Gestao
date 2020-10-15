import React, { Component } from "react";
import { connect } from "react-redux";
import { actionCreators } from "../../store/PollReport";
import { bindActionCreators } from "redux";

class PollReportBreadcrumb extends Component {
  render() {
    var { className } = this.props;

    if (className === undefined) className = "border-top border-bottom";
    else className += " border-top border-bottom";

    return (
      <div className={className}>
        <div className="mx-1 my-2">
          <span className="sc-text-purple sc-text-size-2">
            Sondagem {this.props.name} /{" "}
          </span>
          <span className="sc-text-size-1 text-muted font-weight-light">
            {this.props.pollReport.selectedFilter.CodigoCurso}° Ano /{" "}
          </span>
          <span className="sc-text-size-1 text-muted font-weight-light">
            {this.props.pollReport.selectedFilter.discipline} /{" "}
          </span>
          <span className="sc-text-size-1 text-muted font-weight-light">
            {this.props.pollReport.selectedFilter.proficiency
              ? `${this.props.pollReport.selectedFilter.proficiency} / `
              : " "}{""}
          </span>
          <span className="sc-text-size-1 text-muted font-weight-light">
            {this.props.pollReport.selectedFilter.term}
          </span>
        </div>
      </div>
    );
  }
}

export default connect(
  (state) => ({ pollReport: state.pollReport }),
  (dispatch) => bindActionCreators(actionCreators, dispatch)
)(PollReportBreadcrumb);
