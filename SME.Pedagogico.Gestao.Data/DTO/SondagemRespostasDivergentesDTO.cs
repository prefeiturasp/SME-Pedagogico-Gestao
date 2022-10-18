using System;

namespace SME.Pedagogico.Gestao.Data
{
    public class SondagemRespostasDivergentesDTO
    {
        public string CodigoTurma { get; set; }
        public string CodigoAluno { get; set; }
        public string PerguntaId { get; set; }
        public string ComponenteCurricularId { get; set; }
        public Guid SondagemAlunoId { get; set; }
    }
}
