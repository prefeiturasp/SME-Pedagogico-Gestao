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
                    { "be548576-329a-48b4-aefd-25242706ee9d", "Adm DRE", "21" },
                    { "9b631a08-ee65-4b39-84e5-4c2ea436eef8", "CEFAI", "18" },
                    { "f98e0f55-072d-48ab-98bb-2fe37603f660", "PAAI", "19" },
                    { "0e2aaf43-8f41-48ab-bdef-b749cf2d0cc8", "DIPED DRE", "20" },
                    { "51610fc5-25a5-438e-b4e0-74f56dfdb72f", "AEE", "35" },
                    { "191c2c1a-d19d-4332-9eb3-592978a1c252", "Básico DRE", "22" },
                    { "003d355f-95f8-45f9-80e0-4baa0fb13f2a", "Básico Escola", "23" },
                    { "6cca3723-99ad-40f9-b354-a67a44ee8672", "Infantil", "24" },
                    { "40b3d294-d342-4a00-a3d1-47e6ad5eef10", "UE Parceira", "25" },
                    { "8600e523-4abc-46f4-8bb2-c6a38d3799de", "AD", "26" },
                    { "75891ab4-b76a-45c9-9d1a-8324550c3e06", "CP", "27" },
                    { "51afbfd1-d355-423a-9b20-607a5f0f6020", "Secretário Escola", "28" },
                    { "f0ea4dd4-5a60-44d5-a622-ed106a9d6d04", "COTIC", "29" },
                    { "ab281bac-1e57-4f9b-b657-5e8abb9e9915", "UE", "30" },
                    { "bda0b10e-6550-4637-96b0-3db53078deb9", "CJ E Volante (PEI, ADI)", "31" },
                    { "1be173c6-f5eb-4247-b03c-8b924a9f48c8", "Fund. e Inf.", "32" },
                    { "f9912e39-6c63-46f2-8239-a771edd9a9ea", "NAAPA", "17" },
                    { "e0f3ea9d-14fe-4c96-a9ad-449fd1e4e2e1", "DIPED", "16" },
                    { "ba0adabe-1e56-4899-9826-fa40f95ab117", "Supervisor DRE", "15" },
                    { "f57b5396-9b7c-4a7b-bfdc-520c6f680a4d", "Técnico", "14" },
                    { "76575987-8ad8-473a-b038-5b930134567e", "ATE", "37" },
                    { "3ff47b49-e800-4aa7-a3e6-5069699eedc5", "Readaptado", "36" },
                    { "6e57bd06-df9d-4086-900a-b4ba3d97af8a", "Desenvolvedor", "0" },
                    { "105988b7-f897-4980-8bd0-0a6203f6c97f", "COTIC", "1" },
                    { "baeb4587-f4b2-4650-a1c8-c968f8abf7dc", "SME", "2" },
                    { "81fff531-f5e0-4474-b193-31d82a20be40", "COPED", "3" },
                    { "752b2174-ab94-46bd-9257-004d335b0993", "DIEFEM", "4" },
                    { "8b77c60d-7be4-464e-9a1b-2a2379d741c4", "POA", "33" },
                    { "5c4b286f-3ca4-47aa-a30b-4c6f20d80ffa", "DIEI", "5" },
                    { "bdf94c64-f8b4-4da4-87e9-3213e5e9f30c", "DIEE", "7" },
                    { "665cce38-0a70-4950-b243-9fe4919385de", "NTA", "8" },
                    { "df3297dc-a677-4b1b-9bb0-6817dc69b7c1", "NTC", "9" },
                    { "a30a11ec-73d3-455f-a686-91e07131db14", "NTC-NAAPA", "10" },
                    { "88fe6e3c-2bd9-490c-9d88-f2c00f3b9b89", "DIEE-Conveniado", "11" },
                    { "4810a4f4-9b6a-4e41-8bd9-8d4c66da7bbe", "COPED Básico", "12" },
                    { "5a5275df-b702-422e-8009-16d890690548", "Regional", "13" },
                    { "6da5534f-c7ff-4da9-bcc4-3437900936e6", "DIEJA", "6" },
                    { "3b788a18-c920-48e1-b114-8572f703d219", "PAP", "34" }
                });

            migrationBuilder.InsertData(
                table: "PollType",
                columns: new[] { "Id", "PollTypeDescription" },
                values: new object[,]
                {
                    { "9d55c349-8153-4a12-ae78-3eb3b80cf288", "Sondagem de Português" },
                    { "9863c6d1-d203-4edc-b5e4-7680f5ed9ada", "Sondagem de Alfabetização de Matemática" },
                    { "5ded59ca-bd0e-46ba-9a91-c17b89d86736", "Sondagem de Matemática" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "e38c72f7-c981-4a04-822d-150953a82f80", "Admin" },
                    { "cff47dc2-be18-4126-a8e4-a80a43585a08", "Diretor" },
                    { "09ff8eb8-69ce-4803-bb2d-aa89e2ca63cb", "Supervisor" },
                    { "12bea91b-0d06-481e-a66c-a9d4dc8dd094", "Diretor" },
                    { "2209799e-e4a7-43ad-bd10-ff47164552f7", "Secretario(a)" },
                    { "b402aa41-b41c-4d9c-821b-62a62aaffdef", "Auxiliar" },
                    { "e3c0ed73-5b8b-49ab-81a7-6a82d9cc3528", "Professor" },
                    { "351d07e9-3ad8-4147-98c3-dfb640d7fa42", "Responsavel" },
                    { "d0404d69-3d75-45d7-8f98-4d64003fcb66", "Aluno" }
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
                name: "PollType");

            migrationBuilder.DropTable(
                name: "PortuguesePolls");

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
