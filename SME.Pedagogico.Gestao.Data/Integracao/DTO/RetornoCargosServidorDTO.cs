using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Data.Integracao.DTO
{
    public class RetornoCargosServidorDTO
    {
        public string nomeServidor { get; set; }
        public string codigoServidor { get; set; }
        public List<RetornoCargoDTO> cargos { get; set; }
    }
}
