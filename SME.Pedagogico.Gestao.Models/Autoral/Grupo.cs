
using SME.Pedagogico.Gestao.Models.Base.Abstracts;
using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class Grupo : Table

    {
       
        public string Descricao { get; set; }
        public bool Excluido { get; set; }
        public  virtual  List<Ordem> Ordem { get; set; }
    }
}
