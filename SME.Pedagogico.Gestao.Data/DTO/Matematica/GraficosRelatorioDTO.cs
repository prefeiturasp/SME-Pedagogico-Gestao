using SME.Pedagogico.Gestao.Data.DTO.Matematica;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO
{
  public  class GraficosRelatorioDTO
    {
        public string nomeGrafico { get; set; }
        public List<BarrasGraficoDTO> Barras { get; set; }
    }
}
