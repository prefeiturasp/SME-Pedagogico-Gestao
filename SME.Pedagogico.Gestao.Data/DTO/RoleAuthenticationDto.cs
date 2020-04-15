using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO
{
    public class RoleAuthenticationDto
    {
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public string AccessLevelValue { get; set; }
    }
}
