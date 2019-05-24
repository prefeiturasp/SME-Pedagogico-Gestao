namespace SME.Pedagogico.Gestao.Models.Academic
{
    public class StudentCode : Base.Abstracts.ValuedTable
    {
        #region ==================== ATTRIBUTES ====================

        public string CodeId { get; set; }
        public virtual Organization.Code Code { get; set; }

        public string StudentId { get; set; }
        public virtual Student Student { get; set; }

        #endregion ==================== ATTRIBUTES ====================
    }
}