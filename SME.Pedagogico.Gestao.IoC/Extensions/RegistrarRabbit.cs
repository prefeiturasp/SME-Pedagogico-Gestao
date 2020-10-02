using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using SME.Pedagogico.Gestao.Infra;
using System;

namespace SME.Pedagogico.Gestao.IoC
{
    public static class RegistrarRabbit
    {
        public static void AddRabbit(this IServiceCollection services)
        {
            var factory = new ConnectionFactory
            {
                HostName = Environment.GetEnvironmentVariable("ConfiguracaoRabbit__HostName"),
                UserName = Environment.GetEnvironmentVariable("ConfiguracaoRabbit__UserName"),
                Password = Environment.GetEnvironmentVariable("ConfiguracaoRabbit__Password"),
                VirtualHost = Environment.GetEnvironmentVariable("ConfiguracaoRabbit__Virtualhost")
            };

            var conexaoRabbit = factory.CreateConnection();
            IModel _channel = conexaoRabbit.CreateModel();
            services.AddSingleton(conexaoRabbit);
            services.AddSingleton(_channel);

            _channel.ExchangeDeclare(RotasRabbit.ExchangeSgp, ExchangeType.Topic);
            _channel.QueueDeclare(RotasRabbit.FilaSgp, false, false, false, null);
            _channel.QueueBind(RotasRabbit.FilaSgp, RotasRabbit.ExchangeSgp, "*");
        }
    }
}
