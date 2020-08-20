using SME.Pedagogico.Gestao.Models.Base.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class ComponenteCurricular : Table
    {
        public string Descricao { get; set; }
        public bool Excluido { get; set; }
    }
}
