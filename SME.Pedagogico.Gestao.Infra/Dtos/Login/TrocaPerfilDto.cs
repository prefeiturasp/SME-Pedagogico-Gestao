using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Infra
{
    public class TrocaPerfilDto
    {
        public bool EhProfessor { get; set; }
        public bool EhProfessorCj { get; set; }
        public bool EhProfessorPoa { get; set; }
        public DateTime DataHoraExpiracao { get; set; }
        public string Token { get; set; }
    }
}
