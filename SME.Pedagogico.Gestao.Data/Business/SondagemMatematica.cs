using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.DTO;
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

                    var studentPoolCM = db.MathPoolCMs.Where(x =>
                    x.TurmaEolCode == student.AnoTurma &&
                     x.AlunoEolCode == student.CodigoEolAluno).FirstOrDefault();

                    for (int semestre = 1; semestre <= 2; semestre++)
                    {
                        if (studentPoolCM == null)
                        {
                            studentPoolCM = new MathPoolCM();
                            studentPoolCM.AlunoEolCode = student.CodigoEolAluno;
                            studentPoolCM.DreEolCode = student.CodigoEolDRE;
                            studentPoolCM.EscolaEolCode = student.CodigoEolEscola;
                            studentPoolCM.AnoTurma = Convert.ToInt32(student.AnoTurma);
                            studentPoolCM.TurmaEolCode = student.AnoTurma;
                            studentPoolCM.AnoLetivo = Convert.ToInt32(student.AnoLetivo);

                            MapValuesPoolCM(student, ref studentPoolCM, semestre);
                            await db.MathPoolCMs.AddAsync(studentPoolCM);
                        }
                        else
                        {
                            MapValuesPoolCM(student, ref studentPoolCM, semestre);
                            db.MathPoolCMs.Update(studentPoolCM);
                        }
                    }
                }

                await db.SaveChangesAsync();
            }
        }       

        private void MapValuesPoolCM(SondagemMatematicaOrdemDTO studentDTO, 
                                     ref MathPoolCM studentPoolCM, 
                                     int semestre)
        {
            studentPoolCM.Semestre = new Semester();
            studentPoolCM.Semestre.Value = semestre.ToString();

            if (semestre == 1) {
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
            } else if (semestre == 2) {
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

        public async Task<List<SondagemMatematicaOrdemDTO>> ListPoolCM(FiltroSondagemMatematicaDTO filtroSondagem)
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
                            studentDTO.AnoLetivo = filtroSondagem.AnoTurma;
                            studentDTO.CodigoEolDRE = filtroSondagem.DreEolCode;
                            studentDTO.CodigoEolEscola = filtroSondagem.EscolaEolCode;
                            studentDTO.AnoTurma = filtroSondagem.AnoTurma;

                            if (studentPollsMath?.Count > 0)
                            {
                                for (int semestre = 1; semestre <= db.Semesters.Count(); semestre++)
                                {
                                    var studentPollMath = studentPollsMath.ElementAt(semestre - 1);

                                    if (semestre.Equals(1))
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
                                    else if (semestre.Equals(2))
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
                            else
                            {
                                AddEmptyCMPoolTo(studentDTO);
                            }

                            retornoSondagem.Add(studentDTO);
                        }
                    }
                }
                return retornoSondagem;
            } catch (Exception)
            {
                throw;
            }
        }

        private void AddEmptyCMPoolTo(SondagemMatematicaOrdemDTO studentDTO)
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

        public async Task InsertPoolNumerosAsync(List<SondagemMatematicaNumerosDTO> dadosSondagem)
        {
            using (Contexts.SMEManagementContext db = new Contexts.SMEManagementContext())
            {
                foreach (var student in dadosSondagem)
                {

                    var studentPoolNumeros = db.MathPoolNumbers.Where(x =>
                    x.TurmaEolCode == student.AnoTurma &&
                     x.AlunoEolCode == student.CodigoEolAluno).FirstOrDefault();

                    for (int semestre = 1; semestre <= db.Semesters.Count(); semestre++)
                    {
                        if (studentPoolNumeros == null)
                        {
                            studentPoolNumeros = new MathPoolNumber();
                            studentPoolNumeros.AlunoEolCode = student.CodigoEolAluno;
                            studentPoolNumeros.DreEolCode = student.CodigoEolDRE;
                            studentPoolNumeros.EscolaEolCode = student.CodigoEolEscola;
                            studentPoolNumeros.AnoTurma = Convert.ToInt32(student.AnoTurma);
                            studentPoolNumeros.TurmaEolCode = student.AnoTurma;
                            studentPoolNumeros.AnoLetivo = Convert.ToInt32(student.AnoLetivo);

                            MapValuesPoolNumbers(student, ref studentPoolNumeros, semestre);
                            await db.MathPoolNumbers.AddAsync(studentPoolNumeros);
                        }
                        else
                        {

                            MapValuesPoolNumbers(student, ref studentPoolNumeros, semestre);
                            db.MathPoolNumbers.Update(studentPoolNumeros);
                        }
                    }
                }

                await db.SaveChangesAsync();
            }
        }

        private void MapValuesPoolNumbers(SondagemMatematicaNumerosDTO studentDTO, ref MathPoolNumber studentPoolNumeros, int semestre)
        {
            studentPoolNumeros.Semestre = new Semester();
            studentPoolNumeros.Semestre.Value = semestre.ToString();

            if (semestre == 1)
            {
                studentPoolNumeros.Familiares = studentDTO.Familiares1S;
                studentPoolNumeros.Opacos = studentDTO.Opacos1S;
                studentPoolNumeros.Transparentes = studentDTO.Transparentes1S;
                studentPoolNumeros.TerminamZero = studentDTO.TerminamZero1S;
                studentPoolNumeros.Algarismos = studentDTO.Algarismos1S;
                studentPoolNumeros.Processo = studentDTO.Processo1S;
                studentPoolNumeros.ZeroIntercalados = studentDTO.ZeroIntercalados1S;
            }
            else if (semestre == 2)
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

                    var studentPoolCA = db.MathPoolCAs.Where(x =>
                    x.TurmaEolCode == student.AnoTurma &&
                     x.AlunoEolCode == student.CodigoEolAluno).FirstOrDefault();

                    for (int semestre = 1; semestre <= 2; semestre++)
                    {
                        if (studentPoolCA == null)
                        {
                            studentPoolCA = new MathPoolCA();
                            studentPoolCA.AlunoEolCode = student.CodigoEolAluno;
                            studentPoolCA.DreEolCode = student.CodigoEolDRE;
                            studentPoolCA.EscolaEolCode = student.CodigoEolEscola;
                            studentPoolCA.AnoTurma = Convert.ToInt32(student.AnoTurma);
                            studentPoolCA.TurmaEolCode = student.AnoTurma;
                            studentPoolCA.AnoLetivo = Convert.ToInt32(student.AnoLetivo);

                            MapValuesPoolCA(student, ref studentPoolCA, semestre);
                            await db.MathPoolCAs.AddAsync(studentPoolCA);
                        }
                        else
                        {
                            MapValuesPoolCA(student, ref studentPoolCA, semestre);
                            db.MathPoolCAs.Update(studentPoolCA);
                        }
                    }
                }

                await db.SaveChangesAsync();
            }
        }

        private void MapValuesPoolCA(SondagemMatematicaOrdemDTO studentDTO, ref MathPoolCA studentPoolCA, int semestre)
        {
            studentPoolCA.Semestre = new Semester();
            studentPoolCA.Semestre.Value = semestre.ToString();

            if (semestre == 1)
            {
                studentPoolCA.Ordem1Ideia = studentDTO.Ideia1Semestre1;
                studentPoolCA.Ordem1Resultado = studentDTO.Resultado1Semestre1;
                studentPoolCA.Ordem2Ideia = studentDTO.Ideia2Semestre1;
                studentPoolCA.Ordem2Resultado = studentDTO.Resultado2Semestre1;
                studentPoolCA.Ordem3Ideia = studentDTO.Ideia3Semestre1;
                studentPoolCA.Ordem3Resultado = studentDTO.Resultado3Semestre1;
                studentPoolCA.Ordem4Ideia = studentDTO.Ideia4Semestre1;
                studentPoolCA.Ordem4Resultado = studentDTO.Resultado4Semestre1;
            }
            else if (semestre == 2)
            {
                studentPoolCA.Ordem1Ideia = studentDTO.Ideia1Semestre2;
                studentPoolCA.Ordem1Resultado = studentDTO.Resultado1Semestre2;
                studentPoolCA.Ordem2Ideia = studentDTO.Ideia2Semestre2;
                studentPoolCA.Ordem2Resultado = studentDTO.Resultado2Semestre2;
                studentPoolCA.Ordem3Ideia = studentDTO.Ideia3Semestre2;
                studentPoolCA.Ordem3Resultado = studentDTO.Resultado3Semestre2;
                studentPoolCA.Ordem4Ideia = studentDTO.Ideia4Semestre2;
                studentPoolCA.Ordem4Resultado = studentDTO.Resultado4Semestre2;
            }
        }
    }
}
