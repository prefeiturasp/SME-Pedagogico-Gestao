using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class Pergunta //: Table
    {
        public string  Id { get; set; }
        public string Descricao { get; set; }
        public virtual List<OrdemPergunta> OrdemPergunta { get; set; }
        public string ComponenteCurricularId { get; set; }
        public virtual ComponenteCurricular ComponenteCurricular { get; set; }
        public bool Excluido { get; set; }
        [NotMapped]
        public virtual Pergunta PerguntaPai { get; set; }
    }
}
