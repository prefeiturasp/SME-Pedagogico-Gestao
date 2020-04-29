using SME.Pedagogico.Gestao.WebApp.Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO
{
    public class BuscaPerfilServidor
    {
        public string codigoRF { get; set; }
        public string codigoCargo { get; set; }
        public string anoLetivo { get; set; }
        public string roleId { get; set; }
        public UserRoleModel activeRole { get; set; }
    }
}
