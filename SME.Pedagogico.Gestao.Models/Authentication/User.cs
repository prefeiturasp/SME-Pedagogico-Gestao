using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Models.Authentication
{
    public class User : Base.Abstracts.NamedTable
    {
        #region ==================== ATTRIBUTES ====================
        public string Password { get; set; } = null;

        public virtual Entity.Profile Profile { get; set; }
        public virtual List<UserRole> Roles { get; set; }
        #endregion ==================== ATTRIBUTES ====================



        #region ==================== CONSTRUCTORS ====================
        #endregion ==================== CONSTRUCTORS ====================



        #region ==================== METHODS ====================
        #endregion ==================== METHODS ====================
    }
}
