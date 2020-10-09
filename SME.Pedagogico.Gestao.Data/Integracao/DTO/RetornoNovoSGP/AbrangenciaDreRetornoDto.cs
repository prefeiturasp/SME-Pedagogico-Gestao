﻿using Newtonsoft.Json;

namespace SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoNovoSGP
{
    public class AbrangenciaDreRetornoDto
    {
        [JsonProperty("abreviacao")]
        public string Abreviacao { get; set; }
        [JsonProperty("codigo")]
        public string Codigo { get; set; }
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("id")]
        public long Id { get; set; }
    }
}
