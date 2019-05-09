using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Data.Contexts
{
    public class SMEManagementContext : DbContext
    {
        #region ==================== ATTRIBUTES ====================
        private string connectionString = "Server=localhost;Port=5432;Database=smeManagementDB;Username=postgres;Password=39162604;";

        #region ---------- Academic ----------
        public DbSet<Models.Academic.Student> Students { get; set; }
        public DbSet<Models.Academic.StudentCode> StudentCodes { get; set; }
        public DbSet<Models.Academic.Teacher> Teachers { get; set; }
        public DbSet<Models.Academic.TeacherCode> TeacherCodes { get; set; }
        #endregion ---------- Academic ----------

        #region ---------- Authentication ----------
        public DbSet<Models.Authentication.AccessLevel> AccessLevels { get; set; }
        public DbSet<Models.Authentication.LoggedUser> LoggedUsers { get; set; }
        public DbSet<Models.Authentication.Role> Roles { get; set; }
        public DbSet<Models.Authentication.User> Users { get; set; }
        public DbSet<Models.Authentication.UserRole> UserRoles { get; set; }
        #endregion ---------- Authentication ----------

        #region ---------- Entity ----------
        public DbSet<Models.Entity.Profile> Profiles { get; set; }
        #endregion ---------- Entity ----------

        #region ---------- Institutional ----------
        #endregion ---------- Institutional ----------

        #region ---------- Organization ----------
        public DbSet<Models.Organization.Code> Codes { get; set; }
        public DbSet<Models.Organization.LogControl> LogControls { get; set; }
        #endregion ---------- Organization ----------
        #endregion ==================== ATTRIBUTES ====================



        #region ==================== CONSTRUCTORS ====================
        public SMEManagementContext()
            : base()
        { }

        public SMEManagementContext(string connectionString)
            : base()
        {
            this.connectionString = connectionString;
        }
        #endregion ==================== CONSTRUCTORS ====================



        #region ==================== METHODS ====================
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }
        #endregion ==================== METHODS ====================
    }
}
