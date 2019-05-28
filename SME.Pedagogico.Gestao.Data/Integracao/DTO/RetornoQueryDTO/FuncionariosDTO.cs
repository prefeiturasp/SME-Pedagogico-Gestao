
using System; 

namespace SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO
{
    public class FuncionariosDTO
    {
        public int CodigoRF { get; set; }
        public string NomeServidor { get; set; }
         
        public string DataInicio { get; set; }
         
        public string DataFim { get; set; }
         
        public string Cargo { get; set; }
    }
}
