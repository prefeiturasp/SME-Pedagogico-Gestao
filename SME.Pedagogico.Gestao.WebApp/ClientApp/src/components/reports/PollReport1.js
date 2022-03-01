import React, { Component } from "react";
import Card from "../containers/Card";
import PollFilter from "../classRecord/PollFilter";
import PollReportFilter from "./PollReportFilter";
import PollReportBreadcrumb from "./PollReportBreadcrumb";
import PollReportPortugueseGrid from "./PollReportPortugueseGrid";
import PollReportMathGrid from "./PollReportMathGrid";
import PollReportPortugueseChart from "./PollReportPortugueseChart";
import PollReportMathChart from "./PollReportMathChart";
import PollReportMathNumbersChart from "./PollReportMathNumbersChart";
import PollReportMathChartClassroom from "./PollReportMathChartClassroom";
import { connect } from "react-redux";
import { actionCreators } from "../../store/PollReport";
import { bindActionCreators } from "redux";
import RelatorioPortuguesAutoral from "./RelatorioAutoral/RelatorioPortuguesAutoral";
import MensagemConfirmacaoImprimir from "./MensagemConfirmacaoImprimir";
import RelatorioMatematicaConsolidado from "./RelatorioMatematicaConsolidado";
import { GrupoDto } from "../dtos/grupoDto";
import RelatorioConsolidadoCapacidadeLeitura from "./RelatorioConsolidadeCapacidadeLeitura/RelatorioConsolidadoCapacidadeLeitura";
import RelatorioPorTurmaLeituraVozAlta from "./RelatorioPorTurmaLeituraVozAlta/RelatorioPorTurmaLeituraVozAlta";
import GraficoPorTurmaLeituraVozAlta from "./GraficoPorTurmaLeituraVozAlta/GraficoPorTurmaLeituraVozAlta";
import RelatorioMatematicaPorTurma from "./RelatorioMatematicaPorTurma/RelatorioMatematicaPorTurma";
import GraficoMatematicaPorTurma from "./GraficoMatematicaPorTurma/GraficoMatematicaPorTurma";
import RelatorioPorTurmaProducaoTexto from "./RelatorioPorTurmaProducaoTexto/RelatorioPorTurmaProducaoTexto";
import GraficoPorTurmaProducaoTexto from "./GraficoPorTurmaProducaoTexto/GraficoPorTurmaProducaoTexto";
import RelatorioPorTurmaCapacidadeLeitura from "./RelatorioPorTurmaCapacidadeLeitura/RelatorioPorTurmaCapacidadeLeitura";
import GraficoPorTurmaCapacidadeLeitura from "./GraficoPorTurmaCapacidadeLeitura/GraficoPorTurmaCapacidadeLeitura";
import GraficoConsolidadoLeituraVozAlta from "./GraficoConsolidadoLeituraVozAlta";
import GraficoConsolidadoProducaoTexto from "./GraficoConsolidadoProducaoTexto";
import GraficoConsolidadoMatematica from "./GraficoConsolidadoMatematica/GraficoConsolidadoMatematica";
import GraficoConsolidadoCapacidadeLeitura from "./GraficoConsolidadoCapacidadeLeitura";
import { DISCIPLINES_ENUM } from "../../Enums";

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

    const ehMatematica =
      discipline === DISCIPLINES_ENUM.DISCIPLINA_MATEMATICA.Descricao;
    const semestre = ehMatematica ? SEMESTRES[term] : 0;
    const bimestre = ehMatematica ? 0 : BIMESTRES[term];
    const proficienciaId = proficiencia.length ? proficiencia[0].id : 0;
    const anoLetivo = parseInt(SchoolYear);
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

  render() {
    var reportData = null;
    var chartData = null;
    let mathType = null;
    const { linkPdf } = this.props.pollReport;

    if (this.props.pollReport.showReport === true) {
      reportData = this.props.pollReport.data;
      chartData = this.props.pollReport.chartData;
    } else {
      reportData = [];
      chartData = [];
    }

    this.classroomReport = this.props.pollReport.selectedFilter.classroomReport;

    var indexes = [];

    if (this.props.pollReport.showReport === true) {
      if (
        chartData &&
        chartData.chartIdeaData !== undefined &&
        chartData.chartIdeaData.length > 0
      ) {
        chartData.totals = [];
        mathType = "consolidado";

        for (let i = 0; i < chartData.chartIdeaData.length; i++) {
          indexes.push(i);
          chartData.totals.push({
            name: "ORDEM " + chartData.chartIdeaData[i].order,
            idea: new Array(chartData.chartIdeaData[i].idea.length),
            result: new Array(chartData.chartResultData[i].result.length),
          });

          for (let j = 0; j < chartData.chartIdeaData[i].idea.length; j++) {
            switch (chartData.chartIdeaData[i].idea[j].description) {
              case "Acertou":
                chartData.totals[i].idea[0] =
                  chartData.chartIdeaData[i].idea[j].quantity;
                break;
              case "Errou":
                chartData.totals[i].idea[1] =
                  chartData.chartIdeaData[i].idea[j].quantity;
                break;
              case "Não Resolveu":
                chartData.totals[i].idea[2] =
                  chartData.chartIdeaData[i].idea[j].quantity;
                break;
              case "Sem preenchimento":
                chartData.totals[i].idea[3] =
                  chartData.chartIdeaData[i].idea[j].quantity;
                break;
              default:
                break;
            }
          }

          for (let j = 0; j < chartData.chartResultData[i].result.length; j++) {
            switch (chartData.chartResultData[i].result[j].description) {
              case "Acertou":
                chartData.totals[i].result[0] =
                  chartData.chartResultData[i].result[j].quantity;
                break;
              case "Errou":
                chartData.totals[i].result[1] =
                  chartData.chartResultData[i].result[j].quantity;
                break;
              case "Não Resolveu":
                chartData.totals[i].result[2] =
                  chartData.chartResultData[i].result[j].quantity;
                break;
              case "Sem preenchimento":
                chartData.totals[i].result[3] =
                  chartData.chartResultData[i].result[j].quantity;
                break;
              default:
                break;
            }
          }
        }
      } else {
        mathType = "turma";
      }
    }

    var numbers = false;

    if (
      reportData &&
      reportData !== [] &&
      reportData.length > 0 &&
      reportData[0].poll !== undefined
    )
      if (reportData[0].poll[0].order === 0) numbers = true;

    const montarRelatorioConsolidadosAcimaDoQuartoAno = (dados) => {
      switch (this.props.pollReport.selectedFilter.grupoId) {
        case GrupoDto.CAPACIDADE_LEITURA:
          return (
            <div className="mb-4">
              <RelatorioConsolidadoCapacidadeLeitura dados={dados} />
            </div>
          );
        case GrupoDto.LEITURA_EM_VOZ_ALTA:
          return <RelatorioPortuguesAutoral dados={dados} />;
        case GrupoDto.PRODUCAO_DE_TEXTO:
          return <RelatorioPortuguesAutoral dados={dados} />;
        default:
          break;
      }
    };

    const montarRelatorioPorTurmaPortuguesAcimaDoQuartoAno = (dados) => {
      switch (this.props.pollReport.selectedFilter.grupoId) {
        case GrupoDto.CAPACIDADE_LEITURA:
          return (
            <div className="mb-4">
              <RelatorioPorTurmaCapacidadeLeitura
                ordens={dados.ordens}
                perguntas={dados.perguntas}
                alunos={dados.alunos}
              />
            </div>
          );
        case GrupoDto.LEITURA_EM_VOZ_ALTA:
          return (
            <div className="mb-4">
              <RelatorioPorTurmaLeituraVozAlta
                perguntas={dados.perguntas}
                alunos={dados.alunos}
              />
            </div>
          );
        case GrupoDto.PRODUCAO_DE_TEXTO:
          return (
            <div className="mb-4">
              <RelatorioPorTurmaProducaoTexto
                perguntas={dados.perguntas}
                alunos={dados.alunos}
              />
            </div>
          );
        default:
          break;
      }
    };

    const montarGraficoPorTurmaPortuguesAcimaDoQuartoAno = (graficos) => {
      switch (this.props.pollReport.selectedFilter.grupoId) {
        case GrupoDto.CAPACIDADE_LEITURA:
          return (
            <div className="row">
              {graficos.map((dados) => {
                return <GraficoPorTurmaCapacidadeLeitura dados={dados} />;
              })}
            </div>
          );
        case GrupoDto.LEITURA_EM_VOZ_ALTA:
          return (
            <div className="row">
              {graficos.map((dados) => {
                return <GraficoPorTurmaLeituraVozAlta dados={dados} />;
              })}
            </div>
          );
        case GrupoDto.PRODUCAO_DE_TEXTO:
          return (
            <div className="mb-4">
              {graficos.map((dados) => {
                return <GraficoPorTurmaProducaoTexto dados={dados} />;
              })}
            </div>
          );
        default:
          break;
      }
    };

    const montarGraficoConsolidadosPortuguesAcimaDoQuartoAno = (graficos) => {
      switch (this.props.pollReport.selectedFilter.grupoId) {
        case GrupoDto.CAPACIDADE_LEITURA:
          return (
            <div className="row">
              {graficos.map((dados) => {
                return <GraficoConsolidadoCapacidadeLeitura dados={dados} />;
              })}
            </div>
          );
        case GrupoDto.LEITURA_EM_VOZ_ALTA:
          return (
            <div className="row">
              {graficos.map((dados) => {
                return <GraficoConsolidadoLeituraVozAlta dados={dados} />;
              })}
            </div>
          );
        case GrupoDto.PRODUCAO_DE_TEXTO:
          return (
            <div className="mb-4">
              {graficos.map((dados) => {
                return <GraficoConsolidadoProducaoTexto dados={dados} />;
              })}
            </div>
          );
        default:
          break;
      }
    };

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

              {this.props.pollReport.showReport ? (
                <div>
                  <PollReportBreadcrumb className="mt-4" name="Planilha" />

                  {reportData ? (
                    this.props.pollReport.selectedFilter.discipline ===
                    "Língua Portuguesa" ? (
                      Number(
                        this.props.pollReport.selectedFilter &&
                          this.props.pollReport.selectedFilter.CodigoCurso
                      ) >= 4 ? (
                        this.classroomReport ? (
                          montarRelatorioPorTurmaPortuguesAcimaDoQuartoAno(
                            reportData
                          )
                        ) : this.props.pollReport.selectedFilter.grupoId ===
                          GrupoDto.CAPACIDADE_LEITURA ? (
                          reportData &&
                          reportData.relatorioPorOrdem.map((dados) =>
                            montarRelatorioConsolidadosAcimaDoQuartoAno(dados)
                          )
                        ) : (
                          montarRelatorioConsolidadosAcimaDoQuartoAno(
                            reportData
                          )
                        )
                      ) : (
                        <PollReportPortugueseGrid
                          className="mt-3"
                          classroomReport={this.classroomReport}
                          data={reportData}
                        />
                      )
                    ) : Number(
                        this.props.pollReport.selectedFilter.CodigoCurso
                      ) >= 7 ? (
                      this.classroomReport ? (
                        <RelatorioMatematicaPorTurma
                          alunos={reportData.alunos}
                          perguntas={reportData.perguntas}
                        />
                      ) : (
                        reportData &&
                        reportData.perguntas &&
                        reportData.perguntas.map((dados) => {
                          return (
                            <RelatorioMatematicaConsolidado dados={dados} />
                          );
                        })
                      )
                    ) : (
                      <PollReportMathGrid
                        className="mt-3"
                        classroomReport={this.classroomReport}
                        data={reportData}
                      />
                    )
                  ) : null}

                  <PollReportBreadcrumb className="mt-5" name="Gráfico" />
                  {chartData ? (
                    this.props.pollReport.selectedFilter.discipline ===
                    "Língua Portuguesa" ? (
                      Number(
                        this.props.pollReport.selectedFilter &&
                          this.props.pollReport.selectedFilter.CodigoCurso
                      ) >= 4 ? (
                        this.classroomReport ? (
                          montarGraficoPorTurmaPortuguesAcimaDoQuartoAno(
                            chartData
                          )
                        ) : (
                          montarGraficoConsolidadosPortuguesAcimaDoQuartoAno(
                            chartData
                          )
                        )
                      ) : (
                        <PollReportPortugueseChart data={chartData} />
                      )
                    ) : this.props.pollReport.selectedFilter.discipline ===
                        "Matemática" &&
                      Number(
                        this.props.pollReport.selectedFilter.CodigoCurso
                      ) >= 7 ? (
                      <div className="row">
                        {this.classroomReport
                          ? chartData.map((dados, index) => {
                              return (
                                <GraficoMatematicaPorTurma
                                  dados={dados}
                                  index={index}
                                />
                              );
                            })
                          : chartData.map((dados, index) => {
                              return (
                                <GraficoConsolidadoMatematica
                                  dados={dados}
                                  index={index}
                                />
                              );
                            })}
                      </div>
                    ) : (
                      <div className="mt-4">
                        {
                          //Consilidado de Numeros
                          this.classroomReport === false &&
                            this.props.pollReport.selectedFilter.proficiency ===
                              "Números" && (
                              <PollReportMathNumbersChart
                                data={chartData.chartNumberData}
                              />
                            )
                        }
                        {
                          //Consilidado de Aditivo e Multiplicativo
                          this.classroomReport === false &&
                            this.props.pollReport.selectedFilter.proficiency !==
                              "Números" &&
                            indexes.map((index) => {
                              const chartId =
                                "ordem" + chartData.chartIdeaData[index].order;

                              return (
                                <PollReportMathChart
                                  key={chartId}
                                  chartIds={[
                                    chartId + "idea" + index,
                                    chartId + "result" + index,
                                  ]}
                                  data={chartData.totals[index]}
                                />
                              );
                            })
                        }
                        {
                          // Por Turma de Numeros
                          this.classroomReport === true &&
                            this.props.pollReport.selectedFilter.proficiency ===
                              "Números" &&
                            chartData !== undefined &&
                            Array.isArray(chartData) && (
                              <PollReportMathChartClassroom
                                data={chartData}
                                numbers={numbers}
                              />
                            )
                        }
                        {
                          // Por Turma Aditivo e Multiplicativo
                          this.classroomReport === true &&
                            this.props.pollReport.selectedFilter.proficiency !==
                              "Números" &&
                            chartData !== undefined &&
                            Array.isArray(chartData) &&
                            chartData.map((item, index) => {
                              const order =
                                item.name !== null
                                  ? item.name.replace(" ", "").toLowerCase()
                                  : "";
                              const chart1Id = order + "-ideaChart" + index;
                              const chart2Id = order + "-resultChart" + index;

                              return (
                                <PollReportMathChartClassroom
                                  data={item}
                                  chartIds={[chart1Id, chart2Id]}
                                  numbers={numbers}
                                />
                              );
                            })
                        }
                      </div>
                    )
                  ) : null}
                </div>
              ) : null}
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
