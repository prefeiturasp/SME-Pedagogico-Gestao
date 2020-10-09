using System;
using System.Collections.Generic;
using System.Text;
using SME.Pedagogico.Gestao.Data.DTO.Matematica.Relatorio;

namespace SME.Pedagogico.Gestao.Data.DTO.Portugues.Relatorio.CapacidadeLeitura
{
  public  class OrdemDTO
    {
        public string Ordem { get; set; }
        public List<PerguntaDTO> Pergunta { get; set; }
    }
}
