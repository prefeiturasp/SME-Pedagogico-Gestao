using System;
using System.Collections.Generic;
using System.Text;
using SME.Pedagogico.Gestao.Models.Base.Abstracts;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class Pergunta //: Table
    {
        public string  Id { get; set; }
        public string Descricao { get; set; }
        //public int Ordenacao { get; set; }
        public string ComponenteCurricularId { get; set; }
        public virtual ComponenteCurricular ComponenteCurricular { get; set; }
        public bool Excluido { get; set; }
    }
}
