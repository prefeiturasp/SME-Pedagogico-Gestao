using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SME.Pedagogico.Gestao.Data.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessLevels",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Codes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Codes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogControls",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogControls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MathPoolCAs",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DreEolCode = table.Column<string>(nullable: true),
                    NumeroChamada = table.Column<string>(nullable: true),
                    EscolaEolCode = table.Column<string>(nullable: true),
                    TurmaEolCode = table.Column<string>(nullable: true),
                    AlunoEolCode = table.Column<string>(nullable: true),
                    AlunoNome = table.Column<string>(nullable: true),
                    AnoLetivo = table.Column<int>(nullable: false),
                    AnoTurma = table.Column<int>(nullable: false),
                    Semestre = table.Column<int>(nullable: false),
                    Ordem1Ideia = table.Column<string>(nullable: true),
                    Ordem1Resultado = table.Column<string>(nullable: true),
                    Ordem2Ideia = table.Column<string>(nullable: true),
                    Ordem2Resultado = table.Column<string>(nullable: true),
                    Ordem3Ideia = table.Column<string>(nullable: true),
                    Ordem3Resultado = table.Column<string>(nullable: true),
                    Ordem4Ideia = table.Column<string>(nullable: true),
                    Ordem4Resultado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MathPoolCAs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MathPoolCMs",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DreEolCode = table.Column<string>(nullable: true),
                    NumeroChamada = table.Column<string>(nullable: true),
                    EscolaEolCode = table.Column<string>(nullable: true),
                    TurmaEolCode = table.Column<string>(nullable: true),
                    AlunoEolCode = table.Column<string>(nullable: true),
                    AlunoNome = table.Column<string>(nullable: true),
                    AnoLetivo = table.Column<int>(nullable: false),
                    AnoTurma = table.Column<int>(nullable: false),
                    Semestre = table.Column<int>(nullable: false),
                    Ordem3Ideia = table.Column<string>(nullable: true),
                    Ordem3Resultado = table.Column<string>(nullable: true),
                    Ordem4Ideia = table.Column<string>(nullable: true),
                    Ordem4Resultado = table.Column<string>(nullable: true),
                    Ordem5Ideia = table.Column<string>(nullable: true),
                    Ordem5Resultado = table.Column<string>(nullable: true),
                    Ordem6Ideia = table.Column<string>(nullable: true),
                    Ordem6Resultado = table.Column<string>(nullable: true),
                    Ordem7Ideia = table.Column<string>(nullable: true),
                    Ordem7Resultado = table.Column<string>(nullable: true),
                    Ordem8Ideia = table.Column<string>(nullable: true),
                    Ordem8Resultado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MathPoolCMs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MathPoolNumbers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DreEolCode = table.Column<string>(nullable: true),
                    NumeroChamada = table.Column<string>(nullable: true),
                    EscolaEolCode = table.Column<string>(nullable: true),
                    TurmaEolCode = table.Column<string>(nullable: true),
                    AlunoEolCode = table.Column<string>(nullable: true),
                    AlunoNome = table.Column<string>(nullable: true),
                    AnoLetivo = table.Column<int>(nullable: false),
                    AnoTurma = table.Column<int>(nullable: false),
                    Semestre = table.Column<int>(nullable: false),
                    Familiares = table.Column<string>(nullable: true),
                    Opacos = table.Column<string>(nullable: true),
                    Transparentes = table.Column<string>(nullable: true),
                    TerminamZero = table.Column<string>(nullable: true),
                    Algarismos = table.Column<string>(nullable: true),
                    Processo = table.Column<string>(nullable: true),
                    ZeroIntercalados = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MathPoolNumbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PollType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PollTypeDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortuguesePolls",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    dreCodeEol = table.Column<string>(nullable: true),
                    schoolCodeEol = table.Column<string>(nullable: true),
                    classroomCodeEol = table.Column<string>(nullable: true),
                    schoolYear = table.Column<string>(nullable: true),
                    yearClassroom = table.Column<string>(nullable: true),
                    studentCodeEol = table.Column<string>(nullable: true),
                    studentNameEol = table.Column<string>(nullable: true),
                    reading1B = table.Column<string>(nullable: true),
                    writing1B = table.Column<string>(nullable: true),
                    reading2B = table.Column<string>(nullable: true),
                    writing2B = table.Column<string>(nullable: true),
                    reading3B = table.Column<string>(nullable: true),
                    writing3B = table.Column<string>(nullable: true),
                    reading4B = table.Column<string>(nullable: true),
                    writing4B = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortuguesePolls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrivilegedAccess",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    OccupationPlace = table.Column<string>(nullable: true),
                    OccupationPlaceCode = table.Column<int>(nullable: false),
                    DreCodeEol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivilegedAccess", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentCodes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    CodeId = table.Column<string>(nullable: true),
                    StudentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentCodes_Codes_CodeId",
                        column: x => x.CodeId,
                        principalTable: "Codes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentCodes_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCodes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    CodeId = table.Column<string>(nullable: true),
                    TeacherId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherCodes_Codes_CodeId",
                        column: x => x.CodeId,
                        principalTable: "Codes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherCodes_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoggedUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    RefreshToken = table.Column<string>(nullable: true),
                    Session = table.Column<string>(nullable: true),
                    LastAccess = table.Column<DateTime>(nullable: false),
                    ExpiresAt = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoggedUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoggedUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StudentId = table.Column<string>(nullable: true),
                    TeacherId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profiles_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessLevelId = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_AccessLevels_AccessLevelId",
                        column: x => x.AccessLevelId,
                        principalTable: "AccessLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AccessLevels",
                columns: new[] { "Id", "Description", "Value" },
                values: new object[,]
                {
                    { "9ac485b1-1937-4fc6-a058-0c5f792b803b", "Secretário Escola", "28" },
                    { "dabe2b26-bb66-4e05-a344-2c8be28be920", "CEFAI", "18" },
                    { "d3318ed6-5a43-4aa3-a4df-c864f19d0802", "PAAI", "19" },
                    { "58c6191e-545f-4b44-9c04-097460abbb30", "DIPED DRE", "20" },
                    { "3a9e20ee-c32a-42c5-97dd-c0433882daa7", "Adm DRE", "21" },
                    { "c169267c-3ccc-4142-b4ff-3a1ea3b2108b", "Básico DRE", "22" },
                    { "db11cd19-01f8-484e-979e-722f555d4289", "Básico Escola", "23" },
                    { "14b1c27c-74cf-415b-84e1-95547a0e71de", "Infantil", "24" },
                    { "6635bf3e-3031-4135-9f1f-eab9a2139313", "UE Parceira", "25" },
                    { "85ffbfbf-0604-416c-ac09-6f438d531fbe", "AD", "26" },
                    { "28795439-c54e-47db-8eb1-9e25ef8b66d9", "CP", "27" },
                    { "78f8c86b-89bf-42a1-bdac-25660f1aeaa4", "AEE", "35" },
                    { "cbf2b915-a10a-4919-8d52-48d82640ac7a", "COTIC", "29" },
                    { "c169aa19-e917-4b1a-a8f5-c3b7265a6d5f", "UE", "30" },
                    { "cc20d42c-424d-4761-9e76-3e9d1222ebb6", "CJ E Volante (PEI, ADI)", "31" },
                    { "2cbe13a6-d27a-4987-b8aa-6898f7ccdc4a", "Fund. e Inf.", "32" },
                    { "470587a3-e791-4b7a-b40f-ea4461413810", "NAAPA", "17" },
                    { "ba1af705-f989-480d-a41f-4e8ead00db9f", "DIPED", "16" },
                    { "e3a924f4-5d29-40d4-8be1-9b6d02f785eb", "Supervisor DRE", "15" },
                    { "eca031f8-cf7e-45b9-ac5a-2a0b175b2d2d", "Técnico", "14" },
                    { "5336d36e-06b4-4939-b502-00f0e6bb314c", "ATE", "37" },
                    { "7ffc0419-07f9-4500-b6a6-27469357fe83", "Readaptado", "36" },
                    { "368836c2-50ba-4ae6-8d71-d1cf5a7ac694", "Desenvolvedor", "0" },
                    { "bba3238b-4aa8-4780-9d5b-1fb70d892487", "COTIC", "1" },
                    { "8ba728bc-b54b-4caf-bd22-68b893d3ee1c", "SME", "2" },
                    { "d424c0c4-5fb0-4a66-b148-5c6667892df2", "COPED", "3" },
                    { "1bd4e2fc-d1a6-4d64-81c6-cecd16d14131", "DIEFEM", "4" },
                    { "d9529284-fcf3-47fb-813e-2217df8f85cf", "POA", "33" },
                    { "b86deaad-efd3-41e7-92a1-27a8ecfc1b9b", "DIEI", "5" },
                    { "37dbfa94-adf5-4208-ad24-7cb1a53f13bb", "DIEE", "7" },
                    { "48dbac05-c72a-4ab9-9078-d298affdb126", "NTA", "8" },
                    { "853b1b86-6d8e-47b8-ac23-11533c585b12", "NTC", "9" },
                    { "f19f17c8-ea1b-4dbb-ba45-9247278dc157", "NTC-NAAPA", "10" },
                    { "91baa561-c938-4e74-83da-a68123a0d7cf", "DIEE-Conveniado", "11" },
                    { "aa9c60a5-5678-40c2-89c3-711505a47ab4", "COPED Básico", "12" },
                    { "4893d962-ee52-4464-bd21-dfd6f17fdd0c", "Regional", "13" },
                    { "c3618690-7de2-4ede-8412-54cdbda0143d", "DIEJA", "6" },
                    { "a9ad61fb-ef73-49fb-a98e-35bbecc59578", "PAP", "34" }
                });

            migrationBuilder.InsertData(
                table: "PollType",
                columns: new[] { "Id", "PollTypeDescription" },
                values: new object[,]
                {
                    { "e6c663bd-e496-40b1-af56-76b3b196754c", "Sondagem de Português" },
                    { "a2c5146c-57c0-4a5e-bb39-fe560598d0eb", "Sondagem de Alfabetização de Matemática" },
                    { "f075817d-7493-4d37-9f7f-b9d06b38cbf7", "Sondagem de Matemática" }
                });

            migrationBuilder.InsertData(
                table: "PrivilegedAccess",
                columns: new[] { "Id", "DreCodeEol", "Login", "Name", "OccupationPlace", "OccupationPlaceCode" },
                values: new object[,]
                {
                    { "9e4c3aca-d1c7-4c2b-92c1-1f83bde3b4ac", "108800", "6928161", "SIMONE DA SILVA", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "4b1053c0-d1e1-4e03-999f-a730b77f9d89", "108800", "8026637", "WAGNER RODRIGUES FLORIANO", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "d20e6776-7e1b-4036-8b83-b710d9389d1f", "108800", "7228287", "CAMILA RAMOS FRANCO DE SOUZA", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "a2d16406-3785-449f-9dc3-cd1bb0ae7396", "108800", "7528418", "PATRICIA FERNANDES ROSA", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "8b6b7d7c-3a64-4746-8141-4dccbe3a528c", "108800", "6200877", "PAULA DO NASCIMENTO JULIO AGNELLO", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "b0141395-332f-4527-ab7d-3553004605c3", "108800", "6391389", "IVAN VENTURINI", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "0ae5df4f-af56-40b9-a2a5-9629149e7ba6", "108800", "6751318", "GLAUCIA ESIMIR DE CAMARGO FANTOZZI HADAD", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "e63f90f0-1ba0-4c9a-b3f4-270d038d1a2c", "108800", "6777694", "SUMAYA GISELE MARTINS CAVALCANTE", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "4650eef5-e9f0-42d0-8762-1287047bd9f7", "108800", "6928161", "SIMONE DA SILVA", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "43a629e0-1f2a-4d3a-a2ca-723f233a925b", "108800", "7287160", "TATHIANA AUGUSTA RODRIGUES LOURENCO MARTINEZ", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "33b1c3f8-046d-448c-8c9f-7a0c206c5834", "108800", "7298587", "LIVIA LEDIER FELIX VIEIRA", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "bc9d55be-a531-4517-a17c-44d97b438077", "108800", "7705620", "LARISSA DE GOUVEIA", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "7fce7df5-d46b-4387-aaf7-45178f9abe3a", "108800", "7728182", "MARCELO DOS SANTOS DIAS", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "e7b8e505-3c2f-493a-9477-0b08cc1dcade", "108800", "7987498", "FABIANA LOPES LAURITO", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "8769315c-2cdc-42d1-aa44-96da86d8563a", "108800", "7990375", "ADRIANA SBEGHEN BONAFE ZACHHUBER", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "2faa651b-8ad2-4e3e-a110-5f4a0cd96147", "108800", "8028044", "MARIA CLAUDIA DA SILVA", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "de70d2a5-9d18-49c5-9c8c-96bc2cf732d8", "108800", "8028311", "ROBERTO BELISIARIO SANTOS", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "c0bcbd8a-9a96-44d5-b5a9-28913c7e751a", "108900", "7706812", "SIMONY DE LENA DOTTO", "DIRETORIA REGIONAL DE EDUCACAO PENHA", 3 },
                    { "9affbf19-b753-4d38-928b-044adfa8b0a8", "108900", "7721854", "CINTIA MITSUE KAMURA", "DIRETORIA REGIONAL DE EDUCACAO PENHA", 3 },
                    { "e54075e2-6d92-453d-8ff7-c62f8a152634", "108900", "7761279", "SUSAN QUILES QUISBERT", "DIRETORIA REGIONAL DE EDUCACAO PENHA", 3 },
                    { "e9ed65e8-8dd5-4142-8b9e-db7527b00160", "108700", "8206252", "JUCILENE ALVES GOMES DA SILVA", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "49d669d1-b4e3-4c38-b8db-286e2d4c9ca9", "108700", "6911161", "Liliane Aparecida Granzotti", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "8caca87b-c86e-4826-a624-786477eebed6", "108700", "8030910", "DIOGO LAZARO DE ARAUJO", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "6f0cce24-a8b1-4dd5-95f7-30d10677b4cc", "108700", "8030910", "DIOGO LAZARO DE ARAUJO", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "753bf950-61d9-46a4-b59e-bc6b4c3ff1ea", "108700", "7549695", "SELMA ANDREA DOS SANTOS SILVA", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "18db0e8a-0618-484e-85bf-ffa0fd18fd6b", "108700", "7807350", "REGIANE PEREA CARVALHO", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "4c914b6e-d1a1-45a8-ada7-23e7ddcb88a4", "108900", "6664253", "ELIANA SOUZA DA SILVA DE BENEDETTI", "DIRETORIA REGIONAL DE EDUCACAO PENHA", 3 },
                    { "1274d704-2c97-4162-9b7f-4a6bf74874c7", "108700", "7228546", "SIMONE RIBEIRO MANSANO", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "a9de3191-959d-4bf8-9356-a34a1e388d2b", "108700", "5908710", "MARCIA MARQUES DOS SANTOS", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "6022a2d5-3cf4-4ed7-b5b1-a0ec00da56bd", "108700", "5514894", "MARIA TEREZA VIEIRA SCHINZARI", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "bf5a1e3a-17e2-48ce-848c-7464b87668fc", "108700", "5841704", "ANA REGINA BARBOSA SPINARDI", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "6ddd6d5b-4501-41c2-a031-38c544c209ca", "108700", "6466419", "WANIA MAGALHAES", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "acf852ce-804d-4c16-9618-ed5f99d55105", "108700", "6664962", "ELIANE PRADO FREIRE", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "943b5718-9553-48f3-bf57-381d50297842", "108700", "8066086", "ANNA FLAVIA SANCHES DE ALMEIDA", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "6601ac5d-d6aa-482f-87e3-0ddc6c13cc2d", "108700", "6923968", "LUCIA RAMALHO NUNES MUNIS", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "56dc76b3-24a7-40e2-94af-f254a9d86097", "108700", "7264755", "ESTELA VANESSA DE MENEZES", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "0b7fe85a-f0c1-48bc-a6de-1366b0d219bd", "108700", "7400853", "ROSA HELENA DE FREITAS ROGERIO CARVALHO", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "a54d7934-46fd-4ed6-b3ed-52c621e40ae2", "108700", "7451016", "MONICA CRISTINA ALBERTINI DOS SANTOS", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "a5ce8616-0b3d-49d1-8fa8-c9484f29cfb9", "108700", "7531907", "KARINA LEITE RENTZ", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "016df9b3-4773-4597-856b-05190a140255", "108700", "7708980", "CAMILA NETO FERNANDES ANDRADE", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "2e0ae575-bc78-4b33-b86f-98c51213f6b8", "108700", "7807350", "REGIANE PEREA CARVALHO", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "5704284e-f256-4c6c-96ca-09de4aedc0f8", "108700", "7866518", "DAYANE CAMPOREZE RODRIGUES", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "4c43c37d-ab1e-4be7-b50e-4d3a7ac87b53", "108700", "7910649", "DANIELA LOURENCO DOS SANTOS", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "d23947c2-50a5-4b4c-ad13-64614937d66c", "108700", "7950969", "PRISCILA VAZ MAGRINELLI", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "751de089-f1a0-4bf6-b7f9-7ff0b664dc52", "108700", "7219253", "ALESSANDRA QUIQUETTO DE OLIVEIRA", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "7786c23c-dc64-4768-8c81-d2f2b65b99d4", "108900", "6011365", "LUCI BATISTA COSTA SOARES DE MIRANDA", "DIRETORIA REGIONAL DE EDUCACAO PENHA", 3 },
                    { "759960dd-9aa4-4075-b638-ce390376898e", "109200", "6389911", "MIRTES INNOCENCIO DA SILVA", "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS", 3 },
                    { "809fede9-c8b5-4063-ab64-5bdccb392ddd", "108900", "6033113", "VERA LUCIA CICON HERNANDES", "DIRETORIA REGIONAL DE EDUCACAO PENHA", 3 },
                    { "ad1b22b0-2ab2-4122-abfc-966ccc82c3f4", "109200", "8066736", "GIRSELEY ALEXANDRE GONCALVES SATO", "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS", 3 },
                    { "a48eb4c9-242c-42bd-b377-dc666e3581ba", "109200", "7357915", "DANIELA PINHEIRO ALVANI TERCIANO", "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS", 3 },
                    { "a88c0577-79d5-4261-aa8f-3697b6d0ef62", "109200", "8176337", "RENATA LIMA DURAES", "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS", 3 },
                    { "4c64cd59-7350-46c6-b0c7-2703209b61ca", "109300", "6944213", "CRISTIANE NASCIMENTO SILVA GOMES", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "f91e4bd6-3986-4059-937a-812cc90b1b52", "109300", "7288298", "IVO DOS SANTOS CARVALHO", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "7d940c6b-293c-4108-a934-b7b697a0ecb4", "109300", "7499361", "ANDREA ANGELO SOARES DOS SANTOS", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "9cf4302c-100b-4d12-ace5-7d8d6f724361", "109300", "5518091", "JAIR SIPIONI", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "cf6eb78a-2888-4262-ac57-ae71fb884ee7", "109300", "5629632", "ARLENE FERREIRA DOS SANTOS", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "3cf46cc1-97c5-4cbc-95b9-1c8403fdc1a7", "109300", "5759129", "MARIA ISABEL VIEIRA DE SOUZA", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "b0b29a6d-d740-4c7d-bf1a-b04e40f48c30", "109200", "7936095", "RENATA SANTANA DE MIRANDA CARDOSO", "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS", 3 },
                    { "76888722-a86d-4299-80bb-7077a3e69693", "109300", "6770134", "REGINA CELIA RIBEIRO DA SILVA", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "5a0d1a46-6f2f-48a5-8edb-13e5e6c2672a", "109300", "6840531", "EUNICE SOUSA DO NASCIMENTO", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "84fbfdf7-8d54-4a37-a777-d392c613c1fd", "109300", "6925961", "KEILA FERREIRA DA SILVA VIANA", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "60911bec-8ef3-472d-a245-7f160a8e9611", "109300", "7234392", "ROSANA CARLA DE OLIVEIRA", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "3541b0e1-7a15-4803-8673-8c240b1815b5", "109300", "7443994", "MARIA APARECIDA DE SOUZA SANTOS", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "9ff2d871-bd49-487c-8f9e-0d8f021766fe", "109300", "7479417", "RINA MARCIA DE ALMEIDA", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "a1364689-7cd5-4c30-976f-7019c9ecc659", "109300", "7502397", "ANA PAULA MENDES GUARINHO", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "745ac7ab-2027-4dda-9513-9732db21743f", "109300", "7872241", "PALOMA ROBERTA FERMINO", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "2ab02934-9e35-4e6f-860b-f8a20027ef6d", "109300", "8013799", "SIMONE APARECIDA SILVA", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "81906bf8-ae91-4491-891d-2ebaede4e11d", "109300", "8063389", "ADRIANA GOIS DE SOUZA", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "a2c2ffb5-151b-4823-a30b-8b52a640ca35", "109300", "6811361", "JANE CRISTINA DE SOUZA", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "e8ee71d9-b69b-414c-adf4-ae891489ad00", "109200", "7526555", "EDNA RIBEIRO DOS SANTOS", "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS", 3 },
                    { "7c13022e-70dd-48da-b217-42a3d0c24c1c", "109200", "7371161", "SERGIO EDUARDO MORENO HAEITMANN", "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS", 3 },
                    { "84b69f9c-8626-472f-98ad-3517971119a2", "109200", "7231555", "JESSICA NACCARATO DA SILVA", "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS", 3 },
                    { "d605cd5d-3fb6-42b2-af77-b6f7ebdf204d", "108900", "6306730", "ROSANA BATISTA", "DIRETORIA REGIONAL DE EDUCACAO PENHA", 3 },
                    { "c475a202-d43e-41aa-bf8b-b4a194cda537", "108900", "6788696", "OLESIA PATRICIA APARECIDA GIANNELLA HENRIQUE", "DIRETORIA REGIONAL DE EDUCACAO PENHA", 3 },
                    { "e1efe21b-98d8-4fbe-a5c6-88ce24b95a88", "108900", "7220278", "ALESSANDRA SERRA DE ABREU CAMPOS", "DIRETORIA REGIONAL DE EDUCACAO PENHA", 3 },
                    { "b469e937-0faa-4cf0-8486-46bc949be245", "108900", "7940645", "NUBIA NOGUEIRA CHINOCA", "DIRETORIA REGIONAL DE EDUCACAO PENHA", 3 },
                    { "90b84758-9e7c-44a5-ad00-4a89983a2187", "108900", "7986645", "THALITA GARCIA LOPES", "DIRETORIA REGIONAL DE EDUCACAO PENHA", 3 },
                    { "223301ec-db32-4b96-bf13-53e07aa36c71", "109000", "7761147", "MONICA GERDULLO SASSI", "DIRETORIA REGIONAL DE EDUCACAO PIRITUBA/JARAGUA", 3 },
                    { "b41461ca-1296-4557-8fc0-0ce636b017a9", "109000", "7279515", "REGINA BRUHNS ROSSINI ANDRADE", "DIRETORIA REGIONAL DE EDUCACAO PIRITUBA/JARAGUA", 3 },
                    { "2e3f04f4-a626-4215-af6f-8cf90dfa06f3", "109000", "6564283", "RUI DA SILVA LIMA", "DIRETORIA REGIONAL DE EDUCACAO PIRITUBA/JARAGUA", 3 },
                    { "07f83897-e884-4c91-a38d-f8c94af937aa", "109000", "7283199", "ADRIANA BONIFACIO CALIMAN", "DIRETORIA REGIONAL DE EDUCACAO PIRITUBA/JARAGUA", 3 },
                    { "baa4f782-216a-49c2-87b0-bd7f754c8b58", "109100", "7767951", "CLAUDIA GONCALVES DA SILVA", "DIRETORIA REGIONAL DE EDUCACAO SANTO AMARO", 3 },
                    { "0d40a1b8-0209-40a5-bf6f-80802f48f1d0", "109100", "6348564", "LINEIA RUIZ TRIVILIN", "DIRETORIA REGIONAL DE EDUCACAO SANTO AMARO", 3 },
                    { "9eaf4bea-90e3-4577-9bee-33c4bf2f4a20", "109100", "5781027", "CARLOS ANTONIO VIEIRA", "DIRETORIA REGIONAL DE EDUCACAO SANTO AMARO", 3 },
                    { "970ca343-485e-4bdb-9cb4-803c9ec3ce26", "109100", "7462131", "Solange Amalia da Cruz", "DIRETORIA REGIONAL DE EDUCACAO SANTO AMARO", 3 },
                    { "bcdaf51e-4f8a-4343-b6ef-2ce3518e58b9", "109100", "7516100", "Grace Zaggia Utimura", "DIRETORIA REGIONAL DE EDUCACAO SANTO AMARO", 3 },
                    { "c5676feb-3d82-4e79-9d3f-97e11997f3b8", "109100", "7725507", "Haroldo Heverton Souza de Arruda", "DIRETORIA REGIONAL DE EDUCACAO SANTO AMARO", 3 },
                    { "b1f6752c-9f94-498e-8ff1-048ddb54e13e", "109200", "6920951", "JOSE ANTONIO DOS SANTOS", "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS", 3 },
                    { "4136c647-9960-4a3d-84cd-760660be57c0", "109200", "7739214", "JOSE HUMBERTO DO NASCIMENTO", "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS", 3 },
                    { "8a3a2549-19e5-4e1b-841e-393bf8d77909", "109200", "7275803", "PAULA CRISTINA CASTRO PINHEIRO BANDLER", "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS", 3 },
                    { "267336fa-d6f6-40dd-b42c-ef78eb6a8132", "108600", "7913788", "ANDERSON ACIOLI MACHADO", "DIRETORIA REGIONAL DE EDUCACAO IPIRANGA", 3 },
                    { "403b8308-a983-4cf3-9c45-5967e06a137f", "109200", "5589100", "REJANE MARIA BRESSAN", "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS", 3 },
                    { "30a3209f-3eb4-4751-8670-91caaf0b1dd3", "109200", "7230486", "ADRIANA CRISTINA LOURENCO IUPI", "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS", 3 },
                    { "b433905d-56e8-4c9a-8a9d-a405936bda53", "108900", "5910935", "WANIA CRISTINA MANOEL", "DIRETORIA REGIONAL DE EDUCACAO PENHA", 3 },
                    { "390a984d-bf58-4c35-bda1-2f9b914f863e", "108600", "7441487", "ERIKA RENATA DE FREITAS", "DIRETORIA REGIONAL DE EDUCACAO IPIRANGA", 3 },
                    { "4ce3a8c9-7864-410f-a29f-e1d5a3c5a648", "108500", "5640539", "ROSANA RAIMONDI", "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES", 3 },
                    { "10be533e-a8c9-49be-9697-f97e4cbbd1e1", "108600", "6909795", "MARTA MALHEIROS ADRIANO", "DIRETORIA REGIONAL DE EDUCACAO IPIRANGA", 3 },
                    { "c39b87e2-7d84-4f63-9a65-5d4133d1782e", "", "7716125", "Uyara Vieira Costa de Andrade", "SME", 2 },
                    { "fd88f50c-6576-43bd-b7dd-c4263c126e85", "", "7924488", "Gabriela Manzolli Rowlands Lopes", "SME", 2 },
                    { "fb08025a-5458-4adb-9b55-58efdc19520a", "", "6941583", "Ronaldo José da Silveira", "SME", 2 },
                    { "6f321d3c-516d-4407-a530-6f5b66f75347", "", "6946895", "MINEA PASCHOALETO FRATELLI SONOBE", "SME", 2 },
                    { "0d1c1ee7-ed51-40b3-9248-50428dfac959", "", "6923950", "Rosangela Ferreira de Souza Queiroz", "SME", 2 },
                    { "6a63035e-94eb-4668-b86c-526796eee22b", "108100", "7418078", "Annaa Luisa de Castro", "DIRETORIA REGIONAL DE EDUCACAO BUTANTA", 3 },
                    { "2ea357d7-2406-44a3-899f-86a45703a774", "108100", "7936532", "DIEGO BENJAMIM NEVES", "DIRETORIA REGIONAL DE EDUCACAO BUTANTA", 3 },
                    { "a1e6ed59-d027-4cbe-b9fe-4b733dce7c12", "108100", "8019444", "JULIANO RODRIGO MACIEL FERNANDES", "DIRETORIA REGIONAL DE EDUCACAO BUTANTA", 3 },
                    { "a16bb182-5296-419b-a96a-c21d504360c7", "108100", "8019444", "JULIANO RODRIGO MACIEL FERNANDES", "DIRETORIA REGIONAL DE EDUCACAO BUTANTA", 3 },
                    { "546369b9-a24a-46f3-a878-b0b96b551b55", "", "7705182", "Kátia Sayuri Endo", "SME", 2 },
                    { "fd78ca54-3c94-49b1-a70d-8edd63a427ec", "108100", "7371489", "ROSANA RODRIGUES DA SILVA", "DIRETORIA REGIONAL DE EDUCACAO BUTANTA", 3 },
                    { "e77dfee8-7c15-45c7-929c-e59075046059", "108100", "8161828", "DANIEL DAMIAO DA SILVA", "DIRETORIA REGIONAL DE EDUCACAO BUTANTA", 3 },
                    { "2425dc81-3ed0-460e-8c8b-ef999c609cd2", "108100", "7940726", "Silvana Bastos Pereira Mendes", "DIRETORIA REGIONAL DE EDUCACAO BUTANTA", 3 },
                    { "43476b2c-7639-49b2-80b8-af3eb9a5e3a7", "108200", "6775861", "PATRICIA LACERDA", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "d5301668-d3a7-43b0-bf2e-4746caaeebdd", "108200", "7115571", "ROSANGELA JULIA DE MATOS MONTEIRO", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "265212cb-73c4-4564-b10e-4256d2f00878", "108200", "7251297", "CASSIA APARECIDA GUIMARAES", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "7bced4d5-cbc9-49de-a72d-cf1d206b1667", "108200", "7915144", "MARIA LUANA LIMA MENDES DOS SANTOS", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "a784241d-4365-4224-a0de-2e3b698d35e2", "108200", "6204619", "ROSELI HELENA DE SOUZA SALGADO", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "e3dbcfae-9e03-4917-a8be-705cce5f9a1c", "108600", "5996236", "ELAINE CRISTINA RAMOS DE ALMEIDA NUNES", "DIRETORIA REGIONAL DE EDUCACAO IPIRANGA", 3 },
                    { "1af63a67-d240-414b-be61-98746c32d240", "108200", "5413010", "CECILIA REGINA CARLINI FERREIRA COELHO", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "07b2a182-b94b-4af6-b721-f4967550a906", "108100", "6663648", "RUI FRANCISCO DA SILVA", "DIRETORIA REGIONAL DE EDUCACAO BUTANTA", 3 },
                    { "1428e31b-21ae-4106-8bb2-afaa07712a9d", "108200", "7213638", "RICARDO DE SOUZA", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "2687305e-59c2-462e-93cf-33d17d2bf293", "", "7827067", "Amanda Martins Amaro", "SME", 2 },
                    { "efaebf73-e387-421a-893b-06a85a71a44d", "", "7923490", "Lis Regia Pontedeiro", "SME", 2 },
                    { "33c4e826-7556-4725-91e9-558558b31e53", "", "caique.amcom", "Caique Latorre", "AMCOM", 1 },
                    { "6dbeab1d-9319-4868-bf60-d2db3df6dd13", "", "massato.amcom", "Massato Kanno", "AMCOM", 1 },
                    { "2d3fd050-e2c7-4414-a52c-2240cf2ed3b9", "", "daniel.amcom", "Daniel Matsumoto", "AMCOM", 1 },
                    { "8ce3a6ac-3306-4a07-8926-c6e5e51e6cd3", "", "danielli.amcom", "Danielli", "AMCOM", 1 },
                    { "457429e4-7304-47b0-9b9d-591768092aed", "", "jeff.amcom", "Jeff", "AMCOM", 1 },
                    { "fa34be50-bed5-4094-9743-0f106469ddfa", "", "aline.amcom", "Aline", "AMCOM", 1 },
                    { "7c745299-388a-4e16-abf9-436a1c35a3be", "", "gabi.sme", "Gabi", "SME", 2 },
                    { "9ee58035-bcf7-4654-bbf2-035e79752ed6", "", "heloisa.sme", "Heloisa Giannichi", "SME", 2 },
                    { "8c5f1356-89a3-4f9b-b7be-0c821dc5df58", "", "7951221", "Karla de Oliveira Queiroz", "SME", 2 },
                    { "39ca87d8-f0db-4250-9804-42a2340165d5", "", "7719086", "Fernando Araujo de Oliveira", "SME", 2 },
                    { "22713881-5523-4a00-8ce2-fa1033b07213", "", "8016119", "Daniela Harumi Hikawa", "SME", 2 },
                    { "bdaf9c4e-9a3b-4462-bccf-7e14b044851f", "", "7906706", "Felipe de Souza Costa", "SME", 2 },
                    { "34015653-7941-4262-be6b-990582e57573", "", "7944560", "Heloisa Maria de Morais Giannichi", "SME", 2 },
                    { "b5171d68-bd26-4de0-8937-b8bcdd51d487", "", "7744412", "Carla da Silva Francisco", "SME", 2 },
                    { "459231ad-eb6e-4de4-ba25-cad8cf6cbb3d", "", "8163740", "Paula Giampietri Franco", "SME", 2 },
                    { "41c4abe7-a950-48aa-8ecc-4800e5513c3b", "", "6122147", "Humberto Luis de Jesus", "SME", 2 },
                    { "1f33cc43-45ee-4b43-ae82-a935d5d2f5c0", "", "7727640", "Kátia Gisele Turollo do Nascimento", "SME", 2 },
                    { "68238f9f-3982-442b-aefc-f1977682e39a", "", "7887337", "Thayrê Marin Alves de Lima", "SME", 2 },
                    { "45199d3e-3168-4db9-8a98-57b2cd1b0f3e", "", "6888895", "Fernando Jorge Barrios", "SME", 2 },
                    { "c269d2c8-8009-40dc-8fcd-9ca6fe99c2a5", "", "2994267", "Edna Calvo Leite", "SME", 2 },
                    { "5755a6e8-aed7-4931-8954-b50bea983c0b", "", "7937431", "Cintia Anselmo dos Santos", "SME", 2 },
                    { "499d8144-ad16-41c9-9d5d-f535d48840e7", "108200", "7550618", "LUANNA OLIVEIRA DE ALMEIDA", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "f77840ee-d161-4e23-ae9e-942dca31af75", "108200", "6940145", "REGINA PAULA COLLAZO BERTUCCIOLI", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "56281bca-9e2b-4e6d-b05e-e4adc692b724", "108200", "7814062", "DEMETRIUS SARAIVA GOMES", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "30a10434-208b-4123-950a-0a25086263cc", "108400", "6686362", "ROBERTO ANTONIO MACIEL", "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA", 3 },
                    { "aea81465-e46a-4f4f-86a3-28d33e8bf9d5", "108400", "6719767", "MARTHA LUCIA BRAGA", "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA", 3 },
                    { "db6b3d5a-1b82-4578-aaf9-b49cc5f4d432", "108200", "7731892", "LEANDRO ALVES DOS SANTOS", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "280c94a6-e13f-4b4a-8118-39a43fd033e1", "108400", "8023999", "ADELINE FERNANDES FERREIRA", "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA", 3 },
                    { "39e829d0-4e14-4cba-9777-a07b18c3cb78", "108400", "8055327", "THAIS CHARELLI MARTINS", "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA", 3 },
                    { "d05f36d6-0933-4948-bc64-65f4ca6954b0", "108400", "8160490", "JULIO CESAR DE CARVALHO SANTOS", "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA", 3 },
                    { "8a31ff3b-45b7-4e55-bf10-aae5382ccdcc", "108400", "8219532", "ANA CRISTINA PEREIRA", "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA", 3 },
                    { "ff9fed57-13f0-44c7-8b7a-0ad9f1ee4539", "108500", "6940773", "ROMEU GUIMARAES GUSMAO", "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES", 3 },
                    { "d2a3be43-31ab-4bb9-a14a-d83f44a71ee2", "108500", "6784011", "ESTER MARQUES DE PAULA DIONISIO", "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES", 3 },
                    { "1e15c9a0-c126-40bc-a091-23d85eda06b6", "108400", "6383793", "JOSE ALVES MARTINS FILHO", "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA", 3 },
                    { "0750fca3-650c-46c5-9876-2a93e9de1708", "108500", "6767494", "LUCIMEIRE CABRAL DE SANTANA FREITAS", "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES", 3 },
                    { "207f8ba0-edcc-4c3e-88b2-30c8efd4182b", "108500", "7935897", "BIANCA FREIRE DOS SANTOS", "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES", 3 },
                    { "4f12582c-9cdb-4fb8-8a13-91c8a6bf4c90", "108500", "5358051", "Rosana Soares Godinho", "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES", 3 },
                    { "bf48f83d-67c9-471a-ab4b-1c1a6d147d37", "108500", "7976445", "Fernanda Moreira Xavier", "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES", 3 },
                    { "54831a56-4898-4482-8b13-8739be100468", "108500", "7808208", "Luciano de Brito Leal", "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES", 3 },
                    { "f239f27d-c1c2-4228-8c33-b161084a92e1", "108500", "8401918", "MARIA INES ALVES PEREIRA", "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES", 3 },
                    { "16a2de0a-3a7b-4d05-a549-35a536bb5b88", "108600", "6002129", "KELLEY CARVALHO MONTEIRO DE OLIVEIRA", "DIRETORIA REGIONAL DE EDUCACAO IPIRANGA", 3 },
                    { "6b68ca04-2932-4bda-b69f-d6198d39ff09", "108600", "7326238", "IRAIDE SILVA RIBEIRO DOS SANTOS", "DIRETORIA REGIONAL DE EDUCACAO IPIRANGA", 3 },
                    { "f10b658e-3d79-4945-9e79-ea8bedf5fae5", "108600", "8078734", "FRANCISCO FABIANO DANTAS SANTOS", "DIRETORIA REGIONAL DE EDUCACAO IPIRANGA", 3 },
                    { "def5564e-f222-44c8-a7a2-9c54f810aaa0", "108600", "5988861", "MARCELO AUGUSTO MACHADO", "DIRETORIA REGIONAL DE EDUCACAO IPIRANG", 3 },
                    { "a7331401-706a-41bf-863e-f4526b15dd96", "108500", "7705719", "SILVANA DOS SANTOS SILVA", "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES", 3 },
                    { "55525053-ba73-4007-b375-6f8ade4e0011", "108400", "580553", "SISI MARIA VENTURA", "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA", 3 },
                    { "57fc0ca1-bc22-4554-bb9d-9d8d9aadae86", "108400", "7237383", "JULIANA NAGAHAMA", "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA", 3 },
                    { "8a36d222-b0d0-48b4-b2bb-894b54689611", "108400", "7456191", "DANIELE LEITE FERREIRA MEMOLI", "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA", 3 },
                    { "3434bd15-022f-400e-b661-0ff3f40a3730", "108200", "8044953", "CLEOMAR DE SOUZA LIMA", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "54b1c385-3e7c-4df4-86e0-020a7f935dec", "108200", "5830834", "RITA DE CASSIA GERALDI MENEGON", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "dad9ec61-733c-4103-ab44-9891a51dbd99", "108200", "6062130", "CRISTINA BARROCO MASSEI FERNANDES", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "a869f0b9-42e2-4d9b-96f6-105587e1f926", "108200", "6604439", "ELISABETE MARTINS DA FONSECA", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "e3a4c3ed-2972-45ae-a9fe-19cfee94251c", "108200", "7373121", "ANGELICA DE ALMEIDA MERLI", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "b7b57410-07c5-4af7-b874-42339a74897a", "108200", "8582416", "KARINA ESTEVES BELMONTE", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "a386dff7-05fb-4bd5-b58c-5ef7df50b78c", "108400", "6751067", "MARCIA REGINA BARRELLI", "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA", 3 },
                    { "ed14dc7f-8f94-4331-8742-80c2704ea710", "108300", "8022691", "TATIANA FERREIRA COSTA", "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO", 3 },
                    { "9338c49e-ad20-4527-a4d2-b7d169329041", "108300", "8036080", "Luciene Aparecida Grisolio Cioffi", "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO", 3 },
                    { "cdb72015-4231-4781-a554-53ec137a59de", "108300", "8094411", "Eduardo  Murakami da Silva", "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO", 3 },
                    { "d0e7e973-841e-44fe-910c-99916c552997", "108300", "7944527", "JAQUELINE APARECIDA DE LIMA MATOS", "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO", 3 },
                    { "32ab4c77-8f5a-486f-b1d5-dc34f20c115c", "108300", "5974755", "SANDRA REGINA DE CARVALHO", "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO", 3 },
                    { "3eabc7f9-e961-4a3b-a6bf-aab6f355138e", "108300", "5929156", "MARIA TERESA FUEYO", "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO", 3 },
                    { "41ca514a-5185-44b0-a45c-0653431309cc", "108400", "6383793", "JOSE ALVES MARTINS FILHO", "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA", 3 },
                    { "0765ab2b-d31b-4fbb-b4dc-fa78aeeaa9cd", "108300", "8206597", "MICHELLE BARBOSA FONSECA", "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO", 3 },
                    { "1509fc87-6c21-4468-9368-758e69af0685", "108300", "7721803", "OSMIR SANTOS MACEDO", "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO", 3 },
                    { "db3d6ba8-74b2-4983-99ea-79f6c881d838", "108400", "7953542", "SORAIA APARECIDA INACIO DA CRUZ", "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA", 3 },
                    { "427033f4-dfc1-4a10-93d3-0cf8efa89eef", "108300", "7510691", "MARINA DAS GRACAS MORAES", "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO", 3 },
                    { "c17ca3c0-fbb7-4fff-98b1-7e6345a32dac", "108300", "7256795", "ROSANA BUENO", "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO", 3 },
                    { "2c6cbb53-6fac-4cb3-a4c7-60f43d6b599c", "108300", "6911323", "MARCELA DE PINA BERGAMINE", "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO", 3 },
                    { "28d2f047-5190-47ec-8260-8e62cec41da1", "108300", "6941095", "CAROLINA NOGUEIRA DROGA", "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO", 3 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "113cd716-9c71-4056-a6d0-3f0b02230359", "Aluno" },
                    { "023a52a5-dfb1-4770-914c-6ce2e70a0529", "Admin" },
                    { "9d0c344c-7e23-47a5-8905-1f73c400b4b8", "Diretor" },
                    { "aacb2d2a-c070-4a8a-89d4-9ef4f388bac1", "CP" },
                    { "1e3802a5-d76c-4fb2-98db-1d81be1d7262", "Diretor" },
                    { "359f467e-4df4-4572-b8a4-67999711ea97", "Secretario(a)" },
                    { "8dc0247c-04db-45e4-813c-4f8943dce5fa", "Auxiliar" },
                    { "03165f0e-0844-44fd-bbbd-b0ac023639cd", "Professor" },
                    { "c7e42867-1f14-48fc-8dda-5580a37a8e4e", "Responsavel" },
                    { "892d29db-154d-475a-adf6-e6a7daa2c91e", "Adm DRE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoggedUsers_UserId",
                table: "LoggedUsers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_StudentId",
                table: "Profiles",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_TeacherId",
                table: "Profiles",
                column: "TeacherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCodes_CodeId",
                table: "StudentCodes",
                column: "CodeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCodes_StudentId",
                table: "StudentCodes",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCodes_CodeId",
                table: "TeacherCodes",
                column: "CodeId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCodes_TeacherId",
                table: "TeacherCodes",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_AccessLevelId",
                table: "UserRoles",
                column: "AccessLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogControls");

            migrationBuilder.DropTable(
                name: "LoggedUsers");

            migrationBuilder.DropTable(
                name: "MathPoolCAs");

            migrationBuilder.DropTable(
                name: "MathPoolCMs");

            migrationBuilder.DropTable(
                name: "MathPoolNumbers");

            migrationBuilder.DropTable(
                name: "PollType");

            migrationBuilder.DropTable(
                name: "PortuguesePolls");

            migrationBuilder.DropTable(
                name: "PrivilegedAccess");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "StudentCodes");

            migrationBuilder.DropTable(
                name: "TeacherCodes");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Codes");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "AccessLevels");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
