namespace SME.Pedagogico.Gestao.Models.Academic
{
    public class TeacherCode : Base.Abstracts.ValuedTable
    {
        #region ==================== ATTRIBUTES ====================

        public string CodeId { get; set; }
        public virtual Organization.Code Code { get; set; }

        public string TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        #endregion ==================== ATTRIBUTES ====================
    }
}