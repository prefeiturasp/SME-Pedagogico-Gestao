import React, { Component } from "react";
import { bindActionCreators } from "redux";
import { connect } from "react-redux";

import Card from "../containers/Card";
import PollFilter from "../classRecord/PollFilter";
import PollReportFilter from "./PollReportFilter";
import MensagemConfirmacaoImprimir from "./MensagemConfirmacaoImprimir";

import { actionCreators } from "../../store/PollReport";

import { DISCIPLINES_ENUM } from "../../Enums";
import { componentRenderReport } from "./funcoes/componentRenderReport";
import { novaRenderizacaoComponente } from "./funcoes/novaRenderizacaoComponente";

class PollReport extends Component {
  constructor(props) {
    super(props);

    this.classroomReport = true;

    this.state = {
      showMessage: false,
      showPollFilter: false,
      messageType: "",
      ehDesabilitado: true,
    };

    this.openPollFilter = this.openPollFilter.bind(this);
  }

  componentDidUpdate(prevProps, prevState) {
    if (this.props.pollReport.showReport === true) {
      const {
        selectedFilter,
        showMessageSuccess,
        showMessageError,
        messageError,
      } = this.props.pollReport;
      const { showMessageSuccessPollReport, showMessageErrorPollReport } =
        this.props.pollReportMethods;
      const {
        discipline: componenteCurricular,
        proficiency: proficiencia,
        term: semestre,
      } = selectedFilter;

      const { yearClassroom: ano } = selectedFilter;
      const temProficiencia = ano < "7" ? proficiencia : "0";
      const valor = !!componenteCurricular && !!temProficiencia && !!semestre;

      if (prevState.ehDesabilitado === valor) {
        this.setState({
          ehDesabilitado: !valor,
        });
      }

      if (showMessageSuccess && !this.state.showMessage) {
        this.setState({ showMessage: true, messageType: "success" });
        showMessageSuccessPollReport(false);
      }

      if (showMessageError && !this.state.showMessage) {
        this.setState({ showMessage: true, messageType: "error" });
        showMessageErrorPollReport(false, messageError);
      }
    }
  }

  imprimir = () => {
    const { pollReportMethods, pollReport, user } = this.props;
    const { printingPollReport, printPollReport } = pollReportMethods;
    const { selectedFilter, filters } = pollReport;
    const { username: usuarioRf } = user;
    const {
      discipline,
      proficiency,
      SchoolYear,
      codigoDRE,
      CodigoEscola: ueCodigo,
      CodigoTurmaEol,
      CodigoCurso: ano,
      term,
      grupoId: grupoID,
    } = selectedFilter;

    const BIMESTRES = {
      "1° Bimestre": 1,
      "2° Bimestre": 2,
      "3° Bimestre": 3,
      "4° Bimestre": 4,
    };

    const SEMESTRES = {
      "1° Semestre": 1,
      "2° Semestre": 2,
    };

    printingPollReport(true);

    const componenteCurricular = Object.values(filters).filter(
      (item) => item.name === discipline
    );

    const proficiencia = componenteCurricular[0].proficiencies.filter(
      (item) => item.label === proficiency
    );

    const anoLetivo = parseInt(SchoolYear);
    const ehSondagemAntiga = anoLetivo < 2022;
    const ehMatematica =
      discipline === DISCIPLINES_ENUM.DISCIPLINA_MATEMATICA.Descricao;
    const semestre = ehMatematica && ehSondagemAntiga ? SEMESTRES[term] : 0;
    const bimestre = ehMatematica && ehSondagemAntiga ? 0 : BIMESTRES[term];
    const proficienciaId = proficiencia.length ? proficiencia[0].id : 0;
    const dreCodigo = parseInt(codigoDRE) || 0;
    const turmaCodigo = parseInt(CodigoTurmaEol) || 0;
    const componenteCurricularId = componenteCurricular[0].id;
    const grupoId = grupoID || "";

    printPollReport({
      anoLetivo,
      dreCodigo,
      ueCodigo,
      ano,
      turmaCodigo,
      componenteCurricularId,
      proficienciaId,
      semestre,
      bimestre,
      grupoId,
      usuarioRf,
    });
  };

  acaoFeedBack = () => {
    this.setState({ showMessage: false });
  };

  openPollFilter(value) {
    this.setState({
      showPollFilter: value,
    });
  }

  montarMensagemSondagemNaoDisponivel = () => {
    return (
      <div className="d-flex mt-4 justify-content-center sc-text-blue sc-text-size-2">
        Sondagem não disponível neste ano letivo
      </div>
    );
  };

  componentRender() {
    const { SchoolYear, discipline, CodigoCurso } =
      this.props.pollReport.selectedFilter;
    const ehMatematica =
      discipline === DISCIPLINES_ENUM.DISCIPLINA_MATEMATICA.Descricao;
    const codigoCursoMaiorIgualSete = CodigoCurso >= "7";

    if (SchoolYear >= "2022" && ehMatematica) {
      return novaRenderizacaoComponente(this.props);
    }
    if (SchoolYear === "2019" && ehMatematica && codigoCursoMaiorIgualSete) {
      return this.montarMensagemSondagemNaoDisponivel();
    }
    return componentRenderReport(this.props);
  }

  render() {
    const { linkPdf } = this.props.pollReport;

    return (
      <>
        <Card className="mb-3 mt-5">
          <PollFilter reports={true} resultClick={this.openPollFilter} />
        </Card>

        <MensagemConfirmacaoImprimir
          exibir={this.state.showMessage}
          messageType={this.state.messageType}
          acaoFeedBack={() => this.acaoFeedBack()}
          linkPdf={linkPdf}
        />
        {this.state.showPollFilter && (
          <Card id="pollReport-card">
            <div className="py-2 px-3">
              <div className="d-flex">
                <PollReportFilter />
                <div className="flex-fill d-flex justify-content-end">
                  <div className="mt-auto">
                    <button
                      type="button"
                      className="btn btn-sm btn-outline-primary"
                      style={{ width: 48 }}
                      onClick={() => this.imprimir()}
                      disabled={this.state.ehDesabilitado}
                    >
                      <i className="fas fa-print"></i>
                    </button>
                  </div>
                </div>
              </div>
              {this.componentRender()}
            </div>
          </Card>
        )}
      </>
    );
  }
}

export default connect(
  (state) => ({
    pollReport: state.pollReport,
    poll: state.poll,
    user: state.user,
    filters: state.filters,
  }),
  (dispatch) => ({
    pollReportMethods: bindActionCreators(actionCreators, dispatch),
  })
)(PollReport);
