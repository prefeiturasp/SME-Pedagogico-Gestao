using SME.Pedagogico.Gestao.Data.DTO.Matematica.Relatorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO.Matematica.Relatorio
{
    public class PerguntaDTO
    {
        public string  Nome { get; set; }
        public TotalDTO Total { get; set; }
        public List<RespostaDTO> Respostas { get; set; }

    }
}
