using Newtonsoft.Json;

namespace SME.Pedagogico.Gestao.Data.DTO
{
    public class FiltroSondagemMatematicaDTO
    {
        [JsonProperty(PropertyName = "dreCodeEol")]
        public string DreEolCode { get; set; }

        [JsonProperty(PropertyName = "schoolCodeEol")]
        public string EscolaEolCode { get; set; }

        [JsonProperty(PropertyName = "classroomCodeEol")]
        public string TurmaEolCode { get; set; }

        [JsonProperty(PropertyName = "schoolYear")]
        public string AnoLetivo { get; set; }

        [JsonProperty(PropertyName = "yearClassroom")]
        public string AnoTurma { get; set; }

        [JsonProperty(PropertyName = "grupoClassroom")]
        public int Grupo { get; set; }
    }
}
