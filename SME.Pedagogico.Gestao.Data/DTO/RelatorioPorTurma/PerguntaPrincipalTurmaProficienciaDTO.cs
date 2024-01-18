namespace SME.Pedagogico.Gestao.Data.DTO.RelatorioPorTurma
{
    public class PerguntaPrincipalTurmaProficienciaDTO
    {
        public string PerguntaId {  get; set; }
        public string PerguntaDescricao { get ; set; }
        public string SubPerguntaId {  get; set; }
        public string SubPerguntaDescricao { get; set; }
        public int OrdemPergunta { get; set; }
    }
}
