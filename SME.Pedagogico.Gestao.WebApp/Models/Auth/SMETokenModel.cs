using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.WebApp.Models.Auth
{
    public class SMETokenModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
