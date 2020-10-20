using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO.Matematica
{
  public  class AlunoPerguntaRespostaDTO
    {
        public string  CodigoAluno { get; set; }
        public string  NomeAluno { get; set; }
        public string PerguntaId { get; set; }
        public string PerguntaDescricao { get; set; }
        public string RespostaId { get; set; }
        public string RespostaDescricao { get; set; }
      

    }
}
