using System;

namespace SME.Pedagogico.Gestao.Models.Organization
{
    public class LogControl : Base.Abstracts.Table
    {
        #region ==================== ATTRIBUTES ====================

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ModifiedAt { get; set; } = DateTime.Now;

        #endregion ==================== ATTRIBUTES ====================
    }
}