using System;

namespace SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO
{
    public class BuscaProfessorDTO
    {
        public int CodigoRF { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string CPF { get; set; }
        public string DataInicioExercicio { get; set; }
    }
}
