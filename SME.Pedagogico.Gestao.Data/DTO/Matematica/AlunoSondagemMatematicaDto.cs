using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO.Matematica
{
    public class AlunoSondagemMatematicaDto
    {
        public string Id { get; set; }
        public string CodigoAluno { get; set; }
        public string NomeAluno { get; set; }
        public string CodigoTurma { get; set; }
        public string CodigoDre { get; set; }
        public string CodigoUe { get; set; }
        public int AnoLetivo { get; set; }
        public int AnoTurma { get; set; }
        public string ComponenteCurricular { get; set; }
        public IEnumerable<AlunoRespostaDto> Respostas { get; set; }
    }
}
