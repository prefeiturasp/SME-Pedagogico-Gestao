using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.Integracao.DTO
{
    public class FiltroTotalAlunosAtivos
    {
        public string AnoTurma { get; set; }
        public int AnoLetivo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string UeId { get; set; }
        public string DreId { get; set; }
    }
}
