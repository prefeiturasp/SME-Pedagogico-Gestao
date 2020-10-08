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
import ReportService from "../../service/ReportService";
import { connect } from "react-redux";
import { actionCreators } from "../../store/PollReport";
import { bindActionCreators } from "redux";
import MensagemConfirmacaoImprimir from "./MensagemConfirmacaoImprimir";
import RelatorioMatematicaConsolidado from "./RelatorioMatematicaConsolidado";

class PollReport extends Component {
  constructor(props) {
    super(props);

    this.classroomReport = true;

    this.state = {
      showMessage: false,
      showPollFilter: false,
      ehDesabilitado: true,
    };

    this.printClick = this.printClick.bind(this);
    this.openPollFilter = this.openPollFilter.bind(this);
  }

  componentDidUpdate(prevProps, prevState) {
    if (this.props.pollReport.showReport === true) {
      const {
        discipline: componenteCurricular,
        proficiency: proficiencia,
        term: semestre,
      } = this.props.pollReport.selectedFilter;

      const valor = !!componenteCurricular && !!proficiencia && !!semestre;
      if (prevState.ehDesabilitado === valor) {
        this.setState({
          ehDesabilitado: !valor,
        });
      }
    }
  }

  imprimir = () => {
    this.setState({ showMessage: true });

    const discipline = Object.values(this.props.pollReport.filters).filter(
      (item) => item.name === this.props.pollReport.selectedFilter.discipline
    );

    const proficiencia = discipline[0].proficiencies.filter(
      (item) => item.label === this.props.pollReport.selectedFilter.proficiency
    );

    const { username: usuarioRf } = this.props.user;
    const {
      SchoolYear,
      codigoDRE,
      CodigoEscola,
      CodigoTurmaEol,
      CodigoCurso,
      term,
    } = this.props.pollReport.selectedFilter;
    const semestre = term === "1° Semestre" ? 1 : 2;

    const payload = {
      anoLetivo: parseInt(SchoolYear),
      dreCodigo: parseInt(codigoDRE),
      ueCodigo: parseInt(CodigoEscola),
      ano: CodigoCurso,
      turmaCodigo: parseInt(CodigoTurmaEol),
      componenteCurricularId: discipline[0].id,
      proficienciaId: proficiencia[0].id,
      semestre,
      usuarioRf,
    };

    this.props.pollReportMethods.printPollReport(payload);
  };

  printClick() {
    var userName = this.props.user.username;
    var AnoCurso = this.props.pollReport.selectedFilter.CodigoCurso;
    var CodigoEscola =
      this.props.filters.activeSchollsCode == ""
        ? "todas"
        : this.props.filters.activeSchollsCode;
    var CodigoTurmaEol =
      this.props.pollReport.selectedFilter.CodigoTurmaEol == ""
        ? "Todas"
        : this.props.pollReport.selectedFilter.CodigoTurmaEol;
    var CodigoDre = this.props.filters.activeDreCode;
    var Disciplina = this.props.pollReport.selectedFilter.discipline;
    var Proeficiencia = this.props.pollReport.selectedFilter.proficiency;
    var periodo = this.props.pollReport.selectedFilter.term;
    var RelatorioDeClasse = this.props.pollReport.selectedFilter
      .classroomReport;
    var Dres = this.props.filters.listDres;

    if ("codigoDRE" in Dres[0]) {
      var nomeDre =
        CodigoDre == "todas"
          ? "Todas"
          : Dres.filter((x) => x.codigoDRE == CodigoDre)[0].nomeDRE.substring(
              31
            );
    } else {
      var nomeDre =
        CodigoDre == "todas"
          ? "Todas"
          : Dres.filter((x) => x.codigo == CodigoDre)[0].nome.substring(31);
    }

    if (this.props.filters.scholls[0] != undefined) {
      if ("codigoEscola" in this.props.filters.scholls[0]) {
        var nomeEscola =
          CodigoEscola == "todas"
            ? "Todas"
            : this.props.filters.scholls.filter(
                (x) => x.codigoEscola == CodigoEscola
              )[0].nomeEscola;
      } else {
        var nomeEscola =
          CodigoEscola == "todas"
            ? "Todas"
            : this.props.filters.scholls.filter(
                (x) => x.codigo == CodigoEscola
              )[0].nome;
      }
    } else {
      var nomeEscola =
        CodigoEscola == "todas"
          ? "Todas"
          : this.props.filters.scholls.filter(
              (x) => x.codigo == CodigoEscola
            )[0].nome;
    }

    var pollReportData = this.props.pollReport.data;
    var chartData = this.props.pollReport.chartData;

    var especial = AnoCurso == "3" && Proeficiencia == "Escrita" ? true : false;

    if (
      Disciplina == "Língua Portuguesa" &&
      Proeficiencia == "Escrita" &&
      RelatorioDeClasse == false &&
      !especial
    ) {
      var preSilabicoValor = 0;
      var silabicoComValor = 0;
      var silabicoSemValor = 0;
      var silabicoAlfabeticoValor = 0;
      var alfabeticoValor = 0;
      var totalStudents = 0;

      var preSilabicoPorcentagem = 0;
      var silabicoSemValorPorcentagem = 0;
      var silabicoComValorPorcentagem = 0;
      var silabicoAlfabeticoPorcentagem = 0;
      var alfabeticoPorcentagem = 0;
      var totalPercentage = 0;

      // chartData
      var preSilabicoChart = 0;
      var silabicoSemValorChart = 0;
      var silabicoComValorChart = 0;
      var silabicoAlfabeticoChart = 0;
      var alfabeticoChart = 0;

      if (pollReportData.length > 0) {
        for (var index in pollReportData) {
          if (pollReportData[index].optionName == "Alfabético") {
            alfabeticoValor = pollReportData[index].studentQuantity;
            alfabeticoPorcentagem = pollReportData[index].studentPercentage;
            alfabeticoChart = chartData[index].value;
          }

          if (pollReportData[index].optionName == "Pré-Silábico") {
            preSilabicoValor = pollReportData[index].studentQuantity;
            preSilabicoPorcentagem = pollReportData[index].studentPercentage;
            preSilabicoChart = chartData[index].value;
          }
          if (pollReportData[index].optionName == "Silábico alfabético") {
            silabicoAlfabeticoValor = pollReportData[index].studentQuantity;
            silabicoAlfabeticoPorcentagem =
              pollReportData[index].studentPercentage;
            silabicoAlfabeticoChart = chartData[index].value;
          }
          if (pollReportData[index].optionName == "Silábico sem valor") {
            silabicoSemValor = pollReportData[index].studentQuantity;
            silabicoSemValorPorcentagem =
              pollReportData[index].studentPercentage;
            silabicoSemValorChart = chartData[index].value;
          }
          if (pollReportData[index].optionName == "Silábico com valor") {
            silabicoComValor = pollReportData[index].studentQuantity;
            silabicoComValorPorcentagem =
              pollReportData[index].studentPercentage;
            silabicoComValorChart = chartData[index].value;
          }

          totalStudents += pollReportData[index].studentQuantity;
          totalPercentage += pollReportData[index].studentPercentage;
        }
      }

      var report = {
        headerFooter: {
          teacherName: this.props.user.username, //this.props.user.username, // rf do professor
          dreName: nomeDre, // Nome da Dre pegar nome da DRE
          schoolName: nomeEscola, // Nome da escola pegar nome da Escola
          classYear: AnoCurso, // ano da turma
          className: CodigoTurmaEol, // turma PEgar nome da Turma
          subject: Disciplina, // Portugues
          testName: Proeficiencia, // Escrita
          period: periodo, // 1 BIMESTRES
          type: RelatorioDeClasse == true ? "Por Turma" : "Consolidado", // CONSOLIDADO
        },
        table: {
          pS_Value: preSilabicoValor,
          ssV_Value: silabicoSemValor,
          scV_Value: silabicoComValor,
          sA_Value: silabicoAlfabeticoValor,
          a_Value: alfabeticoValor,
          total_Value: totalStudents,
          pS_Percentage: preSilabicoPorcentagem,
          ssV_Percentage: silabicoSemValorPorcentagem,
          scV_Percentage: silabicoComValorPorcentagem,
          sA_Percentage: silabicoAlfabeticoPorcentagem,
          a_Percentage: alfabeticoPorcentagem,
          total_Percentage: totalPercentage,
        },
        chart: {
          pS_Value: preSilabicoChart,
          ssV_Value: silabicoSemValorChart,
          scV_Value: silabicoComValorChart,
          sA_Value: silabicoAlfabeticoChart,
          a_Value: alfabeticoChart,
        },
      };

      return fetch(
        "http://hom-latexservice.sme.prefeitura.sp.gov.br/api/Recipes/PollReportPortugueseWriting",
        {
          method: "post",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify(report),
        }
      )
        .then((response) => response.blob())
        .then((blob) => {
          // 2. Create blob link to download
          const url = window.URL.createObjectURL(new Blob([blob]));
          const link = document.createElement("a");
          link.href = url;
          link.setAttribute("download", "relatorio.pdf");
          // 3. Append to html page
          document.body.appendChild(link);
          // 4. Force download
          // link.printClick(url);
          link.click();
          //  var w = window.open(link.click());
          //    w.print();
          //     w.close();
          // 5. Clean up and remove the link
          link.parentNode.removeChild(link);
        });
    } else if (
      (Disciplina == "Língua Portuguesa" &&
        Proeficiencia == "Leitura" &&
        RelatorioDeClasse == false) ||
      especial
    ) {
      var nivel1 = 0;
      var nivel2 = 0;
      var nivel3 = 0;
      var nivel4 = 0;

      var nivel1Porcentagem = 0;
      var nivel2Porcentagem = 0;
      var nivel3Porcentagem = 0;
      var nivel4Porcentagem = 0;

      var nivel1Chart = 0;
      var nivel2Chart = 0;
      var nivel3Chart = 0;
      var nivel4Chart = 0;

      var totalStudents = 0;
      var totalPorcentagem = 0;

      if (pollReportData.length > 0) {
        for (var index in pollReportData) {
          if (pollReportData[index].optionName == "Nivel1") {
            nivel1 = pollReportData[index].studentQuantity;
            nivel1Porcentagem = pollReportData[index].studentPercentage;
            nivel1Chart = chartData[index].value;
          }
          if (pollReportData[index].optionName == "Nivel2") {
            nivel2 = pollReportData[index].studentQuantity;
            nivel2Porcentagem = pollReportData[index].studentPercentage;
            nivel2Chart = chartData[index].value;
          }
          if (pollReportData[index].optionName == "Nivel3") {
            nivel3 = pollReportData[index].studentQuantity;
            nivel3Porcentagem = pollReportData[index].studentPercentage;
            nivel3Chart = chartData[index].value;
          }
          if (pollReportData[index].optionName == "Nivel4") {
            nivel4 = pollReportData[index].studentQuantity;
            nivel4Porcentagem = pollReportData[index].studentPercentage;
            nivel4Chart = chartData[index].value;
          }

          totalStudents += pollReportData[index].studentQuantity;
          totalPorcentagem += pollReportData[index].studentPercentage;
        }
        var report = {
          headerFooter: {
            teacherName: this.props.user.username, // rf do professor
            dreName: nomeDre, // Nome da Dre pegar nome da DRE
            schoolName: nomeEscola, // Nome da escola pegar nome da Escola
            classYear: AnoCurso, // ano da turma
            className: CodigoTurmaEol, // turma PEgar nome da Turma
            subject: Disciplina, // Portugues
            testName: Proeficiencia, // Escrita
            period: periodo, // 1 BIMESTRES
            type: RelatorioDeClasse == true ? "Por Turma" : "Consolidado", // cONSOLIDADO
          },
          table: {
            n1_Value: nivel1,
            n2_Value: nivel2,
            n3_Value: nivel3,
            n4_Value: nivel4,
            total_Value: totalStudents,
            n1_Percentage: nivel1Porcentagem,
            n2_Percentage: nivel2Porcentagem,
            n3_Percentage: nivel3Porcentagem,
            n4_Percentage: nivel4Porcentagem,
            total_Percentage: totalPorcentagem,
          },
          chart: {
            n1_Value: nivel1Chart,
            n2_Value: nivel2Chart,
            n3_Value: nivel3Chart,
            n4_Value: nivel4Chart,
          },
        };

        return fetch(
          "http://hom-latexservice.sme.prefeitura.sp.gov.br/api/Recipes/PollReportPortugueseReading",
          {
            method: "post",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(report),
          }
        )
          .then((response) => response.blob())
          .then((blob) => {
            // 2. Create blob link to download
            const url = window.URL.createObjectURL(new Blob([blob]));
            const link = document.createElement("a");
            link.href = url;
            link.setAttribute("download", "relatorio.pdf");
            // 3. Append to html page
            document.body.appendChild(link);
            // 4. Force download
            // link.printClick(url);
            link.click();
            //  var w = window.open(link.click());
            //    w.print();
            //     w.close();
            // 5. Clean up and remove the link
            link.parentNode.removeChild(link);
          });
      }
    } else if (
      Disciplina == "Língua Portuguesa" &&
      Proeficiencia == "Escrita" &&
      RelatorioDeClasse == true
    ) {
    } else if (
      Disciplina == "Língua Portuguesa" &&
      Proeficiencia == "Leitura" &&
      RelatorioDeClasse == true
    ) {
      var report = {
        headerFooter: {
          teacherName: this.props.user.username, // rf do professor
          dreName: nomeDre, // Nome da Dre pegar nome da DRE
          schoolName: nomeEscola, // Nome da escola pegar nome da Escola
          classYear: AnoCurso, // ano da turma
          className: CodigoTurmaEol, // turma PEgar nome da Turma
          subject: Disciplina, // Portugues
          testName: Proeficiencia, // Escrita
          period: periodo, // 1 BIMESTRES
          type: RelatorioDeClasse == true ? "Por Turma" : "Consolidado", // CONSOLIDADO
        },
        table: {
          itemTemplatePath: "string",
          items: pollReportData,
        },
        chart: {
          n1_Value: 0,
          n2_Value: 0,
          n3_Value: 0,
          n4_Value: 0,
        },
      };

      return fetch(
        "http://hom-latexservice.sme.prefeitura.sp.gov.br/api/Recipes/PollReportPortugueseReadingClass",
        {
          method: "post",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify(report),
        }
      )
        .then((response) => response.blob())
        .then((blob) => {
          // 2. Create blob link to download
          const url = window.URL.createObjectURL(new Blob([blob]));
          const link = document.createElement("a");
          link.href = url;
          link.setAttribute("download", "relatorio.pdf");
          // 3. Append to html page
          document.body.appendChild(link);
          // 4. Force download
          // link.printClick(url);
          link.click();
          //  var w = window.open(link.click());
          //    w.print();
          //     w.close();
          // 5. Clean up and remove the link
          link.parentNode.removeChild(link);
        });
    } else if (
      Disciplina == "Matemática" &&
      Proeficiencia == "Campo Aditivo" &&
      RelatorioDeClasse == false
    ) {
      var itemsIdeia = pollReportData.ideaResults;
      var itemsResults = pollReportData.resultResults;
      var totals = pollReportData.totals;
      var itemscharts = chartData;

      //   var ideia =  itemsIdeia.map((x) => {
      //         x.ideia_Acertou_Percentage = x.correctIdeaPercentage
      //         delete x.correctIdeaPercentage
      //         x.ideia_Acertou_Value = x.correctIdeaQuantity
      //         delete x.correctIdeaQuantity
      //         x.ideia_Errou_Value = x.incorrectIdeaQuantity
      //         delete x.incorrectIdeaQuantity
      //         x.ideia_Errou_Percentage = x.incorrectIdeaPercentage
      //         delete x.incorrectIdeaPercentage
      //         x.ideia_NaoResolveu_Value  = x.notAnsweredIdeaQuantity
      //         delete  x.notAnsweredIdeaQuantity
      //         x.resultado_NaoResolveu_Percentage = x.notAnsweredIdeaPercentage
      //         delete x.notAnsweredIdeaPercentage
      //         return x })

      //         var results =  itemsResults.map((x) => {
      //             x.resultado_Acertou_Percentage = x.correctResultPercentage
      //             delete x.correctResultPercentage
      //             x.resultado_Acertou_Value = x.correctResultQuantity
      //             delete x.correctResultQuantity
      //             x.resultado_Errou_Percentage = x.incorrectResultPercentage
      //             delete x.incorrectResultPercentage
      //             x.resultado_Errou_Value = x.incorrectResultQuantity
      //             delete x.incorrectResultQuantity
      //             x.resultado_NaoResolveu_Percentage  = x.notAnsweredResultPercentage
      //             delete  x.notAnsweredResultPercentage
      //             x.resultado_NaoResolveu_Value = x.notAnsweredResultQuantity
      //             delete x.notAnsweredResultQuantity
      //             return x })

      var tables = [];

      for (var index in itemsIdeia) {
        tables.push({
          tableName: "ORDEM " + "" + itemsResults[index].orderName,
          ideia_Acertou_Value: itemsIdeia[index].correctIdeaQuantity,
          ideia_Errou_Value: itemsIdeia[index].incorrectIdeaQuantity,
          ideia_NaoResolveu_Value: itemsIdeia[index].notAnsweredIdeaQuantity,
          ideia_Total_Value: totals[index].totalStudentIdeaQuantity,
          resultado_Acertou_Value: itemsResults[index].correctResultQuantity,
          resultado_Errou_Value: itemsResults[index].incorrectResultQuantity,
          resultado_NaoResolveu_Value:
            itemsResults[index].notAnsweredResultQuantity,
          resultado_Total_Value: totals[index].totalStudentResultQuantity,
          ideia_Acertou_Percentage: itemsIdeia[index].correctIdeaPercentage,
          ideia_Errou_Percentage: itemsIdeia[index].incorrectIdeaPercentage,
          ideia_NaoResolveu_Percentage:
            itemsIdeia[index].notAnsweredIdeaPercentage,
          ideia_Total_Percentage: totals[index].totalStudentIdeaPercentage,
          resultado_Acertou_Percentage:
            itemsResults[index].correctResultPercentage,
          resultado_Errou_Percentage:
            itemsResults[index].incorrectResultPercentage,
          resultado_NaoResolveu_Percentage:
            itemsResults[index].notAnsweredResultPercentage,
          resultado_Total_Percentage:
            totals[index].totalStudentResultPercentage,
        });
      }

      var charts = [];

      for (var index in itemscharts.chartIdeaData) {
        charts.push({
          chartName: itemscharts.totals[index].name,
          dataName: "DataName",
          ideia_Acertou_Value:
            itemscharts.chartIdeaData[index].idea[0].quantity,
          ideia_Errou_Value: itemscharts.chartIdeaData[index].idea[1].quantity,
          ideia_NaoResolveu_Value:
            itemscharts.chartIdeaData[index].idea[2].quantity,
          resultado_Acertou_Value:
            itemscharts.chartResultData[index].result[0].quantity,
          resultado_Errou_Value:
            itemscharts.chartResultData[index].result[1].quantity,
          resultado_NaoResolveu_Value:
            itemscharts.chartResultData[index].result[2].quantity,
        });
      }

      var report = {
        headerFooter: {
          teacherName: this.props.user.username, // rf do professor
          dreName: nomeDre, // Nome da Dre pegar nome da DRE
          schoolName: nomeEscola, // Nome da escola pegar nome da Escola
          classYear: AnoCurso, // ano da turma
          className: CodigoTurmaEol, // turma PEgar nome da Turma
          subject: Disciplina, // Portugues
          testName: Proeficiencia, // Escrita
          period: periodo, // 1 BIMESTRES
          type: RelatorioDeClasse == true ? "Por Turma" : "Consolidado", // Consolidado
        },
        tables,

        charts,
      };

      return fetch(
        "http://hom-latexservice.sme.prefeitura.sp.gov.br/api/Recipes/PollReportMathSum",
        {
          method: "post",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify(report),
        }
      )
        .then((response) => response.blob())
        .then((blob) => {
          // 2. Create blob link to download
          const url = window.URL.createObjectURL(new Blob([blob]));
          const link = document.createElement("a");
          link.href = url;
          link.setAttribute("download", "relatorio.pdf");
          // 3. Append to html page
          document.body.appendChild(link);
          // 4. Force download
          // link.printClick(url);
          link.click();
          //  var w = window.open(link.click());
          //    w.print();
          //     w.close();
          // 5. Clean up and remove the link
          link.parentNode.removeChild(link);
        });
    } else if (
      Disciplina == "Matemática" &&
      Proeficiencia == "Campo Multiplicativo" &&
      RelatorioDeClasse == false
    ) {
      var itemsIdeia = pollReportData.ideaResults;
      var itemsResults = pollReportData.resultResults;
      var totals = pollReportData.totals;
      var itemscharts = chartData;

      //   var ideia =  itemsIdeia.map((x) => {
      //         x.ideia_Acertou_Percentage = x.correctIdeaPercentage
      //         delete x.correctIdeaPercentage
      //         x.ideia_Acertou_Value = x.correctIdeaQuantity
      //         delete x.correctIdeaQuantity
      //         x.ideia_Errou_Value = x.incorrectIdeaQuantity
      //         delete x.incorrectIdeaQuantity
      //         x.ideia_Errou_Percentage = x.incorrectIdeaPercentage
      //         delete x.incorrectIdeaPercentage
      //         x.ideia_NaoResolveu_Value  = x.notAnsweredIdeaQuantity
      //         delete  x.notAnsweredIdeaQuantity
      //         x.resultado_NaoResolveu_Percentage = x.notAnsweredIdeaPercentage
      //         delete x.notAnsweredIdeaPercentage
      //         return x })

      //         var results =  itemsResults.map((x) => {
      //             x.resultado_Acertou_Percentage = x.correctResultPercentage
      //             delete x.correctResultPercentage
      //             x.resultado_Acertou_Value = x.correctResultQuantity
      //             delete x.correctResultQuantity
      //             x.resultado_Errou_Percentage = x.incorrectResultPercentage
      //             delete x.incorrectResultPercentage
      //             x.resultado_Errou_Value = x.incorrectResultQuantity
      //             delete x.incorrectResultQuantity
      //             x.resultado_NaoResolveu_Percentage  = x.notAnsweredResultPercentage
      //             delete  x.notAnsweredResultPercentage
      //             x.resultado_NaoResolveu_Value = x.notAnsweredResultQuantity
      //             delete x.notAnsweredResultQuantity
      //             return x })

      var tables = [];

      for (var index in itemsIdeia) {
        tables.push({
          tableName: "ORDEM " + "" + itemsResults[index].orderName,
          ideia_Acertou_Value: itemsIdeia[index].correctIdeaQuantity,
          ideia_Errou_Value: itemsIdeia[index].incorrectIdeaQuantity,
          ideia_NaoResolveu_Value: itemsIdeia[index].notAnsweredIdeaQuantity,
          ideia_Total_Value: totals[index].totalStudentIdeaQuantity,
          resultado_Acertou_Value: itemsResults[index].correctResultQuantity,
          resultado_Errou_Value: itemsResults[index].incorrectResultQuantity,
          resultado_NaoResolveu_Value:
            itemsResults[index].notAnsweredResultQuantity,
          resultado_Total_Value: totals[index].totalStudentResultQuantity,
          ideia_Acertou_Percentage: itemsIdeia[index].correctIdeaPercentage,
          ideia_Errou_Percentage: itemsIdeia[index].incorrectIdeaPercentage,
          ideia_NaoResolveu_Percentage:
            itemsIdeia[index].notAnsweredIdeaPercentage,
          ideia_Total_Percentage: totals[index].totalStudentIdeaPercentage,
          resultado_Acertou_Percentage:
            itemsResults[index].correctResultPercentage,
          resultado_Errou_Percentage:
            itemsResults[index].incorrectResultPercentage,
          resultado_NaoResolveu_Percentage:
            itemsResults[index].notAnsweredResultPercentage,
          resultado_Total_Percentage:
            totals[index].totalStudentResultPercentage,
        });
      }

      var charts = [];

      for (var index in itemscharts.chartIdeaData) {
        charts.push({
          chartName: itemscharts.totals[index].name,
          dataName: "DataName",
          ideia_Acertou_Value:
            itemscharts.chartIdeaData[index].idea[0].quantity,
          ideia_Errou_Value: itemscharts.chartIdeaData[index].idea[1].quantity,
          ideia_NaoResolveu_Value:
            itemscharts.chartIdeaData[index].idea[2].quantity,
          resultado_Acertou_Value:
            itemscharts.chartResultData[index].result[0].quantity,
          resultado_Errou_Value:
            itemscharts.chartResultData[index].result[1].quantity,
          resultado_NaoResolveu_Value:
            itemscharts.chartResultData[index].result[2].quantity,
        });
      }

      var report = {
        headerFooter: {
          teacherName: this.props.user.username, // rf do professor
          dreName: nomeDre, // Nome da Dre pegar nome da DRE
          schoolName: nomeEscola, // Nome da escola pegar nome da Escola
          classYear: AnoCurso, // ano da turma
          className: CodigoTurmaEol, // turma PEgar nome da Turma
          subject: Disciplina, // Portugues
          testName: Proeficiencia, // Escrita
          period: periodo, // 1 BIMESTRES
          type: RelatorioDeClasse == true ? "Por Turma" : "Consolidado", // cONSOLIDADO
        },
        tables,

        charts,
      };

      return fetch(
        "http://hom-latexservice.sme.prefeitura.sp.gov.br/api/Recipes/PollReportMathMultiplication",
        {
          method: "post",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify(report),
        }
      )
        .then((response) => response.blob())
        .then((blob) => {
          // 2. Create blob link to download
          const url = window.URL.createObjectURL(new Blob([blob]));
          const link = document.createElement("a");
          link.href = url;
          link.setAttribute("download", "relatorio.pdf");
          // 3. Append to html page
          document.body.appendChild(link);
          // 4. Force download
          // link.printClick(url);
          link.click();
          //  var w = window.open(link.click());
          //    w.print();
          //     w.close();
          // 5. Clean up and remove the link
          link.parentNode.removeChild(link);
        });
    } else if (
      Disciplina == "Matemática" &&
      Proeficiencia == "Números" &&
      RelatorioDeClasse == false
    ) {
      var tables = [];

      for (var index in pollReportData.numerosResults) {
        tables.push({
          tableName: pollReportData.numerosResults[index].groupName,
          true_Value:
            pollReportData.numerosResults[index]
              .escreveConvencionalmenteResultado,
          true_Percentage:
            pollReportData.numerosResults[index]
              .escreveConvencionalmentePercentage,
          false_Value:
            pollReportData.numerosResults[index]
              .naoEscreveConvencionalmenteResultado,
          false_Percentage:
            pollReportData.numerosResults[index]
              .naoEscreveConvencionalmentePercentage,
          total_Value:
            pollReportData.numerosResults[index]
              .escreveConvencionalmenteResultado +
            pollReportData.numerosResults[index]
              .naoEscreveConvencionalmenteResultado,
          total_Percentage:
            pollReportData.numerosResults[index]
              .naoEscreveConvencionalmentePercentage +
            pollReportData.numerosResults[index]
              .escreveConvencionalmentePercentage,
        });
      }

      var charts = [];

      charts.push(
        {
          dataName: "",
          chart1Name: chartData.chartNumberData[0].order,
          true1_Value: chartData.chartNumberData[0].numbers[0].quantity,
          false1_Value: chartData.chartNumberData[0].numbers[1].quantity,
          chart2Name: chartData.chartNumberData[1].order,
          true2_Value: chartData.chartNumberData[1].numbers[0].quantity,
          false2_Value: chartData.chartNumberData[1].numbers[1].quantity,
        },
        {
          dataName: "",
          chart1Name: chartData.chartNumberData[2].order,
          true1_Value: chartData.chartNumberData[2].numbers[0].quantity,
          false1_Value: chartData.chartNumberData[2].numbers[1].quantity,
          chart2Name: chartData.chartNumberData[3].order,
          true2_Value: chartData.chartNumberData[3].numbers[0].quantity,
          false2_Value: chartData.chartNumberData[3].numbers[1].quantity,
        },
        {
          dataName: "",
          chart1Name: chartData.chartNumberData[4].order,
          true1_Value: chartData.chartNumberData[4].numbers[0].quantity,
          false1_Value: chartData.chartNumberData[4].numbers[1].quantity,
          chart2Name: chartData.chartNumberData[5].order,
          true2_Value: chartData.chartNumberData[5].numbers[0].quantity,
          false2_Value: chartData.chartNumberData[5].numbers[1].quantity,
        }
      );

      var report = {
        headerFooter: {
          teacherName: this.props.user.username, // rf do professor
          dreName: nomeDre, // Nome da Dre pegar nome da DRE
          schoolName: nomeEscola, // Nome da escola pegar nome da Escola
          classYear: AnoCurso, // ano da turma
          className: CodigoTurmaEol, // turma PEgar nome da Turma
          subject: Disciplina, // Portugues
          testName: Proeficiencia, // Escrita
          period: periodo, // 1 BIMESTRES
          type: RelatorioDeClasse == true ? "Por Turma" : "Consolidado", // cONSOLIDADO
        },
        tables,

        charts,
        chart2: {
          dataName: "dataName",
          chartName: chartData.chartNumberData[6].order,
          true_Value: chartData.chartNumberData[6].numbers[0].quantity,
          false_Value: chartData.chartNumberData[6].numbers[1].quantity,
        },
      };

      return fetch(
        "http://hom-latexservice.sme.prefeitura.sp.gov.br/api/Recipes/PollReportMathNumbers",
        {
          method: "post",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify(report),
        }
      )
        .then((response) => response.blob())
        .then((blob) => {
          // 2. Create blob link to download
          const url = window.URL.createObjectURL(new Blob([blob]));
          const link = document.createElement("a");
          link.href = url;
          link.setAttribute("download", "relatorio.pdf");
          // 3. Append to html page
          document.body.appendChild(link);
          // 4. Force download
          // link.printClick(url);
          link.click();
          //  var w = window.open(link.click());
          //    w.print();
          //     w.close();
          // 5. Clean up and remove the link
          link.parentNode.removeChild(link);
        });
    }
  }

  openPollFilter(value) {
    this.setState({
      showPollFilter: value,
    });
  }
  render() {
    var reportData = null;
    var chartData = null;
    var mathType = null;

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
        chartData && chartData.chartIdeaData !== undefined &&
        chartData.chartIdeaData.length > 0
      ) {
        chartData.totals = [];
        mathType = "consolidado";

        for (var i = 0; i < chartData.chartIdeaData.length; i++) {
          indexes.push(i);
          chartData.totals.push({
            name: "ORDEM " + chartData.chartIdeaData[i].order,
            idea: new Array(chartData.chartIdeaData[i].idea.length),
            result: new Array(chartData.chartResultData[i].result.length),
          });

          for (var j = 0; j < chartData.chartIdeaData[i].idea.length; j++) {
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
              default:
                break;
            }
          }

          for (var j = 0; j < chartData.chartResultData[i].result.length; j++) {
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
    return (
      <div>
        <Card className="mb-3">
          <PollFilter reports={true} resultClick={this.openPollFilter} />
        </Card>
        <MensagemConfirmacaoImprimir
          exibir={this.state.showMessage}
          acaoFeedBack={() => this.setState({ showMessage: false })}
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

              {this.props.pollReport.showReport === true && (
                <div>
                  <PollReportBreadcrumb className="mt-4" name="Planilha" />

                  {this.props.pollReport.selectedFilter.discipline ===
                  "Língua Portuguesa" ? (
                    <PollReportPortugueseGrid
                      className="mt-3"
                      classroomReport={this.classroomReport}
                      data={reportData}
                    />
                  ) : (
                    Number(this.props.pollReport.selectedFilter.CodigoCurso) >= 7?
                    reportData.map(dados => {
                      return <RelatorioMatematicaConsolidado dados={dados}/>
                    })
                    :
                    <PollReportMathGrid
                      className="mt-3"
                      classroomReport={this.classroomReport}
                      data={reportData}
                    />
                  )}

                  <PollReportBreadcrumb className="mt-5" name="Gráfico" />

                  {this.props.pollReport.selectedFilter.discipline ===
                    "Língua Portuguesa" && (
                    <PollReportPortugueseChart data={chartData} />
                  )}
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
                          var chartId =
                            "ordem" + chartData.chartIdeaData[index].order;

                          return (
                            <PollReportMathChart
                              key={chartId}
                              chartIds={[chartId + "idea", chartId + "result"]}
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
                        chartData.map((item) => {
                          var order =
                            item.name !== null
                              ? item.name.replace(" ", "").toLowerCase()
                              : "";
                          var chart1Id = order + "-ideaChart";
                          var chart2Id = order + "-resultChart";

                          return (
                            <PollReportMathChartClassroom
                              data={item}
                              chartIds={[chart1Id, chart2Id]}
                              numbers={numbers}
                            />
                          );
                        })
                    }
                    {/* {this.classroomReport === false ?
                                                (chartData.chartIdeaData.length > 0 ?
                                                    indexes.map(index => {
                                                        var chartId = "ordem" + chartData.chartIdeaData[index].order;

                                                        return (
                                                            <PollReportMathChart key={chartId} chartIds={[(chartId + "idea"), (chartId + "result")]} data={chartData.totals[index]} />
                                                        );
                                                    })
                                                    :
                                                    <PollReportMathNumbersChart data={chartData.chartNumberData} />
                                                )
                                                :
                                                numbers === false ?
                                                    (chartData.map(item => {
                                                        var order = item.name !== null ? item.name.replace(" ", "").toLowerCase() : "";
                                                        var chart1Id = order + "-ideaChart";
                                                        var chart2Id = order + "-resultChart"

                                                        return (
                                                            <PollReportMathChartClassroom data={item} chartIds={[chart1Id, chart2Id]} numbers={numbers} />
                                                        );
                                                    }))
                                                    :
                                                    <PollReportMathChartClassroom data={chartData} numbers={numbers} />
                                            } */}
                  </div>
                </div>
              )}
            </div>
          </Card>
        )}
      </div>
    );
  }
}

export default connect(
  (state) => ({
    pollReport: state.pollReport,
    user: state.user,
    filters: state.filters,
  }),
  (dispatch) => ({
    pollReportMethods: bindActionCreators(actionCreators, dispatch),
  })
)(PollReport);
