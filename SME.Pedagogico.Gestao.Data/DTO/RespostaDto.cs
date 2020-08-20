using SME.Pedagogico.Gestao.Models.Autoral;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO
{
    public class RespostaDto
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public int Ordenacao { get; set; }

        public static explicit operator RespostaDto(Resposta resposta) =>
            resposta == null ? null : new RespostaDto
            {
                Id = resposta.Id,
                Descricao = resposta.Descricao
            };
    }
}
