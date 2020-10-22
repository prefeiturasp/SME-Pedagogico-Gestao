using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO.Matematica
{
  public  class GraficosRelatorioDTO
    {
        public string nomeGrafico { get; set; }
        public List<BarrasGraficoDTO> Barras { get; set; }
    }
}
