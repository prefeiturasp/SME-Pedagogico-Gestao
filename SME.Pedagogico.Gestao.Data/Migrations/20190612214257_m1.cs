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
                    { "2edc2133-0d17-4951-90b1-5b51d4e0599d", "AD", "26" },
                    { "955ba028-889c-409b-bd18-5715f3d5315a", "CEFAI", "18" },
                    { "a58dd6dd-10cf-4c37-85ba-ddc2dd14bb72", "PAAI", "19" },
                    { "61432693-5a1d-4a5b-916a-acf39455e7e5", "DIPED DRE", "20" },
                    { "24e36273-8863-4504-b35b-aa4951a72a6b", "Adm DRE", "21" },
                    { "4aa1497d-0a1c-4177-8355-1cdbde685de8", "Básico DRE", "22" },
                    { "14162a07-47ff-46e3-aeb4-802e1063e6d6", "Básico Escola", "23" },
                    { "6e63fb73-8d52-4f8f-b3be-ad1735f7e693", "Infantil", "24" },
                    { "5202bfe8-f0bf-4634-83b7-b4bc510ffedf", "UE Parceira", "25" },
                    { "46127b64-698d-40cb-8ea2-c2ddd31a6934", "AEE", "35" },
                    { "6621d049-b4fd-46fb-b174-371727bd5446", "CP", "27" },
                    { "261ee896-f46c-417d-b467-5f7e1aa8ff58", "Secretário Escola", "28" },
                    { "72519030-49bf-403d-b357-f9457d694cc8", "COTIC", "29" },
                    { "98cfbfb6-0ce3-4699-ac60-016a88f9e793", "UE", "30" },
                    { "ae452529-2f1c-4cc5-b9f0-36558a52e5f3", "CJ E Volante (PEI, ADI)", "31" },
                    { "49f8c684-592b-49af-b095-eae7e617d22d", "Fund. e Inf.", "32" },
                    { "be59e15d-1630-49ee-9188-9f5d7858d75d", "NAAPA", "17" },
                    { "fcbc2237-4c8d-4254-8c2b-3f2e9866a2ee", "DIPED", "16" },
                    { "900876ad-dcb2-499c-a454-deea9baa423b", "Supervisor DRE", "15" },
                    { "cd866005-7452-412e-9a24-3fa3f1dd995b", "Técnico", "14" },
                    { "298b6004-bbb2-4ba8-af9a-270c4d006eae", "ATE", "37" },
                    { "cbdbdc1c-edf3-41f7-b995-29d6007080f8", "Readaptado", "36" },
                    { "cadf81cf-247f-4d9e-9535-0229b71c0409", "Desenvolvedor", "0" },
                    { "dd4ff7a2-1c52-408c-aea2-123d8eace7d2", "COTIC", "1" },
                    { "969bb770-ed9d-4810-871f-47b0e43feb02", "SME", "2" },
                    { "31ecb7f1-ac69-4b15-be79-38c6522312e1", "COPED", "3" },
                    { "fc0c9f6f-18a7-4927-a808-3a341844b82c", "DIEFEM", "4" },
                    { "36b42579-c7b6-405a-954b-d218e8f19f89", "POA", "33" },
                    { "4bb8555d-9a13-4c97-b018-1d6049c938ea", "DIEI", "5" },
                    { "ba22c73f-d8b0-4a1d-9979-b3df6d4e9621", "DIEE", "7" },
                    { "482fa371-c52b-46a5-a4de-518acf913149", "NTA", "8" },
                    { "d0148ce5-5a97-497c-acaf-8bdb273f9b8e", "NTC", "9" },
                    { "11bb2496-f8ce-46f6-9376-2183d9547b19", "NTC-NAAPA", "10" },
                    { "6a955932-0ccb-4fce-9b6d-3cf6dd07f3f9", "DIEE-Conveniado", "11" },
                    { "7a8ab3d9-7d6b-4956-b3da-ae877382942e", "COPED Básico", "12" },
                    { "dd0292e3-df74-49fb-bb70-853863fe31fc", "Regional", "13" },
                    { "64292298-6102-498a-8b88-38170125c7ae", "DIEJA", "6" },
                    { "cb4d8612-8e66-4169-b126-5b2b23acd7c3", "PAP", "34" }
                });

            migrationBuilder.InsertData(
                table: "PollType",
                columns: new[] { "Id", "PollTypeDescription" },
                values: new object[,]
                {
                    { "4c274126-5ff8-4a04-b893-777650abe9bf", "Sondagem de Português" },
                    { "9b098a6a-57c2-4893-a2f7-9f735689f84a", "Sondagem de Alfabetização de Matemática" },
                    { "8ebf0fbb-c3e0-4333-b174-f9ce5c3504a3", "Sondagem de Matemática" }
                });

            migrationBuilder.InsertData(
                table: "PrivilegedAccess",
                columns: new[] { "Id", "DreCodeEol", "Login", "Name", "OccupationPlace", "OccupationPlaceCode" },
                values: new object[,]
                {
                    { "09e0d3a7-58f2-4648-a492-bf8cd27de096", "", "heloisa.sme", "Heloisa Giannichi", "SME", 2 },
                    { "16c0c94b-05f0-48ad-99c8-f06250fe464b", "", "gabi.sme", "Gabi", "SME", 2 },
                    { "8a09c6b0-275f-4a86-a8be-751067cc7b71", "", "aline.amcom", "Aline", "AMCOM", 1 },
                    { "216ec9c7-514c-4148-94c9-03d15537e676", "", "jeff.amcom", "Jeff", "AMCOM", 1 },
                    { "befd7a2a-5f02-4107-b506-d110ac1c788c", "108100", "7418078", "Annaa Luisa de Castro", "DIRETORIA REGIONAL DE EDUCACAO BUTANTA", 3 },
                    { "eae86c1c-35ae-48bc-9339-9eb62829b738", "", "daniel.amcom", "Daniel Matsumoto", "AMCOM", 1 },
                    { "a6ff4837-beef-4962-b41a-7c3930be66c1", "", "massato.amcom", "Massato Kanno", "AMCOM", 1 },
                    { "af58bd68-9c16-4f7d-93b3-f5d43b68e02f", "", "caique.amcom", "Caique Latorre", "AMCOM", 1 },
                    { "ace79f34-53ad-431c-ae8e-3465f75b9ae0", "", "danielli.amcom", "Danielli", "AMCOM", 1 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "755eaf63-ac5d-404c-90b3-6067737e20f8", "Aluno" },
                    { "9c9305ae-e8ab-4848-8fcc-ea4761261dd3", "Admin" },
                    { "ddc01c24-25b2-4564-8d56-79d830e29eac", "Diretor" },
                    { "ac399962-688c-41c8-b20f-e396492bcf67", "CP" },
                    { "b6c67d93-82aa-4516-aa25-9eadcafe5ce5", "Diretor" },
                    { "5801862d-91b9-4d95-86ff-909c18545aef", "Secretario(a)" },
                    { "516f38fd-7eea-4f1e-bea8-ee4ceed971e3", "Auxiliar" },
                    { "dd19ab68-f596-4de0-912f-b7a9312b752e", "Professor" },
                    { "ca142c98-69eb-4dfe-8253-1af96b6d4acb", "Responsavel" },
                    { "1ef3debd-761e-485a-b93b-194dae0fa3e8", "Adm DRE" }
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
