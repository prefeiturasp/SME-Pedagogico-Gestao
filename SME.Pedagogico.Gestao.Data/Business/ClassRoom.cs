using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.Business
{
    public class ClassRoom
    {
        public List<StudentClassRoom> MockListaChamada()
        {
            var ListStudantClassRoom = new List<StudentClassRoom>();


            var student = new StudentClassRoom();

            student.codigoAluno = "5848422";
            student.nomeAluno = "SAMILLE AIALA DE JESUS SANTOS";
            student.dataNascimento = DateTime.ParseExact("11/09/2011", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            student.nomeSocialAluno = null;
            student.codigoSituacaoMatricula = 1;
            student.situacaoMatricula = "Ativo";
            student.numeroAlunoChamada = "21";
            student.dataSituacao = DateTime.ParseExact("17/04/2019", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            student.possuiDeficiencia = false;

            var studant2 = new StudentClassRoom()
            {
                codigoAluno = "6003306",
                nomeAluno = "NATASHA MIRELLY DA COSTA SOUSA",
                dataNascimento = DateTime.ParseExact("19/03/2012", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                nomeSocialAluno = null,
                codigoSituacaoMatricula = 1,
                situacaoMatricula = "Ativo",
                dataSituacao = DateTime.ParseExact("17/04/2019", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                numeroAlunoChamada = "19",
                possuiDeficiencia = false,
            };

            var studant4 = new StudentClassRoom()
            {
                codigoAluno = "5882737",
                nomeAluno = "BEATRIZ FERREIRA LUCAS DAVELLI",
                dataNascimento = DateTime.ParseExact("19/01/2012", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                nomeSocialAluno = null,
                codigoSituacaoMatricula = 1,
                situacaoMatricula = "Ativo",
                dataSituacao = DateTime.ParseExact("17/04/2019", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                possuiDeficiencia = false,
                numeroAlunoChamada = "4",
            };
            var studant5 = new StudentClassRoom()
            {
                codigoAluno = "5959226",
                nomeAluno = "MARIANA GALIEGO ALVES",
                dataNascimento = DateTime.ParseExact("19/12/2011", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                nomeSocialAluno = null,
                codigoSituacaoMatricula = 1,
                situacaoMatricula = "Ativo",
                dataSituacao = DateTime.ParseExact("17/04/2019", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                possuiDeficiencia = false,
                numeroAlunoChamada = "14"
            };

            ListStudantClassRoom.Add(student);
            ListStudantClassRoom.Add(studant2);
            ListStudantClassRoom.Add(studant4);
            ListStudantClassRoom.Add(studant5);


            return ListStudantClassRoom;
        }

    }
    public class Student
    {
        public string Id { get; set; }
        public int Sequence { get; set; }
        public string Name { get; set; }
        public double Attendance { get; set; }
    }

    public class StudentClassRoom
    {
        public string codigoAluno { get; set; }
        public string nomeAluno { get; set; }
        public string nomeSocialAluno { get; set; }
        public DateTime dataNascimento { get; set; }
        public int codigoSituacaoMatricula { get; set; }
        public string situacaoMatricula { get; set; }
        public DateTime dataSituacao { get; set; }
        public string numeroAlunoChamada { get; set; }
        public bool possuiDeficiencia { get; set; }
        //public string NomeFrequencia { get; set; }
        //public bool AlunoRecemMatriculado { get; set; }
    }

}
