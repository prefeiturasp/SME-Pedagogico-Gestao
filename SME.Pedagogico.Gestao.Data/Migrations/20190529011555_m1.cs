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
                name: "Semesters",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.Id);
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
                    SemestreCode = table.Column<int>(nullable: false),
                    SemestreId = table.Column<string>(nullable: true),
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
                    table.ForeignKey(
                        name: "FK_MathPoolCAs_Semesters_SemestreId",
                        column: x => x.SemestreId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    SemestreCode = table.Column<int>(nullable: false),
                    SemestreId = table.Column<string>(nullable: true),
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
                    table.ForeignKey(
                        name: "FK_MathPoolCMs_Semesters_SemestreId",
                        column: x => x.SemestreId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    SemestreCode = table.Column<int>(nullable: false),
                    SemestreId = table.Column<string>(nullable: true),
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
                    table.ForeignKey(
                        name: "FK_MathPoolNumbers_Semesters_SemestreId",
                        column: x => x.SemestreId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    { "ba3c4fad-21f1-4e27-b285-239ec8e1b41e", "Básico DRE", "22" },
                    { "d3143bd9-c3ab-4ac8-850e-a21f05383230", "DIPED", "16" },
                    { "5649f295-7f77-410c-b4f1-95777e116a84", "NAAPA", "17" },
                    { "7afd3a8d-9b86-40e3-a1ed-959f03d8c5b0", "CEFAI", "18" },
                    { "66f51d6d-d1c2-48d7-b1c9-a441229a4bc1", "PAAI", "19" },
                    { "888c8c29-5771-4475-91f6-f13cec5c40cb", "DIPED DRE", "20" },
                    { "8fceb54a-fd67-44f1-9bb3-8f776f825215", "Adm DRE", "21" },
                    { "60204118-bd92-4845-abf0-798a3814fdef", "POA", "33" },
                    { "20e076b6-282a-49ec-92b2-2e7d67563d18", "Básico Escola", "23" },
                    { "f6fad244-5ed8-4537-9907-440845c49956", "Infantil", "24" },
                    { "1eefc7dc-3437-4e20-bc04-61751ddebca8", "UE Parceira", "25" },
                    { "c0249ef3-2a97-4d5f-92cf-e20ea276a339", "AD", "26" },
                    { "19bee4e5-68a6-406d-9f94-a77501ec0135", "CP", "27" },
                    { "9b29f6ec-c58a-4d2a-9687-85f94840fbeb", "Secretário Escola", "28" },
                    { "7c3cc57d-2703-4408-a69f-3013ac30d4f1", "COTIC", "29" },
                    { "5c1fe9ce-ce38-4896-90b3-278ae8acc721", "UE", "30" },
                    { "c472462d-9a05-43b9-a5a0-4eecf09c67ad", "Supervisor DRE", "15" },
                    { "bdd40003-3bf4-495e-bf96-4f31788316eb", "Técnico", "14" },
                    { "3ece5641-72ed-46af-a3d0-4d7478f80838", "Regional", "13" },
                    { "0e58c654-4551-4fee-83b5-faba20e37f41", "COPED Básico", "12" },
                    { "7ad1e379-6ecf-488d-930e-dc64c124a764", "ATE", "37" },
                    { "28332e80-fb12-48ba-8f91-93f917cd1da5", "Readaptado", "36" },
                    { "cf24d574-2b58-4b6f-aa91-90422ab5bb90", "AEE", "35" },
                    { "0392b063-5db0-4b85-b781-572c8d63110e", "PAP", "34" },
                    { "fd68f013-1d9d-44e5-a817-5b37f71ed690", "Desenvolvedor", "0" },
                    { "7786a674-fc18-4da8-9965-c02956ba5a98", "COTIC", "1" },
                    { "1bf1b083-a2ed-433f-b35e-c8a7dfdfc792", "SME", "2" },
                    { "7a8c6da8-931e-4bf9-abd9-de26b31f06e3", "CJ E Volante (PEI, ADI)", "31" },
                    { "8db5ba3e-d49a-4f8a-9128-09c52509ff52", "COPED", "3" },
                    { "118d1a8a-f020-40db-b6f5-6b189104136a", "DIEI", "5" },
                    { "d26ec454-0bfe-41f3-974f-fc8f769d722a", "DIEJA", "6" },
                    { "46ca96f2-af50-4746-be63-c9c79f523dee", "DIEE", "7" },
                    { "7a6348e6-3c14-4ecb-9338-7d2126bd11dc", "NTA", "8" },
                    { "dfbafdad-961f-4f7a-8912-6d688e737b9d", "NTC", "9" },
                    { "c6162cb9-cf26-4c27-a275-d6f3c5428768", "NTC-NAAPA", "10" },
                    { "cc5e194a-ce83-4ef6-aff9-f11fa25837ee", "DIEE-Conveniado", "11" },
                    { "9a9895d7-71bd-46c6-a4a9-ce53d20e011e", "DIEFEM", "4" },
                    { "e60c724a-6bd3-4c8c-9554-94e9e3cac85f", "Fund. e Inf.", "32" }
                });

            migrationBuilder.InsertData(
                table: "PollType",
                columns: new[] { "Id", "PollTypeDescription" },
                values: new object[,]
                {
                    { "7b8dab37-4897-41fc-ae2d-c92119d6b675", "Sondagem de Português" },
                    { "4dcbf25e-0d6c-4ccf-b025-442d13dac07c", "Sondagem de Alfabetização de Matemática" },
                    { "441c22b6-c627-4a79-a04f-32454cd227c8", "Sondagem de Matemática" }
                });

            migrationBuilder.InsertData(
                table: "PrivilegedAccess",
                columns: new[] { "Id", "Login", "Name", "OccupationPlace", "OccupationPlaceCode" },
                values: new object[,]
                {
                    { "139113e3-b90a-4f42-8fd8-bab3a60a76c4", "danielli.amcom", "Danielli", "AMCOM", 1 },
                    { "87eec126-acd8-46ce-ba9a-6f6eb7e898c0", "jeff.amcom", "Jeff", "AMCOM", 1 },
                    { "b1fcaa76-deee-4308-b0ec-2a80775d896b", "aline.amcom", "Aline", "AMCOM", 1 },
                    { "e075775d-9a6b-4d1d-b669-40dc05386a96", "gabi.sme", "Gabi", "SME", 2 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "2d684d56-ec0c-4e68-8ec2-d5d827a82c75", "Admin" },
                    { "941eb81d-0562-48eb-b65d-5b60d238838b", "Professor" },
                    { "dbd50975-45e3-471b-86be-ddabab2222db", "Auxiliar" },
                    { "164ef8ec-7fb4-4cea-81ea-bb5c2813f80e", "Secretario(a)" },
                    { "5a8eeb43-f98f-4f12-a661-a0df3a1be74d", "Diretor" },
                    { "fb6eabbe-d45a-476b-a9da-1c84f24dfc48", "Aluno" },
                    { "143ed30f-06e9-4011-9eeb-75da1e0a4d47", "Diretor" },
                    { "64d84265-e28c-4173-8df2-6d0767e165ac", "Responsavel" },
                    { "2e16b83d-d639-4285-9178-b0050fac5321", "Supervisor" }
                });

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { "4cb1c00d-0f4f-49d0-8f2f-a67b697af1cc", "1" },
                    { "4721ed3f-d591-4c06-ae57-cab3edc7eebc", "2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoggedUsers_UserId",
                table: "LoggedUsers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MathPoolCAs_SemestreId",
                table: "MathPoolCAs",
                column: "SemestreId");

            migrationBuilder.CreateIndex(
                name: "IX_MathPoolCMs_SemestreId",
                table: "MathPoolCMs",
                column: "SemestreId");

            migrationBuilder.CreateIndex(
                name: "IX_MathPoolNumbers_SemestreId",
                table: "MathPoolNumbers",
                column: "SemestreId");

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
                name: "Semesters");

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
