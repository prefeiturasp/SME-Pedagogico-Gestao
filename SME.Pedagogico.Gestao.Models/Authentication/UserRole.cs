using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #endregion ==================== ATTRIBUTES ====================



        #region ==================== CONSTRUCTORS ====================
        #endregion ==================== CONSTRUCTORS ====================



        #region ==================== METHODS ====================
        #endregion ==================== METHODS ====================
    }
}
