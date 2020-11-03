﻿using Newtonsoft.Json;

namespace SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoNovoSGP
{
    public class DisciplinaRetornoDto
    {
        [JsonProperty("codigoComponenteCurricular")]
        public long CodigoComponenteCurricular { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }
    }
}