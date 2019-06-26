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
                    { "cc90c334-7ac8-4cf5-b24c-f79216e5ac86", "Secretário Escola", "28" },
                    { "ec1ecd44-bcb2-4e8a-94d8-963083866510", "CEFAI", "18" },
                    { "2783c0d5-c983-4427-aac6-cf297c3db5c6", "PAAI", "19" },
                    { "0445ac25-7dcf-43c9-bdf4-f4d4087a6a58", "DIPED DRE", "20" },
                    { "c366bfa6-c2d7-47cb-bdec-720a44d642a2", "Adm DRE", "21" },
                    { "4214d684-4289-4d09-8947-95ecaec71d5b", "Básico DRE", "22" },
                    { "72af2f07-9909-4726-b096-20c24418414c", "Básico Escola", "23" },
                    { "1586d2ac-4c0f-40b7-9be1-48c32cd0a6bd", "Infantil", "24" },
                    { "269b6c5d-4f8f-48ef-974b-08289836258c", "UE Parceira", "25" },
                    { "ad23c9f3-80ce-4372-bf48-97f204b3db28", "AD", "26" },
                    { "a7b1b287-5a03-4f56-a074-e65d6babbca2", "CP", "27" },
                    { "faba9e51-7899-40f8-a6b2-b72cb6c604a4", "AEE", "35" },
                    { "e81af9b7-129c-45d1-bb69-9380dddaa857", "COTIC", "29" },
                    { "bd3e91c4-89e8-43aa-a532-0cfd2ed313a0", "UE", "30" },
                    { "21e425bd-567d-4303-8749-4af40a4edfaf", "CJ E Volante (PEI, ADI)", "31" },
                    { "a0ebaabd-24d1-4b4e-b584-ccad6994aa9a", "Fund. e Inf.", "32" },
                    { "0eb07de9-1ee7-4192-8a56-da8ad275bef3", "NAAPA", "17" },
                    { "bcbe9f61-c8d1-4fc0-bffd-27bdf3274b3e", "DIPED", "16" },
                    { "89dbe199-f044-4dea-ac67-16be72dffb54", "Supervisor DRE", "15" },
                    { "1e6db09f-64ff-442e-9194-fc817d1b4f11", "Técnico", "14" },
                    { "99ab2735-cef2-44f0-965a-2e58615cf2b0", "ATE", "37" },
                    { "3e06f944-c2e3-4d69-9561-5aa5bf827d2b", "Readaptado", "36" },
                    { "dee1c2e5-b04b-4621-9729-c7b0e7972899", "Desenvolvedor", "0" },
                    { "6e089c2c-2b94-4b16-93be-2c887c3252e5", "COTIC", "1" },
                    { "11ab3d86-20cf-4f9e-a00e-27a343813208", "SME", "2" },
                    { "b986be3e-dd2f-41d7-b3f2-61c1af77b25c", "COPED", "3" },
                    { "3890adab-cc3e-446e-9c66-21df25a605fb", "DIEFEM", "4" },
                    { "a56ea02e-75d3-4f3e-9382-8f560109a448", "POA", "33" },
                    { "d68c57be-01d2-45c3-86cd-31bf79ead9fe", "DIEI", "5" },
                    { "b60eb98c-c0ea-4062-82bc-7de3f940d132", "DIEE", "7" },
                    { "46ba752f-d244-45be-933c-5f2a8978bff6", "NTA", "8" },
                    { "82f396f3-1d39-4679-bfcf-735972f9d5f8", "NTC", "9" },
                    { "8f2dd730-be30-4898-b14e-e4cea347f569", "NTC-NAAPA", "10" },
                    { "c24edc24-1d05-4e37-ba16-8828194589d2", "DIEE-Conveniado", "11" },
                    { "36a071cb-08db-4d10-84eb-fc4e0e189590", "COPED Básico", "12" },
                    { "f0b5ad9b-c8a3-4769-9f73-30846a90dc27", "Regional", "13" },
                    { "0997022f-329e-4801-b54c-2b483824390d", "DIEJA", "6" },
                    { "8c4bcc0c-7123-4bad-a38c-cdd74f93049e", "PAP", "34" }
                });

            migrationBuilder.InsertData(
                table: "PollType",
                columns: new[] { "Id", "PollTypeDescription" },
                values: new object[,]
                {
                    { "dde1ef30-fd7d-4bb1-be60-c60540a0d5e8", "Sondagem de Português" },
                    { "fcc9fd55-8c9e-4d6b-a055-9abd7425b593", "Sondagem de Alfabetização de Matemática" },
                    { "2da0e938-e030-4dda-aa20-cc20fc10184c", "Sondagem de Matemática" }
                });

            migrationBuilder.InsertData(
                table: "PrivilegedAccess",
                columns: new[] { "Id", "DreCodeEol", "Login", "Name", "OccupationPlace", "OccupationPlaceCode" },
                values: new object[,]
                {
                    { "0ca2c58d-3fde-45be-9a7d-433b447a50c1", "108800", "6928161", "SIMONE DA SILVA", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "65dad45a-f14c-4308-8e21-76d1827bb426", "108800", "8026637", "WAGNER RODRIGUES FLORIANO", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "6969a39c-1bb6-4cec-b69b-2842f1bf60b0", "108800", "7228287", "CAMILA RAMOS FRANCO DE SOUZA", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "c50fd30e-a272-4943-92e9-4e05b67e91bf", "108800", "7528418", "PATRICIA FERNANDES ROSA", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "04fb81bd-a06e-4828-8416-c1a34fa620e0", "108800", "6200877", "PAULA DO NASCIMENTO JULIO AGNELLO", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "7144c034-d9ce-4581-9d54-ff10c9420f00", "108800", "6391389", "IVAN VENTURINI", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "c25db8bd-21b0-4a37-b9ae-8521c880f15f", "108800", "6751318", "GLAUCIA ESIMIR DE CAMARGO FANTOZZI HADAD", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "ca5f7cc8-8abd-4f05-ae42-af3b2f068863", "108800", "6777694", "SUMAYA GISELE MARTINS CAVALCANTE", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "72792770-7cf3-48f6-b99f-9a963ee6b528", "108800", "6928161", "SIMONE DA SILVA", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "efba0e92-55e5-4488-8722-2e335d2fda21", "108800", "7287160", "TATHIANA AUGUSTA RODRIGUES LOURENCO MARTINEZ", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "20d9123b-83cc-4169-bfc8-095db411878d", "108800", "7298587", "LIVIA LEDIER FELIX VIEIRA", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "a3aeeb8e-a5cc-4f6f-a7c9-4413145a53ce", "108800", "7705620", "LARISSA DE GOUVEIA", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "24a7fe35-fb41-4c8b-89c0-e6e976188a97", "108800", "7728182", "MARCELO DOS SANTOS DIAS", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "effe8cb1-6711-4775-8120-32e6b5c79701", "108800", "7987498", "FABIANA LOPES LAURITO", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "a9e153e6-4cc2-4506-a864-9b4db72601c9", "108800", "7990375", "ADRIANA SBEGHEN BONAFE ZACHHUBER", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "e8464780-13af-40a4-8674-af70e38f2b99", "108800", "8028044", "MARIA CLAUDIA DA SILVA", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "5b320a48-5dab-4b43-97c7-e2c230e877d8", "108800", "8028311", "ROBERTO BELISIARIO SANTOS", "DIRETORIA REGIONAL DE EDUCACAO JACANA/TREMEMBE", 3 },
                    { "0b690789-93e0-431f-a5d9-f10fb1f0de7e", "108900", "7706812", "SIMONY DE LENA DOTTO", "DIRETORIA REGIONAL DE EDUCACAO PENHA", 3 },
                    { "1bbbe44d-bddd-4c6e-838e-afbea5d57135", "108900", "7721854", "CINTIA MITSUE KAMURA", "DIRETORIA REGIONAL DE EDUCACAO PENHA", 3 },
                    { "73e8d755-1bfc-4cc5-8d6b-4175bae146ca", "108900", "7761279", "SUSAN QUILES QUISBERT", "DIRETORIA REGIONAL DE EDUCACAO PENHA", 3 },
                    { "7dd74068-e2f9-4502-b132-f989596cba17", "108700", "8206252", "JUCILENE ALVES GOMES DA SILVA", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "b02af9ff-5216-4666-adbd-73116ee7e644", "108700", "6911161", "Liliane Aparecida Granzotti", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "14dc348e-b738-4867-9b16-f5b030638fad", "108700", "8030910", "DIOGO LAZARO DE ARAUJO", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "7806d41e-7937-4803-94eb-6f59fdddcfcc", "108700", "8030910", "DIOGO LAZARO DE ARAUJO", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "5ad88522-f47d-4f21-b89d-d096087d8d57", "108700", "7549695", "SELMA ANDREA DOS SANTOS SILVA", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "7cee470d-d979-4a2d-82da-5cba5e72c1b3", "108700", "7807350", "REGIANE PEREA CARVALHO", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "3fed35dc-d20d-462d-a122-3732e8245aa6", "108900", "6664253", "ELIANA SOUZA DA SILVA DE BENEDETTI", "DIRETORIA REGIONAL DE EDUCACAO PENHA", 3 },
                    { "e222123b-8b71-4889-9e9a-2c02cc3ad68b", "108700", "7228546", "SIMONE RIBEIRO MANSANO", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "07900b45-670a-4150-8bf2-7eda7c6047d0", "108700", "5908710", "MARCIA MARQUES DOS SANTOS", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "b840208a-8076-4103-ba3e-fb5e9796df96", "108700", "5514894", "MARIA TEREZA VIEIRA SCHINZARI", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "26b7e596-b098-4dd6-aeda-215ace412f40", "108700", "5841704", "ANA REGINA BARBOSA SPINARDI", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "df0c1428-3dde-4815-b6a9-5a977a4604b3", "108700", "6466419", "WANIA MAGALHAES", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "f780e21f-55a3-4fe2-b4ee-90ede6e0d21a", "108700", "6664962", "ELIANE PRADO FREIRE", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "d15baf96-1432-48e0-adef-e98dedde64c5", "108700", "8066086", "ANNA FLAVIA SANCHES DE ALMEIDA", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "d78ef4a9-9eae-46b9-84ae-df6f29cf771a", "108700", "6923968", "LUCIA RAMALHO NUNES MUNIS", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "c134e730-1ddc-4c75-90e9-570730a34321", "108700", "7264755", "ESTELA VANESSA DE MENEZES", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "b5afbe5f-090d-4261-815d-62b0708c56de", "108700", "7400853", "ROSA HELENA DE FREITAS ROGERIO CARVALHO", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "1f08205f-2436-451f-9f1a-e30af8763635", "108700", "7451016", "MONICA CRISTINA ALBERTINI DOS SANTOS", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "782943cf-8cd2-4369-8470-6c01b308359d", "108700", "7531907", "KARINA LEITE RENTZ", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "f28cf705-f2bb-4906-8c7b-57a33d0e37da", "108700", "7708980", "CAMILA NETO FERNANDES ANDRADE", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "9240d99b-63cf-4107-8fba-2beef99bb448", "108700", "7807350", "REGIANE PEREA CARVALHO", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "49747555-9d5e-4c41-bd7e-7564c0b03c76", "108700", "7866518", "DAYANE CAMPOREZE RODRIGUES", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "2e84bec9-0731-42db-8eab-46f8e8aba508", "108700", "7910649", "DANIELA LOURENCO DOS SANTOS", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "2129a5a1-64e9-472c-8784-57bdd2ea7596", "108700", "7950969", "PRISCILA VAZ MAGRINELLI", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "f37af113-fe08-43d6-8f84-f91dcd8f74ed", "108700", "7219253", "ALESSANDRA QUIQUETTO DE OLIVEIRA", "DIRETORIA REGIONAL DE EDUCACAO ITAQUERA", 3 },
                    { "a7e40741-65bf-4271-a938-6c45263d4b10", "108900", "6011365", "LUCI BATISTA COSTA SOARES DE MIRANDA", "DIRETORIA REGIONAL DE EDUCACAO PENHA", 3 },
                    { "9bf115ac-456a-46f1-8cd3-809aa5812273", "109200", "6389911", "MIRTES INNOCENCIO DA SILVA", "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS", 3 },
                    { "2f3dd564-d95f-4440-ba6e-817a6f8d7ba9", "108900", "6033113", "VERA LUCIA CICON HERNANDES", "DIRETORIA REGIONAL DE EDUCACAO PENHA", 3 },
                    { "1779e49c-a645-4500-9e82-55c392d13d29", "109200", "8066736", "GIRSELEY ALEXANDRE GONCALVES SATO", "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS", 3 },
                    { "bd479add-1b5b-4784-ab6d-fb767dd10f37", "109200", "7357915", "DANIELA PINHEIRO ALVANI TERCIANO", "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS", 3 },
                    { "4f123d0c-61cd-4a9c-9031-1ef075cd5ad9", "109200", "8176337", "RENATA LIMA DURAES", "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS", 3 },
                    { "2e6f3d01-0468-48fb-b99e-c57f2e030dcc", "109300", "6944213", "CRISTIANE NASCIMENTO SILVA GOMES", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "7631e2cb-91e9-4918-80da-6da2535948eb", "109300", "7288298", "IVO DOS SANTOS CARVALHO", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "c579518e-da31-43af-aecb-ae438473bae4", "109300", "7499361", "ANDREA ANGELO SOARES DOS SANTOS", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "2c0ebfb8-1c94-46eb-bfe0-bc1cf87ab6e7", "109300", "5518091", "JAIR SIPIONI", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "b9fd8ef8-2735-4c12-addd-56897519c380", "109300", "5629632", "ARLENE FERREIRA DOS SANTOS", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "ddecf7e1-1a99-4cc0-b2ee-29c1e3deeeb5", "109300", "5759129", "MARIA ISABEL VIEIRA DE SOUZA", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "87a656ec-fa20-4b4a-82ba-6b3f081c7c47", "109200", "7936095", "RENATA SANTANA DE MIRANDA CARDOSO", "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS", 3 },
                    { "04911c66-f4d2-4d8e-bee9-5ae0102785fa", "109300", "6770134", "REGINA CELIA RIBEIRO DA SILVA", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "0ce65fa0-1b6c-4cb8-9ca7-891ae7bc8421", "109300", "6840531", "EUNICE SOUSA DO NASCIMENTO", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "b87858f4-31aa-4b48-97b3-23c70eea5b66", "109300", "6925961", "KEILA FERREIRA DA SILVA VIANA", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "51b8ba83-20a5-4c40-a86e-8340c2ba3017", "109300", "7234392", "ROSANA CARLA DE OLIVEIRA", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "9331c13c-7988-41ff-a8ef-6a8e64061671", "109300", "7443994", "MARIA APARECIDA DE SOUZA SANTOS", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "e71bc614-d588-4837-9d3f-1c51e97f5af9", "109300", "7479417", "RINA MARCIA DE ALMEIDA", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "7bf869e6-95c9-4689-a97b-4a2b0bc9b5e1", "109300", "7502397", "ANA PAULA MENDES GUARINHO", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "9a38a118-495e-49d2-89ea-ab6ba8d4f169", "109300", "7872241", "PALOMA ROBERTA FERMINO", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "bc4a7299-c041-4a11-b40e-855fa5335570", "109300", "8013799", "SIMONE APARECIDA SILVA", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "ad6f7041-4018-433a-84a7-ab57fa8df5f4", "109300", "8063389", "ADRIANA GOIS DE SOUZA", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "0e3a7471-466f-4d7a-bc21-1790e8e7a01b", "109300", "6811361", "JANE CRISTINA DE SOUZA", "DIRETORIA REGIONAL DE EDUCACAO SAO MIGUEL", 3 },
                    { "8eba8501-340e-46dc-862f-5a72b4d06719", "109200", "7526555", "EDNA RIBEIRO DOS SANTOS", "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS", 3 },
                    { "e08732b0-3071-46b7-9492-c8c4f1c8d87a", "109200", "7371161", "SERGIO EDUARDO MORENO HAEITMANN", "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS", 3 },
                    { "d667ca06-f8b3-4315-af0d-808648fc127b", "109200", "7231555", "JESSICA NACCARATO DA SILVA", "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS", 3 },
                    { "a7976e6b-9a5c-45a6-87b8-ac13c07a59d6", "108900", "6306730", "ROSANA BATISTA", "DIRETORIA REGIONAL DE EDUCACAO PENHA", 3 },
                    { "a9289425-618e-4a69-86e6-399ed78a851a", "108900", "6788696", "OLESIA PATRICIA APARECIDA GIANNELLA HENRIQUE", "DIRETORIA REGIONAL DE EDUCACAO PENHA", 3 },
                    { "2fabd104-7a22-40e4-9df1-9f9c5b9bfa44", "108900", "7220278", "ALESSANDRA SERRA DE ABREU CAMPOS", "DIRETORIA REGIONAL DE EDUCACAO PENHA", 3 },
                    { "d6ae3572-d825-4a26-87f0-f8b615e2e29d", "108900", "7940645", "NUBIA NOGUEIRA CHINOCA", "DIRETORIA REGIONAL DE EDUCACAO PENHA", 3 },
                    { "78910a2b-d3b8-4885-af24-4a5df9571ca7", "108900", "7986645", "THALITA GARCIA LOPES", "DIRETORIA REGIONAL DE EDUCACAO PENHA", 3 },
                    { "79609f9b-5641-4309-ac0b-50c4ee4bc8be", "109000", "7761147", "MONICA GERDULLO SASSI", "DIRETORIA REGIONAL DE EDUCACAO PIRITUBA/JARAGUA", 3 },
                    { "c5836473-017b-4bcd-b580-5ffa83c6bac4", "109000", "7279515", "REGINA BRUHNS ROSSINI ANDRADE", "DIRETORIA REGIONAL DE EDUCACAO PIRITUBA/JARAGUA", 3 },
                    { "f62687f8-7cb8-492c-b8fc-1e195e886d1f", "109000", "6564283", "RUI DA SILVA LIMA", "DIRETORIA REGIONAL DE EDUCACAO PIRITUBA/JARAGUA", 3 },
                    { "066c7ac6-56a0-4f2d-9ddc-bbbfffe99c69", "109000", "7283199", "ADRIANA BONIFACIO CALIMAN", "DIRETORIA REGIONAL DE EDUCACAO PIRITUBA/JARAGUA", 3 },
                    { "6bbd2153-9c18-4594-881c-13af24d164cc", "109100", "7767951", "CLAUDIA GONCALVES DA SILVA", "DIRETORIA REGIONAL DE EDUCACAO SANTO AMARO", 3 },
                    { "2a02d636-fde7-49ac-b4c9-243e44a97ccf", "109100", "6348564", "LINEIA RUIZ TRIVILIN", "DIRETORIA REGIONAL DE EDUCACAO SANTO AMARO", 3 },
                    { "3a2f08ca-18fb-4e38-b4a0-b4c093ca2382", "109100", "5781027", "CARLOS ANTONIO VIEIRA", "DIRETORIA REGIONAL DE EDUCACAO SANTO AMARO", 3 },
                    { "610b0562-fe6a-48ad-9d0e-d985bc29bf3b", "109100", "7462131", "Solange Amalia da Cruz", "DIRETORIA REGIONAL DE EDUCACAO SANTO AMARO", 3 },
                    { "0b3cb612-cd47-4bbe-ba6f-9c0043768090", "109100", "7516100", "Grace Zaggia Utimura", "DIRETORIA REGIONAL DE EDUCACAO SANTO AMARO", 3 },
                    { "69d89816-8562-42a2-b4d6-ef50368c2a66", "109100", "7725507", "Haroldo Heverton Souza de Arruda", "DIRETORIA REGIONAL DE EDUCACAO SANTO AMARO", 3 },
                    { "3c24a5d6-3843-4e77-b3be-3cc157ff7904", "109200", "6920951", "JOSE ANTONIO DOS SANTOS", "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS", 3 },
                    { "6eebb01b-1ec3-46c1-852d-bab6883af0e6", "109200", "7739214", "JOSE HUMBERTO DO NASCIMENTO", "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS", 3 },
                    { "c742d023-cf3d-4449-b487-e4c8feb1217f", "109200", "7275803", "PAULA CRISTINA CASTRO PINHEIRO BANDLER", "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS", 3 },
                    { "401db9b4-7f71-4538-ab72-1f0ba81b9928", "108600", "7913788", "ANDERSON ACIOLI MACHADO", "DIRETORIA REGIONAL DE EDUCACAO IPIRANGA", 3 },
                    { "1768baf8-a6d8-4d4e-b17b-aa438bfb05eb", "109200", "5589100", "REJANE MARIA BRESSAN", "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS", 3 },
                    { "a9a88fbd-6131-46df-b499-caa97ff54a83", "109200", "7230486", "ADRIANA CRISTINA LOURENCO IUPI", "DIRETORIA REGIONAL DE EDUCACAO SAO MATEUS", 3 },
                    { "d23d7157-0751-41cc-8180-9220c7558528", "108900", "5910935", "WANIA CRISTINA MANOEL", "DIRETORIA REGIONAL DE EDUCACAO PENHA", 3 },
                    { "8962313e-8319-47f3-a153-8af2c85e278d", "108600", "7441487", "ERIKA RENATA DE FREITAS", "DIRETORIA REGIONAL DE EDUCACAO IPIRANGA", 3 },
                    { "5d6c0804-eea7-4a80-96a6-375c98c7a24f", "108500", "5640539", "ROSANA RAIMONDI", "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES", 3 },
                    { "01c86473-8829-4b54-ae17-1e9b2b68c5d4", "108600", "6909795", "MARTA MALHEIROS ADRIANO", "DIRETORIA REGIONAL DE EDUCACAO IPIRANGA", 3 },
                    { "a2597e44-36e7-4ab8-ab3d-b046260ef9a4", "", "7716125", "Uyara Vieira Costa de Andrade", "SME", 2 },
                    { "6691bd4f-602a-4617-a813-40c6839d8e03", "", "7924488", "Gabriela Manzolli Rowlands Lopes", "SME", 2 },
                    { "604540a7-ac83-4d84-998d-ce732e821b39", "", "6941583", "Ronaldo José da Silveira", "SME", 2 },
                    { "e3914004-ef74-4903-8f14-5876ae85cd29", "", "6946895", "MINEA PASCHOALETO FRATELLI SONOBE", "SME", 2 },
                    { "6931929e-9370-453c-83cb-a55c3b2d69e5", "", "6923950", "Rosangela Ferreira de Souza Queiroz", "SME", 2 },
                    { "52625087-39e6-45bb-a58e-23a0f1cf6d0a", "108100", "7418078", "Annaa Luisa de Castro", "DIRETORIA REGIONAL DE EDUCACAO BUTANTA", 3 },
                    { "6743fa52-bfe4-4dc2-8de3-66879c06f8fd", "108100", "7936532", "DIEGO BENJAMIM NEVES", "DIRETORIA REGIONAL DE EDUCACAO BUTANTA", 3 },
                    { "9c550602-535e-4daa-a961-358ab06be366", "108100", "8019444", "JULIANO RODRIGO MACIEL FERNANDES", "DIRETORIA REGIONAL DE EDUCACAO BUTANTA", 3 },
                    { "ce9d2c45-176e-4d5d-8797-d10487d7b1b8", "108100", "8019444", "JULIANO RODRIGO MACIEL FERNANDES", "DIRETORIA REGIONAL DE EDUCACAO BUTANTA", 3 },
                    { "90e4a3fe-894d-4543-a3f9-feb9cc74841f", "", "7705182", "Kátia Sayuri Endo", "SME", 2 },
                    { "31a8670a-8506-41f8-b941-ad63718c7f78", "108100", "7371489", "ROSANA RODRIGUES DA SILVA", "DIRETORIA REGIONAL DE EDUCACAO BUTANTA", 3 },
                    { "df44e04c-7208-4cf7-9038-dfcfd4633b4c", "108100", "8161828", "DANIEL DAMIAO DA SILVA", "DIRETORIA REGIONAL DE EDUCACAO BUTANTA", 3 },
                    { "66e6cdce-b075-4f89-8b40-004cfd3cf01d", "108100", "7940726", "Silvana Bastos Pereira Mendes", "DIRETORIA REGIONAL DE EDUCACAO BUTANTA", 3 },
                    { "12787f6f-0aae-41cd-9f28-5f427dd9721b", "108200", "6775861", "PATRICIA LACERDA", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "9c085c36-afd6-46a5-88ef-34bde8a1f2d9", "108200", "7115571", "ROSANGELA JULIA DE MATOS MONTEIRO", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "19b1f87a-ee0b-4635-9844-ca6be00e13e0", "108200", "7251297", "CASSIA APARECIDA GUIMARAES", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "e943689f-24aa-42d4-ae46-99e734c52fd9", "108200", "7915144", "MARIA LUANA LIMA MENDES DOS SANTOS", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "f2421e4a-5c3b-4e0a-a24e-3cafc13a5a7c", "108200", "6204619", "ROSELI HELENA DE SOUZA SALGADO", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "26f8869c-e1ba-4ccf-95a4-56f303a6c4c4", "108600", "5996236", "ELAINE CRISTINA RAMOS DE ALMEIDA NUNES", "DIRETORIA REGIONAL DE EDUCACAO IPIRANGA", 3 },
                    { "2eba33b6-e0fe-4e29-ac5d-3e9b5eaf2f00", "108200", "5413010", "CECILIA REGINA CARLINI FERREIRA COELHO", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "257c735a-af54-4974-a93a-330e0f274a8c", "108100", "6663648", "RUI FRANCISCO DA SILVA", "DIRETORIA REGIONAL DE EDUCACAO BUTANTA", 3 },
                    { "00785576-5042-4bea-bfbf-5d7d5379ff7c", "108200", "7213638", "RICARDO DE SOUZA", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "e87bac47-8d5f-4405-872c-5e0967d53b1d", "", "7827067", "Amanda Martins Amaro", "SME", 2 },
                    { "c424dce4-cb0e-4054-9594-db80ea40a007", "", "7923490", "Lis Regia Pontedeiro", "SME", 2 },
                    { "6cd46e22-641c-494d-b5e7-8ea54c4860a7", "", "caique.amcom", "Caique Latorre", "AMCOM", 1 },
                    { "7a017470-cd6d-4a8d-ab41-463b05d939ba", "", "massato.amcom", "Massato Kanno", "AMCOM", 1 },
                    { "d55f3416-5997-4b97-8725-f5718f30ef20", "", "daniel.amcom", "Daniel Matsumoto", "AMCOM", 1 },
                    { "06ef8802-7b2a-4070-9a4d-dffc508c1e9e", "", "danielli.amcom", "Danielli", "AMCOM", 1 },
                    { "93cdc84f-8534-44bf-80ba-767b29170cfe", "", "jeff.amcom", "Jeff", "AMCOM", 1 },
                    { "b92c2b3b-7b64-4fb8-88a7-3e7fbad23133", "", "aline.amcom", "Aline", "AMCOM", 1 },
                    { "9d7de56a-cb89-4935-996a-77dc15061f7a", "", "gabi.sme", "Gabi", "SME", 2 },
                    { "611b095e-f8af-41d1-9997-5917520844c7", "", "heloisa.sme", "Heloisa Giannichi", "SME", 2 },
                    { "67aaca93-8561-443e-92ec-802ed0a2d0ce", "", "7951221", "Karla de Oliveira Queiroz", "SME", 2 },
                    { "e722bceb-c812-4a63-8425-32d51d2fd090", "", "7719086", "Fernando Araujo de Oliveira", "SME", 2 },
                    { "5f283d10-5afc-4d9b-8f21-1d8f39379620", "", "8016119", "Daniela Harumi Hikawa", "SME", 2 },
                    { "b008b61c-9ec6-4267-8dd0-ec2c44f8799c", "", "7906706", "Felipe de Souza Costa", "SME", 2 },
                    { "a7337a93-3ba2-429c-add5-eab8c4459bed", "", "7944560", "Heloisa Maria de Morais Giannichi", "SME", 2 },
                    { "eeb5fe04-a8b7-4a76-87c0-7c88d55842da", "", "7744412", "Carla da Silva Francisco", "SME", 2 },
                    { "621f5c21-0a27-4da7-b4d5-8bfc9674f92d", "", "8163740", "Paula Giampietri Franco", "SME", 2 },
                    { "7ca680f0-16cd-4a29-8a7b-97db3a8e577e", "", "6122147", "Humberto Luis de Jesus", "SME", 2 },
                    { "909099ca-ea78-4c40-b848-21756b4fc9c9", "", "7727640", "Kátia Gisele Turollo do Nascimento", "SME", 2 },
                    { "be3dc818-7174-480a-9fc9-99418604098a", "", "7887337", "Thayrê Marin Alves de Lima", "SME", 2 },
                    { "0db3df80-84b2-40a5-ad63-68b434bf477f", "", "6888895", "Fernando Jorge Barrios", "SME", 2 },
                    { "04b86c0b-1d83-4919-8471-1c29bde9221a", "", "2994267", "Edna Calvo Leite", "SME", 2 },
                    { "b8804f3a-c5bb-47da-88e6-34ca22670bce", "", "7937431", "Cintia Anselmo dos Santos", "SME", 2 },
                    { "254de096-ba73-47cb-9ae8-3b3db5a91aeb", "108200", "7550618", "LUANNA OLIVEIRA DE ALMEIDA", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "bc86bb33-4675-4aa9-9870-0f4c7c94e11b", "108200", "6940145", "REGINA PAULA COLLAZO BERTUCCIOLI", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "313968fd-5a53-48fb-968b-bd440785cf89", "108200", "7814062", "DEMETRIUS SARAIVA GOMES", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "f01b9f1d-6ac9-4f9d-b17c-ecc886540cc9", "108400", "6686362", "ROBERTO ANTONIO MACIEL", "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA", 3 },
                    { "fbb0943e-e822-47e4-bbfd-a516d3bb3f16", "108400", "6719767", "MARTHA LUCIA BRAGA", "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA", 3 },
                    { "5adfb8aa-d644-4430-84eb-82427a232170", "108200", "7731892", "LEANDRO ALVES DOS SANTOS", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "6b2d7321-5158-4a15-b7b9-4d2609bf57fd", "108400", "8023999", "ADELINE FERNANDES FERREIRA", "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA", 3 },
                    { "8adfd156-6231-4401-aafc-749267c5ce60", "108400", "8055327", "THAIS CHARELLI MARTINS", "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA", 3 },
                    { "07d17a9b-1b82-494e-9b29-6b5efae4a711", "108400", "8160490", "JULIO CESAR DE CARVALHO SANTOS", "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA", 3 },
                    { "86442bc6-4ea1-4c43-938a-555f03b821db", "108400", "8219532", "ANA CRISTINA PEREIRA", "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA", 3 },
                    { "e4b1347d-548d-481e-935f-e672811ae3b2", "108500", "6940773", "ROMEU GUIMARAES GUSMAO", "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES", 3 },
                    { "f51bfa45-38b9-4a20-a606-84c30c27c82b", "108500", "6784011", "ESTER MARQUES DE PAULA DIONISIO", "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES", 3 },
                    { "9176dece-8fc7-4101-8355-36b3080785d3", "108400", "6383793", "JOSE ALVES MARTINS FILHO", "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA", 3 },
                    { "0cde1820-ac04-4b84-ad70-1941348c42ff", "108500", "6767494", "LUCIMEIRE CABRAL DE SANTANA FREITAS", "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES", 3 },
                    { "61b5d13b-7ced-46c6-8807-d13038e80c4b", "108500", "7935897", "BIANCA FREIRE DOS SANTOS", "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES", 3 },
                    { "78bf0590-c22c-4e94-b70e-ce60935bd7af", "108500", "5358051", "Rosana Soares Godinho", "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES", 3 },
                    { "21bbdfbe-ffc7-4a2b-9251-fa840a8aa4a9", "108500", "7976445", "Fernanda Moreira Xavier", "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES", 3 },
                    { "fd71b59a-f4a6-4239-bb9e-d4b66da79329", "108500", "7808208", "Luciano de Brito Leal", "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES", 3 },
                    { "92bb8158-288d-4247-9f1e-b68bcf6a5c01", "108500", "8401918", "MARIA INES ALVES PEREIRA", "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES", 3 },
                    { "e3c12765-8c86-45a2-83d8-0d13a8b70f39", "108600", "6002129", "KELLEY CARVALHO MONTEIRO DE OLIVEIRA", "DIRETORIA REGIONAL DE EDUCACAO IPIRANGA", 3 },
                    { "5770d730-6de6-4ee1-b812-3f205aeaf81b", "108600", "7326238", "IRAIDE SILVA RIBEIRO DOS SANTOS", "DIRETORIA REGIONAL DE EDUCACAO IPIRANGA", 3 },
                    { "abb61fee-8c87-4dbc-8d09-9e8928c3ad5c", "108600", "8078734", "FRANCISCO FABIANO DANTAS SANTOS", "DIRETORIA REGIONAL DE EDUCACAO IPIRANGA", 3 },
                    { "55f4ffa4-2e3f-4fe0-8ecc-ddced1fda900", "108600", "5988861", "MARCELO AUGUSTO MACHADO", "DIRETORIA REGIONAL DE EDUCACAO IPIRANG", 3 },
                    { "cc1e2fac-518a-4447-bff6-c3c1572b721e", "108500", "7705719", "SILVANA DOS SANTOS SILVA", "DIRETORIA REGIONAL DE EDUCACAO GUAIANASES", 3 },
                    { "e9d151f4-5f7d-46ff-9aa5-239175f1bfce", "108400", "580553", "SISI MARIA VENTURA", "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA", 3 },
                    { "27180267-0291-4f8f-ada1-86310879b6e7", "108400", "7237383", "JULIANA NAGAHAMA", "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA", 3 },
                    { "e70e9559-3fb8-4cf4-b704-f158c2049317", "108400", "7456191", "DANIELE LEITE FERREIRA MEMOLI", "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA", 3 },
                    { "b346be88-3e8e-467f-a644-eb46f3b13a0d", "108200", "8044953", "CLEOMAR DE SOUZA LIMA", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "d14ac86c-99d5-4056-9470-b51ac4655d4e", "108200", "5830834", "RITA DE CASSIA GERALDI MENEGON", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "795ac90e-edb9-4fe6-9cd6-834353ea2356", "108200", "6062130", "CRISTINA BARROCO MASSEI FERNANDES", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "9b50d55a-0531-4a3d-90c1-dced6855c8ac", "108200", "6604439", "ELISABETE MARTINS DA FONSECA", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "baae413b-c45e-4451-9f30-1fdfb191a7f7", "108200", "7373121", "ANGELICA DE ALMEIDA MERLI", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "6f1eb78d-6d14-4432-97b7-8e3968f22433", "108200", "8582416", "KARINA ESTEVES BELMONTE", "DIRETORIA REGIONAL DE EDUCACAO CAMPO LIMPO", 3 },
                    { "4f098494-c818-41e2-98b9-84bfdaf77cfd", "108400", "6751067", "MARCIA REGINA BARRELLI", "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA", 3 },
                    { "be99d221-b769-44cf-b24f-716c2bc2a68e", "108300", "8022691", "TATIANA FERREIRA COSTA", "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO", 3 },
                    { "a681631e-074f-44fa-b9a3-f69d4dc491fa", "108300", "8036080", "Luciene Aparecida Grisolio Cioffi", "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO", 3 },
                    { "610930b5-93d7-49dd-9856-6d8aa47b05e9", "108300", "8094411", "Eduardo  Murakami da Silva", "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO", 3 },
                    { "f307c66f-18bc-4715-b3d6-7df41c28c118", "108300", "7944527", "JAQUELINE APARECIDA DE LIMA MATOS", "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO", 3 },
                    { "16b14466-cd94-44ad-829d-e4f921130b86", "108300", "5974755", "SANDRA REGINA DE CARVALHO", "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO", 3 },
                    { "efd9db96-adef-46e9-a1a4-edbb56ae22b1", "108300", "5929156", "MARIA TERESA FUEYO", "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO", 3 },
                    { "791ca65f-75fb-4072-8bb6-d0c22646e087", "108400", "6383793", "JOSE ALVES MARTINS FILHO", "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA", 3 },
                    { "323225f7-ba99-4cfe-b843-0eb478bc1fcc", "108300", "8206597", "MICHELLE BARBOSA FONSECA", "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO", 3 },
                    { "89cd7dc8-8bf1-494f-ba87-e2b5019088cc", "108300", "7721803", "OSMIR SANTOS MACEDO", "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO", 3 },
                    { "5312b90b-911d-4d4d-ae31-6bb275e04393", "108400", "7953542", "SORAIA APARECIDA INACIO DA CRUZ", "DIRETORIA REGIONAL DE EDUCACAO FREGUESIA/BRASILANDIA", 3 },
                    { "bd5aba9f-ea35-4a62-87d0-6a57a15cd927", "108300", "7510691", "MARINA DAS GRACAS MORAES", "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO", 3 },
                    { "3170c6d6-2cf0-453d-9018-af2f21466975", "108300", "7256795", "ROSANA BUENO", "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO", 3 },
                    { "b2e3b1b3-c75e-4921-8def-f75f4b41bda7", "108300", "6911323", "MARCELA DE PINA BERGAMINE", "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO", 3 },
                    { "5486198b-32ba-4ed0-8a92-faf7b59aa07e", "108300", "6941095", "CAROLINA NOGUEIRA DROGA", "DIRETORIA REGIONAL DE EDUCACAO CAPELA DO SOCORRO", 3 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "840c2ace-95e7-4a60-a309-9847198f440a", "Aluno" },
                    { "6c13343e-67a8-4f89-a714-e6eefbc80fdc", "Admin" },
                    { "809457b7-c609-4173-9104-c995b8d55dda", "Diretor" },
                    { "57188ff9-1c9c-420c-b7e6-0d094b3456e9", "CP" },
                    { "c03942cc-8f60-418a-af5b-c440974952b3", "Diretor" },
                    { "3bcac4b8-5091-4508-a32a-791fc47f4d0c", "Secretario(a)" },
                    { "c2f5838c-e7e2-4f23-91fb-58d171cf2f24", "Auxiliar" },
                    { "2fc4bc01-210e-4d86-978f-42dfb6e713c0", "Professor" },
                    { "0a95bc7b-d9aa-4b2e-b990-200623dfab35", "Responsavel" },
                    { "199622d5-99b6-47ce-8da2-ca6cd02422ba", "Adm DRE" }
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
