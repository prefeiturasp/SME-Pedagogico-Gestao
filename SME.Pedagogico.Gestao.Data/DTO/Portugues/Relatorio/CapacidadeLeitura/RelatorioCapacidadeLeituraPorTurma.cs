using SME.Pedagogico.Gestao.Data.DTO.Portugues.Graficos.Portugues;
using SME.Pedagogico.Gestao.Data.DTO.Relatorio;
using SME.Pedagogico.Gestao.Data.DTO.RelatorioPorTurma;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO.Portugues.Relatorio.CapacidadeLeitura
{
    public class RelatorioCapacidadeLeituraPorTurma
    {
        public IEnumerable<OrdemRelatorioPorTurmaDTO> Ordens { get; set; }

        public IEnumerable<PerguntasRelatorioDTO> Perguntas { get; set; }
        public List<AlunoPorTurmaCapacidadeLeituraDTO> Alunos { get; set; }

        public List<GraficoOrdem> Graficos { get; set; }
    }
}
