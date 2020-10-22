import React, { Component } from 'react';
import SelectChangeColor from '../inputs/SelectChangeColor';
import { connect } from 'react-redux';
import { actionCreators } from '../../store/PollReport';
import { bindActionCreators } from 'redux';
import { actionCreators as pollStoreActionCreators } from '../../store/SondagemPortuguesStore';
import { DISCIPLINES_ENUM } from "../../Enums";
import { ROLES_ENUM } from "../../Enums";

class PollReportFilter extends Component {
    constructor() {
        super();

        this.initialFilter = [];
        this.state = {
            proficiencies: [],
            grupos: [],
            terms: [],
            selectedFilter: {
                discipline: null,
                proficiency: null,
                grupoId: null,
                term: null,
            },
            grupoSelecionado: null,
            selectedProficiency: null,
            selectedTerm: null,
        }

        this.initialFilterChange = this.initialFilterChange.bind(this);
        this.onChangeProficiency = this.onChangeProficiency.bind(this);
        this.onChangeGrupo = this.onChangeGrupo.bind(this);
        this.onChangeTerm = this.onChangeTerm.bind(this);
        this.setSelectedFilter = this.setSelectedFilter.bind(this);
        this.checkButton = this.checkButton.bind(this);
        this.limparDadosFiltro = this.limparDadosFiltro.bind(this);
    }

    componentDidMount() {
        this.props.pollReportsMethods.hidePollReport();
        this.props.sondagemPortuguesMethods.listarGrupos();

        if (this.restricaoDisciplina(DISCIPLINES_ENUM.DISCIPLINA_PORTUGUES))
            delete this.props.pollReport.filters.port;

        if (this.restricaoDisciplina(DISCIPLINES_ENUM.DISCIPLINA_MATEMATICA))
            delete this.props.pollReport.filters.math;

        for (var key in this.props.pollReport.filters)
            this.initialFilter.push({ value: key, label: this.props.pollReport.filters[key].name });
    }

    componentDidUpdate() {
        if ((this.ehMatematicaAcimaDoSetimoAnoConsolidado()) &&
            (this.state.selectedFilter.proficiency || this.state.selectedFilter.grupoId)) {
            this.limparDadosFiltro();
        } else if (this.ehPortuguesAcimaDoQuartoAnoConsolidado() && this.state.selectedFilter.proficiency) {
            this.limparDadosFiltro();
        }
    }

    limparDadosFiltro() {
        var novoFiltro = this.state.selectedFilter;
        novoFiltro.proficiency = "";
        novoFiltro.grupoId = "";
        this.setState({
            selectedFilter: novoFiltro,
            selectedProficiency: "",
        });
    }

    initialFilterChange(event) {
        var filters = this.props.pollReport.filters;
        var index = event.nativeEvent.target.selectedIndex;
        var label = event.nativeEvent.target[index].text;
        var grupos = [{ value: "", label: "" }].concat(this.props.sondagemPortugues.grupos) ?
            this.props.sondagemPortugues.grupos.map(grupo => {
                return ({
                    value: grupo.id,
                    label: grupo.descricao
                });
            }) : [];

        this.setState({
            selectedFilter: {
                discipline: label,
                proficiency: null,
                term: null,
                grupoId: null,
            },
            selectedProficiency: "",
            selectedTerm: "",
            proficiencies: filters[event.target.value].proficiencies,
            grupos,
            grupoSelecionado: "",
            terms: filters[event.target.value].terms
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
                grupoId: selectedFilter.grupoId
            },
            selectedProficiency: selectedProficiency,
            grupoSelecionado: "",
        });
    }

    onChangeGrupo(event) {
        var selectedFilter = this.state.selectedFilter;
        this.setState({
            selectedFilter: {
                discipline: selectedFilter.discipline,
                proficiency: selectedFilter.proficiency,
                term: selectedFilter.term,
                grupoId: event.target.value
            },
            grupoSelecionado: event.target.value
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
                grupoId: selectedFilter.grupoId,
            },
            selectedTerm: selectedTerm
        });
    }

    setSelectedFilter() {
        this.props.pollReportsMethods.resetPollReportFilter();
        this.props.pollReportsMethods.setPollReportFilter(this.state.selectedFilter);

        var parameters = this.state.selectedFilter;
        parameters.classroomReport = this.props.poll.selectedFilter.classroomCodeEol === "" ? false : true;
        parameters.codigoDRE = this.props.poll.selectedFilter.dreCodeEol === "todas" ? "" : this.props.poll.selectedFilter.dreCodeEol;
        parameters.CodigoEscola = this.props.poll.selectedFilter.schoolCodeEol === "todas" ? "" : this.props.poll.selectedFilter.schoolCodeEol;
        parameters.CodigoCurso = this.props.poll.selectedFilter.yearClassroom;
        parameters.CodigoTurmaEol = this.props.poll.selectedFilter.classroomCodeEol === null ? "" : this.props.poll.selectedFilter.classroomCodeEol;
        parameters.SchoolYear = this.props.poll.selectedFilter.schoolYear;
        parameters.grupoId = this.ehPortuguesAcimaDoQuartoAnoConsolidado() ? this.state.grupoSelecionado : null;
        this.props.pollReportsMethods.resetData();
        this.props.pollReportsMethods.getPollReport(parameters);
    }

    ehMatematicaAcimaDoSetimoAnoConsolidado() {
        return Number(this.props.poll.selectedFilter.yearClassroom) >= 7 &&
            this.state.selectedFilter.discipline === "Matemática"
    }

    ehPortuguesAcimaDoQuartoAnoConsolidado(){
       return Number(this.props.poll.selectedFilter.yearClassroom) >=4 &&
       this.state.selectedFilter.discipline === "Língua Portuguesa"
    }

    checkButton() {
        var parameters = this.state.selectedFilter;

        if (this.ehMatematicaAcimaDoSetimoAnoConsolidado()) {
            return !parameters.discipline || !parameters.term
        } else if (this.ehPortuguesAcimaDoQuartoAnoConsolidado()) {
            return !parameters.discipline || !parameters.term || !parameters.grupoId
        } else {
            return !parameters.discipline || !parameters.term || !parameters.proficiency
        }
    }

    restricaoDisciplina(disciplina) {
        return this.props.user.activeRole.roleName === ROLES_ENUM.PROFESSOR &&
            !DISCIPLINES_ENUM.PossuiDisciplinaRegencia(this.props.filters.listDisciplines) &&
            !DISCIPLINES_ENUM.PossuiDisciplina(disciplina, this.props.filters.listDisciplines);
    }

    render() {
        return (
            <div className="d-flex flex-column d-inline-flex">
                <span className="sc-text-blue sc-text-size-1">
                    Filtro para Relatórios
            </span>
                <div className="pt-2 d-inline-flex">
                    <SelectChangeColor
                        className="custom-select-sm"
                        defaultText="Matéria"
                        options={this.initialFilter}
                        onChange={this.initialFilterChange}
                    />
                    <div className="px-2"></div>
                    <SelectChangeColor
                        className="custom-select-sm"
                        defaultText="Proficiência"
                        options={this.state.proficiencies}
                        onChange={this.onChangeProficiency}
                        value={this.state.selectedProficiency}
                        resetColor={!this.state.selectedProficiency}
                        disabled={this.ehMatematicaAcimaDoSetimoAnoConsolidado() || this.ehPortuguesAcimaDoQuartoAnoConsolidado()}
                    />
                    {this.ehPortuguesAcimaDoQuartoAnoConsolidado() && <>
                        <div className="px-2" />
                        <SelectChangeColor
                            className="custom-select-sm"
                            defaultText="Grupo"
                            options={this.state.grupos}
                            onChange={this.onChangeGrupo}
                            value={this.props.grupoSelecionado}
                            resetColor={!this.state.grupoSelecionado}
                        />
                    </>
                    }
                    <div className="px-2"></div>
                    <SelectChangeColor
                        className="custom-select-sm"
                        defaultText="Período"
                        options={this.state.terms}
                        onChange={this.onChangeTerm}
                        value={this.state.selectedTerm}
                        resetColor={this.state.selectedTerm === "" ? true : false}
                    />
                    <div className="px-2"></div>
                    <button
                        type="button"
                        className="btn btn-sm btn-outline-primary"
                        style={{ width: 109 }}
                        onClick={this.setSelectedFilter}
                        disabled={this.checkButton()}
                    >
                        Buscar
              </button>
                </div>
            </div>
        );
    }
}

export default connect(
    (state) => ({
        pollReport: state.pollReport,
        poll: state.poll,
        sondagemPortugues: state.sondagemPortugues,
        filters: state.filters,
        user: state.user
    }),
    (dispatch) => ({
        pollReportsMethods: bindActionCreators(actionCreators, dispatch),
        sondagemPortuguesMethods: bindActionCreators(
            pollStoreActionCreators,
            dispatch
        ),
    })
)(PollReportFilter);