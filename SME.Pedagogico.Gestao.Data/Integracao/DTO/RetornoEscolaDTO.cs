using Newtonsoft.Json;

namespace SME.Pedagogico.Gestao.Data.Integracao.DTO
{
    public class RetornoEscolaDTO
    {
        [JsonProperty(PropertyName = "Codigo")]
        public string CodigoEscola { get; set; }
        public string CodigoDRE { get; set; }
        
        [JsonProperty(PropertyName = "Nome")]
        public string NomeEscola { get; set; }
        public string Sigla { get; set; }
    }
}
