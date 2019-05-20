using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.WebApp.Models.Auth
{
    public class UserRoleModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string AccessLevelId { get; set; }
        public string AccessLevel { get; set; }
        public string Description { get; set; }
    }
}
