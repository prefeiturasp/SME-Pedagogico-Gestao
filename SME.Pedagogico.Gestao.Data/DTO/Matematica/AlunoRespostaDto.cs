using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO.Matematica
{
    public class AlunoRespostaDto
    {
        public string PeriodoId { get; set; }
        public string Pergunta { get; set; }
        public string Resposta { get; set; }
        public int Bimestre { get; set; }
    }
}
