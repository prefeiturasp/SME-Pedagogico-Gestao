﻿using SME.Pedagogico.Gestao.Models.Base.Abstracts;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class PerguntaAnoEscolar : Table
    {
        public virtual Pergunta Pergunta { get; set; }
        public int AnoEscolar { get; set; }
        public int Ordenacao { get; set; }
        public bool Excluido { get; set; }
    }
}
