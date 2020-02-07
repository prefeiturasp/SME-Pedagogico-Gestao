using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Models.Organization
{
  public class PeriodoDeAbertura
    {
        public int Id { get; set; }
        public string Ano { get; set; }
        public int Bimestre { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
