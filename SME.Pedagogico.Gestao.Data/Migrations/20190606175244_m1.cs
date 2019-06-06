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
                    { "75c46e09-9785-4712-a024-e6a94d549581", "UE Parceira", "25" },
                    { "f9ebfe86-5dbf-4da8-9df2-2e25f0a72bea", "CEFAI", "18" },
                    { "b467b113-cbf8-4acf-a9db-8efc23246363", "PAAI", "19" },
                    { "3ebd57e4-2600-4171-8071-7e084502d18c", "DIPED DRE", "20" },
                    { "8e384961-c431-4eac-aef0-dbd24b0c41e3", "Adm DRE", "21" },
                    { "feb6982b-84b8-4733-82d5-ad059eb474c1", "Básico DRE", "22" },
                    { "4d88da3f-47aa-4077-a3a6-f17bb3f847b8", "Básico Escola", "23" },
                    { "a917ecfd-fd8d-43d5-a476-055d99190b13", "Infantil", "24" },
                    { "144a201e-f3ea-4ab4-ab9f-c265c7014feb", "AEE", "35" },
                    { "9db3aaa2-4aab-4d34-a1aa-501c28208a88", "AD", "26" },
                    { "fc1896b4-d9aa-4c5d-9972-2a4d82311dab", "CP", "27" },
                    { "98cff31c-cd8c-41f1-bc07-f37240e20174", "Secretário Escola", "28" },
                    { "3918ef88-1524-402e-ab56-8444c4b398bc", "COTIC", "29" },
                    { "6907ebef-62cf-4396-b1b8-93a393944860", "UE", "30" },
                    { "c91bd518-8b0f-4516-af9f-766b471e7024", "CJ E Volante (PEI, ADI)", "31" },
                    { "2aeb38f5-5324-4015-abe1-f5982efc8563", "Fund. e Inf.", "32" },
                    { "c0adbe15-ae33-4e0d-aff9-c5cc27bfdac5", "NAAPA", "17" },
                    { "25cc4ed0-1344-4270-b878-551d2834c075", "DIPED", "16" },
                    { "405c7282-2589-4b65-889b-71cc559c2f5d", "Supervisor DRE", "15" },
                    { "beaf8491-ea5f-4a76-b5f8-ebb4721bc0db", "Técnico", "14" },
                    { "342ff63e-0211-4b06-a935-271b94b1009b", "ATE", "37" },
                    { "86d480f0-89db-44d8-9a9e-60edf46b5d7b", "Readaptado", "36" },
                    { "6581796a-8e98-46ad-bb39-40455d3310ff", "Desenvolvedor", "0" },
                    { "4867a294-3b45-4357-ab69-0f483e46f0f0", "COTIC", "1" },
                    { "3d1e49de-63b7-498e-b607-9d4ef4ac8a02", "SME", "2" },
                    { "966c3836-b61b-40e0-8d55-679b147e9a58", "COPED", "3" },
                    { "09a111c9-bfc6-426d-9559-04e66ca2508e", "DIEFEM", "4" },
                    { "a2f54490-2284-4e5c-b27d-2f4a22a91ef1", "POA", "33" },
                    { "1b74fe32-4ff8-4bde-af61-796d056b1afd", "DIEI", "5" },
                    { "790eb99e-5371-44fe-8b1b-87b529336705", "DIEE", "7" },
                    { "792abbf0-2056-4906-beee-a4c2bc6a2304", "NTA", "8" },
                    { "c4d2972e-a7b5-4be0-b499-e9c2c6bd79ba", "NTC", "9" },
                    { "b5330752-7ece-4d21-a1b5-fee8accb83a9", "NTC-NAAPA", "10" },
                    { "17b29d4a-f652-4b9f-aadb-a86d2b8f7b0c", "DIEE-Conveniado", "11" },
                    { "91cf288a-36f0-48b8-ae08-6d7f26046da4", "COPED Básico", "12" },
                    { "1d410d23-5a1d-409a-b3dd-082658229070", "Regional", "13" },
                    { "ab2b887d-15e5-429d-882b-af40e0870247", "DIEJA", "6" },
                    { "2bdfab29-3c14-4f40-9561-71e30ebddb42", "PAP", "34" }
                });

            migrationBuilder.InsertData(
                table: "PollType",
                columns: new[] { "Id", "PollTypeDescription" },
                values: new object[,]
                {
                    { "cc8ac4b6-2e9e-4f06-a719-e94058251ea5", "Sondagem de Português" },
                    { "018b2c19-4f43-4627-8855-b03bf7b95920", "Sondagem de Alfabetização de Matemática" },
                    { "9a113be3-7506-49f9-b5df-667ce6ad6bf2", "Sondagem de Matemática" }
                });

            migrationBuilder.InsertData(
                table: "PrivilegedAccess",
                columns: new[] { "Id", "Login", "Name", "OccupationPlace", "OccupationPlaceCode" },
                values: new object[,]
                {
                    { "bbabe6a2-99b7-4ad0-97d8-010ebfd742ac", "gabi.sme", "Gabi", "SME", 2 },
                    { "36e510e4-ae6a-4fa2-b668-62891e952245", "aline.amcom", "Aline", "AMCOM", 1 },
                    { "f6033d9e-0712-4f66-b228-a0b7a27e0083", "jeff.amcom", "Jeff", "AMCOM", 1 },
                    { "5323e4fd-fa90-4323-aa46-87ca04b2cfcc", "heloisa.sme", "Heloisa Giannichi", "SME", 2 },
                    { "ccec87a2-dd43-49fb-ad3e-5a2fbc35f360", "Daniel.amcom", "Daniel Matsumoto", "AMCOM", 1 },
                    { "1125d90a-8b3e-4463-93a2-71d3356611c4", "massato.amcom", "Massato Kanno", "AMCOM", 1 },
                    { "17c9943d-0abb-4a0f-8722-536a8ae52d62", "caique.amcom", "Caique Latorre", "AMCOM", 1 },
                    { "77175dba-aa8d-4a33-8682-59b8771bf439", "danielli.amcom", "Danielli", "AMCOM", 1 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "49cf6fa3-fcca-4fde-8eb2-d7b89e573bdc", "Responsavel" },
                    { "683ce3fd-8e56-4dce-b8d9-9d5354dc5e91", "Admin" },
                    { "0507a90a-b70a-4d7a-9379-c9b3b19db0b1", "Diretor" },
                    { "f9c81811-05b5-42e0-b89b-6442c5068d2a", "Supervisor" },
                    { "b7a50ae8-fbc7-4430-ae24-d573dc6ce1da", "Diretor" },
                    { "0c772e04-4541-4e26-8269-729e2ee65f41", "Secretario(a)" },
                    { "14b8e37e-51d0-4d0f-843a-c442e71219b7", "Auxiliar" },
                    { "f3ddbc11-22e2-4459-98fd-7f8bc993839d", "Professor" },
                    { "1a6f1be2-7ac8-45e2-a0c3-b5d91644a1bc", "Aluno" }
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
