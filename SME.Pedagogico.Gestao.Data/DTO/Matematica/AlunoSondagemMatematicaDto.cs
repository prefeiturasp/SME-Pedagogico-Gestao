using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO.Matematica
{
    public class AlunoSondagemMatematicaDto
    {
        public Guid Id { get; set; }
        public string CodigoAluno { get; set; }
        public string NomeAluno { get; set; }
        public Guid PeriodoId { get; set; }
        public string CodigoTurma { get; set; }
        public string CodigoDre { get; set; }
        public string CodigoUe { get; set; }
        public int AnoLetivo { get; set; }
        public int AnoTurma { get; set; }
        public Guid ComponenteCurricular { get; set; }
        public IEnumerable<AlunoRespostaDto> Respostas { get; set; }
    }
}
