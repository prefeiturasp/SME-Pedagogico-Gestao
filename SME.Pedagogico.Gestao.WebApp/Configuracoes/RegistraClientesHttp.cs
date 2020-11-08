using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

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
            });

            services.AddHttpClient(name: "apiSGP", c =>
            {
                c.BaseAddress = new Uri(configuration.GetSection("urlApiSgp").Value);
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddHttpClient(name: "apiEOL", c =>
            {
                c.BaseAddress = new Uri(configuration.GetSection("urlApiEol").Value);
                c.DefaultRequestHeaders.Add("x-api-eol-key", configuration.GetSection("API_EOL_KEY_ENV").Value);
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });

        }
    }
}
