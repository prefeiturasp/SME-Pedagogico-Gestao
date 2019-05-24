using Microsoft.EntityFrameworkCore;

namespace SME.Pedagogico.Gestao.WebApp.Contexts
{
    public class SMEManagementContext : DbContext
    {
        #region ==================== ATTRIBUTES ====================

        public DbSet<Gestao.Models.Authentication.LoggedUser> LoggedUsers { get; set; }
        public DbSet<Gestao.Models.Authentication.User> Users { get; set; }

        #endregion ==================== ATTRIBUTES ====================

        #region ==================== CONSTRUCTORS ====================

        public SMEManagementContext(DbContextOptions<SMEManagementContext> options)
            : base(options)
        { }

        #endregion ==================== CONSTRUCTORS ====================
    }
}