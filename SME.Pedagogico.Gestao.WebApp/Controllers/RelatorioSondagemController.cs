﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.Business;
using SME.Pedagogico.Gestao.Data.DataTransfer;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Data.DTO.Portugues.Relatorio;
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
                    var businessPoll = new Data.Business.PollPortuguese(_config);

                    if (Convert.ToInt32(parameters.CodigoCurso) < 4)
                    {
                        PollReportPortugueseResult result = new PollReportPortugueseResult();
                        result = await BuscarDadosSyncAsync(parameters, parameters.SchoolYear, parameters.CodigoDRE, parameters.CodigoEscola, parameters.CodigoCurso, businessPoll);

                        return (Ok(result));
                    }

                    var periodo = await businessPoll.ObterPeriodoRelatorioPorDescricao(parameters.Term);

                    if (periodo == null)
                        return StatusCode(500, $"Não foi possivel encontrar o périodo com descrição {parameters.Term}");

                    return Ok(await BuscarDadosAutoralAsync(parameters, periodo.Id));
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

        private async Task<RelatorioAutoralLeituraProducaoDto> BuscarDadosAutoralAsync(ParametersModel parametersModel, string periodoId)
        {
            if (parametersModel.GrupoId.Equals("e27b99a3-789d-43fb-a962-7df8793622b1"))
            {
                // Adicionar implementação do consolidado de capacidade de Leitura
                return null;
            }

            var relatorioPortugues = new RelatorioPortugues();

            return await relatorioPortugues.ObterRelatorioPortugues(new RelatorioPortuguesFiltroDto
            {
                AnoEscolar = Convert.ToInt32(parametersModel.CodigoCurso),
                AnoLetivo = Convert.ToInt32(parametersModel.SchoolYear),
                CodigoDre = parametersModel.CodigoDRE,
                CodigoUe = parametersModel.CodigoEscola,
                ComponenteCurricularId = "c65b2c0a-7a58-4d40-b474-23f0982f14b1",
                GrupoId = parametersModel.GrupoId,
                PeriodoId = periodoId
            });
        }

        private async Task<PollReportPortugueseResult> BuscarDadosSyncAsync(ParametersModel parameters, string anoLetivo, string codigoDre, string codigoEscola, string codigoCurso, PollPortuguese businessPoll)
        {
            return await businessPoll.BuscarDadosRelatorioPortugues(parameters.Proficiency, parameters.Term, anoLetivo, codigoDre, codigoEscola, codigoCurso);
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