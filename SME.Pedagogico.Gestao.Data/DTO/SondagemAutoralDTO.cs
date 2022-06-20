using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao
{
    public class SondagemAutoralDTO
    {
        public string SondagemId { get; set; }
        public string SondagemAlunoId { get; set; }
        public string SondagemAlunoRespostaId { get; set; }
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
