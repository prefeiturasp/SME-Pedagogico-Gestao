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
                            var newStudentPoolCM = new MathPoolCM();
                            newStudentPoolCM.AlunoEolCode = student.CodigoEolAluno;
                            newStudentPoolCM.DreEolCode = student.CodigoEolDRE;
                            newStudentPoolCM.EscolaEolCode = student.CodigoEolEscola;
                            newStudentPoolCM.AnoTurma = Convert.ToInt32(student.AnoTurma);
                            newStudentPoolCM.TurmaEolCode = student.CodigoEolTurma;
                            newStudentPoolCM.AnoLetivo = Convert.ToInt32(student.AnoLetivo);
                            newStudentPoolCM.Semestre = semestre;

                            MapValuesPoolCM(student, ref newStudentPoolCM, semestre);
                            await db.MathPoolCMs.AddAsync(newStudentPoolCM);
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
            studentPoolCM.Semestre = semestre;

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
                            studentDTO.AnoLetivo = filtroSondagem.AnoTurma;
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
                            studentDTO.AnoLetivo = filtroSondagem.AnoTurma;
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
                                        studentDTO.Ideia3Semestre1 = studentPollMath.Ordem3Ideia;
                                        studentDTO.Ideia4Semestre1 = studentPollMath.Ordem4Ideia;
                                        studentDTO.Resultado1Semestre1 = studentPollMath.Ordem1Resultado;
                                        studentDTO.Resultado2Semestre1 = studentPollMath.Ordem2Resultado;
                                        studentDTO.Resultado3Semestre1 = studentPollMath.Ordem3Resultado;
                                        studentDTO.Resultado4Semestre1 = studentPollMath.Ordem4Resultado;
                                    }
                                    else if (semestre.Equals(2))
                                    {
                                        studentDTO.Ideia1Semestre2 = studentPollMath.Ordem1Ideia;
                                        studentDTO.Ideia2Semestre2 = studentPollMath.Ordem2Ideia;
                                        studentDTO.Ideia3Semestre2 = studentPollMath.Ordem3Ideia;
                                        studentDTO.Ideia4Semestre2 = studentPollMath.Ordem4Ideia;
                                        studentDTO.Resultado1Semestre2 = studentPollMath.Ordem1Resultado;
                                        studentDTO.Resultado2Semestre2 = studentPollMath.Ordem2Resultado;
                                        studentDTO.Resultado3Semestre2 = studentPollMath.Ordem3Resultado;
                                        studentDTO.Resultado4Semestre2 = studentPollMath.Ordem4Resultado;
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
                return retornoSondagem;
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
                            studentDTO.AnoLetivo = filtroSondagem.AnoTurma;
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
                return retornoSondagem;
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
            studentDTO.Familiares2S = string.Empty;
            studentDTO.Opacos2S = string.Empty;
            studentDTO.Processo2S = string.Empty;
            studentDTO.TerminamZero2S = string.Empty;
            studentDTO.Transparentes2S = string.Empty;
            studentDTO.ZeroIntercalados2S = string.Empty;
        }

        private void AddEmptyCAPoolTo(SondagemMatematicaOrdemDTO studentDTO)
        {
            studentDTO.Ideia1Semestre1 = string.Empty;
            studentDTO.Ideia2Semestre1 = string.Empty;
            studentDTO.Ideia3Semestre1 = string.Empty;
            studentDTO.Ideia4Semestre1 = string.Empty;
            studentDTO.Resultado1Semestre1 = string.Empty;
            studentDTO.Resultado2Semestre1 = string.Empty;
            studentDTO.Resultado3Semestre1 = string.Empty;
            studentDTO.Resultado4Semestre1 = string.Empty;
            studentDTO.Ideia1Semestre2 = string.Empty;
            studentDTO.Ideia2Semestre2 = string.Empty;
            studentDTO.Ideia3Semestre2 = string.Empty;
            studentDTO.Ideia4Semestre2 = string.Empty;
            studentDTO.Resultado1Semestre2 = string.Empty;
            studentDTO.Resultado2Semestre2 = string.Empty;
            studentDTO.Resultado3Semestre2 = string.Empty;
            studentDTO.Resultado4Semestre2 = string.Empty;
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

                    for (int semestre = 1; semestre <= 2; semestre++)
                    {
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

                            MapValuesPoolNumbers(student, ref newStudentPoolNumeros, semestre);
                            await db.MathPoolNumbers.AddAsync(newStudentPoolNumeros);
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
            studentPoolNumeros.Semestre = semestre;

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
                            var newStudentPoolCA = new MathPoolCA();
                            newStudentPoolCA.AlunoEolCode = student.CodigoEolAluno;
                            newStudentPoolCA.DreEolCode = student.CodigoEolDRE;
                            newStudentPoolCA.EscolaEolCode = student.CodigoEolEscola;
                            newStudentPoolCA.AnoTurma = Convert.ToInt32(student.AnoTurma);
                            newStudentPoolCA.TurmaEolCode = student.CodigoEolTurma;
                            newStudentPoolCA.AnoLetivo = Convert.ToInt32(student.AnoLetivo);
                            newStudentPoolCA.Semestre = semestre;

                            MapValuesPoolCA(student, ref newStudentPoolCA, semestre);
                            await db.MathPoolCAs.AddAsync(newStudentPoolCA);
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
            studentPoolCA.Semestre = semestre;

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
