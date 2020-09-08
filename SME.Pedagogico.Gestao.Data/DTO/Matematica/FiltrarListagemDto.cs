using System;

namespace SME.Pedagogico.Gestao.Data.DTO.Matematica
{
    public class FiltrarListagemDto
    {
        public int AnoEscolar { get; set; }
        public int AnoLetivo { get; set; }
        public string CodigoDre { get; set; }
        public string CodigoUe { get; set; }
        public string CodigoTurma { get; set; }
        public Guid ComponenteCurricular { get; set; }
        public string PerguntaId { get; set; }
        public string OrdemId { get; set; }
        public string GrupoId { get; set; }
    }
}
