using System;
using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Infra
{
    public class PerfisUsuarioSondagemDto
    {
        public PerfisUsuarioSondagemDto()
        {
            Perfis = new List<Guid>();    
        }
        
        public string CodigoRf { get; set; }
        public bool PossuiCargoCJ { get; set; }
        public bool PossuiPerfilCJ { get; set; }
        public bool ContratoExterno { get; set; }
        public IList<Guid> Perfis { get; set; }
        public IList<GrupoUsuarioGuidNomeDto> PerfisCompleto { get; set; }
        public bool PossuiPerfilProfessor { get; set; }
        public bool PossuiPerfilProfessorPoa { get; set; }
        public bool PossuiPerfilDre { get; set; }
        public bool PossuiPerfilSme { get; set; }
        public bool PossuiPerfilSmeOuDre { get; set; }
    }
}