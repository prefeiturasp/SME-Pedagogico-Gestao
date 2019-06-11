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
     
    public class PollReportPortugueseStudentItem
    {
        public string Code { get; set; }
        public string StudentName { get; set; }
        public string StudentValue { get; set; }
    }
      
     
}
