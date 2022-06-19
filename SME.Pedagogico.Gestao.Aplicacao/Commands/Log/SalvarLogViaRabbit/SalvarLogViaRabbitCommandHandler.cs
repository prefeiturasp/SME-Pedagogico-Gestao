using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SME.Pedagogico.Gestao.Infra;
using SME.Pedagogico.Gestao.Infra.Utilitarios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class SalvarLogViaRabbitCommandHandler : AsyncRequestHandler<SalvarLogViaRabbitCommand>
    {
        private readonly ConfiguracaoRabbitLogOptions configuracaoRabbitOptions;

        public SalvarLogViaRabbitCommandHandler(ConfiguracaoRabbitLogOptions configuracaoRabbitOptions)
        {
            this.configuracaoRabbitOptions = configuracaoRabbitOptions ?? throw new ArgumentNullException(nameof(configuracaoRabbitOptions));
        }

        protected override async Task Handle(SalvarLogViaRabbitCommand request, CancellationToken cancellationToken)
        {
            var mensagem = JsonConvert.SerializeObject(new LogMensagem(request.Mensagem,
                                                                       request.Nivel.ToString(),
                                                                       request.Contexto.ToString(),
                                                                       request.Observacao,
                                                                       request.Projeto,
                                                                       request.Rastreamento,
                                                                       request.ExcecaoInterna), new JsonSerializerSettings
                                                                       {
                                                                           NullValueHandling = NullValueHandling.Ignore
                                                                       });

            var body = Encoding.UTF8.GetBytes(mensagem);

            PublicarMensagem(body);
        }

        private void PublicarMensagem(byte[] body)
        {
            var factory = new ConnectionFactory
            {
                HostName = configuracaoRabbitOptions.HostName,
                UserName = configuracaoRabbitOptions.UserName,
                Password = configuracaoRabbitOptions.Password,
                VirtualHost = configuracaoRabbitOptions.VirtualHost
            };

            using (var conexaoRabbit = factory.CreateConnection())
            {
                using (IModel _channel = conexaoRabbit.CreateModel())
                {
                    var props = _channel.CreateBasicProperties();

                    _channel.BasicPublish(RotasRabbit.SgpLogs, RotasRabbit.RotaLogs, props, body);
                }
            }
        }
    }

    public class LogMensagem
    {
        public LogMensagem(string mensagem, string nivel, string contexto, string observacao, string projeto, string rastreamento, string excecaoInterna)
        {
            Mensagem = mensagem;
            Nivel = nivel;
            Contexto = contexto;
            Observacao = observacao;
            Projeto = projeto;
            Rastreamento = rastreamento;
            ExcecaoInterna = excecaoInterna;
            DataHora = DateTime.Now;
        }

        public string Mensagem { get; set; }
        public string Nivel { get; set; }
        public string Contexto { get; set; }
        public string Observacao { get; set; }
        public string Projeto { get; set; }
        public string Rastreamento { get; set; }
        public string ExcecaoInterna { get; set; }
        public DateTime DataHora { get; set; }

    }

}
