using System;
using System.Collections.Generic;
using System.Text;
using SME.Pedagogico.Gestao.Models.Base.Abstracts;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class OrdemPergunta
    {

        public string Id { get; set; }
        public int SequenciaOrdem { get; set; }
        public string PerguntaId { get; set; }
        public virtual Pergunta Pergunta { get; set; }
        public bool Excluido { get; set; }
    }
}
