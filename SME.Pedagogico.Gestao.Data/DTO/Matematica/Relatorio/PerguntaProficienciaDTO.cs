using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Data.DTO.Matematica.Relatorio
{
    public class PerguntaProficienciaDTO
    {
        public string Nome { get; set; }

        public List<PerguntaDTO> SubPerguntas { get; set; }
    }
}
