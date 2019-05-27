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
                    { "24556be2-6c56-4a6d-96d3-500519ec8170", "Adm DRE", "21" },
                    { "c11c1ccc-e240-4315-9e3a-ed869f2d8828", "CEFAI", "18" },
                    { "21303685-449b-4b19-b4f2-002472dc03b4", "PAAI", "19" },
                    { "b54daba3-9a31-4dfb-ae65-29280042113a", "DIPED DRE", "20" },
                    { "55cf612a-a2b4-4d08-9a67-db76ef6d4732", "AEE", "35" },
                    { "225efdd1-3342-4945-a65b-db2613e57561", "Básico DRE", "22" },
                    { "0f64334c-3d91-4bf1-8d5f-4c8f5022d369", "Básico Escola", "23" },
                    { "11aa7a3d-ecbe-4539-8378-4def7e225082", "Infantil", "24" },
                    { "7d527c28-bf04-48d2-a9c2-4c096021789d", "UE Parceira", "25" },
                    { "fc3dc1aa-dce3-479b-8e3e-80997cebe7a5", "AD", "26" },
                    { "8a05adb3-a042-4f7d-9d97-edc05aeeabab", "CP", "27" },
                    { "9141ffc4-95ff-475a-a598-064f6fc0c22a", "Secretário Escola", "28" },
                    { "52da301a-721a-48cf-bea5-2d708f45505a", "COTIC", "29" },
                    { "6ee947f5-19ac-4c93-8cac-f33083ebe938", "UE", "30" },
                    { "bebb8398-7991-4a1f-9c50-a43873a07e0d", "CJ E Volante (PEI, ADI)", "31" },
                    { "2b61705f-3dd7-4100-8806-96c6137d9c65", "Fund. e Inf.", "32" },
                    { "a28febe5-f228-4002-8939-ca0727990bd4", "NAAPA", "17" },
                    { "dfa3ff7c-f92f-422a-b6a6-69c412effd81", "DIPED", "16" },
                    { "9b3c5e58-1d2d-4a19-ac88-0d3517204a08", "Supervisor DRE", "15" },
                    { "aec55362-8964-4299-9875-9fe2a7a33c42", "Técnico", "14" },
                    { "6ec9d2d9-3a6e-42ab-a62e-7d0b1c8eb432", "ATE", "37" },
                    { "72823f44-0387-4e0a-b1f4-8cb1c34fe746", "Readaptado", "36" },
                    { "b491f516-e32a-46bf-bfd1-4da213148271", "Desenvolvedor", "0" },
                    { "8800f115-aa29-4d64-a80a-844bf85b3fe1", "COTIC", "1" },
                    { "406ef7ea-3117-4e82-935d-885a41323d67", "SME", "2" },
                    { "9c31717e-ec8c-4140-8061-9775f4a0c123", "COPED", "3" },
                    { "f4da84a7-6eaf-4238-97c1-0b345303a3a8", "DIEFEM", "4" },
                    { "fac80129-876c-41fc-a573-b4446c4e4d61", "POA", "33" },
                    { "5c799345-a574-429d-a8be-cd14d546c73a", "DIEI", "5" },
                    { "4068f7b3-39b2-49fa-9423-8d8cb789055f", "DIEE", "7" },
                    { "3685e30d-9bb6-4ff9-bf78-241204632a81", "NTA", "8" },
                    { "4285f961-e3b2-4437-9005-6ea7f358e161", "NTC", "9" },
                    { "eae87bad-f78e-41ba-896c-6fbd57cda7fb", "NTC-NAAPA", "10" },
                    { "23d66457-09c4-4b67-ad09-b346ea02fc52", "DIEE-Conveniado", "11" },
                    { "f1f31c54-af9a-4bc1-bf2f-9b62d94aa2b5", "COPED Básico", "12" },
                    { "24a17593-23a4-4379-87b6-aef4cb38c665", "Regional", "13" },
                    { "a02a80ed-7def-4c50-b22b-b5eb5d8ab269", "DIEJA", "6" },
                    { "79e605e3-d8dc-46a7-bb8f-b71fb3fe53ac", "PAP", "34" }
                });

            migrationBuilder.InsertData(
                table: "PollType",
                columns: new[] { "Id", "PollTypeDescription" },
                values: new object[,]
                {
                    { "59d55e11-df3b-4b89-86d7-47b83505681e", "Sondagem de Português" },
                    { "6084c793-00b1-4a64-84bd-0e0c35272510", "Sondagem de Alfabetização de Matemática" },
                    { "667d4b5f-2f0d-4a95-94c1-57d20bd1d4f5", "Sondagem de Matemática" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "e23aa1eb-b693-4cb6-8394-0700b1d5b10e", "Admin" },
                    { "225a6048-8c5e-42f0-a6cd-fc8cb18d9797", "Diretor" },
                    { "cb58a6ab-a572-4bdb-bcf8-3364f20ae269", "Supervisor" },
                    { "4248fd6c-60f5-4b80-ba68-80b55a7e9446", "Diretor" },
                    { "bf3e14cc-20e3-4632-a61b-2cd8f13bb99f", "Secretario(a)" },
                    { "03eeb0d4-12d3-41be-8f22-78729f22e73c", "Auxiliar" },
                    { "8eb938db-bd70-45f6-9586-696d30d88ecd", "Professor" },
                    { "ba4725af-b724-469b-bf5b-1b4edc412aba", "Responsavel" },
                    { "0f9f7e51-130e-435f-b180-5004f52f6249", "Aluno" }
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
