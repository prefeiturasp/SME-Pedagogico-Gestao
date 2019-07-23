namespace SME.Pedagogico.Gestao.Models.Entity
{
    public class Profile : Base.Abstracts.NamedTable
    {
        #region ==================== ATTRIBUTES ====================

        public string StudentId { get; set; }
        public virtual Academic.Student Student { get; set; }

        public string TeacherId { get; set; }
        public virtual Academic.Teacher Teacher { get; set; }

        public string UserId { get; set; }
        public virtual Authentication.User User { get; set; }

        #endregion ==================== ATTRIBUTES ====================
    }
}