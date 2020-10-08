namespace SME.Pedagogico.Gestao.Infra
{
    public class RelatorioImpressaoFiltroDto
    {
        public int AnoLetivo { get; set; }
        public string Ano { get; set; }
        public string DreCodigo { get; set; }
        public string UeCodigo { get; set; }
        public string TurmaCodigo { get; set; }
        public ComponenteCurricularEnum ComponenteCurricular { get; set; }
        public ProficienciaEnum Proficiencia { get; set; }
        public int Semestre { get; set; }
        public string UsuarioRF { get; set; }
    }
}
