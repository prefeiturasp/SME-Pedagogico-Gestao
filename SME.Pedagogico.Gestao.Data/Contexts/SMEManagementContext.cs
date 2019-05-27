using Microsoft.EntityFrameworkCore;

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
        public DbSet<Models.Academic.PortuguesePoll> PortuguesePolls { get; set; }
        public DbSet<Models.Academic.Semester> Semesters { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed para os perfis
            Models.Authentication.Role[] roles = new Models.Authentication.Role[]
            {
                new Models.Authentication.Role() { Name = "Admin" },
                new Models.Authentication.Role() { Name = "Diretor" },
                new Models.Authentication.Role() { Name = "Supervisor" },
                new Models.Authentication.Role() { Name = "Diretor" },
                new Models.Authentication.Role() { Name = "Secretario(a)" },
                new Models.Authentication.Role() { Name = "Auxiliar" },
                new Models.Authentication.Role() { Name = "Professor" },
                new Models.Authentication.Role() { Name = "Responsavel" },
                new Models.Authentication.Role() { Name = "Aluno" }
            };
            modelBuilder.Entity<Models.Authentication.Role>().HasData(roles);

            // Seed para os niveis de acesso
            Models.Authentication.AccessLevel[] accessLevels = new Models.Authentication.AccessLevel[]
            {
                new Models.Authentication.AccessLevel() { Description = "Desenvolvedor", Value = "0" },
                new Models.Authentication.AccessLevel() { Description = "COTIC", Value = "1" },
                new Models.Authentication.AccessLevel() { Description = "SME", Value = "2" },
                new Models.Authentication.AccessLevel() { Description = "COPED", Value = "3" },
                new Models.Authentication.AccessLevel() { Description = "DIEFEM", Value = "4" },
                new Models.Authentication.AccessLevel() { Description = "DIEI", Value = "5" },
                new Models.Authentication.AccessLevel() { Description = "DIEJA", Value = "6" },
                new Models.Authentication.AccessLevel() { Description = "DIEE", Value = "7" },
                new Models.Authentication.AccessLevel() { Description = "NTA", Value = "8" },
                new Models.Authentication.AccessLevel() { Description = "NTC", Value = "9" },
                new Models.Authentication.AccessLevel() { Description = "NTC-NAAPA", Value = "10" },
                new Models.Authentication.AccessLevel() { Description = "DIEE-Conveniado", Value = "11" },
                new Models.Authentication.AccessLevel() { Description = "COPED Básico", Value = "12" },
                new Models.Authentication.AccessLevel() { Description = "Regional", Value = "13" },
                new Models.Authentication.AccessLevel() { Description = "Técnico", Value = "14" },
                new Models.Authentication.AccessLevel() { Description = "Supervisor DRE", Value = "15" },
                new Models.Authentication.AccessLevel() { Description = "DIPED", Value = "16" },
                new Models.Authentication.AccessLevel() { Description = "NAAPA", Value = "17" },
                new Models.Authentication.AccessLevel() { Description = "CEFAI", Value = "18" },
                new Models.Authentication.AccessLevel() { Description = "PAAI", Value = "19" },
                new Models.Authentication.AccessLevel() { Description = "DIPED DRE", Value = "20" },
                new Models.Authentication.AccessLevel() { Description = "Adm DRE", Value = "21" },
                new Models.Authentication.AccessLevel() { Description = "Básico DRE", Value = "22" },
                new Models.Authentication.AccessLevel() { Description = "Básico Escola", Value = "23" },
                new Models.Authentication.AccessLevel() { Description = "Infantil", Value = "24" },
                new Models.Authentication.AccessLevel() { Description = "UE Parceira", Value = "25" },
                new Models.Authentication.AccessLevel() { Description = "AD", Value = "26" },
                new Models.Authentication.AccessLevel() { Description = "CP", Value = "27" },
                new Models.Authentication.AccessLevel() { Description = "Secretário Escola", Value = "28" },
                new Models.Authentication.AccessLevel() { Description = "COTIC", Value = "29" },
                new Models.Authentication.AccessLevel() { Description = "UE", Value = "30" },
                new Models.Authentication.AccessLevel() { Description = "CJ E Volante (PEI, ADI)", Value = "31" },
                new Models.Authentication.AccessLevel() { Description = "Fund. e Inf.", Value = "32" },
                new Models.Authentication.AccessLevel() { Description = "POA", Value = "33" },
                new Models.Authentication.AccessLevel() { Description = "PAP", Value = "34" },
                new Models.Authentication.AccessLevel() { Description = "AEE", Value = "35" },
                new Models.Authentication.AccessLevel() { Description = "Readaptado", Value = "36" },
                new Models.Authentication.AccessLevel() { Description = "ATE", Value = "37" },
            };
            modelBuilder.Entity<Models.Authentication.AccessLevel>().HasData(accessLevels);

            Models.Academic.PollType[] pollTypes = new Models.Academic.PollType[]
            {
                new Models.Academic.PollType() { PollTypeDescription = "Sondagem de Português"},
                new Models.Academic.PollType() { PollTypeDescription = "Sondagem de Matemática"},
                new  Models.Academic.PollType() { PollTypeDescription = "Sondagem de Alfabetização de Matemática"}
            };

            modelBuilder.Entity<Models.Academic.PollType>().HasData(pollTypes);

            Models.Academic.Semester[] semesters = new Models.Academic.Semester[]
            {
                new Models.Academic.Semester() { Value = "1"},
                new Models.Academic.Semester() { Value = "2"},
            };
            modelBuilder.Entity<Models.Academic.Semester>().HasData(semesters);

        }

        #endregion ==================== METHODS ====================
    }
}