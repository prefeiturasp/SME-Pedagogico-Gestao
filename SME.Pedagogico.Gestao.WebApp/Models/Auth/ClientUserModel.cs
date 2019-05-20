using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.WebApp.Models.Auth
{
    public class ClientUserModel
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public IdentityModel Identity { get; set; }
        public IEnumerable<Cookie> Cookies { get; set; }
        public SMETokenModel SMEToken { get; set; }
        public List<UserRoleModel> Roles { get; set; } = new List<UserRoleModel>();
    }
}
