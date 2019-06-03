using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Data.Enums;
using SME.Pedagogico.Gestao.Data.Functionalities;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using SME.Pedagogico.Gestao.Models.Academic;

namespace SME.Pedagogico.Gestao.Data.Business
{
    public class SondagemMatematica
    {
        private string _token;

        public IConfiguration _config;
        public SondagemMatematica(IConfiguration config)
        {
            var createToken = new CreateToken(config);
            _token = createToken.CreateTokenProvisorio();
        }

        public async Task InsertPoolCMAsync(List<SondagemMatematicaOrdemDTO> dadosSondagem)
        {
            using (Contexts.SMEManagementContext db = new Contexts.SMEManagementContext())
            {
                foreach (var student in dadosSondagem)
                {
                    for (int semestre = 1; semestre <= 2; semestre++)
                    {
                        var studentPoolCM = db.MathPoolCMs.Where(x =>
                                                                x.TurmaEolCode == student.CodigoEolTurma &&
                                                                 x.AlunoEolCode == student.CodigoEolAluno &&
                                                                 x.Semestre == semestre).FirstOrDefault();

                        if (studentPoolCM == null)
                        {
                            var newStudentPoolCM = new MathPoolCM();
                            newStudentPoolCM.AlunoEolCode = student.CodigoEolAluno;
                            newStudentPoolCM.DreEolCode = student.CodigoEolDRE;
                            newStudentPoolCM.EscolaEolCode = student.CodigoEolEscola;
                            newStudentPoolCM.AnoTurma = Convert.ToInt32(student.AnoTurma);
                            newStudentPoolCM.TurmaEolCode = student.CodigoEolTurma;
                            newStudentPoolCM.AnoLetivo = Convert.ToInt32(student.AnoLetivo);
                            newStudentPoolCM.Semestre = semestre;

                            MapValuesPoolCM(student, ref newStudentPoolCM);
                            await db.MathPoolCMs.AddAsync(newStudentPoolCM);
                        }
                        else
                        {
                            MapValuesPoolCM(student, ref studentPoolCM);
                            db.MathPoolCMs.Update(studentPoolCM);
                        }
                    }
                }

                await db.SaveChangesAsync();
            }
        }       

        private void MapValuesPoolCM(SondagemMatematicaOrdemDTO studentDTO, 
                                     ref MathPoolCM studentPoolCM)
        {
            if (studentPoolCM.Semestre == 1) {

                if (studentPoolCM.AnoTurma == 2)
                {
                    studentPoolCM.Ordem3Ideia = studentDTO.Ideia3Semestre1;
                    studentPoolCM.Ordem3Resultado = studentDTO.Resultado3Semestre1;
                }
                else
                {
                    studentPoolCM.Ordem4Ideia = studentDTO.Ideia4Semestre1;
                    studentPoolCM.Ordem4Resultado = studentDTO.Resultado4Semestre1;
                    studentPoolCM.Ordem5Ideia = studentDTO.Ideia5Semestre1;
                    studentPoolCM.Ordem5Resultado = studentDTO.Resultado5Semestre1;
                    studentPoolCM.Ordem6Ideia = studentDTO.Ideia6Semestre1;
                    studentPoolCM.Ordem6Resultado = studentDTO.Resultado6Semestre1;
                    studentPoolCM.Ordem7Ideia = studentDTO.Ideia7Semestre1;
                    studentPoolCM.Ordem7Resultado = studentDTO.Resultado7Semestre1;
                    studentPoolCM.Ordem8Ideia = studentDTO.Ideia8Semestre1;
                    studentPoolCM.Ordem8Resultado = studentDTO.Resultado8Semestre1;
                }

            } else if (studentPoolCM.Semestre == 2) {

                if (studentPoolCM.AnoTurma == 2)
                {
                    studentPoolCM.Ordem3Ideia = studentDTO.Ideia3Semestre2;
                    studentPoolCM.Ordem3Resultado = studentDTO.Resultado3Semestre2;
                }
                else
                {
                    studentPoolCM.Ordem4Ideia = studentDTO.Ideia4Semestre2;
                    studentPoolCM.Ordem4Resultado = studentDTO.Resultado4Semestre2;
                    studentPoolCM.Ordem5Ideia = studentDTO.Ideia5Semestre2;
                    studentPoolCM.Ordem5Resultado = studentDTO.Resultado5Semestre2;
                    studentPoolCM.Ordem6Ideia = studentDTO.Ideia6Semestre2;
                    studentPoolCM.Ordem6Resultado = studentDTO.Resultado6Semestre2;
                    studentPoolCM.Ordem7Ideia = studentDTO.Ideia7Semestre2;
                    studentPoolCM.Ordem7Resultado = studentDTO.Resultado7Semestre2;
                    studentPoolCM.Ordem8Ideia = studentDTO.Ideia8Semestre2;
                    studentPoolCM.Ordem8Resultado = studentDTO.Resultado8Semestre2;
                }
            }
        }

        public async Task<List<SondagemMatematicaOrdemDTO>> ListPoolCMAsync(FiltroSondagemMatematicaDTO filtroSondagem)
        {
            try
             {
                var retornoSondagem = new List<SondagemMatematicaOrdemDTO>();

                using (Contexts.SMEManagementContext db = new Contexts.SMEManagementContext())
                {
                    var sondagemDaTurma = db.MathPoolCMs
                                                        .Where(x => x.TurmaEolCode.Equals(filtroSondagem.TurmaEolCode))
                                                        .ToList();


                    var turmApi = new TurmasAPI(new EndpointsAPI());

                    var classroomStudentsFromAPI = await turmApi.GetAlunosNaTurma(Convert.ToInt32(filtroSondagem.TurmaEolCode), Convert.ToInt32(filtroSondagem.AnoLetivo), _token);

                    classroomStudentsFromAPI = classroomStudentsFromAPI.Where(x => x.CodigoSituacaoMatricula == 1).ToList();
                    if (classroomStudentsFromAPI == null)
                    {
                        return null;
                    }

                    foreach (var studentClassRoom in classroomStudentsFromAPI)
                    {
                        var studentDTO = new SondagemMatematicaOrdemDTO();
                        if (sondagemDaTurma != null)
                        {
                            var studentPollsMath = sondagemDaTurma.Where(x => x.AlunoEolCode == studentClassRoom.CodigoAluno.ToString()).ToList();
                            studentDTO.NomeAluno = studentClassRoom.NomeAluno;
                            studentDTO.CodigoEolAluno = studentClassRoom.CodigoAluno.ToString();
                            studentDTO.NumeroAlunoChamada = studentClassRoom.NumeroAlunoChamada.ToString();
                            studentDTO.AnoLetivo = filtroSondagem.AnoLetivo;
                            studentDTO.CodigoEolDRE = filtroSondagem.DreEolCode;
                            studentDTO.CodigoEolEscola = filtroSondagem.EscolaEolCode;
                            studentDTO.AnoTurma = filtroSondagem.AnoTurma;
                            studentDTO.CodigoEolTurma = filtroSondagem.TurmaEolCode;

                            if (studentPollsMath?.Count > 0)
                            {
                                for (int semestre = 1; semestre <= 2; semestre++)
                                {
                                    var studentPollMath = studentPollsMath
                                                            .Where(s => s.Semestre == semestre)
                                                            .FirstOrDefault();

                                    if (semestre.Equals(1))
                                    {
                                        if (studentPollMath.AnoTurma == (int)AnoTurmaEnum.SegundoAno)
                                        {
                                            studentDTO.Ideia3Semestre1 = studentPollMath.Ordem3Ideia;
                                            studentDTO.Resultado3Semestre1 = studentPollMath.Ordem3Resultado;
                                        }
                                        else
                                        {
                                            studentDTO.Ideia4Semestre1 = studentPollMath.Ordem4Ideia;
                                            studentDTO.Ideia5Semestre1 = studentPollMath.Ordem5Ideia;
                                            studentDTO.Ideia6Semestre1 = studentPollMath.Ordem6Ideia;
                                            studentDTO.Ideia7Semestre1 = studentPollMath.Ordem7Ideia;
                                            studentDTO.Ideia8Semestre1 = studentPollMath.Ordem8Ideia;
                                            studentDTO.Resultado4Semestre1 = studentPollMath.Ordem4Resultado;
                                            studentDTO.Resultado6Semestre1 = studentPollMath.Ordem5Resultado;
                                            studentDTO.Resultado7Semestre1 = studentPollMath.Ordem6Resultado;
                                            studentDTO.Resultado5Semestre1 = studentPollMath.Ordem7Resultado;
                                            studentDTO.Resultado8Semestre1 = studentPollMath.Ordem8Resultado;
                                        }
                                    }
                                    else if (semestre.Equals(2))
                                    {
                                        if (studentPollMath.AnoTurma == (int)AnoTurmaEnum.SegundoAno)
                                        {
                                            studentDTO.Ideia3Semestre2 = studentPollMath.Ordem3Ideia;
                                            studentDTO.Resultado3Semestre2 = studentPollMath.Ordem3Resultado;
                                        }
                                        else
                                        {
                                            studentDTO.Ideia4Semestre2 = studentPollMath.Ordem4Ideia;
                                            studentDTO.Ideia5Semestre2 = studentPollMath.Ordem5Ideia;
                                            studentDTO.Ideia6Semestre2 = studentPollMath.Ordem6Ideia;
                                            studentDTO.Ideia7Semestre2 = studentPollMath.Ordem7Ideia;
                                            studentDTO.Ideia8Semestre2 = studentPollMath.Ordem8Ideia;
                                            studentDTO.Resultado4Semestre2 = studentPollMath.Ordem4Resultado;
                                            studentDTO.Resultado6Semestre2 = studentPollMath.Ordem5Resultado;
                                            studentDTO.Resultado7Semestre2 = studentPollMath.Ordem6Resultado;
                                            studentDTO.Resultado5Semestre2 = studentPollMath.Ordem7Resultado;
                                            studentDTO.Resultado8Semestre2 = studentPollMath.Ordem8Resultado;
                                        }
                                    }
                                }

                            }
                            else
                            {
                                AddEmptyCMPoolTo(studentDTO);
                            }

                            retornoSondagem.Add(studentDTO);
                        }
                    }
                }
                return retornoSondagem.OrderBy(r => Convert.ToInt32(r.NumeroAlunoChamada)).ToList();
            } catch (Exception)
            {
                throw;
            }
        }
         
        public async Task<PollReportMathResult> BuscarDadosRelatorioMatematicaAsync(string proficiency, string semestre, string anoLetivo, string codigoDre, string codigoEscola, string anoTurma)
        {
            if (proficiency.Equals("CM", StringComparison.InvariantCultureIgnoreCase))
            {
                return await BuscaDadosRelatorioMatCMAsync(semestre, anoLetivo, codigoDre, codigoEscola, anoTurma);
            } else if (proficiency.Equals("CA", StringComparison.InvariantCultureIgnoreCase))
            {
                return await BuscaDadosRelatorioMatCAAsync(semestre, anoLetivo, codigoDre, codigoEscola, anoTurma);
            } else if (proficiency.Equals("Numeros", StringComparison.InvariantCultureIgnoreCase))
            {
                return await BuscaDadosRelatorioMatNumeros(semestre, anoLetivo, codigoDre, codigoEscola, anoTurma);
            }

            return default;
        }

        private async Task<PollReportMathResult> BuscaDadosRelatorioMatNumeros(string semestre, string anoLetivo, string codigoDre, string codigoEscola, string anoTurma)
        {
            using (Contexts.SMEManagementContext db = new Contexts.SMEManagementContext())
            {
                IQueryable<MathPoolNumber> query = db.Set<MathPoolNumber>();
                var ideasAndResults = new PollReportMathItem();
                var relatorioRetorno = new PollReportMathResult();
                var ideaCharts = new List<MathIdeaChartDataModel>();
                var resultCharts = new List<MathResultChartDataModel>();

                query = db.MathPoolNumbers
                          .Where(x => x.AnoLetivo.ToString() == anoLetivo
                       && x.Semestre.ToString() == semestre);

                if (query.Count() > 1)
                {
                    query = MontaFiltrosGenericosNumeros(codigoDre, codigoEscola, anoTurma, query);

                    var familiaresAgrupados = query.GroupBy(fu => fu.Familiares)
                                            .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                            .ToList();
                    var opacosAgrupados = query.GroupBy(fu => fu.Opacos)
                                                .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                                .ToList();

                    var transparentesAgrupados = query.GroupBy(fu => fu.Transparentes)
                                            .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                            .ToList();
                    var terminamZeroAgrupados = query.GroupBy(fu => fu.TerminamZero)
                                                .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                                .ToList();

                    var algarismosAgrupados = query.GroupBy(fu => fu.Algarismos)
                                            .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                            .ToList();
                    var processoAgrupados = query.GroupBy(fu => fu.Processo)
                                                .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                                .ToList();

                    var zeroIntercaladosAgrupados = query.GroupBy(fu => fu.ZeroIntercalados)
                                            .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                            .ToList();

                    CreateNumberItem(familiaresAgrupados, grupo: "Familiares", ref relatorioRetorno, ref ideaCharts);
                    CreateNumberItem(opacosAgrupados, grupo: "Opacos", ref relatorioRetorno, ref ideaCharts);
                    CreateNumberItem(transparentesAgrupados, grupo: "Transparentes", ref relatorioRetorno, ref ideaCharts);
                    CreateNumberItem(terminamZeroAgrupados, grupo: "Terminam em zero", ref relatorioRetorno, ref ideaCharts);
                    CreateNumberItem(algarismosAgrupados, grupo: "Algarismos", ref relatorioRetorno, ref ideaCharts);
                    CreateNumberItem(processoAgrupados, grupo: "Processo de generalização", ref relatorioRetorno, ref ideaCharts);
                    CreateNumberItem(zeroIntercaladosAgrupados, grupo: "Zero intercalados", ref relatorioRetorno, ref ideaCharts);

                    relatorioRetorno.Results = ideasAndResults;
                    relatorioRetorno.ChartIdeaData.AddRange(ideaCharts);
                    relatorioRetorno.ChartResultData.AddRange(resultCharts);

                    return relatorioRetorno;
                }

                return default;
            }
        }

        private IQueryable<MathPoolNumber> MontaFiltrosGenericosNumeros(string codigoDre, string codigoEscola, string anoTurma, IQueryable<MathPoolNumber> query)
        {
            if (!string.IsNullOrWhiteSpace(codigoDre))
            {
                query = query.Where(u => u.DreEolCode == codigoDre);
            }

            if (!string.IsNullOrWhiteSpace(codigoEscola))
            {
                query = query.Where(u => u.EscolaEolCode == codigoEscola);
            }

            if (!string.IsNullOrWhiteSpace(anoTurma))
            {
                query = query.Where(u => u.AnoTurma.ToString() == anoTurma);
            }
          
            return query;
        }

        private async Task<PollReportMathResult> BuscaDadosRelatorioMatCMAsync(string semestre, string anoLetivo, string codigoDre, string codigoEscola, string anoTurmaParam)
        {
            var listReturn = new List<PollReportMathItem>();

            using (Contexts.SMEManagementContext db = new Contexts.SMEManagementContext())
            {
                IQueryable<MathPoolCM> query = db.Set<MathPoolCM>();
                var ideasAndResults = new PollReportMathItem();
                var relatorioRetorno = new PollReportMathResult();
                var ideaCharts = new List<MathIdeaChartDataModel>();
                var resultCharts = new List<MathResultChartDataModel>();
                var anoTurma = Convert.ToInt32(anoTurmaParam);

                query = db.MathPoolCMs
                          .Where(x => x.AnoLetivo.ToString() == anoLetivo
                       && x.Semestre.ToString() == semestre);

                if (query.Count() > 1)
                {
                    query = MontaFiltrosGenericosCM(codigoDre, codigoEscola, anoTurmaParam, query);

                    if (anoTurma == (int)AnoTurmaEnum.SegundoAno)
                    {
                        var ordem3IdeiaAgrupados = query.GroupBy(fu => fu.Ordem3Ideia)
                                            .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                            .ToList();
                        var ordem3ResultadoAgrupados = query.GroupBy(fu => fu.Ordem3Resultado)
                                                .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                                .ToList();

                        CreateIdeaItem(ordem3IdeiaAgrupados, order: "3", ref ideasAndResults, ref ideaCharts);
                        CreateResultItem(ordem3ResultadoAgrupados, order: "3", ref ideasAndResults, ref resultCharts);
                    }
                    else
                    {
                        var ordem4IdeiaAgrupados = query.GroupBy(fu => fu.Ordem4Ideia)
                                                .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                                .ToList();
                        var ordem4ResultadoAgrupados = query.GroupBy(fu => fu.Ordem4Resultado)
                                                    .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                                    .ToList();

                        var ordem5IdeiaAgrupados = query.GroupBy(fu => fu.Ordem5Ideia)
                                                .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                                .ToList();
                        var ordem5ResultadoAgrupados = query.GroupBy(fu => fu.Ordem5Resultado)
                                                    .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                                    .ToList();

                        var ordem6IdeiaAgrupados = query.GroupBy(fu => fu.Ordem6Ideia)
                                                .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                                .ToList();
                        var ordem6ResultadoAgrupados = query.GroupBy(fu => fu.Ordem6Resultado)
                                                    .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                                    .ToList();

                        var ordem7IdeiaAgrupados = query.GroupBy(fu => fu.Ordem7Ideia)
                                                .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                                .ToList();
                        var ordem7ResultadoAgrupados = query.GroupBy(fu => fu.Ordem7Resultado)
                                                    .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                                    .ToList();

                        var ordem8IdeiaAgrupados = query.GroupBy(fu => fu.Ordem8Ideia)
                                                .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                                .ToList();
                        var ordem8ResultadoAgrupados = query.GroupBy(fu => fu.Ordem8Resultado)
                                                    .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                                    .ToList();

                        CreateIdeaItem(ordem4IdeiaAgrupados, order: "4", ref ideasAndResults, ref ideaCharts);
                        CreateIdeaItem(ordem5IdeiaAgrupados, order: "5", ref ideasAndResults, ref ideaCharts);
                        CreateIdeaItem(ordem6IdeiaAgrupados, order: "6", ref ideasAndResults, ref ideaCharts);
                        CreateIdeaItem(ordem7IdeiaAgrupados, order: "7", ref ideasAndResults, ref ideaCharts);
                        CreateIdeaItem(ordem8IdeiaAgrupados, order: "8", ref ideasAndResults, ref ideaCharts);
                        CreateResultItem(ordem4ResultadoAgrupados, order: "4", ref ideasAndResults, ref resultCharts);
                        CreateResultItem(ordem5ResultadoAgrupados, order: "5", ref ideasAndResults, ref resultCharts);
                        CreateResultItem(ordem6ResultadoAgrupados, order: "6", ref ideasAndResults, ref resultCharts);
                        CreateResultItem(ordem7ResultadoAgrupados, order: "7", ref ideasAndResults, ref resultCharts);
                        CreateResultItem(ordem8ResultadoAgrupados, order: "8", ref ideasAndResults, ref resultCharts);
                    }

                    relatorioRetorno.Results = ideasAndResults;
                    relatorioRetorno.ChartIdeaData.AddRange(ideaCharts);
                    relatorioRetorno.ChartResultData.AddRange(resultCharts);

                    return relatorioRetorno;
                }

                return default;
            }
        }

        private IQueryable<MathPoolCM> MontaFiltrosGenericosCM(string codigoDre, string codigoEscola, string anoTurma, IQueryable<MathPoolCM> query)
        {
            if (!string.IsNullOrWhiteSpace(codigoDre))
            {
                query = query.Where(u => u.DreEolCode == codigoDre);
            }

            if (!string.IsNullOrWhiteSpace(codigoEscola))
            {
                query = query.Where(u => u.EscolaEolCode == codigoEscola);
            }

            if (!string.IsNullOrWhiteSpace(anoTurma))
            {
                query = query.Where(u => u.AnoTurma.ToString() == anoTurma);
            }

            return query;
        }

        private async Task<PollReportMathResult> BuscaDadosRelatorioMatCAAsync(string semestre, 
                                                                               string anoLetivo, 
                                                                               string codigoDre,
                                                                               string codigoEscola, 
                                                                               string anoTurmaParam)
        {
            var listReturn = new List<PollReportMathItem>();

            using (Contexts.SMEManagementContext db = new Contexts.SMEManagementContext())
            {
                IQueryable<MathPoolCA> query = db.Set<MathPoolCA>();
                var ideasAndResults = new PollReportMathItem();
                var relatorioRetorno = new PollReportMathResult();
                var ideaCharts = new List<MathIdeaChartDataModel>();
                var resultCharts = new List<MathResultChartDataModel>();
                var anoTurma = Convert.ToInt32(anoTurmaParam);

                query = db.MathPoolCAs
                          .Where(x => x.AnoLetivo.ToString() == anoLetivo
                       && x.Semestre.ToString() == semestre);

                if (query.Count() > 1)
                {
                    query = MontaFiltrosGenericosCA(codigoDre, codigoEscola, anoTurmaParam, query);

                    var ordem1Ideia = query.GroupBy(fu => fu.Ordem1Ideia)
                                            .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                            .ToList();
                    var ordem1Resultado = query.GroupBy(fu => fu.Ordem1Resultado)
                                                .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                                .ToList();

                    var ordem2Ideia = query.GroupBy(fu => fu.Ordem2Ideia)
                                            .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                            .ToList();
                    var ordem2Resultado = query.GroupBy(fu => fu.Ordem2Resultado)
                                                .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                                .ToList();

                    if (anoTurma != (int)AnoTurmaEnum.SegundoAno)
                    {
                        var ordem3Ideia = query.GroupBy(fu => fu.Ordem3Ideia)
                                            .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                            .ToList();
                        var ordem3Resultado = query.GroupBy(fu => fu.Ordem3Resultado)
                                                    .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                                    .ToList();

                        var ordem4Ideia = query.GroupBy(fu => fu.Ordem4Ideia)
                                                .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                                .ToList();
                        var ordem4Resultado = query.GroupBy(fu => fu.Ordem4Resultado)
                                                    .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                                    .ToList();

                        CreateIdeaItem(ordem3Ideia, order: "3", ref ideasAndResults, ref ideaCharts);
                        CreateIdeaItem(ordem4Ideia, order: "4", ref ideasAndResults, ref ideaCharts);
                        CreateResultItem(ordem3Resultado, order: "3", ref ideasAndResults, ref resultCharts);
                        CreateResultItem(ordem4Resultado, order: "4", ref ideasAndResults, ref resultCharts);
                    }                    

                    CreateIdeaItem(ordem1Ideia, order: "1", ref ideasAndResults, ref ideaCharts);
                    CreateIdeaItem(ordem2Ideia, order: "2", ref ideasAndResults, ref ideaCharts);
                    CreateResultItem(ordem1Resultado, order: "1", ref ideasAndResults, ref resultCharts);
                    CreateResultItem(ordem2Resultado, order: "2", ref ideasAndResults, ref resultCharts);

                    relatorioRetorno.Results = ideasAndResults;
                    relatorioRetorno.ChartIdeaData.AddRange(ideaCharts);
                    relatorioRetorno.ChartResultData.AddRange(resultCharts);

                    return relatorioRetorno;
                }

                return default;
            }
        }

        private static IQueryable<MathPoolCA> MontaFiltrosGenericosCA(string codigoDre, string codigoEscola, string anoTurma, IQueryable<MathPoolCA> query)
        {
            if (!string.IsNullOrWhiteSpace(codigoDre))
            {
                query = query.Where(u => u.DreEolCode == codigoDre);
            }

            if (!string.IsNullOrWhiteSpace(codigoEscola))
            {
                query = query.Where(u => u.EscolaEolCode == codigoEscola);
            }

            if (!string.IsNullOrWhiteSpace(anoTurma))
            {
                query = query.Where(u => u.AnoTurma.ToString() == anoTurma);
            }

            return query;
        }

        private void CreateIdeaItem(List<MathGroupByDTO> ordemIdeia, 
                                    string order, 
                                    ref PollReportMathItem ideasAndResults, 
                                    ref List<MathIdeaChartDataModel> ideaCharts)
        {
            var ideaResults = new List<IdeaChartDTO>();
            var ideaRetorno = new MathItemIdea();
            var ideaChart = new MathIdeaChartDataModel();

            foreach (var item in ordemIdeia)
            {
                if (!item.Label.Trim().Equals(""))
                {
                    if (item.Label.Equals("A", StringComparison.InvariantCultureIgnoreCase))
                    {
                        ideaRetorno.CorrectIdeaQuantity = item.Value;
                    }
                    else if (item.Label.Equals("E", StringComparison.InvariantCultureIgnoreCase))
                    {
                        ideaRetorno.IncorrectIdeaQuantity = item.Value;
                    }
                    else if (item.Label.Equals("NR", StringComparison.InvariantCultureIgnoreCase))
                    {
                        ideaRetorno.NotAnsweredIdeaQuantity = item.Value;
                    }
                }
            }

            var ideaTotalStudents = ideaRetorno.CorrectIdeaQuantity + ideaRetorno.IncorrectIdeaQuantity + ideaRetorno.NotAnsweredIdeaQuantity;

            if (ideaTotalStudents < 1)
            {
                ideaRetorno.CorrectIdeaPercentage = 0;
                ideaRetorno.IncorrectIdeaPercentage = 0;
                ideaRetorno.NotAnsweredIdeaPercentage = 0;
            } else
            {
                ideaRetorno.CorrectIdeaPercentage = (ideaRetorno.CorrectIdeaQuantity / ideaTotalStudents) * 100;
                ideaRetorno.IncorrectIdeaPercentage = (ideaRetorno.IncorrectIdeaQuantity / ideaTotalStudents) * 100;
                ideaRetorno.NotAnsweredIdeaPercentage = (ideaRetorno.NotAnsweredIdeaQuantity / ideaTotalStudents) * 100;
            }
            ideaRetorno.OrderName = order;

            ideasAndResults.IdeaResults.Add(ideaRetorno);
            ideaResults.Add(new IdeaChartDTO() { Description = "Acertou", Quantity = ideaRetorno.CorrectIdeaQuantity });
            ideaResults.Add(new IdeaChartDTO() { Description = "Errou", Quantity = ideaRetorno.IncorrectIdeaQuantity });
            ideaResults.Add(new IdeaChartDTO() { Description = "Não Resolveu", Quantity = ideaRetorno.NotAnsweredIdeaQuantity });

            ideaChart.Order = order;
            ideaChart.Idea.AddRange(ideaResults);
            ideaCharts.Add(ideaChart);
        }

        private void CreateResultItem(List<MathGroupByDTO> ordemResult, 
                                      string order, 
                                      ref PollReportMathItem ideasAndResults,
                                      ref List<MathResultChartDataModel> resultCharts)
        {
            var resultRetorno = new MathItemResult();
            var resultResults = new List<ResultChartDTO>();
            var resultChart = new MathResultChartDataModel();

            foreach (var item in ordemResult)
            {
                if (!item.Label.Trim().Equals(""))
                {
                    if (item.Label.Equals("A"))
                    {
                        resultRetorno.CorrectResultQuantity = item.Value;
                    }
                    else if (item.Label.Equals("E"))
                    {
                        resultRetorno.IncorrectResultQuantity = item.Value;
                    }
                    else if (item.Label.Equals("NR"))
                    {
                        resultRetorno.NotAnsweredResultQuantity = item.Value;
                    }
                }
            }

            var ideaTotalStudents = resultRetorno.CorrectResultQuantity + resultRetorno.IncorrectResultQuantity + resultRetorno.NotAnsweredResultQuantity;

            resultRetorno.CorrectResultPercentage = (resultRetorno.CorrectResultQuantity / ideaTotalStudents) * 100;
            resultRetorno.IncorrectResultPercentage = (resultRetorno.IncorrectResultQuantity / ideaTotalStudents) * 100;
            resultRetorno.NotAnsweredResultPercentage = (resultRetorno.NotAnsweredResultQuantity / ideaTotalStudents) * 100;
            resultRetorno.OrderName = order;

            ideasAndResults.ResultResults.Add(resultRetorno);
            resultResults.Add(new ResultChartDTO() { Description = "Acertou", Quantity = resultRetorno.CorrectResultQuantity });
            resultResults.Add(new ResultChartDTO() { Description = "Errou", Quantity = resultRetorno.IncorrectResultQuantity });
            resultResults.Add(new ResultChartDTO() { Description = "Não Resolveu", Quantity = resultRetorno.NotAnsweredResultQuantity });

            resultChart.Order = order;
            resultChart.Result.AddRange(resultResults);
            resultCharts.Add(resultChart);
        }


        private void CreateNumberItem(List<MathGroupByDTO> ordemIdeia,
                                  string grupo,
                                  ref PollReportMathResult ideasAndResults,
                                  ref List<MathIdeaChartDataModel> ideaCharts)
        {
            var ideaResults = new List<IdeaChartDTO>();
            var numberRetorno = new MathNumberResult();
            var ideaChart = new MathIdeaChartDataModel();

            foreach (var item in ordemIdeia)
            {
                if (!item.Label.Trim().Equals(""))
                {
                    if (item.Label.Equals("S", StringComparison.InvariantCultureIgnoreCase))
                    {
                        numberRetorno.EscreveConvencionalmenteResultado = item.Value;
                    }
                    else if (item.Label.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                    {
                        numberRetorno.NaoEscreveConvencionalmenteResultado = item.Value;
                    }                
                }
            }

            var ideaTotalStudents = numberRetorno.EscreveConvencionalmenteResultado + numberRetorno.NaoEscreveConvencionalmenteResultado ;

            if (ideaTotalStudents > 0)
            {
                numberRetorno.EscreveConvencionalmentePercentage = (numberRetorno.EscreveConvencionalmenteResultado / ideaTotalStudents) * 100;
                numberRetorno.NaoEscreveConvencionalmentePercentage = (numberRetorno.NaoEscreveConvencionalmenteResultado / ideaTotalStudents) * 100;
            } else
            {
                numberRetorno.EscreveConvencionalmentePercentage = 0;
                numberRetorno.NaoEscreveConvencionalmentePercentage = 0;
            }
            
            numberRetorno.GroupName = grupo;

            ideasAndResults.Results.NumerosResults.Add(numberRetorno);
            ideaResults.Add(new IdeaChartDTO() { Description = "Escreve convencionalmente", Quantity = numberRetorno.EscreveConvencionalmenteResultado});
            ideaResults.Add(new IdeaChartDTO() { Description = "Não escreve convencionalmente", Quantity = numberRetorno.NaoEscreveConvencionalmenteResultado });
         
            ideaChart.Order = grupo;
            ideaChart.Idea.AddRange(ideaResults);
            ideaCharts.Add(ideaChart);
        }

        public async Task<List<SondagemMatematicaOrdemDTO>> ListPoolCAAsync(FiltroSondagemMatematicaDTO filtroSondagem)
        {
            try
            {
                var retornoSondagem = new List<SondagemMatematicaOrdemDTO>();

                using (Contexts.SMEManagementContext db = new Contexts.SMEManagementContext())
                {
                    var sondagemDaTurma = db.MathPoolCAs
                                            .Where(x => x.TurmaEolCode.Equals(filtroSondagem.TurmaEolCode))
                                            .ToList();


                    var turmApi = new TurmasAPI(new EndpointsAPI());

                    var classroomStudentsFromAPI = await turmApi.GetAlunosNaTurma(Convert.ToInt32(filtroSondagem.TurmaEolCode), Convert.ToInt32(filtroSondagem.AnoLetivo), _token);

                    classroomStudentsFromAPI = classroomStudentsFromAPI.Where(x => x.CodigoSituacaoMatricula == 1).ToList();
                    if (classroomStudentsFromAPI == null)
                    {
                        return null;
                    }

                    foreach (var studentClassRoom in classroomStudentsFromAPI)
                    {
                        var studentDTO = new SondagemMatematicaOrdemDTO();
                        if (sondagemDaTurma != null)
                        {
                            var studentPollsMath = sondagemDaTurma.Where(x => x.AlunoEolCode == studentClassRoom.CodigoAluno.ToString()).ToList();
                            studentDTO.NomeAluno = studentClassRoom.NomeAluno;
                            studentDTO.CodigoEolAluno = studentClassRoom.CodigoAluno.ToString();
                            studentDTO.NumeroAlunoChamada = studentClassRoom.NumeroAlunoChamada.ToString();
                            studentDTO.AnoLetivo = filtroSondagem.AnoLetivo;
                            studentDTO.CodigoEolDRE = filtroSondagem.DreEolCode;
                            studentDTO.CodigoEolEscola = filtroSondagem.EscolaEolCode;
                            studentDTO.AnoTurma = filtroSondagem.AnoTurma;
                            studentDTO.CodigoEolTurma = filtroSondagem.TurmaEolCode;

                            if (studentPollsMath?.Count > 0)
                            {
                                for (int semestre = 1; semestre <= 2; semestre++)
                                {
                                    var studentPollMath = studentPollsMath
                                                            .Where(s => s.Semestre == semestre)
                                                            .FirstOrDefault();

                                    if (semestre.Equals(1))
                                    {
                                        studentDTO.Ideia1Semestre1 = studentPollMath.Ordem1Ideia;
                                        studentDTO.Ideia2Semestre1 = studentPollMath.Ordem2Ideia;
                                        studentDTO.Resultado1Semestre1 = studentPollMath.Ordem1Resultado;
                                        studentDTO.Resultado2Semestre1 = studentPollMath.Ordem2Resultado;

                                        if (studentPollMath.AnoTurma != (int)AnoTurmaEnum.SegundoAno)
                                        {
                                            studentDTO.Resultado3Semestre1 = studentPollMath.Ordem3Resultado;
                                            studentDTO.Resultado4Semestre1 = studentPollMath.Ordem4Resultado;
                                            studentDTO.Ideia3Semestre1 = studentPollMath.Ordem3Ideia;
                                            studentDTO.Ideia4Semestre1 = studentPollMath.Ordem4Ideia;
                                        }
                                    }
                                    else if (semestre.Equals(2))
                                    {
                                        studentDTO.Ideia1Semestre2 = studentPollMath.Ordem1Ideia;
                                        studentDTO.Ideia2Semestre2 = studentPollMath.Ordem2Ideia;
                                        studentDTO.Resultado1Semestre2 = studentPollMath.Ordem1Resultado;
                                        studentDTO.Resultado2Semestre2 = studentPollMath.Ordem2Resultado;

                                        if (studentPollMath.AnoTurma != (int)AnoTurmaEnum.SegundoAno)
                                        {
                                            studentDTO.Resultado3Semestre2 = studentPollMath.Ordem3Resultado;
                                            studentDTO.Resultado4Semestre2 = studentPollMath.Ordem4Resultado;
                                            studentDTO.Ideia3Semestre2 = studentPollMath.Ordem3Ideia;
                                            studentDTO.Ideia4Semestre2 = studentPollMath.Ordem4Ideia;
                                        }
                                    }
                                }

                            }
                            else
                            {
                                AddEmptyCAPoolTo(studentDTO);
                            }

                            retornoSondagem.Add(studentDTO);
                        }
                    }
                }
                return retornoSondagem.OrderBy(r => Convert.ToInt32(r.NumeroAlunoChamada)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SondagemMatematicaNumerosDTO>> ListPoolNumerosAsync(FiltroSondagemMatematicaDTO filtroSondagem)
        {
            try
            {
                var retornoSondagem = new List<SondagemMatematicaNumerosDTO>();

                using (Contexts.SMEManagementContext db = new Contexts.SMEManagementContext())
                {
                    var sondagemDaTurma = db.MathPoolNumbers
                                            .Where(x => x.TurmaEolCode.Equals(filtroSondagem.TurmaEolCode))
                                            .ToList();


                    var turmApi = new TurmasAPI(new EndpointsAPI());

                    var classroomStudentsFromAPI = await turmApi.GetAlunosNaTurma(Convert.ToInt32(filtroSondagem.TurmaEolCode), Convert.ToInt32(filtroSondagem.AnoLetivo), _token);

                    classroomStudentsFromAPI = classroomStudentsFromAPI.Where(x => x.CodigoSituacaoMatricula == 1).ToList();
                    if (classroomStudentsFromAPI == null)
                    {
                        return null;
                    }

                    foreach (var studentClassRoom in classroomStudentsFromAPI)
                    {
                        var studentDTO = new SondagemMatematicaNumerosDTO();
                        if (sondagemDaTurma != null)
                        {
                            var studentPollsMath = sondagemDaTurma.Where(x => x.AlunoEolCode == studentClassRoom.CodigoAluno.ToString()).ToList();
                            studentDTO.NomeAluno = studentClassRoom.NomeAluno;
                            studentDTO.CodigoEolAluno = studentClassRoom.CodigoAluno.ToString();
                            studentDTO.NumeroAlunoChamada = studentClassRoom.NumeroAlunoChamada.ToString();
                            studentDTO.AnoLetivo = filtroSondagem.AnoLetivo;
                            studentDTO.CodigoEolDRE = filtroSondagem.DreEolCode;
                            studentDTO.CodigoEolEscola = filtroSondagem.EscolaEolCode;
                            studentDTO.AnoTurma = filtroSondagem.AnoTurma;
                            studentDTO.CodigoEolTurma = filtroSondagem.TurmaEolCode;

                            if (studentPollsMath?.Count > 0)
                            {
                                for (int semestre = 1; semestre <= 2; semestre++)
                                {
                                    var studentPollMath = studentPollsMath
                                                            .Where(s => s.Semestre == semestre)
                                                            .FirstOrDefault();

                                    if (semestre.Equals(1))
                                    {
                                        studentDTO.Familiares1S = studentPollMath.Familiares;
                                        studentDTO.Opacos1S = studentPollMath.Opacos;
                                        studentDTO.Processo1S = studentPollMath.Processo;
                                        studentDTO.TerminamZero1S = studentPollMath.TerminamZero;
                                        studentDTO.Transparentes1S = studentPollMath.Transparentes;
                                        studentDTO.ZeroIntercalados1S = studentPollMath.ZeroIntercalados;
                                        studentDTO.Algarismos1S = studentPollMath.Algarismos;
                                    }
                                    else if (semestre.Equals(2))
                                    {
                                        studentDTO.Familiares2S = studentPollMath.Familiares;
                                        studentDTO.Opacos2S = studentPollMath.Opacos;
                                        studentDTO.Processo2S = studentPollMath.Processo;
                                        studentDTO.TerminamZero2S = studentPollMath.TerminamZero;
                                        studentDTO.Transparentes2S = studentPollMath.Transparentes;
                                        studentDTO.ZeroIntercalados2S = studentPollMath.ZeroIntercalados;
                                        studentDTO.Algarismos2S = studentPollMath.Algarismos;
                                    }
                                }

                            }
                            else
                            {
                                AddEmptyNumberPoolTo(studentDTO);
                            }

                            retornoSondagem.Add(studentDTO);
                        }
                    }
                }
                return retornoSondagem.OrderBy(r => Convert.ToInt32(r.NumeroAlunoChamada)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void AddEmptyNumberPoolTo(SondagemMatematicaNumerosDTO studentDTO)
        {
            studentDTO.Familiares1S = string.Empty;
            studentDTO.Opacos1S = string.Empty;
            studentDTO.Processo1S = string.Empty;
            studentDTO.TerminamZero1S = string.Empty;
            studentDTO.Transparentes1S = string.Empty;
            studentDTO.ZeroIntercalados1S = string.Empty;
            studentDTO.Algarismos1S = string.Empty;
            studentDTO.Familiares2S = string.Empty;
            studentDTO.Opacos2S = string.Empty;
            studentDTO.Processo2S = string.Empty;
            studentDTO.TerminamZero2S = string.Empty;
            studentDTO.Transparentes2S = string.Empty;
            studentDTO.ZeroIntercalados2S = string.Empty;
            studentDTO.Algarismos2S = string.Empty;
        }

        private void AddEmptyCAPoolTo(SondagemMatematicaOrdemDTO studentDTO)
        {
            var anoTurma = Convert.ToInt32(studentDTO.AnoTurma);

            studentDTO.Ideia1Semestre1 = string.Empty;
            studentDTO.Ideia2Semestre1 = string.Empty;
            studentDTO.Resultado1Semestre1 = string.Empty;
            studentDTO.Resultado2Semestre1 = string.Empty;
            studentDTO.Ideia1Semestre2 = string.Empty;
            studentDTO.Ideia2Semestre2 = string.Empty;
            studentDTO.Resultado1Semestre2 = string.Empty;
            studentDTO.Resultado2Semestre2 = string.Empty;

            if (anoTurma != (int)AnoTurmaEnum.SegundoAno)
            {
                studentDTO.Ideia3Semestre1 = string.Empty;
                studentDTO.Ideia4Semestre1 = string.Empty;
                studentDTO.Ideia3Semestre2 = string.Empty;
                studentDTO.Ideia4Semestre2 = string.Empty;
                studentDTO.Resultado3Semestre1 = string.Empty;
                studentDTO.Resultado4Semestre1 = string.Empty;
                studentDTO.Resultado3Semestre2 = string.Empty;
                studentDTO.Resultado4Semestre2 = string.Empty;
            }
        }

        private void AddEmptyCMPoolTo(SondagemMatematicaOrdemDTO studentDTO)
        {
            var anoTurma = Convert.ToInt32(studentDTO.AnoTurma);

            if (anoTurma == (int)AnoTurmaEnum.SegundoAno)
            {
                studentDTO.Ideia3Semestre1 = string.Empty;
                studentDTO.Ideia3Semestre2 = string.Empty;
                studentDTO.Resultado3Semestre1 = string.Empty;
                studentDTO.Resultado3Semestre2 = string.Empty;
            }
            else
            {
                studentDTO.Ideia4Semestre1 = string.Empty;
                studentDTO.Ideia5Semestre1 = string.Empty;
                studentDTO.Ideia6Semestre1 = string.Empty;
                studentDTO.Ideia7Semestre1 = string.Empty;
                studentDTO.Ideia8Semestre1 = string.Empty;
                studentDTO.Resultado4Semestre1 = string.Empty;
                studentDTO.Resultado6Semestre1 = string.Empty;
                studentDTO.Resultado7Semestre1 = string.Empty;
                studentDTO.Resultado5Semestre1 = string.Empty;
                studentDTO.Resultado8Semestre1 = string.Empty;
                studentDTO.Ideia5Semestre2 = string.Empty;
                studentDTO.Ideia4Semestre2 = string.Empty;
                studentDTO.Ideia6Semestre2 = string.Empty;
                studentDTO.Ideia7Semestre2 = string.Empty;
                studentDTO.Ideia8Semestre2 = string.Empty;
                studentDTO.Resultado4Semestre2 = string.Empty;
                studentDTO.Resultado6Semestre2 = string.Empty;
                studentDTO.Resultado7Semestre2 = string.Empty;
                studentDTO.Resultado5Semestre2 = string.Empty;
                studentDTO.Resultado8Semestre2 = string.Empty;
            }
        }

        public async Task InsertPoolNumerosAsync(List<SondagemMatematicaNumerosDTO> dadosSondagem)
        {
            using (Contexts.SMEManagementContext db = new Contexts.SMEManagementContext())
            {
                foreach (var student in dadosSondagem)
                {
                    for (int semestre = 1; semestre <= 2; semestre++)
                    {
                        var studentPoolNumeros = db.MathPoolNumbers.Where(x =>
                                                                            x.TurmaEolCode == student.CodigoEolTurma &&
                                                                             x.AlunoEolCode == student.CodigoEolAluno &&
                                                                             x.Semestre == semestre).FirstOrDefault();

                        if (studentPoolNumeros == null)
                        {
                            var newStudentPoolNumeros = new MathPoolNumber();
                            newStudentPoolNumeros.AlunoEolCode = student.CodigoEolAluno;
                            newStudentPoolNumeros.DreEolCode = student.CodigoEolDRE;
                            newStudentPoolNumeros.EscolaEolCode = student.CodigoEolEscola;
                            newStudentPoolNumeros.AnoTurma = Convert.ToInt32(student.AnoTurma);
                            newStudentPoolNumeros.TurmaEolCode = student.CodigoEolTurma;
                            newStudentPoolNumeros.AnoLetivo = Convert.ToInt32(student.AnoLetivo);
                            newStudentPoolNumeros.Semestre = semestre;

                            MapValuesPoolNumbers(student, ref newStudentPoolNumeros);
                            await db.MathPoolNumbers.AddAsync(newStudentPoolNumeros);
                        }
                        else
                        {

                            MapValuesPoolNumbers(student, ref studentPoolNumeros);
                            db.MathPoolNumbers.Update(studentPoolNumeros);
                        }
                    }
                }

                await db.SaveChangesAsync();
            }
        }

        private void MapValuesPoolNumbers(SondagemMatematicaNumerosDTO studentDTO, ref MathPoolNumber studentPoolNumeros)
        {
            if (studentPoolNumeros.Semestre == 1)
            {
                studentPoolNumeros.Familiares = studentDTO.Familiares1S;
                studentPoolNumeros.Opacos = studentDTO.Opacos1S;
                studentPoolNumeros.Transparentes = studentDTO.Transparentes1S;
                studentPoolNumeros.TerminamZero = studentDTO.TerminamZero1S;
                studentPoolNumeros.Algarismos = studentDTO.Algarismos1S;
                studentPoolNumeros.Processo = studentDTO.Processo1S;
                studentPoolNumeros.ZeroIntercalados = studentDTO.ZeroIntercalados1S;
            }
            else if (studentPoolNumeros.Semestre == 2)
            {
                studentPoolNumeros.Familiares = studentDTO.Familiares2S;
                studentPoolNumeros.Opacos = studentDTO.Opacos2S;
                studentPoolNumeros.Transparentes = studentDTO.Transparentes2S;
                studentPoolNumeros.TerminamZero = studentDTO.TerminamZero2S;
                studentPoolNumeros.Algarismos = studentDTO.Algarismos2S;
                studentPoolNumeros.Processo = studentDTO.Processo2S;
                studentPoolNumeros.ZeroIntercalados = studentDTO.ZeroIntercalados2S;
            }
        }

        public async Task InsertPoolCAAsync(List<SondagemMatematicaOrdemDTO> dadosSondagem)
        {
            using (Contexts.SMEManagementContext db = new Contexts.SMEManagementContext())
            {
                foreach (var student in dadosSondagem)
                {
                    for (int semestre = 1; semestre <= 2; semestre++)
                    {
                        var studentPoolCA = db.MathPoolCAs.Where(x =>
                                                                x.TurmaEolCode == student.CodigoEolTurma &&
                                                                 x.AlunoEolCode == student.CodigoEolAluno &&
                                                                 x.Semestre == semestre).FirstOrDefault();

                        if (studentPoolCA == null)
                        {
                            var newStudentPoolCA = new MathPoolCA();
                            newStudentPoolCA.AlunoEolCode = student.CodigoEolAluno;
                            newStudentPoolCA.DreEolCode = student.CodigoEolDRE;
                            newStudentPoolCA.EscolaEolCode = student.CodigoEolEscola;
                            newStudentPoolCA.AnoTurma = Convert.ToInt32(student.AnoTurma);
                            newStudentPoolCA.TurmaEolCode = student.CodigoEolTurma;
                            newStudentPoolCA.AnoLetivo = Convert.ToInt32(student.AnoLetivo);
                            newStudentPoolCA.Semestre = semestre;

                            MapValuesPoolCA(student, ref newStudentPoolCA);
                            await db.MathPoolCAs.AddAsync(newStudentPoolCA);
                        }
                        else
                        {
                            MapValuesPoolCA(student, ref studentPoolCA);
                            db.MathPoolCAs.Update(studentPoolCA);
                        }
                    }
                }

                await db.SaveChangesAsync();
            }
        }

        private void MapValuesPoolCA(SondagemMatematicaOrdemDTO studentDTO, ref MathPoolCA studentPoolCA)
        {
            if (studentPoolCA.Semestre == 1)
            {
                studentPoolCA.Ordem1Ideia = studentDTO.Ideia1Semestre1;
                studentPoolCA.Ordem1Resultado = studentDTO.Resultado1Semestre1;
                studentPoolCA.Ordem2Ideia = studentDTO.Ideia2Semestre1;
                studentPoolCA.Ordem2Resultado = studentDTO.Resultado2Semestre1;

                if (studentPoolCA.AnoTurma != (int)AnoTurmaEnum.SegundoAno)
                {
                    studentPoolCA.Ordem3Ideia = studentDTO.Ideia3Semestre1;
                    studentPoolCA.Ordem3Resultado = studentDTO.Resultado3Semestre1;
                    studentPoolCA.Ordem4Ideia = studentDTO.Ideia4Semestre1;
                    studentPoolCA.Ordem4Resultado = studentDTO.Resultado4Semestre1;
                }
            }
            else if (studentPoolCA.Semestre == 2)
            {
                studentPoolCA.Ordem1Ideia = studentDTO.Ideia1Semestre2;
                studentPoolCA.Ordem1Resultado = studentDTO.Resultado1Semestre2;
                studentPoolCA.Ordem2Ideia = studentDTO.Ideia2Semestre2;
                studentPoolCA.Ordem2Resultado = studentDTO.Resultado2Semestre2;

                if (studentPoolCA.AnoTurma != (int)AnoTurmaEnum.SegundoAno)
                {
                    studentPoolCA.Ordem3Ideia = studentDTO.Ideia3Semestre2;
                    studentPoolCA.Ordem3Resultado = studentDTO.Resultado3Semestre2;
                    studentPoolCA.Ordem4Ideia = studentDTO.Ideia4Semestre2;
                    studentPoolCA.Ordem4Resultado = studentDTO.Resultado4Semestre2;
                }
            }
        }
    }
}
