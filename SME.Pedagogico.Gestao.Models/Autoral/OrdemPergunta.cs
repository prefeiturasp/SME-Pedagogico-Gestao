using System;
using System.Collections.Generic;
using System.Text;
using SME.Pedagogico.Gestao.Models.Base.Abstracts;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class OrdemPergunta : Table
    {
        public virtual Ordem Ordem { get; set; }
        public virtual Pergunta Pergunta { get; set; }
        public bool Excluido { get; set; }
    }
}
