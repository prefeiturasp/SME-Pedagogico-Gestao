using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Models.Academic;

namespace SME.Pedagogico.Gestao.Data.Business
{
    public class SondagemMatematica
    {
        public IConfiguration _config;
        public SondagemMatematica(IConfiguration config)
        {

            _config = config;
        }

        public async Task InsertPoolCM(List<SondagemMatematicaOrdemDTO> dadosSondagem)
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

        public async Task<SondagemMatematicaOrdemDTO> ListPoolCM(FiltroSondagemMatematicaDTO filtroSondagem)
        {
            throw new NotImplementedException();
        }

        public async Task InsertPoolNumeros(List<SondagemMatematicaNumerosDTO> dadosSondagem)
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

        public async Task InsertPoolCA(List<SondagemMatematicaOrdemDTO> dadosSondagem)
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
