// import { connect } from "react-redux";

//  const lala =  connect(
//   state => ({
//     pollReport: state.pollReport,
//     user: state.user,
//     filters: state.filters
//   })
// )(ReportService);

// const ReportService   {
   
//     CriaRelatorio: () =>  {
//         var pollReportData = lala.props.pollReport.data;
//         var chartData = lala.props.pollReport.chartData;
//         //CriaHeader 
//         var header = this.CriaCabecalho();
//         // Criar Roport
//         var para = ""
//         // BaixaPdf
//     },
//     CriaCabecalho: () =>  {

//      var HeaderData = {
        
//         userName : lala.props.user.username,
//         anoCurso : lala.props.pollReport.selectedFilter.CodigoCurso,
//         codigoEscolaSelecionada :
//         lala.props.filters.activeSchollsCode == ""
//             ? "todas"
//             : lala.props.filters.activeSchollsCode,
//         codigoTurmaEol: lala.props.pollReport.selectedFilter.CodigoTurmaEol == ""
//             ? "Todas"
//             : lala.props.pollReport.selectedFilter.CodigoTurmaEol,
//         codigoDreSeleciona : this.props.filters.activeDreCode,
//         disciplina : lala.props.pollReport.selectedFilter.discipline,
//         proeficiencia : this.props.pollReport.selectedFilter.proficiency,
//         periodo : this.props.pollReport.selectedFilter.term,
//         relatorioDeClasse : this.props.pollReport.selectedFilter.classroomReport,
//         dres : this.props.filters.listDres,
//         nomeDre : this.RetornaNomeDre(this.dres, this.codigoDreSelecionada),
//         escolas : this.props.filters.scholls,
//         nomeEscola : this.RetornaNomeEscola(this.escolas, this.codigoEscolaSelecionada),
//         especial: this.anoCurso == 3 && this.proeficiencia == "Escrita" ? true : false
//       }

//       return  HeaderData;
//     },

//     RetornaNomeDre: (dres, codigoDre) => {
//         var nomeDre = ""
//         if ("codigoDRE" in dres[0]) {
//              nomeDre =
//              codigoDre == "todas"
//                 ? "Todas"
//                 : dres.filter(x => x.codigoDRE == codigoDre)[0].nomeDRE.substring(31);
//           } else {
//              nomeDre =
//              codigoDre == "todas"
//                 ? "Todas"
//                 : dres.filter(x => x.codigo == codigoDre)[0].nome.substring(31);
//           }
//           return nomeDre
//       },
    
//     RetornaNomeEscola: (escolas, codigoEscola) => {
//         var nomeEscola = ""
//         if(escolas != undefined){
//             if ("codigoEscola" in escolas[0]) {
//                nomeEscola =
//               codigoEscola == "todas"
//                   ? "Todas"
//                   : escolas.filter(
//                       x => x.codigoEscola == codigoEscola
//                     )[0].nomeEscola;
//             }
//         }  
           
//         else {
//                  nomeEscola  = codigoEscola == "todas"
//                   ? "Todas"
//                   : this.props.filters.scholls.filter(x => x.codigo == codigoEscola)[0].nome;
//         }
    
//         return nomeEscola;
//       }
    
// }

