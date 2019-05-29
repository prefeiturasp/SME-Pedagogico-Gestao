using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.DataTransfer;
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
                    List<PollReportPortugueseStudentItem> result = await BuscarDadosPorTurmaAsync(parameters);                 
                  
                    return (Ok(result));                   
                }
                else
                {

                    List<PollReportPortugueseItem> result = await BuscarDadosSyncAsync(parameters, "2019","4", "", "");
                        //await BuscarDadosSync(parameters, anoLetivo, codigoDre, codigoEscola, codigoCurso);

                    //   List<PollReportPortugueseItem> result = new List<PollReportPortugueseItem>();


                    //Tirar esse mock e incluar 
                    result.Add(new PollReportPortugueseItem()
                    {
                        OptionName = "Pré-Silábico",
                        studentQuantity = 60,
                        StudentPercentage = 35.71
                    });
                    result.Add(new PollReportPortugueseItem()
                    {
                        OptionName = "Silábico sem Valor",
                        studentQuantity = 30,
                        StudentPercentage = 17.86
                    });
                    result.Add(new PollReportPortugueseItem()
                    {
                        OptionName = "Silábico com Valor",
                        studentQuantity = 45,
                        StudentPercentage = 26.78
                    });
                    result.Add(new PollReportPortugueseItem()
                    {
                        OptionName = "Silábico Alfabético",
                        studentQuantity = 23,
                        StudentPercentage = 13.69
                    });
                    result.Add(new PollReportPortugueseItem()
                    {
                        OptionName = "Alfabético",
                        studentQuantity = 10,
                        StudentPercentage = 5.95
                    });

                    return (Ok(result));
                }
            }
            else if (parameters.Discipline == "Matemática")
            {
                if (parameters.ClassroomReport)
                {
                    List<PollReportMathStudentItem> result = new List<PollReportMathStudentItem>();

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


                    result.Add(item1);
                    result.Add(item2);
                    result.Add(item3);
                    result.Add(item4);

                    return (Ok(result));
                }
                else
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

                    List<PollReportMathItem> result = new List<PollReportMathItem>();
                    result.Add(item1);
                    result.Add(item2);
                    result.Add(item3);
                    result.Add(item4);

                    return (Ok(result));
                }
            }

            return (NotFound());
        }

        private async Task<List<PollReportPortugueseItem>> BuscarDadosSyncAsync(ParametersModel parameters, string anoLetivo, string codigoDre, string codigoEscola, string codigoCurso)
        {
            var BusinessPoll = new Data.Business.PollPortuguese(_config);
             BusinessPoll.BuscarDadosRelatorioPortugues(parameters.Proficiency, parameters.Term,  anoLetivo,  codigoDre,  codigoEscola,  codigoCurso);//ajustar para pegar a turma 
            List<PollReportPortugueseItem> result = new List<PollReportPortugueseItem>();//ola Dani
            //foreach (var sondagem in listaAlunosTurma)
            //{
            //    result.Add(new PollReportPortugueseItem()
            //    {
            //        OptionName = "Alfabético",
            //        studentQuantity = 10,
            //        StudentPercentage = 5.95
            //    });
            //}
            return result;
        }

        private async Task<List<PollReportPortugueseStudentItem>> BuscarDadosPorTurmaAsync(ParametersModel parameters)
        {
            var BusinessPoll = new Data.Business.PollPortuguese(_config);
            var listaAlunosTurma = await BusinessPoll.BuscarAlunosTurmaRelatorioPortugues("1992661", parameters.Proficiency, parameters.Term);//ajustar para pegar a turma 
            List<PollReportPortugueseStudentItem> result = new List<PollReportPortugueseStudentItem>();//ola Dani
            foreach (var sondagem in listaAlunosTurma)
            {
                result.Add(
                    new PollReportPortugueseStudentItem()
                    {
                        Code = sondagem.studentCodeEol,
                        StudentName = "Aluno " + sondagem.studentCodeEol,
                        StudentValue = ConverterProficienciaAluno(parameters.Proficiency, parameters.Term, sondagem)
                    }
                );
            }
            return result;
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