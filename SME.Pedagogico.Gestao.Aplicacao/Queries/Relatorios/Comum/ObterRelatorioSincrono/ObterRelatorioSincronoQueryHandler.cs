using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SME.Pedagogico.Gestao.Infra;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class StrParaEnvio
    {
        public object Mensagem { get; set; }

    }
    public class ObterRelatorioSincronoQueryHandler : IRequestHandler<ObterRelatorioSincronoQuery, string>
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;

        public ObterRelatorioSincronoQueryHandler(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<string> Handle(ObterRelatorioSincronoQuery request, CancellationToken cancellationToken)
        {
            var mensagem = JsonConvert.SerializeObject(new { Mensagem = request.Filtros });

            using (var httpClient = httpClientFactory.CreateClient("apiSR"))
            {
                var resposta = await httpClient.PostAsync(request.TipoRelatorio.Name(), new StringContent(mensagem, Encoding.UTF8, "application/json-patch+json"));

                if (!resposta.IsSuccessStatusCode || resposta.StatusCode == HttpStatusCode.NoContent)
                    return null;

                var json = await resposta.Content.ReadAsStringAsync();

                var nomeArquivo = JsonConvert.DeserializeObject<string>(json);

                return $"{configuration.GetValue<string>("UrlApiServidorRelatorios")}v1/downloads/sgp/pdf/{request.TipoRelatorio.ShortName()}.pdf/{nomeArquivo}";
            }

        }
    }
}
