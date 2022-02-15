using SME.Pedagogico.Gestao.Models.Base.Abstracts;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class Resposta : Table
    {
        public string Descricao { get; set; }
        public bool Excluido { get; set; }
        public bool Verdadeiro { get; set; }
    }
}
