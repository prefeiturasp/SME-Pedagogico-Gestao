using SME.Pedagogico.Gestao.Models.Autoral;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO
{
    public class PerguntaDto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public int Ordenacao { get; set; }
        public IEnumerable<RespostaDto> Respostas { get; set; }

        public static explicit operator PerguntaDto(Pergunta pergunta) =>
            pergunta == null ? null : new PerguntaDto
            {
                 Descricao = pergunta.Descricao,
                 Id = pergunta.Id,
            };
    }
}
