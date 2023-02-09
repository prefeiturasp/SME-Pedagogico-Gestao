using SME.Pedagogico.Gestao.Models.Enums;
using System;


namespace SME.Pedagogico.Gestao.Models.Organization
{
  public class PeriodoDeAbertura
    {
        public int Id { get; set; }
        public string Ano { get; set; }
        public int Bimestre { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public TipoPeriodoEnum TipoPeriodicidade { get; set; }
    }
}
