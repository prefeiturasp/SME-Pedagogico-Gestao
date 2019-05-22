using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Models.Authentication
{
    public class Role : Base.Abstracts.NamedTable
    {
        #region ==================== ATTRIBUTES ====================

        public virtual List<UserRole> UserRoles { get; set; }

        #endregion ==================== ATTRIBUTES ====================
    }
}