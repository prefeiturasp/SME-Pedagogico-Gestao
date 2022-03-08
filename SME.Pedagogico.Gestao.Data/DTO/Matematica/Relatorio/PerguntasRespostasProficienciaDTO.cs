namespace SME.Pedagogico.Gestao.Data.DTO.Matematica.Relatorio
{
    public class PerguntasRespostasProficienciaDTO : PerguntasRespostasDTO
    {
        public string SubPerguntaId { get; set; }

        public string SubPerguntaDescricao { get; set; }

        public int OrdemPergunta { get; set; }
    }
}
