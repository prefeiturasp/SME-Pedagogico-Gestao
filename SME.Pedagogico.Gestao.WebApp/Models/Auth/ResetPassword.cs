using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.WebApp.Models.Auth
{
    public class ResetPassword
    {
        public string Username { get; set; }
        public string NewPassword { get; set; }
        public string Key { get; set; }
    }
}
