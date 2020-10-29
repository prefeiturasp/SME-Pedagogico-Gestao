using SME.Pedagogico.Gestao.Data.DTO.Portugues.Graficos.Portugues;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO.Portugues.Relatorio
{
    public class RelatorioAutoralLeituraProducaoDto
    {
        public RelatorioAutoralLeituraProducaoDto()
        {
            Graficos = new List<Grafico>();
        }

        public string GrupoDescricao { get; set; }
        public RelatorioPortuguesTotalizadores Totais { get; set; }
        public IEnumerable<RelatorioPortuguesPerguntasDto> Perguntas { get; set; }
        public IList<Grafico> Graficos { get; set; }
    }
}
