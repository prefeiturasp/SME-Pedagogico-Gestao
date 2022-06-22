using System;

namespace SME.Pedagogico.Gestao
{
    public class SondagemAutoralDTO
    {
        public Guid SondagemId { get; set; }
        public Guid SondagemAlunoId { get; set; }
        public Guid SondagemAlunoRespostaId { get; set; }
        public int AnoLetivo { get; set; }
        public int AnoTurma { get; set; }
        public string CodigoAluno { get; set; }
        public string NomeAluno { get; set; }
        public string ComponenteCurricular { get; set; }
        public string CodigoUe { get; set; }
        public string CodigoDre { get; set; }
        public string CodigoTurma { get; set; }
        public string RespostaId { get; set; }
        public string PerguntaId { get; set; }
        public string PeriodoId { get; set; }
        public int Bimestre { get; set; }
    }
}
