using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Data.DTO.Matematica.Relatorio
{
    public class RelatorioConsolidadoProficienciaDTO
    {
        public List<PerguntaProficienciaDTO> Perguntas { get; set; }

        public List<GraficosRelatorioProficienciaDTO> Graficos { get; set; }
    }
}
