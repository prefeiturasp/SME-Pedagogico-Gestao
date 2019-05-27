using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.Integracao.DTO
{
    public class FuncionarioDTO
    {
        public string nomeServidor { get; set; }
        public string codigoServidor { get; set; }
        public List<CargoDTO> ListOccupations { get; set; }
    }
  }
