using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO.Portugues.Relatorio
{
    public class RelatorioPortuguesPerguntasDto
    {
        public RelatorioPortuguesPerguntasDto()
        {
            Total = new RelatorioPortuguesTotalizadores();
            Respostas = new List<RelatorioPortuguesRespostasDto>();
        }

        public string Id { get; set; }
        public string Nome { get; set; }
        public RelatorioPortuguesTotalizadores Total { get; set; }
        public List<RelatorioPortuguesRespostasDto> Respostas { get; set; }
    }
}
