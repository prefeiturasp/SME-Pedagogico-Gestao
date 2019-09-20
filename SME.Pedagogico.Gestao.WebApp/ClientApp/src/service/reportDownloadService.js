import { connect } from 'react-redux';
import { actionCreators } from '../../store/PollReport';
import { bindActionCreators } from 'redux';
import React, { Component } from 'react';



     var userName = this.props.user.username;
     var AnoCurso = this.props.pollReport.selectedFilter.CodigoCurso;
     var CodigoEscola = this.props.filters.activeSchollsCode;
     var CodigoTurmaEol = this.props.pollReport.selectedFilter.CodigoTurmaEol;
     var CodigoDre = this.props.filters.activeDreCode;
     var Disciplina = this.props.pollReport.selectedFilter.discipline;
     var Proeficiencia = this.props.pollReport.selectedFilter.proficiency;
     var periodo = this.props.pollReport.selectedFilter.term;
     var RelatorioDeClasse = this.props.pollReport.selectedFilter
       .classroomReport;
     var Dres = this.props.filters.listDres;

     var nomeDre = Dres.filter(x => x.codigoDRE == CodigoDre)[0].nomeDRE.substring(31);

     var nomeEscola = this.props.filters.scholls.filter(
       x => x.codigoEscola == CodigoEscola
     )[0].nomeEscola;

     var pollReportData = this.props.pollReport.data;
     var chartData = this.props.pollReport.chartData;

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
           alfabeticoChart =   chartData[index].value
         }

         if (pollReportData[index].optionName == "Pré-Silábico") {
           preSilabicoValor = pollReportData[index].studentQuantity;
           preSilabicoPorcentagem = pollReportData[index].studentPercentage;
           preSilabicoChart = chartData[index].value;
         }
         if (pollReportData[index].optionName == "Silábico alfabético") {
             silabicoAlfabeticoValor = pollReportData[index].studentQuantity;
             silabicoAlfabeticoPorcentagem =  pollReportData[index].studentPercentage;
             silabicoAlfabeticoChart = chartData[index].value;

         }
         if (pollReportData[index].optionName == "Silábico sem valor") {
           silabicoSemValor = pollReportData[index].studentQuantity;
           silabicoSemValorPorcentagem =  pollReportData[index].studentPercentage;
             silabicoSemValorChart  = chartData[index].value;

         }
         if (pollReportData[index].optionName == "Silábico com valor") {
             silabicoComValor = pollReportData[index].studentQuantity;
             silabicoComValorPorcentagem = pollReportData[index].studentPercentage;
             silabicoComValorChart = chartData[index].value;
         }

         totalStudents += pollReportData[index].studentQuantity;
         totalPercentage += pollReportData[index].studentPercentage;
       }
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
         type: RelatorioDeClasse == true ? "Por Turma" : "Consolidado" // cONSOLIDADO
       },
       table: {
         pS_Value: preSilabicoValor,
         ssV_Value: silabicoComValor,
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
           sA_Value: silabicoAlfabeticoValor,
           a_Value: alfabeticoChart
       }
     };
     return fetch("http://10.50.1.40/api/Recipes/PollReportPortugueseWriting", {
       method: "post",
       headers: { "Content-Type": "application/json" },
       body: JSON.stringify(report)
     })
       .then(response => response.blob())
       .then(blob => {
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