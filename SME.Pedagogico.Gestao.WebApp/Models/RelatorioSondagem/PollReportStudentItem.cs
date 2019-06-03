using SME.Pedagogico.Gestao.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.WebApp.Models.RelatorioSondagem
{
    public class PollReportPortugueseStudentResult
    {
        public List<PollReportPortugueseStudentItem> Results { get; set; }
        public List<PortChartDataModel> ChartData { get; set; }
    }

    public class PollReportMathStudentResult
    {
        public List<PollReportMathStudentItem> Results { get; set; } = new List<PollReportMathStudentItem>();
        public List<MathChartDataModel> ChartData { get; set; } = new List<MathChartDataModel>();
    }

    public class PollReportPortugueseStudentItem
    {
        public string Code { get; set; }
        public string StudentName { get; set; }
        public string StudentValue { get; set; }
    }
     
    public class PollReportMathStudentItem
    {
        public string Code { get; set; }
        public string StudentName { get; set; }
        public List<MathStudentItemResult> Poll { get; set; } = new List<MathStudentItemResult>();
    }

    public class MathStudentItemResult
    {
        public string Order { get; set; }
        public string Idea { get; set; }
        public string Result { get; set; }
    }
}
