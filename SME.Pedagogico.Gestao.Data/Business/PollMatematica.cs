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

        public List<MathPoll> BuscarAlunosTurmaRelatorioMatematica(string turmaEol, string proficiencia, string bimestre)
        {
            try
            {
                var liststudentPoll = new List<StudentPollMatematica>();
                using (Contexts.SMEManagementContext db = new Contexts.SMEManagementContext())
                { 
                    if (proficiencia == "Campo Aditivo")
                    {
                        var listStudentsPoll = db.MathPoolCAs.Where(x => x.TurmaEolCode == turmaEol && !string.IsNullOrEmpty(x.Ordem1Ideia)).ToList();

                    }
                    else if (proficiencia == "Campo Multiplicativo")
                    {

                       var listStudentsPoll = db.MathPoolCMs.Where(x => x.TurmaEolCode == turmaEol && !string.IsNullOrEmpty(x.Ordem4Ideia)).ToList();

                    }
                    else if (proficiencia == "Números")
                    {

                       var  listStudentsPoll = db.MathPoolNumbers.Where(x => x.TurmaEolCode == turmaEol && !string.IsNullOrEmpty(x.Opacos)).ToList();

                    }

                    #region teste
                    /*
                    switch (bimestre)
                    {
                        case "1° Bimestre":
                            {
                                if (proficiencia == "Escrita")
                                {
                                    listStudentsPoll = db.MathPoolCAs.Where(x => x.classroomCodeEol == turmaEol && !string.IsNullOrEmpty(x.writing1B)).ToList();
                                }
                                else
                                {
                                    listStudentsPoll = db.PortuguesePolls.Where(x => x.classroomCodeEol == turmaEol && !string.IsNullOrEmpty(x.reading1B)).ToList();
                                }
                                break;
                            }
                        case "2° Bimestre":
                            {
                                if (proficiencia == "Escrita")
                                {
                                    listStudentsPoll = db.PortuguesePolls.Where(x => x.classroomCodeEol == turmaEol && !string.IsNullOrEmpty(x.writing2B)).ToList();
                                }
                                else
                                {
                                    listStudentsPoll = db.PortuguesePolls.Where(x => x.classroomCodeEol == turmaEol && !string.IsNullOrEmpty(x.reading2B)).ToList();
                                }
                                break;
                            }
                        case "3° Bimestre":
                            {
                                if (proficiencia == "Escrita")
                                {
                                    listStudentsPoll = db.PortuguesePolls.Where(x => x.classroomCodeEol == turmaEol && !string.IsNullOrEmpty(x.writing3B)).ToList();
                                }
                                else
                                {
                                    listStudentsPoll = db.PortuguesePolls.Where(x => x.classroomCodeEol == turmaEol && !string.IsNullOrEmpty(x.reading3B)).ToList();
                                }
                                break;
                            }
                        default:
                            if (proficiencia == "Escrita")
                            {
                                listStudentsPoll = db.PortuguesePolls.Where(x => x.classroomCodeEol == turmaEol && !string.IsNullOrEmpty(x.writing4B)).ToList();
                            }
                            else
                            {
                                listStudentsPoll = db.PortuguesePolls.Where(x => x.classroomCodeEol == turmaEol && !string.IsNullOrEmpty(x.reading4B)).ToList();
                            }
                            break;
                    }
                    */
                    #endregion

                    return listStudentsPoll;
                    //fazer order by por nome
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
