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

        public async Task InsertPollCM(List<SondagemMatematicaOrdemDTO> dadosSondagem)
        {
            using (Contexts.SMEManagementContext db = new Contexts.SMEManagementContext())
            {
                foreach (var student in dadosSondagem)
                {

                    var studentPoolCM = db.MathPoolCMs.Where(x =>
                    x.TurmaEolCode == student.AnoTurma &&
                     x.AlunoEolCode == student.CodigoEolAluno).FirstOrDefault();

                    if (studentPoolCM == null)
                    {
                        studentPoolCM = new MathPoolCM();

                        studentPoolCM.AlunoEolCode = student.CodigoEolAluno;
                        studentPoolCM.DreEolCode = student.CodigoEolDRE;
                        studentPoolCM.EscolaEolCode = student.CodigoEolEscola;
                        studentPoolCM.AnoTurma = Convert.ToInt32(student.AnoTurma);
                        studentPoolCM.TurmaEolCode = student.AnoTurma;
                        studentPoolCM.AnoLetivo = Convert.ToInt32(student.AnoLetivo);


                        MapValuesPoolCM(student, studentPoolCM);
                        await db.PortuguesePolls.AddAsync(studentPoolCM);

                    }

                    else
                    {
                        MapValuesPollPortuguese(student, studentPoolCM);
                        db.PortuguesePolls.Update(studentPoolCM);
                    }
                }

                await db.SaveChangesAsync();
            }
        }

        private void MapValuesPoolCM(SondagemMatematicaOrdemDTO student, MathPoolCM studentPoolCM)
        {
            throw new NotImplementedException();
        }
    }
}
