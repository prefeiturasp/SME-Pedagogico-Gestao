using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SME.Pedagogico.Gestao.Dominio;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class SalvarLogViaRabbitCommand : IRequest
    {
        public SalvarLogViaRabbitCommand(string mensagem, LogNivel nivel, LogContexto contexto, string observacao = "", string projeto = "Sondagem", string rastreamento = "", string excecaoInterna = "")
        {
            Mensagem = mensagem;
            Nivel = nivel;
            Contexto = contexto;
            Observacao = observacao;
            Projeto = projeto;
            Rastreamento = rastreamento;
            ExcecaoInterna = excecaoInterna;
        }

        public string Mensagem { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public LogNivel Nivel { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public LogContexto Contexto { get; set; }
        public string Observacao { get; set; }
        public string Projeto { get; set; }
        public string Rastreamento { get; set; }
        public string ExcecaoInterna { get; }
    }
}
