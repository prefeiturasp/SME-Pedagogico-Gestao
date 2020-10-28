using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;

namespace SME.Pedagogico.Gestao.WebApp.Configuracoes
{
    public static class RegistraClientesHttp
    {
        public static void Registrar(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient(name: "apiSR", c =>
            {
                c.BaseAddress = new Uri(configuration.GetSection("UrlApiServidorRelatorios").Value);
                c.DefaultRequestHeaders.Add("Accept", "application/json");
                c.Timeout = Timeout.InfiniteTimeSpan;
            });

        }
    }
}
