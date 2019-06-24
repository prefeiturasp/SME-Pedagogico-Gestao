using Newtonsoft.Json;

namespace SME.Pedagogico.Gestao.Data.Integracao.DTO
{
    public class RetornoTurmaDTO
    {

        [JsonProperty(PropertyName = "Codigo")]
        public string CodigoTurma { get; set; }

        [JsonProperty(PropertyName = "Nome")]
        public string NomeTurma { get; set; }

        [JsonProperty(PropertyName = "CodigoEscola")]
        public string CodigoEscola { get; set; }
    }
}
