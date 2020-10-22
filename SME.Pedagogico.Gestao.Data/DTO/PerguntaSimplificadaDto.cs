using SME.Pedagogico.Gestao.Models.Autoral;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO
{
    public class PerguntaSimplificadaDto
    {
        public string Id { get; set; }
        public string Descricao { get; set; }

        public static explicit operator PerguntaSimplificadaDto(Pergunta pergunta) =>
            pergunta == null ? null : new PerguntaSimplificadaDto
            {
                Descricao = pergunta.Descricao,
                Id = pergunta.Id,
            };
    }
}
