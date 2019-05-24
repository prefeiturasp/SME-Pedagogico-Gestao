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
                    { "e0c97970-1ea1-4401-bedc-6c1ec95fb428", "Adm DRE", "21" },
                    { "08c6a95f-b731-45a1-a3ff-3a0948b0d523", "CEFAI", "18" },
                    { "0741a9cc-495f-4525-a2df-888b062848fd", "PAAI", "19" },
                    { "9ee77408-4555-4daf-8d84-f61000a2f1a2", "DIPED DRE", "20" },
                    { "cd68a605-4e05-4fb7-ae5b-7b096ccf1f69", "AEE", "35" },
                    { "b8699e50-4bcc-42da-ba22-2e92333ebc54", "Básico DRE", "22" },
                    { "0677f631-0064-4f1e-a50c-9b0106d2391c", "Básico Escola", "23" },
                    { "dec06fa0-0885-45a8-bacf-06fabdf0818f", "Infantil", "24" },
                    { "4dd3893e-bb8e-4a58-a2d4-1b335f61dc88", "UE Parceira", "25" },
                    { "76615e9c-4f2c-41c7-a19c-ba30d908649f", "AD", "26" },
                    { "b390cec3-53e6-41e6-bf23-6c7a891ce0fe", "CP", "27" },
                    { "d3d357f0-f1cd-4fbe-83cf-e7f386c10409", "Secretário Escola", "28" },
                    { "e2b30a7b-9d55-4aa8-a1dc-06e76540a574", "COTIC", "29" },
                    { "aeed883e-d2a6-4be6-854b-aec2dac494e1", "UE", "30" },
                    { "55213219-10f9-4b6b-80b3-9cebe5d42657", "CJ E Volante (PEI, ADI)", "31" },
                    { "518051cb-d41f-4c03-8a05-65c5571dcdef", "Fund. e Inf.", "32" },
                    { "c7a6a1c7-331c-4be0-a648-784f08f9e068", "NAAPA", "17" },
                    { "0f4508ab-ac87-4e3f-ae3c-975ee6ad3fd0", "DIPED", "16" },
                    { "7b56f732-bb42-4efe-bd82-6e774a135ca1", "Supervisor DRE", "15" },
                    { "5ba48695-c9e5-4799-8819-a72880776271", "Técnico", "14" },
                    { "3708725b-d7f0-4894-834a-4a5c12125ac4", "ATE", "37" },
                    { "18bc31f7-ad10-4c9d-93e6-d1888f8a6cfb", "Readaptado", "36" },
                    { "bb14ae3f-a3ec-4a26-8d7f-20da34168dcd", "Desenvolvedor", "0" },
                    { "f1b2e8ed-b1f6-4711-b6cc-1017b3830181", "COTIC", "1" },
                    { "7b89622f-49aa-42fb-ad8d-31e499ae0e7a", "SME", "2" },
                    { "51d7f256-4ef5-4513-9a68-89a0cf4fc321", "COPED", "3" },
                    { "28d89945-4012-4042-8e04-4cad0a183b2f", "DIEFEM", "4" },
                    { "6ee64423-f7d3-4a8e-a075-8bd721dcf921", "POA", "33" },
                    { "e11ef6c5-87ca-4fdf-84f0-81f4ce236ed4", "DIEI", "5" },
                    { "309cd475-80b2-43ec-9733-68bb66ba2715", "DIEE", "7" },
                    { "9592fa78-5bbc-4b42-95a1-090746ccef22", "NTA", "8" },
                    { "7bae61b6-1937-4dd2-8fca-b7e32881a561", "NTC", "9" },
                    { "5a6e8c14-814a-401b-a7f8-4cd6f933c0ea", "NTC-NAAPA", "10" },
                    { "0ad018b3-b025-4f2e-a248-c15bc73851c0", "DIEE-Conveniado", "11" },
                    { "c3ef0627-feb2-4958-b1c9-30ecb2bb0be9", "COPED Básico", "12" },
                    { "e0e0fdfe-3e4f-4d38-b589-7c0f4607d44e", "Regional", "13" },
                    { "17db4553-f75f-4597-b17a-7012dd5e38e2", "DIEJA", "6" },
                    { "c1858f32-2e0f-4e81-986c-534688e52955", "PAP", "34" }
                });

            migrationBuilder.InsertData(
                table: "PollType",
                columns: new[] { "Id", "PollTypeDescription" },
                values: new object[,]
                {
                    { "1d0678fb-6220-4d9c-bf01-a30d6319f9c5", "Sondagem de Português" },
                    { "b8b5a612-ee9b-4bca-b47b-5d544315bf0d", "Sondagem de Alfabetização de Matemática" },
                    { "9a77b952-c21d-443b-a30b-e7d4e10de7a7", "Sondagem de Matemática" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "2015ed7f-1737-4cf6-bbde-dbf98dec7073", "Admin" },
                    { "73833460-5a72-4145-a6b9-15e89c55100b", "Diretor" },
                    { "4051c64a-41c4-40d5-9021-57ee36a5d717", "Supervisor" },
                    { "0893dbf2-e310-4876-ab46-1741df3481d6", "Diretor" },
                    { "3878382b-ba1d-4bf2-8f9c-857b14ce1205", "Secretario(a)" },
                    { "7855d0db-686b-41b8-a4dc-1f9019f587f8", "Auxiliar" },
                    { "c2da0c87-b498-4351-9538-ace034562056", "Professor" },
                    { "22908bef-6aa0-4e30-911a-340e77ffde8a", "Responsavel" },
                    { "c84f0bad-03f9-4b93-a0e3-1597c935a895", "Aluno" }
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
