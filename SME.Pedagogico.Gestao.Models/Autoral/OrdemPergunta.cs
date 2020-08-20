using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class OrdemPergunta
    {
        public Guid Id { get; set; }
        public Ordem Ordem { get; set; }
        public Pergunta Pergunta { get; set; }
        public bool Excluido { get; set; }
    }
}
