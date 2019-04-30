using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Models.Base.Abstracts
{
    public abstract class NamedTable : Table
    {
        #region ==================== ATTRIBUTES ====================
        public string Name { get; set; } = null;
        #endregion ==================== ATTRIBUTES ====================



        #region ==================== CONSTRUCTORS ====================
        public NamedTable()
            : base()
        { }
        #endregion ==================== CONSTRUCTORS ====================



        #region ==================== METHODS ====================
        #endregion ==================== METHODS ====================
    }
}
