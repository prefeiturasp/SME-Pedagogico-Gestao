using System;
using System.Collections.Generic;
using System.Text;
using SME.Pedagogico.Gestao.Models.Base.Abstracts;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class OrdemPergunta : Table
    {
        public Ordem Ordem { get; set; }
        public Pergunta Pergunta { get; set; }
        public bool Excluido { get; set; }
    }
}
