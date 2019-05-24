using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Models.Academic
{
    public class Student : Base.Abstracts.Table
    {
        #region ==================== ATTRIBUTES ====================

        public virtual Entity.Profile Profile { get; set; }
        public virtual List<StudentCode> Codes { get; set; }

        #endregion ==================== ATTRIBUTES ====================
    }
}