using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.Business;
using SME.Pedagogico.Gestao.Data.DTO.Matematica.Relatorio;

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

            if (int.Parse(parameters.CodigoCurso) >= 7 && parameters.Discipline == "Matemática")
            {
                var filtro = new filtrosRelatorioDTO()
                {
                    AnoDaTurma = int.Parse(parameters.CodigoCurso),
                    AnoLetivo = int.Parse(parameters.SchoolYear),
                    CodigoDRE = parameters.CodigoDRE,
                    CodigoEscola = parameters.CodigoEscola,
                    CodigoTurmaEol = parameters.CodigoTurmaEol,
                    DescricaoDisciplina = parameters.Discipline,
                    DescricaoPeriodo = parameters.Term,
                };
                var obj = new RelatorioMatematicaAutoral();
                var retorno = await obj.ObterPeriodoMatematica(filtro);
               return  (Ok(retorno));
            }


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
                    result = await BuscarDadosSyncAsync(parameters, parameters.SchoolYear, parameters.CodigoDRE, parameters.CodigoEscola, parameters.CodigoCurso);

                    return (Ok(result));
                }
            }
            else if (parameters.Discipline == "Matemática")
            {
                if (parameters.ClassroomReport)
                {
                    if (parameters.Proficiency == "Números")
                    {
                        PollReportMathStudentNumbersResult result = BuscaDadosMathTurmaNumbersAsync(parameters.Proficiency,
                                                                                                  parameters.Term,
                                                                                                  parameters.CodigoDRE,
                                                                                                  parameters.CodigoEscola,
                                                                                                  parameters.CodigoTurmaEol, parameters.CodigoCurso);




                        return (Ok(result));
                    }
                    else
                    {
                        PollReportMathStudentResult result = BuscaDadosMathTurmaAsync(parameters.Proficiency,
                                                                                                      parameters.Term,
                                                                                                      parameters.CodigoDRE,
                                                                                                      parameters.CodigoEscola,
                                                                                                      parameters.CodigoTurmaEol, parameters.CodigoCurso);


                        return (Ok(result));
                    }

                }

                else    // cONSOLIDADO
                {
                    var result = await BuscaDadosMathAsync(parameters, parameters.SchoolYear, parameters.CodigoDRE, parameters.CodigoEscola, parameters.CodigoCurso);
                    return Ok(result);
                }
            }

            return (NotFound());
        }


        private PollReportMathStudentResult BuscaDadosMathTurmaAsync(string proficiency, string term, string codigoDre, string codigoEscola, string codigoTurma, string codigoCurso)
        {
            var businessPoll = new Data.Business.SondagemMatematicaTurma(_config);

            return businessPoll.BuscarDadosMatematicaPorTurmaAsync(proficiency, term, codigoDre, codigoEscola, codigoTurma, codigoCurso);

        }
        private PollReportMathStudentNumbersResult BuscaDadosMathTurmaNumbersAsync(string proficiency, string term, string codigoDre, string codigoEscola, string codigoTurma, string codigoCurso)
        {
            var businessPoll = new Data.Business.SondagemMatematicaTurma(_config);

            return businessPoll.BuscarDadosMatematicaPorTurmaNumbersAsync(proficiency, term, codigoDre, codigoEscola, codigoTurma, codigoCurso);

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
                    return "Pré-Silábico";
                case "SSV":
                    return "Silábico sem valor";
                case "SCV":
                    return "Silábico com valor";
                case "SA":
                    return "Silábico alfabético";
                case "A":
                    return "Alfabético";
                default:
                    return proficiencia;
            }
        }



        #endregion ==================== METHODS ====================
    }
}