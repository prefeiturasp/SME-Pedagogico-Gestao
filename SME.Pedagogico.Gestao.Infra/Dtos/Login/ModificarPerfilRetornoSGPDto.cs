using System;

namespace SME.Pedagogico.Gestao.Infra
{
    public class ModificarPerfilRetornoSGPDto
    {
        public bool EhProfessor { get; set; }
        public bool EhProfessorCj { get; set; }
        public bool EhProfessorPoa { get; set; }
        public DateTime DataHoraExpiracao { get; set; }
        public string Token { get; set; }
        public bool EhProfessorCjInfantil { get; set; }
        public bool EhProfessorInfantil { get; set; }
    }
}
