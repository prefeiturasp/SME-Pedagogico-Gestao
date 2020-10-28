using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Data.DTO.Portugues.Graficos.Portugues
{
    public class Grafico
    {
        public Grafico()
        {
            Barras = new List<GraficoBarra>();
        }

        public string NomeGrafico { get; set; }
        public IList<GraficoBarra> Barras { get; set; }
    }
}
