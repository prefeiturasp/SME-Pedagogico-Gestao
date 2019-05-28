using Newtonsoft.Json;

namespace SME.Pedagogico.Gestao.Data.DTO
{
    public class SondagemMatematicaNumerosDTO : DadosBasicosSondagemMatematicaDTO
    {
        [JsonProperty(PropertyName = "familiares1S")]
        public string Familiares1S { get; set; }

        [JsonProperty(PropertyName = "familiares2S")]
        public string Familiares2S { get; set; }

        [JsonProperty(PropertyName = "opacos1S")]
        public string Opacos1S { get; set; }

        [JsonProperty(PropertyName = "opacos2S")]
        public string Opacos2S { get; set; }

        [JsonProperty(PropertyName = "transparentes1S")]
        public string Transparentes1S { get; set; }

        [JsonProperty(PropertyName = "transparentes2S")]
        public string Transparentes2S { get; set; }

        [JsonProperty(PropertyName = "terminamzero1S")]
        public string TerminamZero1S { get; set; }

        [JsonProperty(PropertyName = "terminamzero2S")]
        public string TerminamZero2S { get; set; }

        [JsonProperty(PropertyName = "algarismos1S")]
        public string Algarismos1S { get; set; }

        [JsonProperty(PropertyName = "algarismos2S")]
        public string Algarismos2S { get; set; }

        [JsonProperty(PropertyName = "processo1S")]
        public string Processo1S { get; set; }

        [JsonProperty(PropertyName = "processo2S")]
        public string Processo2S { get; set; }

        [JsonProperty(PropertyName = "zerointercalados1S")]
        public string ZeroIntercalados1S { get; set; }

        [JsonProperty(PropertyName = "zerointercalados2S")]
        public string ZeroIntercalados2S { get; set; }
    }
}
