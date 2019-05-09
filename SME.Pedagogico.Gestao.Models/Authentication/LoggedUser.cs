using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Models.Authentication
{
    public class LoggedUser : Base.Abstracts.Table
    {
        public string RefreshToken { get; set; }
        public DateTime LastAccess { get; set; }
        public DateTime ExpiresAt { get; set; }


        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
