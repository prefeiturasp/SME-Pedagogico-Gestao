using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.WebApp.Models.Auth
{
    public class CredentialModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
    }
}
