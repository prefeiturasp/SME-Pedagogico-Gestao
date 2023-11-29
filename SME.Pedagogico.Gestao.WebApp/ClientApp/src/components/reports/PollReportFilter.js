import React, { Component } from "react";
import SelectChangeColor from "../inputs/SelectChangeColor";
import { connect } from "react-redux";
import { actionCreators } from "../../store/PollReport";
import { bindActionCreators } from "redux";
import { actionCreators as pollStoreActionCreators } from "../../store/SondagemPortuguesStore";
import {
  DISCIPLINES_ENUM,
  SHORT_DISCIPLINES_ENUM,
  MATH_EXCLUDE_PROFICIENCIES_ID,
} from "../../Enums";
import { verificarDisciplina } from "../../utils";

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
      campoDisciplina: "",
    };

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
    this.mostrarDisciplina(
      DISCIPLINES_ENUM.DISCIPLINA_MATEMATICA,
      SHORT_DISCIPLINES_ENUM.MATH
    );
    this.mostrarDisciplina(
      DISCIPLINES_ENUM.DISCIPLINA_PORTUGUES,
      SHORT_DISCIPLINES_ENUM.PORT
    );

    for (let key in this.props.pollReport.filters) {
      this.initialFilter.push({
        value: key,
        label: this.props.pollReport.filters[key].name,
      });
    }
  }

  componentDidUpdate(prevProps) {
    if (
      this.ehMatematicaAcimaDoSetimoAnoConsolidado() &&
      (this.state.selectedFilter.proficiency ||
        this.state.selectedFilter.grupoId)
    ) {
      this.limparDadosFiltro();
    } else if (
      this.ehPortuguesAcimaDoQuartoAnoConsolidado() &&
      this.state.selectedFilter.proficiency
    ) {
      this.limparDadosFiltro();
    }

    const { yearClassroom, schoolYear } = this.props.poll.selectedFilter;
    const { yearClassroom: prevYearClassroom, schoolYear: prevSchoolYear } =
      prevProps.poll.selectedFilter;

    if (prevYearClassroom !== yearClassroom) {
      this.carregarProficiencia(this.state.campoDisciplina);
    }

    if (schoolYear !== prevSchoolYear) {
      const filters = this.props.pollReport.filters;
      const campoDisciplina = this.state.campoDisciplina;
      const disciplina = this.state.selectedFilter.discipline;

        const parametroPeriodo = "newTerms";

      this.setState((state) => ({
        ...state,
        selectedProficiency: "",
        selectedTerm: "",
        terms: filters[campoDisciplina][parametroPeriodo],
      }));
    }
  }

  mostrarDisciplina = (disciplina, disciplinaCurta) => {
    const { listDisciplines } = this.props.filters;

    if (listDisciplines.length) {
      const existDisciplina = verificarDisciplina(
        listDisciplines,
        disciplina.Descricao
      );
      if (!existDisciplina) {
        delete this.props.pollReport.filters[disciplinaCurta];
      }
    }
  };

  limparDadosFiltro() {
    const novoFiltro = this.state.selectedFilter;
    novoFiltro.proficiency = "";
    novoFiltro.grupoId = "";
    this.setState({
      selectedFilter: novoFiltro,
      selectedProficiency: "",
    });
  }

  excluirProficienciaId = (ano) => {
    switch (ano) {
      case 1:
        return MATH_EXCLUDE_PROFICIENCIES_ID.CAMPO_ADITIVO;
      case 4:
      case 5:
      case 6:
        return MATH_EXCLUDE_PROFICIENCIES_ID.NUMEROS;
      case 7:
      case 8:
      case 9:
        return MATH_EXCLUDE_PROFICIENCIES_ID.INEXISTENTE;
      default:
        return 0;
    }
  };

  carregarProficiencia = (disciplina) => {
    let { selectedProficiency, selectedFilter } = this.state;
    const { pollReport, poll } = this.props;
    const { filters } = pollReport;
    const { yearClassroom } = poll.selectedFilter;
    let { proficiency, discipline: prevDiscipline } = selectedFilter;
    let term = selectedFilter.term;

    const ano = Number(yearClassroom);
    let proficiencies = disciplina && filters[disciplina].proficiencies;
    const discipline = disciplina && filters[disciplina].name;
    const ehMath = disciplina === SHORT_DISCIPLINES_ENUM.MATH;
    const proficienciaId = ehMath && this.excluirProficienciaId(ano);

    if (proficienciaId) {
      const proficienciaSelecionada = proficiencies.filter(
        (item) => item.id === proficienciaId
      );

      proficiencies = proficiencies.filter(
        (item) => item.id !== proficienciaId
      );

      if (proficienciaSelecionada.length) {
        proficiency =
          proficiency === proficienciaSelecionada[0].label ? null : proficiency;

        selectedProficiency =
          selectedProficiency === proficienciaSelecionada[0].value
            ? null
            : selectedProficiency;
      }

      if (proficienciaId === 9 || !proficienciaSelecionada.length) {
        selectedProficiency = null;
      }
    }

    if (!ehMath && ano >= 4) {
      selectedProficiency = null;
    }

    if (prevDiscipline !== discipline) {
      selectedProficiency = null;
      proficiency = null;
      term = null;
    }

    this.setState({
      proficiencies,
      selectedProficiency,
      selectedFilter: {
        discipline,
        term,
        grupoId: selectedFilter.grupoId,
        proficiency,
      },
    });
  };

  initialFilterChange(event) {
    const filters = this.props.pollReport.filters;
    const index = event.nativeEvent.target.selectedIndex;
    const label = event.nativeEvent.target[index].text;

    const grupos = [{ value: "", label: "" }].concat(
      this.props.sondagemPortugues.grupos
    )
      ? this.props.sondagemPortugues.grupos.map((grupo) => {
          return {
            value: grupo.id,
            label: grupo.descricao,
          };
        })
      : [];
      const parametroPeriodo = "newTerms";

    this.setState({
      selectedFilter: {
        discipline: label,
        proficiency: null,
        term: null,
        grupoId: null,
      },
      selectedTerm: "",
      grupos,
      grupoSelecionado: "",
      terms: filters[event.target.value][parametroPeriodo],
      campoDisciplina: event.target.value,
    });

    this.carregarProficiencia(event.target.value);
  }

  onChangeProficiency(event) {
    const proficiencies = this.state.proficiencies;
    const index = event.nativeEvent.target.selectedIndex;
    const label = event.nativeEvent.target[index].text;
    const selectedFilter = this.state.selectedFilter;
    let selectedProficiency = null;

    for (let i = 0; i < proficiencies.length; i++)
      if (proficiencies[i].label === label) {
        selectedProficiency = proficiencies[i].value;
        break;
      }

    this.setState({
      selectedFilter: {
        discipline: selectedFilter.discipline,
        proficiency: label,
        term: selectedFilter.term,
        grupoId: selectedFilter.grupoId,
      },
      selectedProficiency: selectedProficiency,
      grupoSelecionado: "",
    });
  }

  onChangeGrupo(event) {
    const selectedFilter = this.state.selectedFilter;
    this.setState({
      selectedFilter: {
        discipline: selectedFilter.discipline,
        proficiency: selectedFilter.proficiency,
        term: selectedFilter.term,
        grupoId: event.target.value,
      },
      grupoSelecionado: event.target.value,
    });
  }

  onChangeTerm(event) {
    const terms = this.state.terms;
    const index = event.nativeEvent.target.selectedIndex;
    const label = event.nativeEvent.target[index].text;
    const selectedFilter = this.state.selectedFilter;
    let selectedTerm = null;

    for (let i = 0; i < terms.length; i++)
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
      selectedTerm: selectedTerm,
    });
  }

  setSelectedFilter() {
    this.props.pollReportsMethods.resetPollReportFilter();
    this.props.pollReportsMethods.setPollReportFilter(
      this.state.selectedFilter
    );

    const parameters = this.state.selectedFilter;
    const { schoolYear, yearClassroom } = this.props.poll.selectedFilter;
    const ehMatematica =
      parameters.discipline ===
      DISCIPLINES_ENUM.DISCIPLINA_MATEMATICA.Descricao;
    const codigoCursoMaiorIgualSete = yearClassroom >= "7";

    parameters.classroomReport =
      this.props.poll.selectedFilter.classroomCodeEol === "" ? false : true;
    parameters.codigoDRE =
      this.props.poll.selectedFilter.dreCodeEol === "todas"
        ? ""
        : this.props.poll.selectedFilter.dreCodeEol;
    parameters.CodigoEscola =
      this.props.poll.selectedFilter.schoolCodeEol === "todas"
        ? ""
        : this.props.poll.selectedFilter.schoolCodeEol;
    parameters.CodigoCurso = this.props.poll.selectedFilter.yearClassroom;
    parameters.CodigoTurmaEol =
      this.props.poll.selectedFilter.classroomCodeEol === null
        ? ""
        : this.props.poll.selectedFilter.classroomCodeEol;
    parameters.SchoolYear = this.props.poll.selectedFilter.schoolYear;
    parameters.grupoId = this.ehPortuguesAcimaDoQuartoAnoConsolidado()
      ? this.state.grupoSelecionado
      : null;
    this.props.pollReportsMethods.resetData();

    if (schoolYear === "2019" && ehMatematica && codigoCursoMaiorIgualSete) {
      return;
    }

    this.props.pollReportsMethods.getPollReport(parameters);
  }

  ehMatematicaAcimaDoSetimoAnoConsolidado() {
    return (
      Number(this.props.poll.selectedFilter.yearClassroom) >= 7 &&
      this.state.selectedFilter.discipline === "Matemática"
    );
  }

  ehPortuguesAcimaDoQuartoAnoConsolidado() {
    return (
      Number(this.props.poll.selectedFilter.yearClassroom) >= 4 &&
      this.state.selectedFilter.discipline === "Língua Portuguesa"
    );
  }

  checkButton() {
    const parameters = this.state.selectedFilter;
    const ehNovaMatematica =
      this.props.poll.selectedFilter.schoolYear >= 2022 &&
      parameters.discipline ===
        DISCIPLINES_ENUM.DISCIPLINA_MATEMATICA.Descricao;
    const desabilitarProeficiencia = ehNovaMatematica
      ? false
      : !parameters.proficiency;

    if (this.ehMatematicaAcimaDoSetimoAnoConsolidado()) {
      return !parameters.discipline || !parameters.term;
    } else if (this.ehPortuguesAcimaDoQuartoAnoConsolidado()) {
      return !parameters.discipline || !parameters.term || !parameters.grupoId;
    } else {
      return (
        !parameters.discipline || !parameters.term || desabilitarProeficiencia
      );
    }
  }

  verificaAno = (ano, anoEscolhido) => {
    return ano >= anoEscolhido;
  };

  mostrarProficiencia = () => {
    const anoEscolhido = Number(this.props.poll.selectedFilter.yearClassroom);
    const anoMatematica =
      this.props.poll.selectedFilter.schoolYear >= 2022 ? 4 : 7;

    switch (this.state.selectedFilter.discipline) {
      case DISCIPLINES_ENUM.DISCIPLINA_MATEMATICA.Descricao:
        return !this.verificaAno(anoEscolhido, anoMatematica);
      case DISCIPLINES_ENUM.DISCIPLINA_PORTUGUES.Descricao:
        return !this.verificaAno(anoEscolhido, 4);
      default:
        return true;
    }
  };

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
          {this.mostrarProficiencia() && (
            <>
              <div className="px-2"></div>
              <SelectChangeColor
                className="custom-select-sm"
                defaultText="Proficiência"
                options={this.state.proficiencies}
                onChange={this.onChangeProficiency}
                value={this.state.selectedProficiency || ""}
                resetColor={!this.state.selectedProficiency}
              />
            </>
          )}
          {this.ehPortuguesAcimaDoQuartoAnoConsolidado() && (
            <>
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
          )}
          <div className="px-2"></div>
          <SelectChangeColor
            className="custom-select-sm"
            defaultText="Período"
            options={this.state.terms}
            onChange={this.onChangeTerm}
            value={this.state.selectedTerm || ""}
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
            {this.props.pollReport.loadingSearchPollReport ? (
              <div
                className="spinner-border spinner-border-sm"
                style={{ marginLeft: 13.5, marginRight: 13.5 }}
              ></div>
            ) : (
              "Buscar"
            )}
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
    user: state.user,
  }),
  (dispatch) => ({
    pollReportsMethods: bindActionCreators(actionCreators, dispatch),
    sondagemPortuguesMethods: bindActionCreators(
      pollStoreActionCreators,
      dispatch
    ),
  })
)(PollReportFilter);
