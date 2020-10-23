using SME.Pedagogico.Gestao.Data.DTO.Matematica;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO.RelatorioPorTurma
{
   public class RelatorioMatematicaPorTurmaDTO
    {
        public List<PerguntasRelatorioDTO> Perguntas { get; set; }
        public IEnumerable<AlunoPorTurmaRelatorioDTO> Alunos { get; set; }
        public List<GraficosRelatorioDTO> Graficos { get; set; }
    }
}
