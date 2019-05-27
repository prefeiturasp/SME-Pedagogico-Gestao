using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.Integracao.DTO
{
    public class CargoDTO
    {
        public string codigoCargo { get; set; }
        public string nomeCargo { get; set; }
        public string nomeCargoSobreposto { get; set; }
        public string codigoCargoSobreposto { get; set; }
    }
}
