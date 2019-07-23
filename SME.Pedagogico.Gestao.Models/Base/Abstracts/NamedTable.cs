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
    }
}