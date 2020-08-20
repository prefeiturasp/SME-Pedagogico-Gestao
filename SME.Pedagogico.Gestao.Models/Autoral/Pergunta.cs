using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class Pergunta
    {
        public Guid Id   { get; set; }
        public string Descricao { get; set; }
        public int Ordenacao { get; set; }
        public ComponenteCurricular ComponenteCurricular { get; set; }
        public bool Excluido { get; set; }
    }
}
