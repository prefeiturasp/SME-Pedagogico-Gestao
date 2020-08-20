using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class Ordem
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public Grupo Grupo { get; set; }
        public bool Excluido { get; set; }
    }
}
