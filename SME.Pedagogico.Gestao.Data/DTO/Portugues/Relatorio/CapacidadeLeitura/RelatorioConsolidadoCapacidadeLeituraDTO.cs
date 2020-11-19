using SME.Pedagogico.Gestao.Data.DTO.Portugues.Graficos.Portugues;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO.Portugues.Relatorio.CapacidadeLeitura
{
   public class RelatorioConsolidadoCapacidadeLeituraDTO
    {
        public List<OrdemDTO> RelatorioPorOrdem { get; set; }
        public List<GraficoOrdem> Graficos { get; set; }
    }
}
