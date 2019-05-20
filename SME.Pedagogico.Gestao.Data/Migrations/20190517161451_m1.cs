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
                    { "51847417-a0e0-4a5d-918d-4628cdc6f03a", "Desenvolvedor", "0" },
                    { "46a7aa47-c904-434b-8383-83517476daf7", "Adm DRE", "21" },
                    { "709bbbd5-d0f7-42d2-9d3e-1a915416834b", "Básico DRE", "22" },
                    { "83a4de5e-01ef-4a3f-ad57-0992415a2230", "Infantil", "24" },
                    { "f3bcb5d9-9ffc-4f9c-92c5-8ae3b054817e", "UE Parceira", "25" },
                    { "6a8b1f22-ab6b-4fa9-8f03-5611a7335d53", "AD", "26" },
                    { "16195402-0627-4e33-9a7b-2ea1a5a54392", "CP", "27" },
                    { "11cbed50-1f1c-43b6-82da-e34c04900b8d", "Secretário Escola", "28" },
                    { "0e0e5704-bac8-4881-ad2b-d83fea251baa", "DIPED DRE", "20" },
                    { "a87433b8-7771-43af-89aa-2b68aebfb853", "COTIC", "29" },
                    { "6939cf4d-aea0-4f94-b413-c0666e0be7e8", "CJ E Volante (PEI, ADI)", "31" },
                    { "0c673b2d-974d-4d2e-b1fa-45c9f0d13551", "Fund. e Inf.", "32" },
                    { "0bf8f34a-8ad2-4965-8aba-2641d66ba38c", "POA", "33" },
                    { "f45862f4-4527-4df9-a578-aee5ae8f15a3", "PAP", "34" },
                    { "c89193a3-0cca-44a4-bc71-b1308f4e3179", "AEE", "35" },
                    { "ba96524a-f456-4460-8cc3-5271fcd13168", "Readaptado", "33" },
                    { "dc088cd7-e418-4c96-bf6f-1e5f4ec28291", "ATE", "34" },
                    { "7ae09eb2-43a7-4af3-952a-1ea506fe71d3", "UE", "30" },
                    { "2cfee8fa-dc82-4b34-96d1-842397ddb9c7", "PAAI", "19" },
                    { "ad57030e-a589-4208-8bfa-83627114ac05", "Básico Escola", "23" },
                    { "101872c4-6391-4376-938d-5ab3166cb11b", "NAAPA", "17" },
                    { "8a2775fb-a1bc-4f68-8776-3b5d2afad56c", "COTIC", "1" },
                    { "bc8d1f53-5888-45b9-9171-ee9bfa671de8", "SME", "2" },
                    { "3a27ded1-30d0-4131-9a2f-399ca11c4f5c", "COPED", "3" },
                    { "d97f7c3a-527c-4e49-8355-5bed006d8b88", "DIEFEM", "4" },
                    { "10072826-5399-469f-af46-a16b4f35f1a2", "CEFAI", "18" },
                    { "ae65435b-aa1d-44cc-92f1-5f9a32260208", "DIEJA", "6" },
                    { "c851fa70-ff06-48ea-ac0a-1f1aa7189808", "DIEE", "7" },
                    { "93f26e54-8568-4634-95b3-0945c1e51ee5", "NTA", "8" },
                    { "bb8c9de4-892b-45e2-9599-901770bd1874", "DIEI", "5" },
                    { "9fe95916-8706-4a28-b0b8-3b324d0365a7", "NTC-NAAPA", "10" },
                    { "31f676ed-4719-4c73-abc4-ac3f37c5003c", "DIEE-Conveniado", "11" },
                    { "64c9c2ca-8631-403c-b8a4-21f45c90d6c8", "COPED Básico", "12" },
                    { "556eb493-223d-4711-ab60-5cf949a7b5cd", "Regional", "13" },
                    { "d20b19b7-7525-40bb-aae1-f6a2796519f2", "Técnico", "14" },
                    { "7adae218-5d27-4b2b-9aaa-e9ac6e3eb7f1", "Supervisor DRE", "15" },
                    { "b3f7ee02-2025-40c8-9d94-8f5d9b0b8ede", "DIPED", "16" },
                    { "62b5bb0e-080a-42a0-821e-75e757113669", "NTC", "9" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "a8856347-f9be-437e-8a57-09358b6f9467", "Professor" },
                    { "638b7305-8f20-446e-91dd-6b8a826ee1d7", "Auxiliar" },
                    { "6ced5dc6-1d54-4e62-8d6a-1acec0a4051b", "Secretario(a)" },
                    { "15a0e83c-6a72-4e90-b065-78f3c4620097", "Admin" },
                    { "2347af68-756c-4bca-9e49-c9a506c9c9cb", "Supervisor" },
                    { "2e54c13a-cf62-480e-a148-5cd64a032501", "Diretor" },
                    { "02de0f62-e45a-4c2e-a28b-97eb414db9bb", "Responsavel" },
                    { "9130abda-0f4a-4adc-a556-81ac17d68dd2", "Diretor" },
                    { "5b2f1c50-f241-4b3a-acf6-f276e37c9b0f", "Aluno" }
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
