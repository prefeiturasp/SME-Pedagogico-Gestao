using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.Integracao.DTO
{
    public class AlunoNaTurmaDTO
    {
        public int CodigoAluno { get; set; }
        public string NomeAluno { get; set; }
        public string DataNascimento { get; set; }
        public string NomeSocialAluno { get; set; }
        public int CodigoSituacaoMatricula { get; set; }
        public string SituacaoMatricula { get; set; }
        public string DataSituacao { get; set; }
        public int NumeroAlunoChamada { get; set; }
        public bool PossuiDeficiencia { get; set; }
    }
}
