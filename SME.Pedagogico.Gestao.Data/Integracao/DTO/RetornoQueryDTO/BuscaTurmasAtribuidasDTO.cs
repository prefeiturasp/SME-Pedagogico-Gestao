using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO
{
    public class BuscaTurmasAtribuidasDTO
    {
        [JsonProperty(PropertyName = "codigoTurma")]
        public int CodigoTurma { get; set; }

        [JsonProperty(PropertyName = "nomeTurma")]
        public string NomeTurma { get; set; }

        [JsonProperty(PropertyName = "componenteCurricular")]
        public string ComponenteCurricular { get; set; }

        [JsonProperty(PropertyName = "dataInicioAtribuicao")]
        public string DataInicioAtribuicao { get; set; }

        [JsonProperty(PropertyName = "dataFimAtribuicao")]
        public string DataFimAtribuicao { get; set; }
    }
}
