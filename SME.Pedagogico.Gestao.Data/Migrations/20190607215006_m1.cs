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
                    { "253e9f90-3454-446f-8881-8596a640d41f", "UE Parceira", "25" },
                    { "0b3d9a0e-2c5d-4747-9739-85d0f094f084", "CEFAI", "18" },
                    { "0c888183-27cd-476d-b955-c5bb99a8e186", "PAAI", "19" },
                    { "be663671-7f6a-45f8-9100-1860fa0b14ca", "DIPED DRE", "20" },
                    { "6907aa64-5244-40a2-9d9c-800be165c646", "Adm DRE", "21" },
                    { "ed7530e9-d1a2-4a18-b0bd-a2d014bf81bc", "Básico DRE", "22" },
                    { "d7814af6-f059-4cbf-9f99-8c9c59e0ec20", "Básico Escola", "23" },
                    { "7200c4e5-7f44-47ca-a0f7-9a3906ebaca1", "Infantil", "24" },
                    { "9aaf8310-30d3-457c-83fb-c3a5d5a527f3", "AEE", "35" },
                    { "99fb1d80-6a4e-4471-8fe1-d68db99f2f6c", "AD", "26" },
                    { "464a6d3e-1b93-4e5a-92ba-08eea4183956", "CP", "27" },
                    { "2d892da4-77be-42ae-89c1-ad2202753516", "Secretário Escola", "28" },
                    { "de06fa79-be6a-4817-98b6-a7f96ac6e118", "COTIC", "29" },
                    { "f2aeeec6-e67b-4ea3-98aa-eed3fac5b406", "UE", "30" },
                    { "4d465999-3f16-4cce-8a94-a04ba0d7f18d", "CJ E Volante (PEI, ADI)", "31" },
                    { "2deb8727-1aa8-4e23-bf48-1de4b4674466", "Fund. e Inf.", "32" },
                    { "1087d3ab-27c2-40ae-bf9e-f023fc89bd43", "NAAPA", "17" },
                    { "916ed768-ec50-44c6-9a35-26f18a3d478a", "DIPED", "16" },
                    { "d5f54233-1f1c-488a-a980-96ec62b0e42b", "Supervisor DRE", "15" },
                    { "1e68d501-dbf9-49c7-8bac-5fbc7b40db1f", "Técnico", "14" },
                    { "001029b2-2fff-4608-9de2-a422f5d6d35f", "ATE", "37" },
                    { "68415955-9d14-4a81-97fe-5cfb4240492d", "Readaptado", "36" },
                    { "73fa60eb-b144-4ae7-bf7f-d78faa024822", "Desenvolvedor", "0" },
                    { "fff1dc49-eab7-4aac-bdc2-3a0fbba2fc73", "COTIC", "1" },
                    { "e13741b9-205f-4f82-ba2a-9831e6e24bf0", "SME", "2" },
                    { "010c950e-6ce2-431f-8836-01f479fa5ece", "COPED", "3" },
                    { "68dd550c-f2b5-4597-b556-e12e0a388156", "DIEFEM", "4" },
                    { "9f41a5c4-df7e-4e62-b332-e62f3e6119a3", "POA", "33" },
                    { "23f2173b-ca84-43f0-9720-1841720bc0e4", "DIEI", "5" },
                    { "a08fbe22-e542-42cf-a5e9-93b803f6d987", "DIEE", "7" },
                    { "3d58ec84-0fd5-44e1-9f9d-25953e82d789", "NTA", "8" },
                    { "3daec31e-ff99-4353-8b42-4118eb722b66", "NTC", "9" },
                    { "893b5c17-3800-463a-9004-0c64591a071a", "NTC-NAAPA", "10" },
                    { "89b8f482-8e82-4056-bed5-dd64e1cc7845", "DIEE-Conveniado", "11" },
                    { "b1778549-a108-4924-bb3e-5d0459951d4d", "COPED Básico", "12" },
                    { "4c17dfa3-ae81-417e-9ac7-46e060dc5e5b", "Regional", "13" },
                    { "404f2b94-466a-443b-b532-0b41adf65a97", "DIEJA", "6" },
                    { "ae165d8f-c140-48a3-91dd-f6cc9bb2dbce", "PAP", "34" }
                });

            migrationBuilder.InsertData(
                table: "PollType",
                columns: new[] { "Id", "PollTypeDescription" },
                values: new object[,]
                {
                    { "59333718-6260-4a52-982e-db2614175383", "Sondagem de Português" },
                    { "2676081d-24c5-4d8f-a83b-0283cac2078e", "Sondagem de Alfabetização de Matemática" },
                    { "5f464476-fdb0-4720-ac00-e1ab6c6ceb06", "Sondagem de Matemática" }
                });

            migrationBuilder.InsertData(
                table: "PrivilegedAccess",
                columns: new[] { "Id", "Login", "Name", "OccupationPlace", "OccupationPlaceCode" },
                values: new object[,]
                {
                    { "6b302d27-adaa-41ab-b8a1-e533cb936691", "gabi.sme", "Gabi", "SME", 2 },
                    { "fcdfb1a6-b4d9-4a89-8155-2825afd4b258", "aline.amcom", "Aline", "AMCOM", 1 },
                    { "16ec9cdc-9d59-45f0-a12c-6d4b10f55e4f", "jeff.amcom", "Jeff", "AMCOM", 1 },
                    { "e6ed4a14-78fe-4b1d-9634-70a24ed6f652", "heloisa.sme", "Heloisa Giannichi", "SME", 2 },
                    { "32230790-e7bf-4ea5-b8b5-fc7e847f3f71", "daniel.amcom", "Daniel Matsumoto", "AMCOM", 1 },
                    { "7f6a4331-47c0-492a-9d1c-869269292364", "massato.amcom", "Massato Kanno", "AMCOM", 1 },
                    { "b71e655c-462d-4e4d-b816-8b230b69e470", "caique.amcom", "Caique Latorre", "AMCOM", 1 },
                    { "08e10979-4831-4077-b396-2888795a01c5", "danielli.amcom", "Danielli", "AMCOM", 1 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "4c38b93b-5ddc-4b0a-a30c-f29a5e81c066", "Responsavel" },
                    { "163664fa-a153-4dfa-ac1b-a2bd142f6aab", "Admin" },
                    { "17f872d9-0227-48a3-9834-98e84a3f263c", "Diretor" },
                    { "93eeba4f-47c8-4f17-8b6e-889f2eb084a1", "CP" },
                    { "a00b9267-0d5b-4fb1-8717-5d5fbf42d692", "Diretor" },
                    { "fef8c1b5-0904-4768-bc96-2cf654d2e700", "Secretario(a)" },
                    { "237a58ec-4972-487f-b795-27cfa1fe0514", "Auxiliar" },
                    { "12de7e0e-58b4-486d-916b-ccc1e260c126", "Professor" },
                    { "dc389b6b-9840-49db-927e-a3cb0b05474f", "Aluno" }
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
