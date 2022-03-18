using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Data.DTO.RelatorioPorTurma
{
    public class CabecalhoRelatorioProficienciaDTO
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public int Ordenacao { get; set; }
        public List<PerguntasRelatorioDTO> PerguntasFilhas { get; set; }
    }
}
