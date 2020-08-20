using System;
using System.Collections.Generic;
using System.Text;
using SME.Pedagogico.Gestao.Models.Base.Abstracts;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class PerguntaResposta : Table
    {
        public Pergunta Pergunta { get; set; }
        public Resposta Resposta { get; set; }
        public int Ordenacao { get; set; }
        public bool Excluido { get; set; }
    }
}
