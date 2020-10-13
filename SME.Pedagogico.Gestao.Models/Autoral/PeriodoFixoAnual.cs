using SME.Pedagogico.Gestao.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class PeriodoFixoAnual
    {
        public int Id { get; set; }
        public int Ano { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public TipoPeriodoEnum TipoPeriodo { get; set; }
        public string PeriodoId { get; set; }
        public virtual Periodo Periodo { get; set; }
    }
}
