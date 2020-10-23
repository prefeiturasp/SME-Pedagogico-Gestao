using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO.Portugues.Relatorio
{
    public class RelatorioPortuguesTurmaAluno
    {
        public string CodigoAluno { get; set; }
        public string NomeAluno { get; set; }
        public int NumeroChamada { get; set; }
        public IEnumerable<string> Perguntas { get; set; }
    }
}

