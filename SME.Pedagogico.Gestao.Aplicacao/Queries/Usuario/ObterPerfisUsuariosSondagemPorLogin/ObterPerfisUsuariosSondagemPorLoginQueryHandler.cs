using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;
using SME.Pedagogico.Gestao.Infra;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterPerfisUsuariosSondagemPorLoginQueryHandler: IRequestHandler<ObterPerfisUsuariosSondagemPorLoginQuery, PerfisUsuarioSondagemDto>
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ObterPerfisUsuariosSondagemPorLoginQueryHandler(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<PerfisUsuarioSondagemDto> Handle(ObterPerfisUsuariosSondagemPorLoginQuery request, CancellationToken cancellationToken)
        {
            var httpClient = httpClientFactory.CreateClient("apiEOL");
            var resposta = await httpClient.GetAsync($"AutenticacaoSondagem/perfis/usuarios/{request.Login}");

            if (resposta.IsSuccessStatusCode)
            {
                var json = await resposta.Content.ReadAsStringAsync();
                var retorno = JsonConvert.DeserializeObject<PerfisUsuarioSondagemDto>(json);
                return retorno;
            }
            else
                return null;
        }
    }
}