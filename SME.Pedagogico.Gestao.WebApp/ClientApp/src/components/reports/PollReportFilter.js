import React, { Component } from 'react';
import SelectChangeColor from '../inputs/SelectChangeColor';
import { connect } from 'react-redux';
import { actionCreators } from '../../store/PollReport';
import { bindActionCreators } from 'redux';
import { DISCIPLINES_ENUM } from "../../Enums";

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
            },
            selectedProficiency: null,
            selectedTerm: null,
        }

        this.initialFilterChange = this.initialFilterChange.bind(this);
        this.onChangeProficiency = this.onChangeProficiency.bind(this);
        this.onChangeTerm = this.onChangeTerm.bind(this);
        this.setSelectedFilter = this.setSelectedFilter.bind(this);
        this.checkButton = this.checkButton.bind(this);
    }

    componentDidMount() {
        this.props.hidePollReport();

        if (this.props.filters.listDisciplines.length === 1)
            delete this.props.pollReport.filters[!DISCIPLINES_ENUM.PossuiDisciplina(DISCIPLINES_ENUM.DISCIPLINA_PORTUGUES, this.props.filters.listDisciplines) ? "port" : "math"];

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
            selectedProficiency: "",
            selectedTerm: "",
            proficiencies: filters[event.target.value].proficiencies,
            terms: filters[event.target.value].terms,
        });
    }

    onChangeProficiency(event) {
        var proficiencies = this.state.proficiencies;
        var index = event.nativeEvent.target.selectedIndex;
        var label = event.nativeEvent.target[index].text;
        var selectedFilter = this.state.selectedFilter;
        var selectedProficiency = null;

        for (var i = 0; i < proficiencies.length; i++)
            if (proficiencies[i].label === label) {
                selectedProficiency = proficiencies[i].value;
                break;
            }

        this.setState({
            selectedFilter: {
                discipline: selectedFilter.discipline,
                proficiency: label,
                term: selectedFilter.term,
            },
            selectedProficiency: selectedProficiency
        });
    }

    onChangeTerm(event) {
        var terms = this.state.terms;
        var index = event.nativeEvent.target.selectedIndex;
        var label = event.nativeEvent.target[index].text;
        var selectedFilter = this.state.selectedFilter;
        var selectedTerm = null;

        for (var i = 0; i < terms.length; i++)
            if (terms[i].label === label) {
                selectedTerm = terms[i].value;
                break;
            }

        this.setState({
            selectedFilter: {
                discipline: selectedFilter.discipline,
                proficiency: selectedFilter.proficiency,
                term: label,
            },
            selectedTerm: selectedTerm
        });
    }

    setSelectedFilter() {
        this.props.resetPollReportFilter();
        this.props.setPollReportFilter(this.state.selectedFilter);

        var parameters = this.state.selectedFilter;
        parameters.classroomReport = this.props.poll.selectedFilter.classroomCodeEol === "" ? false : true;
        parameters.codigoDRE = this.props.poll.selectedFilter.dreCodeEol === "todas" ? "" : this.props.poll.selectedFilter.dreCodeEol;
        parameters.CodigoEscola = this.props.poll.selectedFilter.schoolCodeEol === "todas" ? "" : this.props.poll.selectedFilter.schoolCodeEol;
        parameters.CodigoCurso = this.props.poll.selectedFilter.yearClassroom;
        parameters.CodigoTurmaEol = this.props.poll.selectedFilter.classroomCodeEol === null ? "" : this.props.poll.selectedFilter.classroomCodeEol;
        parameters.SchoolYear = this.props.poll.selectedFilter.schoolYear;
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
                    <SelectChangeColor className="custom-select-sm" defaultText="Proficiência" options={this.state.proficiencies} onChange={this.onChangeProficiency} value={this.state.selectedProficiency} resetColor={this.state.selectedProficiency === "" ? true : false} />
                    <div className="px-2"></div>
                    <SelectChangeColor className="custom-select-sm" defaultText="Período" options={this.state.terms} onChange={this.onChangeTerm} value={this.state.selectedTerm} resetColor={this.state.selectedTerm === "" ? true : false} />
                    <div className="px-2"></div>
                    <button type="button" className="btn btn-sm btn-outline-primary" style={{ width: 109 }} onClick={this.setSelectedFilter} disabled={this.checkButton()}>Buscar</button>
                </div>
            </div>
        );
    }
}

export default connect(
    state => ({ pollReport: state.pollReport, poll: state.poll, filters: state.filters }),
    dispatch => bindActionCreators(actionCreators, dispatch)
)(PollReportFilter);