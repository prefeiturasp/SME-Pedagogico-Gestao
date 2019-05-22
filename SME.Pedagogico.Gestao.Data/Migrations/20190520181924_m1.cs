using Microsoft.EntityFrameworkCore.Migrations;
using System;

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
                    { "ef76b295-c3ee-488e-99c7-48931c641e16", "Desenvolvedor", "0" },
                    { "6a8027a8-b5cc-4db5-b9ca-4166a0fb0862", "Adm DRE", "21" },
                    { "c20ae596-858d-4187-a0a1-6cfec18f499f", "Básico DRE", "22" },
                    { "57393d2f-64ba-49b7-8b7c-8e48d8841d5a", "Infantil", "24" },
                    { "151ecf2d-05c1-4c53-b044-6cd8032209e6", "UE Parceira", "25" },
                    { "4e81202d-03e9-49dc-b32e-409271fa7cf5", "AD", "26" },
                    { "1620a652-48a7-46c4-81ee-0b02f4696f9e", "CP", "27" },
                    { "56c72f2e-c17d-470f-a355-47f24e017872", "Secretário Escola", "28" },
                    { "5b2e4668-12d9-4344-86f0-9badba1d9fb0", "DIPED DRE", "20" },
                    { "48650492-1ff3-401c-a69c-bac10adb227c", "COTIC", "29" },
                    { "80ba85c3-2d51-4bf3-9de2-290f140f7103", "CJ E Volante (PEI, ADI)", "31" },
                    { "42ccf8f6-47c9-4a8e-98c3-4767cb00967a", "Fund. e Inf.", "32" },
                    { "767c06f0-9847-4358-bd10-bd4b2b1ad118", "POA", "33" },
                    { "bc56eb95-437c-478c-b748-e159cc9db646", "PAP", "34" },
                    { "3376f838-e4e8-4bdc-a371-7ba50e5f2bf3", "AEE", "35" },
                    { "d4d49e02-49d3-4dda-9ddc-d3bb984ae68d", "Readaptado", "36" },
                    { "6be0fe30-8be3-4434-856b-2768f955f968", "ATE", "37" },
                    { "de749335-8120-432f-82df-04f83783fa3b", "UE", "30" },
                    { "870cfba9-a19c-4afb-9f95-f7ac4742d07a", "PAAI", "19" },
                    { "4ad2aecd-01c1-4aa8-ab59-c6ef9f0add74", "Básico Escola", "23" },
                    { "0a89e0bd-cd67-4c34-b45b-5cefc6e58971", "NAAPA", "17" },
                    { "77d791c5-f86d-45d7-af0a-cb996c77f692", "COTIC", "1" },
                    { "925bcb7e-7fd6-4cdf-9b2f-9f23deb837ea", "SME", "2" },
                    { "5c520ef1-5f6f-43c7-b61f-4a361fa8b33f", "COPED", "3" },
                    { "c664dfaa-3f7a-4ebe-bf4d-9c40840ac4d0", "DIEFEM", "4" },
                    { "ab00fb83-6ad1-47b7-ac54-cb1afea9f558", "CEFAI", "18" },
                    { "f6b67754-88f5-4908-b62f-66234b314b34", "DIEJA", "6" },
                    { "ad6366f8-0eea-4ed7-83ba-8c69a27bdc2c", "DIEE", "7" },
                    { "d47ac0d5-9202-47fc-985f-773b765723d1", "NTA", "8" },
                    { "6f8597bc-df26-401c-a411-5d368a600ed0", "DIEI", "5" },
                    { "5d3d83b4-91d0-4cce-8434-dff59ee57afc", "NTC-NAAPA", "10" },
                    { "8c040b83-3420-4e91-ba69-31746a870279", "DIEE-Conveniado", "11" },
                    { "9f3848a7-8edc-4dbe-9333-8e1781b95b8f", "COPED Básico", "12" },
                    { "0e920ec1-6701-4ac2-9258-f486eda17623", "Regional", "13" },
                    { "6234ab73-522f-42b5-8833-1ef07286b0be", "Técnico", "14" },
                    { "0b82c94c-29ba-4300-aeed-b2fb9f311de4", "Supervisor DRE", "15" },
                    { "41783fe9-7ab3-4f4f-8d59-a10966e73b6a", "DIPED", "16" },
                    { "2ef96d4c-56ff-48d3-a685-de99c88d1eb0", "NTC", "9" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "09006115-2282-42d9-99b3-6384083ab92c", "Professor" },
                    { "370af61b-3167-40ff-ace5-203beeb21c61", "Auxiliar" },
                    { "a0f1e0c9-9200-48eb-a939-0be4c661ac25", "Secretario(a)" },
                    { "caba3853-fd8c-41e5-bb0c-782a562c48b6", "Admin" },
                    { "a01b604f-b160-42ff-ac23-87ca1b08a7f8", "Supervisor" },
                    { "a1c6e605-a927-438b-9960-66f5f25e79b8", "Diretor" },
                    { "65c0cf20-6d47-43fa-84df-d83d408679e3", "Responsavel" },
                    { "a3c4415b-33e9-4de0-9786-c28074fb8543", "Diretor" },
                    { "b3e6f9c3-d018-4a62-a014-f315536be3a7", "Aluno" }
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