using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Data.DTO.RelatorioPorTurma
{
    public class AlunoPorTurmaRelatorioProficienciaDTO
    {
        public int CodigoAluno { get; set; }

        public string NomeAluno { get; set; }

        public List<PerguntasRelatorioProficienciaDTO> Perguntas { get; set; }
    }
}
