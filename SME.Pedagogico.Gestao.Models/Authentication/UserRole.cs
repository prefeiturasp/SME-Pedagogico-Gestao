using System;

namespace SME.Pedagogico.Gestao.Models.Authentication
{
    public class UserRole : Base.Abstracts.Table
    {
        #region ==================== ATTRIBUTES ====================

        public string AccessLevelId { get; set; }
        public virtual AccessLevel AccessLevel { get; set; }

        public string RoleId { get; set; }
        public virtual Role Role { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public Guid? PerfilId { get; set; }

        #endregion ==================== ATTRIBUTES ====================
    }
}