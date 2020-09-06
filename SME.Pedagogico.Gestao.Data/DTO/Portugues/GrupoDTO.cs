using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO.Portugues
{
   public class GrupoDTO
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public  List<OrdemDTO> Ordem { get; set; }
    }
}
