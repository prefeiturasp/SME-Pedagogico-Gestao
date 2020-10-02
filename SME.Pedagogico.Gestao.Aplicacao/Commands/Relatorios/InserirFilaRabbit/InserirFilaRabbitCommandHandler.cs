using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SME.Pedagogico.Gestao.Infra;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class InserirFilaRabbitCommandHandler : IRequestHandler<InserirFilaRabbitCommand, bool>
    {
        private readonly IModel rabbitChannel;

        public InserirFilaRabbitCommandHandler(IModel rabbitChannel)
        {
            this.rabbitChannel = rabbitChannel ?? throw new ArgumentNullException(nameof(rabbitChannel));
        }

        public Task<bool> Handle(InserirFilaRabbitCommand request, CancellationToken cancellationToken)
        {
            byte[] body = FormataBodyWorker(request.AdicionarFilaDto);

            rabbitChannel.QueueBind(request.AdicionarFilaDto.Fila, request.AdicionarFilaDto.Exchange, request.AdicionarFilaDto.Rota);
            rabbitChannel.BasicPublish(request.AdicionarFilaDto.Exchange, request.AdicionarFilaDto.Rota, null, body);

            return Task.FromResult(true);
        }

        private static byte[] FormataBodyWorker(PublicaFilaRelatoriosDto adicionaFilaDto)
        {
            var request = new MensagemRabbit(adicionaFilaDto.Rota, adicionaFilaDto.Mensagem, adicionaFilaDto.CodigoCorrelacao, adicionaFilaDto.UsuarioLogadoRF, adicionaFilaDto.NotificarErroUsuario);
            var mensagem = JsonConvert.SerializeObject(request);
            var body = Encoding.UTF8.GetBytes(mensagem);
            return body;
        }
    }
}
