using Newtonsoft.Json;

namespace SME.Pedagogico.Gestao.Data.DTO
{
    public class DadosBasicosSondagemMatematicaDTO
    {
        [JsonProperty(PropertyName = "name")] 
        public string NomeAluno { get; set; }

        [JsonProperty(PropertyName = "sequenceNumber")]
        public string NumeroAlunoChamada { get; set; }

        [JsonProperty(PropertyName = "studentCodeEol")]
        public string CodigoEolAluno { get; set; }

        [JsonProperty(PropertyName = "dreCodeEol")]
        public string CodigoEolDRE { get; set; }

        [JsonProperty(PropertyName = "schoolCodeEol")]
        public string CodigoEolEscola { get; set; }

        [JsonProperty(PropertyName = "schoolYear")]
        public string AnoLetivo { get; set; }

        [JsonProperty(PropertyName = "yearClassroom")]
        public string AnoTurma { get; set; }
    }
}
