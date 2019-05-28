using SME.Pedagogico.Gestao.Models.Base.Abstracts;

namespace SME.Pedagogico.Gestao.Models.Academic
{
    public class MathPoolCA : Table
    {
        public string DreEolCode { get; set; }
        public string NumeroChamada { get; set; }
        public string EscolaEolCode { get; set; }
        public string TurmaEolCode { get; set; }
        public string AlunoEolCode { get; set; }
        public int AnoLetivo { get; set; }
        public int AnoTurma { get; set; }
        public int SemestreCode { get; set; }
        public virtual Semester Semestre { get; set; }
        public string Ordem1Ideia { get; set; }
        public string Ordem1Resultado { get; set; }
        public string Ordem2Ideia { get; set; }
        public string Ordem2Resultado { get; set; }
        public string Ordem3Ideia { get; set; }
        public string Ordem3Resultado { get; set; }
        public string Ordem4Ideia { get; set; }
        public string Ordem4Resultado { get; set; }
    }
}
