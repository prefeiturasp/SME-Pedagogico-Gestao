using System;

namespace SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO
{
    public class TurmasDoAlunoDTO
    {
        public int AnoLetivo { get; set; }
        public string NomeAluno { get; set; }
        public string NomeSocialAluno { get; set; }
        public int CodigoSituacaoMatricula { get; set; }
        public string SituacaoMatricula { get; set; }
        public string DataNascimento { get; set; }
        public int CodigoTurma { get; set; }
    }
}