using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using MoreLinq;
using SME.Pedagogico.Gestao.Data.Contexts;
using SME.Pedagogico.Gestao.Data.DataTransfer;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Data.DTO.Matematica;
using SME.Pedagogico.Gestao.Data.DTO.Portugues;
using SME.Pedagogico.Gestao.Data.Functionalities;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using SME.Pedagogico.Gestao.Infra;
using SME.Pedagogico.Gestao.Models.Academic;
using SME.Pedagogico.Gestao.Models.Autoral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SME.Pedagogico.Gestao.Data.DTO.Matematica.Relatorio;

namespace SME.Pedagogico.Gestao.Data.Business
{
    public class PollPortuguese
    {
        private AlunosAPI alunoAPI;
        IMapper _mapper;


        private string _token;

        public PollPortuguese(IConfiguration config)
        {
            var createToken = new CreateToken(config);
            _token = createToken.CreateTokenProvisorio();
            alunoAPI = new AlunosAPI(new EndpointsAPI());
        }

        public async void InsertPollPortuguese(List<StudentPollPortuguese> ListStudentsModel)
        {
            using (Contexts.SMEManagementContextData db = new Contexts.SMEManagementContextData())
            {
                var listStudentsPoll = new List<PortuguesePoll>();

                foreach (var student in ListStudentsModel)
                {
                    var studentPollPortuguese = db.PortuguesePolls.FirstOrDefault(x => x.classroomCodeEol == student.classroomCodeEol &&
                                                                                       x.studentCodeEol == student.studentCodeEol);

                    if (studentPollPortuguese == null)
                    {
                        studentPollPortuguese = new PortuguesePoll();

                        studentPollPortuguese.schoolYear = student.schoolYear;
                        studentPollPortuguese.dreCodeEol = student.dreCodeEol;
                        studentPollPortuguese.schoolCodeEol = student.schoolCodeEol;
                        studentPollPortuguese.yearClassroom = student.yearClassroom;
                        studentPollPortuguese.classroomCodeEol = student.classroomCodeEol;
                        studentPollPortuguese.studentNameEol = student.name;
                        studentPollPortuguese.studentCodeEol = student.studentCodeEol;
                        MapValuesPollPortuguese(student, studentPollPortuguese);
                        await db.PortuguesePolls.AddAsync(studentPollPortuguese);
                    }

                    else
                    {
                        MapValuesPollPortuguese(student, studentPollPortuguese);
                        db.PortuguesePolls.Update(studentPollPortuguese);
                    }
                }

                await db.SaveChangesAsync();
            }
        }

        private static void MapValuesPollPortuguese(StudentPollPortuguese student, PortuguesePoll studentPollPortuguese)
        {
            studentPollPortuguese.writing1B = student.t1e;
            studentPollPortuguese.reading1B = student.t1l;
            studentPollPortuguese.writing2B = student.t2e;
            studentPollPortuguese.reading2B = student.t2l;
            studentPollPortuguese.writing3B = student.t3e;
            studentPollPortuguese.reading3B = student.t3l;
            studentPollPortuguese.writing4B = student.t4e;
            studentPollPortuguese.reading4B = student.t4l;
        }

        public async Task<List<StudentPollPortuguese>> ListStudentPollPortuguese(ClassRoomFilter classRoom)
        {
            var liststudentPollPortuguese = new List<StudentPollPortuguese>();
            using (var db = new Contexts.SMEManagementContextData())
            {
                //Pega alunos daquela turma que possuem sondagem 
                // ADD ano letivo no where
                var listStudentsPollPortuguese = db.PortuguesePolls.Where(x => x.classroomCodeEol == classRoom.classroomCodeEol).ToList();

                // Pega alunos da API 
                // tratar se ppor um acaso retornar uma lista vazia 
                var studentsClassRoom = new ClassRoom();
                // var listStudentsClassRoom = studentsClassRoom.MockListaChamada();
                var endpointsAPI = new EndpointsAPI();

                var turmApi = new TurmasAPI(endpointsAPI);

                var listStudentsClassRoom_all_bimesters = await ObterAlunosAtivosTurmaTodosBimestres(classRoom.classroomCodeEol, int.Parse(classRoom.schoolYear));
                var listStudentsClassRoom = FiltrarAlunosAtivosBimestre(listStudentsClassRoom_all_bimesters, 0);

                foreach (var studentClassRoom in listStudentsClassRoom)
                {
                    var studentDTO = new StudentPollPortuguese();
                    if (listStudentsPollPortuguese != null)
                    {
                        var studentPollPortuguese = listStudentsPollPortuguese.Where(x => x.studentCodeEol == studentClassRoom.CodigoAluno.ToString()).FirstOrDefault();
                        studentDTO.name = studentClassRoom.NomeAluno;
                        studentDTO.studentCodeEol = studentClassRoom.CodigoAluno.ToString();
                        studentDTO.sequenceNumber = studentClassRoom.NumeroAlunoChamada.ToString();
                        studentDTO.classroomCodeEol = classRoom.classroomCodeEol;
                        studentDTO.schoolYear = classRoom.schoolYear;
                        studentDTO.dreCodeEol = classRoom.dreCodeEol;
                        studentDTO.schoolCodeEol = classRoom.schoolCodeEol;
                        studentDTO.yearClassroom = classRoom.yearClassroom;
                        studentDTO.ativoB1 = FiltrarAlunosAtivosBimestre(listStudentsClassRoom_all_bimesters, 1).Any(aa => aa.CodigoAluno.Equals(studentClassRoom.CodigoAluno));
                        studentDTO.ativoB2 = FiltrarAlunosAtivosBimestre(listStudentsClassRoom_all_bimesters, 2).Any(aa => aa.CodigoAluno.Equals(studentClassRoom.CodigoAluno));
                        studentDTO.ativoB3 = FiltrarAlunosAtivosBimestre(listStudentsClassRoom_all_bimesters, 3).Any(aa => aa.CodigoAluno.Equals(studentClassRoom.CodigoAluno));
                        studentDTO.ativoB4 = FiltrarAlunosAtivosBimestre(listStudentsClassRoom_all_bimesters, 4).Any(aa => aa.CodigoAluno.Equals(studentClassRoom.CodigoAluno));

                        if (studentPollPortuguese != null)
                        {
                            studentDTO.t1e = studentPollPortuguese.writing1B;
                            studentDTO.t1l = studentPollPortuguese.reading1B;
                            studentDTO.t2e = studentPollPortuguese.writing2B;
                            studentDTO.t2l = studentPollPortuguese.reading2B;
                            studentDTO.t3e = studentPollPortuguese.writing3B;
                            studentDTO.t3l = studentPollPortuguese.reading3B;
                            studentDTO.t4e = studentPollPortuguese.writing4B;
                            studentDTO.t4l = studentPollPortuguese.reading4B;
                        }

                        else
                        {
                            AddStudentPollPortuguese(studentDTO);
                        }

                        liststudentPollPortuguese.Add(studentDTO);
                    }
                }
            }

            return liststudentPollPortuguese.OrderBy(x => Convert.ToInt32(x.sequenceNumber)).ToList();
        }

        private IEnumerable<AlunosNaTurmaDTO> FiltrarAlunosAtivosBimestre(List<(int bimestre, IEnumerable<AlunosNaTurmaDTO> alunos)> alunosBimestre, int bimestre)
        => alunosBimestre.Where(std => std.bimestre == bimestre).FirstOrDefault().alunos ?? Enumerable.Empty<AlunosNaTurmaDTO>();
        
        private async Task<List<(int bimestre, IEnumerable<AlunosNaTurmaDTO> alunos)>> ObterAlunosAtivosTurmaTodosBimestres(string turmaCodigo, int anoLetivo)
        {
            var alunosBimestre = new List<(int bimestre, IEnumerable<AlunosNaTurmaDTO>)>();
            var alunos = new List<AlunosNaTurmaDTO>();
            for (int bimestre = 1; bimestre <= 4; bimestre++)
            {
                var periodo = await ObterPeriodoRelatorioPorDescricao($"{bimestre}° Bimestre");
                if (periodo is null)
                    continue;
                var periodoFixoAnual = await ObterPeriodoFixoAnual(periodo, anoLetivo);
                if (periodoFixoAnual is null)
                    continue;

                if (DateTime.Now.Date < periodoFixoAnual.DataFim
                    && alunosBimestre.Any())
                {
                    var bimestreAnterior = bimestre - 1;
                    alunosBimestre.Add((bimestre, FiltrarAlunosAtivosBimestre(alunosBimestre, bimestreAnterior)));
                }
                else
                {
                    var alunosAtivosPeriodo = await alunoAPI.ObterAlunosAtivosPorTurmaEPeriodo(turmaCodigo, periodoFixoAnual.DataFim, periodoFixoAnual.DataInicio);
                    alunosBimestre.Add((bimestre, alunosAtivosPeriodo));
                    alunos.AddRange(alunosAtivosPeriodo.Where(ap => !alunos.Any(aa => aa.CodigoAluno.Equals(ap.CodigoAluno))));
                }
            }
            alunosBimestre.Add((0, alunos));
            return alunosBimestre;
        }

        private static void AddStudentPollPortuguese(StudentPollPortuguese studentDTO)
        {
            studentDTO.t1e = string.Empty;
            studentDTO.t1l = string.Empty;
            studentDTO.t2e = string.Empty;
            studentDTO.t2l = string.Empty;
            studentDTO.t3e = string.Empty;
            studentDTO.t3l = string.Empty;
            studentDTO.t4e = string.Empty;
            studentDTO.t4l = string.Empty;
        }

        public async Task<List<PortuguesePoll>> BuscarAlunosTurmaRelatorioPortugues(string turmaEol, string proficiencia, string bimestre, Periodo periodo, int anoLetivo, string codigoDre, string codigoUe, string anoTurma)
        {
            var liststudentPollPortuguese = new List<StudentPollPortuguese>();
            PeriodoFixoAnual periodoFixoAnual = null;

            using (Contexts.SMEManagementContextData db = new Contexts.SMEManagementContextData())
            {
                periodoFixoAnual = await ObterPeriodoFixoAnual(periodo, anoLetivo, periodoFixoAnual, db);

                var listStudentsPollPortuguese = new List<PortuguesePoll>();
                switch (bimestre)
                {
                    case "1° Bimestre":
                    {
                        if (proficiencia == "Escrita")
                        {
                            listStudentsPollPortuguese = db.PortuguesePolls
                                .Where(x => x.classroomCodeEol == turmaEol && !
                                    string.IsNullOrEmpty(x.writing1B)).ToList();
                        }
                        else
                        {
                            listStudentsPollPortuguese = db.PortuguesePolls.Where(x => x.classroomCodeEol == turmaEol && !string.IsNullOrEmpty(x.reading1B)).ToList();
                        }

                        break;
                    }
                    case "2° Bimestre":
                    {
                        if (proficiencia == "Escrita")
                        {
                            listStudentsPollPortuguese = db.PortuguesePolls.Where(x => x.classroomCodeEol == turmaEol && !string.IsNullOrEmpty(x.writing2B)).ToList();
                        }
                        else
                        {
                            listStudentsPollPortuguese = db.PortuguesePolls.Where(x => x.classroomCodeEol == turmaEol && !string.IsNullOrEmpty(x.reading2B)).ToList();
                        }

                        break;
                    }
                    case "3° Bimestre":
                    {
                        if (proficiencia == "Escrita")
                        {
                            listStudentsPollPortuguese = db.PortuguesePolls.Where(x => x.classroomCodeEol == turmaEol && !string.IsNullOrEmpty(x.writing3B)).ToList();
                        }
                        else
                        {
                            listStudentsPollPortuguese = db.PortuguesePolls.Where(x => x.classroomCodeEol == turmaEol && !string.IsNullOrEmpty(x.reading3B)).ToList();
                        }

                        break;
                    }
                    default:
                        if (proficiencia == "Escrita")
                        {
                            listStudentsPollPortuguese = db.PortuguesePolls.Where(x => x.classroomCodeEol == turmaEol && !string.IsNullOrEmpty(x.writing4B)).ToList();
                        }
                        else
                        {
                            listStudentsPollPortuguese = db.PortuguesePolls.Where(x => x.classroomCodeEol == turmaEol && !string.IsNullOrEmpty(x.reading4B)).ToList();
                        }

                        break;
                }

                var alunos = await alunoAPI.ObterAlunosAtivosPorTurmaEPeriodo(turmaEol, periodoFixoAnual.DataFim);

                if (alunos == null || !alunos.Any())
                    throw new Exception("Não encontrado alunos para a turma informda");

                alunos.ForEach(aluno =>
                {
                    if (listStudentsPollPortuguese.Any(x => x.studentCodeEol.Equals(aluno.CodigoAluno.ToString())))
                        return;

                    listStudentsPollPortuguese.Add(new PortuguesePoll
                    {
                        classroomCodeEol = turmaEol,
                        dreCodeEol = codigoDre,
                        schoolCodeEol = codigoUe,
                        schoolYear = anoLetivo.ToString(),
                        yearClassroom = anoTurma,
                        studentCodeEol = aluno.CodigoAluno.ToString(),
                        studentNameEol = aluno.NomeAluno,
                    });
                });

                //return listStudentsPollPortuguese;
                return listStudentsPollPortuguese.OrderBy(a => a.studentNameEol).ToList();
                //fazer order by por nome
            }
        }

        private static async Task<PeriodoFixoAnual> ObterPeriodoFixoAnual(Periodo periodo, int anoLetivo, PeriodoFixoAnual periodoFixoAnual, SMEManagementContextData db)
        {
            periodoFixoAnual = await db.PeriodoFixoAnual.FirstOrDefaultAsync(fixo => fixo.PeriodoId == periodo.Id && fixo.Ano == anoLetivo);

            if (periodoFixoAnual == null)
                throw new Exception("Não foi encontrado periodo de abertura da sondagem para os filtros informados");
            return periodoFixoAnual;
        }

        public async Task<Periodo> ObterPeriodoRelatorioPorDescricao(string descricao)
        {
            using (var contexto = new SMEManagementContextData())
            {
                return await contexto.Periodo.FirstOrDefaultAsync(p => p.Descricao.Equals(descricao));
            }
        }

        private async Task<PeriodoFixoAnual> ObterPeriodoFixoAnual(Periodo periodo, int anoLetivo)
        {
            using (var contexto = new SMEManagementContextData())
            {
                return await contexto.PeriodoFixoAnual.FirstOrDefaultAsync(fixo => fixo.PeriodoId == periodo.Id && fixo.Ano == anoLetivo);
            }
        }

        private async Task<PeriodoFixoAnual> ObterPeriodoFixoAnualPorIdEAnoLetivo(string Id, int anoLetivo)
        {
            using (var contexto = new SMEManagementContextData())
            {
                return await contexto.PeriodoFixoAnual.FirstOrDefaultAsync(fixo => fixo.PeriodoId == Id && fixo.Ano == anoLetivo);
            }
        }

        public async Task<PollReportPortugueseResult> BuscarDadosRelatorioPortugues(string proficiencia, string bimestre, string anoLetivo, string codigoDre, string codigoEscola, string codigoCurso, Periodo periodo)
        {
            var liststudentPollPortuguese = new List<StudentPollPortuguese>();
            var existeRespostas = false;
            PeriodoFixoAnual periodoAnual = null;
            var consideraNovaOpcaoRespostaSemPreenchimento = NovaOpcaoRespostaSemPreenchimento.ConsideraOpcaoRespostaSemPreenchimento(int.Parse(anoLetivo),bimestre);

            var listReturn = new List<PollReportPortugueseItem>();

            using (SMEManagementContextData db = new SMEManagementContextData())
            {
                var listStudentsPollPortuguese = new List<PortuguesePoll>();
                IQueryable<PortuguesePoll> query = db.Set<PortuguesePoll>();

                query = db.PortuguesePolls.Where(x => x.schoolYear == anoLetivo);

                //montando filtros genericamente
                if (!string.IsNullOrWhiteSpace(codigoDre))
                    query = query.Where(u => u.dreCodeEol == codigoDre);

                if (!string.IsNullOrWhiteSpace(codigoEscola))
                    query = query.Where(u => u.schoolCodeEol == codigoEscola);

                if (!string.IsNullOrWhiteSpace(codigoCurso))
                    query = query.Where(u => u.yearClassroom == codigoCurso);

                List<PortChartDataModel> graficos = new List<PortChartDataModel>();

                periodoAnual = await db.PeriodoFixoAnual.FirstOrDefaultAsync(x => x.PeriodoId == periodo.Id && x.Ano == Convert.ToInt32(anoLetivo));

                if (periodoAnual == null)
                    throw new Exception("");

                int quantidadeTotalAlunos = await alunoAPI.ObterTotalAlunosAtivosPorPeriodo(new Integracao.DTO.FiltroTotalAlunosAtivos
                {
                    AnoLetivo = Convert.ToInt32(anoLetivo),
                    AnoTurma = Convert.ToInt32(codigoCurso),
                    DataFim = periodoAnual.DataFim,
                    DataInicio = periodoAnual.DataInicio,
                    DreId = codigoDre,
                    UeId = codigoEscola
                });

                switch (bimestre)
                {
                    case "1° Bimestre":
                    {
                        if (proficiencia == "Escrita")
                        {
                            var writing1B = query.GroupBy(fu => fu.writing1B).Select(g => new {Label = g.Key, Value = g.Count()}).ToList();
                            
                            foreach (var item in writing1B)
                            {
                                PollReportPortugueseItem itemRetorno = new PollReportPortugueseItem();
                                itemRetorno.OptionName = MontarTextoProficiencia(item.Label);
                                itemRetorno.studentQuantity = item.Value;
                                listReturn.Add(itemRetorno);

                                graficos.Add(new PortChartDataModel()
                                {
                                    Name = MontarTextoProficiencia(item.Label),
                                    Value = item.Value
                                });
                            }
                        }

                        else //leitura
                        {
                            var reading1B = query.GroupBy(fu => fu.reading1B).Select(g => new {Label = g.Key, Value = g.Count()}).ToList();

                            foreach (var item in reading1B)
                            {
                                PollReportPortugueseItem itemRetorno = new PollReportPortugueseItem();
                                itemRetorno.OptionName = MontarTextoProficiencia(item.Label);
                                itemRetorno.studentQuantity = item.Value;
                                listReturn.Add(itemRetorno);

                                graficos.Add(new PortChartDataModel()
                                {
                                    Name = MontarTextoProficiencia(item.Label),
                                    Value = item.Value
                                });
                            }
                        }
                    }
                        break;
                    case "2° Bimestre":
                    {
                        if (proficiencia == "Escrita")
                        {
                            var writing2B = query.GroupBy(fu => fu.writing2B).Select(g => new {Label = g.Key, Value = g.Count()}).ToList();

                            foreach (var item in writing2B)
                            {
                                PollReportPortugueseItem itemRetorno = new PollReportPortugueseItem();
                                itemRetorno.OptionName = MontarTextoProficiencia(item.Label);
                                itemRetorno.studentQuantity = item.Value;
                                listReturn.Add(itemRetorno);

                                graficos.Add(new PortChartDataModel()
                                {
                                    Name = MontarTextoProficiencia(item.Label),
                                    Value = item.Value
                                });
                            }
                        }
                        else //leitura
                        {
                            var reading2B = query.GroupBy(fu => fu.reading2B).Select(g => new {Label = g.Key, Value = g.Count()}).ToList();

                            foreach (var item in reading2B)
                            {
                                PollReportPortugueseItem itemRetorno = new PollReportPortugueseItem();
                                itemRetorno.OptionName = MontarTextoProficiencia(item.Label);
                                itemRetorno.studentQuantity = item.Value;
                                listReturn.Add(itemRetorno);

                                graficos.Add(new PortChartDataModel()
                                {
                                    Name = MontarTextoProficiencia(item.Label),
                                    Value = item.Value
                                });
                            }
                        }
                    }
                        break;
                    case "3° Bimestre":
                    {
                        if (proficiencia == "Escrita")
                        {
                            var writing3B =  consideraNovaOpcaoRespostaSemPreenchimento ? query.GroupBy(fu => fu.writing3B).Where(x => x.Key.Length > 0).Select(g => new {Label = g.Key, Value = g.Count()}).ToList() 
                                                    : query.GroupBy(fu => fu.writing3B).Select(g => new {Label = g.Key, Value = g.Count()}).ToList();
                            existeRespostas = writing3B.Any();
                            foreach (var item in writing3B)
                            {
                                var itemRetorno = new PollReportPortugueseItem();
                                itemRetorno.OptionName = MontarTextoProficiencia(item.Label);
                                itemRetorno.studentQuantity = item.Value;
                                listReturn.Add(itemRetorno);

                                graficos.Add(new PortChartDataModel()
                                {
                                    Name = MontarTextoProficiencia(item.Label),
                                    Value = item.Value
                                });
                            }
                        }
                        else //leitura
                        {
                            var reading3B = consideraNovaOpcaoRespostaSemPreenchimento ? query.GroupBy(fu => fu.reading3B).Where(x => x.Key.Length > 0).Select(g => new {Label = g.Key, Value = g.Count()}).ToList()
                                                                                       : query.GroupBy(fu => fu.reading3B).Select(g => new {Label = g.Key, Value = g.Count()}).ToList();
                            existeRespostas = reading3B.Any();
                            foreach (var item in reading3B)
                            {
                                var itemRetorno = new PollReportPortugueseItem();
                                itemRetorno.OptionName = MontarTextoProficiencia(item.Label);
                                itemRetorno.studentQuantity = item.Value;
                                listReturn.Add(itemRetorno);

                                graficos.Add(new PortChartDataModel()
                                {
                                    Name = MontarTextoProficiencia(item.Label),
                                    Value = item.Value
                                });
                            }
                        }
                    }
                        break;
                    case "4° Bimestre":
                    {
                        if (proficiencia == "Escrita")
                        {
                            var writing4B = consideraNovaOpcaoRespostaSemPreenchimento ? query.GroupBy(fu => fu.writing4B).Where(x => x.Key.Length > 0).Select(g => new {Label = g.Key, Value = g.Count()}).ToList()
                                                    : query.GroupBy(fu => fu.writing4B).Select(g => new {Label = g.Key, Value = g.Count()}).ToList();
                            existeRespostas = writing4B.Any();
                            foreach (var item in writing4B)
                            {
                                var itemRetorno = new PollReportPortugueseItem();
                                itemRetorno.OptionName = MontarTextoProficiencia(item.Label);
                                itemRetorno.studentQuantity = item.Value;
                                listReturn.Add(itemRetorno);

                                graficos.Add(new PortChartDataModel()
                                {
                                    Name = MontarTextoProficiencia(item.Label),
                                    Value = item.Value
                                });
                            }
                        }
                        else //leitura
                        {
                            var reading4B = consideraNovaOpcaoRespostaSemPreenchimento ? query.GroupBy(fu => fu.reading4B).Where(x => x.Key.Length > 0).Select(g => new {Label = g.Key, Value = g.Count()}).ToList()
                                :query.GroupBy(fu => fu.reading4B).Select(g => new {Label = g.Key, Value = g.Count()}).ToList();
                            existeRespostas = reading4B.Any();
                            foreach (var item in reading4B)
                            {
                                PollReportPortugueseItem itemRetorno = new PollReportPortugueseItem();
                                itemRetorno.OptionName = MontarTextoProficiencia(item.Label);
                                itemRetorno.studentQuantity = item.Value;
                                listReturn.Add(itemRetorno);

                                graficos.Add(new PortChartDataModel()
                                {
                                    Name = MontarTextoProficiencia(item.Label),
                                    Value = item.Value
                                });
                            }
                        }
                    }
                        break;
                }

                var listaGrafico = graficos.GroupBy(fu => fu.Name).Select(g => new {Label = g.Key, Value = g.Sum(soma => soma.Value)}).ToList();

                int totalSemPreenchimento = quantidadeTotalAlunos - listaGrafico.Where(l => !string.IsNullOrWhiteSpace(l.Label)).Sum(l => l.Value) >=0 
                        ? quantidadeTotalAlunos - listaGrafico.Where(l => !string.IsNullOrWhiteSpace(l.Label)).Sum(l => l.Value)
                        : 0;



                foreach (var item in listReturn)
                {
                    item.StudentPercentage = ((double) item.studentQuantity / quantidadeTotalAlunos) * 100;
                    if (!consideraNovaOpcaoRespostaSemPreenchimento)
                    {
                        if (string.IsNullOrWhiteSpace(item.OptionName))
                        {
                            item.OptionName = "Sem preenchimento";
                            item.StudentPercentage = ((double) totalSemPreenchimento / quantidadeTotalAlunos) * 100;
                            item.studentQuantity = totalSemPreenchimento;
                        }
                    }
                }

                var percentualTotalRespostas = listReturn.Select(x => x.StudentPercentage).Sum();
                var retorno = new PollReportPortugueseResult();

                graficos = new List<PortChartDataModel>();

                foreach (var item in listaGrafico)
                {
                    if (!consideraNovaOpcaoRespostaSemPreenchimento)
                    {
                        graficos.Add(new PortChartDataModel()                    {
                            Name = string.IsNullOrWhiteSpace(item.Label)
                                ? "Sem preenchimento"
                                : item.Label,
                            Value = string.IsNullOrWhiteSpace(item.Label)
                                ? totalSemPreenchimento
                                : item.Value
                        });
                    }
                    else
                    {
                        graficos.Add(new PortChartDataModel()                    {
                            Name = item.Label,
                            Value = item.Value
                        });
                    }
                }
                
                
                
                if (proficiencia == "Escrita")
                {
                    //particularidade do 3 ano
                    if (listReturn.Any(l => l.OptionName.Contains("Nivel")))
                    {
                        retorno.Results = listReturn.OrderBy(lr => lr.OptionName).ToList();
                        retorno.ChartData = graficos.OrderBy(g => g.Name).ToList();
                    }
                    else
                    {
                        string[] descSequenciaOrdenadaDeRespostasEscritas = {"Pré-Silábico", "Silábico sem valor", "Silábico com valor", "Silábico alfabético", "Alfabético", "Sem preenchimento"};

                        foreach (var desc in descSequenciaOrdenadaDeRespostasEscritas)
                        {
                            foreach (var item in listReturn)
                            {
                                if (item.OptionName == desc)
                                {
                                    retorno.Results.Add(item);
                                    break;
                                }
                            }
                        }

                        foreach (var desc in descSequenciaOrdenadaDeRespostasEscritas)
                        {
                            foreach (var item in graficos)
                            {
                                if (item.Name == desc)
                                {
                                    retorno.ChartData.Add(item);
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    retorno.Results = listReturn.OrderBy(lr => lr.OptionName).ToList();
                    retorno.ChartData = graficos.OrderBy(g => g.Name).ToList();
                }

                var novaOpcaoRespostaComTodasTurmas = (consideraNovaOpcaoRespostaSemPreenchimento &&
                                                       string.IsNullOrWhiteSpace(codigoEscola));
                if (novaOpcaoRespostaComTodasTurmas)
                {
                    retorno.Total = new TotalDTO()
                    {
                        Quantidade = existeRespostas ? quantidadeTotalAlunos : 0,
                        Porcentagem = existeRespostas ? ((((double)totalSemPreenchimento / quantidadeTotalAlunos) * 100) + percentualTotalRespostas).ToString() : "0",
                    };
                }
                retorno.ConsideraNovaOpcaoRespostaSemPreenchimento = novaOpcaoRespostaComTodasTurmas;
                return retorno;
            }
        }

        public async Task<int> RetornaTotalAlunosSondagem(string[] turmasSondagem, DateTime dataReferencia)
        {
            int totalAlunos = 0;
            foreach (var turma in turmasSondagem)
            {
                var alunos = await alunoAPI.ObterAlunosAtivosPorTurmaEPeriodo(turma, dataReferencia);
                totalAlunos += alunos.Count();
            }

            return totalAlunos;
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


        public IEnumerable<DTO.Portugues.GrupoDTO> ListarGrupos()
        {
            using (var contexto = new SMEManagementContextData())
            {
                var grupos = contexto.Grupo.Include(x => x.Ordem).ToList();

                var ListaGrupos = new List<DTO.Portugues.GrupoDTO>();

                foreach (var grupo in grupos)
                {
                    var grupoDto = new DTO.Portugues.GrupoDTO();
                    grupoDto.Ordem = new List<OrdemDTO>();
                    grupoDto.Id = grupo.Id;
                    grupoDto.Descricao = grupo.Descricao;
                    grupoDto.OrdemVisivel = grupo.OrdemVisivel;

                    foreach (var ordem in grupo.Ordem)
                    {
                        var ordemDto = new OrdemDTO()
                        {
                            Id = ordem.Id,
                            Descricao = ordem.Descricao,
                            Ordenacao = ordem.Ordenacao
                        };
                        grupoDto.Ordem.Add(ordemDto);
                    }

                    grupoDto.Ordem = grupoDto.Ordem?.OrderBy(x => x.Ordenacao).ToList();

                    ListaGrupos.Add(grupoDto);
                }

                return ListaGrupos.OrderBy(x => x.Descricao);
            }
        }

        public IEnumerable<Sondagem> ListarOrdens()
        {
            using (var contexto = new SMEManagementContextData())
            {
                try
                {
                    var ss = contexto.Sondagem.ToList();
                    var s = contexto.Sondagem.Include(x => x.AlunosSondagem).ThenInclude(xx => xx.ListaRespostas).ToList();
                    return s;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public ComponenteCurricular RetornaComponenteCurricularPortugues()
        {
            using (var contexto = new SMEManagementContextData())
            {
                return contexto.ComponenteCurricular.Where(x => x.Descricao == "Língua portuguesa").FirstOrDefault();
            }
        }

        public IEnumerable<PeriodoDto> RetornaPeriodos(Models.Enums.TipoPeriodoEnum tipoPeriodo)
        {
            using (var contexto = new SMEManagementContextData())
            {
                var peridos = contexto.Periodo.Where(x => x.TipoPeriodo == tipoPeriodo).ToList();
                var ListaPeriodos = new List<PeriodoDto>();
                foreach (var periodo in peridos)
                {
                    var periodoDto = new PeriodoDto()
                    {
                        Id = periodo.Id,
                        Descricao = periodo.Descricao
                    };

                    ListaPeriodos.Add(periodoDto);
                }

                return ListaPeriodos;
            }
        }

        public async Task<IEnumerable<AlunoSondagemPortuguesDTO2>> ListarAlunosPortugues(FiltrarListagemDto filtrarListagemDto)
        {
            try 
            {
                var sondagem = await ObterSondagemPortugues(filtrarListagemDto);
                var periodoSondagemSelecionado = await ObterPeriodoFixoAnualPorIdEAnoLetivo(filtrarListagemDto.PeriodoId, filtrarListagemDto.AnoLetivo);
                var endpointsAPI = new EndpointsAPI();

                var turmApi = new TurmasAPI(endpointsAPI);
                var listaAlunos = await turmApi.GetAlunosNaTurma(Convert.ToInt32(filtrarListagemDto.CodigoTurma), _token);
                
                var alunos = listaAlunos.Where(x => !x.AlunoInativo && (x.CodigoSituacaoMatricula == 10 || x.CodigoSituacaoMatricula == 1 || x.CodigoSituacaoMatricula == 6 || x.CodigoSituacaoMatricula == 13 || x.CodigoSituacaoMatricula == 5) || 
                x.AlunoInativo && periodoSondagemSelecionado != null && ((x.DataSituacao > periodoSondagemSelecionado?.DataInicio.Date && x.DataSituacao <= periodoSondagemSelecionado?.DataFim.Date) || x.DataSituacao > periodoSondagemSelecionado?.DataFim.Date)).ToList();
                
                if (alunos == null || !alunos.Any())
                    throw new Exception($"Não encontrado alunos para a turma {filtrarListagemDto.CodigoTurma} do ano letivo {filtrarListagemDto.AnoLetivo}");

                var listagem = new List<AlunoSondagemPortuguesDTO2>();

                if (sondagem != null)
                    foreach (var aluno in sondagem.AlunosSondagem)
                        MapearAlunosListagem(listagem, aluno, sondagem);

                AdicionarAlunosEOL(filtrarListagemDto, alunos, listagem, sondagem);

                return listagem.OrderBy(x => x.NumeroChamada).ThenBy(x => x.NomeAluno);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IEnumerable<SequenciaOrdemSalvaDTO>> ListaSequenciaOrdensSalva(FiltrarListagemDto filtrarListagemDto)
        {
            using (var contexto = new SMEManagementContextData())
            {
                var lista = await contexto.Sondagem.Where(x => x.ComponenteCurricular.Id
                                                                   .Equals(filtrarListagemDto.ComponenteCurricular.ToString())
                                                               && x.AnoTurma == filtrarListagemDto.AnoEscolar
                                                               && x.CodigoDre == filtrarListagemDto.CodigoDre
                                                               && x.CodigoUe == filtrarListagemDto.CodigoUe
                                                               && x.AnoLetivo == filtrarListagemDto.AnoLetivo
                                                               && x.GrupoId == filtrarListagemDto.GrupoId
                                                               && (filtrarListagemDto.CodigoTurma == null ? true : x.CodigoTurma.Equals(filtrarListagemDto.CodigoTurma)))
                    .ToListAsync();

                if (lista.Count == 0)
                {
                    var listaVazia = new List<SequenciaOrdemSalvaDTO>();
                    return listaVazia;
                }

                lista = VerificaSondagemOrdenacaoCapacidadeDeLeitura(lista);

                var listaSequenciaOrdemSalva = lista.GroupBy(x => x.Id).Select(item => new SequenciaOrdemSalvaDTO
                {
                    OrdemId = item.First().OrdemId,
                    SequenciaOrdemSalva = item.First().SequenciaDeOrdemSalva
                }).ToList();

                listaSequenciaOrdemSalva = listaSequenciaOrdemSalva?.DistinctBy(l=> l.OrdemId).ToList();

                return listaSequenciaOrdemSalva;
            }
        }

        public List<Sondagem> VerificaSondagemOrdenacaoCapacidadeDeLeitura(List<Sondagem> sondagens)
        {
            if (sondagens.FirstOrDefault().GrupoId == GrupoEnum.CapacidadeLeitura.Name())
                return sondagens.Where(s => s.SequenciaDeOrdemSalva <= 3).ToList();
            else
                return sondagens;
        }


        public async Task<IEnumerable<PerguntaDto>> ListarPerguntas(int sequenciaOrdem, string grupoId)
        {
            try
            {
                using (var contexto = new SMEManagementContextData())
                {
                    var listaOrdemPergunta = contexto.OrdemPergunta.Include(x => x.Grupo).Include(x => x.Pergunta).Where(y => y.GrupoId == grupoId).ToList();
                    var perguntaResposta = contexto.PerguntaResposta.Include(x => x.Pergunta).Include(y => y.Resposta).ToList();
                    var listaPerguntaDto = new List<PerguntaDto>();

                    foreach (var ordem in listaOrdemPergunta)
                    {
                        var perguntaDto = new PerguntaDto();
                        perguntaDto.Id = ordem.Pergunta.Id;
                        perguntaDto.Descricao = ordem.Pergunta.Descricao;
                        perguntaDto.Ordenacao = ordem.OrdenacaoNaTela;
                        perguntaDto.SequenciaOrdem = ordem.SequenciaOrdem;

                        var lresposta = perguntaResposta.Where(x => x.Pergunta != null && x.Pergunta.Id == ordem.PerguntaId);
                        perguntaDto.Respostas = lresposta.Select(item => new RespostaDto
                        {
                            Descricao = item.Resposta.Descricao,
                            Id = item.Resposta.Id,
                            Ordenacao = item.Ordenacao,
                            Verdadeiro = item.Resposta.Verdadeiro,
                        }).ToList();

                        listaPerguntaDto.Add(perguntaDto);
                    }

                    return listaPerguntaDto.OrderBy(x => x.Ordenacao);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void AdicionarAlunosEOL(FiltrarListagemDto filtrarListagemDto, List<AlunosNaTurmaDTO> alunos, List<AlunoSondagemPortuguesDTO2> listagem, Sondagem sondagem)
        {
            alunos.ForEach(aluno =>
            {
                string idSondagem = null;
                var alunoBanco = listagem.FirstOrDefault(x => x.CodigoAluno.Equals(aluno.CodigoAluno.ToString()));
                if (sondagem != null)
                    idSondagem = sondagem.Id.ToString();
                if (alunoBanco != null)
                {
                    alunoBanco.NumeroChamada = aluno.NumeroAlunoChamada;
                    return;
                }

                listagem.Add(new AlunoSondagemPortuguesDTO2
                {
                    SondagemId = idSondagem,
                    CodigoAluno = aluno.CodigoAluno.ToString(),
                    AnoLetivo = filtrarListagemDto.AnoLetivo,
                    AnoTurma = filtrarListagemDto.AnoEscolar,
                    CodigoDre = filtrarListagemDto.CodigoDre,
                    CodigoTurma = filtrarListagemDto.CodigoTurma,
                    CodigoUe = filtrarListagemDto.CodigoUe,
                    NumeroChamada = aluno.NumeroAlunoChamada,
                    ComponenteCurricular = filtrarListagemDto.ComponenteCurricular.ToString(),
                    NomeAluno = aluno.NomeAluno,
                });
                ;

                listagem.OrderBy(x => x.NumeroChamada);
            });
        }

        private void MapearAlunosListagem(List<AlunoSondagemPortuguesDTO2> listagem, SondagemAluno aluno, Sondagem sondagem)
        {
            var indexAluno = listagem.FindIndex(x => x.CodigoAluno.Equals(aluno.CodigoAluno.ToString()));

            if (indexAluno >= 0)
                foreach (var resposta in aluno.ListaRespostas)
                    AdicionarRespostaAluno(resposta, listagem, indexAluno, sondagem.PeriodoId);
            else
                AdicionarNovoAlunoListagem(listagem, aluno, sondagem);
        }


        public void SalvarSondagemAutoralPortugues(IEnumerable<AlunoSondagemPortuguesDTO2> ListaAlunosSondagemDto)
        {
            try
            {
                if (ListaAlunosSondagemDto == null || !ListaAlunosSondagemDto.Any())
                    throw new Exception("É necessário realizar a sondagem de pelo menos 1 aluno");
                using (var contexto = new SMEManagementContextData())
                {
                    Sondagem sondagem = null;
                    var item = ListaAlunosSondagemDto.FirstOrDefault();

                    if (!string.IsNullOrEmpty(item.SondagemId))
                        sondagem = BuscaSondagem(contexto, item);

                    if (sondagem == null)
                    {
                        var novaSondagem = CriaNovaSondagem(ListaAlunosSondagemDto, item);
                        if (novaSondagem != null)
                        {
                            contexto.Sondagem.Add(novaSondagem);
                            contexto.SaveChanges();
                        }
                    }

                    else
                    {
                        EditaSondagem(ListaAlunosSondagemDto, contexto, sondagem);

                        contexto.Sondagem.Update(sondagem);
                        contexto.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Sondagem BuscaSondagem(SMEManagementContextData contexto, AlunoSondagemPortuguesDTO2 item)
        {
            return contexto.Sondagem.Where(s => s.Id == Guid.Parse(item.SondagemId))
                .Include(ss => ss.AlunosSondagem)
                .ThenInclude(x => x.ListaRespostas).FirstOrDefault();
        }

        private static void EditaSondagem(IEnumerable<AlunoSondagemPortuguesDTO2> ListaAlunosSondagemDto, SMEManagementContextData contexto, Sondagem sondagem)
        {
            foreach (var aluno in ListaAlunosSondagemDto)
            {
                if (string.IsNullOrEmpty(aluno.Id) && aluno.Respostas != null)
                {
                    var alunoNovoSondagem = CriaNovoAlunoSondagem(sondagem, aluno);
                    sondagem.AlunosSondagem.Add(alunoNovoSondagem);
                }
                else if (!string.IsNullOrEmpty(aluno.Id))
                {
                    var alunoSondagem = sondagem.AlunosSondagem.Where(a => a.Id.ToString() == aluno.Id).FirstOrDefault();
                    if (aluno.Respostas == null || aluno.Respostas.Count == 0)
                    {
                        contexto.SondagemAluno.Remove(alunoSondagem);
                    }
                    else
                    {
                        AtualizaNovasRespostas(aluno, alunoSondagem);
                        RemoveRespostasSemValor(contexto, aluno, alunoSondagem);
                    }
                }
            }
        }

        private static void RemoveRespostasSemValor(SMEManagementContextData contexto, AlunoSondagemPortuguesDTO2 aluno, SondagemAluno alunoSondagem)
        {
            var ListaRespostasRemovidas = new List<SondagemAlunoRespostas>();

            if (alunoSondagem.ListaRespostas.Any(x => x.RespostaId != ""))
            {
                foreach (var alunoResposta in alunoSondagem.ListaRespostas)
                {
                    var respostaSondagem = aluno.Respostas.Where(x => x.Pergunta == alunoResposta.PerguntaId && x.Resposta != "").FirstOrDefault();
                    if (respostaSondagem == null)
                    {
                        ListaRespostasRemovidas.Add(alunoResposta);
                    }
                }

                contexto.SondagemAlunoRespostas.RemoveRange(ListaRespostasRemovidas);
            }
            else
            {
                contexto.SondagemAluno.Remove(alunoSondagem);
            }
        }


        private static void AtualizaNovasRespostas(AlunoSondagemPortuguesDTO2 aluno, SondagemAluno alunoSondagem)
        {
            foreach (var resposta in aluno.Respostas)
            {
                var respostaSondagem = alunoSondagem.ListaRespostas.Where(x => x.PerguntaId == resposta.Pergunta).FirstOrDefault();
                if (respostaSondagem != null)
                {
                    respostaSondagem.RespostaId = resposta.Resposta;
                }

                else
                {
                    var respostaNova = CriaNovaRespostaAluno(alunoSondagem, resposta);

                    alunoSondagem.ListaRespostas.Add(respostaNova);
                }
            }
        }


        private static Sondagem CriaNovaSondagem(IEnumerable<AlunoSondagemPortuguesDTO2> ListaAlunosSondagemDto, AlunoSondagemPortuguesDTO2 item)
        {
            var sondagem = (Sondagem) item;
            sondagem.AlunosSondagem = new List<SondagemAluno>();

            var listaAlunosComRespostaDto = ListaAlunosSondagemDto.Where(x => x.Respostas != null && x.Respostas.Count > 0).ToList();

            if (listaAlunosComRespostaDto == null || listaAlunosComRespostaDto.Count == 0)
                return null;

            string periodoId;
            foreach (var alunoDto in listaAlunosComRespostaDto)
            {
                var aluno = CriaNovoAlunoSondagem(sondagem, alunoDto);

                sondagem.AlunosSondagem.Add(aluno);
                aluno.ListaRespostas = new List<SondagemAlunoRespostas>();

                foreach (var respostaDto in alunoDto.Respostas)
                {
                    var resposta = CriaNovaRespostaAluno(aluno, respostaDto);

                    aluno.ListaRespostas.Add(resposta);
                }

                periodoId = alunoDto.Respostas.First().PeriodoId;
                sondagem.PeriodoId = periodoId;
            }

            ;
            return sondagem;
        }

        private static SondagemAlunoRespostas CriaNovaRespostaAluno(SondagemAluno aluno, AlunoRespostaDto respostaDto)
        {
            var resposta = new SondagemAlunoRespostas();
            resposta.Id = Guid.NewGuid();
            resposta.PerguntaId = respostaDto.Pergunta;
            resposta.RespostaId = respostaDto.Resposta;
            resposta.SondagemAlunoId = aluno.Id;
            return resposta;
        }

        private static SondagemAluno CriaNovoAlunoSondagem(Sondagem sondagem, AlunoSondagemPortuguesDTO2 alunoDto)
        {
            var aluno = new SondagemAluno()
            {
                Id = Guid.NewGuid(),
                CodigoAluno = alunoDto.CodigoAluno,
                SondagemId = sondagem.Id,
                NomeAluno = alunoDto.NomeAluno,
                ListaRespostas = new List<SondagemAlunoRespostas>()
            };

            foreach (var respostaDto in alunoDto.Respostas)
            {
                var resposta = CriaNovaRespostaAluno(aluno, respostaDto);
                aluno.ListaRespostas.Add(resposta);
            }

            return aluno;
        }

        private static void DisplayStates(IEnumerable<EntityEntry> entries)
        {
            foreach (var entry in entries)
            {
                Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: {entry.State.ToString()} ");
            }
        }


        private static SondagemAluno ListaRespostas(AlunoSondagemPortuguesDTO2 alunoDto, SondagemAluno aluno, out string periodoId)
        {
            aluno.ListaRespostas = new List<SondagemAlunoRespostas>();
            var resposta = new SondagemAlunoRespostas();

            foreach (var respostaDto in alunoDto.Respostas)
            {
                resposta.Id = Guid.NewGuid();
                resposta.PerguntaId = respostaDto.Pergunta;
                resposta.RespostaId = respostaDto.Resposta;
                resposta.SondagemAlunoId = aluno.Id;

                aluno.ListaRespostas.Add(resposta);
            }

            periodoId = alunoDto.Respostas.First().PeriodoId;
            return aluno;
        }

        private void SalvarAluno(IEnumerable<AlunoSondagemPortuguesDTO> ListaAlunoSondagemPortuguesDTO, SMEManagementContextData contexto)
        {
            foreach (var aluno in ListaAlunoSondagemPortuguesDTO)
            {
                var alunoAutoral = (SondagemAutoral) aluno;

                if (aluno.Respostas != null && aluno.Respostas.Any())
                    SalvarAlunoComResposta(contexto, aluno, alunoAutoral);
            }
        }

        private void SalvarAlunoComResposta(SMEManagementContextData contexto, AlunoSondagemPortuguesDTO aluno, SondagemAutoral alunoAutoral)
        {
            foreach (var resposta in aluno.Respostas)
            {
                var alunoSalvar = MapSalvar(contexto, resposta, alunoAutoral, aluno);

                AdicicionarOuAlterar(contexto, alunoSalvar);
            }
        }

        private SondagemAutoral MapSalvar(SMEManagementContextData contexto, AlunoRespostaDto resposta, SondagemAutoral alunoAutoral, AlunoSondagemPortuguesDTO aluno)
        {
            var alunoBanco = contexto.SondagemAutoral
                .FirstOrDefault(sondagem => sondagem.PerguntaId == resposta.Pergunta
                                            && sondagem.PeriodoId == resposta.PeriodoId
                                            && sondagem.CodigoAluno == alunoAutoral.CodigoAluno
                                            && sondagem.CodigoTurma == alunoAutoral.CodigoTurma
                                            && sondagem.ComponenteCurricularId == alunoAutoral.ComponenteCurricularId
                                            && sondagem.GrupoId == alunoAutoral.GrupoId
                                            && sondagem.OrdemId == alunoAutoral.OrdemId
                );

            if (alunoBanco == null)
                alunoBanco = new SondagemAutoral(alunoAutoral);

            alunoBanco.PerguntaId = resposta.Pergunta;
            alunoBanco.RespostaId = resposta.Resposta;
            alunoBanco.PeriodoId = resposta.PeriodoId;
            alunoBanco.SequenciaDeOrdemSalva = aluno.SequenciaOrdemSalva;

            return alunoBanco;
        }

        private void AdicicionarOuAlterar(SMEManagementContextData context, SondagemAutoral sondagemAutoral)
        {
            if (string.IsNullOrWhiteSpace(sondagemAutoral.Id))
                context.SondagemAutoral.Add(sondagemAutoral);
            else
            {
                context.SondagemAutoral.Update(sondagemAutoral);
            }
        }

        private void AdicionarRespostaAluno(SondagemAlunoRespostas alunoResposta, List<AlunoSondagemPortuguesDTO2> listagem, int index, string periodoId)
        {
            listagem[index].Respostas.Add(new AlunoRespostaDto
            {
                PeriodoId = periodoId,
                Pergunta = alunoResposta.PerguntaId,
                Resposta = alunoResposta.RespostaId
            });
        }


        private void AdicionarRespostaAluno(SondagemAutoral aluno, List<AlunoSondagemPortuguesDTO> listagem, int index)
        {
            listagem[index].Respostas.Add(new AlunoRespostaDto
            {
                PeriodoId = aluno.PeriodoId,
                Pergunta = aluno.PerguntaId,
                Resposta = aluno.RespostaId
            });
        }


        private void AdicionarNovoAlunoListagem(List<AlunoSondagemPortuguesDTO2> listagem, SondagemAluno aluno, Sondagem sondagem)
        {
            var alunoDto = new AlunoSondagemPortuguesDTO2
            {
                Id = aluno.Id.ToString(),
                SondagemId = aluno.SondagemId.ToString(),
                CodigoAluno = aluno.CodigoAluno,
                NomeAluno = aluno.NomeAluno,
                AnoLetivo = sondagem.AnoLetivo,
                AnoTurma = sondagem.AnoTurma,
                CodigoDre = sondagem.CodigoDre,
                CodigoTurma = sondagem.CodigoTurma,
                CodigoUe = sondagem.CodigoUe,
                ComponenteCurricular = sondagem.ComponenteCurricularId,
                GrupoId = sondagem.GrupoId,
                OrdemId = sondagem.OrdemId,
                SequenciaOrdemSalva = sondagem.SequenciaDeOrdemSalva,
                Respostas = new List<AlunoRespostaDto>()
            };

            foreach (var resp in aluno.ListaRespostas)
            {
                var alunoRespDto = new AlunoRespostaDto()
                {
                    Pergunta = resp.PerguntaId,
                    Resposta = resp.RespostaId,
                    PeriodoId = sondagem.PeriodoId
                };
                alunoDto.Respostas.Add(alunoRespDto);
            }

            listagem.Add(alunoDto);
        }

        public void ExcluirSondagem(Sondagem sondagem)
        {
            using (var contexto = new SMEManagementContextData())
            {
                contexto.Sondagem.Remove(sondagem);
                contexto.SaveChanges();
            }
        }


        public async Task<Sondagem> ObterSondagemPortugues(FiltrarListagemDto filtrarListagemDto)
        {
            using (var contexto = new SMEManagementContextData())
            {
                try
                {
                    return await contexto.Sondagem.Where(x => x.ComponenteCurricular.Id
                                                                  .Equals(filtrarListagemDto.ComponenteCurricular.ToString())
                                                              && x.AnoTurma == filtrarListagemDto.AnoEscolar
                                                              && x.OrdemId == filtrarListagemDto.OrdemId
                                                              && x.PeriodoId == filtrarListagemDto.PeriodoId
                                                              && x.CodigoDre == filtrarListagemDto.CodigoDre
                                                              && x.CodigoUe == filtrarListagemDto.CodigoUe
                                                              && x.AnoLetivo == filtrarListagemDto.AnoLetivo
                                                              && (filtrarListagemDto.CodigoTurma == null ? true : x.CodigoTurma.Equals(filtrarListagemDto.CodigoTurma))).Include(ss => ss.AlunosSondagem)
                        .ThenInclude(x => x.ListaRespostas).FirstOrDefaultAsync();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private static async Task<IList<SondagemAutoral>> ObterSondagemPortuguesAutoral(FiltrarListagemDto filtrarListagemDto)
        {
            using (var contexto = new SMEManagementContextData())
            {
                try
                {
                    return await contexto.SondagemAutoral.Where(x => x.ComponenteCurricular.Id
                                                                         .Equals(filtrarListagemDto.ComponenteCurricular.ToString())
                                                                     && x.AnoTurma == filtrarListagemDto.AnoEscolar
                                                                     && x.OrdemId == filtrarListagemDto.OrdemId
                                                                     && x.PeriodoId == filtrarListagemDto.PeriodoId
                                                                     && x.CodigoDre == filtrarListagemDto.CodigoDre
                                                                     && x.CodigoUe == filtrarListagemDto.CodigoUe
                                                                     && x.AnoLetivo == filtrarListagemDto.AnoLetivo
                                                                     && (filtrarListagemDto.CodigoTurma == null ? true : x.CodigoTurma.Equals(filtrarListagemDto.CodigoTurma)))
                        .ToListAsync();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<ResultadoAlunoPortuguesDTO> ObterResultadosAluno(string turmaCodigo, string alunoCodigo)
        {
            using (var contexto = new SMEManagementContextData())
            {
                var resultado = await contexto.PortuguesePolls
                    .FirstOrDefaultAsync(a => a.classroomCodeEol.Equals(turmaCodigo)
                                           && a.studentCodeEol.Equals(alunoCodigo));

                if (resultado == null)
                    return new ResultadoAlunoPortuguesDTO();

                return new ResultadoAlunoPortuguesDTO()
                {
                    Escrita1Bim = resultado.writing1B,
                    Escrita2Bim = resultado.writing2B,
                    Escrita3Bim = resultado.writing3B,
                    Escrita4Bim = resultado.writing4B,
                    Leitura1Bim = resultado.reading1B,
                    Leitura2Bim = resultado.reading2B,
                    Leitura3Bim = resultado.reading3B,
                    Leitura4Bim = resultado.reading4B
                };
            }
        }
    }
}