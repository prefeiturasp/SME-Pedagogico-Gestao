using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO.Matematica
{
    public class AlunoRespostaDto
    {
        public Guid Pergunta { get; set; }
        public Guid? Resposta { get; set; }
    }
}
