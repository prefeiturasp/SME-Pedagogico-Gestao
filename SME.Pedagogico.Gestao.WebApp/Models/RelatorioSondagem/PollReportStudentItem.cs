using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.WebApp.Models.RelatorioSondagem
{
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
        public int Order { get; set; }
        public string Idea { get; set; }
        public string Result { get; set; }
    }
}
