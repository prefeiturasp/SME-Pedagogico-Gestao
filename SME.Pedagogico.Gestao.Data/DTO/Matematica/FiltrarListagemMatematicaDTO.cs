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
        public string Perguntas { get; set; }
        public int? Bimestre { get; set; }
        public int? Grupo { get; set; }
    }
}
