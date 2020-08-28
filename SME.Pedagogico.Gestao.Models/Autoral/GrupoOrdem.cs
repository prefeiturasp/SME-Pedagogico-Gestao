using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class GrupoOrdem
    {
        public string Id { get; set; }
        public string GrupoId { get; set; }
        public virtual Grupo Grupo { get; set; }
        public string OrdemId { get; set; }
        public virtual Ordem Ordem { get; set; }
        public int Ordenacao { get; set; }
        public bool Excluido { get; set; }


    }
}
