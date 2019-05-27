using SME.Pedagogico.Gestao.Models.Base.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Models.Academic
{
    public class MathPoolOrderData : Table
    {
        public string DreEolCode { get; set; }
        public string EscolaEolCode { get; set; }
        public string TurmaEolCode { get; set; }
        public string AlunoEolCode { get; set; }
        public int AnoLetivo { get; set; }
        public int YearClassroom { get; set; }
        public int SemestreCode { get; set; }
        public virtual Semester Semestre { get; set; }
        public string Ordem4Ideia { get; set; }
        public string Ordem4Resultado { get; set; }
        public string Ordem5Ideia { get; set; }
        public string Ordem5Resultado { get; set; }
        public string Ordem6Ideia { get; set; }
        public string Ordem6Resultado { get; set; }
    }
}
