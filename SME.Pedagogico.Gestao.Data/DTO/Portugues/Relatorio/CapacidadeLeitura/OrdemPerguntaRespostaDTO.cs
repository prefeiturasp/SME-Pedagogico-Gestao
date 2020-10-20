using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO.Portugues.Relatorio.CapacidadeLeitura
{
   public class OrdemPerguntaRespostaDTO
    {
        public string OrdermId { get; set; }
        public string Ordem { get; set; }
        public string PerguntaId { get; set; }
        public string PerguntaDescricao { get; set; }
        public string RespostaId { get; set; }
        public string RespostaDescricao { get; set; }
        public int QtdRespostas { get; set; }
    }
}
