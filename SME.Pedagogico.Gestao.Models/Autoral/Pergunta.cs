using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class Pergunta //: Table
    {
        public string  Id { get; set; }
        public string  PerguntaPaiId { get; set; }
        public string Descricao { get; set; }
        public virtual List<OrdemPergunta> OrdemPergunta { get; set; }
        public string ComponenteCurricularId { get; set; }
        public virtual ComponenteCurricular ComponenteCurricular { get; set; }
        public bool Excluido { get; set; }
    }
}
