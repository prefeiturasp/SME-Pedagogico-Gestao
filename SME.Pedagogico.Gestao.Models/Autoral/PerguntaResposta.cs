using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class PerguntaResposta
    {
        public Guid Id { get; set; }
        public Pergunta Pergunta { get; set; }
        public Resposta Resposta { get; set; }
        public int Ordenacao { get; set; }
        public bool Excluido { get; set; }
    }
}
