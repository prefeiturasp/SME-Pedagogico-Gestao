using System;

namespace SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO
{
    public class SalasPorUEDTO
    {
        public int CodigoTurma { get; set; }
        public string NomeTurma { get; set; }
        public string TipoTurma { get; set; }
        public string Situacao { get; set; }
        public string DataInicioTurma { get; set; }
        public string DataFimTurma { get; set; }
         
    }
}
