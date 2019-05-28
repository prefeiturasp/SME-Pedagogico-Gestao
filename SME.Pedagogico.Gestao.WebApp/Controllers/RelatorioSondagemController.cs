using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SME.Pedagogico.Gestao.WebApp.Models.RelatorioSondagem;

namespace SME.Pedagogico.Gestao.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RelatorioSondagemController : ControllerBase
    {
        #region ==================== METHODS ====================
        [HttpPost]
        public async Task<ActionResult<string>> ObterDados([FromBody]ParametersModel parameters)
        {
            if (parameters.Discipline == "Língua Portuguesa")
            {
                if (parameters.ClassroomReport)
                {
                    List<PollReportPortugueseStudentItem> result = new List<PollReportPortugueseStudentItem>();
                    result.Add(new PollReportPortugueseStudentItem()
                    {
                        Code = "1",
                        StudentName = "Alvaro Ramos Grassi",
                        StudentValue = "Pré-Silábico"
                    });
                    result.Add(new PollReportPortugueseStudentItem()
                    {
                        Code = "2",
                        StudentName = "Amanda Aparecida",
                        StudentValue = "Pré-Silábico"
                    });
                    result.Add(new PollReportPortugueseStudentItem()
                    {
                        Code = "3",
                        StudentName = "Anna Beatriz de Goes Callejon",
                        StudentValue = "Silábico Alfabético"
                    });
                    result.Add(new PollReportPortugueseStudentItem()
                    {
                        Code = "4",
                        StudentName = "Caique Siqueira",
                        StudentValue = "Alfabético"
                    });

                    return (Ok(result));
                }
                else
                {
                    List<PollReportPortugueseItem> result = new List<PollReportPortugueseItem>();
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
        #endregion ==================== METHODS ====================
    }
}