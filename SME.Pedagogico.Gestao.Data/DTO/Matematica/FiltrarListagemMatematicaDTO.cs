namespace SME.Pedagogico.Gestao.Data.DTO.Matematica
{
    public class FiltrarListagemMatematicaDTO
    {
        public int AnoEscolar { get; set; }
        public int AnoLetivo { get; set; }
        public string CodigoDre { get; set; }
        public string CodigoUe { get; set; }
        public string CodigoTurma { get; set; }
        public string ComponenteCurricular { get; set; }
        public string PerguntaId { get; set; }
        public int? Bimestre { get; set; }
        public string PerguntaAnoEscolar { get; set; }
    }
}
