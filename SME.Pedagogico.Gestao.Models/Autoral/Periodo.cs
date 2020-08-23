using SME.Pedagogico.Gestao.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using SME.Pedagogico.Gestao.Models.Base.Abstracts;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class Periodo : Table
    {
        public string Descricao { get; set; }
        public TipoPeriodoEnum TipoPeriodo { get; set; }
    }
}
