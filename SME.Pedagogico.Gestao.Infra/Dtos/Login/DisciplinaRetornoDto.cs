using Newtonsoft.Json;

namespace SME.Pedagogico.Gestao.Infra
{
    public class DisciplinaRetornoDto
    {
        [JsonProperty("codigoComponenteCurricular")]
        public string CodigoComponenteCurricular { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }
    }
}
