using Newtonsoft.Json;

namespace SME.Pedagogico.Gestao.Infra
{
    public class AbrangenciaUeRetornoDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("codigo")]
        public string Codigo { get; set; }
        [JsonProperty("nomeSimples")]
        public string NomeSimples { get; set; }
        [JsonProperty("tipoEscola")]
        public int TipoEscola { get; set; }
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("ehInfantil")]
        public bool EhInfantil { get; set; }
    }
}
