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

                    return (Ok(result));     //   pollreportfilter-> 84

                }

                else    // cONSOLIDADO
                {
                    var result = await BuscaDadosMathAsync(parameters, "2019", "4", "000191", "4");
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


            //ajustar para pegar a turma 
            List<PollReportMathStudentItem> result = new List<PollReportMathStudentItem>();
            List<MathChartDataModel> graficos = new List<MathChartDataModel>();

            parameters.CodigoEscola = "1996399"; 

            if (parameters.Proficiency == "Campo Aditivo")
            {
                result = BuscaDadosCA(parameters.CodigoEscola, parameters.Proficiency, parameters.Term, BusinessPoll);
            }
            else if (parameters.Proficiency == "Campo Multiplicativo")
            {
                result = BuscaDadosCM(parameters.CodigoEscola, parameters.Proficiency, parameters.Term, BusinessPoll);
            }
            else if (parameters.Proficiency == "Números")
            {
                result = BuscaDadosNumeros(parameters.CodigoEscola, parameters.Proficiency, parameters.Term, BusinessPoll);
            }

            PollReportMathStudentResult retorno = new PollReportMathStudentResult();
            retorno.Results = result;

            var listaGrafico = graficos.GroupBy(fu => fu.Name).Select(g => new { Label = g.Key, Value = g.Count() }).ToList();
            graficos = new List<MathChartDataModel>();
            foreach (var item in listaGrafico)
            {
                graficos.Add(new MathChartDataModel()
                {
                    Name = item.Label
                    //,Value = item.Value
                });
            }
            retorno.ChartData = graficos;

            return retorno;
        }

        private List<PollReportMathStudentItem> BuscaDadosCA(string codigoEscola, string proficiency, string term, PollMatematica BusinessPoll)
        {
            List<PollReportMathStudentItem> result = new List<PollReportMathStudentItem>();

            List<MathChartDataModel> graficos = new List<MathChartDataModel>();

            var listaAlunosTurma = BusinessPoll.BuscarAlunosTurmaRelatorioMatematicaCA(codigoEscola, proficiency, term);

            foreach (var sondagem in listaAlunosTurma)
            {

                List<MathStudentItemResult> pollTotal = new List<MathStudentItemResult>();

                MathStudentItemResult item1 = new MathStudentItemResult();
                item1.Idea = sondagem.Ordem1Ideia;
                item1.Order = "1";
                item1.Result = sondagem.Ordem1Resultado;

                pollTotal.Add(item1);


                MathStudentItemResult item2 = new MathStudentItemResult();
                item1.Idea = sondagem.Ordem2Ideia;
                item1.Order = "2";
                item1.Result = sondagem.Ordem2Resultado;

                pollTotal.Add(item2);

                MathStudentItemResult item3 = new MathStudentItemResult();
                item1.Idea = sondagem.Ordem3Ideia;
                item1.Order = "3";
                item1.Result = sondagem.Ordem3Resultado;

                pollTotal.Add(item3);


                MathStudentItemResult item4 = new MathStudentItemResult();
                item1.Idea = sondagem.Ordem4Ideia;
                item1.Order = "4";
                item1.Result = sondagem.Ordem4Resultado;

                pollTotal.Add(item4);

                string tipo = "";//ConverterProficienciaAluno(parameters.Proficiency, parameters.Term, sondagem);
                result.Add(
                    new PollReportMathStudentItem()
                    {
                        Code = sondagem.AlunoEolCode,
                        StudentName = "Aluno " + sondagem.AlunoEolCode,
                        Poll = pollTotal
                    }
                );

                graficos.Add(new MathChartDataModel()
                {
                    Name = "" // tipo
                              //,Value = 1
                });

            }
            return result;
        }



        private List<PollReportMathStudentItem> BuscaDadosCM(string codigoEscola, string proficiency, string term, PollMatematica BusinessPoll)
        {
            List<PollReportMathStudentItem> result = new List<PollReportMathStudentItem>();

            List<MathChartDataModel> graficos = new List<MathChartDataModel>();

            var listaAlunosTurma = BusinessPoll.BuscarAlunosTurmaRelatorioMatematicaCM(codigoEscola, proficiency, term);

            foreach (var sondagem in listaAlunosTurma)
            {

                List<MathStudentItemResult> pollTotal = new List<MathStudentItemResult>();

                MathStudentItemResult item4 = new MathStudentItemResult();
                item4.Idea = sondagem.Ordem4Ideia;
                item4.Order = "4";
                item4.Result = sondagem.Ordem4Resultado;

                pollTotal.Add(item4);


                MathStudentItemResult item5 = new MathStudentItemResult();
                item5.Idea = sondagem.Ordem5Ideia;
                item5.Order = "5";
                item5.Result = sondagem.Ordem5Resultado;

                pollTotal.Add(item5);

                MathStudentItemResult item6 = new MathStudentItemResult();
                item6.Idea = sondagem.Ordem6Ideia;
                item6.Order = "6";
                item6.Result = sondagem.Ordem6Resultado;

                pollTotal.Add(item6);


                MathStudentItemResult item7 = new MathStudentItemResult();
                item7.Idea = sondagem.Ordem7Ideia;
                item7.Order = "7";
                item7.Result = sondagem.Ordem7Resultado;

                pollTotal.Add(item7);

                MathStudentItemResult item8 = new MathStudentItemResult();
                item8.Idea = sondagem.Ordem8Ideia;
                item8.Order = "8";
                item8.Result = sondagem.Ordem8Resultado;

                pollTotal.Add(item7);

                string tipo = "";//ConverterProficienciaAluno(parameters.Proficiency, parameters.Term, sondagem);
                result.Add(
                    new PollReportMathStudentItem()
                    {
                        Code = sondagem.AlunoEolCode,
                        StudentName = "Aluno " + sondagem.AlunoEolCode,
                        Poll = pollTotal
                    }
                );

                graficos.Add(new MathChartDataModel()
                {
                    Name = "" // tipo
                              //,Value = 1
                });

            }
            return result;
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
                item1.Order = "Familiares ou Frequentes";  
                item1.Result = sondagem.Familiares;
                pollTotal.Add(item1);

                MathStudentItemResult item2 = new MathStudentItemResult();
                item1.Idea = "Opacos";
                item1.Order = "Opacos";
                item1.Result = sondagem.Opacos;
                pollTotal.Add(item2);

                MathStudentItemResult item3 = new MathStudentItemResult();
                item1.Idea = "Transparentes";
                item1.Order = "Transparentes";
                item1.Result = sondagem.Transparentes;
                pollTotal.Add(item3);

                MathStudentItemResult item4 = new MathStudentItemResult();
                item1.Idea = "Terminam em Zero";
                item1.Order = "1";
                item1.Result = sondagem.TerminamZero;
                pollTotal.Add(item4);

                MathStudentItemResult item5 = new MathStudentItemResult();
                item1.Idea = "Algarismos Iguais";
                item1.Order = "1";
                item1.Result = sondagem.Algarismos ;
                pollTotal.Add(item4);

                MathStudentItemResult item6 = new MathStudentItemResult();
                item1.Idea = "Processos de Generalização";
                item1.Order = "1";
                item1.Result = sondagem.Processo;
                pollTotal.Add(item4);

                MathStudentItemResult item7 = new MathStudentItemResult();
                item1.Idea = "Zeros Intercalados";
                item1.Order = "1";
                item1.Result = sondagem.ZeroIntercalados;
                pollTotal.Add(item4);

                string tipo = "";//ConverterProficienciaAluno(parameters.Proficiency, parameters.Term, sondagem);
                result.Add(
                    new PollReportMathStudentItem()
                    {
                        Code = sondagem.AlunoEolCode,
                        StudentName = "Aluno " + sondagem.AlunoEolCode,
                        Poll = pollTotal
                    }
                );

                graficos.Add(new MathChartDataModel()
                {
                    Name = "" // tipo
                              //,Value = 1
                });

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
                        StudentName = "Aluno " + sondagem.studentCodeEol,
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