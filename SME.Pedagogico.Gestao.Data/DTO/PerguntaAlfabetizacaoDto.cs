namespace SME.Pedagogico.Gestao.Data.DTO
{
    public class PerguntaAlfabetizacaoDto
    {
        public string PerguntaPrincipalId { get; set; }
        public string PerguntaPrincipalDescricao { get; set; }
        public int PerguntaPrincipalOrdenacao { get; set; }
        public string PerguntaSecundariaId { get; set; }
        public string PerguntaSecundariaDescricao { get; set; }
        public int PerguntaSecundariaOrdenacao { get; set; }
        public string RespostaId { get; internal set; }
        public string RespostaDescricao { get; internal set; }
        public int RespostaOrdenacao { get; internal set; }
    }
}
