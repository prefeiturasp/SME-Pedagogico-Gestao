﻿using SME.Pedagogico.Gestao.Models.Base.Abstracts;
using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Models.Authentication
{
    public class User : NamedTable
    {
        #region ==================== ATTRIBUTES ====================

        public string Password { get; set; } = null;

        public virtual Entity.Profile Profile { get; set; }
        public virtual List<UserRole> Roles { get; set; }
        public virtual LoggedUser LoginStatus { get; set; }

        #endregion ==================== ATTRIBUTES ====================
    }
}