using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.Contexts;
using SME.Pedagogico.Gestao.WebApp.Models.Poll;
using SME.Pedagogico.Gestao.Models.Academic;
using System.Collections.Generic;
using System.Threading.Tasks;
using SME.Pedagogico.Gestao.WebApp.Models;
using SME.Pedagogico.Gestao.WebApp.Models.ClassRoom;
using System.Linq;
using SME.Pedagogico.Gestao.Data.DataTransfer;

namespace SME.Pedagogico.Gestao.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PollPortugueseController : ControllerBase
    {

        [HttpPost]
        public async Task<ActionResult> IncluirSondagemPortugues(List<StudentPollPortuguese> ListStudentPollPortuguese)
        {
            

            try
            {
                var BusinessPollPortuguese = new Data.Business.PollPortuguese();
                BusinessPollPortuguese.InsertPollPortuguese(ListStudentPollPortuguese);

                //var ListdataStudentPoll = new List<PortuguesePoll>();

                //foreach (var student in ListStudentPollPortuguese)
                //{
                //    var dataStudentPoll = new PortuguesePoll();
                //    dataStudentPoll.dreCodeEol = student.dreCodeEol;
                //    dataStudentPoll.schoolCodeEol = student.schoolCodeEol;
                //    dataStudentPoll.classroomCodeEol = student.classroomCodeEol;
                //    dataStudentPoll.yearClassroom = student.yearClassroom;
                //    dataStudentPoll.writing1B = student.t1e;
                //    dataStudentPoll.reading1B = student.t1l;
                //    dataStudentPoll.writing2B = student.t2e;
                //    dataStudentPoll.reading2B = student.t2l;
                //    dataStudentPoll.writing3B = student.t3e;
                //    dataStudentPoll.reading3B = student.t3l;
                //    dataStudentPoll.writing4B = student.t4e;
                //    dataStudentPoll.reading4B = student.t4l;

                //    ListdataStudentPoll.Add(dataStudentPoll);
                //}

             

                //BusinessPollPortuguese.InsertPollPortuguese(ListdataStudentPoll);

                return (Ok());
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }

        [HttpPost]
        public async Task<ActionResult> ListarSondagemPortugues(ClassRoomModel classRoomModel)
        {
            try
            {
                var classRoomDataTransfer = new ClassRoomFilter()
                {
                    classroomCodeEol = classRoomModel.classroomCodeEol,
                    dreCodeEol = classRoomModel.dreCodeEol,
                    schoolCodeEol = classRoomModel.schoolCodeEol,
                    schoolYear = classRoomModel.schoolYear,
                    yearClassroom = classRoomModel.yearClassroom
                };

                var BusinessPoll = new Data.Business.PollPortuguese();
                var ListStudentPollPortuguese = BusinessPoll.ListStudentPollPortuguese(classRoomDataTransfer);

                return (Ok(ListStudentPollPortuguese));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        private static void AddStudentPollPortuguese(Data.Business.StudentClassRoom studentClassRoom, StudentPollPortuguese studentDTO)
        {
            studentDTO.name = studentClassRoom.nomeAluno;
            studentDTO.sequenceNumber = studentClassRoom.numeroAlunoChamada;
            studentDTO.schoolCodeEol = studentClassRoom.codigoAluno;
            studentDTO.t1e = string.Empty;
            studentDTO.t1l = string.Empty;
            studentDTO.t2e = string.Empty;
            studentDTO.t2l = string.Empty;
            studentDTO.t3e = string.Empty;
            studentDTO.t3l = string.Empty;
            studentDTO.t4e = string.Empty;
            studentDTO.t4l = string.Empty;
        }
    }
}






////ListaDTO que retorna pra tela;
//var ListStudentPollPortugueseDTO = new List<StudentPollPortuguese>();

////Pega alunos daquela turma que possuem sondagem 
//// ADD ano letivo no where
//var listStudentsPollPortuguese = _db.PortuguesePolls.Where(x => x.classroomCodeEol == classRoom.classroomCodeEol).ToList();



//var listStudentsClassRoom = studentsClassRoom.MockListaChamada();


//                foreach (var studentClassRoom in listStudentsClassRoom)
//                {
//                    var studentDTO = new StudentPollPortuguese();
//                    if (listStudentsPollPortuguese != null)
//                    {
//                        foreach (var studentPortuguese in listStudentsPollPortuguese)
//                        {
//                            if (studentPortuguese.schoolCodeEol == studentClassRoom.codigoAluno)
//                            {
//                                studentDTO.name = studentClassRoom.nomeAluno;
//                                studentDTO.schoolCodeEol = studentClassRoom.codigoAluno;
//                                studentDTO.sequenceNumber = studentClassRoom.numeroAlunoChamada;
//                                studentDTO.t1e = studentPortuguese.writing1B;
//                                studentDTO.t1l = studentPortuguese.reading1B;
//                                studentDTO.t2e = studentPortuguese.writing2B;
//                                studentDTO.t2l = studentPortuguese.reading2B;
//                                studentDTO.t3e = studentPortuguese.writing3B;
//                                studentDTO.t3l = studentPortuguese.reading3B;
//                                studentDTO.t4e = studentPortuguese.writing4B;
//                                studentDTO.t4l = studentPortuguese.reading4B;
//                            }

//                            else
//                            {
//                                AddStudentPollPortuguese(studentClassRoom, studentDTO);
//                            }

//                        }
//                    }

//                    else
//                    {
//                        AddStudentPollPortuguese(studentClassRoom, studentDTO);
//                    }

//                    ListStudentPollPortugueseDTO.Add(studentDTO);
//                }

//                return Ok(ListStudentPollPortugueseDTO);