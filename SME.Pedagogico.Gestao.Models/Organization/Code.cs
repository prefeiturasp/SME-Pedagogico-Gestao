using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Models.Organization
{
    public class Code : Base.Abstracts.NamedTable
    {
        #region ==================== ATTRIBUTES ====================

        public string Description { get; set; } = null;

        public virtual List<Academic.StudentCode> StudentCodes { get; set; }
        public virtual List<Academic.TeacherCode> TeacherCodes { get; set; }

        #endregion ==================== ATTRIBUTES ====================
    }
}