using Newtonsoft.Json;

namespace SME.Pedagogico.Gestao.Data.Integracao.DTO
{
    public class RetornoEscolaDTO
    {
        [JsonProperty(PropertyName = "Codigo")]
        public string CodigoEscola { get; set; }
        public string CodigoDRE { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
    }
}
