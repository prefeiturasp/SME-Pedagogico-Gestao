using SME.Pedagogico.Gestao.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Data.DTO
{

    public class PollReportMathStudentResult
    {
        public List<PollReportMathStudentItem> Results { get; set; } = new List<PollReportMathStudentItem>();
        public List<MathChartDataModel> ChartData { get; set; } = new List<MathChartDataModel>();
    }


    public class PollReportMathStudentNumbersResult
    {
        public List<PollReportMathStudentNumbersItem > Results { get; set; } = new List<PollReportMathStudentNumbersItem>();
        public List<MathChartDataModel> ChartData { get; set; } = new List<MathChartDataModel>();
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




    public class PollReportMathStudentNumbersItem
    {
        public string Code { get; set; }
        public string StudentName { get; set; }
        public List<MathStudentItemNumbersResult> Poll { get; set; } = new List<MathStudentItemNumbersResult>();
    }

    public class MathStudentItemNumbersResult
    {
        public int Order { get; set; }
        public string Idea { get; set; }
        public string Result { get; set; }
    }
}
