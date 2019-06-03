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
                    OccupationPlaceCode = table.Column<int>(nullable: false)
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
                    { "f3ea1eb4-c476-48cd-a02e-748443998e35", "Básico Escola", "23" },
                    { "fe9c37a2-ceaf-467f-a4cb-96a03cf358b9", "CEFAI", "18" },
                    { "a35b9132-1280-4370-8f7f-6643c51b47e7", "PAAI", "19" },
                    { "4d847cbf-d7b7-4c26-a130-819a0cbe853b", "DIPED DRE", "20" },
                    { "c1e63f90-3f08-4556-83ca-75ef0af98f47", "Adm DRE", "21" },
                    { "54674e7c-4bf6-4ae9-9e50-5e51cdf7982a", "Básico DRE", "22" },
                    { "6f9a3174-7188-4037-8590-12b836b8356f", "AEE", "35" },
                    { "afb5eb24-e8c2-4fc0-a8f8-929a0b7495ef", "Infantil", "24" },
                    { "5534fc66-3f69-4946-8943-17bf8d577fd6", "UE Parceira", "25" },
                    { "6940b051-46f2-43eb-ad48-8c88fafd38ac", "AD", "26" },
                    { "84ced6dd-1dcb-4daa-8cdf-47855b246fce", "CP", "27" },
                    { "0bc8c695-e1f3-4c00-9f40-757a74239864", "Secretário Escola", "28" },
                    { "970a069f-5931-4a54-af81-d03712260b68", "COTIC", "29" },
                    { "1c9ea943-3e4d-467f-9608-d2a4b3f74bd8", "UE", "30" },
                    { "9e25ef45-5709-4564-b0e1-dd5a5ac7fff9", "CJ E Volante (PEI, ADI)", "31" },
                    { "58813715-d6da-4f52-9a83-c734adee07d3", "Fund. e Inf.", "32" },
                    { "b97d6716-87df-4fae-a1c5-337a41b8fff2", "NAAPA", "17" },
                    { "0890bc18-f866-413a-9b4c-483de7376354", "DIPED", "16" },
                    { "9731104f-08f2-4ecf-b873-f0fab45bf1d0", "Supervisor DRE", "15" },
                    { "79d926f1-8b19-48e3-98e4-958faefd9981", "Técnico", "14" },
                    { "929e688f-89df-4c69-8d00-724bfad19701", "ATE", "37" },
                    { "5eba0f0f-ca28-4c7d-abc3-a6a227087e15", "Readaptado", "36" },
                    { "7e8a92dd-8fbb-4f02-92b4-3384d78edc72", "Desenvolvedor", "0" },
                    { "254fa1a6-1b1b-48f6-a654-ba3488a68c73", "COTIC", "1" },
                    { "12ce957d-eda4-4b5d-af20-199cb7341b21", "SME", "2" },
                    { "e8117793-13c0-4d92-bff7-a84c13474e9f", "COPED", "3" },
                    { "ae350e3d-bad0-4c77-84cb-c575069c3adc", "DIEFEM", "4" },
                    { "807c014c-bb6f-43ff-ac1e-971825630e3b", "POA", "33" },
                    { "7d3a6fd9-3c24-4925-aa4e-bb528af870d9", "DIEI", "5" },
                    { "f5fd8d6c-3148-403c-bab8-20c0e3ca42f5", "DIEE", "7" },
                    { "a58d824d-a677-4607-b916-49ff3121a3f7", "NTA", "8" },
                    { "cf11396a-6454-492a-ba10-f6d88aa210f5", "NTC", "9" },
                    { "fd434a4a-e5c0-46d4-9423-7b9a7f4aea47", "NTC-NAAPA", "10" },
                    { "4e017c7b-17b8-499f-a6ad-1363eccc6f49", "DIEE-Conveniado", "11" },
                    { "92c7e65c-707a-4537-b804-54f844318031", "COPED Básico", "12" },
                    { "92b3ee01-836f-477e-b3bd-bd4004b27381", "Regional", "13" },
                    { "02f53e04-c4ab-42c8-9409-6ed93caddb50", "DIEJA", "6" },
                    { "30335a06-f75c-4f5f-8098-b357bc83a251", "PAP", "34" }
                });

            migrationBuilder.InsertData(
                table: "PollType",
                columns: new[] { "Id", "PollTypeDescription" },
                values: new object[,]
                {
                    { "cc670f56-9722-4453-b107-b0ac019a4b44", "Sondagem de Português" },
                    { "2844e8ee-6f29-4df6-980c-e9cfeef24514", "Sondagem de Alfabetização de Matemática" },
                    { "8d311666-bcd7-4203-9f3f-95e220dac89c", "Sondagem de Matemática" }
                });

            migrationBuilder.InsertData(
                table: "PrivilegedAccess",
                columns: new[] { "Id", "Login", "Name", "OccupationPlace", "OccupationPlaceCode" },
                values: new object[,]
                {
                    { "71de3c6f-e973-4c76-be61-de91c255755f", "danielli.amcom", "Danielli", "AMCOM", 1 },
                    { "e253650f-dae2-4be5-865c-6cdeb44ddff6", "jeff.amcom", "Jeff", "AMCOM", 1 },
                    { "8487d899-c909-4562-91db-3843a85ae0be", "aline.amcom", "Aline", "AMCOM", 1 },
                    { "57b1f87c-a51c-43d6-83ff-7160c8ec35d7", "gabi.sme", "Gabi", "SME", 2 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "b351dee1-a045-4231-8cf9-38d37a4280dd", "Admin" },
                    { "5d4c63c0-abe7-4a4f-b2ac-7aaea0a1d0df", "Diretor" },
                    { "f7c51a77-e930-4cb7-8935-c7bc1adccf35", "Supervisor" },
                    { "aa7f082d-23a1-40f7-b061-004b3e231bc8", "Diretor" },
                    { "35e4d3c2-73fa-404b-812a-48bd00e8f76d", "Secretario(a)" },
                    { "010a719d-552b-4b22-b170-3f06165ed751", "Auxiliar" },
                    { "e031cb05-375b-463b-83bb-831ba1f45834", "Professor" },
                    { "4cd8d262-cfe4-410a-a6ee-bbecfe8fb413", "Responsavel" },
                    { "d5ddb15e-e156-402b-8a22-4c2e6bab2db2", "Aluno" }
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
