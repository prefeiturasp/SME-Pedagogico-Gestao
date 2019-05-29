using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO
{
    public class PollReportPortugueseResult
    {
        public List<PollReportPortugueseItem> Results { get; set; } = new List<PollReportPortugueseItem>();
        public List<PortChartDataModel> ChartData { get; set; } = new List<PortChartDataModel>();
    }

    public class PortChartDataModel
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }

    public class PollReportPortugueseItem
    {
        public string OptionName { get; set; }
        public int studentQuantity { get; set; }
        public double StudentPercentage { get; set; }
    }

    public class PollReportMathResult
    {
        public List<PollReportMathItem> Results { get; set; } = new List<PollReportMathItem>();
        public List<MathChartDataModel> ChartData { get; set; } = new List<MathChartDataModel>();
    }

    public class MathChartDataModel
    {
        public string Name { get; set; }
        public List<int> Idea { get; set; }
        public List<int> Result { get; set; }
    }

    public class PollReportMathItem
    {
        public string OrderName { get; set; }
        public List<MathItemResult> Results { get; set; } = new List<MathItemResult>();
    }

    public class MathItemResult
    {
        public string TestName { get; set; }
        public int TestIdeaQuantity { get; set; }
        public double TestIdeaPercentage { get; set; }
        public int TestResultQuantity { get; set; }
        public double TestResultPercentage { get; set; }

    }
}
