using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Data.DTO.Matematica
{
    public class GraficosRelatorioProficienciaDTO
    {
        public string Nome { get; set; }

        public List<GraficosRelatorioDTO> ListaDeGrafico { get; set; }
    }
}
