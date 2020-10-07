using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SME.Pedagogico.Gestao.Data.Integracao.DTO
{ 
    public class RetornoTurmaDTO
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }        
        public string NomeTurma { get { return Nome; } }
        public string CodigoEscola { get; set; }
    }
}
