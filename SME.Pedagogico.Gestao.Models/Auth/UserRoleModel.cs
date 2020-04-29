using System;

namespace SME.Pedagogico.Gestao.WebApp.Models.Auth
{
    public class UserRoleModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string AccessLevelId { get; set; }
        public string AccessLevel { get; set; }
        public string Description { get; set; }
        public Guid? PerfilId { get; set; }
    }
}