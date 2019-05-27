using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.Integracao.DTO
{
    public class PerfisServidoresDTO
    {
        public string nomeServidor { get; set; }
        public string codigoServidor { get; set; }
        public List<DreDTO> drEs { get; set; }
        public List<EscolaDTO> escolas { get; set; }
        public List<TurmaDTO> turmas { get; set; }
    
    }
}






