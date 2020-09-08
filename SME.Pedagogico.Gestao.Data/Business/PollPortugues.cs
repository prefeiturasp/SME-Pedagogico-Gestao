using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.Contexts;
using SME.Pedagogico.Gestao.Data.DataTransfer;
using SME.Pedagogico.Gestao.Data.DataTransfer.Portugues;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Data.DTO.Matematica;
using SME.Pedagogico.Gestao.Data.DTO.Portugues;
using SME.Pedagogico.Gestao.Data.Functionalities;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using SME.Pedagogico.Gestao.Models.Academic;
using SME.Pedagogico.Gestao.Models.Autoral;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Data.Business
{
    public class PollPortuguese
    {


        IMapper _mapper;

        private string _token;
        public PollPortuguese(IConfiguration config)
        {
            var createToken = new CreateToken(config);
            _token = createToken.CreateTokenProvisorio();

        }

        public async void InsertPollPortuguese(List<StudentPollPortuguese> ListStudentsModel)
        {
            using (Contexts.SMEManagementContextData db = new Contexts.SMEManagementContextData())
            {

                var listStudentsPoll = new List<PortuguesePoll>();

                foreach (var student in ListStudentsModel)
                {
                    var studentPollPortuguese = db.PortuguesePolls.Where(x =>
                    x.classroomCodeEol == student.classroomCodeEol &&
                     x.studentCodeEol == student.studentCodeEol).FirstOrDefault();

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
            try
            {
                var liststudentPollPortuguese = new List<StudentPollPortuguese>();
                using (Contexts.SMEManagementContextData db = new Contexts.SMEManagementContextData())
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

                    var listStudentsClassRoom = await turmApi.GetAlunosNaTurma(Convert.ToInt32(classRoom.classroomCodeEol), Convert.ToInt32(classRoom.schoolYear), _token);

                    listStudentsClassRoom = listStudentsClassRoom.Where(x => x.CodigoSituacaoMatricula == 10 || x.CodigoSituacaoMatricula == 1 || x.CodigoSituacaoMatricula == 6 || x.CodigoSituacaoMatricula == 13 || x.CodigoSituacaoMatricula == 5).ToList(); // 1 ativo,10 rematriculado,6-pendente de rematricula
                    if (listStudentsClassRoom == null)
                    {
                        return null;
                    }

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
            catch (Exception ex)
            {
                throw;
            }
        }

        //public async Task<> ListStudentPollPortugueseAutoral(FiltrosPortuguesAutoralDTO classRoom)
        //{
        //    using(var context = new Contexts.SMEManagementContextData())
        //    {
        //        context.Pe
        //    }


        //}
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

        public async Task<List<PortuguesePoll>> BuscarAlunosTurmaRelatorioPortugues(string turmaEol, string proficiencia, string bimestre)
        {
            try
            {
                var liststudentPollPortuguese = new List<StudentPollPortuguese>();
                using (Contexts.SMEManagementContextData db = new Contexts.SMEManagementContextData())
                {
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

                    //return listStudentsPollPortuguese;
                    return listStudentsPollPortuguese.OrderBy(a => a.studentNameEol).ToList();
                    //fazer order by por nome
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PollReportPortugueseResult> BuscarDadosRelatorioPortugues(string proficiencia, string bimestre, string anoLetivo, string codigoDre, string codigoEscola, string codigoCurso)
        {

            using (Contexts.SMEManagementContextData db = new Contexts.SMEManagementContextData())
            {
                var lista = db.PeriodoDeAberturas;
            }


            var liststudentPollPortuguese = new List<StudentPollPortuguese>();

            var listReturn = new List<PollReportPortugueseItem>();

            using (Contexts.SMEManagementContextData db = new Contexts.SMEManagementContextData())
            {
                var listStudentsPollPortuguese = new List<Models.Academic.PortuguesePoll>();
                IQueryable<PortuguesePoll> query = db.Set<PortuguesePoll>();

                query = db.PortuguesePolls.Where(x => x.schoolYear == anoLetivo);

                //montando filtros genericamente
                if (!string.IsNullOrWhiteSpace(codigoDre))
                    query = query.Where(u => u.dreCodeEol == codigoDre);

                if (!string.IsNullOrWhiteSpace(codigoEscola))
                    query = query.Where(u => u.schoolCodeEol == codigoEscola);

                if (!string.IsNullOrWhiteSpace(codigoCurso))
                    query = query.Where(u => u.yearClassroom == codigoCurso);

                List<SME.Pedagogico.Gestao.Data.DTO.PortChartDataModel> graficos = new List<SME.Pedagogico.Gestao.Data.DTO.PortChartDataModel>();

                switch (bimestre)
                {
                    case "1° Bimestre":
                        {
                            if (proficiencia == "Escrita")
                            {
                                var writing1B = query.GroupBy(fu => fu.writing1B).Select(g => new { Label = g.Key, Value = g.Count() }).ToList();

                                foreach (var item in writing1B)
                                {
                                    if (!item.Label.Trim().Equals(""))
                                    {
                                        PollReportPortugueseItem itemRetorno = new PollReportPortugueseItem();
                                        itemRetorno.OptionName = MontarTextoProficiencia(item.Label);
                                        itemRetorno.studentQuantity = item.Value;
                                        listReturn.Add(itemRetorno);

                                        graficos.Add(new SME.Pedagogico.Gestao.Data.DTO.PortChartDataModel()
                                        {
                                            Name = MontarTextoProficiencia(item.Label),
                                            Value = item.Value
                                        });
                                    }
                                }
                            }

                            else //leitura
                            {
                                var reading1B = query.GroupBy(fu => fu.reading1B).Select(g => new { Label = g.Key, Value = g.Count() }).ToList();

                                foreach (var item in reading1B)
                                {
                                    if (!item.Label.Trim().Equals(""))
                                    {
                                        PollReportPortugueseItem itemRetorno = new PollReportPortugueseItem();
                                        itemRetorno.OptionName = MontarTextoProficiencia(item.Label);
                                        itemRetorno.studentQuantity = item.Value;
                                        listReturn.Add(itemRetorno);

                                        graficos.Add(new SME.Pedagogico.Gestao.Data.DTO.PortChartDataModel()
                                        {
                                            Name = MontarTextoProficiencia(item.Label),
                                            Value = item.Value
                                        });
                                    }
                                }
                            }
                        }
                        break;
                    case "2° Bimestre":
                        {
                            if (proficiencia == "Escrita")
                            {
                                var writing2B = query.GroupBy(fu => fu.writing2B).Select(g => new { Label = g.Key, Value = g.Count() }).ToList();

                                foreach (var item in writing2B)
                                {
                                    if (!item.Label.Trim().Equals(""))
                                    {
                                        PollReportPortugueseItem itemRetorno = new PollReportPortugueseItem();
                                        itemRetorno.OptionName = MontarTextoProficiencia(item.Label);
                                        itemRetorno.studentQuantity = item.Value;
                                        listReturn.Add(itemRetorno);

                                        graficos.Add(new SME.Pedagogico.Gestao.Data.DTO.PortChartDataModel()
                                        {
                                            Name = MontarTextoProficiencia(item.Label),
                                            Value = item.Value
                                        });
                                    }
                                }

                            }
                            else //leitura
                            {
                                var reading2B = query.GroupBy(fu => fu.reading2B).Select(g => new { Label = g.Key, Value = g.Count() }).ToList();

                                foreach (var item in reading2B)
                                {
                                    if (!item.Label.Trim().Equals(""))
                                    {
                                        PollReportPortugueseItem itemRetorno = new PollReportPortugueseItem();
                                        itemRetorno.OptionName = MontarTextoProficiencia(item.Label);
                                        itemRetorno.studentQuantity = item.Value;
                                        listReturn.Add(itemRetorno);

                                        graficos.Add(new SME.Pedagogico.Gestao.Data.DTO.PortChartDataModel()
                                        {
                                            Name = MontarTextoProficiencia(item.Label),
                                            Value = item.Value
                                        });
                                    }
                                }
                            }
                        }
                        break;
                    case "3° Bimestre":
                        {
                            if (proficiencia == "Escrita")
                            {
                                var writing3B = query.GroupBy(fu => fu.writing3B).Select(g => new { Label = g.Key, Value = g.Count() }).ToList();

                                foreach (var item in writing3B)
                                {
                                    if (!item.Label.Trim().Equals(""))
                                    {
                                        PollReportPortugueseItem itemRetorno = new PollReportPortugueseItem();
                                        itemRetorno.OptionName = MontarTextoProficiencia(item.Label);
                                        itemRetorno.studentQuantity = item.Value;
                                        listReturn.Add(itemRetorno);

                                        graficos.Add(new SME.Pedagogico.Gestao.Data.DTO.PortChartDataModel()
                                        {
                                            Name = MontarTextoProficiencia(item.Label),
                                            Value = item.Value
                                        });
                                    }
                                }

                            }
                            else //leitura
                            {
                                var reading3B = query.GroupBy(fu => fu.reading3B).Select(g => new { Label = g.Key, Value = g.Count() }).ToList();

                                foreach (var item in reading3B)
                                {
                                    if (!item.Label.Trim().Equals(""))
                                    {
                                        PollReportPortugueseItem itemRetorno = new PollReportPortugueseItem();
                                        itemRetorno.OptionName = MontarTextoProficiencia(item.Label);
                                        itemRetorno.studentQuantity = item.Value;
                                        listReturn.Add(itemRetorno);

                                        graficos.Add(new SME.Pedagogico.Gestao.Data.DTO.PortChartDataModel()
                                        {
                                            Name = MontarTextoProficiencia(item.Label),
                                            Value = item.Value
                                        });
                                    }
                                }
                            }
                        }
                        break;
                    case "4° Bimestre":
                        {
                            if (proficiencia == "Escrita")
                            {
                                var writing4B = query.GroupBy(fu => fu.writing4B).Select(g => new { Label = g.Key, Value = g.Count() }).ToList();

                                foreach (var item in writing4B)
                                {
                                    if (!item.Label.Trim().Equals(""))
                                    {
                                        PollReportPortugueseItem itemRetorno = new PollReportPortugueseItem();
                                        itemRetorno.OptionName = MontarTextoProficiencia(item.Label);
                                        itemRetorno.studentQuantity = item.Value;
                                        listReturn.Add(itemRetorno);

                                        graficos.Add(new SME.Pedagogico.Gestao.Data.DTO.PortChartDataModel()
                                        {
                                            Name = MontarTextoProficiencia(item.Label),
                                            Value = item.Value
                                        });
                                    }
                                }

                            }
                            else //leitura
                            {
                                var reading4B = query.GroupBy(fu => fu.reading4B).Select(g => new { Label = g.Key, Value = g.Count() }).ToList();

                                foreach (var item in reading4B)
                                {
                                    if (!item.Label.Trim().Equals(""))
                                    {
                                        PollReportPortugueseItem itemRetorno = new PollReportPortugueseItem();
                                        itemRetorno.OptionName = MontarTextoProficiencia(item.Label);
                                        itemRetorno.studentQuantity = item.Value;
                                        listReturn.Add(itemRetorno);

                                        graficos.Add(new SME.Pedagogico.Gestao.Data.DTO.PortChartDataModel()
                                        {
                                            Name = MontarTextoProficiencia(item.Label),
                                            Value = item.Value
                                        });
                                    }
                                }
                            }
                        }
                        break;

                }

                int total = 0;
                foreach (var item in listReturn)
                {
                    total += item.studentQuantity;
                }

                foreach (var item in listReturn)
                {
                    item.StudentPercentage = (double)item.studentQuantity / (double)total * 100;
                }

                SME.Pedagogico.Gestao.Data.DTO.PollReportPortugueseResult retorno = new PollReportPortugueseResult();
                retorno.Results = listReturn;

                var listaGrafico = graficos.GroupBy(fu => fu.Name).Select(g => new { Label = g.Key, Value = g.Sum(soma => soma.Value) }).ToList();
                graficos = new List<SME.Pedagogico.Gestao.Data.DTO.PortChartDataModel>();
                foreach (var item in listaGrafico)
                {
                    graficos.Add(new SME.Pedagogico.Gestao.Data.DTO.PortChartDataModel()
                    {
                        Name = item.Label,
                        Value = item.Value
                    });
                }
                retorno.ChartData = graficos;

                return retorno;
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

                    if (grupoDto.Ordem.Count > 0)
                        grupoDto.Ordem.OrderBy(x => x.Ordenacao);

                    ListaGrupos.Add(grupoDto);

                }

                return ListaGrupos.OrderBy(x => x.Descricao);


            }
        }

        public IEnumerable<GrupoOrdem> ListarOrdens()
        {
            using (var contexto = new SMEManagementContextData())
            {
                return contexto.GrupoOrdem.Include(x => x.Ordem).ToList();
            }
        }

        public ComponenteCurricular RetornaComponenteCurricularPortugues()
        {
            using (var contexto = new SMEManagementContextData())
            {
                return contexto.ComponenteCurricular.Where(x => x.Descricao == "Língua portuguesa").FirstOrDefault();
            }
        }

        public IEnumerable<PeriodoDto> RetornaPeriodosBimestres()
        {
            using (var contexto = new SMEManagementContextData())
            {
                var peridos = contexto.Periodo.Where(x => x.TipoPeriodo == Models.Enums.TipoPeriodoEnum.Bimestre).ToList();
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

        public async Task<IEnumerable<AlunoSondagemPortuguesDTO>> ListarAlunosPortuguesAutoral(FiltrarListagemDto filtrarListagemDto)
        {
             IList<SondagemAutoral> autoral = await ObterSondagemPortuguesAutoral(filtrarListagemDto);
            var endpointsAPI = new EndpointsAPI();

            var turmApi = new TurmasAPI(endpointsAPI);

            var alunos = await turmApi.GetAlunosNaTurma(Convert.ToInt32(filtrarListagemDto.CodigoTurma), filtrarListagemDto.AnoLetivo, _token);

            if (alunos == null || !alunos.Any())
                throw new Exception($"Não encontrado alunos para a turma {filtrarListagemDto.CodigoTurma} do ano letivo {filtrarListagemDto.AnoLetivo}");

            var listagem = new List<AlunoSondagemPortuguesDTO>();

            foreach (var aluno in autoral)
                MapearAlunosListagem(listagem, aluno);

            AdicionarAlunosEOL(filtrarListagemDto.AnoEscolar, filtrarListagemDto.AnoLetivo, filtrarListagemDto.CodigoDre, filtrarListagemDto.CodigoUe, filtrarListagemDto.CodigoTurma, filtrarListagemDto.ComponenteCurricular, alunos, listagem);

            return listagem.OrderBy(x => x.NumeroChamada);
        }

        private void AdicionarAlunosEOL(int anoEscolar, int anoLetivo, string codigoDre, string codigoUe, string codigoTurma, Guid componenteCurricular, List<AlunosNaTurmaDTO> alunos, List<AlunoSondagemPortuguesDTO> listagem)
        {
            alunos.ForEach(aluno =>
            {
                var alunoBanco = listagem.FirstOrDefault(x => x.CodigoAluno.Equals(aluno.CodigoAluno.ToString()));

                if (alunoBanco != null)
                {
                    alunoBanco.NumeroChamada = aluno.NumeroAlunoChamada;
                    return;
                }

                listagem.Add(new AlunoSondagemPortuguesDTO
                {
                    CodigoAluno = aluno.CodigoAluno.ToString(),
                    AnoLetivo = anoLetivo,
                    AnoTurma = anoEscolar,
                    CodigoDre = codigoDre,
                    CodigoTurma = codigoTurma,
                    CodigoUe = codigoUe,
                    NumeroChamada = aluno.NumeroAlunoChamada,
                    ComponenteCurricular = componenteCurricular.ToString(),
                    NomeAluno = aluno.NomeAluno,
                    
                });;

                listagem.OrderBy(x => x.NumeroChamada);
            });
        }

        private void MapearAlunosListagem(List<AlunoSondagemPortuguesDTO> listagem, SondagemAutoral aluno)
        {
            var indexAluno = listagem.FindIndex(x => x.CodigoAluno.Equals(aluno.CodigoAluno.ToString()));

            if (indexAluno >= 0)
                AdicionarRespostaAluno(aluno, listagem, indexAluno);
            else
                AdicionarNovoAlunoListagem(listagem, aluno);
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

        private void AdicionarNovoAlunoListagem(List<AlunoSondagemPortuguesDTO> listagem, SondagemAutoral aluno)
        {
            listagem.Add(new AlunoSondagemPortuguesDTO
            {
                Id = aluno.Id,
                CodigoAluno = aluno.CodigoAluno,
                NomeAluno = aluno.NomeAluno,
                AnoLetivo = aluno.AnoLetivo,
                AnoTurma = aluno.AnoTurma,
                CodigoDre = aluno.CodigoDre,
                CodigoTurma = aluno.CodigoTurma,
                CodigoUe = aluno.CodigoUe,
                ComponenteCurricular = aluno.ComponenteCurricularId,
                GrupoId = aluno.GrupoId,
                OrdermId = aluno.OrdemId,
                SequenciaOrdemSalva = aluno.SequenciaDeOrdemSalva,
                Respostas = new List<AlunoRespostaDto>()
                {
                    new AlunoRespostaDto
                    {
                        PeriodoId = aluno.PeriodoId,
                        Pergunta = aluno.PerguntaId,
                        Resposta = aluno.RespostaId
                    }
                }
            });
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

        public void SalvarSondagemAutoralPortugues(IEnumerable<AlunoSondagemPortuguesDTO> ListaAlunosSondagemDto)
        {
            if (ListaAlunosSondagemDto == null || !ListaAlunosSondagemDto.Any())
                throw new Exception("É necessário realizar a sondagem de pelo menos 1 aluno");
            using (var contexto = new SMEManagementContextData())
            {
                SalvarAluno(ListaAlunosSondagemDto, contexto);

                contexto.SaveChanges();
            }            
        }
        private void SalvarAluno(IEnumerable<AlunoSondagemPortuguesDTO> ListaAlunoSondagemPortuguesDTO, SMEManagementContextData contexto)
        {
            foreach (var aluno in ListaAlunoSondagemPortuguesDTO)
            {
                var alunoAutoral = (SondagemAutoral)aluno;

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
    }


}

