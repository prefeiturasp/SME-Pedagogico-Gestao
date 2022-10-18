using System.ComponentModel.DataAnnotations;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class PerguntaAnoEscolarBimestre
    {
        [Key]
        public long Id { get; set; }
        public int Bimestre { get; set; }
        public string PerguntaAnoEscolarId { get; set; }
        public virtual PerguntaAnoEscolar PerguntaAnoEscolar { get; set; }
    }
}