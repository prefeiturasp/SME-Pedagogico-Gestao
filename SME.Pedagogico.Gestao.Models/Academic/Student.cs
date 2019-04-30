using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Models.Academic
{
    public class Student : Base.Abstracts.Table
    {
        #region ==================== ATTRIBUTES ====================
        public virtual Entity.Profile Profile { get; set; }
        public virtual List<StudentCode> Codes { get; set; }
        #endregion ==================== ATTRIBUTES ====================



        #region ==================== CONSTRUCTORS ====================
        #endregion ==================== CONSTRUCTORS ====================



        #region ==================== METHODS ====================
        #endregion ==================== METHODS ====================
    }
}
