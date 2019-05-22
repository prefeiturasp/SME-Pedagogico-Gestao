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
                    { "c62ee3a2-f81d-4af0-b4fa-b367c7d15616", "Adm DRE", "21" },
                    { "6ff33fdd-cf2a-4d12-90a7-7e3d903ba682", "CEFAI", "18" },
                    { "b9e5c123-8459-492f-9b60-1ec018fc755e", "PAAI", "19" },
                    { "43a1bed2-1321-4f1e-8c5e-e82ff119bec5", "DIPED DRE", "20" },
                    { "5a1f3213-fdae-4ba2-8ad9-6bc2ad330903", "AEE", "35" },
                    { "94ff477a-0c86-43b2-8fd6-582570f54912", "Básico DRE", "22" },
                    { "9e3b0c10-893d-4d89-b297-d01e66289395", "Básico Escola", "23" },
                    { "ea2e028c-d1f5-4b2e-8318-928b24c81622", "Infantil", "24" },
                    { "646f31a6-6b5f-4692-ad74-1a6208f2af09", "UE Parceira", "25" },
                    { "c21ae571-fe2d-4f4b-97ca-5ec2fec5eeb6", "AD", "26" },
                    { "d9f8ab05-1607-4a50-b06d-252c4f7bd7c7", "CP", "27" },
                    { "3275e504-9b2f-4221-b4fc-78f394dc2b0b", "Secretário Escola", "28" },
                    { "eb5763b4-4416-4014-bd91-63472ec7f34d", "COTIC", "29" },
                    { "a6451b44-abf7-400e-aa4b-bb536f99cd76", "UE", "30" },
                    { "dde7ccbe-2934-4649-b0a4-d8a7a77fc341", "CJ E Volante (PEI, ADI)", "31" },
                    { "e7b9ebaf-f4a7-4a5e-acef-9f53036580c5", "Fund. e Inf.", "32" },
                    { "824ebc09-da86-4791-b5a6-b2f71213e25b", "NAAPA", "17" },
                    { "c8180c42-1663-43c8-8fc4-5fa238e03e2b", "DIPED", "16" },
                    { "a5742a06-fcfb-4348-9969-514182ea78e4", "Supervisor DRE", "15" },
                    { "be4c5ecd-3492-4fb2-9a6d-5f953c66ea70", "Técnico", "14" },
                    { "000af335-784d-49dd-8bf3-70c3e5b9ecb9", "ATE", "34" },
                    { "61e607df-c0b3-4f64-9386-dad686f110ab", "Readaptado", "33" },
                    { "57d5bf0d-2b06-442d-8ed3-b033473153d6", "Desenvolvedor", "0" },
                    { "f4bc9983-038c-4bdd-8966-2f2217614eb5", "COTIC", "1" },
                    { "c42c5c32-d5af-41dc-9f96-8c6f16c52199", "SME", "2" },
                    { "f32a48ce-79cd-429d-8dff-c2e636084070", "COPED", "3" },
                    { "55d901db-cbb2-431d-b7b8-d3cab282a880", "DIEFEM", "4" },
                    { "f689b9a3-354c-490e-87bd-23c8137761d8", "POA", "33" },
                    { "f16550cb-6911-4998-a642-1d8cdf319801", "DIEI", "5" },
                    { "43d91b98-ebed-44a6-a7fb-882173906fd2", "DIEE", "7" },
                    { "1f370bd6-bd40-4665-999a-7f79ca801e13", "NTA", "8" },
                    { "949c268f-98b3-4812-98ba-32d36553c728", "NTC", "9" },
                    { "01921b32-02ff-4281-923b-7d20ff9beb0f", "NTC-NAAPA", "10" },
                    { "3702dfc3-ac27-42ac-bae7-1ffc68de1ec3", "DIEE-Conveniado", "11" },
                    { "82f59765-015a-43fe-9971-25b34fcb1fb4", "COPED Básico", "12" },
                    { "848707b4-766a-488b-b335-1d986a6c657f", "Regional", "13" },
                    { "8f8e2e0d-278f-4d83-83c7-e141220ce9de", "DIEJA", "6" },
                    { "2f70d53b-1bec-47e8-9776-ba33556ed848", "PAP", "34" }
                });

            migrationBuilder.InsertData(
                table: "PollType",
                columns: new[] { "Id", "PollTypeDescription" },
                values: new object[,]
                {
                    { "98ba487b-b377-4132-b351-dbb737a806ff", "Sondagem de Português" },
                    { "75f21b75-e064-4704-8116-2ac7fe9d05c1", "Sondagem de Alfabetização de Matemática" },
                    { "b79f49e9-ad5e-4c9b-9f10-eadfd2a25826", "Sondagem de Matemática" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "98643d8a-1272-4841-9f95-dd4543f6b3d1", "Admin" },
                    { "fd24a1ba-7eec-4b64-8284-e87aa3d18131", "Diretor" },
                    { "10684ef0-1a26-418b-bb03-f083d0091260", "Supervisor" },
                    { "a1c38938-79bf-457a-85c3-cb73d15ebf02", "Diretor" },
                    { "4d6f6908-3991-44de-97de-e3425a3b13a3", "Secretario(a)" },
                    { "3854e3fa-fd9d-429e-ad6b-a1d45482fba1", "Auxiliar" },
                    { "2aff515a-d616-4d0d-b925-b4c891bf5fb0", "Professor" },
                    { "9a015b42-4491-44db-a0e5-ce720e8207aa", "Responsavel" },
                    { "134f752d-4d91-42ee-8e83-4970bc933cf4", "Aluno" }
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
