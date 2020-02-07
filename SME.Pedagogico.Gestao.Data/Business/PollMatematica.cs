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

        public List<MathPoolCA> BuscarAlunosTurmaRelatorioMatematicaCA(string turmaEol, string proficiencia, string term)
        {
            var liststudentPoll = new List<StudentPollMatematica>();
            var listStudentsPoll = new List<MathPoolCA>();
            using (Contexts.SMEManagementContextData db = new Contexts.SMEManagementContextData())
            {
                switch (term)
                {
                    case "1° Semestre":
                        listStudentsPoll = db.MathPoolCAs.Where(x => x.TurmaEolCode == turmaEol &&
                                x.Semestre.Equals(1)).ToList();
                        break;
                    case "2° Semestre":
                        listStudentsPoll = db.MathPoolCAs.Where(x => x.TurmaEolCode == turmaEol &&
                                x.Semestre.Equals(2)).ToList();
                        break;
                }
                return listStudentsPoll;
            }
        }

        public List<MathPoolCM> BuscarAlunosTurmaRelatorioMatematicaCM(string turmaEol, string proficiencia, string term)
        {
            var liststudentPoll = new List<StudentPollMatematica>();
            var listStudentsPoll = new List<MathPoolCM>();
            using (Contexts.SMEManagementContextData db = new Contexts.SMEManagementContextData())
            {
                switch (term)
                {
                    case "1° Semestre":
                        listStudentsPoll = db.MathPoolCMs.Where(x => x.TurmaEolCode == turmaEol &&
                        x.Semestre.Equals(1)).ToList();
                        break;
                    case "2° Semestre":
                        listStudentsPoll = db.MathPoolCMs.Where(x => x.TurmaEolCode == turmaEol &&
                       x.Semestre.Equals(2)).ToList();
                        break;

                }
                return listStudentsPoll;
            }
        }

        public List<MathPoolNumber> BuscarAlunosTurmaRelatorioMatematicaNumber(string turmaEol, string proficiencia, string term)
        {
            var liststudentPoll = new List<StudentPollMatematica>();
            var listStudentsPoll = new List<MathPoolNumber>();
            using (Contexts.SMEManagementContextData db = new Contexts.SMEManagementContextData())
            {
                switch (term)
                {
                    case "1° Semestre":
                        listStudentsPoll = db.MathPoolNumbers.Where(x => x.TurmaEolCode == turmaEol
                                          && x.Semestre.Equals(1)).ToList();

                        break;
                    case "2° Semestre":
                        listStudentsPoll = db.MathPoolNumbers.Where(x => x.TurmaEolCode == turmaEol &&
                                           x.Semestre.Equals(2)).ToList();

                        break;
                    default:
                        break;
                }
            }
            return listStudentsPoll;
        }
    }
}
