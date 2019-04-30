using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Models.Authentication
{
    public class AccessLevel : Base.Abstracts.ValuedTable
    {
        #region ==================== ATTRIBUTES ====================
        public string Description { get; set; }

        public List<UserRole> UserRoles { get; set; }
        #endregion ==================== ATTRIBUTES ====================



        #region ==================== CONSTRUCTORS ====================
        #endregion ==================== CONSTRUCTORS ====================



        #region ==================== METHODS ====================
        #endregion ==================== METHODS ====================
    }
}
