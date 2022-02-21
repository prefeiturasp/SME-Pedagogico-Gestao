using SME.Pedagogico.Gestao.Models.Autoral;
using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Data.DTO
{
    public class PerguntaDto : PerguntaSimplificadaDto
    {       
        public int Ordenacao { get; set; }
        public int? SequenciaOrdem { get; set; }
        public IEnumerable<PerguntaDto> Perguntas { get; set; }
        public string PerguntaAnoEscolar { get; set; }
        public IEnumerable<RespostaDto> Respostas { get; set; }

        public static explicit operator PerguntaDto(Pergunta pergunta) =>
            pergunta == null ? null : new PerguntaDto
            {
                 Descricao = pergunta.Descricao,
                 Id = pergunta.Id,
            };
    }
}
