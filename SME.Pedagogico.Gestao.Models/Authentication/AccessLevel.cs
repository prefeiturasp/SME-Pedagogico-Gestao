using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Models.Authentication
{
    public class AccessLevel : Base.Abstracts.ValuedTable
    {
        #region ==================== ATTRIBUTES ====================

        public string Description { get; set; }

        public List<UserRole> UserRoles { get; set; }

        #endregion ==================== ATTRIBUTES ====================
    }
}