namespace SME.Pedagogico.Gestao.Infra
{
    public class RelatorioImpressaoFiltroDto
    {
        public int AnoLetivo { get; set; }
        public string Ano { get; set; }
        public long DreCodigo { get; set; }
        public long UeCodigo { get; set; }
        public int TurmaCodigo { get; set; }
        public ComponenteCurricularEnum ComponenteCurricular { get; set; }
        public ProficienciaEnum Proficiencia { get; set; }
        public int Semestre { get; set; }
        public string UsuarioRF { get; set; }
    }
}
