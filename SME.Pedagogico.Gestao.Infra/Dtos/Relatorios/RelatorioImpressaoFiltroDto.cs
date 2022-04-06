namespace SME.Pedagogico.Gestao.Infra
{
    public class RelatorioImpressaoFiltroDto
    {
        public RelatorioImpressaoFiltroDto()
        {
            Modalidades = new int[] { 5, 13 }; //modalidades consideradas pelo sondagem
        }

        public int AnoLetivo { get; set; }
        public string Ano { get; set; }
        public long DreCodigo { get; set; }
        public string UeCodigo { get; set; }
        public int TurmaCodigo { get; set; }
        public ComponenteCurricularEnum ComponenteCurricularId { get; set; }
        public ProficienciaEnum ProficienciaId { get; set; }
        public int Semestre { get; set; }
        public int Bimestre { get; set; }
        public string UsuarioRF { get; set; }
        public string GrupoId { get; set; }
        public int[] Modalidades { get; }
    }
}
