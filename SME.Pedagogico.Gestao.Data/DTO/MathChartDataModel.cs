using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Data.DTO
{
    public class MathChartDataModel
    {
        public string Name { get; set; }
        public List<int> Idea { get; set; }
        public List<int> Result { get; set; }
    }
}
