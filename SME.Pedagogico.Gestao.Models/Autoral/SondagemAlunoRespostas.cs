using System;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class SondagemAlunoRespostas 
    {
        public Guid Id
        {
            get; set;
        }
        public virtual SondagemAluno SondagemAluno { get; set; }
        public Guid SondagemAlunoId { get; set; }
        public virtual Pergunta Pergunta { get; set; }
        public string PerguntaId { get; set; }
        public virtual Resposta Resposta { get; set; }
        public string RespostaId { get; set; }
        public int Bimestre { get; set; }
    }
}
