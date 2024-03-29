﻿using SME.Pedagogico.Gestao.Models.Base.Abstracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class PerguntaResposta : Table
    {
        public virtual Pergunta Pergunta { get; set; }
        public virtual Resposta Resposta { get; set; }
        public int Ordenacao { get; set; }
        public bool Excluido { get; set; }
    }
}
