const ReportPortugueseReadingModel =  {



 preSilabicoValor = 0,
 silabicoComValor = 0,
 silabicoSemValor = 0,
 silabicoAlfabeticoValor = 0,
 alfabeticoValor = 0,
 totalStudents = 0,

 preSilabicoPorcentagem = 0,
 silabicoSemValorPorcentagem = 0,
 silabicoComValorPorcentagem = 0,
 silabicoAlfabeticoPorcentagem = 0,
 alfabeticoPorcentagem = 0,
 totalPercentage = 0,

//chartData
 preSilabicoChart = 0,
 silabicoSemValorChart = 0,
 silabicoComValorChart = 0,
 silabicoAlfabeticoChart = 0,
 alfabeticoChart = 0,

ReportPortuguese: (pollReportData) => {


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
      type: RelatorioDeClasse == true ? "Por Turma" : "Consolidado" // CONSOLIDADO
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
      total_Percentage: totalPercentage
    },
    chart: {
      pS_Value: preSilabicoChart,
      ssV_Value: silabicoSemValorChart,
      scV_Value: silabicoComValorChart,
      sA_Value: silabicoAlfabeticoChart,
      a_Value: alfabeticoChart
    }
  };

} 


 }
}