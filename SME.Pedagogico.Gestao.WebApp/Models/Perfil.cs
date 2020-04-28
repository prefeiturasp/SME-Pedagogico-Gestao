using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.WebApp.Models
{
    public class Perfil
    {
        public Guid PerfilGuid { get; set; }
        public string AccessLevel { get; set; }
        public string RoleName { get; set; }
        public bool IsTeacher { get; set; }
        public bool IsDre { get; set; }
        public bool IsSme { get; set; }
        public bool haveOccupationAccess { get; set; }

        public static IEnumerable<Perfil> ObterPerfis()
        {
            return new List<Perfil>
            {
                new Perfil
                {
                    PerfilGuid = Guid.Parse("40E1E074-37D6-E911-ABD6-F81654FE895D"),
                    IsTeacher = true,
                    RoleName = "Professor",
                    haveOccupationAccess = true,
                    AccessLevel = "32",
                    IsDre = false,
                    IsSme = false
                },
                new Perfil
                {
                    PerfilGuid = Guid.Parse("44E1E074-37D6-E911-ABD6-F81654FE895D"),
                    IsTeacher = false,
                    RoleName = "CP",
                    haveOccupationAccess = true,
                    AccessLevel = "27",
                    IsDre = false,
                    IsSme = false
                },
                new Perfil
                {
                    PerfilGuid = Guid.Parse("46E1E074-37D6-E911-ABD6-F81654FE895D"),
                    IsTeacher = false,
                    RoleName = "Diretor",
                    haveOccupationAccess = true,
                    AccessLevel = "27",
                    IsDre = false,
                    IsSme = false
                },
                new Perfil
                {
                    PerfilGuid =  Guid.Parse("45E1E074-37D6-E911-ABD6-F81654FE895D"),
                    IsTeacher = false,
                    RoleName = "AD",
                    haveOccupationAccess = false,
                    AccessLevel = "26",
                    IsDre = false,
                    IsSme = false
                },
                new Perfil
                {
                    PerfilGuid = Guid.Parse("48E1E074-37D6-E911-ABD6-F81654FE895D"),
                    IsTeacher = false,
                    RoleName = "Adm DRE",
                    haveOccupationAccess = false,
                    AccessLevel = "21",
                    IsDre = true,
                    IsSme = false
                },
                new Perfil
                {
                    PerfilGuid = Guid.Parse("49E1E074-37D6-E911-ABD6-F81654FE895D"),
                    IsTeacher = false,
                    RoleName = "DIPED",
                    haveOccupationAccess = false,
                    AccessLevel = "20",
                    IsDre = true,
                    IsSme = false
                },
                new Perfil
                {
                    PerfilGuid = Guid.Parse("58E1E074-37D6-E911-ABD6-F81654FE895D"),
                    IsTeacher = false,
                    RoleName = "DIEFEM",
                    haveOccupationAccess = false,
                    AccessLevel = "4",
                    IsDre = false,
                    IsSme = true
                },
                new Perfil
                {
                    PerfilGuid = Guid.Parse("59E1E074-37D6-E911-ABD6-F81654FE895D"),
                    IsTeacher = false,
                    RoleName = "COPED",
                    haveOccupationAccess = false,
                    AccessLevel = "3",
                    IsDre = false,
                    IsSme = true
                },
                new Perfil
                {
                    PerfilGuid = Guid.Parse("5AE1E074-37D6-E911-ABD6-F81654FE895D"),
                    IsTeacher = false,
                    RoleName = "ADM SME",
                    haveOccupationAccess = false,
                    AccessLevel = "2",
                    IsDre = false,
                    IsSme = true
                },
                new Perfil
                {
                    PerfilGuid = Guid.Parse("5BE1E074-37D6-E911-ABD6-F81654FE895D"),
                    IsTeacher = false,
                    RoleName = "ADM COTIC",
                    haveOccupationAccess = false,
                    AccessLevel = "1",
                    IsDre = false,
                    IsSme = true
                }
            };
        }
    }
}
