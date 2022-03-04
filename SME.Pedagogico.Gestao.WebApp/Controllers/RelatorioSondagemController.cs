using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.Business;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Data.DTO.Matematica.Relatorio;
using SME.Pedagogico.Gestao.Data.DTO.Portugues.Relatorio;
using SME.Pedagogico.Gestao.Models.Academic;
using SME.Pedagogico.Gestao.Models.Autoral;
using SME.Pedagogico.Gestao.WebApp.Models.RelatorioSondagem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpPost]
        public async Task<ActionResult> ObterDadosTeste([FromBody]RelatorioPortuguesFiltroDto filtro)
        {
            var relatorio = new RelatorioPortugues();

            return Ok(await relatorio.ObterRelatorioPorTurmasPortugues(filtro));
        }

        #region ==================== METHODS ====================
        [HttpPost]
        public async Task<ActionResult<string>> ObterDados([FromBody]ParametersModel parameters)
        {
            var businessPoll = new Data.Business.PollPortuguese(_config);

            if (EhRelatorioDeMatematicaAutoral(parameters))
            {
                var filtro = new filtrosRelatorioDTO()
                {
                    AnoEscolar = int.Parse(parameters.CodigoCurso),
                    AnoLetivo = int.Parse(parameters.SchoolYear),
                    CodigoDre = parameters.CodigoDRE,
                    CodigoUe = parameters.CodigoEscola,
                    CodigoTurmaEol = parameters.CodigoTurmaEol,
                    DescricaoDisciplina = parameters.Discipline,
                    DescricaoPeriodo = parameters.Term,
                };
                var obj = new RelatorioMatematicaAutoral();

                if (parameters.ClassroomReport)
                {
                    var relatorioPorTurma = await obj.ObterRelatorioPorTurma(filtro);
                    return (Ok(relatorioPorTurma));
                }

                return await ObtenhaRelatorioMatematicaAutoral(filtro, parameters.Proficiency);
            }

            Periodo periodo = await businessPoll.ObterPeriodoRelatorioPorDescricao(parameters.Term);


            if (parameters.Discipline == "Língua Portuguesa")
            {
                if (parameters.ClassroomReport)
                {
                    if (Convert.ToInt32(parameters.CodigoCurso) < 4)
                    {

                        PollReportPortugueseStudentResult result = new PollReportPortugueseStudentResult();
                        result = await BuscarDadosPorTurmaAsync(parameters, periodo);

                        return (Ok(result));
                    }

                    if (parameters.GrupoId != null && parameters.GrupoId.Equals("e27b99a3-789d-43fb-a962-7df8793622b1"))
                    {
                        var relatorioCapacidadeLeitura = new RelatorioPortuguesCapacidadeLeitura();
                        var relatorio = await relatorioCapacidadeLeitura.ObterRelatorioCapacidadeLeituraPorTurma(new RelatorioPortuguesFiltroDto
                        {
                            AnoEscolar = Convert.ToInt32(parameters.CodigoCurso),
                            AnoLetivo = Convert.ToInt32(parameters.SchoolYear),
                            CodigoDre = parameters.CodigoDRE,
                            CodigoUe = parameters.CodigoEscola,
                            ComponenteCurricularId = "c65b2c0a-7a58-4d40-b474-23f0982f14b1",
                            GrupoId = "e27b99a3-789d-43fb-a962-7df8793622b1",
                            PeriodoId = periodo.Id,
                            CodigoTurma = parameters.CodigoTurmaEol
                        });

                        return Ok(relatorio);
                    }

                    return Ok(await ObterRelatorioProducaoTextoLeituraVozAlta(parameters, periodo));
                }
                else
                {

                    if (periodo == null)
                        return StatusCode(500, $"Não foi possivel encontrar o périodo com descrição {parameters.Term}");

                    if (Convert.ToInt32(parameters.CodigoCurso) < 4)
                    {
                        PollReportPortugueseResult result = new PollReportPortugueseResult();
                        result = await BuscarDadosSyncAsync(parameters, parameters.SchoolYear, parameters.CodigoDRE, parameters.CodigoEscola, parameters.CodigoCurso, businessPoll, periodo);

                        return (Ok(result));
                    }

                    if (parameters.GrupoId.Equals("e27b99a3-789d-43fb-a962-7df8793622b1"))
                    {
                        var relatorioCapacidadeLeitura = new RelatorioPortuguesCapacidadeLeitura();
                        var relatorioCapacidade = await relatorioCapacidadeLeitura.ObterRelatorioCapacidadeLeitura(new RelatorioPortuguesFiltroDto
                        {
                            AnoEscolar = Convert.ToInt32(parameters.CodigoCurso),
                            AnoLetivo = Convert.ToInt32(parameters.SchoolYear),
                            CodigoDre = parameters.CodigoDRE,
                            CodigoUe = parameters.CodigoEscola,
                            ComponenteCurricularId = "c65b2c0a-7a58-4d40-b474-23f0982f14b1",
                            GrupoId = "e27b99a3-789d-43fb-a962-7df8793622b1",
                            PeriodoId = periodo.Id
                        });

                        return (Ok(relatorioCapacidade));

                    }
                    return Ok(await BuscarDadosAutoralAsync(parameters, periodo.Id));
                }
            }
            else if (parameters.Discipline == "Matemática")
            {
                if (parameters.ClassroomReport)
                {
                    if (parameters.Proficiency == "Números")
                    {
                        PollReportMathStudentNumbersResult result = await BuscaDadosMathTurmaNumbersAsync(parameters.Proficiency,
                                                                                                  parameters.Term,
                                                                                                  parameters.CodigoDRE,
                                                                                                  parameters.CodigoEscola,
                                                                                                  parameters.CodigoTurmaEol, parameters.CodigoCurso, parameters.SchoolYear);

                        return (Ok(result));
                    }
                    else
                    {
                        PollReportMathStudentResult result = await BuscaDadosMathTurmaAsync(parameters.Proficiency,
                                                                                                      parameters.Term,
                                                                                                      parameters.CodigoDRE,
                                                                                                      parameters.CodigoEscola,
                                                                                                      parameters.CodigoTurmaEol, parameters.CodigoCurso, parameters.SchoolYear);
                        return (Ok(result));
                    }

                }

                else    // cONSOLIDADO
                {
                    var result = await BuscaDadosMathAsync(parameters, parameters.SchoolYear, parameters.CodigoDRE, parameters.CodigoEscola, parameters.CodigoCurso, periodo);
                    return Ok(result);
                }
            }

            return (NotFound());
        }

        private static async Task<RelatorioPortuguesTurmaDto> ObterRelatorioProducaoTextoLeituraVozAlta(ParametersModel parameters, Periodo periodo)
        {
            var relatorio = new RelatorioPortugues();

            var retorno = await relatorio.ObterRelatorioPorTurmasPortugues(new RelatorioPortuguesFiltroDto
            {
                AnoEscolar = Convert.ToInt32(parameters.CodigoCurso),
                AnoLetivo = Convert.ToInt32(parameters.SchoolYear),
                CodigoDre = parameters.CodigoDRE,
                CodigoTurma = parameters.CodigoTurmaEol,
                CodigoUe = parameters.CodigoEscola,
                ComponenteCurricularId = "c65b2c0a-7a58-4d40-b474-23f0982f14b1",
                GrupoId = parameters.GrupoId,
                PeriodoId = periodo.Id
            });
            return retorno;
        }

        private async Task<PollReportMathStudentResult> BuscaDadosMathTurmaAsync(string proficiency, string term, string codigoDre, string codigoEscola, string codigoTurma, string codigoCurso, string schoolYear)
        {
            var businessPoll = new Data.Business.SondagemMatematicaTurma(_config);

            return await businessPoll.BuscarDadosMatematicaPorTurmaAsync(proficiency, term, codigoDre, codigoEscola, codigoTurma, codigoCurso, schoolYear);

        }
        private async Task<PollReportMathStudentNumbersResult> BuscaDadosMathTurmaNumbersAsync(string proficiency, string term, string codigoDre, string codigoEscola, string codigoTurma, string codigoCurso, string schoolYear)
        {
            var businessPoll = new Data.Business.SondagemMatematicaTurma(_config);

            return await businessPoll.BuscarDadosMatematicaPorTurmaNumbersAsync(proficiency, term, codigoDre, codigoEscola, codigoTurma, codigoCurso, schoolYear);

        }

        private async Task<PollReportMathResult> BuscaDadosMathAsync(ParametersModel parameters, string anoLetivo, string codigoDre, string codigoEscola, string anoTurma, Periodo periodo)
        {
            var businessPoll = new Data.Business.SondagemMatematica(_config);

            return await businessPoll
                .BuscarDadosRelatorioMatematicaAsync(parameters.Proficiency,
                                                     parameters.Term,
                                                     anoLetivo,
                                                     codigoDre,
                                                     codigoEscola,
                                                     anoTurma,
                                                     periodo);
        }

        private async Task<RelatorioAutoralLeituraProducaoDto> BuscarDadosAutoralAsync(ParametersModel parametersModel, string periodoId)
        {
            var relatorioPortugues = new RelatorioPortugues();

            return await relatorioPortugues.ObterRelatorioConsolidadoPortugues(new RelatorioPortuguesFiltroDto
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

        private async Task<PollReportPortugueseResult> BuscarDadosSyncAsync(ParametersModel parameters, string anoLetivo, string codigoDre, string codigoEscola, string codigoCurso, PollPortuguese businessPoll, Periodo periodo)
        {
            return await businessPoll.BuscarDadosRelatorioPortugues(parameters.Proficiency, parameters.Term, anoLetivo, codigoDre, codigoEscola, codigoCurso, periodo);
        }

        private async Task<PollReportPortugueseStudentResult> BuscarDadosPorTurmaAsync(ParametersModel parameters, Periodo periodo)
        {
            var BusinessPoll = new Data.Business.PollPortuguese(_config);
            var alunosBusiness = new AlunosBusiness(_config);

            var alunosEol = await alunosBusiness.ObterAlunosEOL(parameters.SchoolYear, parameters.CodigoTurmaEol, parameters.Term);

            var listaAlunosTurma = await BusinessPoll.BuscarAlunosTurmaRelatorioPortugues(
                parameters.CodigoTurmaEol,
                parameters.Proficiency,
                parameters.Term,
                periodo,
                Convert.ToInt32(parameters.SchoolYear),
                parameters.CodigoDRE,
                parameters.CodigoEscola,
                parameters.CodigoCurso);//ajustar para pegar a turma 

            List<PollReportPortugueseStudentItem> result = new List<PollReportPortugueseStudentItem>();

            List<PortChartDataModel> graficos = new List<PortChartDataModel>();

            foreach (var aluno in alunosEol)
            {
                var sondagem = listaAlunosTurma.FirstOrDefault(s => s.studentCodeEol == aluno.CodigoAluno.ToString());
                string tipo = ConverterProficienciaAluno(parameters.Proficiency, parameters.Term, sondagem);
                result.Add(
                    new PollReportPortugueseStudentItem()
                    {
                        Code = aluno.CodigoAluno.ToString(),
                        StudentName = aluno.NomeAlunoRelatorio,
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
                if (!string.IsNullOrWhiteSpace(item.Label))
                {
                    graficos.Add(new PortChartDataModel()
                    {
                        Name =  item.Label,
                        Value = item.Value
                    });
                }
                
            }
            retorno.ChartData = graficos.OrderBy(a => a.Name).ToList();


            var semPreenchimento = listaGrafico.FirstOrDefault(a => string.IsNullOrWhiteSpace(a.Label));
            if (semPreenchimento != null)
            {
                retorno.ChartData.Add(new PortChartDataModel()
                {
                    Name = "Sem Preenchimento",
                    Value = semPreenchimento.Value
                });
            }

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
        private bool EhRelatorioDeMatematicaAutoral(ParametersModel parameters)
        {
            return parameters.Discipline == "Matemática" &&
                 (int.Parse(parameters.CodigoCurso) >= 7 || int.Parse(parameters.SchoolYear) >= 2022);
        }

        private bool ProficienciaEhNumero(string proficiencia)
        {
            return proficiencia.Equals("Números", StringComparison.InvariantCultureIgnoreCase);
        }

        private async Task<ActionResult<string>> ObtenhaRelatorioMatematicaAutoral(filtrosRelatorioDTO filtro, string proficiencia)
        {
            var relatorio = new RelatorioMatematicaAutoral();

            if (filtro.AnoEscolar <= 3 && !ProficienciaEhNumero(proficiencia))
            {
                return Ok(await relatorio.ObtenhaRelatorioMatematicaProficiencia(filtro, proficiencia));
            }

            return Ok(await relatorio.ObterRelatorioMatematicaAutoral(filtro));
        }
        #endregion ==================== METHODS ====================
    }
}