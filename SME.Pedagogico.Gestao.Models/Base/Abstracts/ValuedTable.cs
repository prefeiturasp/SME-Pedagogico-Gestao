using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Models.Base.Abstracts
{
    public abstract class ValuedTable : Table
    {
        #region ==================== ATTRIBUTES ====================
        public string Value { get; set; } = null;
        #endregion ==================== ATTRIBUTES ====================



        #region ==================== CONSTRUCTORS ====================
        public ValuedTable()
            : base()
        { }
        #endregion ==================== CONSTRUCTORS ====================



        #region ==================== METHODS ====================
        #endregion ==================== METHODS ====================
    }
}
