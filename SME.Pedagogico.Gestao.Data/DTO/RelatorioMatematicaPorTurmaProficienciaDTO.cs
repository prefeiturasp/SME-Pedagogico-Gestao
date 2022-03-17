using SME.Pedagogico.Gestao.Data.DTO.RelatorioPorTurma;
using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Data.DTO.Matematica
{
    public class RelatorioMatematicaPorTurmaProficienciaDTO
    {
        public List<AlunoPorTurmaRelatorioProficienciaDTO> ListaDeAlunos { get; set; }

        public List<GraficosRelatorioProficienciaDTO> ListaDeGraficos { get; set; }
    }
}
