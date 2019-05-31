using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.DataTransfer;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Data.Functionalities;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using SME.Pedagogico.Gestao.Models.Academic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Data.Business
{
    public class PollMatematica
    {
        private string _token;

        public PollMatematica(IConfiguration config)
        {
            var createToken = new CreateToken(config);
            _token = createToken.CreateTokenProvisorio();
        }

        public List<MathPoolCA> BuscarAlunosTurmaRelatorioMatematicaCA(string turmaEol, string proficiencia, string bimestre)
        {
            try
            {
                var liststudentPoll = new List<StudentPollMatematica>();
                var listStudentsPoll = new List<MathPoolCA>();
                using (Contexts.SMEManagementContext db = new Contexts.SMEManagementContext())
                {
                    listStudentsPoll = db.MathPoolCAs.Where(x => x.TurmaEolCode == turmaEol && !string.IsNullOrEmpty(x.Ordem1Ideia)).ToList();


                }
                return listStudentsPoll;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
         
        public List<MathPoolCM> BuscarAlunosTurmaRelatorioMatematicaCM(string turmaEol, string proficiencia, string bimestre)
        {
            try
            {
                var liststudentPoll = new List<StudentPollMatematica>();
                var listStudentsPoll = new List<MathPoolCM>();
                using (Contexts.SMEManagementContext db = new Contexts.SMEManagementContext())
                {
                    listStudentsPoll = db.MathPoolCMs.Where(x => x.TurmaEolCode == turmaEol && !string.IsNullOrEmpty(x.Ordem4Ideia)).ToList(); 
                }
                return listStudentsPoll;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public List<MathPoolNumber> BuscarAlunosTurmaRelatorioMatematicaNumber(string turmaEol, string proficiencia, string bimestre)
        {
            try
            {
                var liststudentPoll = new List<StudentPollMatematica>();
                var listStudentsPoll = new List<MathPoolNumber>();
                using (Contexts.SMEManagementContext db = new Contexts.SMEManagementContext())
                {
                    listStudentsPoll = db.MathPoolNumbers.Where(x => x.TurmaEolCode == turmaEol && !string.IsNullOrEmpty(x.Opacos)).ToList();
                }
                return listStudentsPoll;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
