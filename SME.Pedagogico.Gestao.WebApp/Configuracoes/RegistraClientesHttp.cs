﻿using Microsoft.Extensions.Configuration;
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
                c.DefaultRequestHeaders.Add("x-sr-api-key", configuration.GetSection("ApiKeySr").Value);
                c.DefaultRequestHeaders.Add("Accept", "application/json");
                c.Timeout = Timeout.InfiniteTimeSpan;
            });

            services.AddHttpClient(name: "apiSGP", c =>
            {
                c.BaseAddress = new Uri(configuration.GetSection("urlApiSgp").Value);
                c.DefaultRequestHeaders.Add("Accept", "application/json");
                c.DefaultRequestHeaders.Add("x-sgp-api-key", configuration.GetSection("ChaveIntegracaoSgpApi").Value);
            });

            services.AddHttpClient(name: "apiEOL", c =>
            {
                c.BaseAddress = new Uri(configuration.GetSection("UrlApiEOL").Value);
                c.DefaultRequestHeaders.Add("Accept", "application/json");
                c.DefaultRequestHeaders.Add("x-api-eol-key", configuration.GetSection("ApiKeyEolApi").Value);
            });
        }
    }
}
