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
        public PollReportMathItem Results { get; set; } = new PollReportMathItem();
        public List<MathIdeaChartDataModel> ChartIdeaData { get; set; } = new List<MathIdeaChartDataModel>();
        public List<MathResultChartDataModel> ChartResultData { get; set; } = new List<MathResultChartDataModel>();
        public List<MathNumeroChartDataModel> ChartNumberData { get; set; } = new List<MathNumeroChartDataModel>();
    }

    public class MathIdeaChartDataModel
    {
        public string Order { get; set; }
        public List<IdeaChartDTO> Idea { get; set; } = new List<IdeaChartDTO>();
    }

    public class MathResultChartDataModel
    {
        public string Order { get; set; }
        public List<ResultChartDTO> Result { get; set; } = new List<ResultChartDTO>();
    }

    public class MathNumeroChartDataModel
    {
        public string Order { get; set; }
        public List<NumeroChartDTO> Numbers { get; set; } = new List<NumeroChartDTO>();
    }

    public class PollReportMathItem
    {
        public List<MathNumberResult> NumerosResults { get; set; } = new List<MathNumberResult>();
        public List<MathItemIdea> IdeaResults { get; set; } = new List<MathItemIdea>();
        public List<MathItemResult> ResultResults { get; set; } = new List<MathItemResult>();
    }

    public class MathItemIdea
    {
        public string OrderName { get; set; }
        public int CorrectIdeaQuantity { get; set; }
        public int IncorrectIdeaQuantity { get; set; }
        public int NotAnsweredIdeaQuantity { get; set; }
        public double CorrectIdeaPercentage { get; set; }
        public double IncorrectIdeaPercentage { get; set; }
        public double NotAnsweredIdeaPercentage { get; set; }
    }

    public class MathItemResult
    {
        public string OrderName { get; set; }
        public int CorrectResultQuantity { get; set; }
        public int IncorrectResultQuantity { get; set; }
        public int NotAnsweredResultQuantity { get; set; }
        public double CorrectResultPercentage { get; set; }
        public double IncorrectResultPercentage { get; set; }
        public double NotAnsweredResultPercentage { get; set; }
        public string OrderTitle { get; set; }
    }

    public class MathNumberResult
    {
        public string GroupName { get; set; }
        public int EscreveConvencionalmenteResultado { get; set; }
        public int NaoEscreveConvencionalmenteResultado { get; set; }
        public double EscreveConvencionalmentePercentage { get; set; }
        public double NaoEscreveConvencionalmentePercentage { get; set; }
        public string EscreveConvencionalmenteText { get; set; }
        public string NaoEscreveConvencionalmenteText { get; set; }
        public string OrderTitle { get; set; }
    }
}
