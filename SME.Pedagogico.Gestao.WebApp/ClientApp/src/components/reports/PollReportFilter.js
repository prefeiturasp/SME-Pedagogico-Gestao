import React, { Component } from 'react';
import SelectChangeColor from '../inputs/SelectChangeColor';
import { connect } from 'react-redux';
import { actionCreators } from '../../store/PollReport';
import { bindActionCreators } from 'redux';

class PollReportFilter extends Component {
    constructor() {
        super();

        this.initialFilter = [];
        this.state = {
            proficiencies: [],
            terms: [],
            selectedFilter: {
                discipline: null,
                proficiency: null,
                term: null,
            }
        }

        this.initialFilterChange = this.initialFilterChange.bind(this);
        this.onChangeProficiency = this.onChangeProficiency.bind(this);
        this.onChangeTerm = this.onChangeTerm.bind(this);
        this.setSelectedFilter = this.setSelectedFilter.bind(this);
        this.checkButton = this.checkButton.bind(this);
    }

    componentDidMount() {
        this.props.hidePollReport();

        for (var key in this.props.pollReport.filters)
            this.initialFilter.push({ value: key, label: this.props.pollReport.filters[key].name });
    }

    initialFilterChange(event) {
        var filters = this.props.pollReport.filters;
        var index = event.nativeEvent.target.selectedIndex;
        var label = event.nativeEvent.target[index].text;

        this.setState({
            selectedFilter: {
                discipline: label,
                proficiency: null,
                term: null,
            },
            proficiencies: filters[event.target.value].proficiencies,
            terms: filters[event.target.value].terms,
        });
    }

    onChangeProficiency(event) {
        var index = event.nativeEvent.target.selectedIndex;
        var label = event.nativeEvent.target[index].text;
        var selectedFilter = this.state.selectedFilter;

        this.setState({
            selectedFilter: {
                discipline: selectedFilter.discipline,
                proficiency: label,
                term: selectedFilter.term,
            }
        });
    }

    onChangeTerm(event) {
        var index = event.nativeEvent.target.selectedIndex;
        var label = event.nativeEvent.target[index].text;
        var selectedFilter = this.state.selectedFilter;

        this.setState({
            selectedFilter: {
                discipline: selectedFilter.discipline,
                proficiency: selectedFilter.proficiency,
                term: label,
            }
        });
    }

    setSelectedFilter() {
        this.props.setPollReportFilter(this.state.selectedFilter);

        var parameters = this.state.selectedFilter;
        parameters.classroomReport = true;
        this.props.getPollReport(parameters);
    }

    checkButton() {
        var parameters = this.state.selectedFilter;

        if (parameters.discipline != null && parameters.proficiency != null && parameters.term != null)
            return (false);

        return (true);
    }

    render() {
        return (
            <div className="d-flex flex-column d-inline-flex">
                <span className="sc-text-blue sc-text-size-1">Filtro para Relat&oacute;rios</span>
                <div className="pt-2 d-inline-flex">
                    <SelectChangeColor className="custom-select-sm" defaultText="Matéria" options={this.initialFilter} onChange={this.initialFilterChange} />
                    <div className="px-2"></div>
                    <SelectChangeColor className="custom-select-sm" defaultText="Proficiência" options={this.state.proficiencies} onChange={this.onChangeProficiency} />
                    <div className="px-2"></div>
                    <SelectChangeColor className="custom-select-sm" defaultText="Período" options={this.state.terms} onChange={this.onChangeTerm} />
                    <div className="px-2"></div>
                    <button type="button" className="btn btn-sm btn-outline-primary" style={{ width: 109 }} onClick={this.setSelectedFilter} disabled={this.checkButton()}>Buscar</button>
                </div>
            </div>
        );
    }
}

export default connect(
    state => ({ pollReport: state.pollReport }),
    dispatch => bindActionCreators(actionCreators, dispatch)
)(PollReportFilter);