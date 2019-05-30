using SME.Pedagogico.Gestao.Models.Base.Abstracts;

namespace SME.Pedagogico.Gestao.Models.Academic
{
    public class MathPoolCM : Table
    {
        public string DreEolCode { get; set; }
        public string NumeroChamada { get; set; }
        public string EscolaEolCode { get; set; }
        public string TurmaEolCode { get; set; }
        public string AlunoEolCode { get; set; }
        public int AnoLetivo { get; set; }
        public int AnoTurma { get; set; }
        public int Semestre { get; set; }
        public string Ordem4Ideia { get; set; }
        public string Ordem4Resultado { get; set; }
        public string Ordem5Ideia { get; set; }
        public string Ordem5Resultado { get; set; }
        public string Ordem6Ideia { get; set; }
        public string Ordem6Resultado { get; set; }
        public string Ordem7Ideia { get; set; }
        public string Ordem7Resultado { get; set; }
        public string Ordem8Ideia { get; set; }
        public string Ordem8Resultado { get; set; }
    }
}
