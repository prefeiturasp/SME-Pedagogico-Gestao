using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO
{
    public class PollReportPortugueseItem
    {
        public string OptionName { get; set; }
        public int studentQuantity { get; set; }
        public double StudentPercentage { get; set; }
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
