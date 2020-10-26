using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO.Matematica.Relatorio
{
    public class RelatorioConsolidadoDTO
    {
      public  List<PerguntaDTO> Perguntas { get; set; }
      public List<GraficosRelatorioDTO> Graficos { get; set; }
    }
}
