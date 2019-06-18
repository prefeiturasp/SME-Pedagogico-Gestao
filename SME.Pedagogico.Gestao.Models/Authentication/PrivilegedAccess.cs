using SME.Pedagogico.Gestao.Models.Base.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Models.Authentication
{
  public  class PrivilegedAccess : Table 
    {
        public string  Name { get; set; }
        public string Login { get; set; }
        public string OccupationPlace { get; set; }
        public int OccupationPlaceCode { get; set; }
        public string  DreCodeEol { get; set; }
    }
}
