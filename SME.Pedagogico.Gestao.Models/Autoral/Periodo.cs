using SME.Pedagogico.Gestao.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class Periodo
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public TipoPeriodoEnum TipoPeriodo { get; set; }
    }
}
