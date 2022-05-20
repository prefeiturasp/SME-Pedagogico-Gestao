namespace SME.Pedagogico.Gestao.Data.DTO.RelatorioPorTurma
{
    public class AlunoPerguntaRespostaProficienciaDTO
    {
        public string CodigoAluno { get; set; }
        public string NomeAluno { get; set; }
        public int OrdemPergunta { get; set; }
        public string PerguntaId { get; set; }
        public string PerguntaDescricao { get; set; }
        public string SubPerguntaId { get; set; }
        public string SubPerguntaDescricao { get; set; }
        public int OrdemResposta { get; set; }
        public string RespostaId { get; set; }
        public string RespostaDescricao { get; set; }
    }
}
