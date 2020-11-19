using Newtonsoft.Json;
using System;

namespace SME.Pedagogico.Gestao.Infra
{
    public class AutenticacaoRevalidarRetornoDto
    {
        [JsonProperty("dataHoraExpiracao")]
        public DateTime DataHoraExpiracao { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
