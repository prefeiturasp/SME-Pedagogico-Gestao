using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Models.Academic
{
    public class Teacher : Base.Abstracts.Table
    {
        #region ==================== ATTRIBUTES ====================

        public virtual Entity.Profile Profile { get; set; }
        public virtual List<TeacherCode> Codes { get; set; }

        #endregion ==================== ATTRIBUTES ====================
    }
}