using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.Business;
using SME.Pedagogico.Gestao.Data.DataTransfer;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Models.Academic;
using SME.Pedagogico.Gestao.WebApp.Models.RelatorioSondagem;

namespace SME.Pedagogico.Gestao.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RelatorioSondagemController : ControllerBase
    {
        public IConfiguration _config;
        public RelatorioSondagemController(IConfiguration config)
        {

            _config = config;
        }

        #region ==================== METHODS ====================
        [HttpPost]
        public async Task<ActionResult<string>> ObterDados([FromBody]ParametersModel parameters)
        {
            if (parameters.Discipline == "Língua Portuguesa")
            {
                if (parameters.ClassroomReport)
                {
                    PollReportPortugueseStudentResult result = new PollReportPortugueseStudentResult();
                    result = await BuscarDadosPorTurmaAsync(parameters);

                    return (Ok(result));
                }
                else
                {
                    PollReportPortugueseResult result = new PollReportPortugueseResult();
                    result = await BuscarDadosSyncAsync(parameters, "2019", parameters.CodigoDRE, parameters.CodigoEscola, parameters.CodigoCurso);

                    return (Ok(result));
                }
            }
            else if (parameters.Discipline == "Matemática")
            {
                if (parameters.ClassroomReport)
                {
                    PollReportMathStudentResult result = BuscarDadosMatematicaPorTurmaAsync(parameters);
                    #region mock
                    /* 
                    PollReportMathStudentItem item1 = new PollReportMathStudentItem()
                    {
                        Code = "1",
                        StudentName = "Alvaro Ramos Grassi",
                    };
                    item1.Poll.Add(new MathStudentItemResult()
                    {
                        Order = 1,
                        Idea = "Acertou",
                        Result = "Errou"
                    });
                    item1.Poll.Add(new MathStudentItemResult()
                    {
                        Order = 2,
                        Idea = "Acertou",
                        Result = "Errou"
                    });
                    item1.Poll.Add(new MathStudentItemResult()
                    {
                        Order = 3,
                        Idea = "Acertou",
                        Result = "Errou"
                    });
                    item1.Poll.Add(new MathStudentItemResult()
                    {
                        Order = 4,
                        Idea = "Acertou",
                        Result = "Errou"
                    });

                    PollReportMathStudentItem item2 = new PollReportMathStudentItem()
                    {
                        Code = "1",
                        StudentName = "Amanda Aparecida",
                    };
                    item2.Poll.Add(new MathStudentItemResult()
                    {
                        Order = 1,
                        Idea = "Errou",
                        Result = "Não Resolveu"
                    });
                    item2.Poll.Add(new MathStudentItemResult()
                    {
                        Order = 2,
                        Idea = "Errou",
                        Result = "Não Resolveu"
                    });
                    item2.Poll.Add(new MathStudentItemResult()
                    {
                        Order = 3,
                        Idea = "Errou",
                        Result = "Não Resolveu"
                    });
                    item2.Poll.Add(new MathStudentItemResult()
                    {
                        Order = 4,
                        Idea = "Acertou",
                        Result = "Errou"
                    });

                    PollReportMathStudentItem item3 = new PollReportMathStudentItem()
                    {
                        Code = "3",
                        StudentName = "Anna Beatriz de Goes Callejon",
                    };
                    item3.Poll.Add(new MathStudentItemResult()
                    {
                        Order = 1,
                        Idea = "Acertou",
                        Result = "Acertou"
                    });
                    item3.Poll.Add(new MathStudentItemResult()
                    {
                        Order = 2,
                        Idea = "Acertou",
                        Result = "Acertou"
                    });
                    item3.Poll.Add(new MathStudentItemResult()
                    {
                        Order = 3,
                        Idea = "Acertou",
                        Result = "Acertou"
                    });
                    item3.Poll.Add(new MathStudentItemResult()
                    {
                        Order = 4,
                        Idea = "Acertou",
                        Result = "Errou"
                    });

                    PollReportMathStudentItem item4 = new PollReportMathStudentItem()
                    {
                        Code = "4",
                        StudentName = "Caique Siqueira",
                    };
                    item4.Poll.Add(new MathStudentItemResult()
                    {
                        Order = 1,
                        Idea = "Acertou",
                        Result = "Errou"
                    });
                    item4.Poll.Add(new MathStudentItemResult()
                    {
                        Order = 2,
                        Idea = "Acertou",
                        Result = "Errou"
                    });
                    item4.Poll.Add(new MathStudentItemResult()
                    {
                        Order = 3,
                        Idea = "Acertou",
                        Result = "Errou"
                    });
                    item4.Poll.Add(new MathStudentItemResult()
                    {
                        Order = 4,
                        Idea = "Acertou",
                        Result = "Errou"
                    });

                    result.Results = new List<PollReportMathStudentItem>();
                    result.Results.Add(item1);
                    result.Results.Add(item2);
                    result.Results.Add(item3);
                    result.Results.Add(item4);

                    result.ChartData = new List<Models.RelatorioSondagem.MathChartDataModel>();

                    result.ChartData.Add(new Models.RelatorioSondagem.MathChartDataModel()
                    {
                        Name = "ORDEM 1",
                        Idea = new List<int>() { 60, 13, 30 },
                        Result = new List<int>() { 25, 30, 45 }
                    });
                    result.ChartData.Add(new Models.RelatorioSondagem.MathChartDataModel()
                    {
                        Name = "ORDEM 2",
                        Idea = new List<int>() { 20, 40, 30 },
                        Result = new List<int>() { 10, 15, 5 }
                    });
                    result.ChartData.Add(new Models.RelatorioSondagem.MathChartDataModel()
                    {
                        Name = "ORDEM 3",
                        Idea = new List<int>() { 60, 13, 30 },
                        Result = new List<int>() { 60, 30, 45 }
                    });
                    */
                    #endregion
                    return (Ok(result));     //   pollreportfilter-> 84

                }

                else    // cONSOLIDADO
                {
                    var result = await BuscaDadosMathAsync(parameters, "2014", "4", "500747", "1");
                    return Ok(result);
                }
            }

            return (NotFound());
        }

        private async Task<PollReportMathResult> BuscaDadosMathAsync(ParametersModel parameters, string anoLetivo, string codigoDre, string codigoEscola, string anoTurma)
        {
            var businessPoll = new Data.Business.SondagemMatematica(_config);

            return await businessPoll
                .BuscarDadosRelatorioMatematicaAsync(parameters.Proficiency,
                                                     parameters.Term,
                                                     anoLetivo,
                                                     codigoDre,
                                                     codigoEscola,
                                                     anoTurma);
        }

        private PollReportMathStudentResult BuscarDadosMatematicaPorTurmaAsync(ParametersModel parameters)
        {
            var BusinessPoll = new Data.Business.PollMatematica(_config);
            List<MathChartDataModel> graficos = new List<MathChartDataModel>();

            PollReportMathStudentResult retorno = new PollReportMathStudentResult();
            //ajustar para pegar a turma 
            List<PollReportMathStudentItem> result = new List<PollReportMathStudentItem>();

            parameters.CodigoEscola = "1996399";

            if (parameters.Proficiency == "Campo Aditivo")
            {
                result = BuscaDadosCA(parameters.CodigoEscola, parameters.Proficiency, parameters.Term, BusinessPoll);
                graficos = BuscaGraficoCA(parameters.CodigoEscola, parameters.Proficiency, parameters.Term, BusinessPoll);
            }
            else if (parameters.Proficiency == "Campo Multiplicativo")
            {
                result = BuscaDadosCM(parameters.CodigoEscola, parameters.Proficiency, parameters.Term, BusinessPoll);
                graficos = BuscaGraficoCM(parameters.CodigoEscola, parameters.Proficiency, parameters.Term, BusinessPoll);
            }
            else if (parameters.Proficiency == "Números")
            {
                result = BuscaDadosNumeros(parameters.CodigoEscola, parameters.Proficiency, parameters.Term, BusinessPoll);
                graficos = BuscaGraficoNumeros(parameters.CodigoEscola, parameters.Proficiency, parameters.Term, BusinessPoll);
            }

            retorno.Results = result;
            retorno.ChartData = graficos;

            return retorno;
        }

         
        private List<MathChartDataModel> BuscaGraficoCA(string codigoEscola, string proficiency, string term, PollMatematica BusinessPoll)
        {
            List<PollReportMathStudentItem> result = new List<PollReportMathStudentItem>();

            List<MathChartDataModel> graficos = new List<MathChartDataModel>();

            var listaAlunosTurma = BusinessPoll.BuscarAlunosTurmaRelatorioMatematicaCA(codigoEscola, proficiency, term);

            for (int i = 1; i < 9; i++)
            {
                MathChartDataModel item = new MathChartDataModel();
                int totalAcertou = 0;
                int totalErrou = 0;
                int totalNaoRespondeu = 0;

                switch (i)
                {
                    case 1:
                        item.Name = "Ordem 1 - Ideia";
                        totalAcertou = listaAlunosTurma.Where(p => p.Ordem1Ideia.Equals("A")).Count();
                        totalErrou = listaAlunosTurma.Where(p => p.Ordem1Ideia.Equals("E")).Count();
                        totalNaoRespondeu = listaAlunosTurma.Where(p => p.Ordem1Ideia.Equals("NR")).Count(); 
                        break;
                    case 2:
                        item.Name = "Ordem 1 - Resultado";
                        totalAcertou = listaAlunosTurma.Where(p => p.Ordem1Resultado.Equals("A")).Count();
                        totalErrou = listaAlunosTurma.Where(p => p.Ordem1Resultado.Equals("E")).Count();
                        totalNaoRespondeu = listaAlunosTurma.Where(p => p.Ordem1Resultado.Equals("NR")).Count();
                        break;

                    case 3:
                        item.Name = "Ordem 2 - Ideia";
                        totalAcertou = listaAlunosTurma.Where(p => p.Ordem2Ideia.Equals("A")).Count();
                        totalErrou = listaAlunosTurma.Where(p => p.Ordem2Ideia.Equals("E")).Count();
                        totalNaoRespondeu = listaAlunosTurma.Where(p => p.Ordem2Ideia.Equals("NR")).Count();
                        break;
                    case 4:
                        item.Name = "Ordem 2 - Resultado";
                        totalAcertou = listaAlunosTurma.Where(p => p.Ordem2Resultado.Equals("A")).Count();
                        totalErrou = listaAlunosTurma.Where(p => p.Ordem2Resultado.Equals("E")).Count();
                        totalNaoRespondeu = listaAlunosTurma.Where(p => p.Ordem2Resultado.Equals("NR")).Count();
                        break;


                    case 5:
                        item.Name = "Ordem 3 - Ideia";
                        totalAcertou = listaAlunosTurma.Where(p => p.Ordem3Ideia.Equals("A")).Count();
                        totalErrou = listaAlunosTurma.Where(p => p.Ordem3Ideia.Equals("E")).Count();
                        totalNaoRespondeu = listaAlunosTurma.Where(p => p.Ordem3Ideia.Equals("NR")).Count();
                        break;
                    case 6:
                        item.Name = "Ordem 3 - Resultado";
                        totalAcertou = listaAlunosTurma.Where(p => p.Ordem3Resultado.Equals("A")).Count();
                        totalErrou = listaAlunosTurma.Where(p => p.Ordem3Resultado.Equals("E")).Count();
                        totalNaoRespondeu = listaAlunosTurma.Where(p => p.Ordem3Resultado.Equals("NR")).Count();
                        break;
                    case 7:
                        item.Name = "Ordem 4 - Ideia";
                        totalAcertou = listaAlunosTurma.Where(p => p.Ordem4Ideia.Equals("A")).Count();
                        totalErrou = listaAlunosTurma.Where(p => p.Ordem4Ideia.Equals("E")).Count();
                        totalNaoRespondeu = listaAlunosTurma.Where(p => p.Ordem4Ideia.Equals("NR")).Count();
                        break;
                    case 8:
                        item.Name = "Ordem 4 - Resultado";
                        totalAcertou = listaAlunosTurma.Where(p => p.Ordem4Resultado.Equals("A")).Count();
                        totalErrou = listaAlunosTurma.Where(p => p.Ordem4Resultado.Equals("E")).Count();
                        totalNaoRespondeu = listaAlunosTurma.Where(p => p.Ordem4Resultado.Equals("NR")).Count();
                        break;
                }

                item.Idea = new List<string> { "Acertou", "Errou", "Não Respondeu" };
                item.Result = new List<int> { totalAcertou, totalErrou, totalNaoRespondeu };
                graficos.Add(item);

            } 
            return graficos;
        }


        private List<MathChartDataModel> BuscaGraficoCM(string codigoEscola, string proficiency, string term, PollMatematica BusinessPoll)
        {
            List<PollReportMathStudentItem> result = new List<PollReportMathStudentItem>();

            List<MathChartDataModel> graficos = new List<MathChartDataModel>();

            var listaAlunosTurma = BusinessPoll.BuscarAlunosTurmaRelatorioMatematicaCM(codigoEscola, proficiency, term);

            for (int i = 4; i < 11; i++)
            {
                MathChartDataModel item = new MathChartDataModel();
                int totalAcertou = 0;
                int totalErrou = 0;
                int totalNaoRespondeu = 0;

                switch (i)
                {
                    case 1:
                        item.Name = "Ordem 4 - Ideia";
                        totalAcertou = listaAlunosTurma.Where(p => p.Ordem4Ideia.Equals("A")).Count();
                        totalErrou = listaAlunosTurma.Where(p => p.Ordem4Ideia.Equals("E")).Count();
                        totalNaoRespondeu = listaAlunosTurma.Where(p => p.Ordem4Ideia.Equals("NR")).Count(); 
                        break;
                    case 2:
                        item.Name = "Ordem 4 - Resultado";
                        totalAcertou = listaAlunosTurma.Where(p => p.Ordem4Ideia.Equals("A")).Count();
                        totalErrou = listaAlunosTurma.Where(p => p.Ordem4Ideia.Equals("E")).Count();
                        totalNaoRespondeu = listaAlunosTurma.Where(p => p.Ordem4Ideia.Equals("NR")).Count();
                        break;

                    case 3:
                        item.Name = "Ordem 5 - Ideia";
                        totalAcertou = listaAlunosTurma.Where(p => p.Ordem5Ideia.Equals("A")).Count();
                        totalErrou = listaAlunosTurma.Where(p => p.Ordem5Ideia.Equals("E")).Count();
                        totalNaoRespondeu = listaAlunosTurma.Where(p => p.Ordem5Ideia.Equals("NR")).Count();
                        break;
                    case 4:
                        item.Name = "Ordem 5 - Resultado";
                        totalAcertou = listaAlunosTurma.Where(p => p.Ordem5Ideia.Equals("A")).Count();
                        totalErrou = listaAlunosTurma.Where(p => p.Ordem5Ideia.Equals("E")).Count();
                        totalNaoRespondeu = listaAlunosTurma.Where(p => p.Ordem5Ideia.Equals("NR")).Count();
                        break;

                    case 5:
                        item.Name = "Ordem 6 - Ideia";
                        totalAcertou = listaAlunosTurma.Where(p => p.Ordem6Ideia.Equals("A")).Count();
                        totalErrou = listaAlunosTurma.Where(p => p.Ordem6Ideia.Equals("E")).Count();
                        totalNaoRespondeu = listaAlunosTurma.Where(p => p.Ordem6Ideia.Equals("NR")).Count();
                        break;
                    case 6:
                        item.Name = "Ordem 6 - Resultado";
                        totalAcertou = listaAlunosTurma.Where(p => p.Ordem6Resultado.Equals("A")).Count();
                        totalErrou = listaAlunosTurma.Where(p => p.Ordem6Resultado.Equals("E")).Count();
                        totalNaoRespondeu = listaAlunosTurma.Where(p => p.Ordem6Resultado.Equals("NR")).Count();
                        break;
                    case 7:
                        item.Name = "Ordem 7 - Ideia";
                        totalAcertou = listaAlunosTurma.Where(p => p.Ordem7Ideia.Equals("A")).Count();
                        totalErrou = listaAlunosTurma.Where(p => p.Ordem7Ideia.Equals("E")).Count();
                        totalNaoRespondeu = listaAlunosTurma.Where(p => p.Ordem7Ideia.Equals("NR")).Count();
                        break;
                    case 8:
                        item.Name = "Ordem 7 - Resultado";
                        totalAcertou = listaAlunosTurma.Where(p => p.Ordem7Ideia.Equals("A")).Count();
                        totalErrou = listaAlunosTurma.Where(p => p.Ordem7Ideia.Equals("E")).Count();
                        totalNaoRespondeu = listaAlunosTurma.Where(p => p.Ordem7Ideia.Equals("NR")).Count();
                        break;

                    case 9:
                        item.Name = "Ordem 8 - Ideia";
                        totalAcertou = listaAlunosTurma.Where(p => p.Ordem8Ideia.Equals("A")).Count();
                        totalErrou = listaAlunosTurma.Where(p => p.Ordem8Ideia.Equals("E")).Count();
                        totalNaoRespondeu = listaAlunosTurma.Where(p => p.Ordem8Ideia.Equals("NR")).Count();
                        break;
                    case 10:
                        item.Name = "Ordem 8 - Resultado";
                        totalAcertou = listaAlunosTurma.Where(p => p.Ordem8Ideia.Equals("A")).Count();
                        totalErrou = listaAlunosTurma.Where(p => p.Ordem8Ideia.Equals("E")).Count();
                        totalNaoRespondeu = listaAlunosTurma.Where(p => p.Ordem8Ideia.Equals("NR")).Count();
                        break;
                }

                item.Idea = new List<string> { "Acertou", "Errou", "Não Respondeu" };
                item.Result = new List<int> { totalAcertou, totalErrou, totalNaoRespondeu };
                graficos.Add(item);

            } 
            return graficos;
        }

        private List<MathChartDataModel> BuscaGraficoNumeros(string codigoEscola, string proficiency, string term, PollMatematica BusinessPoll)
        {
            List<PollReportMathStudentItem> result = new List<PollReportMathStudentItem>();

            List<MathChartDataModel> graficos = new List<MathChartDataModel>();

            var listaAlunosTurma = BusinessPoll.BuscarAlunosTurmaRelatorioMatematicaNumber(codigoEscola, proficiency, term);

            for (int i = 1; i < 9; i++)
            {
                MathChartDataModel item = new MathChartDataModel();
                int totalSim = 0;
                int totalNao = 0;

                switch (i)
                {
                    case 1:
                        item.Name = "Familiares ou Frequentes";
                        totalSim = listaAlunosTurma.Where(p => p.Familiares.Equals("S")).Count();
                        totalNao = listaAlunosTurma.Where(p => p.Familiares.Equals("N")).Count();
                        break;
                    case 2:
                        item.Name = "Opacos";
                        totalSim = listaAlunosTurma.Where(p => p.Opacos.Equals("S")).Count();
                        totalNao = listaAlunosTurma.Where(p => p.Opacos.Equals("N")).Count();
                        break;
                    case 3:
                        item.Name = "Transparentes";
                        totalSim = listaAlunosTurma.Where(p => p.Transparentes.Equals("S")).Count();
                        totalNao = listaAlunosTurma.Where(p => p.Transparentes.Equals("N")).Count();
                        break;
                    case 4:
                        item.Name = "Terminam em Zero";
                        totalSim = listaAlunosTurma.Where(p => p.TerminamZero.Equals("S")).Count();
                        totalNao = listaAlunosTurma.Where(p => p.TerminamZero.Equals("N")).Count();
                        break;
                    case 5:
                        item.Name = "Algarismos Iguais";
                        totalSim = listaAlunosTurma.Where(p => p.Algarismos.Equals("S")).Count();
                        totalNao = listaAlunosTurma.Where(p => p.Algarismos.Equals("N")).Count();
                        break;
                    case 6:
                        item.Name = "Processo de Generalização";
                        totalSim = listaAlunosTurma.Where(p => p.Processo.Equals("S")).Count();
                        totalNao = listaAlunosTurma.Where(p => p.Processo.Equals("N")).Count();
                        break;
                    case 7:
                        item.Name = "Zeros Intercalados";
                        totalSim = listaAlunosTurma.Where(p => p.ZeroIntercalados.Equals("S")).Count();
                        totalNao = listaAlunosTurma.Where(p => p.ZeroIntercalados.Equals("N")).Count();
                        break;
                }
                item.Idea = new List<string> { "Escreve convencionamente", "Não escreve convencionamente" };
                item.Result = new List<int> { totalSim, totalNao };
                graficos.Add(item);
            }

            return graficos;
        }

        private List<PollReportMathStudentItem> BuscaDadosCA(string codigoEscola, string proficiency, string term, PollMatematica BusinessPoll)
        {
            List<PollReportMathStudentItem> result = new List<PollReportMathStudentItem>();

            var listaAlunosTurma = BusinessPoll.BuscarAlunosTurmaRelatorioMatematicaCA(codigoEscola, proficiency, term);

            foreach (var sondagem in listaAlunosTurma)
            {
                List<MathStudentItemResult> pollTotal = new List<MathStudentItemResult>();

                for (int i = 1; i < 5; i++)
                {
                    MathStudentItemResult item = new MathStudentItemResult();
                    string ideia = "";
                    string resultado = "";

                    switch (i)
                    {
                        case 1:
                            ideia = ConverteTextoPollMatematica(sondagem.Ordem1Ideia);
                            resultado = ConverteTextoPollMatematica(sondagem.Ordem1Resultado);
                            break;
                        case 2:
                            ideia = ConverteTextoPollMatematica(sondagem.Ordem2Ideia);
                            resultado = ConverteTextoPollMatematica(sondagem.Ordem2Resultado);
                            break;
                        case 3:
                            ideia = ConverteTextoPollMatematica(sondagem.Ordem3Ideia);
                            resultado = ConverteTextoPollMatematica(sondagem.Ordem3Resultado);
                            break;
                        case 4:
                            ideia = ConverteTextoPollMatematica(sondagem.Ordem4Ideia);
                            resultado = ConverteTextoPollMatematica(sondagem.Ordem4Resultado);
                            break;
                    }
                    item.Idea = ideia;
                    item.Order = i;
                    item.Result = resultado;

                    pollTotal.Add(item);
                }

                result.Add(
                    new PollReportMathStudentItem()
                    {
                        Code = sondagem.AlunoEolCode,
                        StudentName = "Aluno " + sondagem.AlunoEolCode,
                        Poll = pollTotal
                    }
                );

            }

            return result;
        }

        private List<PollReportMathStudentItem> BuscaDadosCM(string codigoEscola, string proficiency, string term, PollMatematica BusinessPoll)
        {
            List<PollReportMathStudentItem> result = new List<PollReportMathStudentItem>();

            var listaAlunosTurma = BusinessPoll.BuscarAlunosTurmaRelatorioMatematicaCM(codigoEscola, proficiency, term);

            foreach (var sondagem in listaAlunosTurma)
            {
                List<MathStudentItemResult> pollTotal = new List<MathStudentItemResult>();

                for (int i = 4; i < 9; i++)
                {
                    MathStudentItemResult item = new MathStudentItemResult();
                    string ideia = "";
                    string resultado = "";

                    switch (i)
                    {
                        case 4:
                            ideia = ConverteTextoPollMatematica(sondagem.Ordem4Ideia);
                            resultado = ConverteTextoPollMatematica(sondagem.Ordem4Resultado);
                            break;
                        case 5:
                            ideia = ConverteTextoPollMatematica(sondagem.Ordem5Ideia);
                            resultado = ConverteTextoPollMatematica(sondagem.Ordem5Resultado);
                            break;
                        case 6:
                            ideia = ConverteTextoPollMatematica(sondagem.Ordem6Ideia);
                            resultado = ConverteTextoPollMatematica(sondagem.Ordem6Resultado);
                            break;
                        case 7:
                            ideia = ConverteTextoPollMatematica(sondagem.Ordem7Ideia);
                            resultado = ConverteTextoPollMatematica(sondagem.Ordem7Resultado);
                            break;
                        case 8:
                            ideia = ConverteTextoPollMatematica(sondagem.Ordem8Ideia);
                            resultado = ConverteTextoPollMatematica(sondagem.Ordem8Resultado);
                            break;
                    }
                    item.Idea = ideia;
                    item.Order = i;
                    item.Result = resultado;

                    pollTotal.Add(item);
                }

                result.Add(
                    new PollReportMathStudentItem()
                    {
                        Code = sondagem.AlunoEolCode,
                        StudentName = "Aluno " + sondagem.AlunoEolCode,
                        Poll = pollTotal
                    }
                );
            }
            return result;
        }

        private string ConverteTextoPollMatematica(string texto)
        {
            if (texto.Equals("A"))
            {
                return "Acertou";
            }
            else if (texto.Equals("E"))
            {
                return "Errou";
            }
            else if (texto.Equals("NR"))
            {
                return "Não Resolveu";
            }

            return "";
        }
        private string ConverteTextoPollMatematica(string texto, bool tipoNumero)
        {
            if (texto.Equals("S"))
            {
                return "Escreve convencionalmente";
            }
            else if (texto.Equals("Não escreve convencionalmente"))
            {
                return "Errou";
            }

            return "";
        }
        private List<PollReportMathStudentItem> BuscaDadosNumeros(string codigoEscola, string proficiency, string term, PollMatematica BusinessPoll)
        {
            List<PollReportMathStudentItem> result = new List<PollReportMathStudentItem>();

            List<MathChartDataModel> graficos = new List<MathChartDataModel>();

            var listaAlunosTurma = BusinessPoll.BuscarAlunosTurmaRelatorioMatematicaNumber(codigoEscola, proficiency, term);

            foreach (var sondagem in listaAlunosTurma)
            {

                List<MathStudentItemResult> pollTotal = new List<MathStudentItemResult>();

                MathStudentItemResult item1 = new MathStudentItemResult();
                item1.Idea = "Familiares ou Frequentes";
                item1.Result = ConverteTextoPollMatematica(sondagem.Familiares, true);
                pollTotal.Add(item1);

                MathStudentItemResult item2 = new MathStudentItemResult();
                item2.Idea = "Opacos";
                item2.Result = ConverteTextoPollMatematica(sondagem.Opacos, true);
                pollTotal.Add(item2);

                MathStudentItemResult item3 = new MathStudentItemResult();
                item3.Idea = "Transparentes";
                item3.Result = ConverteTextoPollMatematica(sondagem.Transparentes, true);
                pollTotal.Add(item3);

                MathStudentItemResult item4 = new MathStudentItemResult();
                item4.Idea = "Terminam em Zero";
                item4.Result = ConverteTextoPollMatematica(sondagem.TerminamZero, true);
                pollTotal.Add(item4);

                MathStudentItemResult item5 = new MathStudentItemResult();
                item5.Idea = "Algarismos Iguais";
                item5.Result = ConverteTextoPollMatematica(sondagem.Algarismos, true);
                pollTotal.Add(item5);

                MathStudentItemResult item6 = new MathStudentItemResult();
                item6.Idea = "Processos de Generalização";
                item6.Result = ConverteTextoPollMatematica(sondagem.Processo, true);
                pollTotal.Add(item6);

                MathStudentItemResult item7 = new MathStudentItemResult();
                item7.Idea = "Zeros Intercalados";
                item7.Result = ConverteTextoPollMatematica(sondagem.ZeroIntercalados, true);
                pollTotal.Add(item7);

                result.Add(
                    new PollReportMathStudentItem()
                    {
                        Code = sondagem.AlunoEolCode,
                        StudentName = "Aluno " + sondagem.AlunoEolCode,
                        Poll = pollTotal
                    }
                );
                /*
                graficos.Add(new MathChartDataModel()
                {
                    Name = "Opacos",
                    Result = { 10, 20, 30 }
                });

                graficos.Add(new MathChartDataModel()
                {
                    Name = "Transparentes",
                    Result = { 10, 20, 30 }
                });

                graficos.Add(new MathChartDataModel()
                {
                    Name = "Terminam em Zero",
                    Result = { 10, 20, 30 }
                });

                graficos.Add(new MathChartDataModel()
                {
                    Name = "Algarismos Iguais",
                    Result = { 10, 20, 30 }
                });

                graficos.Add(new MathChartDataModel()
                {
                    Name = "Processos de Generalização",
                    Result = { 10, 20, 30 }
                });

                graficos.Add(new MathChartDataModel()
                {
                    Name = "Zeros Intercalados",
                    Result = { 10, 20, 30 }
                });*/

            }

            return result;
        }


        private async Task<PollReportPortugueseResult> BuscarDadosSyncAsync(ParametersModel parameters, string anoLetivo, string codigoDre, string codigoEscola, string codigoCurso)
        {
            var BusinessPoll = new Data.Business.PollPortuguese(_config);

            return await BusinessPoll.BuscarDadosRelatorioPortugues(parameters.Proficiency, parameters.Term, anoLetivo, codigoDre, codigoEscola, codigoCurso);
            ;
        }

        private async Task<PollReportPortugueseStudentResult> BuscarDadosPorTurmaAsync(ParametersModel parameters)
        {
            var BusinessPoll = new Data.Business.PollPortuguese(_config);
            var listaAlunosTurma = await BusinessPoll.BuscarAlunosTurmaRelatorioPortugues(parameters.CodigoTurmaEol, parameters.Proficiency, parameters.Term);//ajustar para pegar a turma 
            List<PollReportPortugueseStudentItem> result = new List<PollReportPortugueseStudentItem>();
            List<PortChartDataModel> graficos = new List<PortChartDataModel>();
            foreach (var sondagem in listaAlunosTurma)
            {
                string tipo = ConverterProficienciaAluno(parameters.Proficiency, parameters.Term, sondagem);
                result.Add(
                    new PollReportPortugueseStudentItem()
                    {
                        Code = sondagem.studentCodeEol,
                        StudentName = sondagem.studentNameEol,
                        StudentValue = tipo
                    }
                );

                graficos.Add(new PortChartDataModel()
                {
                    Name = tipo,
                    Value = 1
                });
            }

            PollReportPortugueseStudentResult retorno = new PollReportPortugueseStudentResult();
            retorno.Results = result;

            var listaGrafico = graficos.GroupBy(fu => fu.Name).Select(g => new { Label = g.Key, Value = g.Count() }).ToList();
            graficos = new List<PortChartDataModel>();
            foreach (var item in listaGrafico)
            {
                graficos.Add(new PortChartDataModel()
                {
                    Name = item.Label,
                    Value = item.Value
                });
            }
            retorno.ChartData = graficos;

            return retorno;
        }

        private string ConverterProficienciaAluno(string proficiency, string term, PortuguesePoll aluno)
        {
            switch (term)
            {
                case "1° Bimestre":
                    {
                        if (proficiency == "Escrita")
                        {
                            return MontarTextoProficiencia(aluno.writing1B);
                        }
                        else
                        {
                            return MontarTextoProficiencia(aluno.reading1B);
                        }
                    }
                case "2° Bimestre":
                    {

                        if (proficiency == "Escrita")
                        {
                            return MontarTextoProficiencia(aluno.writing2B);
                        }
                        else
                        {
                            return MontarTextoProficiencia(aluno.reading2B);
                        }
                    }
                case "3° Bimestre":
                    {

                        if (proficiency == "Escrita")
                        {
                            return MontarTextoProficiencia(aluno.writing3B);
                        }
                        else
                        {
                            return MontarTextoProficiencia(aluno.reading3B);
                        }
                    }
                default:

                    if (proficiency == "Escrita")
                    {
                        return MontarTextoProficiencia(aluno.writing4B);
                    }
                    else
                    {
                        return MontarTextoProficiencia(aluno.reading4B);
                    }
            }
        }

        private string MontarTextoProficiencia(string proficiencia)
        {
            switch (proficiencia)
            {
                case "PS":
                    return "Pré silábico";
                case "SSV":
                    return "Silábico sem valor sonoro";
                case "SCV":
                    return "Silábico com valor sonoro";
                case "SA":
                    return "Silábico - alfabético";
                case "ALF":
                    return "Alfabético";
                default:
                    return proficiencia;
            }
        }

        #endregion ==================== METHODS ====================
    }
}