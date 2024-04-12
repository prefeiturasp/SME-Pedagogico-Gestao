using Microsoft.EntityFrameworkCore.Internal;
using SME.Pedagogico.Gestao.Infra;
using System;
using System.Linq;

namespace SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO
{
    public class AlunosNaTurmaDTO
    {
        public int CodigoAluno { get; set; }
        public string NomeAluno { get; set; }
        public string NomeAlunoRelatorio
        {
            get
            {
                return AlunoInativo ? string.Format("{0} ({1} em {2})", NomeSocialAluno ?? NomeAluno, SituacaoMatricula, DataSituacao.ToString("dd/MM/yyyy")) : NomeSocialAluno ?? NomeAluno;
            }
        }
        public string DataNascimento { get; set; }
        public string NomeSocialAluno { get; set; }
        public int CodigoSituacaoMatricula { get; set; }
        public string SituacaoMatricula { get; set; }
        public DateTime DataSituacao { get; set; }
        public int NumeroAlunoChamada { get; set; }
        public bool PossuiDeficiencia { get; set; }
        public bool AlunoInativo
        {
            get
            {
                return Enum.GetValues(typeof(AlunoInativoEnum)).OfType<AlunoInativoEnum>().Any(x => Convert.ToInt32(x) == CodigoSituacaoMatricula);
            }
        }
    }
}
