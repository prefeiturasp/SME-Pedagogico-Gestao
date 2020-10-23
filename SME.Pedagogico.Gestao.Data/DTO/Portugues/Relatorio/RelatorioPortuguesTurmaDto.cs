using SME.Pedagogico.Gestao.Data.DTO.Portugues.Graficos.Portugues;
using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Data.DTO.Portugues.Relatorio
{
    public class RelatorioPortuguesTurmaDto
    {
        public RelatorioPortuguesTurmaDto()
        {
            Alunos = new List<RelatorioPortuguesTurmaAluno>();
            Graficos = new List<Grafico>();
        }

        public IEnumerable<PerguntaSimplificadaDto> Perguntas { get; set; }
        public IList<RelatorioPortuguesTurmaAluno> Alunos { get; set; }
        public IList<Grafico> Graficos { get; set; }
    }
}
