using System;

namespace SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO
{
    class TurmasAtribuidasPorProfessor
    { 
        public int CodigoTurma { get; set; }
        public string NomeTurma { get; set; }
        public string ComponenteCurricular { get; set; } 
        public string DataInicioAtribuicao { get; set; }
        public string DataFimAtribuicao { get; set; }
    }
}
