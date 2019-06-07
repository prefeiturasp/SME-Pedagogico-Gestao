﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SME.Pedagogico.Gestao.Data.Contexts;

namespace SME.Pedagogico.Gestao.Data.Migrations
{
    [DbContext(typeof(SMEManagementContext))]
    partial class SMEManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SME.Pedagogico.Gestao.Models.Academic.MathPoolCA", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AlunoEolCode");

                    b.Property<string>("AlunoNome");

                    b.Property<int>("AnoLetivo");

                    b.Property<int>("AnoTurma");

                    b.Property<string>("DreEolCode");

                    b.Property<string>("EscolaEolCode");

                    b.Property<string>("NumeroChamada");

                    b.Property<string>("Ordem1Ideia");

                    b.Property<string>("Ordem1Resultado");

                    b.Property<string>("Ordem2Ideia");

                    b.Property<string>("Ordem2Resultado");

                    b.Property<string>("Ordem3Ideia");

                    b.Property<string>("Ordem3Resultado");

                    b.Property<string>("Ordem4Ideia");

                    b.Property<string>("Ordem4Resultado");

                    b.Property<int>("Semestre");

                    b.Property<string>("TurmaEolCode");

                    b.HasKey("Id");

                    b.ToTable("MathPoolCAs");
                });

            modelBuilder.Entity("SME.Pedagogico.Gestao.Models.Academic.MathPoolCM", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AlunoEolCode");

                    b.Property<string>("AlunoNome");

                    b.Property<int>("AnoLetivo");

                    b.Property<int>("AnoTurma");

                    b.Property<string>("DreEolCode");

                    b.Property<string>("EscolaEolCode");

                    b.Property<string>("NumeroChamada");

                    b.Property<string>("Ordem3Ideia");

                    b.Property<string>("Ordem3Resultado");

                    b.Property<string>("Ordem4Ideia");

                    b.Property<string>("Ordem4Resultado");

                    b.Property<string>("Ordem5Ideia");

                    b.Property<string>("Ordem5Resultado");

                    b.Property<string>("Ordem6Ideia");

                    b.Property<string>("Ordem6Resultado");

                    b.Property<string>("Ordem7Ideia");

                    b.Property<string>("Ordem7Resultado");

                    b.Property<string>("Ordem8Ideia");

                    b.Property<string>("Ordem8Resultado");

                    b.Property<int>("Semestre");

                    b.Property<string>("TurmaEolCode");

                    b.HasKey("Id");

                    b.ToTable("MathPoolCMs");
                });

            modelBuilder.Entity("SME.Pedagogico.Gestao.Models.Academic.MathPoolNumber", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Algarismos");

                    b.Property<string>("AlunoEolCode");

                    b.Property<string>("AlunoNome");

                    b.Property<int>("AnoLetivo");

                    b.Property<int>("AnoTurma");

                    b.Property<string>("DreEolCode");

                    b.Property<string>("EscolaEolCode");

                    b.Property<string>("Familiares");

                    b.Property<string>("NumeroChamada");

                    b.Property<string>("Opacos");

                    b.Property<string>("Processo");

                    b.Property<int>("Semestre");

                    b.Property<string>("TerminamZero");

                    b.Property<string>("Transparentes");

                    b.Property<string>("TurmaEolCode");

                    b.Property<string>("ZeroIntercalados");

                    b.HasKey("Id");

                    b.ToTable("MathPoolNumbers");
                });

            modelBuilder.Entity("SME.Pedagogico.Gestao.Models.Academic.PollType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PollTypeDescription");

                    b.HasKey("Id");

                    b.ToTable("PollType");

                    b.HasData(
                        new
                        {
                            Id = "977a1919-b0d5-44aa-962f-0a1f939bd004",
                            PollTypeDescription = "Sondagem de Português"
                        },
                        new
                        {
                            Id = "7757e0cd-225b-458d-a445-a9096214e514",
                            PollTypeDescription = "Sondagem de Matemática"
                        },
                        new
                        {
                            Id = "261acf02-b715-41e3-bdc0-a2c414e0c13d",
                            PollTypeDescription = "Sondagem de Alfabetização de Matemática"
                        });
                });

            modelBuilder.Entity("SME.Pedagogico.Gestao.Models.Academic.PortuguesePoll", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("classroomCodeEol");

                    b.Property<string>("dreCodeEol");

                    b.Property<string>("reading1B");

                    b.Property<string>("reading2B");

                    b.Property<string>("reading3B");

                    b.Property<string>("reading4B");

                    b.Property<string>("schoolCodeEol");

                    b.Property<string>("schoolYear");

                    b.Property<string>("studentCodeEol");

                    b.Property<string>("studentNameEol");

                    b.Property<string>("writing1B");

                    b.Property<string>("writing2B");

                    b.Property<string>("writing3B");

                    b.Property<string>("writing4B");

                    b.Property<string>("yearClassroom");

                    b.HasKey("Id");

                    b.ToTable("PortuguesePolls");
                });

            modelBuilder.Entity("SME.Pedagogico.Gestao.Models.Academic.Student", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SME.Pedagogico.Gestao.Models.Academic.StudentCode", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodeId");

                    b.Property<string>("StudentId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CodeId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCodes");
                });

            modelBuilder.Entity("SME.Pedagogico.Gestao.Models.Academic.Teacher", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("SME.Pedagogico.Gestao.Models.Academic.TeacherCode", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodeId");

                    b.Property<string>("TeacherId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CodeId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherCodes");
                });

            modelBuilder.Entity("SME.Pedagogico.Gestao.Models.Authentication.AccessLevel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("AccessLevels");

                    b.HasData(
                        new
                        {
                            Id = "a64f6559-0e08-47cb-a183-1179fd1b34c9",
                            Description = "Desenvolvedor",
                            Value = "0"
                        },
                        new
                        {
                            Id = "475d2ed2-15d7-4835-8cb2-1cb28b5d4c8d",
                            Description = "COTIC",
                            Value = "1"
                        },
                        new
                        {
                            Id = "c4d0cf03-4d91-46b2-a3a7-a01c990c9cd4",
                            Description = "SME",
                            Value = "2"
                        },
                        new
                        {
                            Id = "95fdd23b-67f9-43c3-b4f8-e591c9cfd2cd",
                            Description = "COPED",
                            Value = "3"
                        },
                        new
                        {
                            Id = "0261c3a6-fcee-42c4-9461-b8bbc29d0ea7",
                            Description = "DIEFEM",
                            Value = "4"
                        },
                        new
                        {
                            Id = "1930d148-3a9f-4910-a77b-61357d416f8b",
                            Description = "DIEI",
                            Value = "5"
                        },
                        new
                        {
                            Id = "2716a17a-2754-4118-85ba-ab569296ee15",
                            Description = "DIEJA",
                            Value = "6"
                        },
                        new
                        {
                            Id = "bb850a1d-28b2-4b5b-b9ed-0c976168fe0a",
                            Description = "DIEE",
                            Value = "7"
                        },
                        new
                        {
                            Id = "96a78801-847e-4000-87a3-a326343d3143",
                            Description = "NTA",
                            Value = "8"
                        },
                        new
                        {
                            Id = "fbf5fe0a-39d0-445b-9966-28b503e7fef2",
                            Description = "NTC",
                            Value = "9"
                        },
                        new
                        {
                            Id = "572319f4-64d5-4926-9444-05fdaf133345",
                            Description = "NTC-NAAPA",
                            Value = "10"
                        },
                        new
                        {
                            Id = "c0940b0f-6bc8-4bcc-a419-8120746bcf9f",
                            Description = "DIEE-Conveniado",
                            Value = "11"
                        },
                        new
                        {
                            Id = "3b4725a9-3c9c-4134-8f3b-eecc17553aef",
                            Description = "COPED Básico",
                            Value = "12"
                        },
                        new
                        {
                            Id = "17c15905-4bc9-4fce-96a9-665a921902e5",
                            Description = "Regional",
                            Value = "13"
                        },
                        new
                        {
                            Id = "6f8c67f9-0383-4195-80c5-09976d600ff2",
                            Description = "Técnico",
                            Value = "14"
                        },
                        new
                        {
                            Id = "7c690f10-32b2-4ab2-aa36-fb231e852983",
                            Description = "Supervisor DRE",
                            Value = "15"
                        },
                        new
                        {
                            Id = "7388ac67-6d56-4ea5-9745-4388e2023d97",
                            Description = "DIPED",
                            Value = "16"
                        },
                        new
                        {
                            Id = "27bfd694-9337-44d5-8bc4-ff3b2f7412ab",
                            Description = "NAAPA",
                            Value = "17"
                        },
                        new
                        {
                            Id = "41ef9306-b621-432b-9664-042fd024dcb4",
                            Description = "CEFAI",
                            Value = "18"
                        },
                        new
                        {
                            Id = "99ab9df4-c365-4f5f-a641-49daa180e855",
                            Description = "PAAI",
                            Value = "19"
                        },
                        new
                        {
                            Id = "b354dfee-0e0d-455e-ba66-77da5a4f3ac5",
                            Description = "DIPED DRE",
                            Value = "20"
                        },
                        new
                        {
                            Id = "9d9b3b31-6be0-4ea3-a75b-8af4f5f8e502",
                            Description = "Adm DRE",
                            Value = "21"
                        },
                        new
                        {
                            Id = "3fe49272-a374-4195-b42a-df4b911a1b5c",
                            Description = "Básico DRE",
                            Value = "22"
                        },
                        new
                        {
                            Id = "4095364f-467b-4cb7-b87a-c7d45f7ac4b1",
                            Description = "Básico Escola",
                            Value = "23"
                        },
                        new
                        {
                            Id = "c509a676-b7da-4bd7-b1e3-4016661ced4c",
                            Description = "Infantil",
                            Value = "24"
                        },
                        new
                        {
                            Id = "445bd9f1-847d-4d51-aaf6-404d21634014",
                            Description = "UE Parceira",
                            Value = "25"
                        },
                        new
                        {
                            Id = "650d4c67-db38-4733-a6f4-0f56504dc9a2",
                            Description = "AD",
                            Value = "26"
                        },
                        new
                        {
                            Id = "51240101-d79f-4e21-970c-3385ece2df59",
                            Description = "CP",
                            Value = "27"
                        },
                        new
                        {
                            Id = "99fadc2a-8910-447c-82b7-27cc7b96a749",
                            Description = "Secretário Escola",
                            Value = "28"
                        },
                        new
                        {
                            Id = "33b05ae7-ae56-4ad4-b188-76c7420c0cc0",
                            Description = "COTIC",
                            Value = "29"
                        },
                        new
                        {
                            Id = "b14731a1-bdec-4ef7-adf9-f685ec020b64",
                            Description = "UE",
                            Value = "30"
                        },
                        new
                        {
                            Id = "9b4a0f5f-449a-41da-9865-e8de4dd6e8a6",
                            Description = "CJ E Volante (PEI, ADI)",
                            Value = "31"
                        },
                        new
                        {
                            Id = "779c60ef-e0ac-4dc1-ac55-54af173f0e1b",
                            Description = "Fund. e Inf.",
                            Value = "32"
                        },
                        new
                        {
                            Id = "0e2cc59e-1715-47ad-b0f1-502b643f7c62",
                            Description = "POA",
                            Value = "33"
                        },
                        new
                        {
                            Id = "06cfc778-86ed-44d5-b5b5-4c3fc9057d77",
                            Description = "PAP",
                            Value = "34"
                        },
                        new
                        {
                            Id = "5ebe9ebd-1fa6-48cd-99ab-ed317401625d",
                            Description = "AEE",
                            Value = "35"
                        },
                        new
                        {
                            Id = "d3e71547-5b2c-4a65-998b-da0cc885e115",
                            Description = "Readaptado",
                            Value = "36"
                        },
                        new
                        {
                            Id = "2ad1ca3e-eda5-4f36-8ae8-11a0df761177",
                            Description = "ATE",
                            Value = "37"
                        });
                });

            modelBuilder.Entity("SME.Pedagogico.Gestao.Models.Authentication.LoggedUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ExpiresAt");

                    b.Property<DateTime>("LastAccess");

                    b.Property<string>("RefreshToken");

                    b.Property<string>("Session");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("LoggedUsers");
                });

            modelBuilder.Entity("SME.Pedagogico.Gestao.Models.Authentication.PrivilegedAccess", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Login");

                    b.Property<string>("Name");

                    b.Property<string>("OccupationPlace");

                    b.Property<int>("OccupationPlaceCode");

                    b.HasKey("Id");

                    b.ToTable("PrivilegedAccess");

                    b.HasData(
                        new
                        {
                            Id = "3c26c46e-f6af-4ebb-9238-af83bae6bede",
                            Login = "caique.amcom",
                            Name = "Caique Latorre",
                            OccupationPlace = "AMCOM",
                            OccupationPlaceCode = 1
                        },
                        new
                        {
                            Id = "913cfb74-ad55-4bd8-a2aa-6da55e967c29",
                            Login = "massato.amcom",
                            Name = "Massato Kanno",
                            OccupationPlace = "AMCOM",
                            OccupationPlaceCode = 1
                        },
                        new
                        {
                            Id = "db6457e6-4886-439f-934e-368d636c55ce",
                            Login = "Daniel.amcom",
                            Name = "Daniel Matsumoto",
                            OccupationPlace = "AMCOM",
                            OccupationPlaceCode = 1
                        },
                        new
                        {
                            Id = "b04f4d21-edab-4941-b650-bf1ddb848c2c",
                            Login = "danielli.amcom",
                            Name = "Danielli",
                            OccupationPlace = "AMCOM",
                            OccupationPlaceCode = 1
                        },
                        new
                        {
                            Id = "d86faeba-5d54-4f3e-90bf-78eff4150cd1",
                            Login = "jeff.amcom",
                            Name = "Jeff",
                            OccupationPlace = "AMCOM",
                            OccupationPlaceCode = 1
                        },
                        new
                        {
                            Id = "af0fbc61-529e-4eac-b886-5d459c09de19",
                            Login = "aline.amcom",
                            Name = "Aline",
                            OccupationPlace = "AMCOM",
                            OccupationPlaceCode = 1
                        },
                        new
                        {
                            Id = "544a468f-8277-4b97-a4be-ddf53bd5ac3e",
                            Login = "gabi.sme",
                            Name = "Gabi",
                            OccupationPlace = "SME",
                            OccupationPlaceCode = 2
                        },
                        new
                        {
                            Id = "96f87613-6fe2-46a2-a95f-5e5c95e03d3d",
                            Login = "heloisa.sme",
                            Name = "Heloisa Giannichi",
                            OccupationPlace = "SME",
                            OccupationPlaceCode = 2
                        });
                });

            modelBuilder.Entity("SME.Pedagogico.Gestao.Models.Authentication.Role", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = "f07e2ee3-914e-4b6f-9e0e-08efd1f381f0",
                            Name = "Admin"
                        },
                        new
                        {
                            Id = "065c0824-9b02-466a-8638-0c48485909f1",
                            Name = "Diretor"
                        },
                        new
                        {
                            Id = "73f9f236-5691-485a-af17-fcf791b56165",
                            Name = "Supervisor"
                        },
                        new
                        {
                            Id = "bee0702a-e91c-4d60-a872-20138209451c",
                            Name = "Diretor"
                        },
                        new
                        {
                            Id = "8e162e4b-c540-4d26-b4b0-747c2002181e",
                            Name = "Secretario(a)"
                        },
                        new
                        {
                            Id = "9e1de1c8-3702-4bd8-83e1-dc51cc10af26",
                            Name = "Auxiliar"
                        },
                        new
                        {
                            Id = "f9de9efb-6ffb-4465-b0fa-83787ab620cc",
                            Name = "Professor"
                        },
                        new
                        {
                            Id = "2ddd75e9-2dd6-4785-a3cf-09bca3dd1c67",
                            Name = "Responsavel"
                        },
                        new
                        {
                            Id = "b0de13d4-6cd0-4da1-ad12-3c23e72b20cf",
                            Name = "Aluno"
                        });
                });

            modelBuilder.Entity("SME.Pedagogico.Gestao.Models.Authentication.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SME.Pedagogico.Gestao.Models.Authentication.UserRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessLevelId");

                    b.Property<string>("RoleId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AccessLevelId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("SME.Pedagogico.Gestao.Models.Entity.Profile", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("StudentId");

                    b.Property<string>("TeacherId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.HasIndex("TeacherId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("SME.Pedagogico.Gestao.Models.Organization.Code", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Codes");
                });

            modelBuilder.Entity("SME.Pedagogico.Gestao.Models.Organization.LogControl", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("ModifiedAt");

                    b.HasKey("Id");

                    b.ToTable("LogControls");
                });

            modelBuilder.Entity("SME.Pedagogico.Gestao.Models.Academic.StudentCode", b =>
                {
                    b.HasOne("SME.Pedagogico.Gestao.Models.Organization.Code", "Code")
                        .WithMany("StudentCodes")
                        .HasForeignKey("CodeId");

                    b.HasOne("SME.Pedagogico.Gestao.Models.Academic.Student", "Student")
                        .WithMany("Codes")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("SME.Pedagogico.Gestao.Models.Academic.TeacherCode", b =>
                {
                    b.HasOne("SME.Pedagogico.Gestao.Models.Organization.Code", "Code")
                        .WithMany("TeacherCodes")
                        .HasForeignKey("CodeId");

                    b.HasOne("SME.Pedagogico.Gestao.Models.Academic.Teacher", "Teacher")
                        .WithMany("Codes")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("SME.Pedagogico.Gestao.Models.Authentication.LoggedUser", b =>
                {
                    b.HasOne("SME.Pedagogico.Gestao.Models.Authentication.User", "User")
                        .WithOne("LoginStatus")
                        .HasForeignKey("SME.Pedagogico.Gestao.Models.Authentication.LoggedUser", "UserId");
                });

            modelBuilder.Entity("SME.Pedagogico.Gestao.Models.Authentication.UserRole", b =>
                {
                    b.HasOne("SME.Pedagogico.Gestao.Models.Authentication.AccessLevel", "AccessLevel")
                        .WithMany("UserRoles")
                        .HasForeignKey("AccessLevelId");

                    b.HasOne("SME.Pedagogico.Gestao.Models.Authentication.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId");

                    b.HasOne("SME.Pedagogico.Gestao.Models.Authentication.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SME.Pedagogico.Gestao.Models.Entity.Profile", b =>
                {
                    b.HasOne("SME.Pedagogico.Gestao.Models.Academic.Student", "Student")
                        .WithOne("Profile")
                        .HasForeignKey("SME.Pedagogico.Gestao.Models.Entity.Profile", "StudentId");

                    b.HasOne("SME.Pedagogico.Gestao.Models.Academic.Teacher", "Teacher")
                        .WithOne("Profile")
                        .HasForeignKey("SME.Pedagogico.Gestao.Models.Entity.Profile", "TeacherId");

                    b.HasOne("SME.Pedagogico.Gestao.Models.Authentication.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("SME.Pedagogico.Gestao.Models.Entity.Profile", "UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
