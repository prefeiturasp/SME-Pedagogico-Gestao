using Microsoft.EntityFrameworkCore;
using SME.Pedagogico.Gestao.Models.Autoral;

namespace SME.Pedagogico.Gestao.Data.Contexts
{
    public class SMEManagementContextData : DbContext
    {
        #region ==================== ATTRIBUTES ====================

        private string connectionString = "Server=localhost;Port=5432;Database=smeManagementDB;Username=postgres;Password=39162604;";

        #region ---------- Academic ----------

        public DbSet<Models.Academic.Student> Students { get; set; }
        public DbSet<Models.Academic.StudentCode> StudentCodes { get; set; }
        public DbSet<Models.Academic.Teacher> Teachers { get; set; }
        public DbSet<Models.Academic.TeacherCode> TeacherCodes { get; set; }
        public DbSet<Models.Academic.PortuguesePoll> PortuguesePolls { get; set; }
        public DbSet<Models.Academic.MathPoolCM> MathPoolCMs { get; set; }
        public DbSet<Models.Academic.MathPoolCA> MathPoolCAs { get; set; }
        public DbSet<Models.Academic.MathPoolNumber> MathPoolNumbers { get; set; }
        public DbSet<ComponenteCurricular> ComponenteCurricular { get; set; }
        public DbSet<Pergunta> Pergunta { get; set; }
        public DbSet<Resposta> Resposta { get; set; }
        public DbSet<PerguntaResposta> PerguntaResposta { get; set; }
        public DbSet<PerguntaAnoEscolar> PerguntaAnoEscolar { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Ordem> Ordem { get; set; }
        public DbSet<OrdemPergunta> OrdemPergunta { get; set; }
        public DbSet<Periodo> Periodo { get; set; }
        public DbSet<SondagemAutoral> SondagemAutoral { get; set; }

        #endregion ---------- Academic ----------

        #region ---------- Authentication ----------

        public DbSet<Models.Authentication.AccessLevel> AccessLevels { get; set; }
        public DbSet<Models.Authentication.LoggedUser> LoggedUsers { get; set; }
        public DbSet<Models.Authentication.Role> Roles { get; set; }
        public DbSet<Models.Authentication.User> Users { get; set; }
        public DbSet<Models.Authentication.UserRole> UserRoles { get; set; }
        public DbSet<Models.Authentication.PrivilegedAccess> PrivilegedAccess { get; set; }


        #endregion ---------- Authentication ----------

        #region ---------- Entity ----------

        public DbSet<Models.Entity.Profile> Profiles { get; set; }

        #endregion ---------- Entity ----------

        #region ---------- Organization ----------
        public DbSet<Models.Organization.Code> Codes { get; set; }
        public DbSet<Models.Organization.LogControl> LogControls { get; set; }
        public DbSet<Models.Organization.PeriodoDeAbertura> PeriodoDeAberturas { get; set; }

        #endregion ---------- Organization ----------

        #endregion ==================== ATTRIBUTES ====================

        #region ==================== CONSTRUCTORS ====================

        public SMEManagementContextData()
            : base()
        { }

        public SMEManagementContextData(string connectionString)
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
                new Models.Authentication.Role() { Name = "CP" },
                new Models.Authentication.Role() { Name = "Diretor" },
                new Models.Authentication.Role() { Name = "Secretario(a)" },
                new Models.Authentication.Role() { Name = "Auxiliar" },
                new Models.Authentication.Role() { Name = "Professor" },
                new Models.Authentication.Role() { Name = "Responsavel" },
                new Models.Authentication.Role() { Name = "Aluno" },
                new Models.Authentication.Role() { Name = "Adm DRE"}
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

            Models.Authentication.PrivilegedAccess[] pvAccess = new Models.Authentication.PrivilegedAccess[]
            {
                 new Models.Authentication.PrivilegedAccess()
                {
                    Login = "caique.amcom",
                    Name  = "Caique Latorre",
                    OccupationPlace = "AMCOM",
                    OccupationPlaceCode = 1,
                    DreCodeEol = "",


                },
                  new Models.Authentication.PrivilegedAccess()
                {
                    Login = "massato.amcom",
                    Name  = "Massato Kanno",
                    OccupationPlace = "AMCOM",
                    OccupationPlaceCode = 1,
                    DreCodeEol = ""

                },

                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "daniel.amcom",
                    Name  = "Daniel Matsumoto",
                    OccupationPlace = "AMCOM",
                    OccupationPlaceCode = 1,
                    DreCodeEol = ""

                },


                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "danielli.amcom",
                    Name  = "Danielli",
                    OccupationPlace = "AMCOM",
                    OccupationPlaceCode = 1,
                    DreCodeEol = ""

                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "jeff.amcom",
                    Name  = "Jeff",
                    OccupationPlace = "AMCOM",
                    OccupationPlaceCode = 1,
                    DreCodeEol = ""
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "aline.amcom",
                    Name  = "Aline",
                    OccupationPlace = "AMCOM",
                    OccupationPlaceCode = 1,
                    DreCodeEol = ""
                },

                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "gabi.sme",
                    Name  = "Gabi",
                    OccupationPlace = "SME",
                    OccupationPlaceCode = 2,
                    DreCodeEol = ""
                },

                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "heloisa.sme",
                    Name  = "Heloisa Giannichi",
                    OccupationPlace = "SME",
                    OccupationPlaceCode = 2,
                    DreCodeEol = ""
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7951221",
                    Name  = "Karla de Oliveira Queiroz",
                    OccupationPlace = "SME",
                    OccupationPlaceCode = 2,
                    DreCodeEol = ""
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "8016119",
                    Name  = "Daniela Harumi Hikawa",
                    OccupationPlace = "SME",
                    OccupationPlaceCode = 2,
                    DreCodeEol = ""
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7937431",
                    Name  = "Cintia Anselmo dos Santos",
                    OccupationPlace = "SME",
                    OccupationPlaceCode = 2,
                    DreCodeEol = ""
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7906706",
                    Name  = "Felipe de Souza Costa",
                    OccupationPlace = "SME",
                    OccupationPlaceCode = 2,
                    DreCodeEol = ""
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7944560",
                    Name  = "Heloisa Maria de Morais Giannichi",
                    OccupationPlace = "SME",
                    OccupationPlaceCode = 2,
                    DreCodeEol = ""
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7744412",
                    Name  = "Carla da Silva Francisco",
                    OccupationPlace = "SME",
                    OccupationPlaceCode = 2,
                    DreCodeEol = ""
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "8163740",
                    Name  = "Paula Giampietri Franco",
                    OccupationPlace = "SME",
                    OccupationPlaceCode = 2,
                    DreCodeEol = ""
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6122147",
                    Name  = "Humberto Luis de Jesus",
                    OccupationPlace = "SME",
                    OccupationPlaceCode = 2,
                    DreCodeEol = ""
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7727640",
                    Name  = "Kátia Gisele Turollo do Nascimento",
                    OccupationPlace = "SME",
                    OccupationPlaceCode = 2,
                    DreCodeEol = ""
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7887337",
                    Name  = "Thayrê Marin Alves de Lima",
                    OccupationPlace = "SME",
                    OccupationPlaceCode = 2,
                    DreCodeEol = ""
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6888895",
                    Name  = "Fernando Jorge Barrios",
                    OccupationPlace = "SME",
                    OccupationPlaceCode = 2,
                    DreCodeEol = ""
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "2994267",
                    Name  = "Edna Calvo Leite",
                    OccupationPlace = "SME",
                    OccupationPlaceCode = 2,
                    DreCodeEol = ""
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7923490",
                    Name  = "Lis Regia Pontedeiro",
                    OccupationPlace = "SME",
                    OccupationPlaceCode = 2,
                    DreCodeEol = ""
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7719086",
                    Name  = "Fernando Araujo de Oliveira",
                    OccupationPlace = "SME",
                    OccupationPlaceCode = 2,
                    DreCodeEol = ""
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7827067",
                    Name  = "Amanda Martins Amaro",
                    OccupationPlace = "SME",
                    OccupationPlaceCode = 2,
                    DreCodeEol = ""
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7705182",
                    Name  = "Kátia Sayuri Endo",
                    OccupationPlace = "SME",
                    OccupationPlaceCode = 2,
                    DreCodeEol = ""
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7716125",
                    Name  = "Uyara Vieira Costa de Andrade",
                    OccupationPlace = "SME",
                    OccupationPlaceCode = 2,
                    DreCodeEol = ""
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7924488",
                    Name  = "Gabriela Manzolli Rowlands Lopes",
                    OccupationPlace = "SME",
                    OccupationPlaceCode = 2,
                    DreCodeEol = ""
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6941583",
                    Name  = "Ronaldo José da Silveira",
                    OccupationPlace = "SME",
                    OccupationPlaceCode = 2,
                    DreCodeEol = ""
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6946895",
                    Name  = "MINEA PASCHOALETO FRATELLI SONOBE",
                    OccupationPlace = "SME",
                    OccupationPlaceCode = 2,
                    DreCodeEol = ""
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6923950",
                    Name  = "Rosangela Ferreira de Souza Queiroz",
                    OccupationPlace = "SME",
                    OccupationPlaceCode = 2,
                    DreCodeEol = ""
                },


                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7418078",
                    Name  = "Annaa Luisa de Castro",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO BUTANTA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108100"
                },

                 new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7936532",
                    Name  = "DIEGO BENJAMIM NEVES",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO BUTANTA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108100"
                },

                   new Models.Authentication.PrivilegedAccess()
                {
                    Login = "8019444",
                    Name  = "JULIANO RODRIGO MACIEL FERNANDES",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO BUTANTA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108100"
                },
                     new Models.Authentication.PrivilegedAccess()
                {
                    Login = "8019444",
                    Name  = "JULIANO RODRIGO MACIEL FERNANDES",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO BUTANTA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108100"
                },
                        new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7371489",
                    Name  = "ROSANA RODRIGUES DA SILVA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO BUTANTA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108100"
                },

                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6663648",
                    Name  = "RUI FRANCISCO DA SILVA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO BUTANTA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108100"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "8161828",
                    Name  = "DANIEL DAMIAO DA SILVA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO BUTANTA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108100"
                },

                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7940726",
                    Name  = "Silvana Bastos Pereira Mendes",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO BUTANTA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108100"
                },
                 new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6775861",
                    Name  = "PATRICIA LACERDA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108200"
                },
                   new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7115571",
                    Name  = "ROSANGELA JULIA DE MATOS MONTEIRO",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108200"
                },
                 new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7251297",
                    Name  = "CASSIA APARECIDA GUIMARAES",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108200"
                },
                  new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7915144",
                    Name  = "MARIA LUANA LIMA MENDES DOS SANTOS",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108200"
                },
               new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6204619",
                    Name  = "ROSELI HELENA DE SOUZA SALGADO",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108200"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6940145",
                    Name  = "REGINA PAULA COLLAZO BERTUCCIOLI",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108200"
                },
                 new Models.Authentication.PrivilegedAccess()
                {
                    Login = "5413010",
                    Name  = "CECILIA REGINA CARLINI FERREIRA COELHO",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108200"
                },
                 new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7213638",
                    Name  = "RICARDO DE SOUZA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108200"
                },
                  new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7550618",
                    Name  = "LUANNA OLIVEIRA DE ALMEIDA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108200"
                },
                   new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7731892",
                    Name  = "LEANDRO ALVES DOS SANTOS",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108200"
                },
                    new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7814062",
                    Name  = "DEMETRIUS SARAIVA GOMES",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108200"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "8044953",
                    Name  = "CLEOMAR DE SOUZA LIMA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108200"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "5830834",
                    Name  = "RITA DE CASSIA GERALDI MENEGON",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108200"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6062130",
                    Name  = "CRISTINA BARROCO MASSEI FERNANDES",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108200"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6604439",
                    Name  = "ELISABETE MARTINS DA FONSECA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108200"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7373121",
                    Name  = "ANGELICA DE ALMEIDA MERLI",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108200"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "8582416",
                    Name  = "KARINA ESTEVES BELMONTE",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108200"
                },
                 new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7944527",
                    Name  = "JAQUELINE APARECIDA DE LIMA MATOS",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108300"
                },
                 new Models.Authentication.PrivilegedAccess()
                {
                    Login = "8022691",
                    Name  = "TATIANA FERREIRA COSTA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108300"
                },
                 new Models.Authentication.PrivilegedAccess()
                {
                    Login = "8036080",
                    Name  = "Luciene Aparecida Grisolio Cioffi",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108300"
                },
                 new Models.Authentication.PrivilegedAccess()
                {
                    Login = "8094411",
                    Name  = "Eduardo  Murakami da Silva",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108300"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "5929156",
                    Name  = "MARIA TERESA FUEYO",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108300"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "5974755",
                    Name  = "SANDRA REGINA DE CARVALHO",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108300"
                },
                 new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6911323",
                    Name  = "MARCELA DE PINA BERGAMINE",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108300"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7256795",
                    Name  = "ROSANA BUENO",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108300"
                },
                   new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7510691",
                    Name  = "MARINA DAS GRACAS MORAES",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108300"
                },
                      new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6941095",
                    Name  = "CAROLINA NOGUEIRA DROGA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108300"
                },
                         new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7721803",
                    Name  = "OSMIR SANTOS MACEDO",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108300"
                },
                   new Models.Authentication.PrivilegedAccess()
                {
                    Login = "8206597",
                    Name  = "MICHELLE BARBOSA FONSECA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108300"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6383793",
                    Name  = "JOSE ALVES MARTINS FILHO",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108400"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7953542",
                    Name  = "SORAIA APARECIDA INACIO DA CRUZ",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108400"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7456191",
                    Name  = "DANIELE LEITE FERREIRA MEMOLI",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108400"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6751067",
                    Name  = "MARCIA REGINA BARRELLI",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108400"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "580553",
                    Name  = "SISI MARIA VENTURA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108400"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6383793",
                    Name  = "JOSE ALVES MARTINS FILHO",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108400"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6686362",
                    Name  = "ROBERTO ANTONIO MACIEL",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108400"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6719767",
                    Name  = "MARTHA LUCIA BRAGA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108400"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7237383",
                    Name  = "JULIANA NAGAHAMA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108400"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "8023999",
                    Name  = "ADELINE FERNANDES FERREIRA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108400"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "8055327",
                    Name  = "THAIS CHARELLI MARTINS",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108400"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "8160490",
                    Name  = "JULIO CESAR DE CARVALHO SANTOS",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108400"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "8219532",
                    Name  = "ANA CRISTINA PEREIRA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108400"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "5640539",
                    Name  = "ROSANA RAIMONDI",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108500"
                },
                 new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6940773",
                    Name  = "ROMEU GUIMARAES GUSMAO",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108500"
                },
                 new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6784011",
                    Name  = "ESTER MARQUES DE PAULA DIONISIO",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108500"
                },
                 new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6767494",
                    Name  = "LUCIMEIRE CABRAL DE SANTANA FREITAS",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108500"
                },
                 new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7705719",
                    Name  = "SILVANA DOS SANTOS SILVA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108500"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7935897",
                    Name  = "BIANCA FREIRE DOS SANTOS",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108500"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "5358051",
                    Name  = "Rosana Soares Godinho",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108500"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7976445",
                    Name  = "Fernanda Moreira Xavier",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108500"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7808208",
                    Name  = "Luciano de Brito Leal",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108500"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "8401918",
                    Name  = "MARIA INES ALVES PEREIRA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108500"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6002129",
                    Name  = "KELLEY CARVALHO MONTEIRO DE OLIVEIRA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO IPIRANGA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108600"
                },
                 new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7326238",
                    Name  = "IRAIDE SILVA RIBEIRO DOS SANTOS",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO IPIRANGA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108600"
                },
                 new Models.Authentication.PrivilegedAccess()
                {
                    Login = "8078734",
                    Name  = "FRANCISCO FABIANO DANTAS SANTOS",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO IPIRANGA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108600"
                },
                 new Models.Authentication.PrivilegedAccess()
                {
                    Login = "5988861",
                    Name  = "MARCELO AUGUSTO MACHADO",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO IPIRANG",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108600"
                },
                  new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6909795",
                    Name  = "MARTA MALHEIROS ADRIANO",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO IPIRANGA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108600"
                },
                   new Models.Authentication.PrivilegedAccess()
                {
                    Login = "5996236",
                    Name  = "ELAINE CRISTINA RAMOS DE ALMEIDA NUNES",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO IPIRANGA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108600"
                },
                    new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7441487",
                    Name  = "ERIKA RENATA DE FREITAS",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO IPIRANGA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108600"
                },
                     new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7913788",
                    Name  = "ANDERSON ACIOLI MACHADO",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO IPIRANGA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108600"
                },
                 new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7549695",
                    Name  = "SELMA ANDREA DOS SANTOS SILVA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108700"
                },
                 new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7807350",
                    Name  = "REGIANE PEREA CARVALHO",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108700"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "8030910",
                    Name  = "DIOGO LAZARO DE ARAUJO",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108700"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7228546",
                    Name  = "SIMONE RIBEIRO MANSANO",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108700"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "5908710",
                    Name  = "MARCIA MARQUES DOS SANTOS",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108700"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "5514894",
                    Name  = "MARIA TEREZA VIEIRA SCHINZARI",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108700"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "5841704",
                    Name  = "ANA REGINA BARBOSA SPINARDI",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108700"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6466419",
                    Name  = "WANIA MAGALHAES",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108700"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6664962",
                    Name  = "ELIANE PRADO FREIRE",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108700"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6923968",
                    Name  = "LUCIA RAMALHO NUNES MUNIS",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108700"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7219253",
                    Name  = "ALESSANDRA QUIQUETTO DE OLIVEIRA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108700"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7264755",
                    Name  = "ESTELA VANESSA DE MENEZES",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108700"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7400853",
                    Name  = "ROSA HELENA DE FREITAS ROGERIO CARVALHO",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108700"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7451016",
                    Name  = "MONICA CRISTINA ALBERTINI DOS SANTOS",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108700"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7531907",
                    Name  = "KARINA LEITE RENTZ",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108700"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7708980",
                    Name  = "CAMILA NETO FERNANDES ANDRADE",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108700"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7807350",
                    Name  = "REGIANE PEREA CARVALHO",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108700"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7866518",
                    Name  = "DAYANE CAMPOREZE RODRIGUES",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108700"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7910649",
                    Name  = "DANIELA LOURENCO DOS SANTOS",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108700"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7950969",
                    Name  = "PRISCILA VAZ MAGRINELLI",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108700"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "8030910",
                    Name  = "DIOGO LAZARO DE ARAUJO",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108700"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "8066086",
                    Name  = "ANNA FLAVIA SANCHES DE ALMEIDA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108700"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6911161",
                    Name  = "Liliane Aparecida Granzotti",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108700"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "8206252",
                    Name  = "JUCILENE ALVES GOMES DA SILVA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108700"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6928161",
                    Name  = "SIMONE DA SILVA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108800"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "8026637",
                    Name  = "WAGNER RODRIGUES FLORIANO",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108800"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7228287",
                    Name  = "CAMILA RAMOS FRANCO DE SOUZA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108800"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7528418",
                    Name  = "PATRICIA FERNANDES ROSA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108800"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6200877",
                    Name  = "PAULA DO NASCIMENTO JULIO AGNELLO",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108800"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6391389",
                    Name  = "IVAN VENTURINI",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108800"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6751318",
                    Name  = "GLAUCIA ESIMIR DE CAMARGO FANTOZZI HADAD",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108800"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6777694",
                    Name  = "SUMAYA GISELE MARTINS CAVALCANTE",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108800"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "6928161",
                    Name  = "SIMONE DA SILVA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108800"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7287160",
                    Name  = "TATHIANA AUGUSTA RODRIGUES LOURENCO MARTINEZ",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108800"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7298587",
                    Name  = "LIVIA LEDIER FELIX VIEIRA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108800"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7705620",
                    Name  = "LARISSA DE GOUVEIA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108800"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7728182",
                    Name  = "MARCELO DOS SANTOS DIAS",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108800"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7987498",
                    Name  = "FABIANA LOPES LAURITO",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108800"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7990375",
                    Name  = "ADRIANA SBEGHEN BONAFE ZACHHUBER",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108800"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "8028044",
                    Name  = "MARIA CLAUDIA DA SILVA",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108800"
                },
                new Models.Authentication.PrivilegedAccess()
                {
                    Login = "8028311",
                    Name  = "ROBERTO BELISIARIO SANTOS",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108800"
                },
                 new Models.Authentication.PrivilegedAccess()
                {
                    Login = "7706812",
                    Name  = "SIMONY DE LENA DOTTO",
                    OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO PENHA",
                    OccupationPlaceCode = 3,
                    DreCodeEol = "108900"
                },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "7721854",
                     Name  = "CINTIA MITSUE KAMURA",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO PENHA",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "108900"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "7761279",
                     Name  = "SUSAN QUILES QUISBERT",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO PENHA",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "108900"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "6664253",
                     Name  = "ELIANA SOUZA DA SILVA DE BENEDETTI",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO PENHA",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "108900"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "6011365",
                     Name  = "LUCI BATISTA COSTA SOARES DE MIRANDA",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO PENHA",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "108900"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "5910935",
                     Name  = "WANIA CRISTINA MANOEL",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO PENHA",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "108900"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "6033113",
                     Name  = "VERA LUCIA CICON HERNANDES",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO PENHA",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "108900"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "6306730",
                     Name  = "ROSANA BATISTA",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO PENHA",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "108900"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "6788696",
                     Name  = "OLESIA PATRICIA APARECIDA GIANNELLA HENRIQUE",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO PENHA",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "108900"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "7220278",
                     Name  = "ALESSANDRA SERRA DE ABREU CAMPOS",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO PENHA",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "108900"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "7940645",
                     Name  = "NUBIA NOGUEIRA CHINOCA",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO PENHA",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "108900"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "7986645",
                     Name  = "THALITA GARCIA LOPES",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO PENHA",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "108900"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "7761147",
                     Name  = "MONICA GERDULLO SASSI",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO PIRITUBA/JARAGUA",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109000"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "7279515",
                     Name  = "REGINA BRUHNS ROSSINI ANDRADE",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO PIRITUBA/JARAGUA",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109000"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "6564283",
                     Name  = "RUI DA SILVA LIMA",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO PIRITUBA/JARAGUA",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109000"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "7283199",
                     Name  = "ADRIANA BONIFACIO CALIMAN",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO PIRITUBA/JARAGUA",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109000"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "7767951",
                     Name  = "CLAUDIA GONCALVES DA SILVA",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SANTO AMARO",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109100"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "6348564",
                     Name  = "LINEIA RUIZ TRIVILIN",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SANTO AMARO",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109100"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "5781027",
                     Name  = "CARLOS ANTONIO VIEIRA",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SANTO AMARO",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109100"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "7462131",
                     Name  = "Solange Amalia da Cruz",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SANTO AMARO",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109100"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "7516100",
                     Name  = "Grace Zaggia Utimura",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SANTO AMARO",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109100"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "7725507",
                     Name  = "Haroldo Heverton Souza de Arruda",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SANTO AMARO",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109100"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "6920951",
                     Name  = "JOSE ANTONIO DOS SANTOS",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109200"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "7739214",
                     Name  = "JOSE HUMBERTO DO NASCIMENTO",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109200"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "7275803",
                     Name  = "PAULA CRISTINA CASTRO PINHEIRO BANDLER",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109200"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "6389911",
                     Name  = "MIRTES INNOCENCIO DA SILVA",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109200"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "5589100",
                     Name  = "REJANE MARIA BRESSAN",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109200"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "7230486",
                     Name  = "ADRIANA CRISTINA LOURENCO IUPI",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109200"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "7231555",
                     Name  = "JESSICA NACCARATO DA SILVA",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109200"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "7371161",
                     Name  = "SERGIO EDUARDO MORENO HAEITMANN",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109200"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "7526555",
                     Name  = "EDNA RIBEIRO DOS SANTOS",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109200"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "7936095",
                     Name  = "RENATA SANTANA DE MIRANDA CARDOSO",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109200"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "8066736",
                     Name  = "GIRSELEY ALEXANDRE GONCALVES SATO",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109200"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "7357915",
                     Name  = "DANIELA PINHEIRO ALVANI TERCIANO",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109200"
                 },
                    new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "8176337",
                     Name  = "RENATA LIMA DURAES",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109200"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "6944213",
                     Name  = "CRISTIANE NASCIMENTO SILVA GOMES",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109300"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "7288298",
                     Name  = "IVO DOS SANTOS CARVALHO",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109300"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "7499361",
                     Name  = "ANDREA ANGELO SOARES DOS SANTOS",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109300"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "5518091",
                     Name  = "JAIR SIPIONI",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109300"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "5629632",
                     Name  = "ARLENE FERREIRA DOS SANTOS",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109300"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "5759129",
                     Name  = "MARIA ISABEL VIEIRA DE SOUZA",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109300"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "6770134",
                     Name  = "REGINA CELIA RIBEIRO DA SILVA",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109300"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "6811361",
                     Name  = "JANE CRISTINA DE SOUZA",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109300"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "6840531",
                     Name  = "EUNICE SOUSA DO NASCIMENTO",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109300"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "6925961",
                     Name  = "KEILA FERREIRA DA SILVA VIANA",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109300"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "7234392",
                     Name  = "ROSANA CARLA DE OLIVEIRA",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109300"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "7443994",
                     Name  = "MARIA APARECIDA DE SOUZA SANTOS",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109300"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "7479417",
                     Name  = "RINA MARCIA DE ALMEIDA",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109300"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "7502397",
                     Name  = "ANA PAULA MENDES GUARINHO",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109300"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "7872241",
                     Name  = "PALOMA ROBERTA FERMINO",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109300"
                 },
                 new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "8013799",
                     Name  = "SIMONE APARECIDA SILVA",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109300"
                 },
                    new Models.Authentication.PrivilegedAccess()
                 {
                     Login = "8063389",
                     Name  = "ADRIANA GOIS DE SOUZA",
                     OccupationPlace = "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL",
                     OccupationPlaceCode = 3,
                     DreCodeEol = "109300"
                 },
















            };
            modelBuilder.Entity<Models.Authentication.PrivilegedAccess>().HasData(pvAccess);
        }

        #endregion ==================== METHODS ====================
    }
}