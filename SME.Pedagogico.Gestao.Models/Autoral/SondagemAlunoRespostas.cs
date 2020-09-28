using SME.Pedagogico.Gestao.Models.Base.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

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

    }
}
