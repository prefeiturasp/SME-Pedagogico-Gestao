using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO.Matematica.Relatorio
{
  public  class PerguntasRespostasDTO
    {
        public string PerguntaId { get; set; }
        public string PerguntaDescricao  { get; set; }

        public string RespostaId { get; set; }
        public string RespostaDescricao { get; set; }
        public int QtdRespostas { get; set; }
 
    }
}
