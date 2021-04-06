using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO
{
    public class RelatorioGraficoNumerosDTO
    {
        public List<MathChartDataModel> Graficos{ get; set; }
        public List<PollReportMathStudentNumbersItem> Relatorio { get; set; }
    }
}
