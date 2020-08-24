using System;
using System.Collections.Generic;
using System.Text;
using SME.Pedagogico.Gestao.Models.Base.Abstracts;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class Ordem : Table
    {
        public string Descricao { get; set; }
        public string GrupoId { get; set; }
        public virtual Grupo Grupo { get; set; }
        public bool Excluido { get; set; }
    }
}
