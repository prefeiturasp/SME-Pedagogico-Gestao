using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
                    result = await BuscarDadosSyncAsync(parameters, "2019", "4", "", "");

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
                    PollReportMathItem item1 = new PollReportMathItem() { OrderName = "ORDEM 1" };
                    item1.Results.Add(new MathItemResult()
                    {
                        TestName = "Acertou",
                        TestIdeaQuantity = 60,
                        TestIdeaPercentage = 60,
                        TestResultQuantity = 60,
                        TestResultPercentage = 60
                    });
                    item1.Results.Add(new MathItemResult()
                    {
                        TestName = "Errou",
                        TestIdeaQuantity = 30,
                        TestIdeaPercentage = 30,
                        TestResultQuantity = 30,
                        TestResultPercentage = 30
                    });
                    item1.Results.Add(new MathItemResult()
                    {
                        TestName = "Não Respondeu",
                        TestIdeaQuantity = 45,
                        TestIdeaPercentage = 45,
                        TestResultQuantity = 45,
                        TestResultPercentage = 45
                    });

                    PollReportMathItem item2 = new PollReportMathItem() { OrderName = "ORDEM 2" };
                    item2.Results.Add(new MathItemResult()
                    {
                        TestName = "Acertou",
                        TestIdeaQuantity = 60,
                        TestIdeaPercentage = 60,
                        TestResultQuantity = 60,
                        TestResultPercentage = 60
                    });
                    item2.Results.Add(new MathItemResult()
                    {
                        TestName = "Errou",
                        TestIdeaQuantity = 30,
                        TestIdeaPercentage = 30,
                        TestResultQuantity = 30,
                        TestResultPercentage = 30
                    });
                    item2.Results.Add(new MathItemResult()
                    {
                        TestName = "Não Respondeu",
                        TestIdeaQuantity = 45,
                        TestIdeaPercentage = 45,
                        TestResultQuantity = 45,
                        TestResultPercentage = 45
                    });

                    PollReportMathItem item3 = new PollReportMathItem() { OrderName = "ORDEM 3" };
                    item3.Results.Add(new MathItemResult()
                    {
                        TestName = "Acertou",
                        TestIdeaQuantity = 60,
                        TestIdeaPercentage = 60,
                        TestResultQuantity = 60,
                        TestResultPercentage = 60
                    });
                    item3.Results.Add(new MathItemResult()
                    {
                        TestName = "Errou",
                        TestIdeaQuantity = 30,
                        TestIdeaPercentage = 30,
                        TestResultQuantity = 30,
                        TestResultPercentage = 30
                    });
                    item3.Results.Add(new MathItemResult()
                    {
                        TestName = "Não Respondeu",
                        TestIdeaQuantity = 45,
                        TestIdeaPercentage = 45,
                        TestResultQuantity = 45,
                        TestResultPercentage = 45
                    });

                    PollReportMathItem item4 = new PollReportMathItem() { OrderName = "ORDEM 4" };
                    item4.Results.Add(new MathItemResult()
                    {
                        TestName = "Acertou",
                        TestIdeaQuantity = 60,
                        TestIdeaPercentage = 60,
                        TestResultQuantity = 60,
                        TestResultPercentage = 60
                    });
                    item4.Results.Add(new MathItemResult()
                    {
                        TestName = "Errou",
                        TestIdeaQuantity = 30,
                        TestIdeaPercentage = 30,
                        TestResultQuantity = 30,
                        TestResultPercentage = 30
                    });
                    item4.Results.Add(new MathItemResult()
                    {
                        TestName = "Não Respondeu",
                        TestIdeaQuantity = 45,
                        TestIdeaPercentage = 45,
                        TestResultQuantity = 45,
                        TestResultPercentage = 45
                    });

                    PollReportMathResult result = new PollReportMathResult();
                    result.Results.Add(item1);
                    result.Results.Add(item2);
                    result.Results.Add(item3);
                    result.Results.Add(item4);
                    result.ChartData.Add(new Data.DTO.MathChartDataModel()
                    {
                        Name = "ORDEM 1",
                        Idea = new List<int>() { 60, 13, 30 },
                        Result = new List<int>() { 25, 30, 45 }
                    });
                    result.ChartData.Add(new Data.DTO.MathChartDataModel()
                    {
                        Name = "ORDEM 2",
                        Idea = new List<int>() { 20, 40, 30 },
                        Result = new List<int>() { 10, 15, 5 }
                    });
                    result.ChartData.Add(new Data.DTO.MathChartDataModel()
                    {
                        Name = "ORDEM 3",
                        Idea = new List<int>() { 60, 13, 30 },
                        Result = new List<int>() { 60, 30, 45 }
                    });

                    return (Ok(result));
                }
            }

            return (NotFound());
        }

        private PollReportMathStudentResult BuscarDadosMatematicaPorTurmaAsync(ParametersModel parameters)
        {
            var BusinessPoll = new Data.Business.PollMatematica(_config);


            //ajustar para pegar a turma 
            List<PollReportMathStudentItem> result = new List<PollReportMathStudentItem>();
            List<MathChartDataModel> graficos = new List<MathChartDataModel>();

            if (parameters.Proficiency == "Campo Aditivo")
            {
                var listaAlunosTurmaObj = BusinessPoll.BuscarAlunosTurmaRelatorioMatematicaCA("1996399", parameters.Proficiency, parameters.Term);

                foreach (var sondagem in listaAlunosTurmaObj)
                {
                    string tipo = "";//ConverterProficienciaAluno(parameters.Proficiency, parameters.Term, sondagem);
                    result.Add(
                        new PollReportMathStudentItem()
                        {
                            Code = sondagem.AlunoEolCode,
                            StudentName = "Aluno " + sondagem.AlunoEolCode
                            //,StudentValue = tipo    //aqui irei inserir o o
                        }
                    );

                    graficos.Add(new MathChartDataModel()
                    {
                        Name = "" // tipo
                                  //,Value = 1
                    });
                }
            }
            else if (parameters.Proficiency == "Campo Multiplicativo")
            {

                var listaAlunosTurma = BusinessPoll.BuscarAlunosTurmaRelatorioMatematicaCM("1996399", parameters.Proficiency, parameters.Term);
            }
            else if (parameters.Proficiency == "Números")
            {
                var listaAlunosTurma =  BusinessPoll.BuscarAlunosTurmaRelatorioMatematicaNumber("1996399", parameters.Proficiency, parameters.Term);

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

        private async Task<PollReportPortugueseResult> BuscarDadosSyncAsync(ParametersModel parameters, string anoLetivo, string codigoDre, string codigoEscola, string codigoCurso)
        {
            var BusinessPoll = new Data.Business.PollPortuguese(_config);

            return await BusinessPoll.BuscarDadosRelatorioPortugues(parameters.Proficiency, parameters.Term, anoLetivo, codigoDre, codigoEscola, codigoCurso);
            ;
        }

        private async Task<PollReportPortugueseStudentResult> BuscarDadosPorTurmaAsync(ParametersModel parameters)
        {
            var BusinessPoll = new Data.Business.PollPortuguese(_config);
            var listaAlunosTurma = await BusinessPoll.BuscarAlunosTurmaRelatorioPortugues("1992661", parameters.Proficiency, parameters.Term);//ajustar para pegar a turma 
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