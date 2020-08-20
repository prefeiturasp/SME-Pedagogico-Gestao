using SME.Pedagogico.Gestao.Data.Enums;
using SME.Pedagogico.Gestao.Models.Autoral;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO.Matematica
{
    public class PeriodoDto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public static explicit operator PeriodoDto(Periodo periodo) =>
            periodo == null ? null : new PeriodoDto
            {
                Descricao = periodo.Descricao,
                Id = periodo.Id
            };
    }
}
